namespace Quan_Ly_Vat_Tu
{
    partial class TaoLogin
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label hOLabel;
            System.Windows.Forms.Label mACNLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaoLogin));
            this.DS = new Quan_Ly_Vat_Tu.DS();
            this.tableAdapterManager = new Quan_Ly_Vat_Tu.DSTableAdapters.TableAdapterManager();
            this.Bds_NhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.NHANVIENTableAdapter = new Quan_Ly_Vat_Tu.DSTableAdapters.View_NhanVienChuaCoLoginNameTableAdapter();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.Btn_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_LamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.Cmb_ChiNhanh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Label_ChiNhanh = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.view_NhanVienChuaCoLoginNameGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMACN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Btn_TaoLogin = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.Txt_MaCN = new DevExpress.XtraEditors.TextEdit();
            this.Txt_Ten = new DevExpress.XtraEditors.TextEdit();
            this.Txt_Ho = new DevExpress.XtraEditors.TextEdit();
            this.Txt_MaNV = new DevExpress.XtraEditors.TextEdit();
            mANVLabel = new System.Windows.Forms.Label();
            hOLabel = new System.Windows.Forms.Label();
            mACNLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds_NhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_ChiNhanh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.view_NhanVienChuaCoLoginNameGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_MaCN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Ten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Ho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_MaNV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mANVLabel.Location = new System.Drawing.Point(190, 53);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(158, 22);
            mANVLabel.TabIndex = 0;
            mANVLabel.Text = "MÃ NHÂN VIÊN:";
            // 
            // hOLabel
            // 
            hOLabel.AutoSize = true;
            hOLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            hOLabel.Location = new System.Drawing.Point(81, 136);
            hOLabel.Name = "hOLabel";
            hOLabel.Size = new System.Drawing.Size(87, 22);
            hOLabel.TabIndex = 2;
            hOLabel.Text = "HỌ TÊN:";
            // 
            // mACNLabel
            // 
            mACNLabel.AutoSize = true;
            mACNLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mACNLabel.Location = new System.Drawing.Point(81, 241);
            mACNLabel.Name = "mACNLabel";
            mACNLabel.Size = new System.Drawing.Size(318, 22);
            mACNLabel.TabIndex = 6;
            mACNLabel.Text = "ĐANG LÀM VIỆC TẠI CHI NHÁNH:";
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Quan_Ly_Vat_Tu.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // Bds_NhanVien
            // 
            this.Bds_NhanVien.DataMember = "View_NhanVienChuaCoLoginName";
            this.Bds_NhanVien.DataSource = this.DS;
            // 
            // NHANVIENTableAdapter
            // 
            this.NHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.Cmb_ChiNhanh);
            this.panelControl1.Controls.Add(this.Label_ChiNhanh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1938, 127);
            this.panelControl1.TabIndex = 6;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl2.Controls.Add(this.Btn_Thoat);
            this.groupControl2.Controls.Add(this.Btn_LamMoi);
            this.groupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl2.Location = new System.Drawing.Point(1362, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(205, 120);
            this.groupControl2.TabIndex = 8;
            // 
            // Btn_Thoat
            // 
            this.Btn_Thoat.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.Btn_Thoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_Thoat.ImageOptions.SvgImage")));
            this.Btn_Thoat.Location = new System.Drawing.Point(105, 31);
            this.Btn_Thoat.Name = "Btn_Thoat";
            this.Btn_Thoat.Size = new System.Drawing.Size(94, 84);
            this.Btn_Thoat.TabIndex = 4;
            this.Btn_Thoat.Text = "Thoát";
            this.Btn_Thoat.Click += new System.EventHandler(this.Btn_Thoat_Click);
            // 
            // Btn_LamMoi
            // 
            this.Btn_LamMoi.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.Btn_LamMoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_LamMoi.ImageOptions.SvgImage")));
            this.Btn_LamMoi.Location = new System.Drawing.Point(5, 31);
            this.Btn_LamMoi.Name = "Btn_LamMoi";
            this.Btn_LamMoi.Size = new System.Drawing.Size(94, 84);
            this.Btn_LamMoi.TabIndex = 2;
            this.Btn_LamMoi.Text = "Làm Mới";
            this.Btn_LamMoi.Click += new System.EventHandler(this.Btn_LamMoi_Click);
            // 
            // Cmb_ChiNhanh
            // 
            this.Cmb_ChiNhanh.Location = new System.Drawing.Point(399, 45);
            this.Cmb_ChiNhanh.Name = "Cmb_ChiNhanh";
            this.Cmb_ChiNhanh.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_ChiNhanh.Properties.Appearance.Options.UseFont = true;
            this.Cmb_ChiNhanh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Cmb_ChiNhanh.Size = new System.Drawing.Size(319, 32);
            this.Cmb_ChiNhanh.TabIndex = 1;
            this.Cmb_ChiNhanh.SelectedIndexChanged += new System.EventHandler(this.Cmb_ChiNhanh_SelectedIndexChanged);
            // 
            // Label_ChiNhanh
            // 
            this.Label_ChiNhanh.Appearance.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ChiNhanh.Appearance.Options.UseFont = true;
            this.Label_ChiNhanh.Location = new System.Drawing.Point(176, 48);
            this.Label_ChiNhanh.Name = "Label_ChiNhanh";
            this.Label_ChiNhanh.Size = new System.Drawing.Size(123, 26);
            this.Label_ChiNhanh.TabIndex = 0;
            this.Label_ChiNhanh.Text = "CHI NHÁNH";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.view_NhanVienChuaCoLoginNameGridControl);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 127);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1938, 300);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "DANH SÁCH NHÂN VIÊN CHƯA CÓ TÀI KHOẢN LOGIN";
            // 
            // view_NhanVienChuaCoLoginNameGridControl
            // 
            this.view_NhanVienChuaCoLoginNameGridControl.DataSource = this.Bds_NhanVien;
            this.view_NhanVienChuaCoLoginNameGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view_NhanVienChuaCoLoginNameGridControl.Location = new System.Drawing.Point(2, 28);
            this.view_NhanVienChuaCoLoginNameGridControl.MainView = this.gridView1;
            this.view_NhanVienChuaCoLoginNameGridControl.Name = "view_NhanVienChuaCoLoginNameGridControl";
            this.view_NhanVienChuaCoLoginNameGridControl.Size = new System.Drawing.Size(1934, 270);
            this.view_NhanVienChuaCoLoginNameGridControl.TabIndex = 0;
            this.view_NhanVienChuaCoLoginNameGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMANV,
            this.colHO,
            this.colTEN,
            this.colMACN});
            this.gridView1.GridControl = this.view_NhanVienChuaCoLoginNameGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMANV
            // 
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 0;
            this.colMANV.Width = 94;
            // 
            // colHO
            // 
            this.colHO.FieldName = "HO";
            this.colHO.MinWidth = 25;
            this.colHO.Name = "colHO";
            this.colHO.Visible = true;
            this.colHO.VisibleIndex = 1;
            this.colHO.Width = 94;
            // 
            // colTEN
            // 
            this.colTEN.FieldName = "TEN";
            this.colTEN.MinWidth = 25;
            this.colTEN.Name = "colTEN";
            this.colTEN.Visible = true;
            this.colTEN.VisibleIndex = 2;
            this.colTEN.Width = 94;
            // 
            // colMACN
            // 
            this.colMACN.FieldName = "MACN";
            this.colMACN.MinWidth = 25;
            this.colMACN.Name = "colMACN";
            this.colMACN.Visible = true;
            this.colMACN.VisibleIndex = 3;
            this.colMACN.Width = 94;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.groupControl5);
            this.groupControl3.Controls.Add(this.groupControl4);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 427);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1938, 633);
            this.groupControl3.TabIndex = 8;
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.labelControl2);
            this.groupControl5.Controls.Add(this.labelControl1);
            this.groupControl5.Controls.Add(this.Btn_TaoLogin);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl5.Location = new System.Drawing.Point(675, 28);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(1261, 603);
            this.groupControl5.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(121, 218);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(592, 37);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "B2: TẠO LOGIN CHO NHÂN VIÊN ĐƯỢC CHỌN";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(121, 124);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(465, 37);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "B1: CHỌN NHÂN VIÊN Ở BẢNG TRÊN";
            // 
            // Btn_TaoLogin
            // 
            this.Btn_TaoLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_TaoLogin.Appearance.Options.UseFont = true;
            this.Btn_TaoLogin.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.Btn_TaoLogin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_TaoLogin.ImageOptions.SvgImage")));
            this.Btn_TaoLogin.Location = new System.Drawing.Point(779, 184);
            this.Btn_TaoLogin.Name = "Btn_TaoLogin";
            this.Btn_TaoLogin.Size = new System.Drawing.Size(241, 101);
            this.Btn_TaoLogin.TabIndex = 0;
            this.Btn_TaoLogin.Text = "TẠO LOGIN";
            this.Btn_TaoLogin.Click += new System.EventHandler(this.Btn_TaoLogin_Click);
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl4.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl4.Controls.Add(mACNLabel);
            this.groupControl4.Controls.Add(this.Txt_MaCN);
            this.groupControl4.Controls.Add(this.Txt_Ten);
            this.groupControl4.Controls.Add(hOLabel);
            this.groupControl4.Controls.Add(this.Txt_Ho);
            this.groupControl4.Controls.Add(mANVLabel);
            this.groupControl4.Controls.Add(this.Txt_MaNV);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl4.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl4.Location = new System.Drawing.Point(2, 28);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(673, 603);
            this.groupControl4.TabIndex = 0;
            this.groupControl4.Text = "THÔNG TIN NHÂN VIÊN";
            // 
            // Txt_MaCN
            // 
            this.Txt_MaCN.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bds_NhanVien, "MACN", true));
            this.Txt_MaCN.Location = new System.Drawing.Point(405, 238);
            this.Txt_MaCN.Name = "Txt_MaCN";
            this.Txt_MaCN.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_MaCN.Properties.Appearance.Options.UseFont = true;
            this.Txt_MaCN.Size = new System.Drawing.Size(125, 28);
            this.Txt_MaCN.TabIndex = 7;
            // 
            // Txt_Ten
            // 
            this.Txt_Ten.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bds_NhanVien, "TEN", true));
            this.Txt_Ten.Location = new System.Drawing.Point(448, 133);
            this.Txt_Ten.Name = "Txt_Ten";
            this.Txt_Ten.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Ten.Properties.Appearance.Options.UseFont = true;
            this.Txt_Ten.Size = new System.Drawing.Size(125, 28);
            this.Txt_Ten.TabIndex = 5;
            // 
            // Txt_Ho
            // 
            this.Txt_Ho.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bds_NhanVien, "HO", true));
            this.Txt_Ho.Location = new System.Drawing.Point(174, 133);
            this.Txt_Ho.Name = "Txt_Ho";
            this.Txt_Ho.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Ho.Properties.Appearance.Options.UseFont = true;
            this.Txt_Ho.Size = new System.Drawing.Size(268, 28);
            this.Txt_Ho.TabIndex = 3;
            // 
            // Txt_MaNV
            // 
            this.Txt_MaNV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bds_NhanVien, "MANV", true));
            this.Txt_MaNV.Location = new System.Drawing.Point(354, 50);
            this.Txt_MaNV.Name = "Txt_MaNV";
            this.Txt_MaNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_MaNV.Properties.Appearance.Options.UseFont = true;
            this.Txt_MaNV.Size = new System.Drawing.Size(125, 28);
            this.Txt_MaNV.TabIndex = 1;
            // 
            // TaoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1938, 1060);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "TaoLogin";
            this.Text = "Tạo Login";
            this.Load += new System.EventHandler(this.TaoLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds_NhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_ChiNhanh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.view_NhanVienChuaCoLoginNameGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_MaCN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Ten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Ho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_MaNV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DS DS;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource Bds_NhanVien;
        private DSTableAdapters.View_NhanVienChuaCoLoginNameTableAdapter NHANVIENTableAdapter;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit Cmb_ChiNhanh;
        private DevExpress.XtraEditors.LabelControl Label_ChiNhanh;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton Btn_Thoat;
        private DevExpress.XtraEditors.SimpleButton Btn_LamMoi;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl view_NhanVienChuaCoLoginNameGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colHO;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colMACN;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.SimpleButton Btn_TaoLogin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit Txt_MaCN;
        private DevExpress.XtraEditors.TextEdit Txt_Ten;
        private DevExpress.XtraEditors.TextEdit Txt_Ho;
        private DevExpress.XtraEditors.TextEdit Txt_MaNV;
    }
}