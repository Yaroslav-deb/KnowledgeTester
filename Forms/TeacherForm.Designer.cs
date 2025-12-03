using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    partial class TeacherForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvTests;
        private Button btnCreateTest;
        private Button btnDeleteTest;
        private Button btnEditTest;
        private Button btnViewCreatedTests;
        private Button btnExit;
        private Label lblUserInfo;

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
            dgvTests = new DataGridView();
            btnCreateTest = new Button();
            btnEditTest = new Button();
            btnDeleteTest = new Button();
            btnViewCreatedTests = new Button();
            btnExit = new Button();
            lblUserInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTests).BeginInit();
            SuspendLayout();
            // 
            // dgvTests
            // 
            dgvTests.AllowUserToAddRows = false;
            dgvTests.AllowUserToDeleteRows = false;
            dgvTests.AllowUserToResizeRows = false;
            dgvTests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTests.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTests.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvTests.BorderStyle = BorderStyle.None;
            dgvTests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(75, 0, 130);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(75, 0, 130);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTests.ColumnHeadersHeight = 45;
            dgvTests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.BlueViolet;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTests.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTests.EnableHeadersVisualStyles = false;
            dgvTests.GridColor = Color.FromArgb(60, 60, 60);
            dgvTests.Location = new Point(20, 60);
            dgvTests.MultiSelect = false;
            dgvTests.Name = "dgvTests";
            dgvTests.ReadOnly = true;
            dgvTests.RowHeadersVisible = false;
            dgvTests.RowHeadersWidth = 51;
            dgvTests.RowTemplate.Height = 35;
            dgvTests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTests.Size = new Size(950, 450);
            dgvTests.TabIndex = 0;
            // 
            // btnCreateTest
            // 
            btnCreateTest.BackColor = Color.BlueViolet;
            btnCreateTest.Cursor = Cursors.Hand;
            btnCreateTest.FlatAppearance.BorderSize = 0;
            btnCreateTest.FlatStyle = FlatStyle.Flat;
            btnCreateTest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreateTest.ForeColor = Color.White;
            btnCreateTest.Location = new Point(820, 539);
            btnCreateTest.Name = "btnCreateTest";
            btnCreateTest.Size = new Size(150, 40);
            btnCreateTest.TabIndex = 2;
            btnCreateTest.Text = "Створити тест";
            btnCreateTest.UseVisualStyleBackColor = false;
            btnCreateTest.Click += btnCreateTest_Click;
            // 
            // btnEditTest
            // 
            btnEditTest.BackColor = Color.BlueViolet;
            btnEditTest.Cursor = Cursors.Hand;
            btnEditTest.FlatAppearance.BorderSize = 0;
            btnEditTest.FlatStyle = FlatStyle.Flat;
            btnEditTest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditTest.ForeColor = Color.White;
            btnEditTest.Location = new Point(653, 539);
            btnEditTest.Name = "btnEditTest";
            btnEditTest.Size = new Size(150, 40);
            btnEditTest.TabIndex = 3;
            btnEditTest.Text = "Редагувати тест";
            btnEditTest.UseVisualStyleBackColor = false;
            btnEditTest.Click += btnEditTest_Click;
            // 
            // btnDeleteTest
            // 
            btnDeleteTest.BackColor = Color.FromArgb(139, 0, 139);
            btnDeleteTest.Cursor = Cursors.Hand;
            btnDeleteTest.FlatAppearance.BorderSize = 0;
            btnDeleteTest.FlatStyle = FlatStyle.Flat;
            btnDeleteTest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteTest.ForeColor = Color.White;
            btnDeleteTest.Location = new Point(485, 539);
            btnDeleteTest.Name = "btnDeleteTest";
            btnDeleteTest.Size = new Size(150, 40);
            btnDeleteTest.TabIndex = 4;
            btnDeleteTest.Text = "Видалити тест";
            btnDeleteTest.UseVisualStyleBackColor = false;
            btnDeleteTest.Click += btnDeleteTest_Click;
            // 
            // btnViewCreatedTests
            // 
            btnViewCreatedTests.BackColor = Color.FromArgb(72, 61, 139);
            btnViewCreatedTests.Cursor = Cursors.Hand;
            btnViewCreatedTests.FlatAppearance.BorderSize = 0;
            btnViewCreatedTests.FlatStyle = FlatStyle.Flat;
            btnViewCreatedTests.Font = new Font("Segoe UI", 10F);
            btnViewCreatedTests.ForeColor = Color.White;
            btnViewCreatedTests.Location = new Point(20, 539);
            btnViewCreatedTests.Name = "btnViewCreatedTests";
            btnViewCreatedTests.Size = new Size(231, 40);
            btnViewCreatedTests.TabIndex = 1;
            btnViewCreatedTests.Text = "Перегляд результатів тесту";
            btnViewCreatedTests.UseVisualStyleBackColor = false;
            btnViewCreatedTests.Click += btnViewCreatedTests_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(178, 34, 34);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(825, 17);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(145, 30);
            btnExit.TabIndex = 5;
            btnExit.Text = "Вийти з акаунта";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Segoe UI", 12F);
            lblUserInfo.ForeColor = Color.Plum;
            lblUserInfo.Location = new Point(20, 15);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(142, 28);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "Роль: ...  Ім’я: ...";
            // 
            // TeacherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1000, 600);
            Controls.Add(btnExit);
            Controls.Add(lblUserInfo);
            Controls.Add(dgvTests);
            Controls.Add(btnViewCreatedTests);
            Controls.Add(btnCreateTest);
            Controls.Add(btnEditTest);
            Controls.Add(btnDeleteTest);
            Name = "TeacherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Кабінет вчителя";
            WindowState = FormWindowState.Maximized;
            Resize += TeacherForm_Resize;
            ((System.ComponentModel.ISupportInitialize)dgvTests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private void TeacherForm_Resize(object sender, EventArgs e)
        {
            int margin = 20;
            int groupSpacing = 10;
            int buttonHeight = 40;
            int bottomY = this.ClientSize.Height - buttonHeight - margin;

            btnViewCreatedTests.Location = new Point(margin, bottomY);

            int rightEdge = this.ClientSize.Width - margin;

            btnCreateTest.Location = new Point(rightEdge - btnCreateTest.Width, bottomY);

            btnEditTest.Location = new Point(btnCreateTest.Left - groupSpacing - btnEditTest.Width, bottomY);

            btnDeleteTest.Location = new Point(btnEditTest.Left - groupSpacing - btnDeleteTest.Width, bottomY);

            btnExit.Location = new Point(rightEdge - btnExit.Width, 15);

            int gridHeight = bottomY - 60 - margin;
            if (gridHeight > 0)
            {
                dgvTests.Height = gridHeight;
                dgvTests.Width = this.ClientSize.Width - (2 * margin);
            }
        }
        
    }
}