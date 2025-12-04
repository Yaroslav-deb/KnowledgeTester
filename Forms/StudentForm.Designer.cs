using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    partial class StudentForm
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
            lblUserInfo = new Label();
            btnExit = new Button();
            flowLayoutPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUserInfo.ForeColor = Color.Plum;
            lblUserInfo.Location = new Point(20, 20);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(250, 32);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "Студент: ...";
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
            // flowLayoutPanel (Контейнер для плиток)
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = Color.FromArgb(30, 30, 30);
            flowLayoutPanel.Location = new Point(20, 80);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Padding = new Padding(10);
            flowLayoutPanel.Size = new Size(940, 500);
            flowLayoutPanel.TabIndex = 2;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1000, 600);
            Controls.Add(flowLayoutPanel);
            Controls.Add(btnExit);
            Controls.Add(lblUserInfo);
            Name = "StudentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Кабінет студента";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserInfo;
        private Button btnExit;
        private FlowLayoutPanel flowLayoutPanel;
    }
}