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
    public partial class Paint : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        String id,Artist;
        int i = 0;

        public Paint(String M_id,String name)
        {
            InitializeComponent();
            id = M_id;
            Artist = name;
            db_connect();
            comm = new OracleCommand();
            comm.CommandText = "select Artist_id from Artist where Artist_name='" + Artist + "'";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            dt = new DataTable();
            da.Fill(dt);
            int t = dt.Rows.Count;
            dr = dt.Rows[i];
            textBox4.Text = dr["Artist_id"].ToString();
            conn.Close();
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
            cum.CommandText = "insert into Painting (P_name,Price,Year,Artist_id) values('" + textBox2.Text + "','" + textBox3.Text +  "','"  + textBox1.Text + "','" + textBox4.Text +"')";
            cum.CommandType = CommandType.Text;
            cum.ExecuteNonQuery();
            String pname = textBox2.Text;

            comm = new OracleCommand();
            comm.CommandText = "select P_id from Painting where P_name ='"+pname+"'";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            dt = new DataTable();
            da.Fill(dt);
            int t = dt.Rows.Count;
            dr = dt.Rows[i];
            string pid = dr["P_id"].ToString();

            cum.Connection = conn;
            cum.CommandText = "insert into Adds values(" + pid + "," + id + ", SYSDATE)";
            cum.CommandType = CommandType.Text;
            cum.ExecuteNonQuery();

            MessageBox.Show("Painting Added!!");
            conn.Close();
            this.Hide();
            Form mpf = new MProfile(id);
            mpf.Show();
        }
    }
}
