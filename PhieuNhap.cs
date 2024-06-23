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

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            Dataset_Load();

            Program.LoadChiNhanh(Cmb_ChiNhanh);

            if (Program.main_group == "CONGTY")
            {
                BtnThem.Enabled = BtnSua.Enabled = BtnXoa.Enabled = BtnReload.Enabled = false;
                BtnGhi.Enabled = BtnUndo.Enabled = simpleButton1.Enabled = false;
                cTPNGridControl.Visible = true;
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
            if (CTMode) return;
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

            Cmb_ChiNhanh.SelectedIndex = 0;
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

        private bool CanBeDelete(BindingSource parent)
        {
            if (parent.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa!");
                return false;
            }

            return true;
        }

        private bool CanBeDelete(BindingSource parent, BindingSource child)
        {
            if (parent.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa!");
                return false;
            }
            
            if (child.Count > 0)
            {
                MessageBox.Show("Không thể xóa vì đã có " + child.Count + " dữ liệu phụ thuộc!");
                return false;
            }
            
            return true;
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
                if (Txt_MaVT.Text == "" || Txt_SoLuong.Text == "" || dONGIASpinEdit.Value == 0)
                {
                    MessageBox.Show("Kiểm tra lại thông tin vật tư!", "Thông báo");
                    return false;
                }
            }
            
            return true;
        }

        private void SaveProcess01(BindingSource bds)
        {
            groupControl2.Enabled = false;
            Txt_MaNV.Text = Program.username;
            phieuNhapTableAdapter.Connection.ConnectionString = Program.connection_string;
            phieuNhapTableAdapter.Update(dS.PhieuNhap);

            if (dangThemMoi == true)
            {
                dangThemMoi = false;
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

                BtnXoa.Enabled = true;
                BtnSua.Enabled = true;
                BtnThem.Enabled = true;
                BtnReload.Enabled = true;
                BtnUndo.Enabled = false;
                BtnGhi.Enabled = false;
                groupControl1.Enabled = true;

                labelControl1.Visible = false;
                Cmb_DSVT.Visible = false;

                if (CTMode) SaveProcess01(bds);
                else SaveProcess02(bds);

                Cmb_DSVT.Clear();

                MessageBox.Show("Ghi thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi: " + ex.Message, "Thông báo");
            }
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

            labelControl1.Visible = false;
            Cmb_DSVT.Visible = false;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            dangThemMoi = true;
            groupControl1.Enabled = false;

            BtnXoa.Enabled = false;
            BtnThem.Enabled = false;
            BtnSua.Enabled = false;
            BtnReload.Enabled = false;
            BtnUndo.Enabled = true;
            BtnGhi.Enabled = true;

            if (!CTMode)
            {
                groupControl3.Enabled = true;
                labelControl1.Visible = true;
                Cmb_DSVT.Visible = true;

                if (Cmb_DSVT.Properties.Items.Count == 1)
                {
                    MessageBox.Show("Không có vật tư để nhập!");
                    ReverseSetting();
                    return;
                }

                cTPNBindingSource.AddNew();
                vitri = cTPNBindingSource.Position;
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
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (!CTMode)
            {
                if (CanBeDelete(cTPNBindingSource))
                {
                    DeleteRecord(cTPNBindingSource);
                }
            }
            else
            {
                if (CanBeDelete(phieuNhapBindingSource, cTPNBindingSource))
                {
                    DeleteRecord(phieuNhapBindingSource);
                }
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            BtnXoa.Enabled = false;
            BtnSua.Enabled = false;
            BtnThem.Enabled = false;
            BtnReload.Enabled = false;
            BtnUndo.Enabled = true;
            BtnGhi.Enabled = true;

            vitri = CTMode ? phieuNhapBindingSource.Position : cTPNBindingSource.Position;

            groupControl1.Enabled = false;

            if (CTMode)
            {
                groupControl2.Enabled = true;
                Txt_MaVT.Focus();
            }
            else groupControl3.Enabled = true;
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;

            SaveRecord(CTMode ? phieuNhapBindingSource : cTPNBindingSource);
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            UndoRecord(CTMode ? phieuNhapBindingSource : cTPNBindingSource);

            groupControl1.Enabled = true;
            groupControl2.Enabled = false;
            groupControl3.Enabled = false;

            BtnXoa.Enabled = true;
            BtnThem.Enabled = true;
            BtnSua.Enabled = true;
            BtnReload.Enabled = true;
            BtnUndo.Enabled = false;
            BtnGhi.Enabled = false;

            labelControl1.Visible = false;
            Cmb_DSVT.Visible = false;
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
    }
}