using System.Drawing;
using System.Windows.Forms;

namespace KnowledgeTester1.Forms
{
    partial class ViewTestResultsForm
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

            lblTestTitle = new Label();
            dgvResults = new DataGridView();
            btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // lblTestTitle (Заголовок)
            // 
            lblTestTitle.AutoSize = true;
            lblTestTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTestTitle.ForeColor = Color.Plum; // Фіолетовий акцент
            lblTestTitle.Location = new Point(20, 20);
            lblTestTitle.Name = "lblTestTitle";
            lblTestTitle.Size = new Size(250, 32);
            lblTestTitle.TabIndex = 0;
            lblTestTitle.Text = "Результати тесту: ...";
            // 
            // dgvResults (Таблиця)
            // 
            dgvResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvResults.GridColor = Color.FromArgb(60, 60, 60);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(75, 0, 130);
            headerStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            headerStyle.ForeColor = Color.WhiteSmoke;
            headerStyle.SelectionBackColor = Color.FromArgb(75, 0, 130);
            headerStyle.SelectionForeColor = SystemColors.HighlightText;
            headerStyle.WrapMode = DataGridViewTriState.True;
            dgvResults.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvResults.ColumnHeadersHeight = 45;
            dgvResults.EnableHeadersVisualStyles = false;
            rowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = Color.FromArgb(45, 45, 48);
            rowStyle.Font = new Font("Segoe UI", 10F);
            rowStyle.ForeColor = Color.White;
            rowStyle.SelectionBackColor = Color.BlueViolet;
            rowStyle.SelectionForeColor = Color.White;
            rowStyle.WrapMode = DataGridViewTriState.False;
            dgvResults.DefaultCellStyle = rowStyle;
            dgvResults.Location = new Point(20, 70);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersVisible = false;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(760, 350);
            dgvResults.TabIndex = 1;
            // 
            // btnClose (Кнопка виходу)
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(72, 61, 139);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(630, 440);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 40);
            btnClose.TabIndex = 2;
            btnClose.Text = "Закрити";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // ViewTestResultsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(800, 500);
            Controls.Add(btnClose);
            Controls.Add(dgvResults);
            Controls.Add(lblTestTitle);
            Name = "ViewTestResultsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Перегляд результатів";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTestTitle;
        private DataGridView dgvResults;
        private Button btnClose;
    }
}