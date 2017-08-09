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
    /// Interaction logic for Bill_generation.xaml
    /// </summary>
    public partial class Bill_generation : Window
    {
        public Bill_generation()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            Sale_home sh = new Sale_home();
            this.Hide();
            sh.Show();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\NabilPatel\Documents\Visual Studio 2010\Projects\ims\ims\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Item where Item_no = '" + qty.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                dataGrid1.ItemsSource = dt.DefaultView;
                sda.Update(dt);

                SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\NabilPatel\Documents\Visual Studio 2010\Projects\ims\ims\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da1 = new SqlDataAdapter();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rat.Text = dt.Rows[i].ItemArray[4].ToString();
                    Int16 trat = Convert.ToInt16(rat.Text);
                    Int16 iqty = Convert.ToInt16(qty.Text);
                    Int32 irat = trat * iqty;
                    rat.Text = irat.ToString();
                    discnt.Text = (Convert.ToInt16(dt.Rows[i].ItemArray[5].ToString()) / 100 * irat).ToString();

                    cmd.CommandText = "INSERT INTO Trans VALUES('" + invc_no.Text + "','" + dt.Rows[i].ItemArray[0] + "','" + 1 + "','" + 1 + "','" + discnt.Text + "','" + rat.Text + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    da1.InsertCommand = cmd;
                    con1.Open();
                    da1.InsertCommand.ExecuteNonQuery();
                }
                con1.Close();
                con.Close();

                SqlConnection con2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\NabilPatel\Documents\Visual Studio 2010\Projects\ims\ims\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda2 = new SqlDataAdapter("Select * From Bill where Bill_no = '"+invc_no.Text+"'", con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                con2.Open();
                dataGrid1.ItemsSource = dt2.DefaultView;
                sda2.Update(dt2);
                con2.Close();

                tqty.Text = (Convert.ToInt32(tqty.Text) + Convert.ToInt32(qty.Text)).ToString();
                tdiscnt.Text = (Convert.ToInt32(tdiscnt.Text) + Convert.ToInt32(discnt.Text)).ToString();
                textBox1.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(rat.Text)).ToString();
            }      
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            qty.Text = "1";
            tqty.Text = "0";
            tdiscnt.Text = "0";
            textBox1.Text = "0";

            dtl.Content = System.DateTime.Today;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\NabilPatel\Documents\Visual Studio 2010\Projects\ims\ims\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Bill_no From Bill" , con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int j = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                string n = (dt.Rows[j - 1].ItemArray[0].ToString());
                Int16 k = Convert.ToInt16(n);
                string s = "" + (k + 1);
                invc_no.Text = s;
            }
            else
            {
                invc_no.Text = "1";
            }   
        }
        private void edt_Click(object sender, RoutedEventArgs e)
        {
            if (barcd.Text.Equals(""))
            {
                MessageBox.Show("Enter Barcode!");
            }

            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\NabilPatel\Documents\Visual Studio 2010\Projects\ims\ims\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Item where Barcode = '" + qty.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                dataGrid1.ItemsSource = dt.DefaultView;
                sda.Update(dt);

                SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\NabilPatel\Documents\Visual Studio 2010\Projects\ims\ims\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da1 = new SqlDataAdapter();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rat.Text = dt.Rows[i].ItemArray[4].ToString();
                    Int16 trat = Convert.ToInt16(rat.Text);
                    Int16 iqty = Convert.ToInt16(qty.Text);
                    Int32 irat = trat * iqty;
                    rat.Text = irat.ToString();
                    discnt.Text = (Convert.ToInt16(dt.Rows[i].ItemArray[5].ToString()) / 100 * irat).ToString();

                    cmd.CommandText = "INSERT INTO Bill VALUES('" + invc_no.Text + "','" + dt.Rows[i].ItemArray[1] + "','" + dt.Rows[i].ItemArray[0] + "','" + qty.Text + "','" + discnt.Text + "','" + rat.Text + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    da1.InsertCommand = cmd;
                    con1.Open();
                    da1.InsertCommand.ExecuteNonQuery();

                }
               
                con1.Close();
                con.Close();

                SqlConnection con2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\NabilPatel\Documents\Visual Studio 2010\Projects\ims\ims\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda2 = new SqlDataAdapter("Select * From Bill where Invoice_no = '" + invc_no.Text + "'", con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                con2.Open();
                dataGrid1.ItemsSource = dt2.DefaultView;
                sda2.Update(dt2);
                con2.Close();

                tqty.Text = (Convert.ToInt32(tqty.Text) + Convert.ToInt32(qty.Text)).ToString();
                tdiscnt.Text = (Convert.ToInt32(tdiscnt.Text) + Convert.ToInt32(discnt.Text)).ToString();
                textBox1.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(rat.Text)).ToString();
            }
        }
    }
}
