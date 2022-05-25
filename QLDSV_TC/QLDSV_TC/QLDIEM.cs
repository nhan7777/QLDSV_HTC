using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
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

namespace QLDSV_TC
{
    public partial class QLDIEM : DevExpress.XtraEditors.XtraForm
    {
        DataTable Dt_Bangdiem = new DataTable();
        String maltc;
        public QLDIEM()
        {
            InitializeComponent();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.sP_DSLTCTableAdapter.Fill(this.dSSite1.SP_DSLTC, cbKhoa.SelectedValue.ToString().Trim(), cbNK.SelectedValue.ToString(), new System.Nullable<int>(((int)(System.Convert.ChangeType(cbHK.SelectedValue, typeof(int))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void QLDIEM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSSite1.NIENKHOA_HOCKY' table. You can move, or remove it, as needed.
            this.nIENKHOA_HOCKYTableAdapter.Fill(this.dSSite1.NIENKHOA_HOCKY);
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet.KHOA' table. You can move, or remove it, as needed.
            this.kHOATableAdapter.Fill(this.qLDSV_TCDataSet.KHOA);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            maltc = ((DataRowView)bdsDSLTC[bdsDSLTC.Position])["MALTC"].ToString();
            string strLenh = "EXEC SP_BDMHLTC " + maltc;
            Dt_Bangdiem = Program.ExecSqlDataTable(strLenh);
            Dt_Bangdiem.Columns.Add(new DataColumn("HET MON", typeof(float)));
            gc_Bangdiem.DataSource = Dt_Bangdiem;
            gridView2.Columns["MASV"].OptionsColumn.ReadOnly = true;
            gridView2.Columns["HOTEN"].OptionsColumn.ReadOnly = true;
            Dt_Bangdiem.Columns["HET MON"].Expression = "[DIEM_CC]*0.1+[DIEM_GK]*0.3+[DIEM_CK]*0.6";
            //gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            //{
            //    Caption = "DIEM HETMON",
            //    FieldName = "diemHetmon",
            //    Visible = true
            //});

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MALTC", typeof(int));
            dt.Columns.Add("MASV", typeof(string));
            dt.Columns.Add("DIEM_CC", typeof(int));
            dt.Columns.Add("DIEM_GK", typeof(float));
            dt.Columns.Add("DIEM_CK", typeof(float));
            int intmaltc = int.Parse(maltc);
            for(int i = 0; i <Dt_Bangdiem.Rows.Count; i++)
            {
                dt.Rows.Add(intmaltc, Dt_Bangdiem.Rows[i]["MASV"], Dt_Bangdiem.Rows[i]["DIEM_CC"], Dt_Bangdiem.Rows[i]["DIEM_GK"], Dt_Bangdiem.Rows[i]["DIEM_CK"]);
            }
            SqlParameter para = new SqlParameter();
            para.SqlDbType = SqlDbType.Structured;
            para.TypeName = "dbo.TYPE_DANGKY";
            para.ParameterName = "@DIEMTHI";
            para.Value = dt;
            Program.KetNoi();
            try
            {
                SqlCommand Sqlcmd = new SqlCommand("SP_UPDATE_DIEM", Program.conn);
                Sqlcmd.Parameters.Clear();
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.Add(para);
                Sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật điểm thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu. \nBạn xem lại tên Sever của Publisher, và tên CSDL trong chuỗi kết nối.\n" + ex.Message);
                return;
            }
            

        }
    }
}