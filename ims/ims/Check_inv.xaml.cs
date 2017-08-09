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
    /// Interaction logic for Check_inv.xaml
    /// </summary>
    public partial class Check_inv : Window
    {
        string a="";
        public Check_inv()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            barcd.Text = "";
            if (comboBox1.SelectedIndex == -1)
                a = "";
            else a = comboBox1.SelectedValue.ToString();
            int j = a.IndexOf(':') + 1;
            int len1 = a.Length;
            if (!(a.Length == 0))
                a = a.Substring(j, (len1 - j));
            else a = "";

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

            if (a.Contains("yes"))
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select i.Item_no,Item_name,Price,Discount,Item_cutoff,Validity,Cid,Tot_qty From Item i,Stock_Item st where i.Item_no = st.Item_no and CONVERT(INT,i.Item_cutoff) <= CONVERT(INT,st.Tot_qty) ", con);
                DataTable dt = new DataTable();
               
                sda.Fill(dt);
                con.Open();
                dataGrid1.ItemsSource = dt.DefaultView;
                sda.Update(dt);
                con.Close();
            }

            else if (a.Contains("no"))
            {             
                SqlDataAdapter sda = new SqlDataAdapter("Select i.Item_no,Item_name,Price,Discount,Item_cutoff,Validity,Cid,Tot_qty From Item i,Stock_Item st where i.Item_no = st.Item_no and CONVERT(INT,i.Item_cutoff) > CONVERT(INT,st.Tot_qty) ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);              
                con.Open();
                dataGrid1.ItemsSource = dt.DefaultView;
                sda.Update(dt);
                con.Close();
            }

        }

        private void hm_Click(object sender, RoutedEventArgs e)
        {
            Inventory_manager_home imh = new Inventory_manager_home();
            this.Hide();
            imh.Show();
        }

        private void barcd_KeyDown(object sender, KeyEventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            if (e.Key == Key.Enter)
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select Item_name,Price,Discount,Item_cutoff,Validity,Cid From Item where Item_no = '" + barcd.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                dataGrid1.ItemsSource = dt.DefaultView;
                sda.Update(dt);
                con.Close();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Order_item oi = new Order_item();
            this.Hide();
            oi.Show();
        }

        private void chk_ordr_Click(object sender, RoutedEventArgs e)
        {
            Check_order co = new Check_order();
            this.Hide();
            co.Show();
        }
    }
}
