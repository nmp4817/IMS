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
    /// Interaction logic for Inventory_manager_home.xaml
    /// </summary>
    public partial class Inventory_manager_home : Window
    {
        public Inventory_manager_home()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }

        private void yr_prfl_Click(object sender, RoutedEventArgs e)
        {
            Change_pwd cp = new Change_pwd();
            this.Hide();
            cp.Show();
        }

        private void chk_inv_Click(object sender, RoutedEventArgs e)
        {
            Check_inv ci = new Check_inv();
            this.Hide();
            ci.Show();
        }

        private void chk_sup_Click(object sender, RoutedEventArgs e)
        {
            Check_supp cs = new Check_supp();
            this.Hide();
            cs.Show();
        }

        private void api_Click(object sender, RoutedEventArgs e)
        {
            Add_purchase ap = new Add_purchase();
            this.Hide();
            ap.Show();
        }

        private void purc_item_Click(object sender, RoutedEventArgs e)
        {
            Show_pi sp = new Show_pi();
            this.Hide();
            sp.Show();
        }      
    }
}
