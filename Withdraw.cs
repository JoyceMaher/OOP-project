using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace atmmmm
{
    public partial class Withdraw : Form
    {

        private static string connection = "Data Source=MSI;Initial Catalog=banktrial2;Integrated Security=True;Trust Server Certificate=True";
        private SqlConnection con = new SqlConnection(connection);
        public Withdraw()
        {
            InitializeComponent();
        }
        private void Withdraw_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Fname FROM info WHERE CardNumber = @CardNumber", con);
            cmd.Parameters.AddWithValue("@CardNumber", Login.Accn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string accountName = reader["Fname"].ToString();
                label1.Text = "Welcome, " + accountName;
            }
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("update info set Balance = @Balance where CardNumber ='" + Login.Accn + "'", con);


            if (Account.bal >= decimal.Parse(textBox1.Text))
            {
                cmd.Parameters.AddWithValue("@Balance", Account.bal - decimal.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                con.Close();

                this.Hide();
                Account f2 = new Account();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Not enough cash");
                textBox1.Text = "";
                con.Close();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account f2 = new Account();
            f2.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
