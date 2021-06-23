using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace proiectulMeu
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
            cn.Open();
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)

            {
               
                SqlCommand   cmd = new SqlCommand("select User_Userul, User_Parola from Inregistrare where User_Userul = '" + textBox1.Text + "' and User_Parola='" + textBox2.Text + "'", cn);

                string text = textBox1.Text;
                
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    if (reader.GetString(0) != "admin")
                    {
                        reader.Close();
                        this.Hide();
                        Form2 f2 = new Form2(text);
                        Form3 f3 = new Form3(text);
                        f3.Show();
                    }
                    else
                    {
                        this.Hide();
                        Form5 f5 = new Form5();
                        f5.Show();
                    }

                }
                else
                {
                    reader.Close();
                    MessageBox.Show("No Account available with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
           
        }
    }
    
}



