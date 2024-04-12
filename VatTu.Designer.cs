namespace Quan_Ly_Vat_Tu
{
    partial class VatTu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VatTu));
            System.Windows.Forms.Label mAVTLabel;
            System.Windows.Forms.Label tENVTLabel;
            System.Windows.Forms.Label dVTLabel;
            System.Windows.Forms.Label sOLUONGTONLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.Btn_Them = new DevExpress.XtraBars.BarLargeButtonItem();
            this.Btn_Sua = new DevExpress.XtraBars.BarLargeButtonItem();
            this.Btn_Xoa = new DevExpress.XtraBars.BarLargeButtonItem();
            this.Btn_Ghi = new DevExpress.XtraBars.BarLargeButtonItem();
            this.Btn_PhucHoi = new DevExpress.XtraBars.BarLargeButtonItem();
            this.Btn_LamMoi = new DevExpress.XtraBars.BarLargeButtonItem();
            this.Btn_Thoat = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.DS1 = new Quan_Ly_Vat_Tu.DS1();
            this.Bds_VatTu = new System.Windows.Forms.BindingSource(this.components);
            this.VATTUTableAdapter = new Quan_Ly_Vat_Tu.DS1TableAdapters.VattuTableAdapter();
            this.tableAdapterManager = new Quan_Ly_Vat_Tu.DS1TableAdapters.TableAdapterManager();
            this.vattuGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONGTON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Panel_NhapLieu = new DevExpress.XtraEditors.PanelControl();
            this.mAVTTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tENVTTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dVTTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.sOLUONGTONSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.Bds_CTPX = new System.Windows.Forms.BindingSource(this.components);
            this.CTPXTableAdapter = new Quan_Ly_Vat_Tu.DS1TableAdapters.CTPXTableAdapter();
            this.Bds_CTPN = new System.Windows.Forms.BindingSource(this.components);
            this.CTPNTableAdapter = new Quan_Ly_Vat_Tu.DS1TableAdapters.CTPNTableAdapter();
            this.Bds_CTDDH = new System.Windows.Forms.BindingSource(this.components);
            this.CTDDHTableAdapter = new Quan_Ly_Vat_Tu.DS1TableAdapters.CTDDHTableAdapter();
            mAVTLabel = new System.Windows.Forms.Label();
            tENVTLabel = new System.Windows.Forms.Label();
            dVTLabel = new System.Windows.Forms.Label();
            sOLUONGTONLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds_VatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vattuGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Panel_NhapLieu)).BeginInit();
            this.Panel_NhapLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mAVTTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tENVTTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVTTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sOLUONGTONSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds_CTPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds_CTPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds_CTDDH)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barLargeButtonItem1,
            this.Btn_Them,
            this.Btn_Sua,
            this.Btn_Xoa,
            this.Btn_Ghi,
            this.Btn_PhucHoi,
            this.Btn_LamMoi,
            this.Btn_Thoat});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 30;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_Them),
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_Sua),
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_Xoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_Ghi),
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_PhucHoi),
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_LamMoi),
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_Thoat)});
            this.bar1.Text = "Tools";
            // 
            // Btn_Them
            // 
            this.Btn_Them.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Btn_Them.Caption = "Thêm";
            this.Btn_Them.Id = 12;
            this.Btn_Them.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_Them.ImageOptions.SvgImage")));
            this.Btn_Them.Name = "Btn_Them";
            this.Btn_Them.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.Btn_Them.Size = new System.Drawing.Size(94, 84);
            // 
            // Btn_Sua
            // 
            this.Btn_Sua.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Btn_Sua.Caption = "Sửa";
            this.Btn_Sua.Id = 13;
            this.Btn_Sua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_Sua.ImageOptions.SvgImage")));
            this.Btn_Sua.Name = "Btn_Sua";
            this.Btn_Sua.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.Btn_Sua.Size = new System.Drawing.Size(94, 84);
            // 
            // Btn_Xoa
            // 
            this.Btn_Xoa.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Btn_Xoa.Caption = "Xóa";
            this.Btn_Xoa.Id = 14;
            this.Btn_Xoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_Xoa.ImageOptions.SvgImage")));
            this.Btn_Xoa.Name = "Btn_Xoa";
            this.Btn_Xoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.Btn_Xoa.Size = new System.Drawing.Size(94, 84);
            // 
            // Btn_Ghi
            // 
            this.Btn_Ghi.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Btn_Ghi.Caption = "Ghi";
            this.Btn_Ghi.Id = 15;
            this.Btn_Ghi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_Ghi.ImageOptions.SvgImage")));
            this.Btn_Ghi.Name = "Btn_Ghi";
            this.Btn_Ghi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.Btn_Ghi.Size = new System.Drawing.Size(94, 84);
            // 
            // Btn_PhucHoi
            // 
            this.Btn_PhucHoi.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Btn_PhucHoi.Caption = "Phục hồi";
            this.Btn_PhucHoi.Id = 16;
            this.Btn_PhucHoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_PhucHoi.ImageOptions.SvgImage")));
            this.Btn_PhucHoi.Name = "Btn_PhucHoi";
            this.Btn_PhucHoi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.Btn_PhucHoi.Size = new System.Drawing.Size(94, 84);
            // 
            // Btn_LamMoi
            // 
            this.Btn_LamMoi.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Btn_LamMoi.Caption = "Làm mới";
            this.Btn_LamMoi.Id = 17;
            this.Btn_LamMoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_LamMoi.ImageOptions.SvgImage")));
            this.Btn_LamMoi.Name = "Btn_LamMoi";
            this.Btn_LamMoi.Size = new System.Drawing.Size(94, 84);
            // 
            // Btn_Thoat
            // 
            this.Btn_Thoat.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Btn_Thoat.Caption = "Thoát";
            this.Btn_Thoat.Id = 18;
            this.Btn_Thoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_Thoat.ImageOptions.SvgImage")));
            this.Btn_Thoat.Name = "Btn_Thoat";
            this.Btn_Thoat.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.Btn_Thoat.Size = new System.Drawing.Size(94, 84);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1918, 126);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1020);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1918, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 126);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 894);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1918, 126);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 894);
            // 
            // barLargeButtonItem1
            // 
            this.barLargeButtonItem1.Caption = "barLargeButtonItem1";
            this.barLargeButtonItem1.Id = 11;
            this.barLargeButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barLargeButtonItem1.ImageOptions.SvgImage")));
            this.barLargeButtonItem1.ImageOptions.SvgImageSize = new System.Drawing.Size(70, 70);
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // DS1
            // 
            this.DS1.DataSetName = "DS1";
            this.DS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Bds_VatTu
            // 
            this.Bds_VatTu.DataMember = "Vattu";
            this.Bds_VatTu.DataSource = this.DS1;
            // 
            // VATTUTableAdapter
            // 
            this.VATTUTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Quan_Ly_Vat_Tu.DS1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = this.VATTUTableAdapter;
            // 
            // vattuGridControl
            // 
            this.vattuGridControl.DataSource = this.Bds_VatTu;
            this.vattuGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.vattuGridControl.Location = new System.Drawing.Point(0, 126);
            this.vattuGridControl.MainView = this.gridView1;
            this.vattuGridControl.MenuManager = this.barManager1;
            this.vattuGridControl.Name = "vattuGridControl";
            this.vattuGridControl.Size = new System.Drawing.Size(1918, 220);
            this.vattuGridControl.TabIndex = 5;
            this.vattuGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAVT,
            this.colTENVT,
            this.colDVT,
            this.colSOLUONGTON});
            this.gridView1.GridControl = this.vattuGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMAVT
            // 
            this.colMAVT.FieldName = "MAVT";
            this.colMAVT.MinWidth = 25;
            this.colMAVT.Name = "colMAVT";
            this.colMAVT.Visible = true;
            this.colMAVT.VisibleIndex = 0;
            this.colMAVT.Width = 94;
            // 
            // colTENVT
            // 
            this.colTENVT.FieldName = "TENVT";
            this.colTENVT.MinWidth = 25;
            this.colTENVT.Name = "colTENVT";
            this.colTENVT.Visible = true;
            this.colTENVT.VisibleIndex = 1;
            this.colTENVT.Width = 94;
            // 
            // colDVT
            // 
            this.colDVT.FieldName = "DVT";
            this.colDVT.MinWidth = 25;
            this.colDVT.Name = "colDVT";
            this.colDVT.Visible = true;
            this.colDVT.VisibleIndex = 2;
            this.colDVT.Width = 94;
            // 
            // colSOLUONGTON
            // 
            this.colSOLUONGTON.FieldName = "SOLUONGTON";
            this.colSOLUONGTON.MinWidth = 25;
            this.colSOLUONGTON.Name = "colSOLUONGTON";
            this.colSOLUONGTON.Visible = true;
            this.colSOLUONGTON.VisibleIndex = 3;
            this.colSOLUONGTON.Width = 94;
            // 
            // Panel_NhapLieu
            // 
            this.Panel_NhapLieu.Controls.Add(sOLUONGTONLabel);
            this.Panel_NhapLieu.Controls.Add(this.sOLUONGTONSpinEdit);
            this.Panel_NhapLieu.Controls.Add(dVTLabel);
            this.Panel_NhapLieu.Controls.Add(this.dVTTextEdit);
            this.Panel_NhapLieu.Controls.Add(tENVTLabel);
            this.Panel_NhapLieu.Controls.Add(this.tENVTTextEdit);
            this.Panel_NhapLieu.Controls.Add(mAVTLabel);
            this.Panel_NhapLieu.Controls.Add(this.mAVTTextEdit);
            this.Panel_NhapLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_NhapLieu.Location = new System.Drawing.Point(0, 346);
            this.Panel_NhapLieu.Name = "Panel_NhapLieu";
            this.Panel_NhapLieu.Size = new System.Drawing.Size(1918, 674);
            this.Panel_NhapLieu.TabIndex = 6;
            // 
            // mAVTLabel
            // 
            mAVTLabel.AutoSize = true;
            mAVTLabel.Location = new System.Drawing.Point(61, 44);
            mAVTLabel.Name = "mAVTLabel";
            mAVTLabel.Size = new System.Drawing.Size(46, 16);
            mAVTLabel.TabIndex = 0;
            mAVTLabel.Text = "MAVT:";
            // 
            // mAVTTextEdit
            // 
            this.mAVTTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bds_VatTu, "MAVT", true));
            this.mAVTTextEdit.Location = new System.Drawing.Point(113, 41);
            this.mAVTTextEdit.MenuManager = this.barManager1;
            this.mAVTTextEdit.Name = "mAVTTextEdit";
            this.mAVTTextEdit.Size = new System.Drawing.Size(125, 22);
            this.mAVTTextEdit.TabIndex = 1;
            // 
            // tENVTLabel
            // 
            tENVTLabel.AutoSize = true;
            tENVTLabel.Location = new System.Drawing.Point(56, 117);
            tENVTLabel.Name = "tENVTLabel";
            tENVTLabel.Size = new System.Drawing.Size(51, 16);
            tENVTLabel.TabIndex = 2;
            tENVTLabel.Text = "TENVT:";
            // 
            // tENVTTextEdit
            // 
            this.tENVTTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bds_VatTu, "TENVT", true));
            this.tENVTTextEdit.Location = new System.Drawing.Point(113, 114);
            this.tENVTTextEdit.MenuManager = this.barManager1;
            this.tENVTTextEdit.Name = "tENVTTextEdit";
            this.tENVTTextEdit.Size = new System.Drawing.Size(125, 22);
            this.tENVTTextEdit.TabIndex = 3;
            // 
            // dVTLabel
            // 
            dVTLabel.AutoSize = true;
            dVTLabel.Location = new System.Drawing.Point(558, 44);
            dVTLabel.Name = "dVTLabel";
            dVTLabel.Size = new System.Drawing.Size(36, 16);
            dVTLabel.TabIndex = 4;
            dVTLabel.Text = "DVT:";
            // 
            // dVTTextEdit
            // 
            this.dVTTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bds_VatTu, "DVT", true));
            this.dVTTextEdit.Location = new System.Drawing.Point(600, 41);
            this.dVTTextEdit.MenuManager = this.barManager1;
            this.dVTTextEdit.Name = "dVTTextEdit";
            this.dVTTextEdit.Size = new System.Drawing.Size(125, 22);
            this.dVTTextEdit.TabIndex = 5;
            // 
            // sOLUONGTONLabel
            // 
            sOLUONGTONLabel.AutoSize = true;
            sOLUONGTONLabel.Location = new System.Drawing.Point(501, 116);
            sOLUONGTONLabel.Name = "sOLUONGTONLabel";
            sOLUONGTONLabel.Size = new System.Drawing.Size(93, 16);
            sOLUONGTONLabel.TabIndex = 6;
            sOLUONGTONLabel.Text = "SOLUONGTON:";
            // 
            // sOLUONGTONSpinEdit
            // 
            this.sOLUONGTONSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.Bds_VatTu, "SOLUONGTON", true));
            this.sOLUONGTONSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sOLUONGTONSpinEdit.Location = new System.Drawing.Point(600, 113);
            this.sOLUONGTONSpinEdit.MenuManager = this.barManager1;
            this.sOLUONGTONSpinEdit.Name = "sOLUONGTONSpinEdit";
            this.sOLUONGTONSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sOLUONGTONSpinEdit.Size = new System.Drawing.Size(125, 24);
            this.sOLUONGTONSpinEdit.TabIndex = 7;
            // 
            // Bds_CTPX
            // 
            this.Bds_CTPX.DataMember = "FK_CTPX_VatTu";
            this.Bds_CTPX.DataSource = this.Bds_VatTu;
            // 
            // CTPXTableAdapter
            // 
            this.CTPXTableAdapter.ClearBeforeFill = true;
            // 
            // Bds_CTPN
            // 
            this.Bds_CTPN.DataMember = "FK_CTPN_VatTu";
            this.Bds_CTPN.DataSource = this.Bds_VatTu;
            // 
            // CTPNTableAdapter
            // 
            this.CTPNTableAdapter.ClearBeforeFill = true;
            // 
            // Bds_CTDDH
            // 
            this.Bds_CTDDH.DataMember = "FK_CTDDH_VatTu";
            this.Bds_CTDDH.DataSource = this.Bds_VatTu;
            // 
            // CTDDHTableAdapter
            // 
            this.CTDDHTableAdapter.ClearBeforeFill = true;
            // 
            // VatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1918, 1040);
            this.Controls.Add(this.Panel_NhapLieu);
            this.Controls.Add(this.vattuGridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "VatTu";
            this.Text = "VatTu";
            this.Load += new System.EventHandler(this.VatTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds_VatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vattuGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Panel_NhapLieu)).EndInit();
            this.Panel_NhapLieu.ResumeLayout(false);
            this.Panel_NhapLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mAVTTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tENVTTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVTTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sOLUONGTONSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds_CTPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds_CTPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds_CTDDH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarLargeButtonItem Btn_Them;
        private DevExpress.XtraBars.BarLargeButtonItem Btn_Sua;
        private DevExpress.XtraBars.BarLargeButtonItem Btn_Xoa;
        private DevExpress.XtraBars.BarLargeButtonItem Btn_Ghi;
        private DevExpress.XtraBars.BarLargeButtonItem Btn_PhucHoi;
        private DevExpress.XtraBars.BarLargeButtonItem Btn_LamMoi;
        private DevExpress.XtraBars.BarLargeButtonItem Btn_Thoat;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private System.Windows.Forms.BindingSource Bds_VatTu;
        private DS1 DS1;
        private DS1TableAdapters.VattuTableAdapter VATTUTableAdapter;
        private DS1TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl vattuGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAVT;
        private DevExpress.XtraGrid.Columns.GridColumn colTENVT;
        private DevExpress.XtraGrid.Columns.GridColumn colDVT;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONGTON;
        private DevExpress.XtraEditors.PanelControl Panel_NhapLieu;
        private DevExpress.XtraEditors.SpinEdit sOLUONGTONSpinEdit;
        private DevExpress.XtraEditors.TextEdit dVTTextEdit;
        private DevExpress.XtraEditors.TextEdit tENVTTextEdit;
        private DevExpress.XtraEditors.TextEdit mAVTTextEdit;
        private System.Windows.Forms.BindingSource Bds_CTPX;
        private DS1TableAdapters.CTPXTableAdapter CTPXTableAdapter;
        private System.Windows.Forms.BindingSource Bds_CTPN;
        private DS1TableAdapters.CTPNTableAdapter CTPNTableAdapter;
        private System.Windows.Forms.BindingSource Bds_CTDDH;
        private DS1TableAdapters.CTDDHTableAdapter CTDDHTableAdapter;
    }
}