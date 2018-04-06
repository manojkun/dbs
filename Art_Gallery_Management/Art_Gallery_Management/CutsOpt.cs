using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Art_Gallery_Management
{
    public partial class CutsOpt : Form
    {
        public CutsOpt()
        {
            InitializeComponent();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.LightPink;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.LightGreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form cf = new CustForm();
            this.Hide();
            cf.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.DimGray;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Gray;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.DimGray;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form lf = new CustLogin();
            this.Hide();
            lf.Show();
        }
    }
}
