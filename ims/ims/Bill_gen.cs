using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace Inventory_management_system
{
    public partial class Bill_gen : Form
    {
        SqlCommandBuilder scb;
        SqlConnection con2;
        SqlDataAdapter sda2;
        DataSet ds;
        Double discnt;
        int rm = 0;
        public Bill_gen()
        {
            InitializeComponent();
           
        }
        private void Bill_gen_Load(object sender, EventArgs e)
        {
            tqty.Text = "0";
            tdiscnt.Text = "0";
            tprice.Text = "0";
            label8.Text = DateTime.Now.ToString("dd/MM/yy");
            label9.Text = DateTime.Now.ToString("hh:mm:ss");
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Bill_no From Bill", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            billno.Text = "" + (dt.Rows.Count + 1);
        }
        private void itemno_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int fl = 1;
            if (e.KeyCode == Keys.Enter)
            {
                rm = 1;
                if (itemno.Text.Equals(""))
                {
                    MessageBox.Show("Enter ItemNumber!");
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                    SqlDataAdapter sda = new SqlDataAdapter("Select * From Item where Item_no = '" + itemno.Text + "' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Open();
                    if (dt.Rows.Count == 1)
                    {
                        fl = 0;
                    }
                    SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da1 = new SqlDataAdapter();
                    if (fl == 0)
                    {
                        itemname.Text = dt.Rows[0].ItemArray[1].ToString();
                        rat.Text = dt.Rows[0].ItemArray[2].ToString();
                        Int16 trat = Convert.ToInt16(rat.Text);
                        Int16 iqty = Convert.ToInt16("1");
                        Int32 irat = trat * iqty;
                        rat.Text = irat.ToString();
                        discnt = ((Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString()) / 100) * irat);
                        SqlConnection con3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                        SqlDataAdapter sda3 = new SqlDataAdapter("Select Item_no From Trans where Item_no = '" + itemno.Text + "' and Bill_no = '" + billno.Text + "' ", con);
                        DataTable dt3 = new DataTable();
                        SqlCommand cmd3 = new SqlCommand();
                        sda3.Fill(dt3);
                        if (dt3.Rows.Count == 0)
                        {
                            cmd.CommandText = "INSERT INTO Trans VALUES('" + billno.Text + "','" + dt.Rows[0].ItemArray[0].ToString() + "','" + dt.Rows[0].ItemArray[1].ToString() + "','" + 1 + "','" + dt.Rows[0].ItemArray[2].ToString() + "','" + rat.Text + "','" + discnt + "')";
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con1;
                            da1.InsertCommand = cmd;
                            con1.Open();
                            da1.InsertCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.CommandText = "UPDATE Trans set Quantity = CONVERT(varchar(50),CONVERT(INT,Quantity)+1) ,Value =CONVERT(varchar(50),(CONVERT(INT, Price)+CONVERT(INT, Value))) , Discount = CONVERT(varchar(50),CONVERT(FLOAT(24),((Quantity)+1)) * ((CONVERT(FLOAT(24),Discount))/CONVERT(FLOAT(24),Quantity)))   where Bill_no = '" + billno.Text + "' and Item_no = '" + itemno.Text + "'";
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            da1.UpdateCommand = cmd;
                            con1.Open();
                            da1.UpdateCommand.ExecuteNonQuery();
                        }
                        con3.Close();
                        con1.Close();
                        con.Close();

                        tqty.Text = (Convert.ToInt32(tqty.Text) + Convert.ToInt32("1")).ToString();
                        tdiscnt.Text = (Convert.ToInt32(tdiscnt.Text) + Convert.ToInt32(discnt)).ToString();
                        tprice.Text = (Convert.ToInt32(tprice.Text) + Convert.ToInt32(rat.Text)).ToString();

                        con2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                        sda2 = new SqlDataAdapter("Select Bill_no,Item_no,Item_name,Quantity,Price,Discount,Value From Trans where Bill_no = '" + billno.Text + "'", con);
                        ds = new DataSet();
                        sda2.Fill(ds, "Trans");
                        con2.Open();
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            rm = 0;
        }
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (rm == 0)
            {
            try
            {
                scb = new SqlCommandBuilder(sda2);
                sda2.Update(ds, "Trans");
                con2.Close();    
            }
            catch (Exception ex) { MessageBox.Show("RETRY! SELECT QUANTITY AND THEN TRY TO CHANGE!"); }
            
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Trans where Bill_no = '" + billno.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Int64 q = 0;
                Int64 p = 0;
                Int64 d = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    q = q + Convert.ToInt64(dt.Rows[i].ItemArray[3]);
                    p = p + Convert.ToInt64(dt.Rows[i].ItemArray[5]);
                    d = d + Convert.ToInt64(dt.Rows[i].ItemArray[6]);
                }

                tqty.Text = q.ToString();
                tdiscnt.Text = d.ToString();
                tprice.Text = p.ToString();
            }
            catch (Exception e1) { MessageBox.Show(e1.Message); }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            rm = 0;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Quantity")
            {
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                string s1 = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString(); //2nd columns cell value
                Int16 q = Convert.ToInt16(s1);
                string s2 = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();

                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From Item where Item_no = '" + s2 + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Int64 p = Convert.ToInt64(dt.Rows[0].ItemArray[2].ToString());
                Int64 np = q * p;
                Double d = Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString());
                Double nd = np * (d / 100);
                con.Close();
                {
                    SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                    SqlCommand cmd1 = new SqlCommand();
                    SqlDataAdapter da1 = new SqlDataAdapter();
                    cmd1.CommandText = "UPDATE Trans set Quantity = ' " + q + " ', Value = ' " + np + " ' , Discount = ' " + nd + " '   where Bill_no = '" + billno.Text + "' and Item_no = '" + s2 + "'";
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Connection = con1;
                    da1.UpdateCommand = cmd1;
                    con1.Open();
                    da1.UpdateCommand.ExecuteNonQuery();
                    con1.Close();
                }
                try
                {
                    SqlConnection con3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                    SqlDataAdapter sda3 = new SqlDataAdapter("Select Bill_no,Item_no,Item_name,Quantity,Price,Discount,Value From Trans where Bill_no = '" + billno.Text + "'", con3);
                    ds.Clear();
                    sda3.Fill(ds, "Trans");
                    DataTable dt3 = new DataTable();
                    sda3.Fill(dt3);
                    con3.Open();
                    dataGridView1.DataSource = ds.Tables[0];
                    con3.Close();

                    int j = dt3.Rows.Count;
                    int i = 0;
                    Int64 tq = 0, tp = 0, td = 0;
                    for (i = 0; i < j; i++)
                    {
                        tq = tq + Convert.ToInt64(dt3.Rows[i].ItemArray[3]);
                        tp = tp + Convert.ToInt64(dt3.Rows[i].ItemArray[6]);
                        td = td + Convert.ToInt64(dt3.Rows[i].ItemArray[5]);
                    }
                    con3.Close();

                    tqty.Text = tq.ToString();
                    tdiscnt.Text = td.ToString();
                    tprice.Text = tp.ToString();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        Bitmap bitmap;
        private void prnt_Click(object sender, EventArgs e)
        {
            SqlConnection con4 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda4 = new SqlDataAdapter("Select Item_no,Quantity From Trans where Bill_no = '" + billno.Text + "' ", con4);
            DataTable dt4 = new DataTable();
            SqlCommand cmd4 = new SqlCommand();
            sda4.Fill(dt4);
            SqlConnection con5 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda5 = new SqlDataAdapter();
            SqlCommand cmd5 = new SqlCommand();

            cmd5.CommandText = "INSERT INTO Bill VALUES('" + billno.Text + "','" + label8.Text + "','" + label9.Text + "','" + tqty.Text + "','" + tdiscnt.Text + "','" + tprice.Text + "',' " + dt4.Rows.Count + " ',' " + MainWindow.get_user() + " ')";
            cmd5.CommandType = CommandType.Text;
            cmd5.Connection = con5;
            sda5.InsertCommand = cmd5;
            con5.Open();
            sda5.InsertCommand.ExecuteNonQuery();
            con5.Close();

            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                cmd5.CommandText = "INSERT INTO Bill_details VALUES('" + billno.Text + "','" + dt4.Rows[i].ItemArray[0] + "','" + dt4.Rows[i].ItemArray[1] + " ')";
                cmd5.CommandType = CommandType.Text;
                cmd5.Connection = con5;
                sda5.InsertCommand = cmd5;
                con5.Open();
                sda5.InsertCommand.ExecuteNonQuery();
                con5.Close();
            }
            //Resize DataGridView to full height.
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height;

            //Create a Bitmap and draw the DataGridView on it.
            bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            //Resize DataGridView back to original height.
            dataGridView1.Height = height;

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();

            cmd5.CommandText = " Delete from Trans ";
            con5.Open();
            cmd5.ExecuteNonQuery();
            con5.Close();
            Int32[] a = new Int32[dt4.Rows.Count];
            Int32[] b = new Int32[dt4.Rows.Count];
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                a[i] = Convert.ToInt32(dt4.Rows[i].ItemArray[1]);
            }

            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                SqlDataAdapter sda6 = new SqlDataAdapter("Select Tot_qty From Stock_Item where  Item_no= '" + dt4.Rows[i].ItemArray[0] + "' ", con5);
                DataTable dt5 = new DataTable();
                sda6.Fill(dt5);
                b[i] = Convert.ToInt32(dt5.Rows[0].ItemArray[0]);
               // MessageBox.Show("" + b[i]);
                b[i] = b[i] - a[i];
                //MessageBox.Show("" + b[i]);
            }

            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                //MessageBox.Show("" + b[i]);
                cmd5.CommandText = "UPDATE Stock_Item SET Tot_qty='" + b[i].ToString() + "' WHERE Item_no = '" + dt4.Rows[i].ItemArray[0] + "'";
                cmd5.CommandType = CommandType.Text;
                cmd5.Connection = con5;

                SqlDataAdapter sda7 = new SqlDataAdapter();
                sda7.UpdateCommand = cmd5;
                con5.Open();
                sda7.UpdateCommand.ExecuteNonQuery();
                con5.Close();

            }
            SqlDataAdapter sda8 = new SqlDataAdapter("Select * From Item i,Stock_Item s where  i.Item_no=s.Item_no and CONVERT(INT,i.Item_cutoff) > CONVERT(INT,s.Tot_qty)", con5);
            DataTable dt = new DataTable();
            sda8.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    MailMessage msg = new MailMessage("hirenvjaiswal1@gmail.com", "madhurgor@gmail.com", "INVENTORY-ITEM NOTIFICATION", "ORDER FOR ITEM_NO : " + dt.Rows[i].ItemArray[0] + " ITEM_NAME : " + dt.Rows[i].ItemArray[1]);//(from,to,subject,body)
                    SmtpClient eclinet = new SmtpClient();
                    eclinet.Send(msg);
                   
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }

                this.Hide();
            
             
        }
        private void PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Print the contents.
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            SqlConnection con5 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda5 = new SqlDataAdapter();
            SqlCommand cmd5 = new SqlCommand();
            cmd5.CommandText = " Delete from Trans ";
            cmd5.CommandType = CommandType.Text;
            cmd5.Connection = con5;
            con5.Open();
            cmd5.ExecuteNonQuery();
            con5.Close();
            this.Hide();
        }

       /* private void sm_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage msg = new MailMessage("hirenvjaiswal1@gmail.com", "madhurgor@gmail.com", "abc", "cde");//(from,to,subject,body)
                SmtpClient eclinet = new SmtpClient();
                eclinet.Send(msg);
                MessageBox.Show("ok");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }*/
    }
}