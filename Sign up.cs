using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace atmmmm
{
    public partial class Sign_up : Form
    {
        public abstract class Printa
        {
            public abstract void printall();

            public virtual void showpass()
            {
                MessageBox.Show("Password");
            }
        }
        public class Userinfo : Printa
        {
            public string firstname { get; set; }
            public string username { get; set; }
            public string Cardnumber { get; set; }
            public string Balance { get; set; }
            public string Points { get; set; }
            public string pass { get; set; }

            public Userinfo(string firstname, string username, string Cardnumber, string Balance, string Points, string pass)
            {
                this.firstname = firstname;
                this.username = username;
                this.Cardnumber = Cardnumber;
                this.Balance = Balance;
                this.Points = Points;
                this.pass = pass;
            }

            public override void printall()
            {
                MessageBox.Show("" + firstname + " \n" + username + "\n" + Cardnumber + "\n" + Balance + "\n" + Points);
            }

            public override void showpass()
            {
                MessageBox.Show("");
            }

            public class Customer
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public int AccountNumber { get; set; }
                public int Password { get; set; }
                public double Balance { get; set; }
                public double Points { get; set; }
            }
        }
            public Sign_up()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=banktrial2;Integrated Security=True;Trust Server Certificate=True");
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            var r = generator.Next(1000, 1090);
            string s = r.ToString("0000");

            con.Open();
            SqlCommand cmd = new SqlCommand("insert into info (Fname, Lname,Pin, NationaLID, Mobile, CardNumber,Balance,Point) values('" + fnametxt.Text + "','" + lnametxt.Text + "','" + passtxt.Text + "','" + nidtxt.Text + "','" + mobiletxt.Text + "','" + s + "','" + 0 + "','" + 0 + "')", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Your card number is" + s);
            con.Close();
            Login f1 = new Login();
            this.Hide();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            this.Hide();
            f1.Show();
        }

        private void lnametxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
