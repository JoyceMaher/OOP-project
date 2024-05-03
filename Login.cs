using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atmmmm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private static string connection = "Data Source=MSI;Initial Catalog=banktrial2;Integrated Security=True;Trust Server Certificate=True";
        private SqlConnection con = new SqlConnection(connection);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static String Accn;

        private void button2_Click(object sender, EventArgs e)
        {
           
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM info WHERE CardNumber ='" + textBox1.Text + "' AND Pin ='" + textBox2.Text + "'", con);
                /* In the above line, the program is selecting the whole data from the table and matching it with the username and password provided by the user. */
                DataTable dt = new DataTable(); // Creating a virtual table
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Accn = textBox1.Text;
                    Account f2 = new Account();
                    this.Hide();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f1 = new Welcome(); 
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
