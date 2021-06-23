using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace proiectulMeu
{
    public partial class Form5 : Form
    {
        

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("select User_Userul From Inregistrare", con);
            SqlDataReader Sdr = cmd.ExecuteReader();
            int count = 0;
            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    comboBox1.Items.Add(Sdr.GetString(i));
                    count++;

                }
            }
            label3.Text = Convert.ToString(count);
            Sdr.Close();
            con.Close();
            con.Open();
            SqlCommand cmda = new SqlCommand("SELECT  DISTINCT mesaj_sender_id  FROM Mesaje ", con);
            SqlDataReader Sdra = cmda.ExecuteReader();
            int count2 = 0;
            while (Sdra.Read())
            {
                for (int i = 0; i < Sdra.FieldCount; i++)
                {
                    
                    count2++;

                }
            }
            label4.Text = Convert.ToString(count2);
            Sdra.Close();
            con.Close();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
            con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Inregistrare WHERE User_Userul = @userul", con);
                cmd.Parameters.AddWithValue("@userul", comboBox1.SelectedItem);
                
                cmd.ExecuteNonQuery();
                
                con.Close();
                this.Hide();
                Form5 f5 = new Form5();
                f5.ShowDialog();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = "ADMIN";
            this.Hide();
            Form3 f3 = new Form3(text);
            f3.ShowDialog();
        }
    }
    }

