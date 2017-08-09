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
    /// Interaction logic for Inv_status.xaml
    /// </summary>
    public partial class Inv_status : Window
    {
        public Inv_status()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }
        private void home_Click(object sender, RoutedEventArgs e)
        {
            Sale_home sh = new Sale_home();
            this.Hide();
            sh.Show();
        }
        private void barcd_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text = "";
            if(e.Key==Key.Enter)
            {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Item_name,Price,Discount,Item_cutoff,Validity,Cid From Item where Item_no = '" + itm_no.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            dataGrid1.ItemsSource = dt.DefaultView;
            sda.Update(dt);
            con.Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            itm_no.Text = "";
            if (e.Key == Key.Enter)
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select Item_name,Price,Discount,Item_cutoff,Validity,Cid From Item where LOWER(Item_name) = '" + textBox1.Text.ToLower() + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                dataGrid1.ItemsSource = dt.DefaultView;
                sda.Update(dt);
                con.Close();
            }
        }
    }
}