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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
          //ADD
        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 ADD = new Form4();
            ADD.Show();
            this.Hide();
        }
        //UPDATE
        Form4 frm = new Form4();
        private void uPDATEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(DAL.GetConnectionString());
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE CONTACTS SET NAME= @NAME, SURNAME=@SURNAME, COMPANY=@COMPANY, COUNTRYCODE=@COUNTRYCODE, PREFIX=@PREFIX, NUMBER= @NUMBER WHERE ID= @ID", con);
            #region
            cmd.Parameters.AddWithValue("@NAME", frm.textBox1.Text);
            cmd.Parameters.AddWithValue("@SURNAME", frm.textBox2.Text);
            cmd.Parameters.AddWithValue("@COMPANY", frm.textBox3.Text);
            cmd.Parameters.AddWithValue("@COUNTRYCODE", frm.textBox4.Text);
            cmd.Parameters.AddWithValue("@PREFIX", frm.textBox5.Text);
            cmd.Parameters.AddWithValue("@NUMBER", frm.textBox6.Text);
            cmd.Parameters.AddWithValue("@ID", frm.textBox1.Tag);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("UPDATE EDILDI");
            #endregion


        }
        //SELECT
        private void gETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DAL.GetConnectionString());

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CONTACTS " , con);
            #region
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            con.Close();
            #endregion


        }


         //DATAGRIDVIEW
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow Row = dataGridView1.CurrentRow;
            frm.Show();
            #region
            frm.textBox1.Tag = Row.Cells["ID"].Value.ToString();

            frm.textBox1.Text = Row.Cells["NAME"].Value.ToString();
            frm.textBox2.Text = Row.Cells["SURNAME"].Value.ToString();
            frm.textBox3.Text = Row.Cells["COMPANY"].Value.ToString();
            frm.textBox4.Text = Row.Cells["COUNTRYCODE"].Value.ToString();
            frm.textBox5.Text = Row.Cells["PREFIX"].Value.ToString();
            frm.textBox6.Text = Row.Cells["NUMBER"].Value.ToString();
            #endregion

        }
        //DELETE
        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DAL.GetConnectionString());
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM CONTACTS WHERE ID =@ID", con);
            cmd.Parameters.AddWithValue("@ID", frm.textBox1.Tag);
            #region
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("WAS DELETED");

            #endregion

        }
    }
}
