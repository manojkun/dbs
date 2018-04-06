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
    public partial class CustForm : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public CustForm()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void db_connect()
        {
            String oradb = "Data Source=DESKTOP-6VLO37E;User ID=orcl;Password=oppai";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db_connect();
            OracleCommand cum = new OracleCommand();
            cum.Connection = conn;
            cum.CommandText = "insert into Customer values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text + "')";
            cum.CommandType = CommandType.Text;
            cum.ExecuteNonQuery();
            MessageBox.Show("Registered Successfully");
            this.Hide();
            Form cl = new CustLogin();
            cl.Show();
            conn.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
