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
    public partial class Stats : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        String id, Artist;
        int i = 0;

        public void db_connect()
        {
            String oradb = "Data Source=DESKTOP-6VLO37E;User ID=orcl;Password=oppai";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        public Stats(String M_id)
        {
            InitializeComponent();
            id = M_id;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Stats_Load(object sender, EventArgs e)
        {
            db_connect();
            comm = new OracleCommand();
            comm.CommandText = "select count(Cust_id) likes,P_Id,P_name  from likes natural right outer join painting group by P_id,P_name";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "table");
            dt = ds.Tables["table"];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "table";
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form k = new MProfile(id);
            k.Show();
            this.Close();
        }
    }
}
