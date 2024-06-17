using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Quan_Ly_Vat_Tu
{
    public partial class XtraReport6 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport6()
        {
            InitializeComponent();

            string connStr = "Data Source=LAPTOP-S1E2VVUK;Initial Catalog=QLVT_DATHANG;User ID=HTKN;Password=123";

            sqlDataSource1.Connection.ConnectionString = connStr;

            sqlDataSource1.Fill();
        }

    }
}
