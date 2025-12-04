using System.Drawing;
using System.Windows.Forms;
using Font = System.Drawing.Font; // Вирішує конфлікт Font

namespace KnowledgeTester1.Forms
{
    partial class TestResultForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblScore = new Label();
            lblPercent = new Label();
            lblMessage = new Label();
            btnFinish = new Button();
            panelBarBackground = new Panel();
            panelBarFill = new Panel();
            lblDetail = new Label();

            panelBarBackground.SuspendLayout();
            SuspendLayout();

            // 
            // lblTitle (Заголовок)
            // 
            // ЗБІЛЬШИЛИ ВИСОТУ до 100, щоб вмістити назву і дату
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold); // Трохи зменшив шрифт, щоб влізло
            lblTitle.ForeColor = Color.WhiteSmoke;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(500, 100);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Результат тестування";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblScore (Велика оцінка)
            // 
            // ПОСУНУЛИ ВНИЗ (Y=100)
            lblScore.AutoSize = false;
            lblScore.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            lblScore.ForeColor = Color.LimeGreen;
            lblScore.Location = new Point(0, 100);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(500, 90);
            lblScore.TabIndex = 1;
            lblScore.Text = "5";
            lblScore.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblPercent (Відсотки)
            // 
            // ПОСУНУЛИ ВНИЗ (Y=190)
            lblPercent.Font = new Font("Segoe UI", 14F);
            lblPercent.ForeColor = Color.Gainsboro;
            lblPercent.Location = new Point(0, 190);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(500, 30);
            lblPercent.TabIndex = 2;
            lblPercent.Text = "90%";
            lblPercent.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // panelBarBackground
            // 
            // ПОСУНУЛИ ВНИЗ (Y=240)
            panelBarBackground.BackColor = Color.FromArgb(60, 60, 60);
            panelBarBackground.Controls.Add(panelBarFill);
            panelBarBackground.Location = new Point(50, 240);
            panelBarBackground.Name = "panelBarBackground";
            panelBarBackground.Size = new Size(400, 20);
            panelBarBackground.TabIndex = 3;

            // 
            // panelBarFill
            // 
            panelBarFill.BackColor = Color.LimeGreen;
            panelBarFill.Dock = DockStyle.Left;
            panelBarFill.Location = new Point(0, 0);
            panelBarFill.Name = "panelBarFill";
            panelBarFill.Size = new Size(300, 20);
            panelBarFill.TabIndex = 0;

            // 
            // lblDetail
            // 
            // ПОСУНУЛИ ВНИЗ (Y=280)
            lblDetail.Font = new Font("Segoe UI", 11F);
            lblDetail.ForeColor = Color.Silver;
            lblDetail.Location = new Point(20, 280);
            lblDetail.Name = "lblDetail";
            lblDetail.Size = new Size(460, 30);
            lblDetail.TabIndex = 4;
            lblDetail.Text = "Правильних відповідей: 9 з 10";
            lblDetail.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblMessage
            // 
            // ПОСУНУЛИ ВНИЗ (Y=320)
            lblMessage.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblMessage.ForeColor = Color.Plum;
            lblMessage.Location = new Point(20, 320);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(460, 30);
            lblMessage.TabIndex = 5;
            lblMessage.Text = "Чудова робота!";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // btnFinish
            // 
            // ПОСУНУЛИ ВНИЗ (Y=370)
            btnFinish.BackColor = Color.FromArgb(72, 61, 139);
            btnFinish.Cursor = Cursors.Hand;
            btnFinish.FlatAppearance.BorderSize = 0;
            btnFinish.FlatStyle = FlatStyle.Flat;
            btnFinish.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnFinish.ForeColor = Color.White;
            btnFinish.Location = new Point(150, 370);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(200, 45);
            btnFinish.TabIndex = 6;
            btnFinish.Text = "До списку тестів";
            btnFinish.UseVisualStyleBackColor = false;
            btnFinish.Click += btnFinish_Click;

            // 
            // TestResultForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(500, 450); // Збільшили висоту форми
            Controls.Add(btnFinish);
            Controls.Add(lblMessage);
            Controls.Add(lblDetail);
            Controls.Add(panelBarBackground);
            Controls.Add(lblPercent);
            Controls.Add(lblScore);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TestResultForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Результат";
            panelBarBackground.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblScore;
        private Label lblPercent;
        private Label lblMessage;
        private Label lblDetail;
        private Button btnFinish;
        private Panel panelBarBackground;
        private Panel panelBarFill;
    }
}