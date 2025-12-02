using KnowledgeTester1.Database;

namespace KnowledgeTester1.Forms
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
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
            btnLogin.BackColor = Color.SeaShell;
            btnLogin.Location = new Point(332, 342);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Увійти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Bisque;
            lblTitle.BorderStyle = BorderStyle.FixedSingle;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(86, 43);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(285, 33);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Вхід у систему тестування";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(235, 169);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(174, 27);
            txtFullName.TabIndex = 2;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(235, 235);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(174, 27);
            txtCode.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFullName.Location = new Point(32, 169);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(37, 23);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "ПІБ";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblCode.Location = new Point(32, 235);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(158, 23);
            lblCode.TabIndex = 5;
            lblCode.Text = "Персональний код";
            // 
            // lblInfrormation
            // 
            lblInfrormation.AutoSize = true;
            lblInfrormation.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblInfrormation.Location = new Point(174, 103);
            lblInfrormation.Name = "lblInfrormation";
            lblInfrormation.Size = new Size(114, 17);
            lblInfrormation.TabIndex = 6;
            lblInfrormation.Text = "Введіть такі данні:";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(457, 414);
            Controls.Add(lblInfrormation);
            Controls.Add(lblCode);
            Controls.Add(lblFullName);
            Controls.Add(txtCode);
            Controls.Add(txtFullName);
            Controls.Add(lblTitle);
            Controls.Add(btnLogin);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
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
