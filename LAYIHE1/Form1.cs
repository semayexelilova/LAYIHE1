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

namespace LAYIHE1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
            #region
            string username = textBox1.Text;
            SqlConnection con = new SqlConnection(DAL.GetConnectionString());

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT (*) from USERS where username='"+username+"'" , con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string dr = cmd.ExecuteScalar().ToString();
            //MessageBox.Show(dr);

            if (dr=="1")
            {
                MessageBox.Show("password is true");
            }

            else
            {
                MessageBox.Show("password or username is false");
            }
            #endregion

        }
    }
}
