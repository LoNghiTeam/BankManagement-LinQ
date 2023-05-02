namespace BankManagement
{
    partial class FDangNhap
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.icpbMK = new FontAwesome.Sharp.IconPictureBox();
            this.btnLogin = new RJCodeAdvance.RJControls.RJButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblSignup = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icpbMK)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(145)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 540);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::BankManagement.Properties.Resources._1527713;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 540);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(249, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đăng nhập tài khoản của bạn!";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtTK);
            this.panel2.Controls.Add(this.iconPictureBox1);
            this.panel2.Location = new System.Drawing.Point(255, 178);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 49);
            this.panel2.TabIndex = 0;
            // 
            // txtTK
            // 
            this.txtTK.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTK.ForeColor = System.Drawing.Color.Silver;
            this.txtTK.Location = new System.Drawing.Point(48, 6);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(361, 36);
            this.txtTK.TabIndex = 0;
            this.txtTK.Tag = "Tài khoản";
            this.txtTK.Text = "Tài khoản";
            this.txtTK.Enter += new System.EventHandler(this.txtTK_Enter);
            this.txtTK.Leave += new System.EventHandler(this.txtTK_Leave);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.DimGray;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.HouseChimneyUser;
            this.iconPictureBox1.IconColor = System.Drawing.Color.DimGray;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 36;
            this.iconPictureBox1.Location = new System.Drawing.Point(5, 6);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(37, 36);
            this.iconPictureBox1.TabIndex = 3;
            this.iconPictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtMK);
            this.panel3.Controls.Add(this.icpbMK);
            this.panel3.Location = new System.Drawing.Point(255, 233);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(415, 49);
            this.panel3.TabIndex = 1;
            // 
            // txtMK
            // 
            this.txtMK.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMK.ForeColor = System.Drawing.Color.Silver;
            this.txtMK.Location = new System.Drawing.Point(48, 6);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(361, 36);
            this.txtMK.TabIndex = 1;
            this.txtMK.Tag = "Mật khẩu";
            this.txtMK.Text = "Mật khẩu";
            this.txtMK.UseSystemPasswordChar = true;
            this.txtMK.Enter += new System.EventHandler(this.txtMK_Enter);
            this.txtMK.Leave += new System.EventHandler(this.txtMK_Leave);
            // 
            // icpbMK
            // 
            this.icpbMK.BackColor = System.Drawing.Color.White;
            this.icpbMK.ForeColor = System.Drawing.Color.DimGray;
            this.icpbMK.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.icpbMK.IconColor = System.Drawing.Color.DimGray;
            this.icpbMK.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icpbMK.IconSize = 35;
            this.icpbMK.Location = new System.Drawing.Point(7, 6);
            this.icpbMK.Name = "icpbMK";
            this.icpbMK.Size = new System.Drawing.Size(35, 38);
            this.icpbMK.TabIndex = 3;
            this.icpbMK.TabStop = false;
            this.icpbMK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.icpbMK_MouseDown);
            this.icpbMK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.icpbMK_MouseUp);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DimGray;
            this.btnLogin.BackgroundColor = System.Drawing.Color.DimGray;
            this.btnLogin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogin.BorderRadius = 0;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(255, 320);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(150, 40);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(425, 330);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 16);
            this.linkLabel1.TabIndex = 3;
            // 
            // lblSignup
            // 
            this.lblSignup.AutoSize = true;
            this.lblSignup.Location = new System.Drawing.Point(425, 331);
            this.lblSignup.Name = "lblSignup";
            this.lblSignup.Size = new System.Drawing.Size(208, 16);
            this.lblSignup.TabIndex = 4;
            this.lblSignup.TabStop = true;
            this.lblSignup.Text = "Chưa có tài khoản? Đăng ký ngay!";
            this.lblSignup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSignup_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 540);
            this.Controls.Add(this.lblSignup);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icpbMK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTK;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMK;
        private FontAwesome.Sharp.IconPictureBox icpbMK;
        private RJCodeAdvance.RJControls.RJButton btnLogin;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel lblSignup;
    }
}