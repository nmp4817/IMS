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
    /// Interaction logic for Order_item.xaml
    /// </summary>
    public partial class Order_item : Window
    {
        public Order_item()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int add1 = 0;

            var datestring = datePicker1.SelectedDate.ToString();
            string s = Convert.ToString(datestring);
            if (s.Equals("")) { MessageBox.Show("Select Date"); }
            else s = s.Substring(0, 8);

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Item where Item_no = '" + ino.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            if (dt.Rows.Count == 0)
            { add1 = 1; MessageBox.Show("No Item Of this ItemID"); }
            con.Close();

            SqlDataAdapter sda1 = new SqlDataAdapter("Select * From Supplier where S_id = '" + sid.Text + "' ", con);
            DataTable dt1 = new DataTable();
            con.Open();
            sda1.Fill(dt1);
            if (dt1.Rows.Count == 0)
            { add1 = 2; MessageBox.Show("No Supplier Of this SupplierID"); }
            con.Close();

            SqlDataAdapter sda8 = new SqlDataAdapter("Select * from Supplier_item where S_id = '" + sid.Text + "' and Item_no = '" + ino.Text + "' ", con);
            DataTable dt4 = new DataTable();
            con.Open();
            sda8.Fill(dt4);
            if (dt4.Rows.Count == 0)
            { add1 = 4; MessageBox.Show("Supplier_ID and Item_no doesnot match !"); }
            con.Close();

            SqlDataAdapter sda2 = new SqlDataAdapter("Select * from Order1 where Sid = '" + sid.Text + "' and Item_no = '" + ino.Text + "' and O_date='"+s+"'", con);
            DataTable dt2 = new DataTable();
            con.Open();
            sda2.Fill(dt2);
            con.Close();
            if (dt2.Rows.Count > 0)
            { 
                add1 = 3;
                SqlDataAdapter sda4 = new SqlDataAdapter();
                SqlCommand cmd4 = new SqlCommand();
                cmd4.CommandText = "Update Order1 set Order_qty = CONVERT(varchar(50),CONVERT(INT,Order_qty)+" + Convert.ToInt32(qty.Text) + ") where Sid = '" + sid.Text + "' and Item_no = '" + ino.Text + "' and O_date='" + s + "' ";
                cmd4.CommandType = CommandType.Text;
                cmd4.Connection = con;
                con.Open();
                sda4.UpdateCommand = cmd4;
                sda4.UpdateCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been Updated!"); 
            }        

            if (add1 == 0)
            {
                SqlConnection con3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda3 = new SqlDataAdapter();
                SqlCommand cmd3 = new SqlCommand();
                if (sid.Text.Equals("") || ino.Text.Equals("") || qty.Text.Equals("") || s.Equals(""))
                {
                    MessageBox.Show("MAKE SURE YOU DONT HAVE ANY EMPTY FIELD");
                }
                else
                {
                    cmd3.CommandText = "INSERT INTO Order1 VALUES('" + sid.Text + "','" + ino.Text + "','" + qty.Text + "','" + s + " ')";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Connection = con3;
                    sda3.InsertCommand = cmd3;
                    con3.Open();
                    sda3.InsertCommand.ExecuteNonQuery();
                    con3.Close();
                    MessageBox.Show("ITEM ORDERED SUCCESSFULLY");
                }
            }
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            Check_inv ci = new Check_inv();
            this.Hide();
            ci.Show();
        }

    }
}
