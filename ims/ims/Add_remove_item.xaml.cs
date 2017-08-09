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
using System.Data.SqlClient;
using System.Data;

namespace Inventory_management_system
{
    /// <summary>
    /// Interaction logic for Add_remove_item.xaml
    /// </summary>
    public partial class Add_remove_item : Window
    {
        public Add_remove_item()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Admin_home ah = new Admin_home();
            this.Hide();
            ah.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda3 = new SqlDataAdapter();
            SqlCommand cmd3 = new SqlCommand();
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals("") || textBox6.Text.Equals(""))
            {
                MessageBox.Show("MAKE SURE YOU DONT HAVE ANY EMPTY FIELD");
            }
            else
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("Select * From Category where Cid = '" + textBox6.Text + "'", con3);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("NO CATEGORY ID FOUND!");
                }
                else
                {
                    cmd3.CommandText = "INSERT INTO Item VALUES('" + label9.Content + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Connection = con3;
                    sda3.InsertCommand = cmd3;
                    con3.Open();
                    sda3.InsertCommand.ExecuteNonQuery();
                    con3.Close();

                    SqlDataAdapter sda4 = new SqlDataAdapter();
                    SqlCommand cmd4 = new SqlCommand();
                    cmd4.CommandText = "Insert into Stock_Item values('" + label9.Content + "','0')";
                    cmd4.CommandType = CommandType.Text;
                    cmd4.Connection = con3;
                    sda4.InsertCommand = cmd4;
                    con3.Open();
                    sda4.InsertCommand.ExecuteNonQuery();
                    con3.Close();

                    MessageBox.Show("ITEM ADDED SUCCESSFULLY");
                }
            }
               
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Item_no From Item  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int i = dt.Rows.Count;
            label9.Content = Convert.ToString((i+1));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Remove r = new Remove();
            r.Show();
            this.Hide();           
        }
    }
}
