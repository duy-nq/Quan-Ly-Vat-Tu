using DevExpress.XtraEditors;
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
    public partial class UI_TongHopNhapXuat : DevExpress.XtraEditors.XtraForm
    {
        public UI_TongHopNhapXuat()
        {
            InitializeComponent();
        }

        private void UI_TongHopNhapXuat_Load(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraReport3 THNX = new XtraReport3(dateEdit1.DateTime, dateEdit2.DateTime);

            ReportPrintTool print = new ReportPrintTool(THNX);
            print.ShowPreviewDialog();
        }
    }
}