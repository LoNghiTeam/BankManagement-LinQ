using BankManagement.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement
{
    public partial class FHomeKH : Form
    {
        //Fields
        private int borderSize = 2;
        private Size formSize;
        private UserControl userControl;
        //Constructor
        public FHomeKH()
        {
            InitializeComponent();
            CollapseMenu();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(98, 102, 244);
            userControl = new CXinChao();
            userControl.Size = new Size(panelDesktop.Width, panelDesktop.Height);
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(userControl);
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;

            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right

            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          

                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion

            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);

                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }
        //Event Methods
        private void Form2_Resize(object sender, EventArgs e)
        {
            AdjustForm();
            //userControl.Size = new Size(panelDesktop.Width, panelDesktop.Height);
        }
        //Private methods
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(0, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }
        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200) //Collapse menu
            {
                panelMenu.Width = 100;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                panelMenu.Width = 230;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        } 
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Cảnh báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            userControl = new CXinChao();
            userControl.Size = new Size(panelDesktop.Width, panelDesktop.Height);
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(userControl);
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            FChuyenTien giaoDich = new FChuyenTien();
            giaoDich.ShowDialog();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            FNapTien napTien = new FNapTien();
            napTien.ShowDialog();
        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            lblName.Text = "Xin chào " + logging.Taikhoan.HoVaTen;
        }

        private void HomeControl_ButtonClicked(object sender, EventArgs e)
        {
            // Xử lý sự kiện cho tất cả các nút
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // Xử lý cho từng nút tùy theo tên hoặc tag của nút
                if (clickedButton.Name == "btnThem")
                {
                    HomeControl_ButtonThemClicked();
                }
                else if (clickedButton.Name == "btnSua")
                {
                    HomeControl_ButtonSuaClicked();
                }
                else
                {
                    // Xử lý cho các nút khác
                }
            }
        }
        private void HomeControl_ButtonThemClicked()
        {
            MessageBox.Show("Button Them");
        }
        private void HomeControl_ButtonSuaClicked()
        {
            MessageBox.Show("Button Sua");
        }

        private void tsmiSignin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FDangNhap login = new FDangNhap();
            login.Show();
            logging.Taikhoan = null;
        }

        private void panelTitle_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnRutTien_Click(object sender, EventArgs e)
        {
            FRutTien fRutTien = new FRutTien();
            fRutTien.ShowDialog();
        }

        private void btnVayTien_Click(object sender, EventArgs e)
        {
            FVayTienTinDung fVayTien = new FVayTienTinDung();
            fVayTien.ShowDialog();
        }

        private void btnGuiTietKiem_Click(object sender, EventArgs e)
        {
            FTietKiem fTietKiem = new FTietKiem();
            fTietKiem.ShowDialog();
        }

        private void btnQLSTK_Click(object sender, EventArgs e)
        {
            userControl = new CSoTietKiem();
            CSoTietKiem cSoTK = userControl as CSoTietKiem;
            cSoTK.Size = new Size(panelDesktop.Width, panelDesktop.Height);
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(cSoTK);
        }

        private void btnTransHis_Click(object sender, EventArgs e)
        {
            userControl = new CGiaoDich();
            CGiaoDich transControl = userControl as CGiaoDich;
            transControl.Size = new Size(panelDesktop.Width, panelDesktop.Height);
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(transControl);
        }

        private void btnVayTD_Click(object sender, EventArgs e)
        {
            FVayTienTinDung fVayTien = new FVayTienTinDung();
            fVayTien.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDoiMK fChangePass = new FDoiMK();
            fChangePass.ShowDialog();
        }
    }
}
