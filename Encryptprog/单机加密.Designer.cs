namespace Encryptprog
{
    partial class encrypt
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.order = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Dekey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Key = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.ComboBox();
            this.vary = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Cyphertext = new System.Windows.Forms.TextBox();
            this.Plaintext = new System.Windows.Forms.TextBox();
            this.detext = new System.Windows.Forms.Button();
            this.entext = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.ComboBox();
            this.find = new System.Windows.Forms.ComboBox();
            this.defile = new System.Windows.Forms.Button();
            this.enfile = new System.Windows.Forms.Button();
            this.view2 = new System.Windows.Forms.Button();
            this.view1 = new System.Windows.Forms.Button();
            this.quit = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.order);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Dekey);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Key);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.vary);
            this.groupBox1.Location = new System.Drawing.Point(29, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "加密方法Cypher Method";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "序列Order";
            // 
            // order
            // 
            this.order.Enabled = false;
            this.order.Location = new System.Drawing.Point(297, 46);
            this.order.Name = "order";
            this.order.Size = new System.Drawing.Size(100, 21);
            this.order.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "解密密钥DeKey";
            // 
            // Dekey
            // 
            this.Dekey.Location = new System.Drawing.Point(297, 72);
            this.Dekey.Name = "Dekey";
            this.Dekey.Size = new System.Drawing.Size(100, 21);
            this.Dekey.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "密钥CypherKey";
            // 
            // Key
            // 
            this.Key.Location = new System.Drawing.Point(297, 20);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(100, 21);
            this.Key.TabIndex = 2;
            // 
            // name
            // 
            this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.name.Enabled = false;
            this.name.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.name.FormattingEnabled = true;
            this.name.Items.AddRange(new object[] {
            "Caesar cipher",
            "Keyword cipher",
            "Vigenere cipher",
            "AutoKey cipher",
            "Playfair cipher",
            "Permutation cipher",
            "Column cipher",
            "CA",
            "DES",
            "RSA"});
            this.name.Location = new System.Drawing.Point(34, 69);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(133, 20);
            this.name.TabIndex = 1;
            // 
            // vary
            // 
            this.vary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.vary.FormattingEnabled = true;
            this.vary.Items.AddRange(new object[] {
            "单表替代",
            "多表替代",
            "多图替代",
            "分块密码",
            "公钥密码",
            "流密码",
            "置换"});
            this.vary.Location = new System.Drawing.Point(34, 27);
            this.vary.Name = "vary";
            this.vary.Size = new System.Drawing.Size(133, 20);
            this.vary.TabIndex = 0;
            this.vary.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Cyphertext);
            this.groupBox2.Controls.Add(this.Plaintext);
            this.groupBox2.Controls.Add(this.detext);
            this.groupBox2.Controls.Add(this.entext);
            this.groupBox2.Location = new System.Drawing.Point(28, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文本操作To Text";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "密文CypherText";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "明文PlainText";
            // 
            // Cyphertext
            // 
            this.Cyphertext.Location = new System.Drawing.Point(248, 54);
            this.Cyphertext.Multiline = true;
            this.Cyphertext.Name = "Cyphertext";
            this.Cyphertext.Size = new System.Drawing.Size(140, 107);
            this.Cyphertext.TabIndex = 6;
            // 
            // Plaintext
            // 
            this.Plaintext.Location = new System.Drawing.Point(48, 54);
            this.Plaintext.Multiline = true;
            this.Plaintext.Name = "Plaintext";
            this.Plaintext.Size = new System.Drawing.Size(145, 107);
            this.Plaintext.TabIndex = 5;
            // 
            // detext
            // 
            this.detext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detext.Location = new System.Drawing.Point(286, 167);
            this.detext.Name = "detext";
            this.detext.Size = new System.Drawing.Size(58, 25);
            this.detext.TabIndex = 1;
            this.detext.Text = "解密";
            this.detext.UseVisualStyleBackColor = true;
            this.detext.Click += new System.EventHandler(this.detext_Click);
            // 
            // entext
            // 
            this.entext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.entext.Location = new System.Drawing.Point(90, 167);
            this.entext.Name = "entext";
            this.entext.Size = new System.Drawing.Size(58, 26);
            this.entext.TabIndex = 0;
            this.entext.Text = "加密";
            this.entext.UseVisualStyleBackColor = true;
            this.entext.Click += new System.EventHandler(this.entext_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.save);
            this.groupBox3.Controls.Add(this.find);
            this.groupBox3.Controls.Add(this.defile);
            this.groupBox3.Controls.Add(this.enfile);
            this.groupBox3.Controls.Add(this.view2);
            this.groupBox3.Controls.Add(this.view1);
            this.groupBox3.Location = new System.Drawing.Point(28, 337);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(418, 117);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文件操作To File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "保存到";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "源文件";
            // 
            // save
            // 
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save.FormattingEnabled = true;
            this.save.Location = new System.Drawing.Point(73, 50);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(258, 20);
            this.save.TabIndex = 8;
            // 
            // find
            // 
            this.find.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.find.FormattingEnabled = true;
            this.find.Location = new System.Drawing.Point(73, 18);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(259, 20);
            this.find.TabIndex = 7;
            // 
            // defile
            // 
            this.defile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defile.Location = new System.Drawing.Point(205, 85);
            this.defile.Name = "defile";
            this.defile.Size = new System.Drawing.Size(57, 23);
            this.defile.TabIndex = 3;
            this.defile.Text = "解密";
            this.defile.UseVisualStyleBackColor = true;
            // 
            // enfile
            // 
            this.enfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enfile.Location = new System.Drawing.Point(121, 84);
            this.enfile.Name = "enfile";
            this.enfile.Size = new System.Drawing.Size(61, 24);
            this.enfile.TabIndex = 2;
            this.enfile.Text = "加密";
            this.enfile.UseVisualStyleBackColor = true;
            this.enfile.Click += new System.EventHandler(this.enfile_Click);
            // 
            // view2
            // 
            this.view2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.view2.Location = new System.Drawing.Point(345, 47);
            this.view2.Name = "view2";
            this.view2.Size = new System.Drawing.Size(43, 25);
            this.view2.TabIndex = 1;
            this.view2.Text = "浏览";
            this.view2.UseVisualStyleBackColor = true;
            this.view2.Click += new System.EventHandler(this.view2_Click);
            // 
            // view1
            // 
            this.view1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.view1.Location = new System.Drawing.Point(344, 16);
            this.view1.Name = "view1";
            this.view1.Size = new System.Drawing.Size(44, 25);
            this.view1.TabIndex = 0;
            this.view1.Text = "浏览";
            this.view1.UseVisualStyleBackColor = true;
            this.view1.Click += new System.EventHandler(this.view1_Click);
            // 
            // quit
            // 
            this.quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quit.Location = new System.Drawing.Point(478, 35);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(68, 31);
            this.quit.TabIndex = 3;
            this.quit.Text = "退出";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // about
            // 
            this.about.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.about.Location = new System.Drawing.Point(478, 91);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(68, 30);
            this.about.TabIndex = 4;
            this.about.Text = "关于";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // encrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(573, 466);
            this.Controls.Add(this.about);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "encrypt";
            this.Text = "单机加密";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button detext;
        private System.Windows.Forms.Button entext;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button view1;
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.ComboBox name;
        private System.Windows.Forms.ComboBox vary;
        private System.Windows.Forms.TextBox Cyphertext;
        private System.Windows.Forms.TextBox Plaintext;
        private System.Windows.Forms.Button view2;
        private System.Windows.Forms.Button enfile;
        private System.Windows.Forms.Button defile;
        private System.Windows.Forms.ComboBox save;
        private System.Windows.Forms.ComboBox find;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Key;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Dekey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox order;
    }
}

