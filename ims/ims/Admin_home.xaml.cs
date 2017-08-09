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

namespace Inventory_management_system
{
    /// <summary>
    /// Interaction logic for Admin_home.xaml
    /// </summary>
    public partial class Admin_home : Window
    {
        public Admin_home()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Change_pwd cp = new Change_pwd();
            cp.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Add_remove_item ari = new Add_remove_item();
            this.Hide();
            ari.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Add_remove_supp ars = new Add_remove_supp();
            this.Hide();
            ars.Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Add_remove_user aru = new Add_remove_user();
            this.Hide();
            aru.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Show_details sd = new Show_details();
            this.Hide();
            sd.Show();
        }
    }
}
