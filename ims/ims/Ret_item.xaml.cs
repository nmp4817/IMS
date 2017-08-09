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
    /// Interaction logic for Ret_item.xaml
    /// </summary>
    public partial class Ret_item : Window
    {
        public Ret_item()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            int add1 = 0;

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");            
            SqlDataAdapter sda4 = new SqlDataAdapter("Select * From Bill_details where Bill_no = '" + bno.Text + "' and Item_no='" + ino.Text + "' ", con);
            DataTable dt4 = new DataTable();
            con.Open();
            sda4.Fill(dt4);
            if (dt4.Rows.Count == 0)
            { add1 = 4; MessageBox.Show("BILL DOES NOT CONTAIN THIS ITEM!"); }
            con.Close();

            string s = "";
            string dt1 = "";
            SqlDataAdapter sda2 = new SqlDataAdapter("Select * from Supplier_item ", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[1].ToString().Equals(ino.Text)) 
                {
                    s = dt.Rows[i].ItemArray[0].ToString();
                }
            }
            dt1 = DateTime.Now.ToString("dd/MM/yy");

            SqlConnection con3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda3 = new SqlDataAdapter("Select * from Returned_item ", con3);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);

            int fl = 0;
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                if (dt3.Rows[i].ItemArray[0].ToString().Equals(ino.Text) && dt3.Rows[i].ItemArray[2].ToString().Equals(bno.Text))
                {
                    fl = 1;
                }
            }

            if(add1==0)
            if (fl == 0)
            {
                SqlConnection con5 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda5 = new SqlDataAdapter();
                SqlCommand cmd5 = new SqlCommand();

                cmd5.CommandText = "INSERT INTO Returned_item VALUES('" + ino.Text + "','" + s + "','" + bno.Text + "','" + dt1 + "')";
                cmd5.CommandType = CommandType.Text;
                cmd5.Connection = con5;
                sda5.InsertCommand = cmd5;
                con5.Open();
                sda5.InsertCommand.ExecuteNonQuery();
                con5.Close();

                MessageBox.Show("Item Returned successfully");
            }
            else
            {
                MessageBox.Show("Item is already Returned");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Sale_manager_home smh = new Sale_manager_home();
            smh.Show();
            this.Hide();
        }
    }
}
