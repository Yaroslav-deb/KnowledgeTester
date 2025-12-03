using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    partial class EditTestForm
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
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblClass = new Label();
            cbClass = new ComboBox();
            dgvQuestions = new DataGridView();
            btnSave = new Button();
            btnCancel = new Button();
            btnAddQuestion = new Button();
            btnEditQuestion = new Button();
            btnDeleteQuestion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Gainsboro;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(106, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Назва тесту";
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
            txtTitle.Size = new Size(545, 30);
            txtTitle.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescription.ForeColor = Color.Gainsboro;
            lblDescription.Location = new Point(20, 85);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(52, 23);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Опис";
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
            txtDescription.Size = new Size(765, 30);
            txtDescription.TabIndex = 5;
            // 
            // lblClass
            // 
            lblClass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClass.AutoSize = true;
            lblClass.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClass.ForeColor = Color.Gainsboro;
            lblClass.Location = new Point(585, 20);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(49, 23);
            lblClass.TabIndex = 2;
            lblClass.Text = "Клас";
            // 
            // cbClass
            // 
            cbClass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbClass.BackColor = Color.FromArgb(40, 40, 40);
            cbClass.FlatStyle = FlatStyle.Flat;
            cbClass.Font = new Font("Segoe UI", 10F);
            cbClass.ForeColor = Color.White;
            cbClass.FormattingEnabled = true;
            cbClass.Location = new Point(585, 46);
            cbClass.Name = "cbClass";
            cbClass.Size = new Size(200, 31);
            cbClass.TabIndex = 3;
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
            dgvQuestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuestions.Size = new Size(765, 300);
            dgvQuestions.TabIndex = 6;
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
            btnSave.Location = new Point(635, 480);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 35);
            btnSave.TabIndex = 10;
            btnSave.Text = "Зберегти зміни";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
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
            btnCancel.Location = new Point(525, 480);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAddQuestion
            // 
            btnAddQuestion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddQuestion.BackColor = Color.FromArgb(72, 61, 139);
            btnAddQuestion.Cursor = Cursors.Hand;
            btnAddQuestion.FlatAppearance.BorderSize = 0;
            btnAddQuestion.FlatStyle = FlatStyle.Flat;
            btnAddQuestion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddQuestion.ForeColor = Color.White;
            btnAddQuestion.Location = new Point(20, 480);
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Size = new Size(150, 35);
            btnAddQuestion.TabIndex = 7;
            btnAddQuestion.Text = "Додати питання";
            btnAddQuestion.UseVisualStyleBackColor = false;
            btnAddQuestion.Click += btnAddQuestion_Click;
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
            btnEditQuestion.Location = new Point(176, 480);
            btnEditQuestion.Name = "btnEditQuestion";
            btnEditQuestion.Size = new Size(166, 35);
            btnEditQuestion.TabIndex = 8;
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
            btnDeleteQuestion.Location = new Point(348, 480);
            btnDeleteQuestion.Name = "btnDeleteQuestion";
            btnDeleteQuestion.Size = new Size(158, 35);
            btnDeleteQuestion.TabIndex = 9;
            btnDeleteQuestion.Text = "Видалити питання";
            btnDeleteQuestion.UseVisualStyleBackColor = false;
            btnDeleteQuestion.Click += btnDeleteQuestion_Click;
            // 
            // EditTestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(807, 540);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnDeleteQuestion);
            Controls.Add(btnEditQuestion);
            Controls.Add(btnAddQuestion);
            Controls.Add(dgvQuestions);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(cbClass);
            Controls.Add(lblClass);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            MinimumSize = new Size(780, 580);
            Name = "EditTestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редагування тесту";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblClass;
        private ComboBox cbClass;
        private DataGridView dgvQuestions;
        private Button btnSave;
        private Button btnCancel;
        private Button btnAddQuestion;
        private Button btnEditQuestion;
        private Button btnDeleteQuestion;
    }
}