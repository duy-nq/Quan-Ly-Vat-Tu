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
    public partial class Kho : DevExpress.XtraEditors.XtraForm
    {
        String macn = "";
        int vitri = 0;
        bool dangThem = false;

        public Kho()
        {
            InitializeComponent();
        }

        private void Kho_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.KHOTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.KHOTableAdapter.Fill(this.DS.Kho);
            this.DATHANGTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.DATHANGTableAdapter.Fill(this.DS.DatHang);
            this.PHIEUNHAPTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.PHIEUNHAPTableAdapter.Fill(this.DS.PhieuNhap);
            this.PHIEUXUATTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.PHIEUXUATTableAdapter.Fill(this.DS.PhieuXuat);

            macn = ((DataRowView)Bds_Kho[0])["MACN"].ToString();

            foreach (DataRow dr in Program.DT_ChiNhanh.Rows)
            {
                Cmb_ChiNhanh.Properties.Items.Add(dr["TenCN"]);
            }

            Cmb_ChiNhanh.SelectedIndex = Program.main_chinhanh;
            Cmb_ChiNhanh.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            if (Program.main_group == "CONGTY")
            {
                Cmb_ChiNhanh.Enabled = true;
                Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
                Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
                Panel_NhapLieu.Enabled = false;
            }
            else
            {
                Cmb_ChiNhanh.Enabled = false;
                Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
                Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = Panel_NhapLieu.Enabled = false;
            }
        }

        private void Btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dangThem = true;
            vitri = Bds_Kho.Position;
            Panel_NhapLieu.Enabled = true;

            Bds_Kho.AddNew();
            Txt_MaKho.Enabled = true;
            Txt_MaCN.Text = macn;
            Txt_MaCN.Enabled = false;

            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = false;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = true;
            Gc_Kho.Enabled = false;
        }

        private void Btn_Sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = Bds_Kho.Position;

            Txt_MaKho.Enabled = Txt_MaCN.Enabled = false;
            Gc_Kho.Enabled = false;
            Panel_NhapLieu.Enabled = true;
            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = false;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = true;
        }

        private void Btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String makho = "";
            if (Bds_DatHang.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho hàng này vì đã lập đơn hàng", "", MessageBoxButtons.OK);
                return;
            }
            if (Bds_PhieuNhap.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho hàng này vì đã lập phiếu nhập", "", MessageBoxButtons.OK);
                return;
            }
            if (Bds_PhieuXuat.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho hàng này vì đã lập phiếu xuất", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn thật sự muốn xóa kho hàng này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    makho = ((DataRowView)Bds_Kho[Bds_Kho.Position])["MAKHO"].ToString();
                    Bds_Kho.RemoveCurrent(); // xóa trên máy hiện tại
                    this.KHOTableAdapter.Connection.ConnectionString = Program.connection_string;
                    this.KHOTableAdapter.Update(this.DS.Kho); // xóa trên DB
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa kho hàng. Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.KHOTableAdapter.Fill(this.DS.Kho); // có thể xảy ra lỗi vẫn tồn tại trên DB nhưng k thấy trên giao diện
                    Bds_Kho.Position = Bds_Kho.Find("MAKHO", makho); // lệnh tìm vị trí, xảy ra lỗi ở nv nào thì con trỏ đứng ở kho hàng đó
                    return;
                }
            }

            if (Bds_Kho.Count == 0) Btn_Xoa.Enabled = false; // ds kho hàng rỗng 
        }

        private bool KiemTraNhapLieu()
        {
            if (Txt_MaKho.Text.Trim() == "")
            {
                MessageBox.Show("Mã kho không được thiếu!", "", MessageBoxButtons.OK);
                Txt_MaKho.Focus();
                return false;
            }
            if (Txt_TenKho.Text.Trim() == "")
            {
                MessageBox.Show("Tên kho không được thiếu!", "", MessageBoxButtons.OK);
                Txt_TenKho.Focus();
                return false;
            }
            if (Txt_DiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ kho không được thiếu!", "", MessageBoxButtons.OK);
                Txt_DiaChi.Focus();
                return false;
            }
            return true;
        }

        private void Btn_Ghi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!KiemTraNhapLieu()) { return; }

            if (Program.connection.State == ConnectionState.Closed)
            {
                Program.connection.Open();
            }

            String Sql_Query =
                "EXEC QLVT.dbo.SP_KiemTraKho '" + Txt_MaKho.Text.Trim() + "'";
            SqlCommand command = new SqlCommand(Sql_Query, Program.connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows && reader.Read())
            {
                if (!reader.IsDBNull(0) && dangThem == true)
                {
                    MessageBox.Show("Mã kho đã tồn tại!", "", MessageBoxButtons.OK);
                    Txt_MaKho.Focus();
                    reader.Close();
                    return;
                }
            }

            Program.connection.Close();

            try
            {
                // Kết thúc quá trình hiệu chỉnh, hoàn tất ghi dữ liệu vào BindingSource
                Bds_Kho.EndEdit();
                // Đưa thông tin lên lưới
                Bds_Kho.ResetCurrentItem();
                this.KHOTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.KHOTableAdapter.Update(this.DS.Kho);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi kho!\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            dangThem = false;
            Gc_Kho.Enabled = true;
            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
            Panel_NhapLieu.Enabled = false;
        }

        private void Btn_PhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Bds_Kho.CancelEdit();
            if (Btn_Them.Enabled == false && dangThem == true)
            {
                Bds_Kho.RemoveCurrent();
                Bds_Kho.Position = vitri;
                dangThem = false;
            }

            Gc_Kho.Enabled = true;
            Panel_NhapLieu.Enabled = false;
            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
        }

        private void Btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.KHOTableAdapter.Fill(this.DS.Kho);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void Btn_Thoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
                this.KHOTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.KHOTableAdapter.Fill(this.DS.Kho);
                this.DATHANGTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.DATHANGTableAdapter.Fill(this.DS.DatHang);
                this.PHIEUNHAPTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.PHIEUNHAPTableAdapter.Fill(this.DS.PhieuNhap);
                this.PHIEUXUATTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.PHIEUXUATTableAdapter.Fill(this.DS.PhieuXuat);

                macn = ((DataRowView)Bds_Kho[0])["MACN"].ToString();
            }
        }
    }
}