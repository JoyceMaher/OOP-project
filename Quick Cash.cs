using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace atmmmm
{
    public partial class Quick_Csh : Form
    {

        private static string connection = "Data Source=MSI;Initial Catalog=banktrial2;Integrated Security=True;Trust Server Certificate=True";
        private SqlConnection con = new SqlConnection(connection);
        public Quick_Csh()
        {
            InitializeComponent();
        }


        private void Quick_Csh_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account f2 = new Account();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();

            if (Account.bal >= 100)
            {
                SqlCommand cmd = new SqlCommand("update info set Balance = @Balance where CardNumber ='" + Login.Accn + "'", con);

                cmd.Parameters.AddWithValue("@Balance", Account.bal - 100);
                cmd.ExecuteNonQuery();
                con.Close();

                this.Hide();
                Account f2 = new Account();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Insufficient funds");
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (Account.bal >= 200)
            {
                SqlCommand cmd = new SqlCommand("update info set Balance = @Balance where CardNumber ='" + Login.Accn + "'", con);

                cmd.Parameters.AddWithValue("@Balance", Account.bal - 200);
                cmd.ExecuteNonQuery();
                con.Close();

                this.Hide();
                Account f2 = new Account();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Insufficient funds");
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if (Account.bal >= 500)
            {
                SqlCommand cmd = new SqlCommand("update info set Balance = @Balance where CardNumber ='" + Login.Accn + "'", con);

                cmd.Parameters.AddWithValue("@Balance", Account.bal - 500);
                cmd.ExecuteNonQuery();
                con.Close();

                this.Hide();
                Account f2 = new Account();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Insufficient funds");
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            if (Account.bal >= 1000)
            {
                SqlCommand cmd = new SqlCommand("update info set Balance = @Balance where CardNumber ='" + Login.Accn + "'", con);

                cmd.Parameters.AddWithValue("@Balance", Account.bal - 1000);
                cmd.ExecuteNonQuery();
                con.Close();

                this.Hide();
                Account f2 = new Account();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Insufficient funds");
                con.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
