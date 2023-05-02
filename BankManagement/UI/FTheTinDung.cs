using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.UI
{
    public partial class FTheTinDung : Form
    {
        
        public FTheTinDung()
        {
            InitializeComponent();
        }

        private void FTheTinDung_Load(object sender, EventArgs e)
        {
           
        }

        private void tbSTK__TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnMoThe_Click(object sender, EventArgs e)
        {
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
        }
       
        
        private void btnRutTien_Click(object sender, EventArgs e)
        {
        }
        private void refresh()
        {
            int soTK = -1;
            int.TryParse(tbSTK.Texts.Trim(), out soTK);
            tbSTK.Texts = String.Empty;
            tbSTK.Texts = soTK.ToString();
        }
        private void btnChuyenTien_Click(object sender, EventArgs e)
        {
        }
    }

}
