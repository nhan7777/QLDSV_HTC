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

namespace QLDSV_TC
{
    public partial class QLSINHVIEN : DevExpress.XtraEditors.XtraForm
    {
        public QLSINHVIEN()
        {
            InitializeComponent();
        }

        private void sINHVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sINHVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLDSV_TC_HOME);

        }

        private void QLSINHVIEN_Load(object sender, EventArgs e)
        {
            qLDSV_TC_HOME.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLDSV_TC_HOME.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.qLDSV_TC_HOME.LOP);
            // TODO: This line of code loads data into the 'qLDSV_TC_HOME.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Fill(this.qLDSV_TC_HOME.SINHVIEN);

        }

        private void lOPGridControl_Click(object sender, EventArgs e)
        {

        }
    }
}