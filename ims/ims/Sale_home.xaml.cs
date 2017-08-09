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
    /// Interaction logic for Sale_home.xaml
    /// </summary>
    public partial class Sale_home : Window
    {
        public Sale_home()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void Generate_bill_Click(object sender, RoutedEventArgs e)
        {
            Bill_gen bg = new Bill_gen();
            bg.Show();
            //Bill_generation bg = new Bill_generation();
            //this.Hide();
            //bg.Show();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
            SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da1 = new SqlDataAdapter();

            string logout_time = DateTime.Now.ToString("hh:mm:ss");
            string na = MainWindow.get_user();
            string gd = MainWindow.get_date();
            string glit = MainWindow.get_logintime();

            cmd.CommandText = "update Cashier_details set Logout_time='" + logout_time + "' where User_id='" + na + "' and  Login_date='" + gd + "' and Login_time='" + glit + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con1;

            da1.UpdateCommand = cmd;
            con1.Open();
            da1.UpdateCommand.ExecuteNonQuery();
            con1.Close();

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlCommand cmd1 = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Bill where User_id = ' " + na + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Int64 tqty = 0;
            Int64 trate = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[1].ToString().Equals(gd) && DateTime.Today.Add(TimeSpan.Parse(dt.Rows[i].ItemArray[2].ToString())) >= DateTime.Today.Add(TimeSpan.Parse(glit)) && DateTime.Today.Add(TimeSpan.Parse(dt.Rows[i].ItemArray[2].ToString())) <= DateTime.Today.Add(TimeSpan.Parse(logout_time)))
                {
                    tqty = tqty + Convert.ToInt64(dt.Rows[i].ItemArray[3]);
                    trate = trate + Convert.ToInt64(dt.Rows[i].ItemArray[5]);
                }
            }

            SqlConnection con2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlCommand cmd2 = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd2.CommandText = "update Cashier_details set Total_qty = '" + tqty.ToString() + "' , Total_sales = '" + trate.ToString() + "' where User_id='" + na + "' and  Login_date='" + gd + "' and Login_time='" + glit + "' and Logout_time ='" + logout_time + "'";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con2;
            sda.UpdateCommand = cmd2;
            con2.Open();
            sda.UpdateCommand.ExecuteNonQuery();
            con2.Close();

         
            SqlCommand cmd3 = new SqlCommand();
            SqlDataAdapter sda3 = new SqlDataAdapter();
            cmd3.CommandText = "update Report_sale set Total_qty =CONVERT(VARCHAR(50),CONVERT(INT,Total_qty+" + Convert.ToInt64(tqty.ToString()) + "))  , Total_sales = CONVERT(VARCHAR(50),CONVERT(INT,Total_sales+" + Convert.ToInt64(trate.ToString()) + ")) where User_id='" + na + "' and  Login_date='" + gd + "' ";
            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = con2;
            sda3.UpdateCommand = cmd3;
            con2.Open();
            sda3.UpdateCommand.ExecuteNonQuery();
            con2.Close();



        }

        private void Search_item_Click(object sender, RoutedEventArgs e)
        {
            Search_itm si = new Search_itm();
            this.Hide();
            si.Show();
        }

        private void Inventory_status_Click(object sender, RoutedEventArgs e)
        {
            Inv_status i = new Inv_status();
            this.Hide();
            i.Show();
        }

        private void Your_profile_Click(object sender, RoutedEventArgs e)
        {
            Change_pwd cp = new Change_pwd();
            this.Hide();
            cp.Show();
        }
    }
}