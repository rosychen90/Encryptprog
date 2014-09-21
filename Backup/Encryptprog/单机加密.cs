using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Caecar;
using System.IO;
using DES;
using RSA;
using permutation;
using Autokey;
using Keyword;
using Vigenere;
using playfair;
using CA;
using Column;

namespace Encryptprog
{
    
    public partial class encrypt : Form
    {
        string[] skey = RSAcipher.GenerateKeys();
        
    
        public encrypt()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            name.Enabled = true;
            if (vary.SelectedItem.ToString() == "单表替代")
            {
                name.Items.Clear();
                name.Text = "";
                name.Items.Add("Caesar cipher");
                name.Items.Add("Keyword cipher");
            }
            if (vary.SelectedItem.ToString() == "多表替代")
            {
                name.Items.Clear();
                name.Text = "";
                name.Items.Add("Vigenere cipher");
                name.Items.Add("AutoKey cipher");
            }
            if (vary.SelectedItem.ToString() == "多图替代")
            {
                name.Items.Clear();
                name.Text = "";
                name.Items.Add("Playfair cipher");
            }
            if (vary.SelectedItem.ToString() == "置换")
            {
                name.Items.Clear();
                name.Text = "";
                name.Items.Add("Permutation cipher");
                name.Items.Add("Column cipher");
                order.Enabled = true;
            }
            if (vary.SelectedItem.ToString() == "流密码")
            {
                name.Items.Clear();
                name.Text = "";
                name.Items.Add("CA");
                order.Enabled = true;
            }
            if (vary.SelectedItem.ToString() == "分块密码")
            {
                name.Items.Clear();
                name.Text = "";
                name.Items.Add("DES");
            }
            if (vary.SelectedItem.ToString() == "公钥密码")
            {
                name.Items.Clear();
                name.Items.Add("RSA");
            }
        }

