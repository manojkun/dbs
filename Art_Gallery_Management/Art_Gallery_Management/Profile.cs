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
    public partial class Profile : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        String id;

        public Profile(String cus_id)
        {
            InitializeComponent();
            id = cus_id;
        }

        public void db_connect()
        {
            String oradb = "Data Source=DESKTOP-6VLO37E;User ID=orcl;Password=oppai";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
         
           db_connect();
            comm = new OracleCommand();
            comm.CommandText = "select P_id from Painting where P_id not in ( select P_id from Purchase)";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Painting");
            dt = ds.Tables["Painting"];
            comboBox1.DataSource = dt.DefaultView;
            comboBox1.DisplayMember = "P_id";
            listBox1.DataSource = dt.DefaultView;
            listBox1.DisplayMember = "P_id";
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pid = comboBox1.GetItemText(comboBox1.SelectedItem);
            db_connect();
            OracleCommand cum = new OracleCommand();
            cum.Connection = conn;
            cum.CommandText = "insert into Purchase values('" + id + "','" + pid + "' , SYSDATE)";
            cum.CommandType = CommandType.Text;
            cum.ExecuteNonQuery();
            MessageBox.Show("Purchased SuccessFully");
            conn.Close();
            Form f = new Profile(id);
            this.Close();
            f.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            db_connect();
            comm = new OracleCommand();
            //string pid = listBox1.SelectedItem.ToString();
            string pid = comboBox1.GetItemText(comboBox1.SelectedItem);
            label2.Text = pid;
            comm.CommandText = "select P_name from Painting where P_id ="+pid;
            comm.CommandType = CommandType.Text;
            
       /*   OracleParameter p1 = new OracleParameter();
            p1.ParameterName = "para";
            p1.DbType = DbType.Int64;
            label1.Text = comboBox1.SelectedItem.ToString();
            Int64 ans = 1000;//Convert.ToInt64(comboBox1.SelectedItem.ToString());

            p1.Value = ans;
            comm.Parameters.Add(p1);*/
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Painting");
            dt = ds.Tables["Painting"];
            dr = dt.Rows[i];
            label2.Text = dr["P_name"].ToString();
            imgchange(label2.Text);
            likes(pid);
            conn.Close();
        }

        public void imgchange(String iname)
        {
            Image image1 = Image.FromFile("C:\\Users\\Manoj\\Desktop\\"+iname+".jpg");
            pictureBox1.Image = image1;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            db_connect();
            comm = new OracleCommand();
            string pid = listBox1.GetItemText(listBox1.SelectedItem);
            //string pid = comboBox1.GetItemText(comboBox1.SelectedItem);
            label2.Text = pid;
            comm.CommandText = "select P_name from Painting where P_id =" + pid;
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Painting");
            dt = ds.Tables["Painting"];
            dr = dt.Rows[i];
            label2.Text = dr["P_name"].ToString();
            imgchange(label2.Text);
            likes(pid);
            conn.Close();
        }
        public void likes(string pid)
        {
            comm = new OracleCommand();
            comm.CommandText = "select count(Cust_id) cnt from likes where P_id=" + pid;
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "likes");
            dt = ds.Tables["likes"];
            dr = dt.Rows[i];
            label1.Text = dr["cnt"].ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string pid = comboBox1.GetItemText(comboBox1.SelectedItem);
            db_connect();
            OracleCommand cum = new OracleCommand();
            cum.Connection = conn;
            cum.CommandText = "insert into likes values('" + id + "','" + pid + "')";
            cum.CommandType = CommandType.Text;
            try
            {
                cum.ExecuteNonQuery();
            }
            catch (OracleException oe)
            {
                MessageBox.Show("Already Liked The Image");
            }
            likes(pid);
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f1 = new Form1();
            this.Close();
            f1.Show();
        }
        
    }
}
