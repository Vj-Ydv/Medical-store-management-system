using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using Tulpep.NotificationWindow;

namespace Medical_store_management_system
{
    public partial class expiredproduct : Form
    {
        public expiredproduct(string str_value1)
        {
            InitializeComponent();
            label4.Text = str_value1;
           // label12.Text = str2;
        }
        DataTable dbdataset;
        void load_table1()
        {
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select* from medicalstore.pharmacyrecord ;", conDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;

                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        void load_expiredproducts()
        {
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT * From medicalstore.pharmacyrecord where expirydate<Now();", conDataBase);
            conDataBase.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmdDataBase;
            dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;
            dataGridView1.DataSource = bSource;

            sda.Update(dbdataset);

            conDataBase.Close();
            int c = dataGridView1.Rows.Count - 1;
            label2.Text = c.ToString();
            label5.Text = c.ToString();

        }
        void load_finishedproducts()
        {
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT * From medicalstore.pharmacyrecord where quantity<=50;", conDataBase);
            conDataBase.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmdDataBase;
            dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;
            dataGridView2.DataSource = bSource;

            sda.Update(dbdataset);

            conDataBase.Close();
            int c = dataGridView2.Rows.Count - 1;
            label10.Text = c.ToString();
            label8.Text = c.ToString();
        }
        void load_image()
        {
            String susername = label4.Text;
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select * from medicalstore.login where username ='" + susername + "';", conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {

                    byte[] imgg = (byte[])(myReader["image"]);
                    if (imgg == null)
                        pictureBox2.Image = null;

                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox2.Image = System.Drawing.Image.FromStream(mstream);

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void show_notification()
        {
            int a1 = Convert.ToInt32(label5.Text);
            if (a1 > 0)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.info;
                popup.TitleText = "Expired Products Notification";
                popup.ContentText = "\n" + "Check your stock. " + "\n\n" + label5.Text + " " + " products have been expired" + "\n"+ "and " + "  " + label8.Text +" "+" products are finished/finishing.";
                popup.Popup();
            }
        }
        void show_notificationforfinished()
        {
            int a1 = Convert.ToInt32(label8.Text);
            if (a1 > 0)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.info;
                popup.TitleText = "Products finished/ finishing in the stock.";
                popup.ContentText = "\n" + "Check your stock. " + "\n\n" + label8.Text + " " + " products are finishing or have already finished in the stock.";
                popup.Popup();
            }
        }
      
        private void expiredproduct_Load(object sender, EventArgs e)
        {
            
            load_image();
            load_table1();
            load_expiredproducts();
            load_finishedproducts();
            show_notification();
            //show_notifyicon();
            //show_notificationforfinished();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //show_notification();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            pharmacy p1 = new pharmacy(label4.Text);
            p1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //this.Hide();
            newaccess n1 = new newaccess(label4.Text);
            n1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            //show_notification();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            //show_notificationforfinished();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            //show_notificationforfinished();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT * From medicalstore.pharmacyrecord where quantity=0;", conDataBase);
            conDataBase.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmdDataBase;
            dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;
            dataGridView2.DataSource = bSource;

            sda.Update(dbdataset);

            conDataBase.Close();
            int c = dataGridView2.Rows.Count - 1;
            label10.Text = c.ToString();
            //label8.Text = c.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT * From medicalstore.pharmacyrecord where quantity>0 && quantity<=50;", conDataBase);
            conDataBase.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmdDataBase;
            dbdataset = new DataTable();
            sda.Fill(dbdataset);
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dbdataset;
            dataGridView2.DataSource = bSource;

            sda.Update(dbdataset);

            conDataBase.Close();
            int c = dataGridView2.Rows.Count - 1;
            label10.Text = c.ToString();
            //label8.Text = c.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (button8.Text == "Expand")
            {
                // panel1.Width = 300;
                button8.Text = "Shrink";
                t1.Enabled = true;
                panel3.Visible = true;
            }
            else if (button8.Text == "Shrink")
            {
                panel3.Width = 30;
                t1.Enabled = false;

                button8.Text = "Expand";
                panel3.Visible = false;
            }
        }

        private void t1_Tick(object sender, EventArgs e)
        {
            if (panel3.Width >= 540)
                t1.Enabled = false;
            else
                panel3.Width += 90;
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            newaccess na = new newaccess(label4.Text);
            na.ShowDialog();
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
        }
    }
}
