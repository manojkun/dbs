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
    public partial class MProfile : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        String id;

        public MProfile(String M_id)
        {
            InitializeComponent();
            id = M_id;
        }

        private void MProfile_Load(object sender, EventArgs e)
        {

        }

        public void db_connect()
        {
            String oradb = "Data Source=DESKTOP-6VLO37E;User ID=orcl;Password=oppai";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox1.Visible = true;
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            db_connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from Artist where Artist_name='" + textBox1.Text + "'";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            dt = new DataTable();
            da.Fill(dt);
            int t = dt.Rows.Count;
            if (t >= 1)
            {
                    Form lg = new Paint(id);
                    lg.Show();
            }
            else
            {
                Form artin = new Artist(id);
                artin.Show();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form cl = new Clean(id);
            cl.Show();
        }
    }
}
