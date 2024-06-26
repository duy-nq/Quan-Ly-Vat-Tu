using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class TaoLogin : DevExpress.XtraEditors.XtraForm
    {
        public static String manv = "";

        public TaoLogin()
        {
            InitializeComponent();
        }

        private void TaoLogin_Load(object sender, EventArgs e)
        {
            this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.NHANVIENTableAdapter.Fill(this.DS.View_NhanVienChuaCoLoginName);

            foreach (DataRow dr in Program.DT_ChiNhanh.Rows)
            {
                Cmb_ChiNhanh.Properties.Items.Add(dr["TenCN"]);
            }

            Cmb_ChiNhanh.SelectedIndex = Program.main_chinhanh;
            Cmb_ChiNhanh.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            if (Program.main_group == "CONGTY")
            {
                Cmb_ChiNhanh.Enabled = true;
            }
            else
            {
                if (Program.main_group == "USER") Btn_TaoLogin.Enabled = false;
                Cmb_ChiNhanh.Enabled = false;
            }

            Txt_MaNV.Enabled = Txt_Ho.Enabled = Txt_Ten.Enabled = Txt_MaCN.Enabled = false;
        }

        private void Cmb_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_ChiNhanh.Text.ToString() == "System.Data.DataRowView")
                return;
            Program.server_name = Program.Get_ServerName(Cmb_ChiNhanh.Text);

            if (Cmb_ChiNhanh.SelectedIndex != Program.main_chinhanh)
            {
                Program.username = Program.remote_username;
                Program.password = Program.remote_password;
            }
            else
            {
                Program.username = Program.username_DN;
                Program.password = Program.password_DN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            }
            else
            {
                this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.NHANVIENTableAdapter.Fill(this.DS.View_NhanVienChuaCoLoginName);
            }
        }

        private void Btn_LamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                this.NHANVIENTableAdapter.Fill(this.DS.View_NhanVienChuaCoLoginName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_TaoLogin_Click(object sender, EventArgs e)
        {
            if (Bds_NhanVien.Count == 0)
            {
                MessageBox.Show("Không còn nhân viên chưa có login name", "", MessageBoxButtons.OK);
                return;
            }

            manv = ((DataRowView)Bds_NhanVien[Bds_NhanVien.Position])["MANV"].ToString();

            if (((DataRowView)Bds_NhanVien[Bds_NhanVien.Position])["TrangThaiXoa"].ToString() == "True")
            {
                MessageBox.Show("Nhân viên này không tồn tại ở chi nhánh hiện tại", "", MessageBoxButtons.OK);
                return;
            }

            Form f = this.CheckExists(typeof(FormTaoLogin));
            if (f != null) { f.Activate(); }
            else
            {
                FormTaoLogin frm = new FormTaoLogin();
                frm.ShowDialog();
            }

            this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.NHANVIENTableAdapter.Fill(this.DS.View_NhanVienChuaCoLoginName);
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
    }
}