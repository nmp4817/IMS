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
    /// Interaction logic for Check_order.xaml
    /// </summary>
    public partial class Check_order : Window
    {
        public Check_order()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox2.Text = "";
            datePicker1.Text = "";
            if (e.Key == Key.Enter)
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Order1 where Item_no = '" + textBox1.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                dataGrid1.ItemsSource = dt.DefaultView;
                sda.Update(dt);
                con.Close();
            }
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            Check_inv ci = new Check_inv();
            this.Hide();
            ci.Show();
        }

        private void datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            var datestring = datePicker1.SelectedDate.ToString();
            string s = Convert.ToString(datestring);
            if (!(s.Length == 0))
                s = s.Substring(0, 8);
            else s = "";
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Order1 where  O_date = '" + s + "'  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            dataGrid1.ItemsSource = dt.DefaultView;
            sda.Update(dt);
            con.Close();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text = "";
            datePicker1.Text = "";
            if (e.Key == Key.Enter)
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Order1 where Sid = '" + textBox2.Text + "' ", con);
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
