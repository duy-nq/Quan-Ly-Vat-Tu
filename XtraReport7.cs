using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Quan_Ly_Vat_Tu
{
    public partial class XtraReport7 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport7()
        {
            InitializeComponent();

            string connStr;

            if (Program.main_group == "CONGTY")
            {
                connStr = "Data Source=" + Program.remote_server_name + ";Initial Catalog=QLVT_DATHANG;User ID=" + Program.remote_username + ";Password=" + Program.remote_password;
            }
            else
            {
                connStr = "Data Source=" + Program.server_name + ";Initial Catalog=QLVT_DATHANG;User ID=" + Program.username + ";Password=" + Program.password;
            }

            sqlDataSource1.Connection.ConnectionString = connStr;
            
            sqlDataSource1.Fill();
        }

    }
}
