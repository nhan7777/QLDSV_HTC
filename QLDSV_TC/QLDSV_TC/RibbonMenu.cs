using DevExpress.XtraBars;
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
    public partial class RibbonMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonMenu()
        {
            InitializeComponent();
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        /// <summary>
        /// Câu lệnh mở form con (SINH VIÊN) trên ribbon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(QLSINHVIEN));
            if (f != null) f.Activate();
            else
            {
                QLSINHVIEN frm = new QLSINHVIEN();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void barButtonItemQLGV_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(QLSINHVIEN));
            if (f != null) f.Activate();
            else
            {
                QLGIANGVIEN frm = new QLGIANGVIEN();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItemQLLTC_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(QLDSLTC));
            if (f != null) f.Activate();
            else
            {
                QLDSLTC frm = new QLDSLTC();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void barButtonItemQLLOPHOC_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(QLLopHoc));
            if (f != null) f.Activate();
            else
            {
                QLLopHoc frm = new QLLopHoc();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void barButtonItemQLĐIỂM_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(QLDIEM));
            if (f != null) f.Activate();
            else
            {
                QLDIEM frm = new QLDIEM();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void barButtonItemQLHocPhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(HOCPHI));
            if (f != null) f.Activate();
            else
            {
                HOCPHI frm = new HOCPHI();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void barButtonItemDANGKYLTC_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(DANGKY));
            if (f != null) f.Activate();
            else
            {
                DANGKY frm = new DANGKY();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void barButtonItemQLDSTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(QLDSTK));
            if (f != null) f.Activate();
            else
            {
                QLDSTK frm = new QLDSTK();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void barButtonItemQLTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(THONGTINTK));
            if (f != null) f.Activate();
            else
            {
                THONGTINTK frm = new THONGTINTK();
                frm.MdiParent = this;
                frm.Show();
            }
            
        }

        private void barButtonItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }

}