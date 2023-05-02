namespace BankManagement
{
    partial class CGiaoDich
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
            this.dtgvTrans = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbLoaiGD = new RJCodeAdvance.RJControls.RJComboBox();
            this.cbDate = new System.Windows.Forms.CheckBox();
            this.btnClear = new RJCodeAdvance.RJControls.RJButton();
            this.btnTimKiem = new RJCodeAdvance.RJControls.RJButton();
            this.dpNgayGD = new RJCodeAdvance.RJControls.RJDatePicker();
            this.tbxMaGD = new RJCodeAdvance.RJControls.RJTextBox();
            this.tbxNgGui = new RJCodeAdvance.RJControls.RJTextBox();
            this.tbxNgNhan = new RJCodeAdvance.RJControls.RJTextBox();
            this.tbxTienGD = new RJCodeAdvance.RJControls.RJTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDetailGD = new RJCodeAdvance.RJControls.RJButton();
            this.btnPrintGD = new RJCodeAdvance.RJControls.RJButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbMaGD = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrintAllGD = new RJCodeAdvance.RJControls.RJButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTrans)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dtgvTrans);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 576);
            this.panel1.TabIndex = 4;
            // 
            // dtgvTrans
            // 
            this.dtgvTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvTrans.Location = new System.Drawing.Point(439, 0);
            this.dtgvTrans.Name = "dtgvTrans";
            this.dtgvTrans.RowHeadersWidth = 51;
            this.dtgvTrans.RowTemplate.Height = 24;
            this.dtgvTrans.Size = new System.Drawing.Size(672, 437);
            this.dtgvTrans.TabIndex = 3;
            this.dtgvTrans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTrans_CellClick);
            this.dtgvTrans.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTrans_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbLoaiGD);
            this.groupBox2.Controls.Add(this.cbDate);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.dpNgayGD);
            this.groupBox2.Controls.Add(this.tbxMaGD);
            this.groupBox2.Controls.Add(this.tbxNgGui);
            this.groupBox2.Controls.Add(this.tbxNgNhan);
            this.groupBox2.Controls.Add(this.tbxTienGD);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 437);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm nâng cao";
            // 
            // cbbLoaiGD
            // 
            this.cbbLoaiGD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbLoaiGD.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbLoaiGD.BorderSize = 1;
            this.cbbLoaiGD.DisplayMember = "Vay Tiền";
            this.cbbLoaiGD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbLoaiGD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbbLoaiGD.ForeColor = System.Drawing.Color.DimGray;
            this.cbbLoaiGD.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbLoaiGD.Items.AddRange(new object[] {
            "Toàn Bộ Giao Dịch",
            "Rút Tiền",
            "Nạp Tiền",
            "Chuyển Khoản",
            "Gửi Tiết Kiệm",
            "Vay Tín Dụng",
            "Vay Thế Chấp",
            "Tất Toán Giao Dịch",
            "Thanh Toán Nợ"});
            this.cbbLoaiGD.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbbLoaiGD.ListTextColor = System.Drawing.Color.DimGray;
            this.cbbLoaiGD.Location = new System.Drawing.Point(131, 264);
            this.cbbLoaiGD.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbLoaiGD.Name = "cbbLoaiGD";
            this.cbbLoaiGD.Padding = new System.Windows.Forms.Padding(1);
            this.cbbLoaiGD.Size = new System.Drawing.Size(280, 35);
            this.cbbLoaiGD.TabIndex = 17;
            this.cbbLoaiGD.Texts = "";
            // 
            // cbDate
            // 
            this.cbDate.AutoSize = true;
            this.cbDate.Checked = true;
            this.cbDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDate.Location = new System.Drawing.Point(393, 175);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(18, 17);
            this.cbDate.TabIndex = 16;
            this.cbDate.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnClear.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnClear.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnClear.BorderRadius = 0;
            this.btnClear.BorderSize = 0;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(131, 360);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(280, 40);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Cài lại bộ lọc";
            this.btnClear.TextColor = System.Drawing.Color.White;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnTimKiem.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnTimKiem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnTimKiem.BorderRadius = 0;
            this.btnTimKiem.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(131, 314);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(280, 40);
            this.btnTimKiem.TabIndex = 15;
            this.btnTimKiem.Text = "Tìm kiếm nâng cao";
            this.btnTimKiem.TextColor = System.Drawing.Color.White;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dpNgayGD
            // 
            this.dpNgayGD.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dpNgayGD.BorderSize = 0;
            this.dpNgayGD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dpNgayGD.Location = new System.Drawing.Point(131, 166);
            this.dpNgayGD.MinimumSize = new System.Drawing.Size(4, 35);
            this.dpNgayGD.Name = "dpNgayGD";
            this.dpNgayGD.Size = new System.Drawing.Size(256, 35);
            this.dpNgayGD.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.dpNgayGD.TabIndex = 14;
            this.dpNgayGD.TextColor = System.Drawing.Color.White;
            this.dpNgayGD.Value = new System.DateTime(2023, 3, 22, 18, 2, 33, 0);
            // 
            // tbxMaGD
            // 
            this.tbxMaGD.BackColor = System.Drawing.SystemColors.Window;
            this.tbxMaGD.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbxMaGD.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbxMaGD.BorderRadius = 0;
            this.tbxMaGD.BorderSize = 2;
            this.tbxMaGD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMaGD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxMaGD.Location = new System.Drawing.Point(131, 22);
            this.tbxMaGD.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMaGD.Multiline = false;
            this.tbxMaGD.Name = "tbxMaGD";
            this.tbxMaGD.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbxMaGD.PasswordChar = false;
            this.tbxMaGD.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbxMaGD.PlaceholderText = "";
            this.tbxMaGD.Size = new System.Drawing.Size(280, 35);
            this.tbxMaGD.TabIndex = 9;
            this.tbxMaGD.Texts = "";
            this.tbxMaGD.UnderlinedStyle = false;
            // 
            // tbxNgGui
            // 
            this.tbxNgGui.BackColor = System.Drawing.SystemColors.Window;
            this.tbxNgGui.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbxNgGui.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbxNgGui.BorderRadius = 0;
            this.tbxNgGui.BorderSize = 2;
            this.tbxNgGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNgGui.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxNgGui.Location = new System.Drawing.Point(131, 70);
            this.tbxNgGui.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNgGui.Multiline = false;
            this.tbxNgGui.Name = "tbxNgGui";
            this.tbxNgGui.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbxNgGui.PasswordChar = false;
            this.tbxNgGui.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbxNgGui.PlaceholderText = "";
            this.tbxNgGui.Size = new System.Drawing.Size(280, 35);
            this.tbxNgGui.TabIndex = 10;
            this.tbxNgGui.Texts = "";
            this.tbxNgGui.UnderlinedStyle = false;
            // 
            // tbxNgNhan
            // 
            this.tbxNgNhan.BackColor = System.Drawing.SystemColors.Window;
            this.tbxNgNhan.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbxNgNhan.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbxNgNhan.BorderRadius = 0;
            this.tbxNgNhan.BorderSize = 2;
            this.tbxNgNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNgNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxNgNhan.Location = new System.Drawing.Point(131, 118);
            this.tbxNgNhan.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNgNhan.Multiline = false;
            this.tbxNgNhan.Name = "tbxNgNhan";
            this.tbxNgNhan.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbxNgNhan.PasswordChar = false;
            this.tbxNgNhan.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbxNgNhan.PlaceholderText = "";
            this.tbxNgNhan.Size = new System.Drawing.Size(280, 35);
            this.tbxNgNhan.TabIndex = 11;
            this.tbxNgNhan.Texts = "";
            this.tbxNgNhan.UnderlinedStyle = false;
            // 
            // tbxTienGD
            // 
            this.tbxTienGD.BackColor = System.Drawing.SystemColors.Window;
            this.tbxTienGD.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbxTienGD.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbxTienGD.BorderRadius = 0;
            this.tbxTienGD.BorderSize = 2;
            this.tbxTienGD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTienGD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxTienGD.Location = new System.Drawing.Point(131, 214);
            this.tbxTienGD.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTienGD.Multiline = false;
            this.tbxTienGD.Name = "tbxTienGD";
            this.tbxTienGD.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbxTienGD.PasswordChar = false;
            this.tbxTienGD.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbxTienGD.PlaceholderText = "";
            this.tbxTienGD.Size = new System.Drawing.Size(280, 35);
            this.tbxTienGD.TabIndex = 12;
            this.tbxTienGD.Texts = "";
            this.tbxTienGD.UnderlinedStyle = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Mã giao dịch: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Mã người gửi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mã người nhận:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày giao dịch:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Loại giao dịch:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số tiền giao dịch:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 437);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 139);
            this.panel2.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.GhostWhite;
            this.panel4.Controls.Add(this.flowLayoutPanel2);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(439, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(672, 139);
            this.panel4.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnDetailGD);
            this.flowLayoutPanel2.Controls.Add(this.btnPrintGD);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Enabled = false;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 28);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(672, 111);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btnDetailGD
            // 
            this.btnDetailGD.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnDetailGD.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnDetailGD.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDetailGD.BorderRadius = 0;
            this.btnDetailGD.BorderSize = 0;
            this.btnDetailGD.FlatAppearance.BorderSize = 0;
            this.btnDetailGD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailGD.ForeColor = System.Drawing.Color.White;
            this.btnDetailGD.Location = new System.Drawing.Point(3, 3);
            this.btnDetailGD.Name = "btnDetailGD";
            this.btnDetailGD.Size = new System.Drawing.Size(272, 40);
            this.btnDetailGD.TabIndex = 0;
            this.btnDetailGD.Text = "Xem chi tiết giao dịch được chọn";
            this.btnDetailGD.TextColor = System.Drawing.Color.White;
            this.btnDetailGD.UseVisualStyleBackColor = false;
            this.btnDetailGD.Click += new System.EventHandler(this.btnDetailGD_Click);
            // 
            // btnPrintGD
            // 
            this.btnPrintGD.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPrintGD.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPrintGD.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPrintGD.BorderRadius = 0;
            this.btnPrintGD.BorderSize = 0;
            this.btnPrintGD.FlatAppearance.BorderSize = 0;
            this.btnPrintGD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintGD.ForeColor = System.Drawing.Color.White;
            this.btnPrintGD.Location = new System.Drawing.Point(281, 3);
            this.btnPrintGD.Name = "btnPrintGD";
            this.btnPrintGD.Size = new System.Drawing.Size(271, 40);
            this.btnPrintGD.TabIndex = 2;
            this.btnPrintGD.Text = "In giao dịch được chọn";
            this.btnPrintGD.TextColor = System.Drawing.Color.White;
            this.btnPrintGD.UseVisualStyleBackColor = false;
            this.btnPrintGD.Click += new System.EventHandler(this.btnPrintGD_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbMaGD);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(672, 28);
            this.panel5.TabIndex = 0;
            // 
            // lbMaGD
            // 
            this.lbMaGD.AutoSize = true;
            this.lbMaGD.Location = new System.Drawing.Point(99, 6);
            this.lbMaGD.Name = "lbMaGD";
            this.lbMaGD.Size = new System.Drawing.Size(16, 16);
            this.lbMaGD.TabIndex = 1;
            this.lbMaGD.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã giao dịch:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(439, 139);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hành động khác";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoScroll = true;
            this.flowLayoutPanel3.Controls.Add(this.btnPrintAllGD);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(433, 118);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnPrintAllGD
            // 
            this.btnPrintAllGD.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPrintAllGD.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPrintAllGD.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPrintAllGD.BorderRadius = 0;
            this.btnPrintAllGD.BorderSize = 0;
            this.btnPrintAllGD.FlatAppearance.BorderSize = 0;
            this.btnPrintAllGD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintAllGD.ForeColor = System.Drawing.Color.White;
            this.btnPrintAllGD.Location = new System.Drawing.Point(3, 3);
            this.btnPrintAllGD.Name = "btnPrintAllGD";
            this.btnPrintAllGD.Size = new System.Drawing.Size(427, 40);
            this.btnPrintAllGD.TabIndex = 1;
            this.btnPrintAllGD.Text = "In danh sách giao dịch";
            this.btnPrintAllGD.TextColor = System.Drawing.Color.White;
            this.btnPrintAllGD.UseVisualStyleBackColor = false;
            this.btnPrintAllGD.Click += new System.EventHandler(this.btnPrintAllGD_Click);
            // 
            // CGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CGiaoDich";
            this.Size = new System.Drawing.Size(1111, 576);
            this.Load += new System.EventHandler(this.CTrans_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTrans)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvTrans;
        private System.Windows.Forms.GroupBox groupBox2;
        private RJCodeAdvance.RJControls.RJDatePicker dpNgayGD;
        private RJCodeAdvance.RJControls.RJTextBox tbxMaGD;
        private RJCodeAdvance.RJControls.RJTextBox tbxNgGui;
        private RJCodeAdvance.RJControls.RJTextBox tbxNgNhan;
        private RJCodeAdvance.RJControls.RJTextBox tbxTienGD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private RJCodeAdvance.RJControls.RJButton btnTimKiem;
        private System.Windows.Forms.CheckBox cbDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lbMaGD;
        private System.Windows.Forms.Label label1;
        private RJCodeAdvance.RJControls.RJComboBox cbbLoaiGD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private RJCodeAdvance.RJControls.RJButton btnDetailGD;
        private RJCodeAdvance.RJControls.RJButton btnClear;
        private RJCodeAdvance.RJControls.RJButton btnPrintGD;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private RJCodeAdvance.RJControls.RJButton btnPrintAllGD;
    }
}