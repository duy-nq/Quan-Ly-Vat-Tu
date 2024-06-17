namespace Quan_Ly_Vat_Tu
{
    partial class UI_DanhSachNhanVien
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
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.Cmb_ChiNhanh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_ChiNhanh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseBackColor = true;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(73, 167);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(75, 17);
            this.labelControl6.TabIndex = 39;
            this.labelControl6.Text = "CHI NHÁNH";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(73, 260);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(1);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(88, 28);
            this.simpleButton1.TabIndex = 38;
            this.simpleButton1.Text = "PREVIEW";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Cmb_ChiNhanh
            // 
            this.Cmb_ChiNhanh.Location = new System.Drawing.Point(73, 190);
            this.Cmb_ChiNhanh.Name = "Cmb_ChiNhanh";
            this.Cmb_ChiNhanh.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.Cmb_ChiNhanh.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_ChiNhanh.Properties.Appearance.Options.UseFont = true;
            this.Cmb_ChiNhanh.Properties.AutoHeight = false;
            this.Cmb_ChiNhanh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Cmb_ChiNhanh.Size = new System.Drawing.Size(325, 37);
            this.Cmb_ChiNhanh.TabIndex = 37;
            this.Cmb_ChiNhanh.SelectedIndexChanged += new System.EventHandler(this.Cmb_ChiNhanh_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Display", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(52, 27);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(602, 124);
            this.labelControl4.TabIndex = 36;
            this.labelControl4.Text = "DANH SÁCH NHÂN VIÊN";
            this.labelControl4.Click += new System.EventHandler(this.labelControl4_Click);
            // 
            // UI_DanhSachNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 314);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.Cmb_ChiNhanh);
            this.Controls.Add(this.labelControl4);
            this.Name = "UI_DanhSachNhanVien";
            this.Text = "UI_DanhSachNhanVien";
            this.Load += new System.EventHandler(this.UI_DanhSachNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_ChiNhanh.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ComboBoxEdit Cmb_ChiNhanh;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}