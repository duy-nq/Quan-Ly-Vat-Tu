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
        int vitri = 0;
        bool dangThemMoi = false;
        private bool CTMode = true;

        private static readonly DataTable DT_DSVT = new DataTable();

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
            if (CTMode) return;

            DT_DSVT.Clear();
            Cmb_VatTu.Properties.Items.Clear();

            Cmb_VatTu.Properties.Items.Add("-Lựa chọn vật tư-");

            string Sql_Query = "SELECT * FROM QLVT_DATHANG.dbo.View_DSVT";

            if (Program.connection.State == ConnectionState.Closed)
            {
                Program.connection.Open();
            }

            if (DT_DSVT.Rows.Count == 0)
            {
                SqlDataAdapter da = new SqlDataAdapter(Sql_Query, Program.connection);
                da.Fill(DT_DSVT);
            }

            foreach (DataRow dr in DT_DSVT.Rows)
            {
                Cmb_ChiNhanh.Properties.Items.Add(dr["TENVT"]);
            }

            Cmb_ChiNhanh.SelectedIndex = 0;
            try
            {
                Cmb_ChiNhanh.SelectedIndex = 1;
            }
            finally
            {
                Cmb_ChiNhanh.SelectedIndex = 0;
            }
        }
    }
}