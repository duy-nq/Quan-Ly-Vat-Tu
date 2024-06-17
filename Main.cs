using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();

            Text = "Mã NV: " + Program.main_maNV + " - " + "Họ tên: " + Program.main_hoTen + " - " + "Nhóm: " + Program.main_group;
        }

        private Form isActive(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype) return f;
            }

            return null;
        }

        private void Btn_THNX_Click(object sender, EventArgs e)
        {
            Form form = isActive(typeof(UI_TongHopNhapXuat));
            if (form == null)
            {
                UI_TongHopNhapXuat fnv = new UI_TongHopNhapXuat
                {
                    MdiParent = this
                };
                fnv.Show();
            }
            else form.Activate();
        }

        private void Btn_CTNX_Click(object sender, EventArgs e)
        {
            Form form = isActive(typeof(UI_SoLuongTriGiaNhapXuat));
            if (form == null)
            {
                UI_SoLuongTriGiaNhapXuat fnv = new UI_SoLuongTriGiaNhapXuat
                {
                    MdiParent = this
                };
                fnv.Show();
            }
            else form.Activate();
        }

        private void Btn_DHCN_Click(object sender, EventArgs e)
        {
            Form form = isActive(typeof(UI_DonDatHangKhongPhieuNhap));
            if (form == null)
            {
                UI_DonDatHangKhongPhieuNhap fnv = new UI_DonDatHangKhongPhieuNhap
                {
                    MdiParent = this
                };
                fnv.Show();
            }
            else form.Activate();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Form form = isActive(typeof(UI_HoatDongNhanVien));
            if (form == null)
            {
                UI_HoatDongNhanVien fnv = new UI_HoatDongNhanVien
                {
                    MdiParent = this
                };
                fnv.Show();
            }
            else form.Activate();
        }

        private void Btn_DMVT_Click(object sender, EventArgs e)
        {
            XtraReport6 DMVT = new XtraReport6();

            ReportPrintTool print = new ReportPrintTool(DMVT);
            print.ShowPreviewDialog();
        }

        private void Btn_DSNV_Click(object sender, EventArgs e)
        {
            Form form = isActive(typeof(UI_DanhSachNhanVien));
            if (form == null)
            {
                UI_DanhSachNhanVien fnv = new UI_DanhSachNhanVien
                {
                    MdiParent = this
                };
                fnv.Show();
            }
            else form.Activate();
        }
    }
}