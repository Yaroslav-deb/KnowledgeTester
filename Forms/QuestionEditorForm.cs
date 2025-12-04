using KnowledgeTester1.Database;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    public partial class QuestionEditorForm : Form
    {
        private readonly List<int> _testIds;
        private readonly Form _parentForm;

        private int? _mainQuestionId;
        private List<int> _linkedQuestionIds = new List<int>();

        private bool _isNavigateBack = false;
        private bool _isEditingMode = false;

        public QuestionEditorForm(List<int> testIds, Form parentForm, int? mainQuestionId = null)
        {
            InitializeComponent();
            _testIds = testIds;
            _parentForm = parentForm;
            _mainQuestionId = mainQuestionId;

            ToggleAnswerButtons(false);
            lnkBack.Enabled = false;
            lnkBack.LinkColor = Color.Gray;

            if (_mainQuestionId != null)
            {
                _isEditingMode = true;

                LoadQuestionText();
                LoadAnswers();

                btnSave.Enabled = false;
                btnSave.BackColor = Color.Gray;
                btnSave.Text = "Збережено";

                ToggleAnswerButtons(true);
                lnkBack.Enabled = true;
                lnkBack.LinkColor = Color.Plum;
            }

            lnkBack.Click += lnkBack_Click;
            this.FormClosed += QuestionEditorForm_FormClosed;
        }

        // --- ЛОГІКА ЗАКРИТТЯ ---
        private void QuestionEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isNavigateBack)
            {
                if (_parentForm != null && !_parentForm.IsDisposed)
                {
                    // Якщо батько - це форма створення
                    if (_parentForm is CreateTestForm createForm)
                    {
                        createForm.LoadQuestions();
                    }
                    else if (_parentForm is EditTestForm editForm)
                    {
                        editForm.LoadQuestionsPublic();
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
            if (_mainQuestionId != null && !_isEditingMode)
            {
                if (MessageBox.Show("Скасувати створення питання? Воно буде видалене.", "Скасування",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using var conn = DatabaseHelper.GetConnection();
                        using var transaction = conn.BeginTransaction();

                        foreach (int qid in _linkedQuestionIds)
                        {
                            using (var cmdA = conn.CreateCommand())
                            {
                                cmdA.Transaction = transaction;
                                cmdA.CommandText = "DELETE FROM Answers WHERE question_id = @qid";
                                cmdA.Parameters.AddWithValue("@qid", qid);
                                cmdA.ExecuteNonQuery();
                            }

                            using (var cmdQ = conn.CreateCommand())
                            {
                                cmdQ.Transaction = transaction;
                                cmdQ.CommandText = "DELETE FROM Questions WHERE id = @id";
                                cmdQ.Parameters.AddWithValue("@id", qid);
                                cmdQ.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при скасуванні: " + ex.Message);
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


        private void ToggleAnswerButtons(bool enabled)
        {
            btnAddAnswer.Enabled = enabled;
            btnEditAnswer.Enabled = enabled;
            btnDeleteAnswer.Enabled = enabled;
            Color c = enabled ? Color.FromArgb(72, 61, 139) : Color.Gray;
            btnAddAnswer.BackColor = c;
            btnEditAnswer.BackColor = c;
            btnDeleteAnswer.BackColor = enabled ? Color.FromArgb(139, 0, 139) : Color.Gray;
        }

        private void LoadQuestionText()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT question_text FROM Questions WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", _mainQuestionId);
                var res = cmd.ExecuteScalar();
                txtQuestion.Text = res?.ToString() ?? "";
            }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Введіть текст питання!");
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var transaction = conn.BeginTransaction();

                if (_mainQuestionId == null) _linkedQuestionIds.Clear();

                try
                {
                    if (_mainQuestionId == null)
                    {
                        for (int i = 0; i < _testIds.Count; i++)
                        {
                            using var cmd = conn.CreateCommand();
                            cmd.Transaction = transaction;
                            cmd.CommandText = "INSERT INTO Questions (test_id, question_text) VALUES (@tid, @text); SELECT last_insert_rowid();";
                            cmd.Parameters.AddWithValue("@tid", _testIds[i]);
                            cmd.Parameters.AddWithValue("@text", txtQuestion.Text);
                            long newId = Convert.ToInt64(cmd.ExecuteScalar());

                            if (i == 0) _mainQuestionId = (int)newId;
                            _linkedQuestionIds.Add((int)newId);
                        }
                    }
                    else
                    {
                        using var cmd = conn.CreateCommand();
                        cmd.Transaction = transaction;
                        cmd.CommandText = "UPDATE Questions SET question_text = @text WHERE id = @id";
                        cmd.Parameters.AddWithValue("@text", txtQuestion.Text);
                        cmd.Parameters.AddWithValue("@id", _mainQuestionId);
                        cmd.ExecuteNonQuery();

                        if (!_linkedQuestionIds.Contains(_mainQuestionId.Value))
                            _linkedQuestionIds.Add(_mainQuestionId.Value);
                    }

                    transaction.Commit();

                    btnSave.Enabled = false;
                    btnSave.BackColor = Color.Gray;
                    btnSave.Text = "Збережено";
                    lnkBack.Enabled = true;
                    lnkBack.LinkColor = Color.Plum;
                    ToggleAnswerButtons(true);
                    LoadAnswers();
                }
                catch { transaction.Rollback(); throw; }
            }
            catch (Exception ex) { MessageBox.Show("Помилка збереження: " + ex.Message); }
        }

        private void LoadAnswers()
        {
            if (_mainQuestionId == null) return;
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, answer_text AS 'Відповідь', is_correct AS 'Правильна' FROM Answers WHERE question_id = @qid ORDER BY id";
                cmd.Parameters.AddWithValue("@qid", _mainQuestionId);
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgvAnswers.DataSource = table;
                if (dgvAnswers.Columns.Contains("id")) dgvAnswers.Columns["id"].Visible = false;
                dgvAnswers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch { }
        }

        private void btnAddAnswer_Click(object sender, EventArgs e)
        {
            if (_mainQuestionId == null) return;
            var f = new AnswerEditorForm(_mainQuestionId.Value);
            if (f.ShowDialog() == DialogResult.OK)
            {
                SyncAnswersFromMain();
                LoadAnswers();
            }
        }

        private void btnEditAnswer_Click(object sender, EventArgs e)
        {
            if (dgvAnswers.CurrentRow == null) return;
            int ansId = Convert.ToInt32(dgvAnswers.CurrentRow.Cells["id"].Value);
            var f = new AnswerEditorForm(_mainQuestionId.Value, ansId);
            if (f.ShowDialog() == DialogResult.OK)
            {
                SyncAnswersFromMain();
                LoadAnswers();
            }
        }

        private void btnDeleteAnswer_Click(object sender, EventArgs e)
        {
            if (dgvAnswers.CurrentRow == null) return;
            int ansId = Convert.ToInt32(dgvAnswers.CurrentRow.Cells["id"].Value);
            if (MessageBox.Show("Видалити відповідь?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using var conn = DatabaseHelper.GetConnection();
                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Answers WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", ansId);
                    cmd.ExecuteNonQuery();
                    SyncAnswersFromMain();
                    LoadAnswers();
                }
                catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
            }
        }

        private void SyncAnswersFromMain()
        {
            if (_linkedQuestionIds.Count <= 1) return;
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                List<(string text, int correct)> mainAnswers = new List<(string, int)>();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT answer_text, is_correct FROM Answers WHERE question_id = @qid";
                    cmd.Parameters.AddWithValue("@qid", _mainQuestionId);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read()) mainAnswers.Add((reader.GetString(0), reader.GetInt32(1)));
                }

                using var transaction = conn.BeginTransaction();
                try
                {
                    for (int i = 1; i < _linkedQuestionIds.Count; i++)
                    {
                        int targetQId = _linkedQuestionIds[i];
                        using (var cmdDel = conn.CreateCommand())
                        {
                            cmdDel.Transaction = transaction;
                            cmdDel.CommandText = "DELETE FROM Answers WHERE question_id = @qid";
                            cmdDel.Parameters.AddWithValue("@qid", targetQId);
                            cmdDel.ExecuteNonQuery();
                        }
                        foreach (var ans in mainAnswers)
                        {
                            using (var cmdIns = conn.CreateCommand())
                            {
                                cmdIns.Transaction = transaction;
                                cmdIns.CommandText = "INSERT INTO Answers (question_id, answer_text, is_correct) VALUES (@qid, @txt, @cor)";
                                cmdIns.Parameters.AddWithValue("@qid", targetQId);
                                cmdIns.Parameters.AddWithValue("@txt", ans.text);
                                cmdIns.Parameters.AddWithValue("@cor", ans.correct);
                                cmdIns.ExecuteNonQuery();
                            }
                        }
                    }
                    transaction.Commit();
                }
                catch { transaction.Rollback(); }
            }
            catch { }
        }
    }
}