using KnowledgeTester1.Database;
using KnowledgeTester1.Forms;
using KnowledgeTester1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowledgeTester
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DatabaseHelper.InitializeDatabase();

            try
            {
                DatabaseHelper.InitializeDatabase();
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критична помилка при запуску:\n\n" + ex.ToString(),
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
