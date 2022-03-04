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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
            #region
            SqlConnection con = new SqlConnection(DAL.GetConnectionString());

            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO USERS " +
                "VALUES (@username,@password,@email)", con);

            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            cmd.Parameters.AddWithValue("@email", textBox3.Text);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Success");

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }
            #endregion

        }


    }
}
