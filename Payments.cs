﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;

namespace StudentMS
{
    public partial class Payments : Form
    {

        MySqlConnection con = new MySqlConnection("server=localhost;username=root;database=mysql;");
        MySqlCommand com;
        MySqlDataReader dr;

        public void ClosedReader()
        {
            dr = com.ExecuteReader();
            dr.Close();
        }

        public Payments()
        {
            InitializeComponent();
        }

        void FindByIDnumber() {
            Txtclear2();
            com = new MySqlCommand("select * from dbstudent_MS.student where idnumber=@idnumber;", con);
            com.Parameters.AddWithValue("@idnumber", textBox4.Text);
            dr = com.ExecuteReader();
            while (dr.Read()) {

                textBox3.Text = dr.GetString(4).ToString();
                comboBox8.Text = dr.GetString(12).ToString();
                comboBox3.Text = dr.GetString(13).ToString();
                textBox7.Text = dr.GetString(8).ToString();
                textBox18.Text = dr.GetString(23).ToString();
                label24.Text = dr.GetString(6).ToString();
            }
            dr.Close();
        }

        void Create_tb_payments_history()
        {
            com = new MySqlCommand("create table if not exists dbstudent_MS.paymentshistory(id int(100) auto_increment primary key, monthcode text, date text, idnumber text, fullname text, kinderlevel text, section text, parent text, balance text, currentbalance text, payment text, logoqty text, logocost text, logoamount text, bookqty text, bookcost text, bookamount text, PEqty text, PEcost text, PEamount text, uniformqty text, uniformcost text, uniformamount text, additionalamount text, AmountToPay text, cash text, change1 text, processedby text);", con);
            ClosedReader();

        }

        void PaymentHistoryParams() {
            com.Parameters.AddWithValue("@monthcode", label41.Text);
            com.Parameters.AddWithValue("@date", Form1.instance.lb4.Text);
            com.Parameters.AddWithValue("@idnumber", textBox4.Text);
            com.Parameters.AddWithValue("@fullname", textBox3.Text);
            com.Parameters.AddWithValue("@kinderlevel", comboBox8.Text);
            com.Parameters.AddWithValue("@section", comboBox3.Text);
            com.Parameters.AddWithValue("@parent", textBox7.Text);
            com.Parameters.AddWithValue("@balance", textBox18.Text);
            com.Parameters.AddWithValue("@currentbalance", textBox5.Text);
            com.Parameters.AddWithValue("@payment", textBox1.Text);
            com.Parameters.AddWithValue("@logoqty", textBox6.Text);
            com.Parameters.AddWithValue("@logocost", textBox14.Text);
            com.Parameters.AddWithValue("@logoamount", textBox15.Text);
            com.Parameters.AddWithValue("@bookqty", textBox8.Text);
            com.Parameters.AddWithValue("@bookcost", textBox13.Text);
            com.Parameters.AddWithValue("@bookamount", textBox16.Text);
            com.Parameters.AddWithValue("@PEqty", textBox9.Text);
            com.Parameters.AddWithValue("@PEcost", textBox12.Text);
            com.Parameters.AddWithValue("@PEamount", textBox17.Text);
            com.Parameters.AddWithValue("@uniformqty", textBox10.Text);
            com.Parameters.AddWithValue("@uniformcost", textBox11.Text);
            com.Parameters.AddWithValue("@uniformamount", textBox19.Text);
            com.Parameters.AddWithValue("@additionalamount", textBox20.Text);
            com.Parameters.AddWithValue("@amounttopay", label22.Text);
            com.Parameters.AddWithValue("@cash", textBox21.Text);
            com.Parameters.AddWithValue("@change1", textBox2.Text);
            com.Parameters.AddWithValue("@processedby", Form1.instance.lb7.Text);
        }

