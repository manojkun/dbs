using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Art_Gallery_Management
{
    public partial class CustLogin : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public CustLogin()
        {
            InitializeComponent();
        }

        public void db_connect()
        {
            String oradb = "Data Source=DESKTOP-6VLO37E;User ID=orcl;Password=oppai";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db_connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from Customer where Cust_id='"+textBox1.Text+"' and Password='"+textBox2.Text+"'";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            dt = new DataTable();
            da.Fill(dt);
            int t = dt.Rows.Count;
            String pr = textBox1.Text;
            if (t == 1)
            {
                DialogResult dr = MessageBox.Show("Logged in Successfully");
                if (dr == DialogResult.OK)
                {
                    Form lg = new Profile(pr);
                    lg.Show();
                }
            }
            else {
                DialogResult dr = MessageBox.Show("Login Failed , Please Try Again");
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CustLogin_Load(object sender, EventArgs e)
        {

        }

    }
}
