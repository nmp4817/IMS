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
    public partial class Dvs : Form
    {
        public Dvs()
        {
            InitializeComponent();
        }

        private void uid_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Report_sale where User_id = '" + uid.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.chart1.Series["SALES"].Points.AddXY(dt.Rows[i].ItemArray[3], Convert.ToDouble(dt.Rows[i].ItemArray[2]));
            }
        }
    }
}
