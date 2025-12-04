using KnowledgeTester1.Database;
using Microsoft.Data.Sqlite;
using System.Data;

namespace KnowledgeTester1.Forms
{
    public partial class TeacherForm : Form
    {
        private readonly int _teacherId;

        private bool _isLogout = false;

        public TeacherForm(int teacherId, string teacherName)
        {
            InitializeComponent();

            _teacherId = teacherId;
            lblUserInfo.Text = $"Вчитель: {teacherName}";

            this.FormClosed += TeacherForm_FormClosed;

            LoadTests();
        }

        private void TeacherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isLogout)
            {
                // 
            }
            else
            {
                Application.Exit();
            }
        }

        
        private void btnExit_Click(object sender, EventArgs e)
        {
            _isLogout = true;
            this.Close();
        }


        public void LoadTests()
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
                        c.name AS 'Клас'
                    FROM Tests t
                    LEFT JOIN Classes c ON t.class_id = c.id
                    WHERE t.teacher_id = @tid
                ";
                cmd.Parameters.AddWithValue("@tid", _teacherId);

                using var reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);

                dgvTests.Columns.Clear();
                dgvTests.AutoGenerateColumns = true;
                dgvTests.DataSource = table;

                dgvTests.RowHeadersVisible = false;
                if (dgvTests.Columns.Contains("id"))
                    dgvTests.Columns["id"].Visible = false;

                dgvTests.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvTests.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvTests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvTests.Columns.Contains("Назва тесту"))
                {
                    dgvTests.Columns["Назва тесту"].FillWeight = 25;
                    dgvTests.Columns["Назва тесту"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                }

                if (dgvTests.Columns.Contains("Опис"))
                {
                    dgvTests.Columns["Опис"].FillWeight = 65;
                    dgvTests.Columns["Опис"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvTests.Columns["Опис"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                }

                if (dgvTests.Columns.Contains("Клас"))
                {
                    dgvTests.Columns["Клас"].FillWeight = 10;
                    dgvTests.Columns["Клас"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                    dgvTests.Columns["Клас"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження тестів: " + ex.Message);
            }
        }

        private int? GetSelectedTestId()
        {
            if (dgvTests.CurrentRow == null) return null;
            return Convert.ToInt32(dgvTests.CurrentRow.Cells["id"].Value);
        }

        private void btnCreateTest_Click(object sender, EventArgs e)
        {
            this.Hide();

            var f = new CreateTestForm(_teacherId, this);

            f.Show();
        }

        private void btnEditTest_Click(object sender, EventArgs e)
        {
            int? testId = GetSelectedTestId();
            if (testId == null)
            {
                MessageBox.Show("Оберіть тест!");
                return;
            }

            this.Hide();
            var f = new EditTestForm(testId.Value, _teacherId, this);
            f.Show();
        }

        private void btnDeleteTest_Click(object sender, EventArgs e)
        {
            int? testId = GetSelectedTestId();
            if (testId == null)
            {
                MessageBox.Show("Оберіть тест!");
                return;
            }

            if (MessageBox.Show("Видалити тест? Увага: Всі результати студентів по цьому тесту також будуть видалені!",
                "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            SqliteConnection.ClearAllPools();

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var transaction = conn.BeginTransaction();

                try
                {
                    using (var cmdDelAnswers = conn.CreateCommand())
                    {
                        cmdDelAnswers.Transaction = transaction;
                        cmdDelAnswers.CommandText = @"DELETE FROM Answers WHERE question_id IN (SELECT id FROM Questions WHERE test_id = @tid)";
                        cmdDelAnswers.Parameters.AddWithValue("@tid", testId);
                        cmdDelAnswers.ExecuteNonQuery();
                    }

                    using (var cmdDelQuestions = conn.CreateCommand())
                    {
                        cmdDelQuestions.Transaction = transaction;
                        cmdDelQuestions.CommandText = "DELETE FROM Questions WHERE test_id = @tid";
                        cmdDelQuestions.Parameters.AddWithValue("@tid", testId);
                        cmdDelQuestions.ExecuteNonQuery();
                    }

                    using (var cmdDelResults = conn.CreateCommand())
                    {
                        cmdDelResults.Transaction = transaction;
                        cmdDelResults.CommandText = "DELETE FROM Results WHERE test_id = @tid";
                        cmdDelResults.Parameters.AddWithValue("@tid", testId);
                        cmdDelResults.ExecuteNonQuery();
                    }

                    using (var cmdDelTest = conn.CreateCommand())
                    {
                        cmdDelTest.Transaction = transaction;
                        cmdDelTest.CommandText = "DELETE FROM Tests WHERE id = @id";
                        cmdDelTest.Parameters.AddWithValue("@id", testId);
                        cmdDelTest.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    LoadTests();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка видалення тесту: " + ex.Message);
            }
        }

        private void btnViewCreatedTests_Click(object sender, EventArgs e)
        {
            if (dgvTests.CurrentRow == null)
            {
                MessageBox.Show("Оберіть тест зі списку!");
                return;
            }

            int testId = Convert.ToInt32(dgvTests.CurrentRow.Cells["id"].Value);

            string testTitle = dgvTests.CurrentRow.Cells["Назва тесту"].Value.ToString();

            this.Hide();

            var f = new ViewTestResultsForm(testId, testTitle, this);
            f.Show();
        }

        
    }
}