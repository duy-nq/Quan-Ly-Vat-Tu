using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Vat_Tu
{
    public partial class FormTaoLogin : DevExpress.XtraEditors.XtraForm
    {
        public FormTaoLogin()
        {
            InitializeComponent();
        }

        private void FormTaoLogin_Load(object sender, EventArgs e)
        {
            Txt_MaNV.Text = TaoLogin.manv;
            Txt_MaNV.Enabled = false;

            if (Program.main_group == "CONGTY")
            {
                Rd_CongTy.Enabled = Rd_ChiNhanh.Enabled = Rd_User.Enabled = false;
                Rd_CongTy.Checked = true;
            }
            else
            {
                Rd_CongTy.Enabled = false;
                Rd_ChiNhanh.Enabled = Rd_User.Enabled = true;
                Rd_ChiNhanh.Checked = true;
            }
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            String vaiTro = "";

            if (!KiemTraNhapLieu()) { return; }

            if (Program.connection.State == ConnectionState.Closed)
            {
                Program.connection.Open();
            }

            if (Rd_CongTy.Checked) vaiTro = "CONGTY";
            else if (Rd_ChiNhanh.Checked) vaiTro = "CHINHANH";
            else if (Rd_User.Checked) vaiTro = "USER";

            try
            {
                String Sql_Query = "EXEC SP_TaoTaiKhoan '" + Txt_LoginName.Text + "', '" + Txt_Password.Text + "', '" + Txt_MaNV.Text + "', '" + vaiTro + "'";

                SqlCommand command = new SqlCommand(Sql_Query, Program.connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader == null)
                {
                    return;
                }

                MessageBox.Show("Đăng ký tài khoản thành công\nLogin: " + Txt_LoginName.Text + "\nPassword: " + Txt_Password.Text +
                    "\nMã nhân viên: " + Txt_MaNV.Text + "\nVai trò: " + vaiTro, "", MessageBoxButtons.OK);
                reader.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo tài khoản\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void Btn_QuayVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool KiemTraNhapLieu()
        {
            if (Txt_LoginName.Text.Trim() == "")
            {
                MessageBox.Show("Tên Login không được để trống!", "", MessageBoxButtons.OK);
                Txt_MaNV.Focus();
                return false;
            }
            if (Txt_Password.Text.Trim() == "")
            {
                MessageBox.Show("Password không được để trống!", "", MessageBoxButtons.OK);
                Txt_MaNV.Focus();
                return false;
            }
            return true;
        }
    }
}