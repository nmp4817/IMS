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
    /// Interaction logic for Sale_manager_home.xaml
    /// </summary>
    public partial class Sale_manager_home : Window
    {
        public Sale_manager_home()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void yp_Click(object sender, RoutedEventArgs e)
        {
            Change_pwd cp = new Change_pwd();
            this.Hide();
            cp.Show();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }

        private void css_Click(object sender, RoutedEventArgs e)
        {
            Check_sale cs = new Check_sale();
            this.Hide();
            cs.Show();
        }

        private void cbs_Click(object sender, RoutedEventArgs e)
        {
            Check_bill cb = new Check_bill();
            this.Hide();
            cb.Show();
        }

        private void Reti_Click(object sender, RoutedEventArgs e)
        {
            Ret_item ri = new Ret_item();
            this.Hide();
            ri.Show();
        }

        private void crs_Click(object sender, RoutedEventArgs e)
        {
            Return_item ri = new Return_item();
            this.Hide();
            ri.Show();
        }

        private void sale_report_Click(object sender, RoutedEventArgs e)
        {
            Report3 r3 = new Report3();
            this.Hide();
            r3.Show();
        }
    }
}
