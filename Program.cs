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
using dotenv.net;
using DevExpress.XtraEditors;

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
        public static String remote_server_name = "";
        public static String main_server = "LAPTOP-S1E2VVUK";
        public static String server_1 = "LAPTOP-S1E2VVUK\\MSSQLSERVER01";
        public static String server_2 = "LAPTOP-S1E2VVUK\\MSSQLSERVER02";
        public static String server_3 = "LAPTOP-S1E2VVUK\\MSSQLSERVER03";
        
        public static String remote_username = "HTKN";
        public static String remote_password = "123";

        public static String username = "";
        public static String password = "";

        public static String username_DN;
        public static String password_DN;

        public static int main_chinhanh;
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

        public static SqlDataReader ExecSqlDataReader(String cmd)
        {
            SqlDataReader myreader;

            // SqlCommand sqlcmd = new SqlCommand(cmd, Program conn);
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = Program.connection;
            sqlcmd.CommandText = cmd;
            sqlcmd.CommandType = CommandType.Text;

            if (Program.connection.State == ConnectionState.Closed) Program.connection.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader();
                return myreader;
            }
            catch (SqlException ex)
            {
                Program.connection.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void ConfigToRemoteServer(ComboBoxEdit cmb)
        {
            if (cmb.Text.ToString() == "System.Data.DataRowView") return;
            server_name = Get_ServerName(cmb.Text);

            if (cmb.SelectedIndex != main_chinhanh)
            {
                username = remote_username;
                password = remote_password;
            }
            else
            {
                username = username_DN;
                password = password_DN;
            }
        }

        public static void LoadChiNhanh(ComboBoxEdit cmb)
        {
            foreach (DataRow dr in Program.DT_ChiNhanh.Rows)
            {
                cmb.Properties.Items.Add(dr["TenCN"]);
            }

            cmb.SelectedIndex = Program.main_chinhanh;
        }

        public static String Get_ServerName(string tenCN)
        {
            foreach (DataRow dr in DT_ChiNhanh.Rows)
            {
                if (dr["TenCN"].ToString() == tenCN)
                {
                    return dr["TenServer"].ToString();
                }
            }

            return "ERR-NOT-FOUND";
        }

        //static void LoadEnvVariables()
        //{
            //DotEnv.Load();

            //Program.main_server = Environment.GetEnvironmentVariable("MAIN_SERVER");
            //Program.server_1 = Environment.GetEnvironmentVariable("SERVER_1");
            //Program.server_2 = Environment.GetEnvironmentVariable("SERVER_2");
            //Program.server_3 = Environment.GetEnvironmentVariable("SERVER_3");
        //}

        [STAThread]
        static void Main()
        {
            //LoadEnvVariables();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());
        }
    }
}
    