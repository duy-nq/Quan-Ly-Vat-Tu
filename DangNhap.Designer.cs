namespace Quan_Ly_Vat_Tu
{
    partial class DangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Cmb_ChiNhanh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Txt_Username = new DevExpress.XtraEditors.TextEdit();
            this.Txt_MatKhau = new DevExpress.XtraEditors.TextEdit();
            this.Btn_Login = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_ChiNhanh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_MatKhau.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Cmb_ChiNhanh
            // 
            this.Cmb_ChiNhanh.Location = new System.Drawing.Point(33, 219);
            this.Cmb_ChiNhanh.Name = "Cmb_ChiNhanh";
            this.Cmb_ChiNhanh.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.Cmb_ChiNhanh.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_ChiNhanh.Properties.Appearance.Options.UseFont = true;
            this.Cmb_ChiNhanh.Properties.AutoHeight = false;
            this.Cmb_ChiNhanh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Cmb_ChiNhanh.Size = new System.Drawing.Size(325, 37);
            this.Cmb_ChiNhanh.TabIndex = 5;
            this.Cmb_ChiNhanh.SelectedIndexChanged += new System.EventHandler(this.Cmb_ChiNhanh_SelectedIndexChanged);
            // 
            // Txt_Username
            // 
            this.Txt_Username.Location = new System.Drawing.Point(33, 292);
            this.Txt_Username.Name = "Txt_Username";
            this.Txt_Username.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Username.Properties.Appearance.Options.UseFont = true;
            this.Txt_Username.Properties.AutoHeight = false;
            this.Txt_Username.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Txt_Username.Size = new System.Drawing.Size(325, 37);
            this.Txt_Username.TabIndex = 6;
            this.Txt_Username.EditValueChanged += new System.EventHandler(this.Txt_Username_EditValueChanged);
            // 
            // Txt_MatKhau
            // 
            this.Txt_MatKhau.Location = new System.Drawing.Point(33, 369);
            this.Txt_MatKhau.Name = "Txt_MatKhau";
            this.Txt_MatKhau.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_MatKhau.Properties.Appearance.Options.UseFont = true;
            this.Txt_MatKhau.Properties.AutoHeight = false;
            this.Txt_MatKhau.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Txt_MatKhau.Properties.PasswordChar = '*';
            this.Txt_MatKhau.Size = new System.Drawing.Size(325, 37);
            this.Txt_MatKhau.TabIndex = 7;
            this.Txt_MatKhau.EditValueChanged += new System.EventHandler(this.Txt_MatKhau_EditValueChanged);
            // 
            // Btn_Login
            // 
            this.Btn_Login.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Login.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Btn_Login.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.Appearance.Options.UseBackColor = true;
            this.Btn_Login.Appearance.Options.UseBorderColor = true;
            this.Btn_Login.Appearance.Options.UseFont = true;
            this.Btn_Login.Location = new System.Drawing.Point(33, 436);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(325, 37);
            this.Btn_Login.TabIndex = 9;
            this.Btn_Login.Text = "ĐĂNG NHẬP";
            this.Btn_Login.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Display", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(33, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(325, 124);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "HỆ THỐNG QUẢN LÝ VẬT TƯ - ĐẶT HÀNG";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl5.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl5.AppearanceDisabled.Options.UseTextOptions = true;
            this.labelControl5.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl5.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(67, 700);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(268, 48);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Học Viện Công Nghệ Bưu Chính Viễn Thông Cơ Sở Tp.HCM ©";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseBackColor = true;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(33, 272);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(107, 17);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "TÊN ĐĂNG NHẬP";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseBackColor = true;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(33, 346);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 17);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "MẬT KHẨU";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(33, 196);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 17);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "CHI NHÁNH";
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 760);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.Txt_MatKhau);
            this.Controls.Add(this.Txt_Username);
            this.Controls.Add(this.Cmb_ChiNhanh);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_ChiNhanh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_MatKhau.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.ComboBoxEdit Cmb_ChiNhanh;
        private DevExpress.XtraEditors.TextEdit Txt_Username;
        private DevExpress.XtraEditors.TextEdit Txt_MatKhau;
        private DevExpress.XtraEditors.SimpleButton Btn_Login;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}

