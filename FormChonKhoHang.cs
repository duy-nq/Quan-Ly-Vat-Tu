using DevExpress.XtraEditors;
using Quan_Ly_Vat_Tu.DSTableAdapters;
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
    public partial class FormChonKhoHang : DevExpress.XtraEditors.XtraForm
    {
        public FormChonKhoHang()
        {
            InitializeComponent();
        }

        private void FormChonKhoHang_Load(object sender, EventArgs e)
        {
            KHOTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.KHOTableAdapter.Fill(this.DS.Kho);
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            DonDatHang.makho = ((DataRowView)Bds_Kho[Bds_Kho.Position])["MAKHO"].ToString();
            PhieuXuat.makho = ((DataRowView)Bds_Kho[Bds_Kho.Position])["MAKHO"].ToString();
            PhieuNhap.makho = ((DataRowView)Bds_Kho[Bds_Kho.Position])["MAKHO"].ToString();
            this.Close();
        }

        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}