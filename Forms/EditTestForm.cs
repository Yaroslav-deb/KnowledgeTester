using KnowledgeTester1.Database;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    public partial class EditTestForm : Form
    {
        private readonly int _testId;
        private readonly int _teacherId;
        private readonly Form _parentForm;

        private bool _isNavigateBack = false;

        public EditTestForm(int testId, int teacherId, Form parentForm)
        {
            InitializeComponent();
            _testId = testId;
            _teacherId = teacherId;
            _parentForm = parentForm;

            LoadClasses();
            LoadTestDetails();
            LoadQuestions();

            this.FormClosed += EditTestForm_FormClosed;
        }

        // --- ЗАВАНТАЖЕННЯ ДАНИХ ---

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

                cbClass.DataSource = dt;
                cbClass.DisplayMember = "name";
                cbClass.ValueMember = "id";
            }
            catch (Exception ex) { MessageBox.Show("Помилка класів: " + ex.Message); }
        }

        private void LoadTestDetails()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT title, description, class_id FROM Tests WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", _testId);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTitle.Text = reader.GetString(0);
                    txtDescription.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    int classId = reader.GetInt32(2);
                    cbClass.SelectedValue = classId;
                }
            }
            catch (Exception ex) { MessageBox.Show("Помилка завантаження тесту: " + ex.Message); }
        }

        private void LoadQuestions()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, question_text AS 'Питання' FROM Questions WHERE test_id = @tid";
                cmd.Parameters.AddWithValue("@tid", _testId);
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());

                dgvQuestions.DataSource = table;
                if (dgvQuestions.Columns.Contains("id")) dgvQuestions.Columns["id"].Visible = false;
            }
            catch { }
        }

        // --- ОСНОВНІ ДІЇ ---

        private void btnSave_Click(object sender, EventArgs e)
        {
            var title = txtTitle.Text.Trim();
            var description = txtDescription.Text.Trim();
            int? classId = null;
            if (cbClass.SelectedValue != null) classId = Convert.ToInt32(cbClass.SelectedValue);

            if (string.IsNullOrEmpty(title) || classId == null)
            {
                MessageBox.Show("Заповніть назву та клас!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Tests 
                    SET title = @title, description = @desc, class_id = @cid 
                    WHERE id = @id
                ";
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@cid", classId);
                cmd.Parameters.AddWithValue("@id", _testId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Зміни збережено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _isNavigateBack = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка збереження: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Просто виходимо без збереження змін у полях (title, desc).
            // Питання зберігаються окремо в QuestionEditor, тому їх зміни вже в БД.
            _isNavigateBack = true;
            this.Close();
        }

        // --- РОБОТА З ПИТАННЯМИ ---

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            // Передаємо список з ОДНОГО елемента (поточний тест)
            var f = new QuestionEditorForm(new List<int> { _testId }, this);
            f.FormClosed += (s, ev) => LoadQuestions();
            f.Show();
            this.Hide(); // Ховаємо редактор тесту, показуємо редактор питання
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.CurrentRow == null) return;
            int qid = Convert.ToInt32(dgvQuestions.CurrentRow.Cells["id"].Value);

            var f = new QuestionEditorForm(new List<int> { _testId }, this, qid);
            f.FormClosed += (s, ev) => LoadQuestions();
            f.Show();
            this.Hide();
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.CurrentRow == null) return;
            int qid = Convert.ToInt32(dgvQuestions.CurrentRow.Cells["id"].Value);

            if (MessageBox.Show("Видалити питання?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using var conn = DatabaseHelper.GetConnection();
                    // 1. Спочатку видаляємо відповіді (для надійності)
                    using (var cmdA = conn.CreateCommand())
                    {
                        cmdA.CommandText = "DELETE FROM Answers WHERE question_id = @qid";
                        cmdA.Parameters.AddWithValue("@qid", qid);
                        cmdA.ExecuteNonQuery();
                    }
                    // 2. Видаляємо питання
                    using (var cmdQ = conn.CreateCommand())
                    {
                        cmdQ.CommandText = "DELETE FROM Questions WHERE id = @id";
                        cmdQ.Parameters.AddWithValue("@id", qid);
                        cmdQ.ExecuteNonQuery();
                    }
                    LoadQuestions();
                }
                catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
            }
        }

        // --- НАВІГАЦІЯ ---

        private void EditTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isNavigateBack)
            {
                if (_parentForm != null && !_parentForm.IsDisposed)
                {
                    if (_parentForm is TeacherForm tf) tf.LoadTests();
                    _parentForm.Show();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        // Цей метод потрібен, щоб QuestionEditorForm міг нас оновити
        public void LoadQuestionsPublic()
        {
            LoadQuestions();
        }
    }
}