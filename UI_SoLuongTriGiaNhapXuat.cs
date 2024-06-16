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
    public partial class UI_SoLuongTriGiaNhapXuat : DevExpress.XtraEditors.XtraForm
    {
        public UI_SoLuongTriGiaNhapXuat()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bool loaiPhieu;
            if (Cmb_LoaiPhieu.Text == null)
            {
                XtraMessageBox.Show("Vui lòng chọn loại phiếu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (Cmb_LoaiPhieu.Text == "Phiếu nhập")
                {
                    loaiPhieu = true;
                }
                else
                {
                    loaiPhieu = false;
                }
            }
            XtraReport2 SLTG = new XtraReport2(loaiPhieu, dateEdit1.DateTime, dateEdit2.DateTime);

            ReportPrintTool print = new ReportPrintTool(SLTG);
            print.ShowPreviewDialog();
        }
    }
}