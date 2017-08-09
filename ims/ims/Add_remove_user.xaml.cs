using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Inventory_management_system
{
    /// <summary>
    /// Interaction logic for Add_remove_user.xaml
    /// </summary>
    public partial class Add_remove_user : Window
    {
        public Add_remove_user()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda3 = new SqlDataAdapter();
            SqlCommand cmd3 = new SqlCommand();
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals("") || textBox6.Text.Equals("") || textBox7.Text.Equals(""))
            {
                MessageBox.Show("MAKE SURE YOU DONT HAVE ANY EMPTY FIELD");
            }
            else
            {
                SqlDataAdapter sda2 = new SqlDataAdapter("Select * From Login where User_id = '" + textBox1.Text + "'", con3);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    MessageBox.Show("CHOOSE ANOTHER USER ID!IT IS ALREADY EXISTS");
                }
                
                else if (textBox3.Text.Equals("1") || textBox3.Text.Equals("2") || textBox3.Text.Equals("3") || textBox3.Text.Equals("4"))
                {
                    cmd3.CommandText = "INSERT INTO Login VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','Y')";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Connection = con3;
                    sda3.InsertCommand = cmd3;
                    con3.Open();
                    sda3.InsertCommand.ExecuteNonQuery();
                    con3.Close();
                    MessageBox.Show("USER ADDED SUCCESSFULLY");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
                else
                {
                    MessageBox.Show("INVALID ROLE ID!");
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
             MessageBox.Show("ENTER USER ID!");
            }
            else
            {
                SqlConnection con5 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

                SqlDataAdapter sda = new SqlDataAdapter("Select * From Login where User_id = '" + textBox1.Text + "'", con5);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("NO USER FOUND!");
                }
                else
                {
                    SqlCommand cmd5 = new SqlCommand();
                    cmd5.CommandText = " Update Login set Status ='N' where User_id = '" + textBox1.Text + "' ";
                    cmd5.CommandType = CommandType.Text;
                    cmd5.Connection = con5;
                    con5.Open();
                    cmd5.ExecuteNonQuery();
                    con5.Close();

                    MessageBox.Show("USER HAS BEEN REMOVED!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }

            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Admin_home ah = new Admin_home();
            this.Hide();
            ah.Show();
        }
    }
}
