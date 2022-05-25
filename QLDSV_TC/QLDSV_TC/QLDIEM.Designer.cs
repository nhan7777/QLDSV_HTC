
namespace QLDSV_TC
{
    partial class QLDIEM
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbKhoa = new System.Windows.Forms.ComboBox();
            this.kHOABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLDSV_TCDataSet = new QLDSV_TC.QLDSV_TCDataSet();
            this.cbNK = new System.Windows.Forms.ComboBox();
            this.nIENKHOAHOCKYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSSite1 = new QLDSV_TC.DSSite1();
            this.cbHK = new System.Windows.Forms.ComboBox();
            this.nIENKHOAHOCKYBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bdsDSLTC = new System.Windows.Forms.BindingSource(this.components);
            this.sP_DSLTCTableAdapter = new QLDSV_TC.DSSite1TableAdapters.SP_DSLTCTableAdapter();
            this.tableAdapterManager = new QLDSV_TC.DSSite1TableAdapters.TableAdapterManager();
            this.sP_DSLTCGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMALTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNHOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOSVDANGKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTaiLTC = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.kHOATableAdapter = new QLDSV_TC.QLDSV_TCDataSetTableAdapters.KHOATableAdapter();
            this.nIENKHOA_HOCKYTableAdapter = new QLDSV_TC.DSSite1TableAdapters.NIENKHOA_HOCKYTableAdapter();
            this.gc_Bangdiem = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.kHOABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSV_TCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIENKHOAHOCKYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSSite1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIENKHOAHOCKYBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSLTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_DSLTCGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Bangdiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khoa :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Niên khoá :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Học kì :";
            // 
            // cbKhoa
            // 
            this.cbKhoa.DataSource = this.kHOABindingSource;
            this.cbKhoa.DisplayMember = "TENKHOA";
            this.cbKhoa.FormattingEnabled = true;
            this.cbKhoa.Location = new System.Drawing.Point(67, 23);
            this.cbKhoa.Name = "cbKhoa";
            this.cbKhoa.Size = new System.Drawing.Size(210, 24);
            this.cbKhoa.TabIndex = 3;
            this.cbKhoa.ValueMember = "MAKHOA";
            // 
            // kHOABindingSource
            // 
            this.kHOABindingSource.DataMember = "KHOA";
            this.kHOABindingSource.DataSource = this.qLDSV_TCDataSet;
            // 
            // qLDSV_TCDataSet
            // 
            this.qLDSV_TCDataSet.DataSetName = "QLDSV_TCDataSet";
            this.qLDSV_TCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbNK
            // 
            this.cbNK.DataSource = this.nIENKHOAHOCKYBindingSource;
            this.cbNK.DisplayMember = "NIENKHOA";
            this.cbNK.FormattingEnabled = true;
            this.cbNK.Location = new System.Drawing.Point(366, 23);
            this.cbNK.Name = "cbNK";
            this.cbNK.Size = new System.Drawing.Size(121, 24);
            this.cbNK.TabIndex = 4;
            this.cbNK.ValueMember = "NIENKHOA";
            // 
            // nIENKHOAHOCKYBindingSource
            // 
            this.nIENKHOAHOCKYBindingSource.DataMember = "NIENKHOA_HOCKY";
            this.nIENKHOAHOCKYBindingSource.DataSource = this.dSSite1;
            // 
            // dSSite1
            // 
            this.dSSite1.DataSetName = "DSSite1";
            this.dSSite1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbHK
            // 
            this.cbHK.DataSource = this.nIENKHOAHOCKYBindingSource1;
            this.cbHK.DisplayMember = "HOCKY";
            this.cbHK.FormattingEnabled = true;
            this.cbHK.Location = new System.Drawing.Point(557, 23);
            this.cbHK.Name = "cbHK";
            this.cbHK.Size = new System.Drawing.Size(121, 24);
            this.cbHK.TabIndex = 5;
            this.cbHK.ValueMember = "HOCKY";
            // 
            // nIENKHOAHOCKYBindingSource1
            // 
            this.nIENKHOAHOCKYBindingSource1.DataMember = "NIENKHOA_HOCKY";
            this.nIENKHOAHOCKYBindingSource1.DataSource = this.dSSite1;
            // 
            // bdsDSLTC
            // 
            this.bdsDSLTC.DataMember = "SP_DSLTC";
            this.bdsDSLTC.DataSource = this.dSSite1;
            // 
            // sP_DSLTCTableAdapter
            // 
            this.sP_DSLTCTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.DANGKYTableAdapter = null;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.LOPTINCHITableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLDSV_TC.DSSite1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sP_DSLTCGridControl
            // 
            this.sP_DSLTCGridControl.DataSource = this.bdsDSLTC;
            this.sP_DSLTCGridControl.Location = new System.Drawing.Point(16, 98);
            this.sP_DSLTCGridControl.MainView = this.gridView1;
            this.sP_DSLTCGridControl.Name = "sP_DSLTCGridControl";
            this.sP_DSLTCGridControl.Size = new System.Drawing.Size(1208, 198);
            this.sP_DSLTCGridControl.TabIndex = 8;
            this.sP_DSLTCGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMALTC,
            this.colTENMH,
            this.colNHOM,
            this.colHOTEN,
            this.colSOSVDANGKY});
            this.gridView1.GridControl = this.sP_DSLTCGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMALTC
            // 
            this.colMALTC.FieldName = "MALTC";
            this.colMALTC.MinWidth = 25;
            this.colMALTC.Name = "colMALTC";
            this.colMALTC.Visible = true;
            this.colMALTC.VisibleIndex = 0;
            this.colMALTC.Width = 94;
            // 
            // colTENMH
            // 
            this.colTENMH.FieldName = "TENMH";
            this.colTENMH.MinWidth = 25;
            this.colTENMH.Name = "colTENMH";
            this.colTENMH.Visible = true;
            this.colTENMH.VisibleIndex = 1;
            this.colTENMH.Width = 94;
            // 
            // colNHOM
            // 
            this.colNHOM.FieldName = "NHOM";
            this.colNHOM.MinWidth = 25;
            this.colNHOM.Name = "colNHOM";
            this.colNHOM.Visible = true;
            this.colNHOM.VisibleIndex = 2;
            this.colNHOM.Width = 94;
            // 
            // colHOTEN
            // 
            this.colHOTEN.FieldName = "HOTEN";
            this.colHOTEN.MinWidth = 25;
            this.colHOTEN.Name = "colHOTEN";
            this.colHOTEN.Visible = true;
            this.colHOTEN.VisibleIndex = 3;
            this.colHOTEN.Width = 94;
            // 
            // colSOSVDANGKY
            // 
            this.colSOSVDANGKY.FieldName = "SOSVDANGKY";
            this.colSOSVDANGKY.MinWidth = 25;
            this.colSOSVDANGKY.Name = "colSOSVDANGKY";
            this.colSOSVDANGKY.Visible = true;
            this.colSOSVDANGKY.VisibleIndex = 4;
            this.colSOSVDANGKY.Width = 94;
            // 
            // btnTaiLTC
            // 
            this.btnTaiLTC.Location = new System.Drawing.Point(705, 26);
            this.btnTaiLTC.Name = "btnTaiLTC";
            this.btnTaiLTC.Size = new System.Drawing.Size(113, 23);
            this.btnTaiLTC.TabIndex = 9;
            this.btnTaiLTC.Text = "Tải lớp TC";
            this.btnTaiLTC.UseVisualStyleBackColor = true;
            this.btnTaiLTC.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(842, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Nhập điểm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(948, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Ghi";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // kHOATableAdapter
            // 
            this.kHOATableAdapter.ClearBeforeFill = true;
            // 
            // nIENKHOA_HOCKYTableAdapter
            // 
            this.nIENKHOA_HOCKYTableAdapter.ClearBeforeFill = true;
            // 
            // gc_Bangdiem
            // 
            this.gc_Bangdiem.Location = new System.Drawing.Point(16, 315);
            this.gc_Bangdiem.MainView = this.gridView2;
            this.gc_Bangdiem.Name = "gc_Bangdiem";
            this.gc_Bangdiem.Size = new System.Drawing.Size(1208, 200);
            this.gc_Bangdiem.TabIndex = 12;
            this.gc_Bangdiem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gc_Bangdiem;
            this.gridView2.Name = "gridView2";
            // 
            // QLDIEM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 561);
            this.Controls.Add(this.gc_Bangdiem);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTaiLTC);
            this.Controls.Add(this.sP_DSLTCGridControl);
            this.Controls.Add(this.cbHK);
            this.Controls.Add(this.cbNK);
            this.Controls.Add(this.cbKhoa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QLDIEM";
            this.Text = "QLDIEM";
            this.Load += new System.EventHandler(this.QLDIEM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kHOABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSV_TCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIENKHOAHOCKYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSSite1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIENKHOAHOCKYBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSLTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_DSLTCGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Bangdiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbKhoa;
        private System.Windows.Forms.ComboBox cbNK;
        private System.Windows.Forms.ComboBox cbHK;
        private QLDSV_TC_HOME dSSite1;
        private System.Windows.Forms.BindingSource bdsDSLTC;
        private QLDSV_TC_HOMETableAdapters.SP_DSLTCTableAdapter sP_DSLTCTableAdapter;
        private QLDSV_TC_HOMETableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl sP_DSLTCGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnTaiLTC;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private QLDSV_TCDataSet qLDSV_TCDataSet;
        private System.Windows.Forms.BindingSource kHOABindingSource;
        private QLDSV_TCDataSetTableAdapters.KHOATableAdapter kHOATableAdapter;
        private System.Windows.Forms.BindingSource nIENKHOAHOCKYBindingSource;
        private QLDSV_TC_HOMETableAdapters.NIENKHOA_HOCKYTableAdapter nIENKHOA_HOCKYTableAdapter;
        private System.Windows.Forms.BindingSource nIENKHOAHOCKYBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colMALTC;
        private DevExpress.XtraGrid.Columns.GridColumn colTENMH;
        private DevExpress.XtraGrid.Columns.GridColumn colNHOM;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOSVDANGKY;
        private DevExpress.XtraGrid.GridControl gc_Bangdiem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}