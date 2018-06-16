using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
namespace Medical_store_management_system
{
    public partial class newaccess : Form
    {
        public newaccess(string str1)
        {
            InitializeComponent();
            textBox1.Text = str1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                
                byte[] imageBt = null;
                FileStream fstream = new FileStream(this.textBox5.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);

                String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("insert into medicalstore.login (username,password,imageurl,Image) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','"+ this.textBox4.Text+"',@IMG)", conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("New account successfully created.");
                    while (myReader.Read())
                    {
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Your password in both fields didn't match. ");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "G:\\visual c#\\Photos\\place your photo here1.jpg";
            pictureBox1.Image = Image.FromFile("G:\\visual c#\\Photos\\place your photo here1.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String picPath = dlg.FileName.ToString();
                // string newFileName = picPath.Replace("\\", "\\\\");
                //textBox4.Text = newFileName;
                textBox5.Text = picPath;
                string newfilename = picPath.Replace("\\", "\\\\");
                textBox4.Text = newfilename;
                pictureBox1.ImageLocation = picPath;
                
            }
        }
        void load_image()
        {
            String susername = textBox1.Text;
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
                    string imageurl = myReader.GetString("imageurl");
                    string iu = imageurl.Replace("\\", "\\\\");
                    this.textBox4.Text = iu;

                    byte[] imgg = (byte[])(myReader["image"]);
                    if (imgg == null)
                        pictureBox1.Image = null;

                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void newaccess_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(80, 80, 80, 80);
            load_image();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                byte[] imageBt = null;
                FileStream fstream = new FileStream(this.textBox4.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);

                String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("update medicalstore.login set username='"+this.textBox1.Text+ "',imageurl='" + this.textBox4.Text + "', password='" + this.textBox2.Text+"',image=@IMG where username='"+this.textBox1.Text+"';", conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Successfully Updated.");
                    while (myReader.Read())
                    {
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Your password in both fields didn't match. ");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "G:\\visual c#\\Photos\\place your photo here1.jpg";
            pictureBox1.Image = Image.FromFile("G:\\visual c#\\Photos\\place your photo here1.jpg");
           // this.Hide();
           // Form1 f1 = new Form1();
            //f1.ShowDialog();
        }
        

    }
}
