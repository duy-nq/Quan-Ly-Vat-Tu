using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Vat_Tu
{
    public partial class UI_HoatDongNhanVien : DevExpress.XtraEditors.XtraForm
    {
        private static readonly DataTable DT_DSNV = new DataTable();

        public UI_HoatDongNhanVien()
        {
            InitializeComponent();
        }

        public void Load_DSNV()
        {
            string Sql_Query = "SELECT * FROM QLVT_DATHANG.dbo.View_DSNV";

            if (Program.connection.State == ConnectionState.Closed)
            {
                Program.connection.Open();
            }

            DT_DSNV.Clear();
            Cmb_DSNV.Properties.Items.Clear();

            SqlDataAdapter da = new SqlDataAdapter(Sql_Query, Program.connection);
            da.Fill(DT_DSNV);

            foreach (DataRow dr in DT_DSNV.Rows)
            {
                if (dr["TrangThaiXoa"].ToString() != "True") 
                    Cmb_DSNV.Properties.Items.Add(dr["MANV"]);
            }

            Cmb_DSNV.SelectedIndex = 0;
        }

        private String Get_TenNV(string manv)
        {
            foreach (DataRow dr in DT_DSNV.Rows)
            {
                if (dr["MANV"].ToString() == manv)
                {
                    return dr["TENNV"].ToString();
                }
            }

            return "ERR-NOT-FOUND";
        }

        private void Cmb_DSNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_TenNV.Text = Get_TenNV(Cmb_DSNV.Text);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            XtraReport5 HDNV = new XtraReport5(Cmb_DSNV.Text, txt_TenNV.Text, dateEdit4.DateTime, dateEdit3.DateTime);

            ReportPrintTool print = new ReportPrintTool(HDNV);
            print.ShowPreviewDialog();
        }

        private void Cmb_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ConfigToRemoteServer(Cmb_ChiNhanh);

            if (Program.KetNoi() == 0) return;
            else
            {
                DT_DSNV.Clear();
                Cmb_DSNV.Properties.Items.Clear();
                Load_DSNV();
            }
        }

        private void UI_HoatDongNhanVien_Load(object sender, EventArgs e)
        {
            Program.LoadChiNhanh(Cmb_ChiNhanh);
            Load_DSNV();

            if (Program.main_group == "CHINHANH")
            {
                Cmb_DSNV.Text = Program.main_maNV;
                txt_TenNV.Text = Program.main_hoTen;
            }
            else
            {
                Cmb_ChiNhanh.Enabled = true;
            }
        }
    }
}