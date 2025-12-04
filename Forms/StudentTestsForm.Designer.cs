using System.Drawing;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace KnowledgeTester1.Forms
{
    partial class StudentTestsForm
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
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();

            lblUserInfo = new Label();
            lblSubjectInfo = new Label();
            btnExit = new Button();
            btnBack = new Button();
            tabControl = new TabControl();
            tabAvailable = new TabPage();
            btnStartTest = new Button();
            dgvAvailable = new DataGridView();
            tabHistory = new TabPage();
            dgvHistory = new DataGridView();
            btnViewStats = new Button();

            tabControl.SuspendLayout();
            tabAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvailable).BeginInit();
            tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // ЗАГАЛЬНІ СТИЛІ ТАБЛИЦЬ
            // 
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(75, 0, 130);
            headerStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            headerStyle.ForeColor = Color.WhiteSmoke;
            headerStyle.SelectionBackColor = Color.FromArgb(75, 0, 130);
            headerStyle.SelectionForeColor = SystemColors.HighlightText;
            headerStyle.WrapMode = DataGridViewTriState.True;
            rowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = Color.FromArgb(50, 50, 55);
            rowStyle.Font = new Font("Segoe UI", 10F);
            rowStyle.ForeColor = Color.White;
            rowStyle.SelectionBackColor = Color.BlueViolet;
            rowStyle.SelectionForeColor = Color.White;
            rowStyle.WrapMode = DataGridViewTriState.False;
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUserInfo.ForeColor = Color.Plum;
            lblUserInfo.Location = new Point(20, 20);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(113, 28);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "Студент: ...";
            // 
            // lblSubjectInfo
            // 
            lblSubjectInfo.AutoSize = true;
            lblSubjectInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSubjectInfo.ForeColor = Color.WhiteSmoke;
            lblSubjectInfo.Location = new Point(20, 60);
            lblSubjectInfo.Name = "lblSubjectInfo";
            lblSubjectInfo.Size = new Size(153, 32);
            lblSubjectInfo.TabIndex = 4;
            lblSubjectInfo.Text = "Предмет: ...";
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.BackColor = Color.FromArgb(178, 34, 34);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(860, 20);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 35);
            btnExit.TabIndex = 1;
            btnExit.Text = "Вийти";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.BackColor = Color.Gray;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(740, 20);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 35);
            btnBack.TabIndex = 5;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabAvailable);
            tabControl.Controls.Add(tabHistory);
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.Location = new Point(20, 110);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(940, 470);
            tabControl.TabIndex = 2;
            // 
            // tabAvailable
            // 
            tabAvailable.BackColor = Color.FromArgb(30, 30, 30);
            tabAvailable.Controls.Add(btnStartTest);
            tabAvailable.Controls.Add(dgvAvailable);
            tabAvailable.ForeColor = Color.White;
            tabAvailable.Location = new Point(4, 32);
            tabAvailable.Name = "tabAvailable";
            tabAvailable.Padding = new Padding(3);
            tabAvailable.Size = new Size(932, 434);
            tabAvailable.TabIndex = 0;
            tabAvailable.Text = "Доступні тести";
            // 
            // btnStartTest
            // 
            btnStartTest.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStartTest.BackColor = Color.LimeGreen;
            btnStartTest.Cursor = Cursors.Hand;
            btnStartTest.FlatAppearance.BorderSize = 0;
            btnStartTest.FlatStyle = FlatStyle.Flat;
            btnStartTest.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnStartTest.ForeColor = Color.White;
            btnStartTest.Location = new Point(710, 380);
            btnStartTest.Name = "btnStartTest";
            btnStartTest.Size = new Size(200, 40);
            btnStartTest.TabIndex = 1;
            btnStartTest.Text = "Почати тест";
            btnStartTest.UseVisualStyleBackColor = false;
            btnStartTest.Click += btnStartTest_Click;
            // 
            // dgvAvailable
            // 
            dgvAvailable.AllowUserToAddRows = false;
            dgvAvailable.AllowUserToDeleteRows = false;
            dgvAvailable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAvailable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailable.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgvAvailable.BorderStyle = BorderStyle.None;
            dgvAvailable.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvAvailable.ColumnHeadersHeight = 29;
            dgvAvailable.DefaultCellStyle = rowStyle;
            dgvAvailable.EnableHeadersVisualStyles = false;
            dgvAvailable.GridColor = Color.FromArgb(60, 60, 60);
            dgvAvailable.Location = new Point(20, 20);
            dgvAvailable.MultiSelect = false;
            dgvAvailable.Name = "dgvAvailable";
            dgvAvailable.ReadOnly = true;
            dgvAvailable.RowHeadersVisible = false;
            dgvAvailable.RowHeadersWidth = 51;
            dgvAvailable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailable.Size = new Size(890, 340);
            dgvAvailable.TabIndex = 0;
            // 
            // tabHistory
            // 
            tabHistory.BackColor = Color.FromArgb(30, 30, 30);
            tabHistory.Controls.Add(btnViewStats);
            tabHistory.Controls.Add(dgvHistory);
            tabHistory.Location = new Point(4, 32);
            tabHistory.Name = "tabHistory";
            tabHistory.Padding = new Padding(3);
            tabHistory.Size = new Size(932, 434);
            tabHistory.TabIndex = 1;
            tabHistory.Text = "Історія здачі";
            // 
            // btnViewStats
            // 
            btnViewStats.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnViewStats.BackColor = Color.FromArgb(72, 61, 139);
            btnViewStats.Cursor = Cursors.Hand;
            btnViewStats.FlatAppearance.BorderSize = 0;
            btnViewStats.FlatStyle = FlatStyle.Flat;
            btnViewStats.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewStats.ForeColor = Color.White;
            btnViewStats.Location = new Point(710, 380);
            btnViewStats.Name = "btnViewStats";
            btnViewStats.Size = new Size(200, 40);
            btnViewStats.TabIndex = 2;
            btnViewStats.Text = "Детальна статистика";
            btnViewStats.UseVisualStyleBackColor = false;
            btnViewStats.Click += btnViewStats_Click;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvHistory.ColumnHeadersHeight = 29;
            dgvHistory.DefaultCellStyle = rowStyle;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.GridColor = Color.FromArgb(60, 60, 60);
            dgvHistory.Location = new Point(20, 20);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(890, 340);
            dgvHistory.TabIndex = 0;
            // 
            // StudentTestsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1000, 600);
            Controls.Add(tabControl);
            Controls.Add(btnBack);
            Controls.Add(btnExit);
            Controls.Add(lblSubjectInfo);
            Controls.Add(lblUserInfo);
            Name = "StudentTestsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вибір тесту";
            WindowState = FormWindowState.Maximized;
            tabControl.ResumeLayout(false);
            tabAvailable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAvailable).EndInit();
            tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserInfo;
        private Label lblSubjectInfo;
        private Button btnExit;
        private Button btnBack;
        private TabControl tabControl;
        private TabPage tabAvailable;
        private TabPage tabHistory;
        private DataGridView dgvAvailable;
        private DataGridView dgvHistory;
        private Button btnStartTest;
        private Button btnViewStats;
    }
}