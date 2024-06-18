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
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (Program.connection.State == ConnectionState.Closed)
            {
                Program.connection.Open();
            }

            try
            {
                String Sql_Query = "EXEC SP_TaoTaiKhoan '" + Txt_LoginName.Text + "', '" + Txt_Password.Text + "', '" + Txt_MaNV.Text + "', '" + Program.main_group + "'";

                Console.WriteLine(Txt_LoginName.Text);
                Console.WriteLine(Txt_Password.Text);
                Console.WriteLine(Txt_MaNV.Text);
                Console.WriteLine(Program.main_group);
                Console.WriteLine(Program.connection.ConnectionString);

                SqlCommand command = new SqlCommand(Sql_Query, Program.connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader == null)
                {
                    return;
                }

                MessageBox.Show("Đăng ký tài khoản thành công\nLogin: " + Txt_LoginName.Text + "\nPassword: " + Txt_Password.Text +
                    "\nMã nhân viên: " + Txt_MaNV.Text + "\nVai trò: " + Program.main_group, "", MessageBoxButtons.OK);
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
    }
}