using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraBars;
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
using static DevExpress.Xpo.Helpers.CommandChannelHelper;

namespace Quan_Ly_Vat_Tu
{
    public partial class NhanVien : DevExpress.XtraEditors.XtraForm
    {
        String macn = "";
        int vitri = 0;
        bool dangThem = false;

        public static String manv = "";
        public static String trangThaiXoa;

        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.NHANVIENTableAdapter.Fill(this.DS.NhanVien);
            this.DATHANGTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.DATHANGTableAdapter.Fill(this.DS.DatHang);
            this.PHIEUNHAPTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.PHIEUNHAPTableAdapter.Fill(this.DS.PhieuNhap);
            this.PHIEUXUATTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.PHIEUXUATTableAdapter.Fill(this.DS.PhieuXuat);

            macn = ((DataRowView)Bds_NhanVien[0])["MACN"].ToString();

            foreach (DataRow dr in Program.DT_ChiNhanh.Rows)
            {
                Cmb_ChiNhanh.Properties.Items.Add(dr["TenCN"]);
            }

            Cmb_ChiNhanh.SelectedIndex = Program.main_chinhanh;
            Cmb_ChiNhanh.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            if (Program.main_group == "CONGTY")
            {
                Cmb_ChiNhanh.Enabled = true;
                Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = Btn_ChuyenChiNhanh.Enabled = false;
                Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
                Gc_NhanVien.Enabled = true;
                Panel_NhapLieu.Enabled = false;
            } else
            {
                Cmb_ChiNhanh.Enabled = false;
                Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_ChuyenChiNhanh.Enabled = true;
                Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
                Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = Panel_NhapLieu.Enabled = false;
                Gc_NhanVien.Enabled = true; 
            }
        }

        private void Btn_Them_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            dangThem = true;
            vitri = Bds_NhanVien.Position;
            Panel_NhapLieu.Enabled = true;

