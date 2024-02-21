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
    public partial class Students : Form
    {

        MySqlConnection con = new MySqlConnection("server=localhost;username=root;database=mysql;");
        MySqlCommand com;
        MySqlDataReader dr;


        public void ClosedReader() {
            dr = com.ExecuteReader();
            dr.Close();
        }

        void StudentsParams(){
            com.Parameters.AddWithValue("@id", label41.Text);
            com.Parameters.AddWithValue("@monthcode", label40.Text);
            com.Parameters.AddWithValue("@date", Form1.instance.lb4.Text);
            com.Parameters.AddWithValue("@idnumber", textBox4.Text);
            com.Parameters.AddWithValue("@fullname", textBox3.Text);
            com.Parameters.AddWithValue("@fulladdress", textBox5.Text);
            com.Parameters.AddWithValue("@sex", comboBox1 .Text);
            com.Parameters.AddWithValue("@contactnumber", textBox1.Text);
            com.Parameters.AddWithValue("@cfe_fullname", textBox7.Text);
            com.Parameters.AddWithValue("@cfe_fulladdress", textBox6.Text);
            com.Parameters.AddWithValue("@cfe_contactnumber", textBox2.Text);
            com.Parameters.AddWithValue("@cfe_relationship", textBox15.Text);
            com.Parameters.AddWithValue("@kinderlevel", comboBox8.Text);
            com.Parameters.AddWithValue("@section", comboBox3.Text);
            com.Parameters.AddWithValue("@registrationfee", textBox10.Text);
            com.Parameters.AddWithValue("@miscfee", textBox11.Text);
            com.Parameters.AddWithValue("@tuitionfee", textBox12.Text);
            com.Parameters.AddWithValue("@bookfee", textBox13.Text);
            com.Parameters.AddWithValue("@PEqty", textBox24.Text);
            com.Parameters.AddWithValue("@PEfee", textBox23.Text);
            com.Parameters.AddWithValue("@uniformqty", textBox21.Text);
            com.Parameters.AddWithValue("@uniformfee", textBox22.Text);
            com.Parameters.AddWithValue("@otherfee", textBox17.Text);
            com.Parameters.AddWithValue("@totalbalance", textBox18.Text);
            com.Parameters.AddWithValue("@status1", "Active");
            com.Parameters.AddWithValue("@status2", "Inactive");
        }


        void AddNewStudents() {
            com = new MySqlCommand("insert into dbstudent_MS.student(monthcode, date, idnumber, fullname, fulladdress, sex, contactnumber, cfe_fullname, cfe_fulladdress, cfe_contactnumber, cfe_relationship, kinderlevel, section, registrationfee,  miscfee, tuitionfee, bookfee, PEqty, PEfee, uniformqty, uniformfee, otherfee, totalbalance, status)values(@monthcode, @date, @idnumber, @fullname, @fulladdress, @sex, @contactnumber, @cfe_fullname, @cfe_fulladdress, @cfe_contactnumber, @cfe_relationship, @kinderlevel, @section, @registrationfee,  @miscfee, @tuitionfee, @bookfee, @PEqty, @PEfee, @uniformqty, @uniformfee, @otherfee, @totalbalance, @status1)", con); StudentsParams(); ClosedReader();
        }


        void UpdateStudents()
        {
            com = new MySqlCommand("update dbstudent_MS.student set id=@id, fullname=@fullname, fulladdress=@fulladdress, sex=@sex, contactnumber=@contactnumber, cfe_fullname=@cfe_fullname, cfe_fulladdress=@cfe_fulladdress, cfe_contactnumber=@cfe_contactnumber, cfe_relationship=@cfe_relationship, kinderlevel=@kinderlevel, section=@section, registrationfee=@registrationfee, miscfee=@miscfee, tuitionfee=@tuitionfee, bookfee=@bookfee, PEqty=@PEqty, PEfee=@PEfee, uniformqty=@uniformqty, uniformfee=@uniformfee, otherfee=@otherfee where id=@id;", con); StudentsParams(); ClosedReader();
        }



        void ShortcutDisplay() {
            ListViewItem lvi = new ListViewItem(dr.GetInt32(0).ToString());
            int lvi_c;
            for (lvi_c = 1; lvi_c <= 23; lvi_c += 1)
            {
                lvi.SubItems.Add(dr.GetString(lvi_c).ToString()).BackColor = Color.White;
            }
            listView1.Items.Add(lvi);
            lvi.UseItemStyleForSubItems = false;
        }

        void LongcutDisplay()
        {
            ListViewItem lvi = new ListViewItem(dr.GetInt32(0).ToString());
            lvi.SubItems.Add(dr.GetString(1).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(2).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(3).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(4).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(5).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(6).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(7).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(8).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(9).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(10).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(11).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(12).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(13).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(14).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(15).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(16).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(17).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(18).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(19).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(20).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(21).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(22).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(23).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(24).ToString()).BackColor = Color.White;
            lvi.SubItems.Add(dr.GetString(25).ToString()).BackColor = Color.White;
            listView1.Items.Add(lvi);
            lvi.UseItemStyleForSubItems = false;
        }
        void ReloadStudents() {
            listView1.Items.Clear();
            com = new MySqlCommand("select * from dbstudent_MS.student order by id asc;", con);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                //LongcutDisplay();
                ShortcutDisplay();
            }
            dr.Close();
            Autocounts();
        }

        void SelectStudent() {
            com = new MySqlCommand("select * from dbstudent_MS.student where id=@id;", con);
            com.Parameters.AddWithValue("@id", listView1.FocusedItem.Text);
            dr = com.ExecuteReader();
                while (dr.Read()) {
                textBox4.Text = dr.GetString(3).ToString();
                textBox3.Text = dr.GetString(4).ToString();
                textBox5.Text = dr.GetString(5).ToString();
                comboBox1 .Text = dr.GetString(6).ToString();
                textBox1.Text = dr.GetString(7).ToString();
                textBox7.Text = dr.GetString(8).ToString();
                textBox6.Text = dr.GetString(9).ToString();
                textBox2.Text = dr.GetString(10).ToString();
                textBox15.Text = dr.GetString(11).ToString();
                //comboBox8.Text = dr.GetString(12).ToString();
                comboBox3.Text = dr.GetString(13).ToString();
                textBox10.Text = dr.GetString(14).ToString();
                textBox11.Text = dr.GetString(15).ToString();
                textBox12.Text = dr.GetString(16).ToString();
                textBox13.Text = dr.GetString(17).ToString();
                textBox24.Text = dr.GetString(18).ToString();
                textBox23.Text = dr.GetString(19).ToString();
                textBox21.Text = dr.GetString(20).ToString();
                textBox22.Text = dr.GetString(21).ToString();
               textBox17.Text = dr.GetString(22).ToString();
                textBox18.Text = dr.GetString(23).ToString();
                label41.Text = dr.GetInt32(0).ToString();

            }
            dr.Close();
            textBox4.Enabled = false;
        }

        public void Autocounts()
        {
            com = new MySqlCommand("select count(id) from dbstudent_MS.student;", con);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                label30.Text = dr.GetInt32(0).ToString();
            }
            dr.Close();

            com = new MySqlCommand("select count(kinderlevel) from dbstudent_MS.student where kinderlevel='PRE KINDER 1';", con);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                label31.Text = dr.GetInt32(0).ToString();
            }
            dr.Close();


            com = new MySqlCommand("select count(kinderlevel) from dbstudent_MS.student where kinderlevel='PRE KINDER 2';", con);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                label34.Text = dr.GetInt32(0).ToString();
            }
            dr.Close();

            com = new MySqlCommand("select count(kinderlevel) from dbstudent_MS.student where kinderlevel='KINDER';", con);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                label38.Text = dr.GetInt32(0).ToString();
            }
            dr.Close();

        }

        void FindExistedID() {
            if ((label41.Text == "0"))
            {
                com = new MySqlCommand("select * from dbstudent_MS.student where idnumber=@idnumber;", con);
                com.Parameters.AddWithValue("@idnumber", textBox4.Text);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    label50.Text = dr.GetString(3).ToString();
                }
                dr.Close();
            }
            else { }
            }

        public Students()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Students_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            WindowState = FormWindowState.Maximized;
            textBox10.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox16.ReadOnly = true;
            textBox17.ReadOnly = true;
            textBox18.ReadOnly = true;
            textBox18.ReadOnly = true;
            textBox8.Text = "0";
            textBox9.Text = "0";
            Lvs();
            con.Close();
            con.Open();
            ReloadStudents();

            if (Form1.instance.lb8.Text == "Role: CASHIER")
            {
                listView1.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;

            }
            else {
                listView1.Enabled = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
            }            
            //textBox4.ReadOnly = true;
          // textBox4.Text = DateTime.Now.ToString("yyyy-ddhhmmss");

        }

        public void Lvs() {
            listView1.BackColor = Color.MediumBlue;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Columns.Clear();
            listView1.Columns.Add("#",0);
            listView1.Columns.Add("MonthCode", 100);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("ID Number", 120);
            listView1.Columns.Add("Fullname", 200);
            listView1.Columns.Add("Full Address", 200);
            listView1.Columns.Add("Sex/Gender", 120);
            listView1.Columns.Add("Contact No.", 120);
            listView1.Columns.Add("CFE-Fullname", 200);
            listView1.Columns.Add("CFE-Full Address", 200);
            listView1.Columns.Add("CFE-Contact No.", 150);
            listView1.Columns.Add("CFE-Relationship", 150);
           // listView1.Columns.Add("Sem/Grading", 0);
            listView1.Columns.Add("Kinder Level", 120);
            listView1.Columns.Add("Section", 120);
            //listView1.Columns.Add("Course", 0);
            //listView1.Columns.Add("Units", 0);
         //   listView1.Columns.Add("Cost/Unit", 0);
            listView1.Columns.Add("Registration Fee", 120);
            listView1.Columns.Add("Misc. Fee", 120);
            listView1.Columns.Add("Tuition Fee", 120);
            listView1.Columns.Add("Book Fee", 120);
            listView1.Columns.Add("PE QTY", 100);
            listView1.Columns.Add("PE Uniform", 150);
            listView1.Columns.Add("Uniform QTY", 100);
            listView1.Columns.Add("Schoo Uniform", 120);
            listView1.Columns.Add("Other Fees", 120);
            listView1.Columns.Add("Total Balance", 150);
            listView1.Columns.Add(" ", 40);

            comboBox1.FlatStyle = FlatStyle.Popup;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("MALE");
            comboBox1.Items.Add("FEMALE");
            comboBox1.Text = "MALE";

     
            comboBox2.FlatStyle = FlatStyle.Popup;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.Items.Add("ALL");
            comboBox2.Items.Add("First Grading");
            comboBox2.Items.Add("Second Grading");
            comboBox2.Items.Add("Third Grading");
            comboBox2.Items.Add("Fourth Grading");
            comboBox2.Text = "ALL";

            comboBox8.FlatStyle = FlatStyle.Popup;
            comboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox8.Items.Clear();
            comboBox8.Items.Add("[ SELECT ]");
            comboBox8.Items.Add("PRE KINDER 1");
            comboBox8.Items.Add("PRE KINDER 2");
            comboBox8.Items.Add("KINDER");
            comboBox8.Text = "[ SELECT ]";
         

            comboBox7.FlatStyle = FlatStyle.Popup;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.Items.Clear();
            comboBox7.Items.Add("ALL");
            comboBox7.Items.Add("PRE KINDER 1");
            comboBox7.Items.Add("PRE KINDER 2");
            comboBox7.Items.Add("KINDER");
            comboBox7.Text = "ALL";

            comboBox3.FlatStyle = FlatStyle.Popup;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.Items.Clear();
            comboBox3.Items.Add("[ SELECT ]");
            comboBox3.Items.Add("1");
            comboBox3.Items.Add("2");
            comboBox3.Items.Add("3");
            comboBox3.Items.Add("4");
            comboBox3.Text = "[ SELECT ]";

            comboBox4.FlatStyle = FlatStyle.Popup;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.Items.Clear();
            comboBox4.Items.Add("NO");
            comboBox4.Items.Add("YES");
            comboBox4.Text = "NO";

            label40.Text = DateTime.Now.ToString("MMMyyyy");

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        void Calculatebalance() {
            try
            {
                int n1, n2, n3, n4, n5, n6, n7, balance;
                n1 = Convert.ToInt32(textBox11.Text);
                n2 = Convert.ToInt32(textBox12.Text);
                n3 = Convert.ToInt32(textBox13.Text);
                n4 = Convert.ToInt32(textBox22.Text);
                n5 = Convert.ToInt32(textBox23.Text);
                n6 = Convert.ToInt32(textBox17.Text);
                n7 = Convert.ToInt32(textBox10.Text);
                balance = n1 + n2 + n3 + n4 + n5 + n6 + n7;
                textBox18.Text = balance.ToString();
            }
            catch { }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Calculatebalance();
            if (textBox4.Text=="" || comboBox8.Text == "[ SELECT ]" || comboBox3.Text == "[ SELECT ]" || textBox3.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox2.Text == "" || textBox15.Text == ""  || textBox11.Text == "" || textBox10.Text == "" || textBox24.Text == "" || textBox23.Text == "" || textBox21.Text == "" || textBox12.Text == "" || textBox22.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox16.Text == "" || textBox17.Text == "") {
                MessageBox.Show("Please input all required details.","Missing Details",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (textBox2.TextLength < 11)
            {
                MessageBox.Show("Need atleast 11 digits contact numbers.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(textBox4.TextLength >= 4))
            {
                MessageBox.Show("Need atleast 5 characters ID Number.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Clear();
            }
            else if (textBox4.Text == label50.Text)
            {
                MessageBox.Show("ID Number is already taken.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Clear();
            }
            else {
              
                if (label41.Text == "0")
                {
                    AddNewStudents();
                    MessageBox.Show("New student details are now saved.", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else {
                    UpdateStudents();
                    MessageBox.Show("Student details are now updated.", "Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ReloadStudents(); Txtclr();
            }
          //  textBox4.Text = DateTime.Now.ToString("yyyy-ddhhmmss");
        }

        void Txtclr()
        {
            label41.Text = "0";
            comboBox1.Text = "MALE";
            comboBox2.Text = "First Grading";
            comboBox8.Text = "[ SELECT ]";
            comboBox3.Text = "[ SELECT ]";
            comboBox4.Text = "NO";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox15.Clear();
            textBox4.Enabled = true;
            ReloadStudents();
        }

        void Txtclr2() {
            textBox10.Clear();
            textBox23.Clear();
            textBox16.Clear();
            textBox22.Clear();
            textBox24.Clear();
            textBox21.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox15.Clear();
            textBox18.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.MaxLength = 11;
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) {
                e.Handled = false;
                }
            else
            {
                e.Handled = true;
            }

            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.MaxLength = 11;
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
            if (char.IsDigit(e.KeyChar) || e.KeyChar =='-'|| e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox9.Text == "") {
                textBox10.Text = "";
            }else {
                try
                {
                    int n1, n2, n3;
                    n1 = Convert.ToInt32(textBox8.Text);
                    n2 = Convert.ToInt32(textBox9.Text);
                    n3 = n1 * n2;
                    textBox10.Text = n3.ToString();
                }
                catch { }

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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            SelectStudent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Txtclr();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox9.Text == "")
            {
                textBox10.Text = "";
            }
            else
            {
                try
                {
                    //int n1, n2, n3;
                  //  n1 = Convert.ToInt32(textBox8.Text);
                  ///  n2 = Convert.ToInt32(textBox9.Text);
                  //  n3 = n1 * n2;
                  //  textBox10.Text = n3.ToString();
                }
                catch { }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try { FindExistedID();  } catch { }
                
            
        }

        void SearchBy_MonthCode() {
            listView1.Items.Clear();
            //dbstudent_MS.students
            com = new MySqlCommand("select * from dbstudent_MS.student where monthcode like @monthcode order by id desc;", con);
            com.Parameters.AddWithValue("@monthcode", "%" + textBox19.Text + "%");
            dr = com.ExecuteReader();
            while (dr.Read()) { ShortcutDisplay(); }
            dr.Close();
        }

        void SearchBy_IDnumber_Fullname()
        {
            listView1.Items.Clear();
            //dbstudent_MS.students
            com = new MySqlCommand("select * from dbstudent_MS.student where idnumber like @search or fullname like @search order by id desc;", con);
            com.Parameters.AddWithValue("@search", "%" +textBox20.Text+"%");
            dr = com.ExecuteReader();
            while (dr.Read()) { ShortcutDisplay(); }
            dr.Close();
        }
        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text == "")
            {ReloadStudents();}
            else { SearchBy_MonthCode(); }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (textBox20.Text == "")
            { ReloadStudents(); }
            else { SearchBy_IDnumber_Fullname(); }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        void SearchBy_Year_Level()
        {
            listView1.Items.Clear();
            //dbstudent_MS.students
            com = new MySqlCommand("select * from dbstudent_MS.student where kinderlevel=@yearlevel order by id desc;", con);
            com.Parameters.AddWithValue("@yearlevel", comboBox7.Text);
            dr = com.ExecuteReader();
            while (dr.Read()) { ShortcutDisplay(); }
            dr.Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "ALL")
            { con.Close();  con.Open(); ReloadStudents(); }
            else { SearchBy_Year_Level(); }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar=='#' || e.KeyChar == '@' || e.KeyChar == ',' || e.KeyChar == '-' || e.KeyChar == '.')
            {
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == '#' || e.KeyChar == '@' || e.KeyChar == ',' || e.KeyChar == '-' || e.KeyChar == '.')
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
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == ',' || e.KeyChar == '-' || e.KeyChar == '.')
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
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == ',' || e.KeyChar == '-' || e.KeyChar == '.')
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
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == ',' || e.KeyChar == '-' || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }


        void Select_payment_details()
        {
            con.Close();
                con.Open();
            com = new MySqlCommand("select * from dbstudent_MS.paymentsetting where sex=@sex and kinderlevel=@kinderlevel;", con);
            com.Parameters.AddWithValue("@sex", comboBox1.Text);
            com.Parameters.AddWithValue("@kinderlevel", comboBox8.Text);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
               // label41.Text = dr.GetInt32(0).ToString();
                textBox10.Text = dr.GetString(4).ToString();
                textBox11.Text = dr.GetString(5).ToString();
                textBox12.Text = dr.GetString(6).ToString();
                textBox13.Text = dr.GetString(7).ToString();
                textBox16.Text = dr.GetString(8).ToString();
                textBox14.Text = dr.GetString(9).ToString();
                textBox17.Text = dr.GetString(10).ToString();
                textBox18.Text = dr.GetString(11).ToString();
            }
            dr.Close();
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e) { }

        private void comboBox8_TextChanged(object sender, EventArgs e)
        {
                if (comboBox8.Text == "[ SELECT ]")
                {
                    Txtclr2();
                }
                else
                {
                    Txtclr2();
                    Select_payment_details();
                }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox8_Click(object sender, EventArgs e)
        {
          
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.Text = "[ SELECT ]";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            textBox21.MaxLength = 1;
            try
            {
                int n1, n2, n3;
                n1 = Convert.ToInt32(textBox14.Text);
                n2 = Convert.ToInt32(textBox21.Text);
                n3 = n1 * n2;
                textBox22.Text = n3.ToString();
            }
            catch { }
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

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            textBox24.MaxLength = 1;
            try {
                int n1, n2, n3;
                n1 = Convert.ToInt32(textBox16.Text);
                n2 = Convert.ToInt32(textBox24.Text);
                n3 = n1 * n2;
                textBox23.Text = n3.ToString();
            } catch { }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label52_Click(object sender, EventArgs e)
        {

        }
    }
}
