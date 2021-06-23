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
    public partial class Form3 : Form
    {
        

        public Form3(string text)
        {
            InitializeComponent();
            label1.Text = text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand("select * From Inregistrare where User_Userul =@textValue ", con);
            cmd.Parameters.AddWithValue("@textValue", text);
            SqlDataReader Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                label7.Text = (Sdr["User_Nume"].ToString());
                label8.Text = (Sdr["User_Prenume"].ToString());
                label9.Text = (Sdr["User_Email"].ToString());
                label10.Text = (Sdr["User_Parola"].ToString());
            }

            Sdr.Close();
            SqlCommand command = new SqlCommand("SELECT Avatar_img FROM Avatar where Avatar_Id in (select Avatar_Id from Inregistrare where User_Userul ='"+ label1.Text + "')", con); 
            byte[] image = (byte[])command.ExecuteScalar();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(image, 0, image.Length);

                Bitmap bitmap = new Bitmap(stream);
                pictureBox1.Image = bitmap;
            }



            con.Close();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           string  text2 = label1.Text;
            this.Close();
            Form2 f2 = new Form2(text2);
            f2.ShowDialog();

        }
       
      

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
                con.Open();

                SqlCommand cmd = new SqlCommand("Update Inregistrare SET User_Nume = @userul where User_Userul= @userul2", con);
                cmd.Parameters.AddWithValue("@userul", textBox1.Text);
                cmd.Parameters.AddWithValue("@userul2", label1.Text);
                cmd.ExecuteNonQuery();
                textBox1.Text = "";
                con.Close();
                this.Hide();
                Form3 f3 = new Form3(label1.Text);
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
                con.Open();

                SqlCommand cmd = new SqlCommand("Update Inregistrare SET User_Prenume = @userul where User_Userul= @userul2", con);
                cmd.Parameters.AddWithValue("@userul", textBox1.Text);
                cmd.Parameters.AddWithValue("@userul2", label1.Text);
                cmd.ExecuteNonQuery();
                textBox1.Text = "";
                con.Close();
                this.Hide();
                Form3 f3 = new Form3(label1.Text);
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
                con.Open();

                SqlCommand cmd = new SqlCommand("Update Inregistrare SET User_Email = @userul where User_Userul= @userul2", con);
                cmd.Parameters.AddWithValue("@userul", textBox1.Text);
                cmd.Parameters.AddWithValue("@userul2", label1.Text);
                cmd.ExecuteNonQuery();
                textBox1.Text = "";
                con.Close();
                this.Hide();
                Form3 f3 = new Form3(label1.Text);
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
                con.Open();

                SqlCommand cmd = new SqlCommand("Update Inregistrare SET User_Parola = @userul where User_Userul= @userul2", con);
                cmd.Parameters.AddWithValue("@userul", textBox1.Text);
                cmd.Parameters.AddWithValue("@userul2", label1.Text);
                cmd.ExecuteNonQuery();
                textBox1.Text = "";
                con.Close();
                this.Hide();
                Form3 f3 = new Form3(label1.Text);
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
