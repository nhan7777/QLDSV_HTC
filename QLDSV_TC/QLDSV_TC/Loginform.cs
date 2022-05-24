﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class Loginform : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection conn_publisher = new SqlConnection();
        private bool isSinhVien = false;
        public Loginform()
        {
            InitializeComponent();
        }

        private void LayDSPM(String cmd)
        {
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            Program.bds_dspm.DataSource = dt;
            tENPMComboBox.DataSource = Program.bds_dspm;
            tENPMComboBox.DisplayMember = "TENPM";
            tENPMComboBox.ValueMember = "TENSERVER";
        }

        private int KetNoi_CSDLGOC()
        {
            if (conn_publisher != null && conn_publisher.State == ConnectionState.Open)
                conn_publisher.Close();
            try
            {
                conn_publisher.ConnectionString = Program.connstr_publicsher;
                conn_publisher.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu. \nBạn xem lại tên Sever của Publisher, và tên CSDL trong chuỗi kết nối.\n" + e.Message);
                return 0;
            }
        }

        private void Loginform_Load_1(object sender, EventArgs e)
        {
            /*// TODO: This line of code loads data into the 'qLDSV_TC_HOME.v_DSLTC' table. You can move, or remove it, as needed.
            this.v_DSLTCTableAdapter.Fill(this.qLDSV_TC_HOME.v_DSLTC);
            // TODO: This line of code loads data into the 'qLDSV_TC_HOME.v_DSPHANMANH' table. You can move, or remove it, as needed.
            this.v_DSPHANMANHTableAdapter1.Fill(this.qLDSV_TC_HOME.v_DSPHANMANH);*/

            if (KetNoi_CSDLGOC() == 0) return;
            LayDSPM("select * from v_DSPHANMANH");

        }

        /// <summary>
        /// Button Login
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (isSinhVien == false)
            {
                if (textBoxToUsername.Text.Trim() == "" || textBoxToPass.Text.Trim() == "")
                {
                    MessageBox.Show("Login name và mật khẩu không được trống", "", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                if (textBoxToUsername.Text.Trim() == "")
                {
                    MessageBox.Show("Login name không được trống", "", MessageBoxButtons.OK);
                    return;
                }
            }

            if (isSinhVien == true)
            {
                Program.mlogin = "svkn";
                Program.password = "123";
                if (Program.KetNoi() == 0) return;
            }
            else
            {
                Program.mlogin = textBoxToUsername.Text; Program.password = textBoxToPass.Text;
                if (Program.KetNoi() == 0) return;
            }

            /// get user and login
            Program.mlogin = textBoxToUsername.Text;
            Program.password = textBoxToPass.Text;

            //
            Program.mChinhanh = tENPMComboBox.SelectedIndex;
            Program.loginDN = Program.mlogin;
            Program.passwordDN = Program.password;

        }

        private void tENPMComboBoxPHANMANH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.severname = tENPMComboBox.SelectedValue.ToString();
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close(); Program.mainForm.Close();
        }
    }
}
