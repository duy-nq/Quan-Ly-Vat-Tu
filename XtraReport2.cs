using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Quan_Ly_Vat_Tu
{
    public partial class XtraReport2 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport2()
        {
            InitializeComponent();
        }

        public XtraReport2(bool type, DateTime dateStart, DateTime dateEnd)
        {
            InitializeComponent();

            xrLabel2.Text = dateStart.ToString("yyyy-MM");
            xrLabel4.Text = dateEnd.ToString("yyyy-MM");

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

            sqlDataSource1.Queries[0].Parameters[0].Value = type;
            sqlDataSource1.Queries[0].Parameters[1].Value = dateStart.ToString("yyyy-MM");
            sqlDataSource1.Queries[0].Parameters[2].Value = dateEnd.ToString("yyyy-MM");
            
            sqlDataSource1.Fill();
        }

    }
}
