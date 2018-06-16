using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Medical_store_management_system
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
           // label4.Text = str1;
        }
        
        private void login_Load(object sender, EventArgs e)
        {
            //panel1.BackColor = Color.FromArgb(170, 0, 0, 100);
            // panel1.BackColor = Color.FromArgb(170, 0, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vizayyadav.blogspot.com/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select * from medicalstore.login where username='" + this.textBox1.Text + "' and password='" + this.textBox2.Text + "';", conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("YOU ARE AN AUTHORIZED USER...ACCESS GRANTED.");
                    this.Hide();
                    expiredproduct f2 = new expiredproduct(textBox1.Text);
                    f2.ShowDialog();



                }
                else if (count > 1)
                {
                    MessageBox.Show("DUPLICATE USERNAME AND PASSWORD...ACCESS DENIED.");
                }
                else
                {
                    MessageBox.Show("YOU SEEM TO BE AN UNAUTHORIZED USER...ACCESS DENIED.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}