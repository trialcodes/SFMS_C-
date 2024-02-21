using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentMS
{
    public partial class Settings : Form
    {

        MySqlConnection con = new MySqlConnection("server=localhost;username=root;database=mysql;");
        MySqlCommand com;
        MySqlDataReader dr;

        void YearLevelPaymentsParams() {
            com.Parameters.AddWithValue("@date", Form1.instance.lb4.Text);
            com.Parameters.AddWithValue("@kinderlevel", comboBox8.Text);
            com.Parameters.AddWithValue("@sex", comboBox4.Text);
            com.Parameters.AddWithValue("@units", textBox12.Text);
            com.Parameters.AddWithValue("@costperunit", textBox11.Text);
            com.Parameters.AddWithValue("@registationfee", textBox10.Text);
            com.Parameters.AddWithValue("@miscfee", textBox13.Text);
            com.Parameters.AddWithValue("@tuitionfee", textBox14.Text);
            com.Parameters.AddWithValue("@bookfee", textBox15.Text);
            com.Parameters.AddWithValue("@PEfee", textBox16.Text);
            com.Parameters.AddWithValue("@uniformfee", textBox18.Text);
            com.Parameters.AddWithValue("@otherfees", textBox17.Text);
            com.Parameters.AddWithValue("@totalbalance", textBox19.Text);
            com.Parameters.AddWithValue("@id", label41.Text);

        }
        void AddYearLevelPayments()
        {
            com = new MySqlCommand("insert into dbstudent_MS.paymentsetting(date, kinderlevel, sex, registationfee, miscfee, tuitionfee ,bookfee, PEfee, uniformfee, otherfees, totalbalance)values(@date, @kinderlevel, @sex, @registationfee, @miscfee, @tuitionfee, @bookfee, @PEfee, @uniformfee, @otherfees, @totalbalance);", con);
            YearLevelPaymentsParams(); ClosedReader();

        }

        void UpdatedYearLevelPayments()
        {
            com = new MySqlCommand("update dbstudent_MS.paymentsetting set id=@id, kinderlevel=@kinderlevel, sex=@sex, registationfee=@registationfee, miscfee= @miscfee, tuitionfee=@tuitionfee, bookfee=@bookfee, PEfee=@PEfee, uniformfee=@uniformfee, otherfees=@otherfees, totalbalance=@totalbalance where id=@id;", con); YearLevelPaymentsParams(); ClosedReader();

        }

        void ShortcutDisplay() {
            ListViewItem paylist = new ListViewItem(dr.GetInt32 (0).ToString ());
            int paylistc;
            for (paylistc = 1; paylistc <= 11; paylistc += 1) { paylist.SubItems.Add(dr.GetString(paylistc).ToString()).BackColor=Color .White ; }
            paylist.UseItemStyleForSubItems = false;
            listView2.Items.Add(paylist);
        }



        void Reload_payments_details() {
            listView2.Items.Clear();
            com = new MySqlCommand("select * from dbstudent_MS.paymentsetting order by kinderlevel asc;", con);
            dr = com.ExecuteReader();
            while (dr.Read()) { ShortcutDisplay(); }dr.Close();

            com = new MySqlCommand("select count(id) from dbstudent_MS.paymentsetting;", con);
            dr = com.ExecuteReader();
            while (dr.Read()) { label40.Text = dr.GetInt32(0).ToString(); }dr.Close();
        }


        void SameYearLevelInvalid() {
            com = new MySqlCommand("select * from dbstudent_MS.paymentsetting where kinderlevel=@kinderlevel;", con);
            com.Parameters.AddWithValue("@kinderlevel", comboBox8.Text);
            dr = com.ExecuteReader();
            while (dr.Read()) { label50.Text = dr.GetString(2).ToString(); }dr.Close();
        }

        void Select_payment_details()
        {
            com = new MySqlCommand("select * from dbstudent_MS.paymentsetting where id=@id;", con);
            com.Parameters.AddWithValue("@id", listView2 .FocusedItem .Text);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                label41.Text = dr.GetInt32(0).ToString();
                comboBox8.Enabled = false;
                comboBox8.Text = dr.GetString(2).ToString();
                comboBox4.Text = dr.GetString(3).ToString();
            //    textBox12.Text = dr.GetString(4).ToString();
            //    textBox11.Text = dr.GetString(5).ToString();
                textBox10.Text = dr.GetString(4).ToString();
                textBox13.Text = dr.GetString(5).ToString();
                textBox14.Text = dr.GetString(6).ToString();
                textBox15.Text = dr.GetString(7).ToString();
                textBox16.Text = dr.GetString(8).ToString();
                textBox18.Text = dr.GetString(9).ToString();
                textBox17.Text = dr.GetString(10).ToString();
                textBox19.Text = dr.GetString(11).ToString();
                //label50.Text = dr.GetString(2).ToString();
            } dr.Close();
        }

        void Display_User() {
            com = new MySqlCommand("select * from dbstudent_MS.useraccounts where username=@username;", con);
            com.Parameters.AddWithValue("@username",login.instance .lb8.Text);
            dr = com.ExecuteReader();
            while (dr.Read()) {
                textBox4.Text = dr.GetString(2).ToString();
                textBox3.Text = dr.GetString(3).ToString();
                textBox5.Text = dr.GetString(4).ToString();
                comboBox1.Text = dr.GetString(5).ToString();
                comboBox2.Text = dr.GetString(7).ToString();
                textBox6.Text = dr.GetString(8).ToString();
                label27.Text = dr.GetString(9).ToString();
            }
            dr.Close();
        }


        void UpdateuserParams() {
            com.Parameters.AddWithValue("@username",label26.Text);
            com.Parameters.AddWithValue("@fullname", textBox4.Text);
            com.Parameters.AddWithValue("@fulladdress", textBox3.Text);
            com.Parameters.AddWithValue("@contactnumber", textBox5.Text);
            com.Parameters.AddWithValue("@sex", comboBox1.Text);
            com.Parameters.AddWithValue("@password", textBox2.Text);
        }
        void Updateuser() {
            com = new MySqlCommand("update dbstudent_MS.useraccounts set username=@username, fullname=@fullname, fulladdress=@fulladdress, contactnumber=@contactnumber, sex=@sex where username=@username;", con); UpdateuserParams(); ClosedReader();
        }

        void Updateuserpass()
        {
            com = new MySqlCommand("update dbstudent_MS.useraccounts set username=@username, password=@password where username=@username;", con); UpdateuserParams(); ClosedReader();
        }


        public void ClosedReader()
        {
            dr = com.ExecuteReader();
            dr.Close();
        }

        public Settings()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Settings_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            WindowState = FormWindowState.Maximized;
            con.Close();
            con.Open();
            comboBox2.Enabled = false;
            textBox6.Enabled = false;
            textBox19.Enabled = false;
            List_sets();
            comboBox2.DropDownStyle = ComboBoxStyle.Simple;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Text="0";
            textBox11.Text="0";
            textBox10.Clear();
            label26.Text = login.instance.lb8.Text;
            Reload_payments_details();
            Display_User();
            textBox7.UseSystemPasswordChar = true;
            textBox8.UseSystemPasswordChar = true;
            textBox9.UseSystemPasswordChar = true;
            textBox1.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;
            if (Form1.instance.lb8.Text == "Role: ADMIN")
            {
                groupBox3.Enabled = true;
                groupBox7.Enabled = true;
            }
            else {
                groupBox3.Enabled = false;
                groupBox7.Enabled = false;
            }
        }

        void List_sets() {
            listView2.BackColor = Color.MediumBlue;
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView2.Columns.Clear();
            listView2.Columns.Add("#", 0);
            listView2.Columns.Add("Date", 100);
            listView2.Columns.Add("Kinder Level", 150);
            listView2.Columns.Add("Sex/Gender", 100);
         //   listView2.Columns.Add("Units", 0);
         //   listView2.Columns.Add("Cost/Unit", 0);
            listView2.Columns.Add("Registration Fee", 130);
            listView2.Columns.Add("Misc. Fee", 120);
            listView2.Columns.Add("Tuition Fee", 120);
            listView2.Columns.Add("Book Fee", 120);
            listView2.Columns.Add("PE Uniform", 150);
            listView2.Columns.Add("Schoo Uniform", 120);
            listView2.Columns.Add("Other Fees", 120);
            listView2.Columns.Add("Total Balance", 150);
            listView2.Columns.Add(" ", 40);

            comboBox8.FlatStyle = FlatStyle.Popup;
            comboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox8.Items.Clear();
            comboBox8.Items.Add("[ SELECT ]");
            comboBox8.Items.Add("PRE KINDER 1");
            comboBox8.Items.Add("PRE KINDER 2");
            comboBox8.Items.Add("KINDER");
            comboBox8.Text = "[ SELECT ]";

            comboBox3.FlatStyle = FlatStyle.Popup;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.Items.Clear();
            comboBox3.Items.Add("ALL");
            comboBox3.Items.Add("[ SELECT ]");
            comboBox3.Items.Add("PRE KINDER 1");
            comboBox3.Items.Add("PRE KINDER 2");
            comboBox3.Items.Add("KINDER");
            comboBox3.Text = "ALL";

            comboBox1.FlatStyle = FlatStyle.Popup;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("MALE");
            comboBox1.Items.Add("FEMALE");
            comboBox1.Text = "MALE";

            comboBox4.FlatStyle = FlatStyle.Popup;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.Items.Clear();
            comboBox4.Items.Add("MALE");
            comboBox4.Items.Add("FEMALE");
            comboBox4.Text = "MALE";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Calculatebalance();
            if (textBox12.Text == "" || textBox11.Text == "" || textBox10.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "" || textBox18.Text == "" || textBox19.Text == "")
            {
                MessageBox.Show("Please input all required details.", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(label40 .Text=="6") {
                MessageBox.Show("Sorry! You are not allowed more than 6 kinder level.", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtClear();
            }
            else if (label41.Text == "0")
            {
              //  if (label50.Text == comboBox8.Text)
               // {
                  //  MessageBox.Show("Year Level already in the list.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  }
                AddYearLevelPayments();
                Reload_payments_details();
                MessageBox.Show("A Year Level Payment details are now added.", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtClear();
            }
            else
            {
                UpdatedYearLevelPayments();
                Reload_payments_details();
                MessageBox.Show("A Year Level Payment details are now Updated.", "Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtClear();
            }

        }

        void TxtClear() {
            comboBox8.Text = "[ SELECT ]";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox10.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            label41.Text = "0";
            label50.Text = "0";
            comboBox8.Enabled = true;
            Reload_payments_details();
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

        private void textBox11_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox13_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox14_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox15_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox16_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox18_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox17_KeyPress_1(object sender, KeyPressEventArgs e)
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

        void Calculatebalance()
        {
            try
            {
                int n1, n2, n3, n4, n5, n6, n7, balance;
                n1 = Convert.ToInt32(textBox10.Text);
                n2 = Convert.ToInt32(textBox13.Text);
                n3 = Convert.ToInt32(textBox14.Text);
                n4 = Convert.ToInt32(textBox15.Text);
                n5 = Convert.ToInt32(textBox16.Text);
                n6 = Convert.ToInt32(textBox18.Text);
                n7 = Convert.ToInt32(textBox17.Text);
                balance = n1 + n2 + n3 + n4 + n5 + n6 + n7;
                textBox19.Text = balance.ToString();
            }
            catch { }
        }


        void CalculateTuition() {

            if (textBox11.Text == "" || textBox12.Text == "")
            {
                textBox10.Text = "";
            }
            else
            {
                try
                {
                 // //  int n1, n2, n3;
                  //  n1 = Convert.ToInt32(textBox11.Text);
                 //   n2 = Convert.ToInt32(textBox12.Text);
                 //   n3 = n1 * n2;
                 //   textBox10.Text = n3.ToString();
                }catch { }

            }
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            textBox12.MaxLength = 2;
            CalculateTuition();
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            CalculateTuition();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (label41.Text == "0")
            {
                label50.Text = "0";
                SameYearLevelInvalid();
            }
            else
            { 

            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            TxtClear();
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
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            Select_payment_details();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.MaxLength = 11;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '@' || e.KeyChar == '_' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '@' || e.KeyChar == '_' || e.KeyChar == '.' || e.KeyChar == '-')
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
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '@' || e.KeyChar == '_' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ',' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == (char)Keys.Space)
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
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '@' || e.KeyChar == '_' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '@' || e.KeyChar == '_' || e.KeyChar == '.' || e.KeyChar == '-')
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
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '@' || e.KeyChar == '_' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox9.UseSystemPasswordChar = false;
            textBox1.UseSystemPasswordChar = false;
            textBox2.UseSystemPasswordChar = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.UseSystemPasswordChar = false;
            textBox8.UseSystemPasswordChar = false;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            textBox7.UseSystemPasswordChar = true;
            textBox8.UseSystemPasswordChar = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            textBox9.UseSystemPasswordChar = true;
            textBox1.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "" || textBox3.Text == "" || textBox6.Text == "" || textBox7.Text == "") {
                MessageBox.Show("Please input all required information, specially password and confirm password. Thank you!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox5.TextLength < 11) {
                MessageBox.Show("Need atleast 11 digits contact numbers.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!(textBox7.Text==textBox8.Text)) {
                MessageBox.Show("Password and confirmation mismatch.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(textBox7.Text == label27.Text))
            {
                MessageBox.Show("Please enter your current password. Thank you!", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                Updateuser();
                textBox4.Clear();
                textBox3.Clear();
                textBox5.Clear();
                comboBox1.Text="MALE";
                MessageBox.Show("Your user accounts details are now updated.", "Saved Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Display_User();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox1.Clear();
                textBox2.Clear();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please input all required information, specially password and confirm password. Thank you!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!(label27.Text == textBox9.Text))
            {
                MessageBox.Show("Please enter your current password. Thank you!", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(textBox1.Text == textBox2.Text))
            {
                MessageBox.Show("Password and confirmation mismatch.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Updateuserpass();
                MessageBox.Show("Your password is now updated", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox1.Clear();
                textBox2.Clear();
                Display_User();
            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_TextChanged(object sender, EventArgs e)
        {

            if (comboBox8.Text == "[ SELECT ]")
            { textBox15.Clear(); }
            else {
                if (comboBox8.Text == "PRE KINDER 1")
                {
                    textBox15.Clear();
                    textBox15.Text = "2500";
                }
                else
                {
                    textBox15.Clear();
                    textBox15.Text = "3500";
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "FEMALE")
            {textBox18.Text = "1200"; }
            else { textBox18.Text = "0"; }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
