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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(DAL.GetConnectionString());

            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO CONTACTS " +
                "VALUES (@NAME,@SURNAME,@COMPANY,@COUNTRYCODE,@PREFIX,@NUMBER)", con);
            #region
            cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
            cmd.Parameters.AddWithValue("@SURNAME", textBox2.Text);
            cmd.Parameters.AddWithValue("@COMPANY", textBox3.Text);
            cmd.Parameters.AddWithValue("@COUNTRYCODE", textBox4.Text);
            cmd.Parameters.AddWithValue("@PREFIX", textBox5.Text);
            cmd.Parameters.AddWithValue("@NUMBER", textBox6.Text);

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
