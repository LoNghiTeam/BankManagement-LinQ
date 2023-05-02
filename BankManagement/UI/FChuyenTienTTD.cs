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
    public partial class FChuyenTienTTD : Form
    {
        public FChuyenTienTTD(TheTinDung theTinDung, double soDu)
        {
            InitializeComponent();
            
        }

        private void FChuyenTienTTD_Load(object sender, EventArgs e)
        {
            
        }


        private void tbSoTKNhan__TextChanged(object sender, EventArgs e)
        {
            int soTKNhan = -1;
            if (int.TryParse(tbSoTKNhan.Texts, out soTKNhan))
            {
            }
        }

        private void tbTienChuyen__TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            
        }
    }
    
}
