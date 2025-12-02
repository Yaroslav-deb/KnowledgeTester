using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Windows.Forms;

namespace KnowledgeTester1.Database
{
    public static class DatabaseHelper
    {
        private static readonly string ProjectDir = 
            Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

        // Папка Database в корне проекта
        private static readonly string DbFolder =
            Path.Combine(ProjectDir, "Database");

        // Путь к базе данных
        private static readonly string DbPath =
            Path.Combine(DbFolder, "school.db");

        public static string ConnectionString =>
            $"Data Source={DbPath}";

        public static void InitializeDatabase()
        {
            try
            {
                if (!Directory.Exists(DbFolder))
                    Directory.CreateDirectory(DbFolder);

                bool needInit = !File.Exists(DbPath);

                if (needInit)
                {
                    // создаём пустую БД
                    using (var connection = new SqliteConnection(ConnectionString))
                    {
                        connection.Open();
                    }
                }

                using (var conn = new SqliteConnection(ConnectionString))
                {
                    conn.Open();

                    if (needInit)
                    {
                        string sql = GetInitSql();
                        using var cmd = conn.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка инициализации БД: " + ex.Message);
                throw;
            }
        }

        public static SqliteConnection GetConnection()
        {
            var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        private static string GetInitSql()
        {
            // Здесь я помещаю твой SQL. Если ты захочешь — можно вынести в файл .sql.
            return @"
PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS ""Users""
(
 id integer primary key autoincrement,
 full_name text not null,
 role text not null check (role in ('student', 'admin', 'teacher')),
 personal_code text unique not null,
 class_id integer,
 foreign key(class_id) references ""Classes""(id)
);

CREATE TABLE IF NOT EXISTS ""Classes""
(
 id integer primary key autoincrement,
 name text not null unique
);

CREATE TABLE IF NOT EXISTS ""Tests""
(
 id integer primary key autoincrement,
 title text not null,
 description text,
 class_id integer,
 teacher_id integer,
 foreign key (class_id) references ""Classes""(id),
 foreign key (teacher_id) references ""Users""(id)
);

CREATE TABLE IF NOT EXISTS ""Questions""
(
 id integer primary key autoincrement,
 test_id integer,
 question_text text not null,
 foreign key (test_id) references ""Tests""(id)
);

CREATE TABLE IF NOT EXISTS ""Answers""
(
 id integer primary key autoincrement,
 question_id integer,
 answer_text text not null,
 is_correct integer not null check(is_correct in (0, 1)),
 foreign key (question_id) references ""Questions""(id)
);

CREATE TABLE IF NOT EXISTS ""Results""
(
 id integer primary key autoincrement,
 student_id integer not null,
 test_id integer not null,
 score integer not null,
 max_score integer not null,
 ""date"" text not null,
 foreign key (student_id) references ""Users""(id),
 foreign key (test_id) references ""Tests""(id)
);

-- Insert classes
INSERT OR IGNORE INTO Classes (name) VALUES
('7-А'),
('9-А'),
('10-А'),
('11-А');

-- Teachers (5 for 7/9 and 5 for 10/11)
INSERT OR IGNORE INTO ""Users""(full_name, role, personal_code, class_id) VALUES
('Іваненко Марія Петрівна', 'teacher', 'TCH-001-A1', NULL),
('Павлюк Сергій Олександрович', 'teacher', 'TCH-002-B4', NULL),
('Коваль Анна Ігорівна', 'teacher', 'TCH-003-C2', NULL),
('Бойко Олег Миколайович', 'teacher', 'TCH-004-D7', NULL),
('Шевченко Оксана Василівна', 'teacher', 'TCH-005-E9', NULL),
('Гриценко Микола Іванович', 'teacher', 'TCH-006-F3', NULL),
('Дмитрук Наталія Степанівна', 'teacher', 'TCH-007-G8', NULL),
('Лисенко Юрій Павлович', 'teacher', 'TCH-008-H5', NULL),
('Мельник Світлана Андріївна', 'teacher', 'TCH-009-J1', NULL),
('Онищук Роман Григорович', 'teacher', 'TCH-010-K4', NULL);

-- Students 7-A
INSERT OR IGNORE INTO ""Users"" (full_name, role, personal_code, class_id) VALUES
('Кравець Андрій Сергійович', 'student', 'STU7A-001', 1),
('Мельник Софія Ігорівна', 'student', 'STU7A-002', 1),
('Мазур Владислав Юрійович', 'student', 'STU7A-003', 1),
('Мироненко Дарина Олегівна', 'student', 'STU7A-004', 1),
('Гуменюк Максим Володимирович', 'student', 'STU7A-005', 1),
('Мисько Аліна Петрівна', 'student', 'STU7A-006', 1),
('Шеремета Денис Вадимович', 'student', 'STU7A-007', 1),
('Гордійчук Лілія Миколаївна', 'student', 'STU7A-008', 1),
('Котик Роман Андрійович', 'student', 'STU7A-009', 1);

-- Students 9-A
INSERT OR IGNORE INTO ""Users"" (full_name, role, personal_code, class_id) VALUES
('Білик Олександр Тарасович', 'student', 'STU9A-001', 2),
('Проценко Анастасія Миколаївна', 'student', 'STU9A-002', 2),
('Шевчук Дмитро Сергійович', 'student', 'STU9A-003', 2),
('Калініна Анна Романівна', 'student', 'STU9A-004', 2),
('Литвин Артем Олександрович', 'student', 'STU9A-005', 2),
('Семенюк Вікторія Павлівна', 'student', 'STU9A-006', 2),
('Кузьменко Назар Ігорович', 'student', 'STU9A-007', 2),
('Петренко Богдан Михайлович', 'student', 'STU9A-008', 2),
('Корнієнко Олена Василівна', 'student', 'STU9A-009', 2),
('Сергієнко Ілля Валентинович', 'student', 'STU9A-010', 2);

-- Students 10-A
INSERT OR IGNORE INTO ""Users"" (full_name, role, personal_code, class_id) VALUES
('Гаврилюк Іван Миколайович', 'student', 'STU10A-001', 3),
('Романюк Марія Олегівна', 'student', 'STU10A-002', 3),
('Шпортко Андрій Віталійович', 'student', 'STU10A-003', 3),
('Савчук Діана Степанівна', 'student', 'STU10A-004', 3),
('Захарченко Емма Сергіївна', 'student', 'STU10A-005', 3),
('Пилипчук Данило Васильович', 'student', 'STU10A-006', 3),
('Бородай Лілія Орестівна', 'student', 'STU10A-007', 3),
('Горобець Назар Петрович', 'student', 'STU10A-008', 3);

-- Students 11-A
INSERT OR IGNORE INTO ""Users"" (full_name, role, personal_code, class_id) VALUES
('Сидоренко Марк Олексійович', 'student', 'STU11A-001', 4),
('Левченко Софія Богданівна', 'student', 'STU11A-002', 4),
('Ткаченко Владислав Петрович', 'student', 'STU11A-003', 4),
('Гуменна Ольга Михайлівна', 'student', 'STU11A-004', 4),
('Дяченко Микита Сергійович', 'student', 'STU11A-005', 4),
('Сушко Анастасія Юріївна', 'student', 'STU11A-006', 4),
('Маслюк Олександра Олегівна', 'student', 'STU11A-007', 4),
('Кирилюк Максим Андрійович', 'student', 'STU11A-008', 4),
('Горчак Тетяна Степанівна', 'student', 'STU11A-009', 4),
('Капустін Павло Ілліч', 'student', 'STU11A-010', 4),
('Сич Олексій Дмитрович', 'student', 'STU11A-011', 4);
";
        }
    }
}
