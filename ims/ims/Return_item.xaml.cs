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
    /// Interaction logic for Return_item.xaml
    /// </summary>
    public partial class Return_item : Window
    {
        public Return_item()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }
        
        private void datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox1.Text = "";
            var datestring = datePicker1.SelectedDate.ToString();
            string s = Convert.ToString(datestring);
            if (s.Length == 0)
            {
                s = "";
            }
            else
            {
                s = s.Substring(0, 8);
            }
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Returned_item where Ret_date = '"+s+"'  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            dataGrid1.ItemsSource = dt.DefaultView;
            sda.Update(dt);
            con.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            datePicker1.Text = "";
            if (e.Key == Key.Enter)
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Returned_item where Item_no = '" + textBox1.Text + "'", con);
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
            Sale_manager_home smh = new Sale_manager_home();
            this.Hide();
            smh.Show();
        }
    }
}