        private void quit_Click(object sender, EventArgs e)
        {
            string msgquit;
            msgquit = "确认退出本程序吗？";
            DialogResult quitresult = MessageBox.Show(this, msgquit, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quitresult == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void about_Click(object sender, EventArgs e)
        {
            string msgabout;
            msgabout = "本程序由   小组制作，请勿用于商业用途。" + "\n\n" + "版本号：V1.0";
            DialogResult aboutresult = MessageBox.Show(this, msgabout, "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
      
        private void view1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.Title = "打开文件";
            opendlg.Filter = "文本文件(*.txt)|*.txt";
            //opendlg.InitialDirectory = 
            opendlg.RestoreDirectory = true;
            if (opendlg.ShowDialog() == DialogResult.OK) 
            {
                find.Text = opendlg.FileName;
            }
        }

        private void view2_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedlg = new SaveFileDialog();
            savedlg.Title = "保存文件";
            savedlg.Filter = "文本文件(*.txt)|*.txt";
            //savedlg.InitialDirectory = 
            savedlg.RestoreDirectory = true;
            if (savedlg.ShowDialog() == DialogResult.OK) 
            {
                save.Text = savedlg.FileName;
            }
        }

        private void entext_Click(object sender, EventArgs e)
        {
            if (name.SelectedItem.ToString() == "RSA")
            {
                Key.Text = skey[0];
                Cyphertext.Text = RSAcipher.EncryptString(Plaintext.Text, skey[0]);
            }
            if (Plaintext.Text.Trim() != string.Empty)
                {
                      
                if (Key.Text.Trim() != string.Empty)
                    {
                        if (name.SelectedItem.ToString() == "Caesar cipher")
                        {
                        int k = Convert.ToInt32(this.Key.Text);
                        Cyphertext.Text = Caecar.Caecarcipher.Caesar(Plaintext.Text, k);
                        }
                        else if(name.SelectedItem.ToString() == "DES")
                        {
                            Cyphertext.Text = DEScipher.Encrypt(Plaintext.Text,Key.Text);  
                        }
                        else if (name.SelectedItem.ToString() == "Permutation cipher")
                        {
                            if (order.Text.ToString() != string.Empty)
                            {
                                Cyphertext.Text = permutation.permutationcipher.encrypt(Plaintext.Text, order.Text, Convert.ToInt32(Key.Text));
                            }
                            else
                            {
                                MessageBox.Show(this, "请输入密钥顺序！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (name.SelectedItem.ToString() == "AutoKey cipher")
                        {
                            Cyphertext.Text = Autokeycipher.encryption(Plaintext.Text, Key.Text);
                        }
                        else if (name.SelectedItem.ToString() == "Keyword cipher")
                        {

                            Cyphertext.Text = Keywordcipher.encrypt(Plaintext.Text, Key.Text);
                        }
                        else if (name.SelectedItem.ToString() == "Vigenere cipher")
                        {
                            Cyphertext.Text = Vigenere.Vigenere.encrypt(Plaintext.Text, Key.Text);
                        }
                        else if (name.SelectedItem.ToString() == "Playfair cipher")
                        {
                            Cyphertext.Text = playfair.Program.encryption(Plaintext.Text, Key.Text);
                        }
                        else if (name.SelectedItem.ToString() == "CA")
                        {
                            if (order.Text.ToString() != string.Empty)
                            {
                                Cyphertext.Text = CA.CA.encrypt(Plaintext.Text, order.Text, Convert.ToInt32(Key.Text));
                            }
                            else
                                MessageBox.Show(this, "请输入二进制密钥流！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (name.SelectedItem.ToString() == "Column cipher")
                        {
                            Cyphertext.Text = Column.Column.encrypt(Plaintext.Text, Key.Text);
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "请输入密钥！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                }
                else
                {
                        MessageBox.Show(this, "请输入要加密的文本！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }

        private void detext_Click(object sender, EventArgs e)
        {
            if (name.SelectedItem.ToString() == "RSA")
            {
                Key.Text = skey[1];
                Plaintext.Text = RSAcipher.DecryptString(Cyphertext.Text, skey[1]);
            }
            if (Cyphertext.Text.Trim() != string.Empty)
            {

                if (Key.Text.Trim() != string.Empty)
                {
                    if (name.SelectedItem.ToString() == "Caesar cipher")
                    {
                        int k = Convert.ToInt32(this.Key.Text);
                        Plaintext.Text = Caecar.Caecarcipher.DeCaesar(Cyphertext.Text, k);
                    }
                    else if (name.SelectedItem.ToString() == "DES")
                    {
                        Plaintext.Text = DEScipher.Decrypt(Cyphertext.Text, Key.Text);
                    }
                    else if (name.SelectedItem.ToString() == "Permutation cipher")
                    {
                        if (order.Text.ToString() != string.Empty)
                        {
                            Plaintext.Text = permutation.permutationcipher.decrypt(Cyphertext.Text, order.Text, Convert.ToInt32(Key.Text));
                        }
                        else
                        {
                            MessageBox.Show(this, "请输入密钥顺序！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (name.SelectedItem.ToString() == "AutoKey cipher")
                    {
                        Plaintext.Text = Autokeycipher.decryption(Cyphertext.Text, Key.Text);
                    }
                    else if (name.SelectedItem.ToString() == "Keyword cipher")
                    {

                        Plaintext.Text = Keywordcipher.decrypt(Cyphertext.Text, Key.Text);
                    }
                    else if (name.SelectedItem.ToString() == "Vigenere cipher")
                    {
                        Plaintext.Text = Vigenere.Vigenere.decrypt(Cyphertext.Text, Key.Text);
                    }
                    else if (name.SelectedItem.ToString() == "Playfair cipher")
                    {
                        Plaintext.Text = playfair.Program.Decrypt(Cyphertext.Text, Key.Text);
                    }
                    else if (name.SelectedItem.ToString() == "CA")
                    {
                        if (order.Text.ToString() != string.Empty)
                        {
                            Plaintext.Text = CA.CA.decrypt(Cyphertext.Text, order.Text, Convert.ToInt32(Key.Text));
                        }
                        else
                            MessageBox.Show(this, "请输入二进制密钥流！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (name.SelectedItem.ToString() == "Column cipher")
                    {
                        Plaintext.Text = Column.Column.decrypt(Cyphertext.Text, Key.Text);

                    }
                }
                else
                {
                    MessageBox.Show(this, "请输入密钥！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(this, "请输入要解密的文本！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void enfile_Click(object sender, EventArgs e)
        {
            string fileContent1 = "";
            FileStream myStream = new FileStream(find.Text, FileMode.Open,FileAccess.Read);         //打开文件，把文件读取到string变量
            StreamReader myStreamReader = new StreamReader(find.Text,System.Text.Encoding.Default);
            string fileContent;
            fileContent = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            if (name.SelectedItem.ToString() == "RSA")
            {
                Key.Text = skey[0];
                fileContent1 = RSAcipher.EncryptString(fileContent, skey[0]);
            }
            if (find.Text.Trim() != string.Empty)
            {

                if (Key.Text.Trim() != string.Empty)
                {
                    if (name.SelectedItem.ToString() == "Caesar cipher")
                    {
                        int k = Convert.ToInt32(this.Key.Text);
                        fileContent1 = Caecar.Caecarcipher.Caesar(fileContent, k);
                    }
                    else if (name.SelectedItem.ToString() == "DES")
                    {
                        fileContent1 = DEScipher.Encrypt(fileContent, Key.Text);
                    }
                    else if (name.SelectedItem.ToString() == "Permutation cipher")
                    {
                        if (order.Text.ToString() != string.Empty)
                        {
                            fileContent1 = permutation.permutationcipher.encrypt(fileContent, order.Text, Convert.ToInt32(Key.Text));
                        }
                        else
                        {
                            MessageBox.Show(this, "请输入顺序！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (name.SelectedItem.ToString() == "AutoKey cipher")
                    {
                        fileContent1 = Autokeycipher.encryption(fileContent, Key.Text);
                    }
                    else if (name.SelectedItem.ToString() == "Keyword cipher")
                    {

                        fileContent1 = Keywordcipher.encrypt(fileContent, Key.Text);
                    }
                    else if (name.SelectedItem.ToString() == "Vigenere cipher")
                    {
                        fileContent1 = Vigenere.Vigenere.encrypt(fileContent, Key.Text);
                    }
                    else if (name.SelectedItem.ToString() == "Playfair cipher")
                    {
                        fileContent1 = playfair.Program.encryption(fileContent, Key.Text);
                    }
                    else if (name.SelectedItem.ToString() == "CA")
                    {
                        if(order.Text.ToString() != string.Empty)
                        {
                            fileContent1 = CA.CA.encrypt(fileContent, order.Text, Convert.ToInt32(Key.Text));
                        }
                        else
                            MessageBox.Show(this, "请输入二进制密钥流！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (name.SelectedItem.ToString() == "Column cipher")
                    {
                        fileContent1 = Column.Column.encrypt(fileContent, Key.Text);

                    }
                }
                else
                {
                    MessageBox.Show(this, "请输入密钥！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(this, "请选择要加密的文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            FileStream myStreamr = new FileStream(save.Text, FileMode.Create,FileAccess.Write);       //创建一个文件，把字符串写入文件
            StreamWriter myStreamWriter = new StreamWriter(myStreamr);
            myStreamWriter.Write(fileContent1);
            myStreamWriter.Close();
        }

    }
}
