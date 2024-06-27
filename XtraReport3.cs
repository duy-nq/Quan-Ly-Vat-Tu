using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Quan_Ly_Vat_Tu
{
    public partial class XtraReport3 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport3()
        {
            InitializeComponent();
        }

        public XtraReport3(DateTime dateStart, DateTime dateEnd)
        {
            InitializeComponent();

            xrLabel2.Text = dateStart.ToString("dd/MM/yyyy");
            xrLabel4.Text = dateEnd.ToString("dd/MM/yyyy");

            string connStr = "Data Source=" + Program.server_name + ";Initial Catalog=QLVT_DATHANG;User ID=" + Program.username + ";Password=" + Program.password;

            sqlDataSource1.Connection.ConnectionString = connStr;

            this.sqlDataSource1.Queries[0].Parameters[0].Value = xrLabel2.Text;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = xrLabel4.Text;
            
            this.sqlDataSource1.Fill();
        }

    }
}
