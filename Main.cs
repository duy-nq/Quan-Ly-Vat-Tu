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
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Hide();

            Program.connection.Close();

            DangNhap loginForm = new DangNhap();

            loginForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Btn_Kho_Click(object sender, EventArgs e)
        {

        }
    }
}