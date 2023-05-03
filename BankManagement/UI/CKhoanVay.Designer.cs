namespace BankManagement.UI
{
    partial class CKhoanVay
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvKhoanVay = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxTinhTrang = new RJCodeAdvance.RJControls.RJTextBox();
            this.tbxLoai = new RJCodeAdvance.RJControls.RJTextBox();
            this.tbxTien = new RJCodeAdvance.RJControls.RJTextBox();
            this.tbxNgHan = new RJCodeAdvance.RJControls.RJTextBox();
            this.tbxNgVay = new RJCodeAdvance.RJControls.RJTextBox();
            this.tbxSoTK = new RJCodeAdvance.RJControls.RJTextBox();
            this.tbxSoKV = new RJCodeAdvance.RJControls.RJTextBox();
            this.btnTatToan = new RJCodeAdvance.RJControls.RJButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhoanVay)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvKhoanVay);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 551);
            this.panel1.TabIndex = 8;
            // 
            // dtgvKhoanVay
            // 
            this.dtgvKhoanVay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKhoanVay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvKhoanVay.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtgvKhoanVay.Location = new System.Drawing.Point(431, 0);
            this.dtgvKhoanVay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgvKhoanVay.Name = "dtgvKhoanVay";
            this.dtgvKhoanVay.ReadOnly = true;
            this.dtgvKhoanVay.RowHeadersWidth = 51;
            this.dtgvKhoanVay.RowTemplate.Height = 24;
            this.dtgvKhoanVay.Size = new System.Drawing.Size(508, 551);
            this.dtgvKhoanVay.TabIndex = 0;
            this.dtgvKhoanVay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvKhoanVay_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày hạn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tình trạng:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Số tiền:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Loại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Vay ngày:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số TK:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Số khoản vay:";
            // 
            // tbxTinhTrang
            // 
            this.tbxTinhTrang.BackColor = System.Drawing.SystemColors.Window;
            this.tbxTinhTrang.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbxTinhTrang.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbxTinhTrang.BorderRadius = 0;
            this.tbxTinhTrang.BorderSize = 2;
            this.tbxTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTinhTrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxTinhTrang.Location = new System.Drawing.Point(111, 252);
            this.tbxTinhTrang.Margin = new System.Windows.Forms.Padding(5);
            this.tbxTinhTrang.Multiline = false;
            this.tbxTinhTrang.Name = "tbxTinhTrang";
            this.tbxTinhTrang.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.tbxTinhTrang.PasswordChar = false;
            this.tbxTinhTrang.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbxTinhTrang.PlaceholderText = "";
            this.tbxTinhTrang.Size = new System.Drawing.Size(297, 35);
            this.tbxTinhTrang.TabIndex = 1;
            this.tbxTinhTrang.Texts = "";
            this.tbxTinhTrang.UnderlinedStyle = false;
            // 
            // tbxLoai
            // 
            this.tbxLoai.BackColor = System.Drawing.SystemColors.Window;
            this.tbxLoai.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbxLoai.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbxLoai.BorderRadius = 0;
            this.tbxLoai.BorderSize = 2;
            this.tbxLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxLoai.Location = new System.Drawing.Point(111, 299);
            this.tbxLoai.Margin = new System.Windows.Forms.Padding(5);
            this.tbxLoai.Multiline = false;
            this.tbxLoai.Name = "tbxLoai";
            this.tbxLoai.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.tbxLoai.PasswordChar = false;
            this.tbxLoai.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbxLoai.PlaceholderText = "";
            this.tbxLoai.Size = new System.Drawing.Size(297, 35);
            this.tbxLoai.TabIndex = 1;
            this.tbxLoai.Texts = "";
            this.tbxLoai.UnderlinedStyle = false;
            // 
            // tbxTien
            // 
            this.tbxTien.BackColor = System.Drawing.SystemColors.Window;
            this.tbxTien.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbxTien.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbxTien.BorderRadius = 0;
            this.tbxTien.BorderSize = 2;
            this.tbxTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxTien.Location = new System.Drawing.Point(111, 207);
            this.tbxTien.Margin = new System.Windows.Forms.Padding(5);
            this.tbxTien.Multiline = false;
            this.tbxTien.Name = "tbxTien";
            this.tbxTien.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.tbxTien.PasswordChar = false;
            this.tbxTien.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbxTien.PlaceholderText = "";
            this.tbxTien.Size = new System.Drawing.Size(297, 35);
            this.tbxTien.TabIndex = 1;
            this.tbxTien.Texts = "";
            this.tbxTien.UnderlinedStyle = false;
            // 
            // tbxNgHan
            // 
            this.tbxNgHan.BackColor = System.Drawing.SystemColors.Window;
            this.tbxNgHan.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbxNgHan.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbxNgHan.BorderRadius = 0;
            this.tbxNgHan.BorderSize = 2;
            this.tbxNgHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNgHan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxNgHan.Location = new System.Drawing.Point(111, 162);
            this.tbxNgHan.Margin = new System.Windows.Forms.Padding(5);
            this.tbxNgHan.Multiline = false;
            this.tbxNgHan.Name = "tbxNgHan";
            this.tbxNgHan.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.tbxNgHan.PasswordChar = false;
            this.tbxNgHan.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbxNgHan.PlaceholderText = "";
            this.tbxNgHan.Size = new System.Drawing.Size(297, 35);
            this.tbxNgHan.TabIndex = 1;
            this.tbxNgHan.Texts = "";
            this.tbxNgHan.UnderlinedStyle = false;
            // 
            // tbxNgVay
            // 
            this.tbxNgVay.BackColor = System.Drawing.SystemColors.Window;
            this.tbxNgVay.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbxNgVay.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbxNgVay.BorderRadius = 0;
            this.tbxNgVay.BorderSize = 2;
            this.tbxNgVay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNgVay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxNgVay.Location = new System.Drawing.Point(111, 117);
            this.tbxNgVay.Margin = new System.Windows.Forms.Padding(5);
            this.tbxNgVay.Multiline = false;
            this.tbxNgVay.Name = "tbxNgVay";
            this.tbxNgVay.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.tbxNgVay.PasswordChar = false;
            this.tbxNgVay.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbxNgVay.PlaceholderText = "";
            this.tbxNgVay.Size = new System.Drawing.Size(297, 35);
            this.tbxNgVay.TabIndex = 1;
            this.tbxNgVay.Texts = "";
            this.tbxNgVay.UnderlinedStyle = false;
            // 
            // tbxSoTK
            // 
            this.tbxSoTK.BackColor = System.Drawing.SystemColors.Window;
            this.tbxSoTK.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbxSoTK.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbxSoTK.BorderRadius = 0;
            this.tbxSoTK.BorderSize = 2;
            this.tbxSoTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSoTK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxSoTK.Location = new System.Drawing.Point(111, 69);
            this.tbxSoTK.Margin = new System.Windows.Forms.Padding(5);
            this.tbxSoTK.Multiline = false;
            this.tbxSoTK.Name = "tbxSoTK";
            this.tbxSoTK.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.tbxSoTK.PasswordChar = false;
            this.tbxSoTK.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbxSoTK.PlaceholderText = "";
            this.tbxSoTK.Size = new System.Drawing.Size(297, 35);
            this.tbxSoTK.TabIndex = 1;
            this.tbxSoTK.Texts = "";
            this.tbxSoTK.UnderlinedStyle = false;
            // 
            // tbxSoKV
            // 
            this.tbxSoKV.BackColor = System.Drawing.SystemColors.Window;
            this.tbxSoKV.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbxSoKV.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbxSoKV.BorderRadius = 0;
            this.tbxSoKV.BorderSize = 2;
            this.tbxSoKV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSoKV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxSoKV.Location = new System.Drawing.Point(111, 21);
            this.tbxSoKV.Margin = new System.Windows.Forms.Padding(5);
            this.tbxSoKV.Multiline = false;
            this.tbxSoKV.Name = "tbxSoKV";
            this.tbxSoKV.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.tbxSoKV.PasswordChar = false;
            this.tbxSoKV.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbxSoKV.PlaceholderText = "";
            this.tbxSoKV.Size = new System.Drawing.Size(297, 35);
            this.tbxSoKV.TabIndex = 1;
            this.tbxSoKV.Texts = "";
            this.tbxSoKV.UnderlinedStyle = false;
            // 
            // btnTatToan
            // 
            this.btnTatToan.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnTatToan.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnTatToan.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnTatToan.BorderRadius = 0;
            this.btnTatToan.BorderSize = 0;
            this.btnTatToan.FlatAppearance.BorderSize = 0;
            this.btnTatToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTatToan.ForeColor = System.Drawing.Color.White;
            this.btnTatToan.Location = new System.Drawing.Point(111, 351);
            this.btnTatToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTatToan.Name = "btnTatToan";
            this.btnTatToan.Size = new System.Drawing.Size(297, 39);
            this.btnTatToan.TabIndex = 3;
            this.btnTatToan.Text = "Tất toán khoản vay";
            this.btnTatToan.TextColor = System.Drawing.Color.White;
            this.btnTatToan.UseVisualStyleBackColor = false;
            this.btnTatToan.Click += new System.EventHandler(this.btnTatToan_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTatToan);
            this.panel2.Controls.Add(this.tbxSoKV);
            this.panel2.Controls.Add(this.tbxSoTK);
            this.panel2.Controls.Add(this.tbxNgVay);
            this.panel2.Controls.Add(this.tbxNgHan);
            this.panel2.Controls.Add(this.tbxTien);
            this.panel2.Controls.Add(this.tbxLoai);
            this.panel2.Controls.Add(this.tbxTinhTrang);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 551);
            this.panel2.TabIndex = 1;
            // 
            // CKhoanVay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CKhoanVay";
            this.Size = new System.Drawing.Size(939, 551);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhoanVay)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvKhoanVay;
        private System.Windows.Forms.Panel panel2;
        private RJCodeAdvance.RJControls.RJButton btnTatToan;
        private RJCodeAdvance.RJControls.RJTextBox tbxSoKV;
        private RJCodeAdvance.RJControls.RJTextBox tbxSoTK;
        private RJCodeAdvance.RJControls.RJTextBox tbxNgVay;
        private RJCodeAdvance.RJControls.RJTextBox tbxNgHan;
        private RJCodeAdvance.RJControls.RJTextBox tbxTien;
        private RJCodeAdvance.RJControls.RJTextBox tbxLoai;
        private RJCodeAdvance.RJControls.RJTextBox tbxTinhTrang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
