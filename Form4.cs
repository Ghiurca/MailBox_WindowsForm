using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace proiectulMeu
{
    public partial class Form4 : Form
    {
        private SqlCommand cmd;
        private SqlDataReader dr;
        private SqlConnection cn;

        public object DataGridView1 { get; private set; }

        public Form4()
        {
            InitializeComponent();
        }
       
        private void Form4_Load(object sender, EventArgs e)
        {
            Fillcombobox();
            comboBox1.Text ="1";
            SqlConnection cnn;
            string connectionString; 
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
            cnn = new SqlConnection(connectionString);

                MemoryStream stream = new MemoryStream();
                cnn.Open();
                SqlCommand command = new SqlCommand("select Avatar_img from Avatar where Avatar_Id = '" + comboBox1.SelectedItem + "'", cnn);
                byte[] image = (byte[])command.ExecuteScalar();
            stream.Write(image, 0, image.Length);
                cnn.Close();
                Bitmap bitmap = new Bitmap(stream);
                pictureBox1.Image = bitmap;

        }

        
        private void Register_Click(object sender, EventArgs e)
        {
            {

                if (textBox1.Text != string.Empty || textBox2.Text != string.Empty || textBox3.Text != string.Empty || textBox4.Text != string.Empty || textBox5.Text != string.Empty)
                {
                    if (textBox5.Text == textBox6.Text)
                    {
                        cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True");
                        cn.Open();
                        cmd = new SqlCommand("select * from Inregistrare where User_Userul='" + textBox1.Text + "'", cn);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            dr.Close();
                            MessageBox.Show("Acest username exista deja.Incearca un altul ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cn.Close();
                        }
                        else
                        {
                            cn.Close();
                            dr.Close();
                            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True");
                            SqlCommand cmd = cn.CreateCommand();
                            cn.Open();
                            
                            cmd.CommandText = "INSERT INTO Inregistrare values(@Userul, @Nume, @Prenume, @Email, @Parola,'" + comboBox1.SelectedItem + "')";
                           
                            
                            cmd.Parameters.AddWithValue("@Userul", textBox1.Text);
                            cmd.Parameters.AddWithValue("@Nume", textBox2.Text);
                            cmd.Parameters.AddWithValue("@Prenume", textBox3.Text);
                            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                            cmd.Parameters.AddWithValue("@Parola", textBox5.Text);
                           

                            cmd.ExecuteNonQuery();



                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            comboBox1.SelectedItem = '1';
                            cn.Close();
                            MessageBox.Show("Contul este creat.Acum te poti loga.");
                            this.Hide();
                            Form1 f1 = new Form1();
                            f1.ShowDialog();
                        }

                        
                       
                       
                    }

                    else
                    {
                        MessageBox.Show("Campurile de parola trebuie sa fie la fel ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Insereaza valori in campurile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
        void Fillcombobox()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("select Avatar_Id From Avatar", con);
            SqlDataReader Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    comboBox1.Items.Add(Sdr.GetInt32(i));

                }
            }
            Sdr.Close();
            con.Close();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cnn;
            string connectionString;
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
            cnn = new SqlConnection(connectionString);

            MemoryStream stream = new MemoryStream();
            cnn.Open();
            SqlCommand command = new SqlCommand("select Avatar_img from Avatar where Avatar_Id = '" + comboBox1.SelectedItem + "'", cnn);
            byte[] image = (byte[])command.ExecuteScalar();
            stream.Write(image, 0, image.Length);
            cnn.Close();
            Bitmap bitmap = new Bitmap(stream);
            pictureBox1.Image = bitmap;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            
        }
    }
}