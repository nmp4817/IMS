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
    /// Interaction logic for Change_pwd.xaml
    /// </summary>
    public partial class Change_pwd : Window
    {
        public Change_pwd()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = "";
            if (MainWindow.get_user().ToString().Equals("hiren"))
            {
                 path = "Images/hiren.jpg";
            }
            else if (MainWindow.get_user().ToString().Equals("nabil"))
            {
                path = "Images/nabil.JPG";
            }
            else if (MainWindow.get_user().ToString().Equals("madhur"))
            {
                path = "Images/IM.jpg";
            }
            else if (MainWindow.get_user().ToString().Equals("rohan"))
            {
                path = "Images/Admin.jpg";
            }
            else if (MainWindow.get_user().ToString().Equals("mayur"))
            {
                path = "Images/SP.jpg";
            }
            image1.Source = new BitmapImage(new Uri(path, UriKind.Relative));
            name.Content = MainWindow.get_user();
            login_time.Content = MainWindow.get_logintime();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select R_id from Login where User_id = '" + MainWindow.get_user() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0].ItemArray[0].ToString().Equals("1"))
            {
                Sale_home sh = new Sale_home();
                this.Hide();
                sh.Show();
            }
            else if (dt.Rows[0].ItemArray[0].ToString().Equals("2"))
            {
                Sale_manager_home smh = new Sale_manager_home();
                this.Hide();
                smh.Show();
            }
            else if (dt.Rows[0].ItemArray[0].ToString().Equals("3"))
            {
                Inventory_manager_home imh = new Inventory_manager_home();
                imh.Show();
                this.Hide();
            }
            else if (dt.Rows[0].ItemArray[0].ToString().Equals("4"))
            {
                Admin_home ah = new Admin_home();
                ah.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            label5.Visibility = Visibility.Visible;
            label6.Visibility = Visibility.Visible;
            label7.Visibility = Visibility.Visible;
            oldpwd.Visibility = Visibility.Visible;
            newpwd.Visibility = Visibility.Visible;
            repwd.Visibility = Visibility.Visible;
            done.Visibility = Visibility.Visible;
        }

        private void done_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Password From Login where User_id = '" + MainWindow.get_user() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (!oldpwd.Text.Equals(dt.Rows[0].ItemArray[0]))
            {
                MessageBox.Show("Password is Wrong, Please Re-enter.");
            }
            else if (!newpwd.Text.Equals(repwd.Text.ToString()))
            {
                MessageBox.Show("New Password & Re-entered Password Should be Same.");
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da1 = new SqlDataAdapter();
                int i = newpwd.Text.IndexOf(':') + 1;
                int len = newpwd.Text.Length;
                string s = newpwd.Text.Substring(i, (len - i));

                cmd.CommandText = "update Login set Password = '" + s + "' where User_id = '" + MainWindow.get_user() + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                da1.UpdateCommand = cmd;
                con.Open();
                da1.UpdateCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Password is Changed Successfully.");
            }
        }
   }
}