            Bds_NhanVien.AddNew();
            Txt_MaNV.Enabled = true;
            Txt_MaCN.Text = macn;
            Txt_MaCN.Enabled = false;
            Date_NgaySinh.EditValue = "";

            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = false;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = true;
            Gc_NhanVien.Enabled = false;
        }

        private void Btn_Sua_ItemClick(object sender, ItemClickEventArgs e)
        {
            vitri = Bds_NhanVien.Position;

            Txt_MaNV.Enabled = false;
            Gc_NhanVien.Enabled = false;
            Panel_NhapLieu.Enabled = true;
            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = false;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = true;
        }

        private void Btn_Xoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            Int32 manv = 0;
            if (Bds_DatHang.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập đơn hàng", "", MessageBoxButtons.OK);
                return;
            }
            if (Bds_PhieuNhap.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu nhập", "", MessageBoxButtons.OK);
                return;
            }
            if (Bds_PhieuXuat.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu xuất", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn thật sự muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    manv = int.Parse(((DataRowView)Bds_NhanVien[Bds_NhanVien.Position])["MANV"].ToString());
                    Bds_NhanVien.RemoveCurrent(); // xóa trên máy hiện tại
                    this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connection_string;
                    this.NHANVIENTableAdapter.Update(this.DS.NhanVien); // xóa trên DB
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa nhân viên. Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.NHANVIENTableAdapter.Fill(this.DS.NhanVien); // có thể xảy ra lỗi vẫn tồn tại trên DB nhưng k thấy trên giao diện
                    Bds_NhanVien.Position = Bds_NhanVien.Find("MANV", manv); // lệnh tìm vị trí, xảy ra lỗi ở nv nào thì con trỏ đứng ở nhân viên đó
                    return;
                }
            }

            if (Bds_NhanVien.Count == 0) Btn_Xoa.Enabled = false; // ds nhân viên rỗng 
        }

        private bool KiemTraNhapLieu()
        {
            if (Txt_MaNV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                Txt_MaNV.Focus();
                return false;
            }
            if (Txt_Ho.Text.Trim() == "")
            {
                MessageBox.Show("Họ nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                Txt_Ho.Focus();
                return false;
            }
            if (Txt_Ten.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                Txt_Ten.Focus();
                return false;
            }
            if (Txt_CMND.Text.Trim() == "")
            {
                MessageBox.Show("Số CMND không được thiếu!", "", MessageBoxButtons.OK);
                Txt_CMND.Focus();
                return false;
            }
            if (Txt_Luong.Text.Trim() == "")
            {
                MessageBox.Show("Lương nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                Txt_Luong.Focus();
                return false;
            }
            if (Txt_DiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                Txt_DiaChi.Focus();
                return false;
            }
            if (float.Parse(Txt_Luong.Text.Trim().ToString()) < 4000000)
            {
                MessageBox.Show("Lương nhân viên phải lớn hơn 4000000 VND!", "", MessageBoxButtons.OK);
                Txt_Luong.Focus();
                return false;
            }
            return true;
        }

        private void Btn_Ghi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!KiemTraNhapLieu()) { return; }

            if (Program.connection.State == ConnectionState.Closed)
            {
                Program.connection.Open();
            }

            String Sql_Query =
                "EXEC QLVT.dbo.SP_KiemTraNhanVien '" + Txt_MaNV.Text.Trim() + "'";
            SqlCommand command = new SqlCommand(Sql_Query, Program.connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows && reader.Read())
            {
                if (!reader.IsDBNull(0) && dangThem == true)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "", MessageBoxButtons.OK);
                    Txt_MaNV.Focus();
                    reader.Close();
                    return;
                }
            }

            Program.connection.Close();

            try
            {
                // Kết thúc quá trình hiệu chỉnh, hoàn tất ghi dữ liệu vào BindingSource
                Bds_NhanVien.EndEdit();
                // Đưa thông tin lên lưới
                Bds_NhanVien.ResetCurrentItem();
                this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.NHANVIENTableAdapter.Update(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên!\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            dangThem = false;
            Gc_NhanVien.Enabled = true;
            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
            Panel_NhapLieu.Enabled = false;
        }

        private void Btn_PhucHoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Bds_NhanVien.CancelEdit();
            if (Btn_Them.Enabled == false && dangThem == true)
            {
                Bds_NhanVien.RemoveCurrent();
                Bds_NhanVien.Position = vitri;
                dangThem = false;
            }

            Gc_NhanVien.Enabled = true;
            Panel_NhapLieu.Enabled = false;
            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_Ghi.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
            Btn_PhucHoi.Enabled = false;
        }

        private void Btn_LamMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.NHANVIENTableAdapter.Fill(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void Btn_Thoat_ItemClick(object sender, ItemClickEventArgs e)
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
            } else
            {
                Program.username = Program.username_DN;
                Program.password = Program.password_DN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            } else
            {
                this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.NHANVIENTableAdapter.Fill(this.DS.NhanVien);
                this.PHIEUXUATTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.PHIEUXUATTableAdapter.Fill(this.DS.PhieuXuat);
                this.PHIEUNHAPTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.PHIEUNHAPTableAdapter.Fill(this.DS.PhieuNhap);

                macn = ((DataRowView)Bds_NhanVien[0])["MACN"].ToString();
            }
        }

        private void Btn_ChuyenChiNhanh_Click(object sender, EventArgs e)
        {
            manv = ((DataRowView)Bds_NhanVien[Bds_NhanVien.Position])["MANV"].ToString();
            trangThaiXoa = ((DataRowView)Bds_NhanVien[Bds_NhanVien.Position])["TrangThaiXoa"].ToString();

            Form f = this.CheckExists(typeof(FormChuyenChiNhanh));
            if (f != null) { f.Activate(); }
            else
            {
                FormChuyenChiNhanh frm = new FormChuyenChiNhanh();
                frm.ShowDialog();
            }
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