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

        private static readonly string DbFolder = Path.Combine(ProjectDir, "Database");
        private static readonly string DbPath = Path.Combine(DbFolder, "school.db");

        // 1. ДОДАЛИ Timeout=30 (чекати до 30 секунд, якщо база зайнята, замість миттєвого вильоту)
        public static string ConnectionString => $"Data Source={DbPath};Default Timeout=30;";

        public static void InitializeDatabase()
        {
            try
            {
                if (!Directory.Exists(DbFolder))
                    Directory.CreateDirectory(DbFolder);

                // Перевіряємо, чи існує файл
                bool needInit = !File.Exists(DbPath);

                // Якщо файлу немає, створюємо його порожнім
                if (needInit)
                {
                    using (var connection = new SqliteConnection(ConnectionString))
                    {
                        connection.Open();
                    }
                }

                using (var conn = new SqliteConnection(ConnectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        // 2. ВМИКАЄМО РЕЖИМ WAL (Дозволяє паралельний доступ без блокувань)
                        cmd.CommandText = @"
                            PRAGMA journal_mode = WAL;
                            PRAGMA foreign_keys = ON;
                        ";
                        cmd.ExecuteNonQuery();
                    }

                    if (needInit)
                    {
                        using var cmd = conn.CreateCommand();
                        cmd.CommandText = GetInitSql();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка ініціалізації БД: " + ex.Message);
                // Тут можна не робити throw, щоб дати програмі шанс запуститися, 
                // але краще знати про проблему.
                throw;
            }
        }

        public static SqliteConnection GetConnection()
        {
            var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            // Для кожного нового з'єднання переконуємося, що FK увімкнені
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "PRAGMA foreign_keys = ON;";
                cmd.ExecuteNonQuery();
            }

            return conn;
        }

        private static string GetInitSql()
        {
            return @"
PRAGMA foreign_keys = ON;

-- Админ
CREATE TABLE IF NOT EXISTS Admins (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    full_name TEXT NOT NULL,
    personal_code TEXT UNIQUE NOT NULL
);

-- Классы
CREATE TABLE IF NOT EXISTS Classes (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL UNIQUE
);

-- Учителя
CREATE TABLE IF NOT EXISTS Teachers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    full_name TEXT NOT NULL,
    personal_code TEXT UNIQUE NOT NULL
);

-- Предметы
CREATE TABLE IF NOT EXISTS Subjects (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL UNIQUE
);

-- Соответствие учителя к классам
CREATE TABLE IF NOT EXISTS TeacherClasses (
    teacher_id INTEGER NOT NULL,
    class_id INTEGER NOT NULL,
    FOREIGN KEY(teacher_id) REFERENCES Teachers(id) ON DELETE CASCADE,
    FOREIGN KEY(class_id) REFERENCES Classes(id) ON DELETE CASCADE,
    PRIMARY KEY(teacher_id, class_id)
);

-- Соответствие учителя к предметам
CREATE TABLE IF NOT EXISTS TeacherSubjects (
    teacher_id INTEGER NOT NULL,
    subject_id INTEGER NOT NULL,
    FOREIGN KEY(teacher_id) REFERENCES Teachers(id) ON DELETE CASCADE,
    FOREIGN KEY(subject_id) REFERENCES Subjects(id) ON DELETE CASCADE,
    PRIMARY KEY(teacher_id, subject_id)
);

-- Студенты
CREATE TABLE IF NOT EXISTS Students (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    full_name TEXT NOT NULL,
    personal_code TEXT UNIQUE NOT NULL,
    class_id INTEGER NOT NULL,
    FOREIGN KEY(class_id) REFERENCES Classes(id) ON DELETE CASCADE
);

-- Тесты
CREATE TABLE IF NOT EXISTS Tests (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    title TEXT NOT NULL,
    description TEXT,
    class_id INTEGER,
    teacher_id INTEGER,
    FOREIGN KEY(class_id) REFERENCES Classes(id),
    FOREIGN KEY(teacher_id) REFERENCES Teachers(id)
);

-- Вопросы
CREATE TABLE IF NOT EXISTS Questions (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    test_id INTEGER,
    question_text TEXT NOT NULL,
    FOREIGN KEY(test_id) REFERENCES Tests(id) ON DELETE CASCADE
);

-- Ответы
CREATE TABLE IF NOT EXISTS Answers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    question_id INTEGER,
    answer_text TEXT NOT NULL,
    is_correct INTEGER NOT NULL CHECK(is_correct IN (0,1)),
    FOREIGN KEY(question_id) REFERENCES Questions(id) ON DELETE CASCADE
);

