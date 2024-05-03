using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sign_up
{
    public partial class Form1 : Form
    {
        public static string Firstname { get; set; }
        public string user;
        public string password;

        public Form1()
        {
            InitializeComponent();
        }
        string filename, record;
        StreamReader sr;
        FileStream sign_up_file;
        int yehia7arak;
        int yehia7arak2;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void login_btn_Click(object sender, EventArgs e)
        {
            filename = @"C:\Users\workstation\OneDrive\Desktop\y^5.txt";

            sign_up_file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(sign_up_file);
            record = sr.ReadLine();
            string[] check;
            while (record != null)
            {
                check = record.Split(',');
                if (email_txt.Text == check[2] && pass_txt.Text == check[3])
                {
                    MessageBox.Show("found");
                    return;

                }
                record = sr.ReadLine();
               
                
            }
            if(email_txt.Text!="" && pass_txt.Text!="")
                MessageBox.Show("not found");
           
        }


        private void signup_btn_Click(object sender, EventArgs e)
        { 
            
            this.Hide();
            Form5 form5 = new Form5(this);
            form5.ShowDialog();
            this.Show();
        }

        private void email_txt_TextChanged(object sender, EventArgs e)
        {




        }

        private void pass_txt_TextChanged(object sender, EventArgs e)
        {

        }

        public void getdata(string username, string password, string firstname)
        {
            user = username;
            this.password = password;
            Firstname = firstname;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void email_labl_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            pass_txt.UseSystemPasswordChar = !pass_txt.UseSystemPasswordChar;
            button1.Text = pass_txt.UseSystemPasswordChar ? "Show" : "Hide";
        }

        private void pass_labl_Click(object sender, EventArgs e)
        {

        }

        private void email_txt_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}