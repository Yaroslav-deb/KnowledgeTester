using KnowledgeTester1.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    public partial class TeacherForm : Form
    {
        private int _teacherId;

        public TeacherForm(int teacherId)
        {
            InitializeComponent();
            _teacherId = teacherId;

            LoadTests();
        }
        public TeacherForm()
        {
            InitializeComponent();
        }

        private void LoadTests()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT t.id, t.title, c.name AS class_name
                    FROM Tests t
                    LEFT JOIN Classes c ON t.class_id = c.id
                    WHERE t.teacher_id = @tid
                ";
                cmd.Parameters.AddWithValue("@tid", _teacherId);

                //using var adapter = new SqliteDataAdapter(cmd);
                DataTable table = new DataTable();
                //adapter.Fill(table);

                //dgvTests.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження тестів: " + ex.Message);
            }
        }

    }
}
