using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory_management_system
{
    public partial class Dvq : Form
    {
        string s = "";
        
        public Dvq()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
                s = comboBox1.SelectedItem.ToString();
                if (s.Length == 0)
                {
                    s = "";
                }
                else
                {
                    int i = s.IndexOf(':') + 1;
                    int len = s.Length;
                    s = s.Substring(i, (len - i));
                }
                
                SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlDataAdapter sda1 = new SqlDataAdapter("Select * From Report_sale where User_id = '" + s + "' ", con1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    this.chart1.Series["QUANTITY"].Points.AddXY(dt1.Rows[j].ItemArray[3], Convert.ToDouble(dt1.Rows[j].ItemArray[1]));
                }
        }

        private void Dvq_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlCommand cmd1 = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Login where R_id = '1' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i].ItemArray[0]);
            }
        }
    }
}
