using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    partial class QuestionEditorForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            txtQuestion = new TextBox();
            btnSave = new Button();
            dgvAnswers = new DataGridView();
            btnAddAnswer = new Button();
            btnEditAnswer = new Button();
            btnDeleteAnswer = new Button();
            lblQuestion = new Label();
            btnCancel = new Button();
            lnkBack = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dgvAnswers).BeginInit();
            SuspendLayout();
            // 
            // txtQuestion
            // 
            txtQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtQuestion.BackColor = Color.FromArgb(40, 40, 40);
            txtQuestion.BorderStyle = BorderStyle.FixedSingle;
            txtQuestion.Font = new Font("Segoe UI", 10F);
            txtQuestion.ForeColor = Color.White;
            txtQuestion.Location = new Point(26, 59);
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(843, 30);
            txtQuestion.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.LimeGreen;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(719, 400);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 35);
            btnSave.TabIndex = 1;
            btnSave.Text = "Зберегти питання";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // dgvAnswers
            // 
            dgvAnswers.AllowUserToAddRows = false;
            dgvAnswers.AllowUserToDeleteRows = false;
            dgvAnswers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAnswers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnswers.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvAnswers.BorderStyle = BorderStyle.None;
            dgvAnswers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(75, 0, 130);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(75, 0, 130);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAnswers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAnswers.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.BlueViolet;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAnswers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAnswers.EnableHeadersVisualStyles = false;
            dgvAnswers.GridColor = Color.FromArgb(60, 60, 60);
            dgvAnswers.Location = new Point(26, 120);
            dgvAnswers.Name = "dgvAnswers";
            dgvAnswers.ReadOnly = true;
            dgvAnswers.RowHeadersVisible = false;
            dgvAnswers.RowHeadersWidth = 51;
            dgvAnswers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnswers.Size = new Size(843, 260);
            dgvAnswers.TabIndex = 2;
            // 
            // btnAddAnswer
            // 
            btnAddAnswer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddAnswer.BackColor = Color.FromArgb(72, 61, 139);
            btnAddAnswer.Cursor = Cursors.Hand;
            btnAddAnswer.FlatAppearance.BorderSize = 0;
            btnAddAnswer.FlatStyle = FlatStyle.Flat;
            btnAddAnswer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddAnswer.ForeColor = Color.White;
            btnAddAnswer.Location = new Point(26, 400);
            btnAddAnswer.Name = "btnAddAnswer";
            btnAddAnswer.Size = new Size(150, 35);
            btnAddAnswer.TabIndex = 3;
            btnAddAnswer.Text = "Додати відповідь";
            btnAddAnswer.UseVisualStyleBackColor = false;
            btnAddAnswer.Click += btnAddAnswer_Click;
            // 
            // btnEditAnswer
            // 
            btnEditAnswer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditAnswer.BackColor = Color.FromArgb(72, 61, 139);
            btnEditAnswer.Cursor = Cursors.Hand;
            btnEditAnswer.FlatAppearance.BorderSize = 0;
            btnEditAnswer.FlatStyle = FlatStyle.Flat;
            btnEditAnswer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditAnswer.ForeColor = Color.White;
            btnEditAnswer.Location = new Point(182, 400);
            btnEditAnswer.Name = "btnEditAnswer";
            btnEditAnswer.Size = new Size(177, 35);
            btnEditAnswer.TabIndex = 4;
            btnEditAnswer.Text = "Редагувати відповідь";
            btnEditAnswer.UseVisualStyleBackColor = false;
            btnEditAnswer.Click += btnEditAnswer_Click;
            // 
            // btnDeleteAnswer
            // 
            btnDeleteAnswer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteAnswer.BackColor = Color.FromArgb(139, 0, 139);
            btnDeleteAnswer.Cursor = Cursors.Hand;
            btnDeleteAnswer.FlatAppearance.BorderSize = 0;
            btnDeleteAnswer.FlatStyle = FlatStyle.Flat;
            btnDeleteAnswer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteAnswer.ForeColor = Color.White;
            btnDeleteAnswer.Location = new Point(365, 400);
            btnDeleteAnswer.Name = "btnDeleteAnswer";
            btnDeleteAnswer.Size = new Size(166, 35);
            btnDeleteAnswer.TabIndex = 5;
            btnDeleteAnswer.Text = "Видалити відповідь";
            btnDeleteAnswer.UseVisualStyleBackColor = false;
            btnDeleteAnswer.Click += btnDeleteAnswer_Click;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQuestion.ForeColor = Color.Gainsboro;
            lblQuestion.Location = new Point(26, 30);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(127, 23);
            lblQuestion.TabIndex = 6;
            lblQuestion.Text = "Текст питання";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(606, 400);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 35);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lnkBack
            // 
            lnkBack.ActiveLinkColor = Color.Magenta;
            lnkBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lnkBack.AutoSize = true;
            lnkBack.Font = new Font("Segoe UI", 10F);
            lnkBack.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkBack.LinkColor = Color.Plum;
            lnkBack.Location = new Point(543, 406);
            lnkBack.Name = "lnkBack";
            lnkBack.Size = new Size(57, 23);
            lnkBack.TabIndex = 20;
            lnkBack.TabStop = true;
            lnkBack.Text = "Назад";
            lnkBack.VisitedLinkColor = Color.Plum;
            lnkBack.Click += lnkBack_Click;
            // 
            // QuestionEditorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(903, 460);
            Controls.Add(lnkBack);
            Controls.Add(btnCancel);
            Controls.Add(lblQuestion);
            Controls.Add(btnDeleteAnswer);
            Controls.Add(btnEditAnswer);
            Controls.Add(btnAddAnswer);
            Controls.Add(dgvAnswers);
            Controls.Add(btnSave);
            Controls.Add(txtQuestion);
            Name = "QuestionEditorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редагування питання";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvAnswers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtQuestion;
        private Button btnSave;
        private DataGridView dgvAnswers;
        private Button btnAddAnswer;
        private Button btnEditAnswer;
        private Button btnDeleteAnswer;
        private Label lblQuestion;
        private Button btnCancel;
        private LinkLabel lnkBack;
    }
}