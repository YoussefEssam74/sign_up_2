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
using System.Windows.Forms.VisualStyles;

namespace sign_up
{
    public partial class Form5 : Form
    {
       // private Form1 form1Reference;
        public Form5(Form1 form1)
        {
            InitializeComponent();
           // form1Reference = form1;
        }
        FileStream sign_up_file;
        StreamWriter sw;
        string filename,record;
        
        private void label6_Click(object sender, EventArgs e)
        {
            label6.Size = new Size(66, 50);
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
        

            string firstname="", secondname = "", email = "", pass = "", check = "";
            //save first name
            firstname = firstname_txt.Text;
            //save second name
            secondname = secondname_txt.Text;
            //save email
            email = email_txt.Text;
            //save pass
            pass = pass_txt.Text;
            check = conf_txt.Text;

            // check the pass
            check = conf_txt.Text;
            if (is_this_email(email)&&(firstname != "" && secondname != "" && email != "" && pass != ""))
            {

              MessageBox.Show("This Email is Already Exists");
                email_txt.Text = null;
                sign_up_file.Close();
               return;

            }
            if (firstname != "" && secondname != "" && email != "" && pass != "")
            {
                if (pass == check)
                {
                    sign_up_file.Seek(0, SeekOrigin.End);
                    record = firstname + "," + secondname + "," + email + "," + pass;
                    sw.WriteLine(record);
                    sw.Flush();
                    sign_up_file.Close();
                    this.Close();
                  
                }
                else if (pass != check)
                {
                    MessageBox.Show("the Password is wrong");
                    pass_txt.Text = "";
                    conf_txt.Text = "";
                    sign_up_file.Close();

                }


            }
            else 
            {
                MessageBox.Show("There are blanks that need to be completed.");
                sign_up_file.Close();


            }

        }
        private void Form5_Load(object sender, EventArgs e)
        {
            filename = @"C:\Users\workstation\OneDrive\Desktop\y^5.txt";
            sign_up_file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(sign_up_file);
        }

        private void conf_txt_TextChanged(object sender, EventArgs e)
        {

        }

        public bool is_this_email(string email)
        {
            StreamReader sr = new StreamReader(sign_up_file);
            sign_up_file.Seek (0, SeekOrigin.Begin);
            while ( !sr.EndOfStream)
            {
                string line = sr.ReadLine();    
                if(line.StartsWith(email))
                    {
                    sw.Close();
                    return true;
                }
            }
           sw.Close();
            return false;
        }
    }

}
