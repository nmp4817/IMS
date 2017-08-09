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
    /// Interaction logic for Add_purchase.xaml
    /// </summary>
    public partial class Add_purchase : Window
    {
        public Add_purchase()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            int add1 = 0;

            var datestring = datePicker1.SelectedDate.ToString();
            string s = Convert.ToString(datestring);
            if (s.Equals("")) { MessageBox.Show("Select Purchase Date"); }
            else { s = s.Substring(0, 8); }

            var datestring2 = datePicker2.SelectedDate.ToString();
            string s2 = Convert.ToString(datestring2);
            if (s2.Equals("")) { MessageBox.Show("Select Expiry Date"); }
            else { s2 = s2.Substring(0, 8); }
            
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

            SqlDataAdapter sda2 = new SqlDataAdapter("Select * from Purchase_item where Sid = '" + sid.Text + "' and Item_no = '" + ino.Text + "' and Batch_no = '" + bno.Text + "'", con);
            DataTable dt2 = new DataTable();
            con.Open();
            sda2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            { add1 = 3; MessageBox.Show("Data has been already inserted!"); }
            con.Close();

            SqlDataAdapter sda8 = new SqlDataAdapter("Select * from Supplier_item where S_id = '" + sid.Text + "' and Item_no = '" + ino.Text + "' ", con);
            DataTable dt4 = new DataTable();
            con.Open();
            sda8.Fill(dt4);
            if (dt4.Rows.Count == 0)
            { add1 = 4; MessageBox.Show("Supplier_ID and Item_no doesnot match !"); }
            con.Close();
            
            if (add1 == 0)
            {
                SqlConnection con3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda3 = new SqlDataAdapter();
                SqlCommand cmd3 = new SqlCommand();
                if (sid.Text.Equals("") || ino.Text.Equals("") || qty.Text.Equals("") || bno.Text.Equals("") || s.Equals(""))
                {
                    MessageBox.Show("MAKE SURE YOU DONT HAVE ANY EMPTY FIELD");
                }
                else
                {
                    cmd3.CommandText = "INSERT INTO Purchase_item VALUES('" + sid.Text + "','" + ino.Text + "','" + qty.Text + "','" + bno.Text + "','" + s + " ')";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Connection = con3;
                    sda3.InsertCommand = cmd3;
                    con3.Open();
                    sda3.InsertCommand.ExecuteNonQuery();
                    con3.Close();

                    SqlDataAdapter sda5 = new SqlDataAdapter("select * from Stock where Item_no='" + ino.Text + "' and Batch_no='" + bno.Text + "' ", con);
                    DataTable dt3 = new DataTable();
                    sda5.Fill(dt3);
                    if (dt3.Rows.Count == 1)
                    {
                        MessageBox.Show("ENTER VALID BATCH NO ! THIS BATCH NO IS ALREADY EXISTS!");
                    }


                    else if (dt3.Rows.Count == 0)
                    {
                        SqlDataAdapter sda6 = new SqlDataAdapter();
                        SqlCommand cmd5 = new SqlCommand();
                        cmd5.CommandText = "Insert into Stock Values('" + ino.Text + "','" + bno.Text + "','" + qty.Text + "','" + s2 + "')";
                        cmd5.CommandType = CommandType.Text;
                        cmd5.Connection = con3;
                        sda6.UpdateCommand = cmd5;
                        con3.Open();
                        sda6.UpdateCommand.ExecuteNonQuery();
                        con3.Close();
                    }

                    SqlDataAdapter sda7 = new SqlDataAdapter();
                    SqlCommand cmd6 = new SqlCommand();
                    cmd6.CommandText = "update Stock_Item set Tot_qty=CONVERT(varchar(50),CONVERT(INT,Tot_qty)+" + Convert.ToInt32(qty.Text) + ") where Item_no='" + ino.Text + "' ";
                    cmd6.CommandType = CommandType.Text;
                    cmd6.Connection = con3;
                    sda7.UpdateCommand = cmd6;
                    con3.Open();
                    sda7.UpdateCommand.ExecuteNonQuery();
                    con3.Close();


                    MessageBox.Show("ITEM ADDED SUCCESSFULLY");
                }
            }
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            Inventory_manager_home imh = new Inventory_manager_home();
            this.Hide();
            imh.Show();
        }
    }
}
