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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Quan_Ly_Vat_Tu
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();

            Text = "Mã NV: " + Program.main_maNV + " - " + "Họ tên: " + Program.main_hoTen + " - " + "Nhóm: " + Program.main_group;
            Console.WriteLine(Text);
        }

        private new Form IsActive(Type ftype, FormCollection forms)
        {
            foreach (Form f in forms)
            {
                if (f.GetType() == ftype) return f;
            }
            return null;
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                {
                    return f;
                }
            return null;
        }

        public void HienThiMenu()
        {
            Status_MaNV.Text = "Mã NV: " + Program.main_maNV;
            Status_HoTenNV.Text = "Họ tên NV: " + Program.main_hoTen;
            Status_Nhom.Text = "Nhóm: " + Program.main_group;
        }

        private void Btn_NhanVien_Click(object sender, EventArgs e)
        {
            Form f = this.CheckExists(typeof(NhanVien));
            if (f != null) { f.Activate(); }
            else
            {
                NhanVien frm = new NhanVien();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void Btn_VatTu_Click(object sender, EventArgs e)
        {
            Form f = this.CheckExists(typeof(VatTu));
            if (f != null) { f.Activate(); }
            else
            {
                VatTu frm = new VatTu();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void Btn_TaoLogin_Click(object sender, EventArgs e)
        {
            Form f = this.CheckExists(typeof(TaoLogin));
            if (f != null) { f.Activate(); }
            else
            {
                TaoLogin frm = new TaoLogin();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void XoaForm()
        {
            foreach(Form f in this.MdiChildren) { f.Dispose(); }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Hide();

            Program.connection.Close();

            Program.username = Program.username_DN = "";
            Program.password = Program.password_DN = "";

            DangNhap loginForm = new DangNhap();

            loginForm.ShowDialog();
        }

        private void Btn_DDH_Click(object sender, EventArgs e)
        {
            Form f = this.CheckExists(typeof(DonDatHang));
            if (f != null) { f.Activate(); }
            else
            {
                DonDatHang frm = new DonDatHang();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Group_BaoCao_Paint(object sender, PaintEventArgs e)
        {

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

        private void Btn_PhieuNhap_Click(object sender, EventArgs e)
        {
            Form form = isActive(typeof(PhieuNhap));
            if (form == null)
            {
                PhieuNhap fnv = new PhieuNhap
                {
                    MdiParent = this
                };
                fnv.Show();
            }
            else form.Activate();
        }

        private void Btn_PhieuXuat_Click(object sender, EventArgs e)
        {
            Form form = isActive(typeof(PhieuXuat));
            if (form == null)
            {
                PhieuXuat fnv = new PhieuXuat
                {
                    MdiParent = this
                };
                fnv.Show();
            }
            else form.Activate();
        }
    }
}