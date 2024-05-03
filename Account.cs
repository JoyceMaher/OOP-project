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
    public partial class Account : Form
    {

        private static string connection = "Data Source=LAPTOP-LBL0EKF6\\SQLEXPRESS;Initial Catalog=\"User Info\";Integrated Security=True";
        private SqlConnection con = new SqlConnection(connection);
        public Account()
        {
            InitializeComponent();
        }

        public static decimal bal;

        private void getbalance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Balance FROM info WHERE CardNumber ='" + Login.Accn + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            bal = decimal.Parse(dt.Rows[0][0].ToString());
            label5.Text = dt.Rows[0][0].ToString();

            con.Close();

        }

        private void getname()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Fname FROM info WHERE CardNumber ='" + Login.Accn + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            String ah = dt.Rows[0][0].ToString();
            label1.Text = "Welcome, " + ah;

            con.Close();

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Account_Load(object sender, EventArgs e)
        {
            getbalance();
            getname();
            label6.Text = Login.Accn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Withdraw f3 = new Withdraw();
            f3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f1 = new Welcome();
            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deposit f4 = new Deposit();
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quick_Csh f6 = new Quick_Csh();
            f6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Points f7 = new Points();
            f7.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feed f7 = new Feed();
            f7.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
