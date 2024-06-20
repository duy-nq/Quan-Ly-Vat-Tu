using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class FormChuyenChiNhanh : DevExpress.XtraEditors.XtraForm
    {
        public FormChuyenChiNhanh()
        {
            InitializeComponent();
        }

        private void FormChuyenChiNhanh_Load(object sender, EventArgs e)
        {
            Txt_ChiNhanhHienTai.Text = Program.DT_ChiNhanh.Rows[Program.main_chinhanh]["TenCN"].ToString();
            Txt_ChiNhanhHienTai.Enabled = false;

            foreach (DataRow dr in Program.DT_ChiNhanh.Rows)
            {
                Cmb_ChiNhanh.Properties.Items.Add(dr["TenCN"]);
            }

            Cmb_ChiNhanh.SelectedIndex = Program.main_chinhanh;
            Cmb_ChiNhanh.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            String chiNhanhMoi = "";

            if (Cmb_ChiNhanh.SelectedIndex == Program.main_chinhanh)
            {
                MessageBox.Show("Chi nhánh hiện tại và chi nhánh chuyển đến không được trùng nhau", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            //if (NhanVien.trangThaiXoa == 1)
            //{
            //    MessageBox.Show("Nhân viên này không tồn tại ở chi nhánh hiện tại", "Thông báo", MessageBoxButtons.OK);
            //    return;
            //}

            string chiNhanhDuocChon = Cmb_ChiNhanh.Properties.Items[Cmb_ChiNhanh.SelectedIndex].ToString();
            if (chiNhanhDuocChon.Contains("1"))
            {
                chiNhanhMoi = "CN1";
            } else if (chiNhanhDuocChon.Contains("2")) {
                chiNhanhMoi = "CN2";
            }
            Console.WriteLine(chiNhanhMoi);

            if (Program.connection.State == ConnectionState.Closed)
            {
                Program.connection.Open();
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn chuyển chi nhánh?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String Sql_Query = "EXEC SP_CHUYENCHINHANH '" + NhanVien.manv + "', '" + chiNhanhMoi + "'";

                    SqlCommand command = new SqlCommand(Sql_Query, Program.connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader == null)
                    {
                        return;
                    }

                    MessageBox.Show("Chuyển chi nhánh thành công", "Thông báo", MessageBoxButtons.OK);
                    reader.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển chi nhánh: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }
        }
    }
}