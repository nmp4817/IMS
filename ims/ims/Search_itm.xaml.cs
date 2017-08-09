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
using System.Data.SqlClient;
using System.Data;

namespace Inventory_management_system
{
    /// <summary>
    /// Interaction logic for Search_itm.xaml
    /// </summary>
    public partial class Search_itm : Window
    {
        string s;
        int fl = 0;
        public Search_itm()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            s = comboBox1.SelectedValue.ToString();
            int i = s.IndexOf(':') + 1;
            int len= s.Length;
            s = s.Substring(i , (len - i));
            label3.Content = "Enter " + s;
            comboBox2.Visibility= Visibility.Visible;
            comboBox2.Items.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

            if (s.Contains("Category"))
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select Cname from Category ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();

                int j = 0, k = dt.Rows.Count;
                while (k != 0)
                {
                    comboBox2.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                    j++;
                    k--;
                    fl = 1;
                }
                con.Close();       
            }
            else if (s.Contains("Name"))
            {
                
                    SqlDataAdapter sda = new SqlDataAdapter("Select Item_name from Item", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Open();

                    int j = 0, k = dt.Rows.Count;
                    while (k != 0)
                    {
                        comboBox2.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                        j++;
                        k--;
                        fl = 2;
                    }
                    con.Close();
            }
            else if (s.Contains("Availibility"))
            {
                comboBox2.Items.Add("yes");
                comboBox2.Items.Add("no");
                fl = 3;
            }
           
        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //s1 = comboBox1.SelectedValue.ToString();
            //int i = s1.IndexOf(':') + 1;
            //int len = s1.Length;
            //s1 = s1.Substring(i, (len - i));

            string n = "";
            string a = "";
            string c = "";

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            if(fl==2)
            if (s.Contains("Name"))
            {
                n =comboBox2.SelectedValue.ToString();
                int j = n.IndexOf(':') + 1;
                int len1 = n.Length;
                n = n.Substring(j, (len1 - j));

                SqlDataAdapter sda = new SqlDataAdapter("Select * From Item where Item_Name = '" + n + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                dataGrid1.ItemsSource = dt.DefaultView;
                sda.Update(dt);
                con.Close();
            }
            if(fl==1)
            if(s.Contains("Category"))
            {
                c = comboBox2.SelectedValue.ToString();
                int j = c.IndexOf(':') + 1;
                int len1 = c.Length;
                c = c.Substring(j, (len1 - j));

                SqlDataAdapter sda = new SqlDataAdapter("Select * From Item i,Category c where i.Cid=c.Cid and Cname = '" + c + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                dataGrid1.ItemsSource = dt.DefaultView;
                sda.Update(dt);
                con.Close();
            }
            if(fl==3)
            if(s.Contains("Availibility")) 
            {
                a = comboBox2.SelectedValue.ToString();
                int j = a.IndexOf(':') + 1;
                int len1 = a.Length;
                a = a.Substring(j, (len1 - j));

                if (a.Equals("yes"))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("Select * From Item i,Stock_Item st where i.Item_no = st.Item_no and CONVERT(INT,i.Item_cutoff) <= CONVERT(INT,st.Tot_qty) ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Open();
                    dataGrid1.ItemsSource = dt.DefaultView;
                    sda.Update(dt);
                    con.Close();
                }

                else if (a.Equals("no"))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("Select * From Item i,Stock_Item st where i.Item_no = st.Item_no and CONVERT(INT,i.Item_cutoff) > CONVERT(INT,st.Tot_qty) ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Open();
                    dataGrid1.ItemsSource = dt.DefaultView;
                    sda.Update(dt);
                    con.Close();
                }

                //else { }
            }
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            Sale_home sh = new Sale_home();
            this.Hide();
            sh.Show();
        }
    }
}
