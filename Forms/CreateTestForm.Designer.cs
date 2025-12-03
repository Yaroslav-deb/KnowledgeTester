using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    partial class CreateTestForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTestForm));
            txtTitle = new TextBox();
            dgvQuestions = new DataGridView();
            btnSave = new Button();
            btnCreateQuestion = new Button();
            cbClass = new ComboBox();
            btnEditQuestion = new Button();
            btnDeleteQuestion = new Button();
            txtDescription = new TextBox();
            cbSubject = new ComboBox();
            lblTitle = new Label();
            lblSubject = new Label();
            lblDescription = new Label();
            lblClass = new Label();
            lnkBack = new LinkLabel();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.BackColor = Color.FromArgb(40, 40, 40);
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Font = new Font("Segoe UI", 10F);
            txtTitle.ForeColor = Color.White;
            txtTitle.Location = new Point(20, 46);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(450, 30);
            txtTitle.TabIndex = 0;
            // 
            // dgvQuestions
            // 
            dgvQuestions.AllowUserToAddRows = false;
            dgvQuestions.AllowUserToDeleteRows = false;
            dgvQuestions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuestions.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvQuestions.BorderStyle = BorderStyle.None;
            dgvQuestions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(75, 0, 130);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(75, 0, 130);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvQuestions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvQuestions.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.BlueViolet;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvQuestions.DefaultCellStyle = dataGridViewCellStyle2;
            dgvQuestions.EnableHeadersVisualStyles = false;
            dgvQuestions.GridColor = Color.FromArgb(60, 60, 60);
            dgvQuestions.Location = new Point(20, 160);
            dgvQuestions.Name = "dgvQuestions";
            dgvQuestions.ReadOnly = true;
            dgvQuestions.RowHeadersVisible = false;
            dgvQuestions.RowHeadersWidth = 51;
            dgvQuestions.Size = new Size(840, 280);
            dgvQuestions.TabIndex = 2;
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
            btnSave.Location = new Point(710, 460);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 35);
            btnSave.TabIndex = 6;
            btnSave.Text = "Зберегти тест";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCreateQuestion
            // 
            btnCreateQuestion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCreateQuestion.BackColor = Color.FromArgb(72, 61, 139);
            btnCreateQuestion.Cursor = Cursors.Hand;
            btnCreateQuestion.FlatAppearance.BorderSize = 0;
            btnCreateQuestion.FlatStyle = FlatStyle.Flat;
            btnCreateQuestion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCreateQuestion.ForeColor = Color.White;
            btnCreateQuestion.Location = new Point(20, 460);
            btnCreateQuestion.Name = "btnCreateQuestion";
            btnCreateQuestion.Size = new Size(160, 35);
            btnCreateQuestion.TabIndex = 7;
            btnCreateQuestion.Text = "Додати питання";
            btnCreateQuestion.UseVisualStyleBackColor = false;
            btnCreateQuestion.Click += btnCreateQuestion_Click;
            // 
            // cbClass
            // 
            cbClass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbClass.BackColor = Color.FromArgb(40, 40, 40);
            cbClass.FlatStyle = FlatStyle.Flat;
            cbClass.Font = new Font("Segoe UI", 10F);
            cbClass.ForeColor = Color.White;
            cbClass.FormattingEnabled = true;
            cbClass.Location = new Point(710, 46);
            cbClass.Name = "cbClass";
            cbClass.Size = new Size(150, 31);
            cbClass.TabIndex = 8;
            // 
            // btnEditQuestion
            // 
            btnEditQuestion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditQuestion.BackColor = Color.FromArgb(72, 61, 139);
            btnEditQuestion.Cursor = Cursors.Hand;
            btnEditQuestion.FlatAppearance.BorderSize = 0;
            btnEditQuestion.FlatStyle = FlatStyle.Flat;
            btnEditQuestion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditQuestion.ForeColor = Color.White;
            btnEditQuestion.Location = new Point(186, 461);
            btnEditQuestion.Name = "btnEditQuestion";
            btnEditQuestion.Size = new Size(171, 35);
            btnEditQuestion.TabIndex = 9;
            btnEditQuestion.Text = "Редагувати питання";
            btnEditQuestion.UseVisualStyleBackColor = false;
            btnEditQuestion.Click += btnEditQuestion_Click;
            // 
            // btnDeleteQuestion
            // 
            btnDeleteQuestion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteQuestion.BackColor = Color.FromArgb(139, 0, 139);
            btnDeleteQuestion.Cursor = Cursors.Hand;
            btnDeleteQuestion.FlatAppearance.BorderSize = 0;
            btnDeleteQuestion.FlatStyle = FlatStyle.Flat;
            btnDeleteQuestion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteQuestion.ForeColor = Color.White;
            btnDeleteQuestion.Location = new Point(363, 461);
            btnDeleteQuestion.Name = "btnDeleteQuestion";
            btnDeleteQuestion.Size = new Size(160, 35);
            btnDeleteQuestion.TabIndex = 10;
            btnDeleteQuestion.Text = "Видалити питання";
            btnDeleteQuestion.UseVisualStyleBackColor = false;
            btnDeleteQuestion.Click += btnDeleteQuestion_Click;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.BackColor = Color.FromArgb(40, 40, 40);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.ForeColor = Color.White;
            txtDescription.Location = new Point(20, 111);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(840, 30);
            txtDescription.TabIndex = 11;
            // 
            // cbSubject
            // 
            cbSubject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbSubject.BackColor = Color.FromArgb(40, 40, 40);
            cbSubject.FlatStyle = FlatStyle.Flat;
            cbSubject.Font = new Font("Segoe UI", 10F);
            cbSubject.ForeColor = Color.White;
            cbSubject.FormattingEnabled = true;
            cbSubject.Location = new Point(490, 46);
            cbSubject.Name = "cbSubject";
            cbSubject.Size = new Size(200, 31);
            cbSubject.TabIndex = 12;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Gainsboro;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(106, 23);
            lblTitle.TabIndex = 13;
            lblTitle.Text = "Назва тесту";
            // 
            // lblSubject
            // 
            lblSubject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSubject.AutoSize = true;
            lblSubject.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubject.ForeColor = Color.Gainsboro;
            lblSubject.Location = new Point(490, 20);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(84, 23);
            lblSubject.TabIndex = 14;
            lblSubject.Text = "Предмет";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescription.ForeColor = Color.Gainsboro;
            lblDescription.Location = new Point(20, 85);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(52, 23);
            lblDescription.TabIndex = 15;
            lblDescription.Text = "Опис";
            // 
            // lblClass
            // 
            lblClass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClass.AutoSize = true;
            lblClass.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClass.ForeColor = Color.Gainsboro;
            lblClass.Location = new Point(710, 20);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(49, 23);
            lblClass.TabIndex = 16;
            lblClass.Text = "Клас";
            // 
            // lnkBack
            // 
            lnkBack.ActiveLinkColor = Color.Magenta;
            lnkBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lnkBack.AutoSize = true;
            lnkBack.Font = new Font("Segoe UI", 10F);
            lnkBack.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkBack.LinkColor = Color.Plum;
            lnkBack.Location = new Point(530, 466);
            lnkBack.Name = "lnkBack";
            lnkBack.Size = new Size(57, 23);
            lnkBack.TabIndex = 17;
            lnkBack.TabStop = true;
            lnkBack.Text = "Назад";
            lnkBack.VisitedLinkColor = Color.Plum;
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
            btnCancel.Location = new Point(593, 460);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 35);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // CreateTestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(882, 520);
            Controls.Add(lnkBack);
            Controls.Add(lblClass);
            Controls.Add(lblDescription);
            Controls.Add(lblSubject);
            Controls.Add(lblTitle);
            Controls.Add(cbSubject);
            Controls.Add(txtDescription);
            Controls.Add(btnDeleteQuestion);
            Controls.Add(btnEditQuestion);
            Controls.Add(cbClass);
            Controls.Add(btnCreateQuestion);
            Controls.Add(btnSave);
            Controls.Add(dgvQuestions);
            Controls.Add(txtTitle);
            Controls.Add(btnCancel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(900, 560);
            Name = "CreateTestForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Створення нового тесту";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private DataGridView dgvQuestions;
        private Button btnSave;
        private Button btnCreateQuestion;
        private ComboBox cbClass;
        private Button btnEditQuestion;
        private Button btnDeleteQuestion;
        private TextBox txtDescription;
        private ComboBox cbSubject;
        private Label lblTitle;
        private Label lblSubject;
        private Label lblDescription;
        private Label lblClass;
        private LinkLabel lnkBack;
        private Button btnCancel;
    }
}