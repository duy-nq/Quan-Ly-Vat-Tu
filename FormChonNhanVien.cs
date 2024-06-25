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

namespace Quan_Ly_Vat_Tu.SubForm
{
    public partial class FormChonNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public FormChonNhanVien()
        {
            InitializeComponent();
        }

        private void FormChonNhanVien_Load(object sender, EventArgs e)
        {
            this.NHANVIENTableAdapter.Fill(this.DS.View_NhanVienDangThuocChiNhanhNay);
        }

        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            DonDatHang.manv = ((DataRowView)Bds_NhanVien[Bds_NhanVien.Position])["MANV"].ToString();
            this.Close();
        }
    }
}