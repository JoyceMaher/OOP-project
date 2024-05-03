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
    public partial class Points : Form
    {
        public Points()
        {
            InitializeComponent();
        }

        private static string connection = "Data Source=LAPTOP-LBL0EKF6\\SQLEXPRESS;Initial Catalog=\"User Info\";Integrated Security=True";
        private SqlConnection con = new SqlConnection(connection);

        private static int pnt;
        private void getpoints()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Point FROM info WHERE CardNumber ='" + Login.Accn + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            pnt = int.Parse(dt.Rows[0][0].ToString());
            label8.Text = dt.Rows[0][0].ToString();

            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account f2 = new Account();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Points_Load(object sender, EventArgs e)
        {
            label9.Text = "" + Account.bal;
            getpoints();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmdb = new SqlCommand("update info set Balance = @Balance where CardNumber ='" + Login.Accn + "'", con);
            SqlCommand cmdp = new SqlCommand("update info set Point = @Point where CardNumber ='" + Login.Accn + "'", con);


            if (pnt >= 10 && pnt >= int.Parse(textBox1.Text))
            {

                cmdb.Parameters.AddWithValue("@Balance", Account.bal + (decimal.Parse(textBox1.Text) * (decimal)0.1));
                cmdp.Parameters.AddWithValue("@Point", pnt - int.Parse(textBox1.Text));
                cmdb.ExecuteNonQuery();
                cmdp.ExecuteNonQuery();
                con.Close();


                this.Hide();
                Account f2 = new Account();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Invalid points");
                textBox1.Text = "";
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            con.Open();

            SqlCommand cmdb = new SqlCommand("update info set Balance = @Balance where CardNumber ='" + Login.Accn + "'", con);
            SqlCommand cmdp = new SqlCommand("update info set Point = @Point where CardNumber ='" + Login.Accn + "'", con);


            if (Account.bal >= 1 && Account.bal >= decimal.Parse(textBox2.Text))
            {

                cmdb.Parameters.AddWithValue("@Balance", Account.bal - decimal.Parse(textBox2.Text));
                cmdp.Parameters.AddWithValue("@Point", pnt + (int.Parse(textBox2.Text) * 0.1));
                cmdb.ExecuteNonQuery();
                cmdp.ExecuteNonQuery();
                con.Close();


                this.Hide();
                Account f2 = new Account();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Invalid points");
                textBox1.Text = "";
                con.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
