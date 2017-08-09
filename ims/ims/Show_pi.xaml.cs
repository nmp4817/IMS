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
    /// Interaction logic for Show_pi.xaml
    /// </summary>
    public partial class Show_pi : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public Show_pi()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void bno_KeyDown(object sender, KeyEventArgs e)
        {
            ino.Text = "";
            sino.Text = "";
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Purchase_item where Batch_no = '" + bno.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            dataGrid1.ItemsSource = dt.DefaultView;
            sda.Update(dt);
            con.Close();
        }

        private void ino_KeyDown(object sender, KeyEventArgs e)
        {
            bno.Text = "";
            sino.Text = "";
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Purchase_item where Item_no = '" + ino.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            dataGrid1.ItemsSource = dt.DefaultView;
            sda.Update(dt);
            con.Close();
        }

        private void sino_KeyDown(object sender, KeyEventArgs e)
        {
            ino.Text = "";
            bno.Text = "";
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Purchase_item where Sid = '" + sino.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            dataGrid1.ItemsSource = dt.DefaultView;
            sda.Update(dt);
            con.Close();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            Inventory_manager_home imh = new Inventory_manager_home();
            this.Hide();
            imh.Show();
        }
    }
}
