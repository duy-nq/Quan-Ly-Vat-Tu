using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Vat_Tu
{
    public partial class VatTu : DevExpress.XtraEditors.XtraForm
    {
        public VatTu()
        {
            InitializeComponent();
        }

        private void VatTu_Load(object sender, EventArgs e)
        {
            DS1.EnforceConstraints = false;
            this.VATTUTableAdapter.Fill(this.DS1.Vattu);
            this.CTPNTableAdapter.Fill(this.DS1.CTPN);
            this.CTPXTableAdapter.Fill(this.DS1.CTPX);
            this.CTDDHTableAdapter.Fill(this.DS1.CTDDH);

        }
    }
}