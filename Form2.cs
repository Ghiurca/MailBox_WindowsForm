using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace proiectulMeu
{
    public partial class Form2 : Form

    {
        
        void Fillcombobox()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("select User_Userul From Inregistrare", con);
            SqlDataReader Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    comboBox1.Items.Add(Sdr.GetString(i));

                }
            }
            Sdr.Close();
            con.Close();

        }
        void FillMesajePrimite()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
            con.Open();
            string index = "select User_Id from Inregistrare where User_Userul ='" + label1.Text + "'";
           
            SqlCommand cmd = new SqlCommand("select mesaj_continut From Mesaje where mesaj_receiver_id = (select User_Id from Inregistrare where User_Userul ='" + label1.Text + "') ", con);
          
            SqlDataReader Sdr = cmd.ExecuteReader();
            
            while (Sdr.Read())

            {
                try
                {
                    for (int i = 0; i < Sdr.FieldCount; i++)
                    {
                        Mesaje.Items.Add(Sdr.GetString(i));

                    }
                }
                catch
                {
                    MessageBox.Show("Nu ai mesaje.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Sdr.Close();
            con.Close();

        }
        void FillUltimulMesaj()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
            con.Open();
            string index = "select User_Id from Inregistrare where User_Userul ='" + label1.Text + "'";

            SqlCommand cmd = new SqlCommand("select TOP 1 mesaj_continut From Mesaje where mesaj_receiver_id = (select User_Id from Inregistrare where User_Userul ='" + label1.Text + "')ORDER BY mesaj_id DESC", con);

            SqlDataReader Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                try
                {
                    for (int i = 0; i < Sdr.FieldCount; i++)
                    {
                        Mesaje.Items.Add(Sdr.GetString(i));

                    }
                }
                catch
                {
                    MessageBox.Show("Nu ai mesaje.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Sdr.Close();
            con.Close();

        }
        public Form2(string text2)
        {
            InitializeComponent();
            label1.Text = text2;
            
       
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Mesaje.Items.Clear();
            FillMesajePrimite();
        }
      
        private void Form2_Load(object sender, EventArgs e)
        {
            Fillcombobox();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mesaje.Items.Clear();
            FillUltimulMesaj();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True");
                    cn.Open();
    

                        SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "INSERT INTO Mesaje values((select User_Id from Inregistrare where User_Userul ='" + label1.Text + "'), (select User_Id from Inregistrare where User_Userul = '" + comboBox1.SelectedItem + "'),'" + textBox1.Text + "' )";
                        try
                        {
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                           
                        }
                        finally
                        {
                            textBox1.Text = "";
                            cn.Close();


                        }
                label2.Text = "Mesajul tau a fost trimis";
                       
                        
                    }
            else
            {
                MessageBox.Show("Scrieti un mesaj.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Mesaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\proiectulMeu\Database1.mdf;Integrated Security=True";
            con.Open();
            string selection = Mesaje.SelectedItem.ToString();
            SqlCommand cmd = new SqlCommand("select User_Userul from Inregistrare where User_Id = (select mesaj_sender_id from Mesaje where mesaj_continut = @textValue) ", con);
            cmd.Parameters.AddWithValue("@textValue", selection);

            using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
            {
                SqlDataReader reader = sqlDataReader;
                try
                {
                    while (reader.Read())
                    {
                        label5.Text = (reader["User_Userul"].ToString());



                    }
                }
                catch
                {
                    MessageBox.Show("alegere nok");
                }
                reader.Close();
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3(label1.Text);
            f3.ShowDialog();
        }
    }


}

