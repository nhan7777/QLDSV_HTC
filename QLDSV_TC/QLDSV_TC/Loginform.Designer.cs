
namespace QLDSV_TC
{
    partial class Loginform
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
            System.Windows.Forms.Label tENPMLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loginform));
            this.qLDSV_TC_HOME = new QLDSV_TC.QLDSV_TC_HOME();
            this.v_DSPHANMANHBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.v_DSPHANMANHTableAdapter1 = new QLDSV_TC.QLDSV_TC_HOMETableAdapters.v_DSPHANMANHTableAdapter();
            this.tableAdapterManager1 = new QLDSV_TC.QLDSV_TC_HOMETableAdapters.TableAdapterManager();
            this.tENPMComboBoxPHANMANH = new System.Windows.Forms.ComboBox();
            this.textBoxToUsername = new System.Windows.Forms.TextBox();
            this.textBoxToPass = new System.Windows.Forms.TextBox();
            this.buttonToLogin = new System.Windows.Forms.Button();
            this.buttonToExit = new System.Windows.Forms.Button();
            this.vDSLTCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_DSLTCTableAdapter = new QLDSV_TC.QLDSV_TC_HOMETableAdapters.v_DSLTCTableAdapter();
            this.vDSLTCBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            tENPMLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSV_TC_HOME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DSPHANMANHBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSLTCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSLTCBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // qLDSV_TC_HOME
            // 
            this.qLDSV_TC_HOME.DataSetName = "QLDSV_TC_HOME";
            this.qLDSV_TC_HOME.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_DSPHANMANHBindingSource1
            // 
            this.v_DSPHANMANHBindingSource1.DataMember = "v_DSPHANMANH";
            this.v_DSPHANMANHBindingSource1.DataSource = this.qLDSV_TC_HOME;
            // 
            // v_DSPHANMANHTableAdapter1
            // 
            this.v_DSPHANMANHTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.CT_DONGHOCPHITableAdapter = null;
            this.tableAdapterManager1.DANGKYTableAdapter = null;
            this.tableAdapterManager1.GIANGVIENTableAdapter = null;
            this.tableAdapterManager1.HOCPHITableAdapter = null;
            this.tableAdapterManager1.KHOATableAdapter = null;
            this.tableAdapterManager1.LOPTableAdapter = null;
            this.tableAdapterManager1.LOPTINCHITableAdapter = null;
            this.tableAdapterManager1.MONHOCTableAdapter = null;
            this.tableAdapterManager1.SINHVIENTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = QLDSV_TC.QLDSV_TC_HOMETableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tENPMLabel
            // 
            tENPMLabel.AutoSize = true;
            tENPMLabel.Font = new System.Drawing.Font("Tahoma", 9.25F);
            tENPMLabel.ForeColor = System.Drawing.Color.Navy;
            tENPMLabel.Location = new System.Drawing.Point(91, 52);
            tENPMLabel.Name = "tENPMLabel";
            tENPMLabel.Size = new System.Drawing.Size(82, 16);
            tENPMLabel.TabIndex = 1;
            tENPMLabel.Text = "PHÂN QUYỀN";
            // 
            // tENPMComboBoxPHANMANH
            // 
            this.tENPMComboBoxPHANMANH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.v_DSPHANMANHBindingSource1, "TENPM", true));
            this.tENPMComboBoxPHANMANH.FormattingEnabled = true;
            this.tENPMComboBoxPHANMANH.Items.AddRange(new object[] {
            "CÔNG NGHỆ THÔNG TIN",
            "VIỄN THÔNG ",
            "PHÒNG KẾ TOÁN"});
            this.tENPMComboBoxPHANMANH.Location = new System.Drawing.Point(186, 49);
            this.tENPMComboBoxPHANMANH.Name = "tENPMComboBoxPHANMANH";
            this.tENPMComboBoxPHANMANH.Size = new System.Drawing.Size(121, 21);
            this.tENPMComboBoxPHANMANH.TabIndex = 2;
            this.tENPMComboBoxPHANMANH.SelectedIndexChanged += new System.EventHandler(this.tENPMComboBoxPHANMANH_SelectedIndexChanged);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 9.25F);
            label3.ForeColor = System.Drawing.Color.Navy;
            label3.Location = new System.Drawing.Point(91, 93);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 16);
            label3.TabIndex = 1;
            label3.Text = "USERNAME";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 9.25F);
            label4.ForeColor = System.Drawing.Color.Navy;
            label4.Location = new System.Drawing.Point(91, 132);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(76, 16);
            label4.TabIndex = 1;
            label4.Text = "PASSWORD";
            // 
            // textBoxToUsername
            // 
            this.textBoxToUsername.Location = new System.Drawing.Point(186, 91);
            this.textBoxToUsername.Name = "textBoxToUsername";
            this.textBoxToUsername.Size = new System.Drawing.Size(163, 21);
            this.textBoxToUsername.TabIndex = 3;
            // 
            // textBoxToPass
            // 
            this.textBoxToPass.Location = new System.Drawing.Point(186, 130);
            this.textBoxToPass.Name = "textBoxToPass";
            this.textBoxToPass.PasswordChar = '*';
            this.textBoxToPass.Size = new System.Drawing.Size(163, 21);
            this.textBoxToPass.TabIndex = 3;
            this.textBoxToPass.UseSystemPasswordChar = true;
            // 
            // buttonToLogin
            // 
            this.buttonToLogin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToLogin.ForeColor = System.Drawing.Color.Blue;
            this.buttonToLogin.Location = new System.Drawing.Point(94, 198);
            this.buttonToLogin.Name = "buttonToLogin";
            this.buttonToLogin.Size = new System.Drawing.Size(106, 32);
            this.buttonToLogin.TabIndex = 4;
            this.buttonToLogin.Text = "LOGIN";
            this.buttonToLogin.UseVisualStyleBackColor = true;
            this.buttonToLogin.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonToExit
            // 
            this.buttonToExit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToExit.ForeColor = System.Drawing.Color.Red;
            this.buttonToExit.Location = new System.Drawing.Point(242, 198);
            this.buttonToExit.Name = "buttonToExit";
            this.buttonToExit.Size = new System.Drawing.Size(107, 32);
            this.buttonToExit.TabIndex = 4;
            this.buttonToExit.Text = "EXIT";
            this.buttonToExit.UseVisualStyleBackColor = true;
            this.buttonToExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // vDSLTCBindingSource
            // 
            this.vDSLTCBindingSource.DataMember = "v_DSLTC";
            this.vDSLTCBindingSource.DataSource = this.qLDSV_TC_HOME;
            // 
            // v_DSLTCTableAdapter
            // 
            this.v_DSLTCTableAdapter.ClearBeforeFill = true;
            // 
            // vDSLTCBindingSource1
            // 
            this.vDSLTCBindingSource1.DataMember = "v_DSLTC";
            this.vDSLTCBindingSource1.DataSource = this.qLDSV_TC_HOME;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "v_DSPHANMANH";
            this.bindingSource1.DataSource = this.qLDSV_TC_HOME;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "v_DSPHANMANH";
            this.bindingSource2.DataSource = this.qLDSV_TC_HOME;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(186, 167);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "SINH VIÊN";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Loginform
            // 
            this.ClientSize = new System.Drawing.Size(444, 255);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.buttonToExit);
            this.Controls.Add(this.buttonToLogin);
            this.Controls.Add(this.textBoxToPass);
            this.Controls.Add(this.textBoxToUsername);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(tENPMLabel);
            this.Controls.Add(this.tENPMComboBoxPHANMANH);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Loginform.IconOptions.LargeImage")));
            this.Name = "Loginform";
            this.Load += new System.EventHandler(this.Loginform_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.qLDSV_TC_HOME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DSPHANMANHBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSLTCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSLTCBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private QLDSV_TCDataSet qLDSV_TCDataSet;
        private System.Windows.Forms.BindingSource v_DSPHANMANHBindingSource;
        private QLDSV_TCDataSetTableAdapters.v_DSPHANMANHTableAdapter v_DSPHANMANHTableAdapter;
        private QLDSV_TCDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox tENPMComboBox;
        private System.Windows.Forms.BindingSource vDSPHANMANHBindingSource;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.RadioButton radioButtonSV;
        private System.Windows.Forms.Button buttonEXIT;
        private QLDSV_TC_HOME qLDSV_TC_HOME;
        private System.Windows.Forms.BindingSource v_DSPHANMANHBindingSource1;
        private QLDSV_TC_HOMETableAdapters.v_DSPHANMANHTableAdapter v_DSPHANMANHTableAdapter1;
        private QLDSV_TC_HOMETableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.ComboBox tENPMComboBoxPHANMANH;
        private System.Windows.Forms.TextBox textBoxToUsername;
        private System.Windows.Forms.TextBox textBoxToPass;
        private System.Windows.Forms.Button buttonToLogin;
        private System.Windows.Forms.Button buttonToExit;
        private System.Windows.Forms.BindingSource vDSLTCBindingSource;
        private QLDSV_TC_HOMETableAdapters.v_DSLTCTableAdapter v_DSLTCTableAdapter;
        private System.Windows.Forms.BindingSource vDSLTCBindingSource1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

