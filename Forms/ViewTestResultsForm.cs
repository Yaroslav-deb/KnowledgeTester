using KnowledgeTester1.Database;
using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    public partial class ViewTestResultsForm : Form
    {
        private readonly int _testId;
        private readonly Form _parentForm;

        public ViewTestResultsForm(int testId, string testTitle, Form parentForm)
        {
            InitializeComponent();
            _testId = testId;
            _parentForm = parentForm;

            lblTestTitle.Text = $"Результати тесту: {testTitle}";
            LoadResults();

            this.FormClosed += ViewTestResultsForm_FormClosed;
        }

        private void LoadResults()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT 
                        s.full_name AS 'ПІБ Студента',
                        r.date AS 'Дата здачі',
                        r.score AS 'Набрано балів',
                        r.max_score AS 'Макс. балів'
                    FROM Results r
                    JOIN Students s ON r.student_id = s.id
                    WHERE r.test_id = @tid
                    ORDER BY r.date DESC
                ";
                cmd.Parameters.AddWithValue("@tid", _testId);

                using var reader = cmd.ExecuteReader();
                DataTable table = new DataTable();

                table.Columns.Add("ПІБ Студента", typeof(string));
                table.Columns.Add("Дата здачі", typeof(string));
                table.Columns.Add("Результат", typeof(string));
                table.Columns.Add("Відсоток", typeof(double));
                table.Columns.Add("Оцінка", typeof(int));

                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string date = reader.GetString(1);
                    int score = reader.GetInt32(2);
                    int maxScore = reader.GetInt32(3);

                    double percent = maxScore > 0 ? ((double)score / maxScore) * 100 : 0;
                    int grade = CalculateGrade(percent);

                    table.Rows.Add(
                        name,
                        date,
                        $"{score} з {maxScore}",
                        Math.Round(percent, 1),
                        grade
                    );
                }

                dgvResults.DataSource = table;

                dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvResults.Columns["Результат"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvResults.Columns["Відсоток"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvResults.Columns["Оцінка"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvResults.Columns["Відсоток"].DefaultCellStyle.Format = "0.0'%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження результатів: " + ex.Message);
            }
        }

        private int CalculateGrade(double percent)
        {
            if (percent >= 90) return 5;
            if (percent >= 75) return 4;
            if (percent >= 50) return 3;
            if (percent >= 25) return 2;
            return 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewTestResultsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_parentForm != null && !_parentForm.IsDisposed)
            {
                _parentForm.Show();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}