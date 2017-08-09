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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Inventory_management_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string u_id = "";
        static string dt1 ="";
        static string lit = "";
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Password.Equals(""))
            {
                MessageBox.Show("Please Enter Username or Password");
            }
            else
            {
                string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string path = (System.IO.Path.GetDirectoryName(executable));
                //AppDomain.CurrentDomain.SetData("DataDirectory", path);

                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Login where User_id = '" + textBox1.Text + "' and Password = '" + textBox2.Password + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][2].ToString().Equals("1"))
                    {
                        u_id = textBox1.Text;
                        Sale_home sh = new Sale_home();
                        this.Hide();
                        sh.Show();
                        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                        SqlCommand cmd = new SqlCommand();
                        SqlDataAdapter da1 = new SqlDataAdapter();

                        dt1 = DateTime.Now.ToString("dd/MM/yy");
                        lit = DateTime.Now.ToString("hh:mm:ss");
                        //DateTime cdt = Convert.ToDateTime(dt1);
                        //DateTime clit = Convert.ToDateTime(lit);


                        cmd.CommandText = "INSERT INTO Cashier_details VALUES('" + textBox1.Text + "','" + dt1 + "','" + lit + "','','0','0')";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con1;

                        da1.InsertCommand = cmd;
                        con1.Open();
                        da1.InsertCommand.ExecuteNonQuery();
                        con1.Close();

                        int fl=0;

                        SqlDataAdapter sda4 = new SqlDataAdapter("Select * From Report_sale where User_id = '" + textBox1.Text + "' and Login_date = '" + dt1 + "'", con);
                        DataTable dt4 = new DataTable();
                        sda4.Fill(dt4);
                        if (dt4.Rows.Count == 0)
                        { fl = 1; }

                        if (fl == 1)
                        {
                            SqlCommand cmd3 = new SqlCommand();
                            SqlDataAdapter sda3 = new SqlDataAdapter();
                            cmd3.CommandText = "insert into Report_sale values('" + textBox1.Text + "','0','0','" + dt1 + "')";
                            cmd3.CommandType = CommandType.Text;
                            cmd3.Connection = con1;
                            sda3.UpdateCommand = cmd3;
                            con1.Open();
                            sda3.UpdateCommand.ExecuteNonQuery();
                            con1.Close();
                        }

                    }
                    else if (dt.Rows[0][2].ToString().Equals("2"))
                    {
                        u_id = textBox1.Text;
                        Sale_manager_home smh = new Sale_manager_home();
                        this.Hide();
                        smh.Show();

                        dt1 = DateTime.Now.ToString("dd/MM/yy");
                        lit = DateTime.Now.ToString("hh:mm:ss");

                    }
                    else if (dt.Rows[0][2].ToString().Equals("3"))
                    {
                        u_id = textBox1.Text;
                        Inventory_manager_home imh = new Inventory_manager_home();
                        this.Hide();
                        imh.Show();
                        dt1 = DateTime.Now.ToString("dd/MM/yy");
                        lit = DateTime.Now.ToString("hh:mm:ss");
                    }
                    else if (dt.Rows[0][2].ToString().Equals("4"))
                    {
                        u_id = textBox1.Text;
                        Admin_home ah = new Admin_home();
                        this.Hide();
                        ah.Show();
                        dt1 = DateTime.Now.ToString("dd/MM/yy");
                        lit = DateTime.Now.ToString("hh:mm:ss");
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Username or Password");
                }
            }
        }

        public static string get_user()
        {
            return u_id;
        }
        public static string get_date()
        {
            return dt1;
        }
        public static string get_logintime()
        {
            return lit;
        }
    }
}
