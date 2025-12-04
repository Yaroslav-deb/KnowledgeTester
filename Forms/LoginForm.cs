using Microsoft.Data.Sqlite;
using KnowledgeTester1.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var code = txtCode.Text.Trim();

            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Будь-ласка, заповніть поле коду доступа.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();

                using (var cmdAdmin = conn.CreateCommand())
                {
                    cmdAdmin.CommandText = "SELECT id, full_name FROM Admins WHERE personal_code = @pc";
                    cmdAdmin.Parameters.AddWithValue("@pc", code);

                    using var reader = cmdAdmin.ExecuteReader();
                    if (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var fullName = reader.GetString(1);

                        MessageBox.Show($"Ласкаво просимо, {fullName}! (Admin)", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Форма Адміна
                        this.Hide();
                        // var f = new AdminForm(id);
                        // f.FormClosed += (s, ev) => this.Show();
                        // f.Show();
                        return;
                    }
                }

                using (var cmdTeacher = conn.CreateCommand())
                {
                    cmdTeacher.CommandText = "SELECT id, full_name FROM Teachers WHERE personal_code = @pc";
                    cmdTeacher.Parameters.AddWithValue("@pc", code);

                    using var reader = cmdTeacher.ExecuteReader();
                    if (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var fullName = reader.GetString(1);

                        var f = new TeacherForm(id, fullName);

                        this.Hide();

                        f.FormClosed += (s, args) =>
                        {
                            this.Show();
                            this.txtCode.Clear();
                            this.txtCode.Focus();
                        };

                        f.Show();
                        return;
                    }
                }

                using (var cmdStudent = conn.CreateCommand())
                {
                    cmdStudent.CommandText = "SELECT id, full_name, class_id FROM Students WHERE personal_code = @pc";
                    cmdStudent.Parameters.AddWithValue("@pc", code);

                    using var reader = cmdStudent.ExecuteReader();
                    if (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var fullName = reader.GetString(1);
                        var classId = reader.GetInt32(2);

                        var f = new StudentForm(id, fullName, classId);

                        this.Hide();

                        f.FormClosed += (s, ev) =>
                        {
                            this.Show();
                            this.txtCode.Clear();
                            this.txtCode.Focus();
                        };

                        f.Show();
                        return;
                    }
                }

                    MessageBox.Show("Користувач з таким кодом не знайден.", "Помилка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при вході: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
