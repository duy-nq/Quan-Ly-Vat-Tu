using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Quan_Ly_Vat_Tu.SubForm;
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
    public partial class DonDatHang : DevExpress.XtraEditors.XtraForm
    {
        public static string manv = "";
        public static string makho = "";
        public static string mavt = "";
        public static string masoddh = "";
        int vitri = 0;
        BindingSource bds = null;
        String chedo = "";
        bool dangThem = false;

        public DonDatHang()
        {
            InitializeComponent();
        }

        private void DonDatHang_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.DATHANGTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.DATHANGTableAdapter.Fill(this.DS.DatHang);
            this.CTDDHTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.CTDDHTableAdapter.Fill(this.DS.CTDDH);
            this.PHIEUNHAPTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.PHIEUNHAPTableAdapter.Fill(this.DS.PhieuNhap);

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
                Cmb_ChiNhanh.Enabled = false;
            }

            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
            Btn_ChonCheDo.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
            Group_DonDatHang.Enabled = Group_CTDDH.Enabled = false;
            Gc_DatHang.Enabled = Gc_CTDDH.Enabled = false;
        }

        private void Btn_DatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Btn_ChonCheDo.Links[0].Caption = "ĐƠN ĐẶT HÀNG";
            Btn_ChonCheDo.ImageOptions.SvgImage = Btn_DatHang.ImageOptions.SvgImage;

            chedo = "DATHANG";
            bds = Bds_DatHang;
            Gc_DatHang.Enabled = true;
            Gc_CTDDH.Enabled = false;

            if (Program.main_group == "CONGTY")
            {
                Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
                Btn_ChonCheDo.Enabled = true;
            }
            else
            {
                Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_ChonCheDo.Enabled = true;
                Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
            }
        }

        private void Btn_CTDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Btn_ChonCheDo.Links[0].Caption = "CHI TIẾT ĐƠN HÀNG";
            Btn_ChonCheDo.ImageOptions.SvgImage = Btn_CTDDH.ImageOptions.SvgImage;

            chedo = "CTDDH";
            bds = Bds_CTDDH;
            Gc_DatHang.Enabled = true;
            Gc_CTDDH.Enabled = true;

            if (Program.main_group == "CONGTY")
            {
                Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
                Btn_ChonCheDo.Enabled = true;
            }
            else
            {
                Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_ChonCheDo.Enabled = true;
                Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
            }
        }

        private void Btn_ChonNhanVien_Click(object sender, EventArgs e)
        {
            Form f = this.CheckExists(typeof(FormChonNhanVien));
            if (f != null) { f.Activate(); }
            else
            {
                FormChonNhanVien frm = new FormChonNhanVien();
                frm.ShowDialog();
            }

            Txt_MaNV.Text = manv;
        }

        private void Btn_ChonKhoHang_Click(object sender, EventArgs e)
        {
            Form f = this.CheckExists(typeof(FormChonKhoHang));
            if (f != null) { f.Activate(); }
            else
            {
                FormChonKhoHang frm = new FormChonKhoHang();
                frm.ShowDialog();
            }

            Txt_MaKho.Text = makho;
        }

        private void Btn_ChonVatTu_Click(object sender, EventArgs e)
        {
            Form f = this.CheckExists(typeof(FormChonVatTu));
            if (f != null) { f.Activate(); }
            else
            {
                FormChonVatTu frm = new FormChonVatTu();
                frm.ShowDialog();
            }

            Txt_MaVT.Text = mavt;
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
                this.DATHANGTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.DATHANGTableAdapter.Fill(this.DS.DatHang);
                this.CTDDHTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.CTDDHTableAdapter.Fill(this.DS.CTDDH);
            }
        }

        private void Btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dangThem = true;
            vitri = bds.Position;
            bds.AddNew();

            if (chedo == "DATHANG")
            {
                Group_DonDatHang.Enabled = true;
                Txt_MaNV.Enabled = Txt_MaKho.Enabled = false;
                Date_Ngay.EditValue = "";
            } else if (chedo == "CTDDH")
            {
                masoddh = ((DataRowView)Bds_DatHang[Bds_DatHang.Position])["MasoDDH"].ToString();

                Group_CTDDH.Enabled = true;
                Txt_CTDH_MaSoDDH.Text = masoddh;
                Txt_CTDH_MaSoDDH.Enabled = Txt_MaVT.Enabled = false;
            }

            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = Btn_ChonCheDo.Enabled = false;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = true;
            Gc_DatHang.Enabled = false;
        }

        private void Btn_Sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bds.Position;
            if (chedo == "DATHANG")
            {
                Group_DonDatHang.Enabled = true;
                Txt_MaSoDDH.Enabled = Txt_MaNV.Enabled = Txt_MaKho.Enabled = false;
            } else if (chedo == "CTDDH")
            {
                Group_CTDDH.Enabled = true;
                Txt_CTDH_MaSoDDH.Enabled = Txt_MaVT.Enabled = false;
            }
            

            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = Btn_ChonCheDo.Enabled = false;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = true;
            Gc_DatHang.Enabled = false;
        }

        private void Btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String maSoDDH = "";
            if (chedo == "DATHANG")
            {
                if (Bds_CTDDH.Count > 0)
                {
                    MessageBox.Show("Đơn đặt hàng đã được lập chi tiết đơn hàng, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }
                if (Bds_PhieuNhap.Count > 0)
                {
                    MessageBox.Show("Đơn đặt hàng đã được lập phiếu nhập, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }
                if (MessageBox.Show("Bạn thật sự muốn xóa đơn đặt hàng này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        maSoDDH = ((DataRowView)bds[bds.Position])["MasoDDH"].ToString();
                        bds.RemoveCurrent();
                        this.DATHANGTableAdapter.Connection.ConnectionString = Program.connection_string;
                        this.DATHANGTableAdapter.Update(this.DS.DatHang);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa đơn đặt hàng. Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                        this.DATHANGTableAdapter.Fill(this.DS.DatHang);
                        bds.Position = bds.Find("MasoDDH", maSoDDH);
                        return;
                    }
                }
            }
            else if (chedo == "CTDDH")
            {
                if (MessageBox.Show("Bạn thật sự muốn xóa chi tiết đơn hàng này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        maSoDDH = ((DataRowView)bds[bds.Position])["MasoDDH"].ToString();
                        bds.RemoveCurrent();
                        this.CTDDHTableAdapter.Connection.ConnectionString = Program.connection_string;
                        this.CTDDHTableAdapter.Update(this.DS.CTDDH);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa chi tiết đơn hàng. Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                        this.CTDDHTableAdapter.Fill(this.DS.CTDDH);
                        bds.Position = bds.Find("MasoDDH", maSoDDH);
                        return;
                    }
                }
            }
            

            if (bds.Count == 0) Btn_Xoa.Enabled = false;
        }

        private bool KiemTraNhapLieu()
        {
            if (bds == Bds_DatHang)
            {
                if (Txt_MaSoDDH.Text.Trim() == "")
                {
                    MessageBox.Show("Mã đơn đặt hàng không được thiếu!", "", MessageBoxButtons.OK);
                    Txt_MaSoDDH.Focus();
                    return false;
                }
                if (Txt_MaNV.Text.Trim() == "")
                {
                    MessageBox.Show("Mã nhân viên không được thiếu!\nHãy ấn nút CHỌN NHÂN VIÊN để chọn mã nhân viên", "", MessageBoxButtons.OK);
                    Txt_MaNV.Focus();
                    Btn_ChonNhanVien.Focus();
                    return false;
                }
                if (Txt_MaKho.Text.Trim() == "")
                {
                    MessageBox.Show("Mã kho không được thiếu!\nHãy ấn nút CHỌN KHO HÀNG để chọn mã kho", "", MessageBoxButtons.OK);
                    Txt_MaKho.Focus();
                    Btn_ChonKhoHang.Focus();
                    return false;
                }
                if (Txt_NhaCC.Text.Trim() == "")
                {
                    MessageBox.Show("Nhà cung cấp không được thiếu!", "", MessageBoxButtons.OK);
                    Txt_NhaCC.Focus();
                    return false;
                }
            }
            else if (bds == Bds_CTDDH)
            {
                if (Txt_CTDH_MaSoDDH.Text.Trim() == "")
                {
                    MessageBox.Show("Mã đơn đặt hàng không được thiếu!", "", MessageBoxButtons.OK);
                    Txt_CTDH_MaSoDDH.Focus();
                    return false;
                }
                if (Txt_MaVT.Text.Trim() == "")
                {
                    MessageBox.Show("Mã nhân viên không được thiếu!\nHãy ấn nút CHỌN VẬT TƯ để chọn mã vật tư", "", MessageBoxButtons.OK);
                    Txt_MaVT.Focus();
                    Btn_ChonVatTu.Focus();
                    return false;
                }
                if (Spin_SoLuong.Value <= 0)
                {
                    MessageBox.Show("Số lượng vật tư trong đơn đặt phải lớn hơn 0!", "", MessageBoxButtons.OK);
                    Spin_SoLuong.Focus();
                    return false;
                }
                if (Txt_DonGia.Text.Trim() == "")
                {
                    MessageBox.Show("Đơn giá không được thiếu!", "", MessageBoxButtons.OK);
                    Txt_DonGia.Focus();
                    return false;
                }
                if (float.Parse(Txt_DonGia.Text.Trim().ToString()) < 0)
                {
                    MessageBox.Show("Đơn giá phải lớn hơn 0 VND!", "", MessageBoxButtons.OK);
                    Txt_DonGia.Focus();
                    return false;
                }
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

            if (chedo == "DATHANG")
            {
                String Sql_Query = "EXEC QLVT.dbo.SP_KiemTraDonDatHang '" + Txt_MaSoDDH.Text.Trim() + "'";
                SqlCommand command = new SqlCommand(Sql_Query, Program.connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    if (!reader.IsDBNull(0) && dangThem == true)
                    {
                        MessageBox.Show("Mã đơn hàng đã tồn tại!", "", MessageBoxButtons.OK);
                        Txt_MaSoDDH.Focus();
                        reader.Close();
                        return;
                    }
                }

                Program.connection.Close();

                try
                {
                    bds.EndEdit();
                    bds.ResetCurrentItem();
                    this.DATHANGTableAdapter.Connection.ConnectionString = Program.connection_string;
                    this.DATHANGTableAdapter.Update(this.DS.DatHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi đơn đặt hàng!\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
            else if (chedo == "CTDDH")
            {
                try
                {
                    if (dangThem == true)
                    {
                        String Sql_Query = "EXEC QLVT.dbo.SP_ThemChiTietDonHang '" + Txt_CTDH_MaSoDDH.Text.Trim() + "', '" + Txt_MaVT.Text.Trim() + "', '"
                        + Spin_SoLuong.Value + "', '" + Txt_DonGia.Text.Trim() + "'";
                        SqlCommand command = new SqlCommand(Sql_Query, Program.connection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader == null) return;
                        reader.Close();

                        bds.EndEdit();
                        bds.ResetCurrentItem();
                        this.CTDDHTableAdapter.Connection.ConnectionString = Program.connection_string;
                        this.CTDDHTableAdapter.Fill(this.DS.CTDDH);

                        MessageBox.Show("Thêm chi tiết đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                    else 
                    {
                        bds.EndEdit();
                        bds.ResetCurrentItem();
                        this.CTDDHTableAdapter.Connection.ConnectionString = Program.connection_string;
                        this.CTDDHTableAdapter.Update(this.DS.CTDDH);

                        MessageBox.Show("Sửa chi tiết đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết đơn hàng!\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;

                }
            }

            dangThem = false;
            Gc_DatHang.Enabled = true;
            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_ChonCheDo.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
            Group_DonDatHang.Enabled = Group_CTDDH.Enabled = false;
        }

        private void Btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (chedo == "DATHANG")
                {
                    this.DATHANGTableAdapter.Fill(this.DS.DatHang);
                }
                else if (chedo == "CTDDH")
                {
                    this.CTDDHTableAdapter.Fill(this.DS.CTDDH);
                }
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

        private void Btn_PhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bds.CancelEdit();
            if (Btn_Them.Enabled == false && dangThem == true)
            {
                bds.Position = vitri;
                dangThem = false;
            }

            if (chedo == "DATHANG")
            {
                Gc_DatHang.Enabled = true;
                Gc_CTDDH.Enabled = false;
            } else if (chedo == "CTDDH")
            {
                Gc_DatHang.Enabled = true;
                Gc_CTDDH.Enabled = true;
            }

            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_ChonCheDo.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
            Group_CTDDH.Enabled = Group_DonDatHang.Enabled = false;
        }
    }
}