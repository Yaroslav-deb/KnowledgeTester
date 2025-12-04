using System;
using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    public partial class TestResultForm : Form
    {
        public TestResultForm(int score, int maxScore, string testTitle = "Тестування", string dateTaken = null)
        {
            InitializeComponent();

            lblTitle.Text = testTitle;

            if (dateTaken != null)
            {
                btnFinish.Text = "Закрити";
                lblTitle.Text += $"\n({dateTaken})";
            }

            CalculateAndShow(score, maxScore);
        }

        private void CalculateAndShow(int score, int maxScore)
        {
            if (maxScore == 0) maxScore = 1;

            double percent = ((double)score / maxScore) * 100;
            int grade = CalculateGrade(percent);

            lblScore.Text = grade.ToString();
            lblPercent.Text = $"{Math.Round(percent)}%";
            lblDetail.Text = $"Правильних відповідей: {score} з {maxScore}";

            Color resultColor;
            string message;

            switch (grade)
            {
                case 5:
                    resultColor = Color.LimeGreen;
                    message = "Відмінний результат!";
                    break;
                case 4:
                    resultColor = Color.YellowGreen;
                    message = "Добре! Гарна робота.";
                    break;
                case 3:
                    resultColor = Color.Orange;
                    message = "Задовільно.";
                    break;
                default:
                    resultColor = Color.IndianRed;
                    message = "Незадовільно.";
                    break;
            }

            lblScore.ForeColor = resultColor;
            panelBarFill.BackColor = resultColor;
            lblMessage.Text = message;
            lblMessage.ForeColor = resultColor;

            int fillWidth = (int)((panelBarBackground.Width * percent) / 100);
            panelBarFill.Width = fillWidth;
        }

        private int CalculateGrade(double percent)
        {
            if (percent >= 90) return 5;
            if (percent >= 75) return 4;
            if (percent >= 50) return 3;
            if (percent >= 25) return 2;
            return 1;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}