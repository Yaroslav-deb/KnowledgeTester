using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    partial class AnswerEditorForm
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
            txtAnswer = new TextBox();
            chkCorrect = new CheckBox();
            btnSave = new Button();
            lblAnswer = new Label();
            SuspendLayout();

            // 
            // lblAnswer
            // 
            lblAnswer.AutoSize = true;
            lblAnswer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAnswer.ForeColor = Color.Gainsboro;
            lblAnswer.Location = new Point(30, 30);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(138, 23);
            lblAnswer.TabIndex = 3;
            lblAnswer.Text = "Текст відповіді:";

            // 
            // txtAnswer
            // 
            txtAnswer.BackColor = Color.FromArgb(40, 40, 40);
            txtAnswer.BorderStyle = BorderStyle.FixedSingle;
            txtAnswer.Font = new Font("Segoe UI", 10F);
            txtAnswer.ForeColor = Color.White;
            txtAnswer.Location = new Point(30, 60);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(420, 30);
            txtAnswer.TabIndex = 0;

            // 
            // chkCorrect
            // 
            chkCorrect.AutoSize = true;
            chkCorrect.Font = new Font("Segoe UI", 10F);
            chkCorrect.ForeColor = Color.WhiteSmoke;
            chkCorrect.Location = new Point(30, 110);
            chkCorrect.Name = "chkCorrect";
            chkCorrect.Size = new Size(244, 27);
            chkCorrect.TabIndex = 1;
            chkCorrect.Text = "Це правильна відповідь?";
            chkCorrect.UseVisualStyleBackColor = true;

            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LimeGreen;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(30, 160);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(420, 40);
            btnSave.TabIndex = 2;
            btnSave.Text = "Зберегти відповідь";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;

            // 
            // AnswerEditorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(480, 230);
            Controls.Add(lblAnswer);
            Controls.Add(btnSave);
            Controls.Add(chkCorrect);
            Controls.Add(txtAnswer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AnswerEditorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редактор відповіді";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAnswer;
        private CheckBox chkCorrect;
        private Button btnSave;
        private Label lblAnswer;
    }
}