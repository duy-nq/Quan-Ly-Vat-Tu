using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Vat_Tu
{
    public partial class UI_DonDatHangKhongPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        public UI_DonDatHangKhongPhieuNhap()
        {
            InitializeComponent();
        }

        private void UI_DonDatHangKhongPhieuNhap_Load(object sender, EventArgs e)
        {
            if (Program.main_group == "CHINHANH")
            {
                Cmb_ChiNhanh.Enabled = false;
                return;
            }

            foreach (DataRow dr in Program.DT_ChiNhanh.Rows)
            {
                Cmb_ChiNhanh.Properties.Items.Add(dr["TenCN"]);
            }

            Cmb_ChiNhanh.SelectedIndex = 0;
            Cmb_ChiNhanh.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        private void Cmb_ChiNhanh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Program.remote_server_name = Program.Get_ServerName(Cmb_ChiNhanh.Text);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraReport4 KPN = new XtraReport4();

            ReportPrintTool print = new ReportPrintTool(KPN);
            print.ShowPreviewDialog();
        }
    }
}