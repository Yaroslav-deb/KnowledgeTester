using KnowledgeTester1.Database;
using System;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    public partial class AnswerEditorForm : Form
    {
        private readonly int _questionId;
        private readonly int? _answerId;

        public AnswerEditorForm(int questionId, int? answerId = null)
        {
            InitializeComponent();
            _questionId = questionId;
            _answerId = answerId;

            if (_answerId != null)
                LoadAnswer();
        }

        private void LoadAnswer()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT answer_text, is_correct FROM Answers WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", _answerId);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtAnswer.Text = reader.GetString(0);
                    chkCorrect.Checked = reader.GetInt32(1) == 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                MessageBox.Show("Введіть текст відповіді!");
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();

                if (_answerId == null)
                {
                    cmd.CommandText = @"INSERT INTO Answers (question_id, answer_text, is_correct) VALUES (@qid, @text, @correct)";
                }
                else
                {
                    cmd.CommandText = @"UPDATE Answers SET answer_text = @text, is_correct = @correct WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", _answerId);
                }

                cmd.Parameters.AddWithValue("@qid", _questionId);
                cmd.Parameters.AddWithValue("@text", txtAnswer.Text);
                cmd.Parameters.AddWithValue("@correct", chkCorrect.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка збереження: " + ex.Message);
            }
        }
    }
}