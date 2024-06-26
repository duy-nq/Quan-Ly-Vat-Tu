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
    public partial class PhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        public static string makho;
        
        int vitri = 0;
        bool dangThemMoi = false;
        private bool CTMode = true;

        public PhieuXuat()
        {
            InitializeComponent();
        }

        private void Dataset_Load()
        {
            dS.EnforceConstraints = false;
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.cTPXTableAdapter.Fill(this.dS.CTPX);
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.phieuXuatTableAdapter.Fill(this.dS.PhieuXuat);
        }

        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            Dataset_Load();

            Program.LoadChiNhanh(Cmb_ChiNhanh);

            if (Program.main_group == "CONGTY")
            {
                BtnThem.Enabled = BtnSua.Enabled = BtnXoa.Enabled = BtnReload.Enabled = false;
                BtnGhi.Enabled = BtnUndo.Enabled = simpleButton1.Enabled = false;

                Cmb_ChiNhanh.Enabled = true;
            }
            else
            {
                Program.LoadVatTu(Cmb_VatTu);
            }
        }

        private void phieuXuatBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phieuXuatBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void Cmb_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ConfigToRemoteServer(Cmb_ChiNhanh);

            if (Program.KetNoi() == 0) return;
            else Dataset_Load();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CTMode = !CTMode;
            if (CTMode)
            {
                cTPXGridControl.Visible = false;
            }
            else
            {
                cTPXGridControl.Visible = true;
            }

            MessageBox.Show("Chuyển sang chế độ " + (CTMode ? "phiếu xuất!" : "chi tiết phiếu xuất!"));
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            if (CTMode)
            {
                this.phieuXuatTableAdapter.Fill(this.dS.PhieuXuat);
            }
            else
            {
                this.cTPXTableAdapter.Fill(this.dS.CTPX);
            }
        }

        private void mAPXTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private String get_MaVT(String tenVT)
        {
            foreach (DataRow dr in Program.DT_DSVT.Rows)
            {
                if (dr["TENVT"].ToString().Trim() == tenVT.Trim())
                {
                    return dr["MAVT"].ToString();
                }
            }

            return "ERR-NOT-FOUND";
        }

        private void Cmb_VatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_MaVT.Text = get_MaVT(Cmb_VatTu.Text);
        }

        private void Setting()
        {
            BtnXoa.Enabled = false;
            BtnSua.Enabled = false;
            BtnThem.Enabled = false;
            BtnReload.Enabled = false;
            simpleButton1.Enabled = false;
            BtnUndo.Enabled = true;
            BtnGhi.Enabled = true;
        }

        private void ReverseSetting()
        {
            panelControl1.Enabled = true;

            groupControl1.Enabled = false;
            groupControl2.Enabled = false;

            BtnXoa.Enabled = true;
            BtnThem.Enabled = true;
            BtnSua.Enabled = true;
            BtnReload.Enabled = true;
            BtnUndo.Enabled = false;
            BtnGhi.Enabled = false;
            simpleButton1.Enabled = true;

            Cmb_VatTu.Visible = false;
        }

        private void DeleteRecord(BindingSource bds)
        {
            string txt = "Tiến hành xóa thông tin ra khỏi DB?";

            if (MessageBox.Show(txt, "Cảnh báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            try
            {
                vitri = bds.Position;
                bds.RemoveCurrent();

                if (CTMode)
                {
                    phieuXuatTableAdapter.Connection.ConnectionString = Program.connection_string;
                    phieuXuatTableAdapter.Update(dS.PhieuXuat);
                }
                else
                {
                    cTPXTableAdapter.Connection.ConnectionString = Program.connection_string;
                    cTPXTableAdapter.Update(dS.CTPX);
                }

                MessageBox.Show("Xóa thành công!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo");

                if (CTMode)
                {
                    phieuXuatTableAdapter.Fill(dS.PhieuXuat);
                    phieuXuatBindingSource.Position = vitri;
                }
                else
                {
                    cTPXTableAdapter.Fill(dS.CTPX);
                    cTPXBindingSource.Position = vitri;
                }
            }
        }

        private bool IsValid()
        {
            if (CTMode)
            {
                if (Txt_MaPX.Text == "")
                {
                    MessageBox.Show("Mã phiếu xuất không được để trống!", "Thông báo");
                    return false;
                }

                if (Txt_TenKH.Text == "")
                {
                    MessageBox.Show("Tên khách hàng không được để trống!", "Thông báo");
                    return false;
                }
            }
            else
            {
                if (Txt_MaVT.Text == "" || Txt_SoLuong.Text == "" || Txt_DonGia.Text == "")
                {
                    MessageBox.Show("Kiểm tra lại thông tin vật tư!", "Thông báo");
                    return false;
                }
            }

            return true;
        }

        private void SaveProcess01(BindingSource bds)
        {
            groupControl1.Enabled = false;

            phieuXuatTableAdapter.Connection.ConnectionString = Program.connection_string;
            phieuXuatTableAdapter.Update(dS.PhieuXuat);

            if (dangThemMoi)
            {
                dangThemMoi = false;
                phieuXuatTableAdapter.Fill(dS.PhieuXuat);
            }
            else
            {
                bds.ResetCurrentItem();
            }
        }

        private void SaveProcess02(BindingSource bds)
        {
            groupControl2.Enabled = false;

            cTPXTableAdapter.Connection.ConnectionString = Program.connection_string;
            cTPXTableAdapter.Update(dS.CTPX);

            if (dangThemMoi)
            {
                dangThemMoi = false;
                cTPXTableAdapter.Fill(dS.CTPX);
                Cmb_VatTu.SelectedIndex = 0;
            }
            else
            {
                bds.ResetCurrentItem();
            }
        }

        private void SaveRecord(BindingSource bds)
        {
            try
            {
                bds.EndEdit();

                if (CTMode) SaveProcess01(bds);
                else SaveProcess02(bds);

                MessageBox.Show("Ghi thành công!", "Thông báo");
                ReverseSetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi: " + ex.Message, "Thông báo");
            }
        }

        private void UndoProcess01()
        {
            phieuXuatTableAdapter.Fill(dS.PhieuXuat);
            phieuXuatBindingSource.Position = vitri;
        }

        private void UndoProcess02()
        {
            cTPXTableAdapter.Fill(dS.CTPX);
            cTPXBindingSource.Position = vitri;
        }

        private void UndoRecord(BindingSource bds)
        {
            if (dangThemMoi == true && BtnThem.Enabled == false)
            {
                bds.CancelEdit();

                if (CTMode) UndoProcess01();
                else UndoProcess02();

                dangThemMoi = false;
            }
            else
            {
                if (CTMode) UndoProcess01();
                else UndoProcess02();
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            dangThemMoi = true;
            groupControl1.Enabled = false;

            Setting();

            if (!CTMode)
            {
                groupControl2.Enabled = true;
                Cmb_VatTu.Visible = true;

                cTPXBindingSource.AddNew();
                vitri = cTPXBindingSource.Position;
            }
            else
            {
                groupControl1.Enabled = true;
                Txt_MaPX.Enabled = true;
                phieuXuatBindingSource.AddNew();
                vitri = phieuXuatBindingSource.Position;
                DE_PhieuXuat.DateTime = DateTime.Now.Date;
                Txt_MaNV.Text = Program.main_maNV;
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (!CTMode)
            {
                if (Program.CanBeDelete(cTPXBindingSource))
                {
                    DeleteRecord(cTPXBindingSource);
                }
            }
            else
            {
                if (Program.CanBeDelete(phieuXuatBindingSource, cTPXBindingSource))
                {
                    DeleteRecord(phieuXuatBindingSource);
                }
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            Setting();
            Txt_MaPX.Enabled = false;

            vitri = CTMode ? phieuXuatBindingSource.Position : cTPXBindingSource.Position;

            groupControl1.Enabled = false;

            if (CTMode)
            {
                groupControl1.Enabled = true;
                Txt_MaKho.Focus();
            }
            else groupControl2.Enabled = true;
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;
            
            SaveRecord(CTMode ? phieuXuatBindingSource : cTPXBindingSource);
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            UndoRecord(CTMode ? phieuXuatBindingSource : cTPXBindingSource);

            ReverseSetting();
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

        private void Btn_Kho_Click(object sender, EventArgs e)
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
    }
}