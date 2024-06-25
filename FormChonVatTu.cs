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
    public partial class FormChonVatTu : DevExpress.XtraEditors.XtraForm
    {
        public FormChonVatTu()
        {
            InitializeComponent();
        }

        private void FormChonVatTu_Load(object sender, EventArgs e)
        {
            this.VATTUTableAdapter.Fill(this.DS.Vattu);
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            DonDatHang.mavt = ((DataRowView)Bds_VatTu[Bds_VatTu.Position])["MAVT"].ToString();
            this.Close();
        }

        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}