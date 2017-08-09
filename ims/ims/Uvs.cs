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
    public partial class Uvs : Form
    {
        public Uvs()
        {
            InitializeComponent();
        }

        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            var datestring = dateTimePicker1.Value.ToString();
            string s = Convert.ToString(datestring);
            if (!s.Equals(""))
            {
                s = s.Substring(0, 8);
            }
            else
            {
                s = "";
            }
            SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda1 = new SqlDataAdapter("Select * From Report_sale where Login_date = '"+s+"' ", con1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                this.chart1.Series["USERS"].Points.AddXY(dt1.Rows[j].ItemArray[0], Convert.ToDouble(dt1.Rows[j].ItemArray[2]));
            }
            
        }
    }
}
