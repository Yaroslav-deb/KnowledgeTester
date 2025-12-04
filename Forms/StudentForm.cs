using KnowledgeTester1.Database;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq; // Додали для зручної роботи зі списками
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    public partial class StudentForm : Form
    {
        private readonly int _studentId;
        private readonly int _classId;
        private readonly string _studentName;

        private bool _isLogout = false;

        public StudentForm(int studentId, string studentName, int classId)
        {
            InitializeComponent();
            _studentId = studentId;
            _studentName = studentName;
            _classId = classId;

            lblUserInfo.Text = $"Студент: {studentName}";

            this.FormClosed += StudentForm_FormClosed;

            LoadSubjects();
        }

        // Допоміжний клас для групування
        private class SubjectGroup
        {
            public int SubjectId { get; set; }
            public string SubjectName { get; set; }
            // Список вчителів (ID та Ім'я) для цього предмета
            public List<(int Id, string Name)> Teachers { get; set; } = new List<(int, string)>();
        }

        private void LoadSubjects()
        {
            flowLayoutPanel.Controls.Clear();

            // Словник для зберігання унікальних предметів
            // Key: SubjectID, Value: Інформація про предмет і список вчителів
            var subjectsMap = new Dictionary<int, SubjectGroup>();

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT 
                        s.id AS SubjectId, 
                        s.name AS SubjectName, 
                        t.id AS TeacherId, 
                        t.full_name AS TeacherName
                    FROM TeacherClasses tc
                    JOIN Teachers t ON tc.teacher_id = t.id
                    JOIN TeacherSubjects ts ON t.id = ts.teacher_id
                    JOIN Subjects s ON ts.subject_id = s.id
                    WHERE tc.class_id = @classId
                    ORDER BY s.name
                ";
                cmd.Parameters.AddWithValue("@classId", _classId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int subjId = reader.GetInt32(0);
                    string subjName = reader.GetString(1);
                    int teachId = reader.GetInt32(2);
                    string teachName = reader.GetString(3);

                    // Якщо такого предмета ще немає в списку - додаємо
                    if (!subjectsMap.ContainsKey(subjId))
                    {
                        subjectsMap[subjId] = new SubjectGroup
                        {
                            SubjectId = subjId,
                            SubjectName = subjName
                        };
                    }

                    // Додаємо вчителя до цього предмета (якщо його там ще немає)
                    var group = subjectsMap[subjId];
                    if (!group.Teachers.Any(t => t.Id == teachId))
                    {
                        group.Teachers.Add((teachId, teachName));
                    }
                }

                // Тепер проходимо по згрупованим предметам і створюємо кнопки
                foreach (var group in subjectsMap.Values)
                {
                    CreateSubjectTile(group);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження предметів: " + ex.Message);
            }
        }

        private void CreateSubjectTile(SubjectGroup group)
        {
            Button btn = new Button();
            btn.Size = new Size(220, 150);
            btn.BackColor = Color.FromArgb(72, 61, 139);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Margin = new Padding(15);

            // Формуємо список імен вчителів через кому або з нового рядка
            // Наприклад: "Іваненко І.І., Петров П.П."
            string teachersText = string.Join(",\n", group.Teachers.Select(t => t.Name));

            btn.Text = $"{group.SubjectName}\n\n----------\n{teachersText}";
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.TextAlign = ContentAlignment.MiddleCenter;

            // Зберігаємо дані в Tag (нам знадобиться SubjectId та список TeacherIds)
            btn.Tag = group;

            btn.Click += SubjectTile_Click;

            flowLayoutPanel.Controls.Add(btn);
        }

        private void SubjectTile_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn?.Tag is SubjectGroup group)
            {
                // 1. Ховаємо StudentForm
                this.Hide();

                // 2. Створюємо StudentTestsForm
                var f = new StudentTestsForm(_studentId, _studentName, _classId, group.SubjectId, group.SubjectName, this);

                // 3. Обробляємо закриття дочірньої форми
                f.FormClosed += (s, args) =>
                {
                    // Перевіряємо, чи натиснув студент "Вийти" в тій формі
                    if (f.IsLogoutRequested)
                    {
                        // Якщо там натиснули "Вийти", ми теж натискаємо "Вийти" тут
                        this.btnExit_Click(null, null);
                    }
                    else
                    {
                        // Якщо просто натиснули "Назад", ми показуємося знову
                        this.Show();
                    }
                };

                f.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _isLogout = true;
            this.Close();
        }

        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_isLogout)
            {
                Application.Exit();
            }
        }
    }
}