        void NewPayments() {

            com = new MySqlCommand("update dbstudent_MS.student set idnumber=@idnumber, totalbalance=@totalbalance where idnumber=@idnumber;", con);
            com.Parameters.AddWithValue("@idnumber", textBox4.Text);
            com.Parameters.AddWithValue("@totalbalance", textBox5.Text);
            ClosedReader();

            com = new MySqlCommand("insert into dbstudent_MS.paymentshistory(monthcode, date, idnumber, fullname, kinderlevel, section, parent, balance, currentbalance, payment, logoqty, logocost, logoamount, bookqty, bookcost, bookamount, PEqty, PEcost, PEamount, uniformqty, uniformcost, uniformamount, additionalamount, amounttopay, cash, change1, processedby)values(@monthcode, @date, @idnumber, @fullname, @kinderlevel, @section, @parent, @balance, @currentbalance, @payment, @logoqty, @logocost, @logoamount, @bookqty, @bookcost, @bookamount, @PEqty, @PEcost, @PEamount, @uniformqty, @uniformcost, @uniformamount, @additionalamount, @amounttopay, @cash, @change1, @processedby)", con); PaymentHistoryParams();ClosedReader();
        }


        void Select_PaymentsHistory() {
            com = new MySqlCommand("select * from dbstudent_MS.paymentshistory where id=@id;", con);
            com.Parameters.AddWithValue("@id", listView1.FocusedItem.Text);
            dr = com.ExecuteReader();
            while (dr.Read()) {
                label54.Text = dr.GetInt32(0).ToString();
                label56.Text = dr.GetString(2).ToString();
                label53.Text = dr.GetString(3).ToString();
                label52.Text = dr.GetString(5).ToString();
                label51.Text = dr.GetString(8).ToString();
            }dr.Close();

        }

        void CancelPayment() {
            com = new MySqlCommand("update dbstudent_MS.student set idnumber=@idnumber and kinderlevel=@kinderlevel, totalbalance=@totalbalance where idnumber=@idnumber and kinderlevel=@kinderlevel;", con);
            com.Parameters.AddWithValue("@idnumber", label53.Text);
            com.Parameters.AddWithValue("@kinderlevel", label52.Text);
            com.Parameters.AddWithValue("@totalbalance", label51.Text);
            ClosedReader();

            com = new MySqlCommand("update dbstudent_MS.paymentshistory set  id=@id, amounttopay='CANCELLED' where id=@id;", con);
            com.Parameters.AddWithValue("@id", label54.Text);
            ClosedReader();
        }



        void ShortcutDisplay()
        {
            ListViewItem lvi = new ListViewItem(dr.GetInt32(0).ToString());
            int lvi_c;
            for (lvi_c = 1; lvi_c <= 27; lvi_c += 1)
            {
                lvi.SubItems.Add(dr.GetString(lvi_c).ToString()).BackColor = Color.White;
            }
            listView1.Items.Add(lvi);
            lvi.UseItemStyleForSubItems = false;
        }


        void ReloadPayments()
        {
            listView1.Items.Clear();
            com = new MySqlCommand("select * from dbstudent_MS.paymentshistory order by id desc;", con);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                //LongcutDisplay();
                ShortcutDisplay();
            }
            dr.Close();
            AutoCounts1();
          //  Autocounts();
        }

