using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quan_Ly_Vat_Tu
{
    public partial class PhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        //private static readonly Dictionary<string, string> DT_DSVT = new Dictionary<string, string>();
        private static readonly DataTable DT_DSVT = new DataTable();
        public static string makho;
        private bool CTMode = true;

        int vitri = 0;
        bool dangThemMoi = false;

        public PhieuNhap()
        {
            InitializeComponent();

            try
            {
                DT_DSVT.Columns.Add("MAVT", typeof(string));
                DT_DSVT.Columns.Add("TENVT", typeof(string));
                DT_DSVT.Columns.Add("SOLUONG", typeof(int));
            }
            catch
            {
                Console.WriteLine("Error: DataTable DT_DSVT");
            }

        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.datHangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);
        }

        private void Dataset_Load()
        {
            dS.EnforceConstraints = false;
            datHangTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.datHangTableAdapter.Fill(this.dS.DatHang);
            cTDDHTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
            phieuNhapTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);
            cTPNTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.cTPNTableAdapter.Fill(this.dS.CTPN);
        }

        private void VTCN_Load()
        {
            DT_DSVT.Clear();
            Cmb_DSVT.Properties.Items.Clear();

            Cmb_DSVT.Properties.Items.Add("-Lựa chọn vật tư-");

            string Sql_Query = "EXEC QLVT_DATHANG.dbo.SP_VatTuChuaNhap '" + Txt_MSDDH.Text + "'";

            using (SqlConnection connection =
                   new SqlConnection(Program.connection_string))
            {
                SqlCommand command =
                    new SqlCommand(Sql_Query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cmb_DSVT.Properties.Items.Add(reader[1].ToString());
                    DT_DSVT.Rows.Add(reader[0].ToString(), reader[1].ToString(), (int)reader[2]);
                }

                reader.Close();
            }

            Cmb_DSVT.SelectedIndex = 0;
        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            Dataset_Load();

            Program.LoadChiNhanh(Cmb_ChiNhanh);

            if (Program.main_group == "CONGTY")
            {
                BtnThem.Enabled = BtnSua.Enabled = BtnXoa.Enabled = BtnReload.Enabled = false;
                BtnGhi.Enabled = BtnUndo.Enabled = simpleButton1.Enabled = false;
                cTPNGridControl.Visible = true;
                Cmb_ChiNhanh.Enabled = true;
            }
        }

        private void datHangBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.datHangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);
        }

        private void datHangGridControl_Click(object sender, EventArgs e)
        {

        }

        private void cTPNGridControl_Click(object sender, EventArgs e)
        {

        }

        private (string MaVT, string SoLuong) Get_TenVT(string tenvt)
        {
            foreach (DataRow dr in DT_DSVT.Rows)
            {
                if (dr["TENVT"].ToString() == tenvt)
                {
                    return (dr["MAVT"].ToString(), (dr["SOLUONG"].ToString()));
                }
            }

            return ("ERR-NOT-FOUND", "0");
        }

        private void Cmb_DSVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            (Txt_MaVT.Text, Txt_SoLuong.Text) = Get_TenVT(Cmb_DSVT.Text);
        }

        private void mAPNTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CTMode = !CTMode;
            if (CTMode) {
                Cmb_DSVT.Visible = false;
                labelControl1.Visible = false;
                cTPNGridControl.Visible = false;
            }
            else
            {
                cTPNGridControl.Visible = true;
            }

            MessageBox.Show("Chuyển sang chế độ " + (CTMode ? "phiếu nhập!" : "chi tiết phiếu nhập!"));
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
                    phieuNhapTableAdapter.Connection.ConnectionString = Program.connection_string;
                    phieuNhapTableAdapter.Update(dS.PhieuNhap);
                }
                else
                {
                    cTPNTableAdapter.Connection.ConnectionString = Program.connection_string;
                    cTPNTableAdapter.Update(dS.CTPN);
                }

                MessageBox.Show("Xóa thành công!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo");

                if (CTMode)
                {
                    phieuNhapTableAdapter.Fill(dS.PhieuNhap);
                    phieuNhapBindingSource.Position = vitri;
                }
                else
                {
                    cTPNTableAdapter.Fill(dS.CTPN);
                    cTPNBindingSource.Position = vitri;
                }
            }
        }

        private void UndoProcess01(BindingSource bds)
        {
            phieuNhapTableAdapter.Fill(dS.PhieuNhap);
            bds.Position = vitri;
        }

        private void UndoProcess02(BindingSource bds)
        {
            cTPNTableAdapter.Fill(dS.CTPN);
            bds.Position = vitri;
        }

        private void UndoRecord(BindingSource bds)
        {
            if (dangThemMoi == true && BtnThem.Enabled == false)
            {
                bds.CancelEdit();

                if (CTMode) UndoProcess01(bds);
                else UndoProcess02(bds);

                dangThemMoi = false;
            }
            else
            {
                if (CTMode) UndoProcess01(bds);
                else UndoProcess02(bds);
            }
        }

        private bool IsValid()
        {
            if (CTMode)
            {
                if (Txt_MaPN.Text == "")
                {
                    MessageBox.Show("Mã phiếu nhập không được để trống!", "Thông báo");
                    return false;
                }
            }
            else
            {
                
                if (Txt_MaVT.Text == "" || Txt_SoLuong.Text == "" || dONGIATextEdit.Text == "" || Txt_MaVT.Text == "ERR-NOT-FOUND")
                {
                    MessageBox.Show("Kiểm tra lại thông tin vật tư!", "Thông báo");
                    return false;
                }
                if (int.Parse(Txt_SoLuong.Text) <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo");
                    return false;
                }
            }
            
            return true;
        }

        private void SaveProcess01(BindingSource bds)
        {
            groupControl2.Enabled = false;
            phieuNhapTableAdapter.Connection.ConnectionString = Program.connection_string;
            phieuNhapTableAdapter.Update(dS.PhieuNhap);

            if (dangThemMoi == true)
            {
                dangThemMoi = false;
                Cmb_DSVT.Clear();
                phieuNhapTableAdapter.Connection.ConnectionString = Program.connection_string;
                phieuNhapTableAdapter.Fill(dS.PhieuNhap);
            }
            else
            {
                bds.ResetCurrentItem();
            }
        }

        private void SaveProcess02(BindingSource bds)
        {
            groupControl3.Enabled = false;
            cTPNTableAdapter.Connection.ConnectionString = Program.connection_string;
            cTPNTableAdapter.Update(dS.CTPN);

            if (dangThemMoi == true)
            {
                Cmb_DSVT.Clear();
                cTPNTableAdapter.Connection.ConnectionString = Program.connection_string;
                cTPNTableAdapter.Fill(dS.CTPN);
                dangThemMoi = false;
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

        private void Setting()
        {
            groupControl1.Enabled = false;

            BtnXoa.Enabled = false;
            BtnThem.Enabled = false;
            BtnSua.Enabled = false;
            BtnReload.Enabled = false;
            simpleButton1.Enabled = false;
            BtnUndo.Enabled = true;
            BtnGhi.Enabled = true;
        }

        private void ReverseSetting()
        {
            groupControl1.Enabled = true;

            groupControl2.Enabled = false;
            groupControl3.Enabled = false;

            BtnXoa.Enabled = true;
            BtnThem.Enabled = true;
            BtnSua.Enabled = true;
            BtnReload.Enabled = true;
            BtnUndo.Enabled = false;
            BtnGhi.Enabled = false;
            simpleButton1.Enabled = true;

            labelControl1.Visible = false;
            Cmb_DSVT.Visible = false;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            dangThemMoi = true;

            Setting();
            Txt_MaNV.Enabled = true;
            Txt_MaPN.Enabled = true;
            DE_PhieuNhap.Enabled = true;

            if (!CTMode)
            {
                if (phieuNhapBindingSource.Count == 0)
                {
                    MessageBox.Show("Không có phiếu nhập để thêm chi tiết!");
                    ReverseSetting();
                    return;
                }   
                
                groupControl3.Enabled = true;
                labelControl1.Visible = true;
                Cmb_DSVT.Visible = true;

                cTPNBindingSource.AddNew();
                vitri = cTPNBindingSource.Position;
                
                VTCN_Load();
                if (Cmb_DSVT.Properties.Items.Count == 1)
                {
                    MessageBox.Show("Không có vật tư để nhập!");
                    ReverseSetting();
                    return;
                }
            }
            else
            {
                if (phieuNhapBindingSource.Count != 0)
                {
                    MessageBox.Show("Đã lập phiếu nhập, không thể thêm mới!");
                    ReverseSetting();
                    return;
                }
                
                groupControl2.Enabled = true;
                phieuNhapBindingSource.AddNew();
                vitri = phieuNhapBindingSource.Position;
                DE_PhieuNhap.DateTime = DateTime.Now.Date;
                Txt_MaNV.Text = Program.main_maNV;
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (!CTMode)
            {
                if (Program.CanBeDelete(cTPNBindingSource))
                {
                    DeleteRecord(cTPNBindingSource);
                }
            }
            else
            {
                if (Program.CanBeDelete(phieuNhapBindingSource, cTPNBindingSource))
                {
                    DeleteRecord(phieuNhapBindingSource);
                }
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            Setting();
            Txt_MaNV.Enabled = false;
            Txt_MaPN.Enabled = false;
            DE_PhieuNhap.Enabled = false;

            vitri = CTMode ? phieuNhapBindingSource.Position : cTPNBindingSource.Position;

            groupControl1.Enabled = false;

            if (CTMode)
            {
                if (phieuNhapBindingSource.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để sửa!", "Thông báo");
                    return;
                }

                groupControl2.Enabled = true;
                Txt_MaVT.Focus();
            }
            else
            {
                if (cTPNBindingSource.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để sửa!", "Thông báo");
                    return;
                }
                groupControl3.Enabled = true;
            }
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;

            SaveRecord(CTMode ? phieuNhapBindingSource : cTPNBindingSource);
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            UndoRecord(CTMode ? phieuNhapBindingSource : cTPNBindingSource);

            ReverseSetting();
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            if (!CTMode)
            {
                cTPNTableAdapter.Fill(dS.CTPN);
            }
            else
            {
                phieuNhapTableAdapter.Fill(dS.PhieuNhap);
            }
        }

        private void Cmb_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ConfigToRemoteServer(Cmb_ChiNhanh);

            if (Program.KetNoi() == 0) return;
            else Dataset_Load();
        }

        private void Txt_MSDDH_EditValueChanged(object sender, EventArgs e)
        {

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