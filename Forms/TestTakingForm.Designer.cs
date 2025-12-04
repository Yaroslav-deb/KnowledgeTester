using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    partial class TestTakingForm
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
            lblStudentInfo = new Label();
            lblTestTitle = new Label();
            lblQuestionCounter = new Label();
            txtQuestionText = new TextBox();
            flowAnswers = new FlowLayoutPanel();
            btnNext = new Button();
            btnPrev = new Button();
            btnBack = new Button();
            progressBar = new ProgressBar();

            SuspendLayout();

            // 
            // lblStudentInfo (Верхній лівий кут)
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Font = new Font("Segoe UI", 10F);
            lblStudentInfo.ForeColor = Color.Plum;
            lblStudentInfo.Location = new Point(20, 20);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(100, 23);
            lblStudentInfo.TabIndex = 0;
            lblStudentInfo.Text = "Студент: ...";

            // 
            // btnBack (Верхній правий кут - переривання тесту)
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.BackColor = Color.Gray;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(860, 20);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 35);
            btnBack.TabIndex = 1;
            btnBack.Text = "Вийти"; // Або "Перервати"
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;

            // 
            // lblTestTitle (Центр зверху)
            // 
            lblTestTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTestTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTestTitle.ForeColor = Color.WhiteSmoke;
            lblTestTitle.Location = new Point(200, 20);
            lblTestTitle.Name = "lblTestTitle";
            lblTestTitle.Size = new Size(600, 40);
            lblTestTitle.TabIndex = 2;
            lblTestTitle.Text = "Назва тесту";
            lblTestTitle.TextAlign = ContentAlignment.TopCenter;

            // 
            // progressBar (Прогрес проходження)
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(20, 70);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(940, 10);
            progressBar.TabIndex = 3;

            // 
            // lblQuestionCounter (Номер питання)
            // 
            lblQuestionCounter.AutoSize = true;
            lblQuestionCounter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQuestionCounter.ForeColor = Color.Gainsboro;
            lblQuestionCounter.Location = new Point(20, 100);
            lblQuestionCounter.Name = "lblQuestionCounter";
            lblQuestionCounter.Size = new Size(138, 28);
            lblQuestionCounter.TabIndex = 4;
            lblQuestionCounter.Text = "Питання 1/5";

            // 
            // txtQuestionText (Текст самого питання)
            // 
            txtQuestionText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtQuestionText.BackColor = Color.FromArgb(20, 20, 20); // Зливається з фоном
            txtQuestionText.BorderStyle = BorderStyle.None;
            txtQuestionText.Font = new Font("Segoe UI", 14F);
            txtQuestionText.ForeColor = Color.White;
            txtQuestionText.Location = new Point(20, 140);
            txtQuestionText.Multiline = true;
            txtQuestionText.Name = "txtQuestionText";
            txtQuestionText.ReadOnly = true;
            txtQuestionText.Size = new Size(940, 100); // Висота для тексту
            txtQuestionText.TabIndex = 5;
            txtQuestionText.Text = "Текст питання...";

            // 
            // flowAnswers (Контейнер для варіантів)
            // 
            flowAnswers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowAnswers.AutoScroll = true;
            flowAnswers.FlowDirection = FlowDirection.TopDown; // Відповіді одна під одною
            flowAnswers.WrapContents = false;
            flowAnswers.Location = new Point(20, 250);
            flowAnswers.Name = "flowAnswers";
            flowAnswers.Size = new Size(940, 250);
            flowAnswers.TabIndex = 6;

            // 
            // btnPrev (Кнопка Назад - по питаннях)
            // 
            btnPrev.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPrev.BackColor = Color.FromArgb(72, 61, 139);
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.FlatAppearance.BorderSize = 0;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrev.ForeColor = Color.White;
            btnPrev.Location = new Point(20, 520);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(150, 45);
            btnPrev.TabIndex = 7;
            btnPrev.Text = "<< Назад";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;

            // 
            // btnNext (Кнопка Далі / Завершити)
            // 
            btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNext.BackColor = Color.LimeGreen; // Зелений для дії вперед
            btnNext.Cursor = Cursors.Hand;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(790, 520);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(170, 45);
            btnNext.TabIndex = 8;
            btnNext.Text = "Далі >>";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;

            // 
            // TestTakingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1000, 600);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(flowAnswers);
            Controls.Add(txtQuestionText);
            Controls.Add(lblQuestionCounter);
            Controls.Add(progressBar);
            Controls.Add(lblTestTitle);
            Controls.Add(btnBack);
            Controls.Add(lblStudentInfo);
            Name = "TestTakingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Проходження тесту";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudentInfo;
        private Label lblTestTitle;
        private Label lblQuestionCounter;
        private TextBox txtQuestionText;
        private FlowLayoutPanel flowAnswers;
        private Button btnNext;
        private Button btnPrev;
        private Button btnBack;
        private ProgressBar progressBar;
    }
}