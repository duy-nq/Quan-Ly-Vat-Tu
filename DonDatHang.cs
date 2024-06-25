using DevExpress.XtraEditors;
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
    public partial class DonDatHang : DevExpress.XtraEditors.XtraForm
    {
        public DonDatHang()
        {
            InitializeComponent();
        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.Bds_DatHang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void DonDatHang_Load(object sender, EventArgs e)
        {
            //this.datHangTableAdapter.Fill(this.dS.DatHang);
            //this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
            DS.EnforceConstraints = false;
            this.DATHANGTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.DATHANGTableAdapter.Fill(this.DS.DatHang);
            this.CTDDHTableAdapter.Connection.ConnectionString = Program.connection_string;
            this.CTDDHTableAdapter.Fill(this.DS.CTDDH);
        }

        private void nGAYDateEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Btn_DatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Btn_ChonCheDo.Links[0].Caption = "ĐƠN ĐẶT HÀNG";
            Btn_ChonCheDo.ImageOptions.SvgImage = Btn_DatHang.ImageOptions.SvgImage;
        }

        private void Btn_CTDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Btn_ChonCheDo.Links[0].Caption = "CHI TIẾT ĐƠN HÀNG";
            Btn_ChonCheDo.ImageOptions.SvgImage = Btn_CTDDH.ImageOptions.SvgImage;
        }
    }
}