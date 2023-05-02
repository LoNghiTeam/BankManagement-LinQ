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
    public partial class FTatToanKV : Form
    {
        public FTatToanKV()
        {
            InitializeComponent();
        }

        internal FTatToanKV(KhoanVay khoanVay)
        {
            InitializeComponent();
        }

        private void FTatToanKV_Load(object sender, EventArgs e)
        {
            
        }
        private double TienTamTinh(int thoigianLT, double tien, int thoigianTT)
        {
            return 0;
        }
       
        private void btnTatToan_Click(object sender, EventArgs e)
        {
        }
    }
}
