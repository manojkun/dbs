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
    public partial class Artist : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        String id;

        public Artist(String M_id)
        {
            InitializeComponent();
            id = M_id;
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
            OracleCommand cum = new OracleCommand();
            cum.Connection = conn;
            cum.CommandText = "insert into Artist (Artist_name,Nationality) values('" + textBox2.Text + "','" + textBox3.Text + "')";
            cum.CommandType = CommandType.Text;
            cum.ExecuteNonQuery();
            MessageBox.Show("Artist Inserted Into DB!!");
            conn.Close();
            this.Hide();
            Form pf = new Paint(id);
            pf.Show();
        }
    }
}
