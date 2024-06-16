using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Quan_Ly_Vat_Tu
{
    public partial class XtraReport5 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport5()
        {
            InitializeComponent();
        }

        public XtraReport5(string manv, string tennv, DateTime dateStart, DateTime dateEnd)
        {
            InitializeComponent();

            xrLabel2.Text = dateStart.ToString("dd/MM/yyyy");
            xrLabel4.Text = dateEnd.ToString("dd/MM/yyyy");

            xrLabel6.Text = tennv;

            string connStr;

            if (Program.main_group == "CONGTY")
            {
                connStr = "Data Source=LAPTOP-S1E2VVUK;Initial Catalog=QLVT_DATHANG;User ID=HTKN;Password=123";
            }
            else
            {
                connStr = "Data Source=" + Program.server_name + ";Initial Catalog=QLVT_DATHANG;User ID=" + Program.username + ";Password=" + Program.password;
            }

            sqlDataSource1.Connection.ConnectionString = connStr;

            sqlDataSource1.Queries[0].Parameters[0].Value = manv;
            sqlDataSource1.Queries[0].Parameters[1].Value = xrLabel2.Text;
            sqlDataSource1.Queries[0].Parameters[2].Value = xrLabel4.Text;
            
            sqlDataSource1.Fill();
        }   

    }
}
