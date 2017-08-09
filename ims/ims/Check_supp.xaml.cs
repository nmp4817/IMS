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
    /// Interaction logic for Check_supp.xaml
    /// </summary>
    public partial class Check_supp : Window
    {
        public Check_supp()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void sid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select s.S_id,s.S_name,s.Contact_no,s.Address,st.Item_no from Supplier s,Supplier_Item st where s.S_id=st.S_id and s.S_id = '"+sid.Text+"' ", con);
                DataTable dt = new DataTable();               
                sda.Fill(dt);
                con.Open();
                dataGrid1.ItemsSource = dt.DefaultView;
                sda.Update(dt);
                con.Close();
            }
        }

        private void hom_Click(object sender, RoutedEventArgs e)
        {
            Inventory_manager_home imh = new Inventory_manager_home();
            this.Hide();
            imh.Show();
        }
    }
}
