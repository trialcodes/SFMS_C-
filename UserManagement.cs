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
    public partial class UserManagement : Form
    {

        MySqlConnection con = new MySqlConnection("server=localhost;username=root;database=mysql;");
        MySqlCommand com;
        MySqlDataReader dr;    
        public void Opencon()
        {
            con.Close();
            con.Open();
            // com.Connection = con;
        }

        public void ClosedReader()
        {
            dr = com.ExecuteReader(); dr.Close();
        }

        void ShortcutDisplay()
        {
            ListViewItem lvi = new ListViewItem(dr.GetInt32(0).ToString());
            int lvi_c;
            for (lvi_c = 1; lvi_c <= 8; lvi_c += 1)
            {
                if (dr.GetString(6).ToString() == "APPROVED")
                {
                    lvi.SubItems.Add(dr.GetString(lvi_c).ToString()).BackColor = Color.Green;
                }
                else {
                    lvi.SubItems.Add(dr.GetString(lvi_c).ToString()).BackColor = Color.Firebrick;
                }
                
            }
            listView1.Items.Add(lvi);
            lvi.UseItemStyleForSubItems = false;
        }


        void Reload_Users() {
            listView1.Items.Clear();
            listView1.ForeColor = Color.White;
            com = new MySqlCommand("select * from dbstudent_MS.useraccounts order by id desc;", con);
            dr = com.ExecuteReader();
            while (dr.Read()) { ShortcutDisplay(); } dr.Close(); AutoCounts();
        }

        void Search_usersByID()
        {
            listView1.Items.Clear();
            listView1.ForeColor = Color.White;
            com = new MySqlCommand("select * from dbstudent_MS.useraccounts where username like @user or fullname like @user order by id desc;", con);
            com.Parameters.AddWithValue("@user","%" + textBox20 .Text + "%" );
            dr = com.ExecuteReader();
            while (dr.Read()) { ShortcutDisplay(); }
            dr.Close(); AutoCounts();
        }

        void Search_usersByRole()
        {
            listView1.Items.Clear();
            listView1.ForeColor = Color.White;
            com = new MySqlCommand("select * from dbstudent_MS.useraccounts where role=@role order by id desc;", con);
            com.Parameters.AddWithValue("@role", comboBox2 .Text);
            dr = com.ExecuteReader();
            while (dr.Read()) { ShortcutDisplay(); }
            dr.Close(); AutoCounts();
        }

        void Search_usersByStatus()
        {
            listView1.Items.Clear();
            listView1.ForeColor = Color.White;
            com = new MySqlCommand("select * from dbstudent_MS.useraccounts where status=@status order by id desc;", con);
            com.Parameters.AddWithValue("@status", comboBox7.Text);
            dr = com.ExecuteReader();
            while (dr.Read()) { ShortcutDisplay(); }
            dr.Close(); AutoCounts();
        }


        void Select_To_Approve_Users()
        {
            //listView1.Items.Clear();
           // listView1.ForeColor = Color.White;
            com = new MySqlCommand("select * from dbstudent_MS.useraccounts where id=" + listView1.FocusedItem.Text + ";", con);
           // com.Parameters.AddWithValue("@id", listView1.FocusedItem.Text);
            dr = com.ExecuteReader();
            while (dr.Read()) {
                label10.Text = dr.GetInt32(0).ToString();
                label11.Text = dr.GetString(6).ToString();
                label12.Text = dr.GetString(8).ToString();
            }dr.Close();
        }

        void ApprovedUser() {
            com = new MySqlCommand("update dbstudent_MS.useraccounts set id=@id, status='APPROVED' where id=@id;",con);
            com.Parameters.AddWithValue("@id", label10.Text);
            ClosedReader();
        }

        void InactiveUser()
        {
            com = new MySqlCommand("update dbstudent_MS.useraccounts set id=@id, status='PENDING' where id=@id;", con);
            com.Parameters.AddWithValue("@id", label10.Text);
            ClosedReader();
        }

        void AutoCounts() {
            com = new MySqlCommand("select count(id) from dbstudent_MS.useraccounts", con);
            dr = com.ExecuteReader();
            while (dr.Read())
            { label30.Text = dr.GetInt32(0).ToString(); }dr.Close();

            com = new MySqlCommand("select count(role) from dbstudent_MS.useraccounts where role='ADMIN';", con);
            dr = com.ExecuteReader();
            while (dr.Read())
            { label2.Text = dr.GetInt32(0).ToString(); }
            dr.Close();

            com = new MySqlCommand("select count(role) from dbstudent_MS.useraccounts where role='CASHIER';", con);
            dr = com.ExecuteReader();
            while (dr.Read())
            { label4.Text = dr.GetInt32(0).ToString(); }
            dr.Close();

            com = new MySqlCommand("select count(status) from dbstudent_MS.useraccounts where status='APPROVED';", con);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                label8.Text = dr.GetInt32(0).ToString();
            }
            dr.Close();

            com = new MySqlCommand("select count(status) from dbstudent_MS.useraccounts where status='PENDING';", con);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                label6.Text = dr.GetInt32(0).ToString();
            }
            dr.Close();
        }

        

        

        void List_sets()
        {
            listView1.BackColor = Color.MediumBlue;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Columns.Clear();
            listView1.Columns.Add("#", 0);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("Fullname", 200);
            listView1.Columns.Add("Full Address", 250);
            listView1.Columns.Add("Contact No.", 120);
            listView1.Columns.Add("Sex", 70);
            listView1.Columns.Add("Status", 90);
            listView1.Columns.Add("Role/User Type", 130);
            listView1.Columns.Add("Username", 120);
           // listView1.Columns.Add("Fieldtrip Fee", 150);
           // listView1.Columns.Add(" ", 40);
        }
            public UserManagement()
        {
            InitializeComponent();
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            Search_usersByID();
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            WindowState = FormWindowState.Maximized;
            Opencon();
            List_sets();
            Reload_Users();

            comboBox2.FlatStyle = FlatStyle.Popup;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.Items.Add("ALL");
            comboBox2.Items.Add("CASHIER");
            comboBox2.Items.Add("ADMIN");
            comboBox2.Text = "MALE";
            comboBox2.Text = "ALL";

            comboBox7.FlatStyle = FlatStyle.Popup;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.Items.Clear();
            comboBox7.Items.Add("ALL");
            comboBox7.Items.Add("APPROVED");
            comboBox7.Items.Add("PENDING");
            comboBox7.Text = "ALL";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "ALL")
            {
                Reload_Users();
            }
            else {
                textBox20.Clear();
                comboBox7.Text ="ALL";
                Search_usersByRole();
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "ALL")
            {
                Reload_Users();

            }
            else
            {
                textBox20.Clear();
                comboBox2.Text = "ALL";
                Search_usersByStatus();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            Select_To_Approve_Users();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label12.Text == "admin123")
            {
                MessageBox.Show("Sorry! Default ADMIN/Accounts not allowed to deactivated.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (label11.Text == "PENDING")
            {
                MessageBox.Show("Sorry! That use is already inactive or pending.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          else if (label10.Text == "0")
            {
                MessageBox.Show("Please click approved user in the users list first.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
            else
            {
                InactiveUser();
                MessageBox.Show("An accounts is now deactivated..", "Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label10.Text = "0";
                Reload_Users();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label11.Text == "APPROVED")
            {
                MessageBox.Show("Sorry! That use is already active or approved.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (label10.Text == "0")
            {
                MessageBox.Show("Please click pending user in the users list first.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ApprovedUser();
                MessageBox.Show("An accounts is now approved.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label10.Text = "0";
                Reload_Users();


            }
        }
    }
}
