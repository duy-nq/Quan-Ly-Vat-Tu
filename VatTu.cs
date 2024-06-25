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
    public partial class VatTu : DevExpress.XtraEditors.XtraForm
    {
        int vitri = 0;

        public VatTu()
        {
            InitializeComponent();
        }

        private void VatTu_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.VATTUTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.VATTUTableAdapter.Fill(this.DS.Vattu);
            this.CTPNTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.CTPNTableAdapter.Fill(this.DS.CTPN);
            this.CTPXTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.CTPXTableAdapter.Fill(this.DS.CTPX);
            this.CTDDHTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.CTDDHTableAdapter.Fill(this.DS.CTDDH);

            if (Program.main_group == "CONGTY")
            {
                Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
                Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
                Panel_NhapLieu.Enabled = false;
            } else
            {
                Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
                Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = Panel_NhapLieu.Enabled = false;
            }
        }

        private void Btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = Bds_VatTu.Position;
            Panel_NhapLieu.Enabled = true;

            Bds_VatTu.AddNew();
            SpinEdit_SoLuongTon.Value = 1;
            Txt_MaVT.Enabled = true;

            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = false;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = true;
            Gc_VatTu.Enabled = false;
        }

        private void Btn_Sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = Bds_VatTu.Position;

            Txt_MaVT.Enabled = false;
            Gc_VatTu.Enabled = false;
            Panel_NhapLieu.Enabled = true;
            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = false;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = true;
        }

        private void Btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String mavt = ((DataRowView)Bds_VatTu[Bds_VatTu.Position])["MAVT"].ToString();
            //String mavt_str = ((DataRowView)Bds_VatTu[Bds_VatTu.Position])["MAVT"].ToString();

            if (Bds_CTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã có trong phiếu nhập", "", MessageBoxButtons.OK);
                return;
            }
            if (Bds_CTPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã có trong phiếu xuất", "", MessageBoxButtons.OK);
                return;
            }
            if (Bds_CTDDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã có trong đơn đặt hàng", "", MessageBoxButtons.OK);
                return;
            }

            if (Program.connection.State == ConnectionState.Closed)
            {
                Program.connection.Open();
            }

            String Sql_Query =
                "DECLARE @res INT " +
                "EXEC @res = SP_TimVatTuChiNhanhKhac '" + mavt + "' " +
                "SELECT 'Value' = @res";
            SqlCommand command = new SqlCommand(Sql_Query, Program.connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows && reader.Read())
            {
                int result = reader.GetInt32(0);
                if (!reader.IsDBNull(0) && result == 1)
                {
                    MessageBox.Show("Không thể xóa vật tư này do đã được lập phiếu ở chi nhánh khác", "", MessageBoxButtons.OK);
                    reader.Close();
                    return;
                }
            }

            Program.connection.Close();

            if (MessageBox.Show("Bạn thật sự muốn xóa vật tư này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    //mavt = ((DataRowView)Bds_VatTu[Bds_VatTu.Position])["MAVT"].ToString();
                    Bds_VatTu.RemoveCurrent();
                    this.VATTUTableAdapter.Connection.ConnectionString = Program.connection_string;
                    this.VATTUTableAdapter.Update(this.DS.Vattu);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa vật tư. Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.VATTUTableAdapter.Fill(this.DS.Vattu);
                    Bds_VatTu.Position = Bds_VatTu.Find("MAVT", mavt);
                    return;
                }
            }
            if (Bds_VatTu.Count == 0) Btn_Xoa.Enabled = false;
        }

        private bool KiemTraNhapLieu()
        {
            if (Txt_MaVT.Text.Trim() == "")
            {
                MessageBox.Show("Mã vật tư không được thiếu!", "", MessageBoxButtons.OK);
                Txt_MaVT.Focus();
                return false;
            }
            if (Txt_TenVT.Text.Trim() == "")
            {
                MessageBox.Show("Tên vật tư không được thiếu!", "", MessageBoxButtons.OK);
                Txt_TenVT.Focus();
                return false;
            }
            if (Txt_DVT.Text.Trim() == "")
            {
                MessageBox.Show("Đơn vị tính không được thiếu!", "", MessageBoxButtons.OK);
                Txt_DVT.Focus();
                return false;
            }
            if (SpinEdit_SoLuongTon.Value < 0)
            {
                MessageBox.Show("Số lượng vật tư không được nhỏ hơn 0!", "", MessageBoxButtons.OK);
                SpinEdit_SoLuongTon.Focus();
                return false;
            }
            return true;
        }

        private void Btn_Ghi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraNhapLieu() == false) return;

            try
            {
                // Kết thúc quá trình hiệu chỉnh, hoàn tất ghi dữ liệu vào BindingSource
                Bds_VatTu.EndEdit();
                // Đưa thông tin lên lưới
                Bds_VatTu.ResetCurrentItem();
                this.VATTUTableAdapter.Connection.ConnectionString = Program.connection_string;
                this.VATTUTableAdapter.Update(this.DS.Vattu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi vật tư!\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            Gc_VatTu.Enabled = true;
            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = true;
            Panel_NhapLieu.Enabled = false;
        }

        private void Btn_PhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Bds_VatTu.CancelEdit();
            if (Btn_Them.Enabled == false) Bds_VatTu.Position = vitri;

            Gc_VatTu.Enabled = true;
            Panel_NhapLieu.Enabled = false;
            Btn_Them.Enabled = Btn_Sua.Enabled = Btn_Xoa.Enabled = Btn_LamMoi.Enabled = Btn_Thoat.Enabled = true;
            Btn_Ghi.Enabled = Btn_PhucHoi.Enabled = false;
        }

        private void Btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.VATTUTableAdapter.Fill(this.DS.Vattu);
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
    }
}