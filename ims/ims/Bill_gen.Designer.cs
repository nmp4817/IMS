namespace Inventory_management_system
{
    partial class Bill_gen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bill_gen));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.billno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.itemno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.itemname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.tqty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tdiscnt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tprice = new System.Windows.Forms.TextBox();
            this.prnt = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bill Generation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bill No :";
            // 
            // billno
            // 
            this.billno.Enabled = false;
            this.billno.Location = new System.Drawing.Point(116, 77);
            this.billno.Name = "billno";
            this.billno.Size = new System.Drawing.Size(100, 20);
            this.billno.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(581, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Time :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(348, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Item No :";
            // 
            // itemno
            // 
            this.itemno.Location = new System.Drawing.Point(436, 81);
            this.itemno.Name = "itemno";
            this.itemno.Size = new System.Drawing.Size(100, 20);
            this.itemno.TabIndex = 6;
            this.itemno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemno_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Item Name :";
            // 
            // itemname
            // 
            this.itemname.Enabled = false;
            this.itemname.Location = new System.Drawing.Point(116, 127);
            this.itemname.Name = "itemname";
            this.itemname.Size = new System.Drawing.Size(100, 20);
            this.itemname.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(348, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Rate :";
            // 
            // rat
            // 
            this.rat.Enabled = false;
            this.rat.Location = new System.Drawing.Point(436, 127);
            this.rat.Name = "rat";
            this.rat.Size = new System.Drawing.Size(100, 20);
            this.rat.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(637, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "abc";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(637, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "abc";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(48, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(725, 206);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 432);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Total Quantity :";
            // 
            // tqty
            // 
            this.tqty.Enabled = false;
            this.tqty.Location = new System.Drawing.Point(136, 429);
            this.tqty.Name = "tqty";
            this.tqty.Size = new System.Drawing.Size(100, 20);
            this.tqty.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(379, 432);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Total Discount :";
            // 
            // tdiscnt
            // 
            this.tdiscnt.Enabled = false;
            this.tdiscnt.Location = new System.Drawing.Point(473, 432);
            this.tdiscnt.Name = "tdiscnt";
            this.tdiscnt.Size = new System.Drawing.Size(100, 20);
            this.tdiscnt.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 477);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Total price :";
            // 
            // tprice
            // 
            this.tprice.Enabled = false;
            this.tprice.Location = new System.Drawing.Point(136, 477);
            this.tprice.Name = "tprice";
            this.tprice.Size = new System.Drawing.Size(100, 20);
            this.tprice.TabIndex = 19;
            // 
            // prnt
            // 
            this.prnt.Location = new System.Drawing.Point(382, 477);
            this.prnt.Name = "prnt";
            this.prnt.Size = new System.Drawing.Size(75, 23);
            this.prnt.TabIndex = 20;
            this.prnt.Text = "Print";
            this.prnt.UseVisualStyleBackColor = true;
            this.prnt.Click += new System.EventHandler(this.prnt_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintPage);
            // 
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;            
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(498, 477);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 21;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Bill_gen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 524);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.prnt);
            this.Controls.Add(this.tprice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tdiscnt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tqty);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.itemname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.itemno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.billno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Bill_gen";
            this.Text = "Bill_gen";
            this.Load += new System.EventHandler(this.Bill_gen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox billno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox itemno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox itemname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox rat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tqty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tdiscnt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tprice;
        private System.Windows.Forms.Button prnt;
        private System.Windows.Forms.Button cancel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}