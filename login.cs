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
    public partial class login : Form
    {

        

       
        MySqlConnection con = new MySqlConnection("server=localhost;username=root;database=mysql;");
        MySqlCommand com;
        MySqlDataReader dr;

        public void Opencon() {
            con.Close();
            con.Open();
           // com.Connection = con;
        }

        public void ClosedReader() {
            dr = com.ExecuteReader();dr.Close();
        }

        public void Create_DB() {
            com = new MySqlCommand("create database if not exists dbstudent_MS;", con); ClosedReader();
        }

        public void Create_table_student() {
            com = new MySqlCommand("create table if not exists dbstudent_MS.student(id int(100) auto_increment primary key, monthcode text, date text, idnumber text, fullname text, fulladdress text, sex text, contactnumber text, cfe_fullname text, cfe_fulladdress text, cfe_contactnumber text, cfe_relationship text, kinderlevel text, section text, registrationfee text,  miscfee text, tuitionfee text, bookfee text, PEqty text, PEfee text, uniformqty text, uniformfee text, otherfee text, totalbalance text, status text)",con);ClosedReader();
        }

        void Resetall() {
            com = new MySqlCommand("drop table if exists dbstudent_MS.student;", con); ClosedReader();
            com = new MySqlCommand("drop table if exists dbstudent_MS.students;", con); ClosedReader();
            com = new MySqlCommand("drop table if exists dbstudent_MS.paymentsetting;", con); ClosedReader();
            com = new MySqlCommand("drop table if exists dbstudent_MS.paymentsettings;", con); ClosedReader();
            com = new MySqlCommand("drop table if exists dbstudent_MS.paymentshistory;", con); ClosedReader();
            
        }

        void Alter_Tables() {

            try { com = new MySqlCommand("alter table dbstudent_MS.student add column PEqty text after bookfee;", con); ClosedReader(); } catch { }

            try { com = new MySqlCommand("alter table dbstudent_MS.student add column uniformqty text after PEfee;", con); ClosedReader(); } catch { }

            try { com = new MySqlCommand("alter table dbstudent_MS.students add column status text;", con); ClosedReader(); } catch { }

            try { com = new MySqlCommand("alter table dbstudent_MS.paymentsettings add column sex text after yearlevel;", con); ClosedReader(); } catch { }

        }

        void Create_tb_payment_settings() {
            com = new MySqlCommand("create table if not exists dbstudent_MS.paymentsettings (id int(100) auto_increment primary key, date text, yearlevel text, units text, costperunit text, tuition text, miscfee text, labfee text, airconfree text, fieldtripfee text, libraryfee text, Otherfees text, totalbalance text)",con); ClosedReader();
        }

        void Create_tb_payment_setting()
        {
            com = new MySqlCommand("create table if not exists dbstudent_MS.paymentsetting (id int(100) auto_increment primary key, date text, kinderlevel text, sex text, registationfee text, miscfee text, tuitionfee text, bookfee text, PEfee text, uniformfee text, otherfees text, totalbalance text)", con); ClosedReader();
        }

        void Create_tb_payments_history() {
            com = new MySqlCommand("create table if not exists dbstudent_MS.paymentshistory(id int(100) auto_increment primary key, monthcode text, date text, idnumber text, fullname text, kinderlevel text, section text, parent text, balance text, currentbalance text, payment text, logoqty text, logocost text, logoamount text, bookqty text, bookcost text, bookamount text, PEqty text, PEcost text, PEamount text, uniformqty text, uniformcost text, uniformamount text, additionalamount text, AmountToPay text, cash text, change1 text, processedby text);",con);
            ClosedReader();

        }

        void Create_tb_useraccounts()
        {
            com = new MySqlCommand("create table if not exists dbstudent_MS.useraccounts(id int(100) auto_increment primary key, date text, fullname text, fulladdress text, contactnumber text, sex text, status text, role text, username text, password text);", con); ClosedReader();

        }

        void UserAccountsParams() {
          //  com.Parameters.Add("@id", );
            com.Parameters.AddWithValue("@date", label4.Text);
            com.Parameters.AddWithValue("@fullname", textBox4.Text);
            com.Parameters.AddWithValue("@fulladdress", textBox3.Text);
            com.Parameters.AddWithValue("@contactnumber", textBox5.Text);
            com.Parameters.AddWithValue("@sex", comboBox1.Text);
            com.Parameters.AddWithValue("@role", comboBox2.Text);
            com.Parameters.AddWithValue("@status1", "APPROVED");
            com.Parameters.AddWithValue("@status2", "PENDING");
            com.Parameters.AddWithValue("@username", textBox6.Text);
            com.Parameters.AddWithValue("@password", textBox7.Text);

        }

        void DefaultAccount() {
            try {
                com = new MySqlCommand("insert into dbstudent_MS.useraccounts(id, date, fullname, fulladdress, contactnumber, sex, role, status, username, password)values('1','1/20/2024','System Administrator','Alaminos City, Pangasinan, PH, 2404','09012345678','MALE','ADMIN','APPROVED','admin123','admin');", con); ClosedReader();
            } catch { }
          

        }

        void NewAccount()
        {
                com = new MySqlCommand("insert into dbstudent_MS.useraccounts(date, fullname, fulladdress, contactnumber, sex, role, status, username, password)values(@date, @fullname, @fulladdress, @contactnumber, @sex, @role, @status2, @username, @password);", con); UserAccountsParams(); ClosedReader();
        }




        public static login instance;
        public Label lb20;
        public Label lb8;
        public Label lb11;

        public login()
        {
            InitializeComponent();
            instance = this;
            lb20 = label20;
            lb8 = label8;
            lb11 = label11;
        }

        private void login_Load(object sender, EventArgs e)
        {
            Opencon();
            Create_DB();
            Create_table_student();
            Create_tb_payment_setting();
            Create_tb_payments_history();
            Create_tb_useraccounts();
            timer1.Start();
            textBox2.UseSystemPasswordChar = true;
            textBox7.UseSystemPasswordChar = true;
            textBox8.UseSystemPasswordChar = true;

            comboBox1.FlatStyle = FlatStyle.Popup;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("MALE");
            comboBox1.Items.Add("FEMALE");
            comboBox1.Text = "MALE";

            comboBox2.FlatStyle = FlatStyle.Popup;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.Items.Add("CASHIER");
            comboBox2.Items.Add("ADMIN");
            comboBox2.Text = "CASHIER";
            Alter_Tables();
            DefaultAccount();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("MM/dd/yyyy");
            label5 .Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
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

     

        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "" || textBox2.Text == "") {
                MessageBox.Show("Please input username and password.", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if(!(label10.Text =="APPROVED")){
                MessageBox.Show("Your account is not allowed. Please ask ADMIN to approved your account first.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text == label8.Text && textBox2.Text == label9.Text) {

                MessageBox.Show("You are now logged on. Click OK to continue.", "Logged On", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                Form1 nfrm = new Form1();
                nfrm.Show();
                this.Hide();
            } else {
                MessageBox.Show("Please input correct username and password.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
            }


            
            
        }

        void Finduser() {
            com = new MySqlCommand("select * from dbstudent_MS.useraccounts where username=@username;", con);
            com.Parameters.AddWithValue("@username", textBox1.Text);
            dr = com.ExecuteReader();
            while (dr.Read()) {
                label8.Text = dr.GetString(8).ToString();
                label9.Text = dr.GetString(9).ToString();
                label11.Text = dr.GetString(7).ToString();
                label10.Text = dr.GetString(6).ToString();
                label20.Text = dr.GetString(2).ToString();
            } dr.Close();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Finduser();
            if (textBox1.Text == "reset123") {
                Resetall();
                MessageBox.Show("Reset Done.", "Successfully Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Create_table_student();
                Create_tb_payment_setting();
                Create_tb_payments_history();
                textBox1.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        void Textclear() {
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "MALE";
            comboBox2.Text = "CASHIER";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Please input all required information.", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (textBox5.TextLength < 11) {
                MessageBox.Show("Need atleast 11 digits contact numbers.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!(textBox8.Text==textBox7.Text)) {
                MessageBox.Show("Password confirmation mismatch.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                NewAccount();
                MessageBox.Show("You are now signed up. Please wait the ADMIN to approved you account.", "Signed Up Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Textclear();
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
            else {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar=='@' || e.KeyChar == '_' || e.KeyChar == '.' || e.KeyChar == '-')
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

        private void textBox4_TextChanged(object sender, EventArgs e)
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

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
