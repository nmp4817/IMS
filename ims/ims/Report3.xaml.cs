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
    /// Interaction logic for Report3.xaml
    /// </summary>
    public partial class Report3 : Window
    {
        public Report3()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Sale_manager_home smh = new Sale_manager_home();
            this.Hide();
            smh.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Dvs dvs = new Dvs();
            dvs.Show();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Dvq dvq = new Dvq();
            dvq.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Uvs uvs = new Uvs();
            uvs.Show();
        }
    }
}