        void SearchPaymentsBy_Monthcode()
        {
            listView1.Items.Clear();
            com = new MySqlCommand("select * from dbstudent_MS.paymentshistory where monthcode like @monthcode order by id desc;", con);
            com.Parameters.AddWithValue("@monthcode", "%" + textBox23.Text + "%");
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                //LongcutDisplay();
                ShortcutDisplay();
            }
            dr.Close();
            //  Autocounts();
        }

        void SearchPaymentsBy_IDnumber_fullname()
        {
            listView1.Items.Clear();
            com = new MySqlCommand("select * from dbstudent_MS.paymentshistory where idnumber like @search or fullname like @search order by id desc;", con);
            com.Parameters.AddWithValue("@search", "%" +textBox22.Text+"%");
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                //LongcutDisplay();
                ShortcutDisplay();
            }
            dr.Close();
            //  Autocounts();
        }

        void SearchPaymentsBy_Kinderlevel()
        {
            listView1.Items.Clear();
            com = new MySqlCommand("select * from dbstudent_MS.paymentshistory where kinderlevel=@search order by id desc;", con);
            com.Parameters.AddWithValue("@search", comboBox7.Text);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                //LongcutDisplay();
                ShortcutDisplay();
            }
            dr.Close();
            //  Autocounts();
        }

        void AutoCounts1() {
            com = new MySqlCommand("select count(id) from dbstudent_MS.paymentshistory;", con);
            dr = com.ExecuteReader();
            while (dr.Read()) { label30.Text = dr.GetInt32(0).ToString(); }dr.Close();

            com = new MySqlCommand("select count(kinderlevel) from dbstudent_MS.paymentshistory where kinderlevel='PRE KINDER 1' and amounttopay != 'CANCELLED';", con);
            dr = com.ExecuteReader();
            while (dr.Read()) { label31.Text = dr.GetInt32(0).ToString(); }dr.Close();

            com = new MySqlCommand("select count(kinderlevel) from dbstudent_MS.paymentshistory where kinderlevel='PRE KINDER 2' and amounttopay != 'CANCELLED';", con);
            dr = com.ExecuteReader();
            while (dr.Read()) { label34.Text = dr.GetInt32(0).ToString(); }dr.Close();

            com = new MySqlCommand("select count(kinderlevel) from dbstudent_MS.paymentshistory where kinderlevel='KINDER' and amounttopay != 'CANCELLED';", con);
            dr = com.ExecuteReader();
            while (dr.Read()) { label38.Text = dr.GetInt32(0).ToString(); }dr.Close();

        }


        private void Payments_Load(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            ControlBox = false;
            WindowState = FormWindowState.Maximized;
            Lvs();
            groupBox4.Enabled = false;
          //  label50.Text = DateTime.Now.ToString("");
            label41.Text = DateTime.Now.ToString("MMMyyyy");
            ReloadPayments();


        }

        public void Lvs()
        {
            listView1.BackColor = Color.MediumBlue;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Columns.Clear();
            listView1.Columns.Add("#", 0);
            listView1.Columns.Add("MonthCode", 100);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("ID Number", 120);
            listView1.Columns.Add("Fullname", 200);
            listView1.Columns.Add("Kinder Level", 140);
            listView1.Columns.Add("Section", 100);
            listView1.Columns.Add("Parent", 150);
            listView1.Columns.Add("Balance", 100);
            listView1.Columns.Add("Current Balance", 140);
            listView1.Columns.Add("Payment", 100);
            listView1.Columns.Add("Logo QTY", 100);
            listView1.Columns.Add("Logo Cost", 100);
            listView1.Columns.Add("Logo Amount", 120);
            listView1.Columns.Add("Book QTY", 100);
            listView1.Columns.Add("Book Cost", 100);
            listView1.Columns.Add("Book Amount", 120);
            listView1.Columns.Add("PE QTY", 100);
            listView1.Columns.Add("PE Cost", 100);
            listView1.Columns.Add("PE Amount", 120);
            listView1.Columns.Add("Uniform QTY", 140);
            listView1.Columns.Add("Uniform Cost", 140);
            listView1.Columns.Add("Uniform Amount", 140);
            listView1.Columns.Add("Additional Amount", 145);
            listView1.Columns.Add("Amount Paid", 145);
            listView1.Columns.Add("Cash", 80);
            listView1.Columns.Add("Change", 80);
            //   listView1.Columns.Add("Payment", 145);
            //  listView1.Columns.Add("Payment", 145);
            listView1.Columns.Add("Processed By", 200);
            listView1.Columns.Add("", 40);

            comboBox7.FlatStyle = FlatStyle.Popup;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.Items.Clear();
            comboBox7.Items.Add("ALL");
            comboBox7.Items.Add("PRE KINDER 1");
            comboBox7.Items.Add("PRE KINDER 2");
            comboBox7.Items.Add("KINDER");
            comboBox7.Text = "ALL";

        }

            void Txtclear() {
            textBox4.Clear();
            textBox3.Clear();
            textBox7.Clear();
            textBox18.Text= "0";
            textBox19.Text = "0";
            textBox17.Text = "0";
            textBox16.Text = "0";
            textBox15.Text = "0";
            textBox1.Clear();
            textBox5.Text = "0";
            textBox2.Text = "0";
            textBox20.Text = "0";
            textBox6.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
         //   textBox11.Clear();
            comboBox3.Text = "";
            comboBox8.Text = "";
            textBox21.Clear();
            textBox2.Text ="0";
            checkBox1.Checked = false;
        }

        void Txtclear2()
        {
            textBox3.Clear();
            textBox7.Clear();
            textBox18.Text = "0";
            textBox1.Clear();
            textBox5.Text = "0";
            textBox2.Text = "0";
            textBox6.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            //textBox11.Clear();
            comboBox3.Text = "";
            comboBox8.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int txt2;
            txt2 = Convert.ToInt32(textBox2.Text);
            if (textBox4.Text == "" || textBox1.Text == "" || textBox21.Text == "")
            {
                MessageBox.Show("Please input all required information like ID number, payment and cash first.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else if ( txt2 < 0) {
                MessageBox.Show("Please input exact amount of cash. Thank you!", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox21.Clear();
            }
            else {
                NewPayments();
                MessageBox.Show("A new payment of Mr/Mrs. " + textBox7.Text + " is now added in the payment history", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                printPreviewControl1.Refresh();
                printPreviewControl1.Zoom = 0.70;
                printPreviewControl1.Rows = 2;
                printPreviewControl1.Document = printDocument1;
                printDocument1.Print();
                Txtclear();
                ReloadPayments();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int printme;
            e.Graphics.DrawImage(pictureBox1.Image, new Rectangle(20, 20, 75, 75));
            printme = 20;
            e.Graphics.DrawString("United Methodist Church School Inc.", new System.Drawing.Font("Microsoft Sans Serif", 14, FontStyle.Bold), Brushes.Black, 102, printme);
            printme += 20;
            e.Graphics.DrawString("12 Marcos Avenue, Alaminos City,", new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 102, printme);
            printme += 15;
            e.Graphics.DrawString("Pangasinan, Philippines, 2404", new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 102, printme);
            printme += 20;
            e.Graphics.DrawString("Printed Date: " + Form1 .instance.lb4.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 102, printme);
            printme += 20;
            e.Graphics.DrawString("Printed By: " + Form1.instance.lb7.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 102, printme);
            printme += 20;
            e.Graphics.DrawString("Parent Name: " +  textBox7.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 10, printme);
            printme += 20;
            e.Graphics.DrawString("Student ID number: " + textBox4.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 10, printme);
            e.Graphics.DrawString("Student Name: " + textBox3.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 300, printme);
            printme += 20;
            e.Graphics.DrawString("Kinder Level: " + comboBox8.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 10, printme);
            e.Graphics.DrawString("Section: " + comboBox3.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 300, printme);
            printme += 20;
            e.Graphics.DrawString("________________________________________________________________________________________________________________________________________________________", new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular), Brushes.Black, 10, printme);
            printme += 15;
            e.Graphics.DrawString("Balance", new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 10, printme);
            e.Graphics.DrawString("Payment", new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 150, printme);
            e.Graphics.DrawString("Current Balance", new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold ), Brushes.Black, 300, printme);
            printme += 15;
            e.Graphics.DrawString("________________________________________________________________________________________________________________________________________________________", new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular), Brushes.Black, 10, printme);
            printme += 20;
            e.Graphics.DrawString("₱" + textBox18.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 10, printme);
            e.Graphics.DrawString("₱" + textBox1.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 150, printme);
            e.Graphics.DrawString("₱" + textBox5.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 300, printme);
         
            printme += 20;

            if (checkBox1.Checked == false)
            {

            }
            else {
               
                e.Graphics.DrawString("________________________________________________________________________________________________________________________________________________________", new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular), Brushes.Black, 10, printme);
                printme += 15;
                e.Graphics.DrawString("ADDITIONAL", new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 10, printme);
                e.Graphics.DrawString("Quantity", new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Bold), Brushes.Black, 150, printme);
                e.Graphics.DrawString("Cost", new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Bold), Brushes.Black, 300, printme);
                e.Graphics.DrawString("Amount", new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Bold), Brushes.Black, 450, printme);
                printme += 12;
                e.Graphics.DrawString("________________________________________________________________________________________________________________________________________________________", new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular), Brushes.Black, 10, printme);
                printme += 20;
                e.Graphics.DrawString("Logo", new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 10, printme);
                e.Graphics.DrawString(textBox6.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 150, printme);
                e.Graphics.DrawString("₱" + textBox14.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 300, printme);
                e.Graphics.DrawString("₱" + textBox15.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 450, printme);
                printme += 20;
                e.Graphics.DrawString("Books", new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 10, printme);
                e.Graphics.DrawString(textBox8.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 150, printme);
                e.Graphics.DrawString("₱" + textBox13.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 300, printme);
                e.Graphics.DrawString("₱" + textBox16.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 450, printme);
                printme += 20;
                e.Graphics.DrawString("P.E.", new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 10, printme);
                e.Graphics.DrawString(textBox9.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 150, printme);
                e.Graphics.DrawString("₱" + textBox12.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 300, printme);
                e.Graphics.DrawString("₱" + textBox17.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 450, printme);
                printme += 20;
                e.Graphics.DrawString("Girl Uniform", new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 10, printme);
                e.Graphics.DrawString(textBox10.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 150, printme);
                e.Graphics.DrawString("₱" + textBox11.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 300, printme);
                e.Graphics.DrawString("₱" + textBox19.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 450, printme);
                printme += 20;
                e.Graphics.DrawString("________________________________________________________________________________________________________________________________________________________", new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular), Brushes.Black, 10, printme);
                printme += 15;
                e.Graphics.DrawString("Additional Amount:", new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular), Brushes.Black, 300, printme);
                e.Graphics.DrawString("₱" +textBox20.Text, new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Bold), Brushes.Black, 450, printme);

            }
            printme += 12;
            e.Graphics.DrawString("________________________________________________________________________________________________________________________________________________________", new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular), Brushes.Black, 10, printme);
            printme += 20;
            e.Graphics.DrawString("Amount To Pay:", new System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold), Brushes.Black, 300, printme);
            e.Graphics.DrawString("₱" + label22.Text, new System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold), Brushes.Black, 450, printme);
            e.Graphics.DrawString("Cash: ₱ " + textBox21.Text, new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 10, printme);
            e.Graphics.DrawString("Change: ₱ " + textBox2.Text, new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 150, printme);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Refresh();
            printPreviewControl1.Zoom = 0.70;
            printPreviewControl1.Rows = 2;
            printPreviewControl1.Document = printDocument1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox4.Enabled = true;
                
            }
            else {
                textBox6.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                groupBox4.Enabled = false;
               
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            FindByIDnumber();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8.MaxLength = 1;
            if (textBox8.Text == "")
            {
                textBox16.Text = "0";
            }
            try
            {

                int n1, n2, n3;
                n1 = Convert.ToInt32(textBox8.Text);
                n2 = Convert.ToInt32(textBox13.Text);
                n3 = n1 * n2;
                textBox16.Text = n3.ToString();
            }
            catch { }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.MaxLength = 1;
            if (textBox6.Text == "") {
                textBox15.Text = "0";
            }
            try {

                int n1, n2, n3;
                n1 = Convert.ToInt32(textBox6.Text);
                n2 = Convert.ToInt32(textBox14.Text);
                n3 = n1 * n2;
                textBox15.Text = n3.ToString();
            }
            catch { }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox9.MaxLength = 1;
            if (textBox9.Text == "")
            {
                textBox17.Text = "0";
            }

            try
            {

                int n1, n2, n3;
                n1 = Convert.ToInt32(textBox9.Text);
                n2 = Convert.ToInt32(textBox12.Text);
                n3 = n1 * n2;
                textBox17.Text = n3.ToString();
            }
            catch { }
        }


        void TotalAmount() {
            try
            {
                int n1, n2, n3, n4, totalamount;
                n1 = Convert.ToInt32(textBox15.Text);
                n2 = Convert.ToInt32(textBox16.Text);
                n3 = Convert.ToInt32(textBox17.Text);
                n4 = Convert.ToInt32(textBox19.Text);
                totalamount = n1 + n2 + n3 + n4;
                textBox20.Text = totalamount.ToString();
            }
            catch { }
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox10.MaxLength = 1;
            if (textBox10.Text == "")
            {
                textBox19.Text = "0";
            }
            try
            {

                int n1, n2, n3;
                n1 = Convert.ToInt32(textBox10.Text);
                n2 = Convert.ToInt32(textBox11.Text);
                n3 = n1 * n2;
                textBox19.Text = n3.ToString();
            }
            catch { }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        private void comboBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void comboBox8_TextChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text == "")
            {

            }
            else if (comboBox8.Text == "PRE KINDER 1")
            {
                textBox13.Text = "2500";
            }
            else
            {
                textBox13.Text = "3500";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Txtclear();
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            try
            {

                int n1, n2, n3;
                n1 = Convert.ToInt32(textBox1.Text);
                n2 = Convert.ToInt32(textBox20.Text);
                n3 = n1 + n2;
                label22.Text = n3.ToString();
            }
            catch { }
        }

        private void label24_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            textBox5.Text = "0";
            textBox2.Text = "0";
            try
            {
                int n1, n2, n3;
                n1 = Convert.ToInt32(textBox18.Text);
                n2 = Convert.ToInt32(textBox1.Text);
                n3 = n1 - n2;
                textBox5.Text = n3.ToString();

                if (n2 > n1)
                {
                    int c1, c2, c3;
                    textBox5.Text = "0";
                    c1 = Convert.ToInt32(textBox18.Text);
                    c2 = Convert.ToInt32(label1.Text);
                    c3 = c1 - c2;
                    textBox2.Text = c3.ToString();
                }
            }
            catch { }

            try
            {
                int n1, n2, n3;
                n1 = Convert.ToInt32(textBox1.Text);
                n2 = Convert.ToInt32(textBox20.Text);
                n3 = n1 + n2;
                label22.Text = n3.ToString();
            }
            catch { }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n1, n2, n3;
                n1 = Convert.ToInt32(label22.Text);
                n2 = Convert.ToInt32(textBox21.Text);
                n3 = n2 - n1;
                textBox2.Text = n3.ToString();
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            SearchPaymentsBy_Monthcode();
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            SearchPaymentsBy_IDnumber_fullname();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "ALL")
            {

                ReloadPayments();
            }
            else {
                SearchPaymentsBy_Kinderlevel();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) ||  e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
    }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Select_PaymentsHistory();
           
           
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (!(label56.Text == Form1.instance.lb4.Text))
            {
                MessageBox.Show("Sorry! You are not allowed to cancel past days payments.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult ask = new DialogResult();
                ask = MessageBox.Show("Are you sure that you want to cancel that payment?","Cancelling Payment",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (ask == DialogResult.Yes)
                {
                    CancelPayment();
                    ReloadPayments();
                    MessageBox.Show("A payment is now cancelled.", "Payment Cancellation.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label56.Text = "0";
                }
                else {
                } 
            }
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar==(char)Keys.Space || e.KeyChar=='-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
