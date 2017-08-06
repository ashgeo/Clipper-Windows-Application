namespace Clipper_CRM_Software
{
    partial class Admin_Control_Panel
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
            this.tab_adminControlPanel = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_firstName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lb_lastname = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lb_phone = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lb_email = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lb_role = new System.Windows.Forms.Label();
            this.btn_addemployee = new System.Windows.Forms.Button();
            this.tab_adminControlPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_adminControlPanel
            // 
            this.tab_adminControlPanel.Controls.Add(this.tabPage1);
            this.tab_adminControlPanel.Controls.Add(this.tabPage2);
            this.tab_adminControlPanel.Location = new System.Drawing.Point(12, 1);
            this.tab_adminControlPanel.Name = "tab_adminControlPanel";
            this.tab_adminControlPanel.SelectedIndex = 0;
            this.tab_adminControlPanel.Size = new System.Drawing.Size(844, 487);
            this.tab_adminControlPanel.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(836, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employee";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_addemployee);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.lb_role);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.lb_phone);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.lb_email);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.lb_lastname);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.lb_firstName);
            this.groupBox1.Location = new System.Drawing.Point(21, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Employee";
            // 
            // lb_firstName
            // 
            this.lb_firstName.AutoSize = true;
            this.lb_firstName.Location = new System.Drawing.Point(30, 49);
            this.lb_firstName.Name = "lb_firstName";
            this.lb_firstName.Size = new System.Drawing.Size(57, 13);
            this.lb_firstName.TabIndex = 0;
            this.lb_firstName.Text = "First Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(151, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(192, 20);
            this.textBox2.TabIndex = 3;
            // 
            // lb_lastname
            // 
            this.lb_lastname.AutoSize = true;
            this.lb_lastname.Location = new System.Drawing.Point(30, 75);
            this.lb_lastname.Name = "lb_lastname";
            this.lb_lastname.Size = new System.Drawing.Size(58, 13);
            this.lb_lastname.TabIndex = 2;
            this.lb_lastname.Text = "Last Name";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(151, 154);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(192, 20);
            this.textBox3.TabIndex = 7;
            // 
            // lb_phone
            // 
            this.lb_phone.AutoSize = true;
            this.lb_phone.Location = new System.Drawing.Point(30, 154);
            this.lb_phone.Name = "lb_phone";
            this.lb_phone.Size = new System.Drawing.Size(38, 13);
            this.lb_phone.TabIndex = 6;
            this.lb_phone.Text = "Phone";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(151, 128);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(192, 20);
            this.textBox4.TabIndex = 5;
            // 
            // lb_email
            // 
            this.lb_email.AutoSize = true;
            this.lb_email.Location = new System.Drawing.Point(30, 128);
            this.lb_email.Name = "lb_email";
            this.lb_email.Size = new System.Drawing.Size(32, 13);
            this.lb_email.TabIndex = 4;
            this.lb_email.Text = "Email";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(151, 101);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(192, 20);
            this.textBox5.TabIndex = 9;
            // 
            // lb_role
            // 
            this.lb_role.AutoSize = true;
            this.lb_role.Location = new System.Drawing.Point(30, 101);
            this.lb_role.Name = "lb_role";
            this.lb_role.Size = new System.Drawing.Size(29, 13);
            this.lb_role.TabIndex = 8;
            this.lb_role.Text = "Role";
            // 
            // btn_addemployee
            // 
            this.btn_addemployee.Location = new System.Drawing.Point(151, 199);
            this.btn_addemployee.Name = "btn_addemployee";
            this.btn_addemployee.Size = new System.Drawing.Size(133, 23);
            this.btn_addemployee.TabIndex = 10;
            this.btn_addemployee.Text = "Add Employee";
            this.btn_addemployee.UseVisualStyleBackColor = true;
            this.btn_addemployee.Click += new System.EventHandler(this.btn_addemployee_Click);
            // 
            // Admin_Control_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 525);
            this.Controls.Add(this.tab_adminControlPanel);
            this.Name = "Admin_Control_Panel";
            this.Text = "Phone";
            this.tab_adminControlPanel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_adminControlPanel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lb_role;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lb_phone;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lb_email;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lb_lastname;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lb_firstName;
        private System.Windows.Forms.Button btn_addemployee;
    }
}