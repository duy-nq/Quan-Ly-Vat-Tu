using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Vat_Tu
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static SqlConnection connection = new SqlConnection();

        public static String connection_string = "";
        public static String database = "QLVT_DATHANG";
        public static String server_name = "";
        public static String main_server = "HAJKU206";
        public static String server_1 = "HAJKU206\\MSSQLSERVER01";
        public static String server_2 = "HAJKU206\\MSSQLSERVER02";
        public static String server_3 = "HAJKU206\\MSSQLSERVER03";
        
        public static String remote_username = "HTKN";
        public static String remote_password = "123";

        public static String username = "";
        public static String password = "";

        public static String username_DN;
        public static String password_DN;

        public static String main_group;
        public static String main_hoTen;
        public static String main_maNV;

        public static DataTable DT_ChiNhanh = new DataTable();

        public static int KetNoi()
        {
            if (Program.connection != null && Program.connection.State == ConnectionState.Open) Program.connection.Close();
            try
            {
                Program.connection_string = "Data Source=" + Program.server_name + ";Initial Catalog=" + Program.database + ";User ID=" +
                      Program.username + ";password=" + Program.password;
                Program.connection.ConnectionString = Program.connection_string;
                Program.connection.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nVui lòng xem lại username và password.\n" + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        public static int KetNoi_MainServer()
        {
            if (Program.connection != null && Program.connection.State == ConnectionState.Open) Program.connection.Close();

            string default_login = "sa";
            string default_password = "123";
            
            try
            {
                Program.connection_string = "Data Source=" + Program.main_server + ";Initial Catalog=" + Program.database + ";User ID=" +
                      default_login + ";password=" + default_password;
                Program.connection.ConnectionString = Program.connection_string;
                Program.connection.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nVui lòng xem lại username và password.\n" + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        public static DataTable ExecSqlQuery(String sql_query, String Connection_String)
        {
            DataTable table = new DataTable();
            connection = new SqlConnection(Connection_String);
            SqlDataAdapter Data_Adapter = new SqlDataAdapter(sql_query, connection);
            Data_Adapter.Fill(table);
            return table;
        }

        public static String Get_ServerName(string tenCN)
        {
            foreach (DataRow dr in Program.DT_ChiNhanh.Rows)
            {
                if (dr["TenCN"].ToString() == tenCN)
                {
                    return dr["TenServer"].ToString();
                }
            }

            return "ERR-NOT-FOUND";
        }



        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());
        }
    }
}
