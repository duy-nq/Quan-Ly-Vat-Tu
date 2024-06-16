using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Quan_Ly_Vat_Tu
{
    public partial class XtraReport4 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport4()
        {
            InitializeComponent();

            string connStr;

            if (Program.main_group == "CONGTY")
            {
                xrLabel6.Text = "Toàn bộ chi nhánh";
                connStr = "Data Source=LAPTOP-S1E2VVUK;Initial Catalog=QLVT_DATHANG;User ID=HTKN;Password=123";
            }
            else
            {
                xrLabel6.Text = "Chi nhánh hiện tại";
                connStr = "Data Source=" + Program.server_name + ";Initial Catalog=QLVT_DATHANG;User ID=" + Program.username + ";Password=" + Program.password;
            }

            sqlDataSource1.Connection.ConnectionString = connStr;

            sqlDataSource1.Fill();
        }
    }
}
