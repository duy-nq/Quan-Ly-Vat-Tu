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
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();

            Text = "Mã NV: " + Program.main_maNV + " - " + "Họ tên: " + Program.main_hoTen + " - " + "Nhóm: " + Program.main_group;
            Console.WriteLine(Text);
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

        private void XoaForm()
        {
            foreach(Form f in this.MdiChildren) { f.Dispose(); }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.XoaForm();
            this.Close();
            if (Program.connection.State == ConnectionState.Open)
            {
                Program.connection.Close();
            }

            Form f = this.CheckExists(typeof(DangNhap));
            if (f != null) { f.Activate(); }
            else
            {
                DangNhap frm = new DangNhap();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}