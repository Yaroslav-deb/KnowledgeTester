using KnowledgeTester1.Database;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    public partial class TestTakingForm : Form
    {
        private readonly int _studentId;
        private readonly int _testId;
        private readonly Form _parentForm;

        private class QuestionInfo
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }

        private List<QuestionInfo> _questions = new List<QuestionInfo>();

        private int _currentIndex = 0;

        private Dictionary<int, int> _userAnswers = new Dictionary<int, int>();

        private bool _isNavigateBack = false;

        public TestTakingForm(int studentId, int testId, string testTitle, string studentName, Form parentForm)
        {
            InitializeComponent();
            _studentId = studentId;
            _testId = testId;
            _parentForm = parentForm;

            lblStudentInfo.Text = $"Студент: {studentName}";
            lblTestTitle.Text = testTitle;

            LoadQuestions();

            if (_questions.Count > 0)
            {
                LoadCurrentQuestion();
            }
            else
            {
                MessageBox.Show("Цей тест не має питань!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isNavigateBack = true;
                this.Close();
            }

            this.FormClosed += TestTakingForm_FormClosed;
        }

        private void LoadQuestions()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, question_text FROM Questions WHERE test_id = @tid";
                cmd.Parameters.AddWithValue("@tid", _testId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _questions.Add(new QuestionInfo
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetString(1)
                    });
                }

                progressBar.Minimum = 0;
                progressBar.Maximum = _questions.Count;
                progressBar.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження питань: " + ex.Message);
            }
        }

        private void LoadCurrentQuestion()
        {
            flowAnswers.Controls.Clear();

            if (_currentIndex < 0 || _currentIndex >= _questions.Count) return;

            var q = _questions[_currentIndex];

            txtQuestionText.Text = q.Text;
            lblQuestionCounter.Text = $"Питання {_currentIndex + 1} з {_questions.Count}";
            progressBar.Value = _currentIndex + 1;

            btnPrev.Enabled = _currentIndex > 0;

            if (_currentIndex == _questions.Count - 1)
            {
                btnNext.Text = "Завершити тест";
                btnNext.BackColor = Color.OrangeRed;
            }
            else
            {
                btnNext.Text = "Далі >>";
                btnNext.BackColor = Color.LimeGreen;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, answer_text FROM Answers WHERE question_id = @qid ORDER BY id"; // Можна додати RANDOM() для перемішування
                cmd.Parameters.AddWithValue("@qid", q.Id);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int ansId = reader.GetInt32(0);
                    string ansText = reader.GetString(1);

                    RadioButton rb = new RadioButton();
                    rb.Text = ansText;
                    rb.Tag = ansId;
                    rb.AutoSize = true;
                    rb.Font = new Font("Segoe UI", 12F);
                    rb.ForeColor = Color.White;
                    rb.Margin = new Padding(10);
                    rb.Padding = new Padding(5);
                    rb.Width = flowAnswers.Width - 40;

                    if (_userAnswers.ContainsKey(q.Id) && _userAnswers[q.Id] == ansId)
                    {
                        rb.Checked = true;
                    }

                    rb.CheckedChanged += (s, e) =>
                    {
                        if (rb.Checked)
                        {
                            _userAnswers[q.Id] = (int)rb.Tag;
                        }
                    };

                    flowAnswers.Controls.Add(rb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження відповідей: " + ex.Message);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                LoadCurrentQuestion();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var currentQId = _questions[_currentIndex].Id;
            if (!_userAnswers.ContainsKey(currentQId))
            {
                MessageBox.Show("Будь ласка, оберіть варіант відповіді!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentIndex < _questions.Count - 1)
            {
                _currentIndex++;
                LoadCurrentQuestion();
            }
            else
            {
                FinishTest();
            }
        }

        private void FinishTest()
        {
            if (MessageBox.Show("Ви впевнені, що хочете завершити тест?", "Завершення",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int correctCount = 0;

            try
            {
                using var conn = DatabaseHelper.GetConnection();

                foreach (var q in _questions)
                {
                    if (!_userAnswers.ContainsKey(q.Id)) continue;

                    int studentAnsId = _userAnswers[q.Id];

                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT is_correct FROM Answers WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", studentAnsId);

                    var result = cmd.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) == 1)
                    {
                        correctCount++;
                    }
                }

                using var cmdInsert = conn.CreateCommand();
                cmdInsert.CommandText = @"
                    INSERT INTO Results (student_id, test_id, score, max_score, date)
                    VALUES (@sid, @tid, @score, @max, @date)
                ";
                cmdInsert.Parameters.AddWithValue("@sid", _studentId);
                cmdInsert.Parameters.AddWithValue("@tid", _testId);
                cmdInsert.Parameters.AddWithValue("@score", correctCount);
                cmdInsert.Parameters.AddWithValue("@max", _questions.Count);
                cmdInsert.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                cmdInsert.ExecuteNonQuery();

                var resultForm = new TestResultForm(correctCount, _questions.Count);

                _isNavigateBack = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при збереженні результату: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Якщо ви вийдете зараз, прогрес буде втрачено. Вийти?", "Попередження",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _isNavigateBack = true;
                this.Close();
            }
        }

        private void TestTakingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isNavigateBack)
            {
                if (_parentForm != null && !_parentForm.IsDisposed)
                {
                    if (_parentForm is StudentTestsForm stf)
                    {
                        //stf.RefreshTables(); // Треба буде створити такий метод
                    }
                    _parentForm.Show();
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}