-- Результаты
CREATE TABLE IF NOT EXISTS Results (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    student_id INTEGER NOT NULL,
    test_id INTEGER NOT NULL,
    score INTEGER NOT NULL,
    max_score INTEGER NOT NULL,
    date TEXT NOT NULL,
    FOREIGN KEY(student_id) REFERENCES Students(id),
    FOREIGN KEY(test_id) REFERENCES Tests(id)
);

-- 
INSERT INTO Admins (full_name, personal_code) VALUES
('Головний Адміністратор','admin123');

INSERT INTO Classes (name) VALUES
('6-А'),('7-А'),('8-А'),('9-А'),('10-А'),('11-А');

-- Предмети
INSERT INTO Subjects (name) VALUES
('Математика'),('Фізика'),('Хімія'),('Історія'),('Географія'),('Література');

-- Вчителі
INSERT INTO Teachers (full_name, personal_code) VALUES
('Ковальчук Ірина Василівна', 'T1'),      -- Математика
('Шевченко Петро Олексійович', 'T2'),     -- Фізика
('Мельник Оксана Іванівна', 'T3'),        -- Хімія
('Бондаренко Андрій Сергійович', 'T4'),   -- Історія
('Ткаченко Наталія Володимирівна', 'T5'), -- Географія
('Кравченко Віктор Миколайович', 'T6'),   -- Література/Математика
('Олійник Марія Юріївна', 'T7'),          -- Фізика/Хімія
('Поліщук Сергій Дмитрович', 'T8'),       -- Історія/Математика
('Лисенко Ганна Павлівна', 'T9'),         -- Географія/Хімія
('Бойко Володимир Тарасович', 'T10');     -- Історія/Географія/Література

-- TeacherClasses
INSERT INTO TeacherClasses (teacher_id, class_id) VALUES
(1,1),(1,2),(1,3),(1,4),
(2,1),(2,2),(2,3),(2,4),
(3,1),(3,2),(3,3),(3,4),
(4,1),(4,2),(4,3),(4,4),
(5,1),(5,2),(5,3),(5,4),
(6,5),(6,6),
(7,5),(7,6),
(8,5),(8,6),
(9,5),(9,6),
(10,5),(10,6);

-- TeacherSubjects
INSERT INTO TeacherSubjects (teacher_id, subject_id) VALUES
(1,1),(2,2),(3,3),(4,4),(4,5),(5,5),(5,6),
(6,1),(6,2),(7,2),(7,3),(8,4),(8,1),(9,5),(9,3),(10,4),(10,5),(10,6);

-- Students 6-А
INSERT INTO Students (full_name, personal_code, class_id) VALUES
('Іваненко Максим Сергійович','S6A1',1),
('Петренко Софія Андріївна','S6A2',1),
('Сидоренко Дмитро Олександрович','S6A3',1),
('Коваленко Анастасія Іванівна','S6A4',1),
('Григоренко Артем Павлович','S6A5',1);

-- Students 7-А
INSERT INTO Students (full_name, personal_code, class_id) VALUES
('Данилюк Вероніка Олексіївна','S7A1',2),
('Гаврилюк Богдан Миколайович','S7A2',2),
('Тимошенко Юлія Володимирівна','S7A3',2),
('Романенко Денис Юрійович','S7A4',2),
('Василенко Вікторія Олегівна','S7A5',2);

-- Students 8-А
INSERT INTO Students (full_name, personal_code, class_id) VALUES
('Павленко Олександр Ігорович','S8A1',3),
('Левченко Дар''я Максимівна','S8A2',3),
('Кузьменко Владислав Тарасович','S8A3',3),
('Білоус Катерина Сергіївна','S8A4',3),
('Мороз Назар Андрійович','S8A5',3);

-- Students 9-А
INSERT INTO Students (full_name, personal_code, class_id) VALUES
('Руденко Євгеній Вікторович','S9A1',4),
('Кравчук Аліна Дмитрівна','S9A2',4),
('Захарченко Ігор Романович','S9A3',4),
('Карпенко Маргарита Олександрівна','S9A4',4),
('Демченко Станіслав Вадимович','S9A5',4);

-- Students 10-А
INSERT INTO Students (full_name, personal_code, class_id) VALUES
('Савченко Олег Петрович','S10A1',5),
('Гончар Ольга Миколаївна','S10A2',5),
('Мазур Антон Васильович','S10A3',5),
('Степаненко Єлизавета Юріївна','S10A4',5),
('Вовк Роман Григорович','S10A5',5);

-- Students 11-А
INSERT INTO Students (full_name, personal_code, class_id) VALUES
('Козак Ярослав Володимирович','S11A1',6),
('Нестеренко Марина Анатоліївна','S11A2',6),
('Попович Андрій Олександрович','S11A3',6),
('Марченко Діана Віталіївна','S11A4',6),
('Шульга Валентин Сергійович','S11A5',6);
";
        }
    }
}