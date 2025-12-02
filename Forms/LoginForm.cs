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
            var fullName = txtFullName.Text.Trim();
            var code = txtCode.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Будь-ласка, заповніть поле з ім'ям та кодом доступа.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = new SqliteCommand("SELECT id, role, class_id, full_name FROM Users WHERE full_name = @fn AND personal_code = @pc", conn);
                cmd.Parameters.AddWithValue("@fn", fullName);
                cmd.Parameters.AddWithValue("@pc", code);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var role = reader.GetString(1);
                    var classId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2);
                    var realName = reader.GetString(3);

                    // Переключаемся по роли
                    if (role == "student")
                    {
                        MessageBox.Show($"Ласкаво просимо, {realName}! (студент)", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Здесь откроем StudentForm (пока заглушка)
                        //var f = new StudentForm(id, classId);
                        this.Hide();
                        //f.FormClosed += (s, ev) => this.Show();
                        //f.Show();
                    }
                    else if (role == "teacher")
                    {
                        MessageBox.Show($"Ласкаво просимо у систему, {realName}! (викладач)", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var f = new TeacherForm(id);
                        this.Hide();
                        f.FormClosed += (s, ev) => this.Show();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Роль поки у розроботці(admin).", "Информація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Користувач з таким ПІБ та кодом не знайден.", "Помилка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при вході: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
