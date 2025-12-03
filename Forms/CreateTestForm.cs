using KnowledgeTester1.Database;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    public partial class CreateTestForm : Form
    {
        private readonly int _teacherId;
        private readonly Form _parentForm;

        private List<int> _createdTestIds = new List<int>();

        // ID головного тесту (першого в списку), для відображення питань у таблиці
        private int _mainTestId = -1;

        // --- НОВА ЗМІННА ---
        // Якщо true - значить ми натиснули "Назад" або "Скасувати" і хочемо повернутися.
        // Якщо false - значить ми натиснули Хрестик і хочемо вийти з програми.
        private bool _isNavigateBack = false;

        public CreateTestForm(int teacherId, Form parentForm)
        {
            InitializeComponent();
            _teacherId = teacherId;
            _parentForm = parentForm;

            LoadClasses();
            LoadSubjects();

            ToggleQuestionButtons(false);

            lnkBack.Enabled = false;
            lnkBack.LinkColor = Color.Gray;

            lnkBack.Click += lnkBack_Click;
            this.FormClosed += CreateTestForm_FormClosed;
        }

        private void CreateTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isNavigateBack)
            {
                if (_parentForm != null && !_parentForm.IsDisposed)
                {
                    if (_parentForm is TeacherForm teacherForm)
                    {
                        teacherForm.LoadTests();
                    }
                    _parentForm.Show();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void lnkBack_Click(object sender, EventArgs e)
        {
            _isNavigateBack = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_createdTestIds.Count > 0)
            {
                if (MessageBox.Show("Скасувати створення тестів? Всі дані будуть втрачені.", "Скасування",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using var conn = DatabaseHelper.GetConnection();
                        using var transaction = conn.BeginTransaction();

                        foreach (int tid in _createdTestIds)
                        {
                            using (var cmdDelA = conn.CreateCommand())
                            {
                                cmdDelA.Transaction = transaction;
                                cmdDelA.CommandText = "DELETE FROM Answers WHERE question_id IN (SELECT id FROM Questions WHERE test_id = @tid)";
                                cmdDelA.Parameters.AddWithValue("@tid", tid);
                                cmdDelA.ExecuteNonQuery();
                            }

                            using (var cmdDelQ = conn.CreateCommand())
                            {
                                cmdDelQ.Transaction = transaction;
                                cmdDelQ.CommandText = "DELETE FROM Questions WHERE test_id = @tid";
                                cmdDelQ.Parameters.AddWithValue("@tid", tid);
                                cmdDelQ.ExecuteNonQuery();
                            }

                            using (var cmdDelT = conn.CreateCommand())
                            {
                                cmdDelT.Transaction = transaction;
                                cmdDelT.CommandText = "DELETE FROM Tests WHERE id = @id";
                                cmdDelT.Parameters.AddWithValue("@id", tid);
                                cmdDelT.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка видалення: " + ex.Message);
                    }

                    _isNavigateBack = true;
                    this.Close();
                }
            }
            else
            {
                _isNavigateBack = true;
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var title = txtTitle.Text.Trim();
            var description = txtDescription.Text.Trim();
            int? subjectId = null;
            if (cbSubject.SelectedValue != null) subjectId = Convert.ToInt32(cbSubject.SelectedValue);

            int selectedClassId = Convert.ToInt32(cbClass.SelectedValue);

            if (string.IsNullOrEmpty(title) || subjectId == null)
            {
                MessageBox.Show("Заповніть назву та предмет!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                List<int> targetClassIds = new List<int>();

                if (selectedClassId == -1)
                {
                    foreach (DataRowView item in cbClass.Items)
                    {
                        int id = Convert.ToInt32(item["id"]);
                        if (id != -1) targetClassIds.Add(id);
                    }
                }
                else
                {
                    targetClassIds.Add(selectedClassId);
                }

                using var transaction = conn.BeginTransaction();

                try
                {
                    foreach (int classId in targetClassIds)
                    {
                        using var cmd = conn.CreateCommand();
                        cmd.Transaction = transaction;
                        cmd.CommandText = @"
                            INSERT INTO Tests (title, description, class_id, teacher_id)
                            VALUES (@title, @desc, @classId, @teacherId);
                            SELECT last_insert_rowid();
                            SELECT last_insert_rowid();
                        ";
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@desc", description);
                        cmd.Parameters.AddWithValue("@classId", classId);
                        cmd.Parameters.AddWithValue("@teacherId", _teacherId);

                        long newId = Convert.ToInt64(cmd.ExecuteScalar());
                        _createdTestIds.Add((int)newId);
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                if (_createdTestIds.Count > 0)
                {
                    _mainTestId = _createdTestIds[0];

                    string msg = selectedClassId == -1
                        ? $"Тест створено для {_createdTestIds.Count} класів!"
                        : "Тест успішно створено!";

                    btnSave.Enabled = false;
                    btnSave.BackColor = Color.Gray;
                    btnSave.Text = "Збережено";

                    lnkBack.Enabled = true;
                    lnkBack.LinkColor = Color.Plum;

                    ToggleQuestionButtons(true);
                    LoadQuestions();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка збереження: " + ex.Message);
            }
        }


        private void btnCreateQuestion_Click(object sender, EventArgs e)
        {
            this.Hide();

            var f = new QuestionEditorForm(_createdTestIds, this);
            f.Show();
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.CurrentRow == null) return;
            int qid = Convert.ToInt32(dgvQuestions.CurrentRow.Cells["id"].Value);

            // Ховаємо цю форму
            this.Hide();

            // Передаємо "this" як батьківську форму і ID питання
            var f = new QuestionEditorForm(_createdTestIds, this, qid);
            f.Show();
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.CurrentRow == null) return;

            // 2. Получаем ID вопроса
            int qid = Convert.ToInt32(dgvQuestions.CurrentRow.Cells["id"].Value);

            if (MessageBox.Show("Видалити питання?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using var conn = DatabaseHelper.GetConnection();
                    using var transaction = conn.BeginTransaction(); // Начинаем транзакцию

                    try
                    {
                        // КРОК 1: Видаляємо всі ВІДПОВІДІ, що прив'язані до цього питання
                        using (var cmdA = conn.CreateCommand())
                        {
                            cmdA.Transaction = transaction;
                            cmdA.CommandText = "DELETE FROM Answers WHERE question_id = @qid";
                            cmdA.Parameters.AddWithValue("@qid", qid);
                            cmdA.ExecuteNonQuery();
                        }

                        // КРОК 2: Тепер спокійно видаляємо саме ПИТАННЯ
                        using (var cmdQ = conn.CreateCommand())
                        {
                            cmdQ.Transaction = transaction;
                            cmdQ.CommandText = "DELETE FROM Questions WHERE id = @id";
                            cmdQ.Parameters.AddWithValue("@id", qid);
                            cmdQ.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Применяем изменения
                        LoadQuestions();      // Обновляем таблицу
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Если ошибка - отменяем удаление
                        MessageBox.Show("Помилка транзакції: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до БД: " + ex.Message);
                }
            }
        }

        // --- ДОПОМІЖНІ МЕТОДИ ---

        public void LoadQuestions()
        {
            if (_mainTestId <= -1) return;
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, question_text AS 'Питання' FROM Questions WHERE test_id = @tid";
                cmd.Parameters.AddWithValue("@tid", _mainTestId);
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());

                dgvQuestions.DataSource = table;
                if (dgvQuestions.Columns.Contains("id")) dgvQuestions.Columns["id"].Visible = false;

                dgvQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvQuestions.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvQuestions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch { }
        }

        private void ToggleQuestionButtons(bool enabled)
        {
            btnCreateQuestion.Enabled = enabled;
            btnEditQuestion.Enabled = enabled;
            btnDeleteQuestion.Enabled = enabled;

            Color btnColor = enabled ? Color.FromArgb(72, 61, 139) : Color.Gray;
            btnCreateQuestion.BackColor = btnColor;
            btnEditQuestion.BackColor = btnColor;
            btnDeleteQuestion.BackColor = enabled ? Color.FromArgb(139, 0, 139) : Color.Gray;
        }

        private void LoadClasses()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT c.id, c.name FROM Classes c 
                                    INNER JOIN TeacherClasses tc ON c.id = tc.class_id 
                                    WHERE tc.teacher_id = @tid ORDER BY c.name";
                cmd.Parameters.AddWithValue("@tid", _teacherId);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                DataTable comboSource = new DataTable();
                comboSource.Columns.Add("id", typeof(int));
                comboSource.Columns.Add("name", typeof(string));

                if (dt.Rows.Count > 0)
                {
                    comboSource.Rows.Add(-1, "--- Всі мої класи ---");
                }

                foreach (DataRow row in dt.Rows)
                {
                    comboSource.Rows.Add(row["id"], row["name"]);
                }

                cbClass.DataSource = comboSource;
                cbClass.DisplayMember = "name";
                cbClass.ValueMember = "id";
            }
            catch (Exception ex) { MessageBox.Show("Помилка класів: " + ex.Message); }
        }

        private void LoadSubjects()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT s.id, s.name FROM Subjects s 
                                    INNER JOIN TeacherSubjects ts ON s.id = ts.subject_id 
                                    WHERE ts.teacher_id = @tid ORDER BY s.name";
                cmd.Parameters.AddWithValue("@tid", _teacherId);
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                cbSubject.DataSource = table;
                cbSubject.DisplayMember = "name";
                cbSubject.ValueMember = "id";
            }
            catch (Exception ex) { MessageBox.Show("Помилка предметів: " + ex.Message); }
        }
    }
}