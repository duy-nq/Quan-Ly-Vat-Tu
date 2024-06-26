using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quan_Ly_Vat_Tu
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        public DangNhap()
        {
            try
            {
                InitializeComponent();
                if (Program.KetNoi_MainServer() == 1)
                {
                    Load_ChiNhanh();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi khi khởi tạo form Đăng Nhập: " + ex.Message);
                Console.WriteLine(ex);
            }
        }

        public void Load_ChiNhanh()
        {
            string Sql_Query = "SELECT TOP 2 * FROM QLVT_DATHANG.dbo.View_DSPM";
            
            if (Program.connection.State == ConnectionState.Closed)
            {
                Program.connection.Open();
            }

            if (Program.DT_ChiNhanh.Rows.Count == 0)
            {
                SqlDataAdapter da = new SqlDataAdapter(Sql_Query, Program.connection);
                da.Fill(Program.DT_ChiNhanh);
            }

            foreach (DataRow dr in Program.DT_ChiNhanh.Rows)
            {
                Cmb_ChiNhanh.Properties.Items.Add(dr["TenCN"]);
            }

            Cmb_ChiNhanh.SelectedIndex = 0;
            Cmb_ChiNhanh.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        private void Cmb_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.server_name = Program.Get_ServerName(Cmb_ChiNhanh.Text);
        }

        private new Form IsActive(Type ftype, FormCollection forms)
        {
            foreach (Form f in forms)
            {
                if (f.GetType() == ftype) return f;
            }
            return null;
        }

        private bool GetInfo()
        {
            if (Program.KetNoi() == 1)
            {
                string sql_query = "EXEC QLVT_DATHANG.dbo.SP_DANGNHAP '" + Program.username + "'";

                SqlCommand command = new SqlCommand(sql_query, Program.connection);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            Program.main_group = reader.GetString(2);
                            Program.main_hoTen = reader.GetString(1);
                            Program.main_maNV = reader.GetString(0);
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản\n" + ex.Message, "", MessageBoxButtons.OK);
                    return false;
                }
                finally
                {
                    Program.connection.Close();
                }

            }
            else return false;

            return true;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (Txt_MatKhau.Text.Trim() == "" || Txt_Username.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            Program.username = Txt_Username.Text;
            Program.password = Txt_MatKhau.Text;

            Program.username_DN = Program.username;
            Program.password_DN = Program.password;

            Program.main_chinhanh = Cmb_ChiNhanh.SelectedIndex;

            if (Program.server_name == null)
            {
                Program.server_name = Program.Get_ServerName(Cmb_ChiNhanh.Text);
            }

            if (!GetInfo()) return;

            Hide();
            Txt_Username.Text = Txt_MatKhau.Text = "";

            Form form = IsActive(typeof(Main), Application.OpenForms);
            form?.Close();
            Main mf = new Main();
            mf.HienThiMenu();
            mf.ShowDialog();

            Close();
        }

        private void Txt_Username_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Txt_MatKhau_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
