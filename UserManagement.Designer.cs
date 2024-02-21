namespace StudentMS
{
    partial class UserManagement
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.MediumBlue;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(-1, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(903, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(13, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 480);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Location = new System.Drawing.Point(7, 404);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(860, 70);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Counts";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Firebrick;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(708, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "0";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Firebrick;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(618, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 44;
            this.label7.Text = "PENDING:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Green;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(708, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Green;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(618, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 20);
            this.label9.TabIndex = 42;
            this.label9.Text = "APPROVED:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(403, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "CASHIER:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "ADMIN:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(69, 35);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 20);
            this.label30.TabIndex = 37;
            this.label30.Text = "0";
            this.label30.Click += new System.EventHandler(this.label30_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 35);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(57, 20);
            this.label29.TabIndex = 36;
            this.label29.Text = "USERS:";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.listView1);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(6, 114);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(861, 284);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Users List";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(6, 26);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(848, 252);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(480, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 20);
            this.label12.TabIndex = 36;
            this.label12.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(321, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 20);
            this.label11.TabIndex = 35;
            this.label11.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "0";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.comboBox7);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.textBox20);
            this.groupBox4.Location = new System.Drawing.Point(6, 26);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(861, 82);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search By";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Gold;
            this.button1.Location = new System.Drawing.Point(756, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 41);
            this.button1.TabIndex = 44;
            this.button1.Text = "Deactivate";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.MediumBlue;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumBlue;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.Gold;
            this.button7.Location = new System.Drawing.Point(652, 33);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(98, 41);
            this.button7.TabIndex = 43;
            this.button7.Text = "Approve";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(329, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 20);
            this.label16.TabIndex = 35;
            this.label16.Text = "Role/User Type";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(319, 40);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(178, 28);
            this.comboBox2.TabIndex = 36;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(513, 21);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(50, 20);
            this.label28.TabIndex = 33;
            this.label28.Text = "Status";
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(503, 40);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(136, 28);
            this.comboBox7.TabIndex = 34;
            this.comboBox7.SelectedIndexChanged += new System.EventHandler(this.comboBox7_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(16, 22);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(275, 20);
            this.label25.TabIndex = 31;
            this.label25.Text = "Username | Lastname / Firstname / M.I.";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(6, 41);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(307, 27);
            this.textBox20.TabIndex = 32;
            this.textBox20.TextChanged += new System.EventHandler(this.textBox20_TextChanged);
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 565);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UserManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
    }
}