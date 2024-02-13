using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Vat_Tu
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();

            Text = "Mã NV: " + Program.main_maNV + " - " + "Họ tên: " + Program.main_hoTen + " - " + "Nhóm: " + Program.main_group;
        }
    }
}