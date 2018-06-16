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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void show_notifyicon()
        {
                notifyIcon1.Icon = Properties.Resources.info1;
                notifyIcon1.BalloonTipTitle = "System Restoration process";
                notifyIcon1.BalloonTipText = "Please wait while system is restoring the backup files.";
                notifyIcon1.ShowBalloonTip(1000);
            
        }
        void restoredata()
        {
            string conn = "server=localhost;user=root;password=vijay;database=medicalstore";
            string file = "G:\\Visual Studio\\MySQL Backup\\medicalstore.sql";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = con;
                        con.Open();
                        mb.ImportFromFile(file);
                        con.Close();
                    }
                }
            }
           // MessageBox.Show("Restore completed...!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.CheckState == CheckState.Checked)
            {
                show_notifyicon();
                label2.Text = "true";
                restoredata();
            }
            this.Hide();
            login f2 = new login();
            f2.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
