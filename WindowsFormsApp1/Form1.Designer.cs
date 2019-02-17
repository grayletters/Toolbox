namespace WindowsFormsApp1
{
    partial class PassForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAddPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddUser = new System.Windows.Forms.TextBox();
            this.txtAddSite = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listPass = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDataPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.passListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rbCipherShift = new System.Windows.Forms.RadioButton();
            this.rbCipherKey = new System.Windows.Forms.RadioButton();
            this.grpCiphers = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeBindingSource)).BeginInit();
            this.grpCiphers.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtAddPass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAddUser);
            this.groupBox1.Controls.Add(this.txtAddSite);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add site";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Info;
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(93, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 26);
            this.label9.TabIndex = 22;
            this.label9.Text = "You can also \r\npress DELETE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 21);
            this.button1.TabIndex = 21;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Info;
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(3, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 26);
            this.label8.TabIndex = 20;
            this.label8.Text = "You can also \r\npress ENTER";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 133);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(57, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAddPass
            // 
            this.txtAddPass.Location = new System.Drawing.Point(6, 99);
            this.txtAddPass.Name = "txtAddPass";
            this.txtAddPass.Size = new System.Drawing.Size(135, 20);
            this.txtAddPass.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Site";
            // 
            // txtAddUser
            // 
            this.txtAddUser.Location = new System.Drawing.Point(6, 58);
            this.txtAddUser.Name = "txtAddUser";
            this.txtAddUser.Size = new System.Drawing.Size(135, 20);
            this.txtAddUser.TabIndex = 1;
            // 
            // txtAddSite
            // 
            this.txtAddSite.Location = new System.Drawing.Point(6, 19);
            this.txtAddSite.Name = "txtAddSite";
            this.txtAddSite.Size = new System.Drawing.Size(135, 20);
            this.txtAddSite.TabIndex = 0;
            // 
            // listPass
            // 
            this.listPass.DataSource = this.listPass.CustomTabOffsets;
            this.listPass.FormattingEnabled = true;
            this.listPass.Location = new System.Drawing.Point(12, 24);
            this.listPass.Name = "listPass";
            this.listPass.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listPass.Size = new System.Drawing.Size(201, 95);
            this.listPass.TabIndex = 1;
            this.listPass.SelectedIndexChanged += new System.EventHandler(this.listPass_SelectedIndexChanged);
            this.listPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listPass_KeyUp);
            this.listPass.MouseEnter += new System.EventHandler(this.listPass_MouseEnter);
            this.listPass.MouseLeave += new System.EventHandler(this.listPass_MouseLeave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.txtDataPass);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDataUser);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.listPass);
            this.groupBox2.Location = new System.Drawing.Point(294, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 194);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Search For Site";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtDataPass
            // 
            this.txtDataPass.Location = new System.Drawing.Point(304, 99);
            this.txtDataPass.Name = "txtDataPass";
            this.txtDataPass.Size = new System.Drawing.Size(135, 20);
            this.txtDataPass.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password";
            // 
            // txtDataUser
            // 
            this.txtDataUser.Location = new System.Drawing.Point(304, 58);
            this.txtDataUser.Name = "txtDataUser";
            this.txtDataUser.Size = new System.Drawing.Size(135, 20);
            this.txtDataUser.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Username";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(104, 222);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(176, 20);
            this.txtKey.TabIndex = 7;
            // 
            // nodeBindingSource
            // 
            this.nodeBindingSource.DataSource = typeof(WindowsFormsApp1.Node);
            // 
            // rbCipherShift
            // 
            this.rbCipherShift.AutoSize = true;
            this.rbCipherShift.Checked = true;
            this.rbCipherShift.Location = new System.Drawing.Point(16, 24);
            this.rbCipherShift.Name = "rbCipherShift";
            this.rbCipherShift.Size = new System.Drawing.Size(78, 17);
            this.rbCipherShift.TabIndex = 15;
            this.rbCipherShift.TabStop = true;
            this.rbCipherShift.Text = "Shift cipher";
            this.rbCipherShift.UseVisualStyleBackColor = true;
            // 
            // rbCipherKey
            // 
            this.rbCipherKey.AutoSize = true;
            this.rbCipherKey.Enabled = false;
            this.rbCipherKey.Location = new System.Drawing.Point(16, 47);
            this.rbCipherKey.Name = "rbCipherKey";
            this.rbCipherKey.Size = new System.Drawing.Size(76, 17);
            this.rbCipherKey.TabIndex = 16;
            this.rbCipherKey.Text = "Key Sipher";
            this.rbCipherKey.UseVisualStyleBackColor = true;
            // 
            // grpCiphers
            // 
            this.grpCiphers.Controls.Add(this.rbCipherKey);
            this.grpCiphers.Controls.Add(this.rbCipherShift);
            this.grpCiphers.Location = new System.Drawing.Point(294, 218);
            this.grpCiphers.Name = "grpCiphers";
            this.grpCiphers.Size = new System.Drawing.Size(141, 77);
            this.grpCiphers.TabIndex = 17;
            this.grpCiphers.TabStop = false;
            this.grpCiphers.Text = "Ciphers";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Cipher Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Info;
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(21, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 39);
            this.label7.TabIndex = 19;
            this.label7.Text = "Choose a unique number (1-100) and remember it. \r\nEnter your number BEFORE adding" +
    " the site data\r\nand BEFORE viewing passwords.";
            // 
            // PassForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 304);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grpCiphers);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PassForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeBindingSource)).EndInit();
            this.grpCiphers.ResumeLayout(false);
            this.grpCiphers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAddPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddUser;
        private System.Windows.Forms.TextBox txtAddSite;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox listPass;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDataPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.BindingSource passListBindingSource;
        private System.Windows.Forms.BindingSource nodeBindingSource;
        private System.Windows.Forms.RadioButton rbCipherShift;
        private System.Windows.Forms.RadioButton rbCipherKey;
        private System.Windows.Forms.GroupBox grpCiphers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
    }
}

