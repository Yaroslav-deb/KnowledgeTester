using KnowledgeTester1.Database;
using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    public partial class StudentTestsForm : Form
    {
        private readonly int _studentId;
        private readonly int _classId;
        private readonly int _subjectId;
        private readonly Form _parentForm;

        private bool _isNavigateBack = false;
        public bool IsLogoutRequested { get; private set; } = false;

        public StudentTestsForm(int studentId, string studentName, int classId, int subjectId, string subjectName, Form parentForm)
        {
            InitializeComponent();
            _studentId = studentId;
            _classId = classId;
            _subjectId = subjectId;
            _parentForm = parentForm;

            lblUserInfo.Text = $"Студент: {studentName}";
            lblSubjectInfo.Text = $"Предмет: {subjectName}";

            LoadAvailableTests();
            LoadHistory();

            this.FormClosed += StudentTestsForm_FormClosed;
        }

        private void LoadAvailableTests()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT 
                        t.id, 
                        t.title AS 'Назва тесту', 
                        t.description AS 'Опис',
                        teacher.full_name AS 'Викладач'
                    FROM Tests t
                    JOIN Teachers teacher ON t.teacher_id = teacher.id
                    JOIN TeacherSubjects ts ON teacher.id = ts.teacher_id
                    WHERE t.class_id = @classId 
                      AND ts.subject_id = @subjectId
                      AND t.id NOT IN (SELECT test_id FROM Results WHERE student_id = @studentId)
                ";
                cmd.Parameters.AddWithValue("@classId", _classId);
                cmd.Parameters.AddWithValue("@subjectId", _subjectId);
                cmd.Parameters.AddWithValue("@studentId", _studentId);

                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());

                dgvAvailable.DataSource = null;
                dgvAvailable.Columns.Clear();
                dgvAvailable.AutoGenerateColumns = true;
                dgvAvailable.DataSource = table;

                if (dgvAvailable.Columns.Contains("id")) dgvAvailable.Columns["id"].Visible = false;
                dgvAvailable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження тестів: " + ex.Message);
            }
        }

        private void LoadHistory()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT 
                        t.title AS 'Назва тесту',
                        r.date AS 'Дата здачі',
                        r.score || '/' || r.max_score AS 'Результат',
                        r.score AS 'RawScore',
                        r.max_score AS 'RawMax'
                    FROM Results r
                    JOIN Tests t ON r.test_id = t.id
                    WHERE r.student_id = @studentId
                      AND t.id IN (
                          SELECT t2.id FROM Tests t2
                          JOIN TeacherSubjects ts ON t2.teacher_id = ts.teacher_id
                          WHERE ts.subject_id = @subjectId
                      )
                    ORDER BY r.date DESC
                ";
                cmd.Parameters.AddWithValue("@studentId", _studentId);
                cmd.Parameters.AddWithValue("@subjectId", _subjectId);

                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());

                dgvHistory.DataSource = null;
                dgvHistory.Columns.Clear();
                dgvHistory.AutoGenerateColumns = true;
                dgvHistory.DataSource = table;

                dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvHistory.Columns.Contains("RawScore")) dgvHistory.Columns["RawScore"].Visible = false;
                if (dgvHistory.Columns.Contains("RawMax")) dgvHistory.Columns["RawMax"].Visible = false;

                if (dgvHistory.Columns.Contains("Результат"))
                    dgvHistory.Columns["Результат"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка історії: " + ex.Message);
            }
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (dgvAvailable.CurrentRow == null)
            {
                MessageBox.Show("Оберіть тест для проходження!");
                return;
            }

            int testId = Convert.ToInt32(dgvAvailable.CurrentRow.Cells["id"].Value);
            string testTitle = dgvAvailable.CurrentRow.Cells["Назва тесту"].Value.ToString();
            string studentName = lblUserInfo.Text.Replace("Студент: ", "");

            this.Hide();
            var f = new TestTakingForm(_studentId, testId, testTitle, studentName, this);
            f.FormClosed += (s, args) => RefreshData();
            f.Show();
        }

        private void btnViewStats_Click(object sender, EventArgs e)
        {
            if (dgvHistory.CurrentRow == null)
            {
                MessageBox.Show("Оберіть тест зі списку історії!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string title = dgvHistory.CurrentRow.Cells["Назва тесту"].Value.ToString();
                string date = dgvHistory.CurrentRow.Cells["Дата здачі"].Value.ToString();

                int score = Convert.ToInt32(dgvHistory.CurrentRow.Cells["RawScore"].Value);
                int max = Convert.ToInt32(dgvHistory.CurrentRow.Cells["RawMax"].Value);

                var statsForm = new TestResultForm(score, max, title, date);
                statsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалося відкрити статистику: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _isNavigateBack = true;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            IsLogoutRequested = true;
            _isNavigateBack = true;
            this.Close();
        }

        private void StudentTestsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isNavigateBack)
            {
                // Повернення до батька
            }
            else
            {
                Application.Exit();
            }
        }

        public void RefreshData()
        {
            LoadAvailableTests();
            LoadHistory();
        }
    }
}