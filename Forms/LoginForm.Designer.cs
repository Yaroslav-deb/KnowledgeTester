using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 

        private void InitializeComponent()
        {
            btnLogin = new Button();
            lblTitle = new Label();
            txtFullName = new TextBox();
            txtCode = new TextBox();
            lblFullName = new Label();
            lblCode = new Label();
            lblInfrormation = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.BlueViolet;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(315, 342);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(111, 35);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Увійти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.WhiteSmoke;
            lblTitle.Location = new Point(63, 41);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(363, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Вхід у систему тестування";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.WhiteSmoke;
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(235, 169);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(191, 30);
            txtFullName.TabIndex = 2;
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.WhiteSmoke;
            txtCode.Font = new Font("Segoe UI", 10F);
            txtCode.Location = new Point(235, 235);
            txtCode.Name = "txtCode";
            txtCode.PasswordChar = '*';
            txtCode.Size = new Size(191, 30);
            txtCode.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 11F);
            lblFullName.ForeColor = Color.Gainsboro;
            lblFullName.Location = new Point(32, 170);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(42, 25);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "ПІБ";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Segoe UI", 11F);
            lblCode.ForeColor = Color.Gainsboro;
            lblCode.Location = new Point(32, 236);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(176, 25);
            lblCode.TabIndex = 5;
            lblCode.Text = "Персональний код";
            // 
            // lblInfrormation
            // 
            lblInfrormation.AutoSize = true;
            lblInfrormation.Font = new Font("Segoe UI", 9F);
            lblInfrormation.ForeColor = Color.Plum;
            lblInfrormation.Location = new Point(174, 103);
            lblInfrormation.Name = "lblInfrormation";
            lblInfrormation.Size = new Size(132, 20);
            lblInfrormation.TabIndex = 6;
            lblInfrormation.Text = "Введіть ваші дані:";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(457, 414);
            Controls.Add(lblInfrormation);
            Controls.Add(lblCode);
            Controls.Add(lblFullName);
            Controls.Add(txtCode);
            Controls.Add(txtFullName);
            Controls.Add(lblTitle);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизація";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label lblTitle;
        private TextBox txtFullName;
        private TextBox txtCode;
        private Label lblFullName;
        private Label lblCode;
        private Label lblInfrormation;
    }
}