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
    /// Interaction logic for Add_remove_supp.xaml
    /// </summary>
    public partial class Add_remove_supp : Window
    {
        public Add_remove_supp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda3 = new SqlDataAdapter();
            SqlCommand cmd3 = new SqlCommand();
            if (textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals(""))
            {
                MessageBox.Show("MAKE SURE YOU DONT HAVE ANY EMPTY FIELD");
            }
            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Supplier where S_id = '" + label7.Content + "'", con3);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {

                    cmd3.CommandText = "INSERT INTO Supplier VALUES('" + label7.Content + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Connection = con3;
                    sda3.InsertCommand = cmd3;
                    con3.Open();
                    sda3.InsertCommand.ExecuteNonQuery();
                    con3.Close();
                }

                SqlDataAdapter sda4 = new SqlDataAdapter();
                SqlCommand cmd4 = new SqlCommand();
                cmd4.CommandText = "Insert into Supplier_item values('" + label7.Content + "','"+textBox5.Text+"')";
                cmd4.CommandType = CommandType.Text;
                cmd4.Connection = con3;
                sda4.InsertCommand = cmd4;
                con3.Open();
                sda4.InsertCommand.ExecuteNonQuery();
                con3.Close();


                MessageBox.Show("ITEM ADDED SUCCESSFULLY");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select S_id From Supplier  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int i = dt.Rows.Count;
            label7.Content = Convert.ToString((i + 1));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Remove_supp rs = new Remove_supp();
            rs.Show();
            this.Hide();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Admin_home ah = new Admin_home();
            ah.Show();
            this.Hide();
        }
    }
}
