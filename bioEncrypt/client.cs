using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {//获得本机的ip地址 
            this.textBox4.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();

        }

        #region 功能函数

        private void StartReceive()
        {
            //指向远程服务端节点 
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(this.textBox1.Text), int.Parse(this.textBox5.Text));
            //创建套接字 
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //连接到发送端 
            client.Connect(ipep);
            //获得[文件名] 
            string SendFileName = System.Text.Encoding.Unicode.GetString(TransferFiles.TransferFiles.ReceiveVarData(client));
            this.textBox2.Text = SendFileName;
            //获得[包的大小] 
            this.textBox3.Text = System.Text.Encoding.Unicode.GetString(TransferFiles.TransferFiles.ReceiveVarData(client));
            //获得[包的总数量] 
            this.textBox8.Text = System.Text.Encoding.Unicode.GetString(TransferFiles.TransferFiles.ReceiveVarData(client));
            this.progressBar1.Maximum = int.Parse(this.textBox8.Text);
            //获得[最后一个包的大小] 
            this.textBox9.Text = System.Text.Encoding.Unicode.GetString(TransferFiles.TransferFiles.ReceiveVarData(client));
            //创建一个新文件 
            FileStream myfilestream = new FileStream(SendFileName, FileMode.Create, FileAccess.Write);
            //已发送包的个数 
            int sendedcount = 0;
            while (true)
            {
                byte[] data = TransferFiles.TransferFiles.ReceiveVarData(client);
                if (data.Length == 0)
                {
                    break;
                }
                else
                {
                    sendedcount++;
                    //将接收到的数据包写入到文件流对象 
                    myfilestream.Write(data, 0, data.Length);
                    //显示已发送包的个数 
                    this.textBox10.Text = sendedcount.ToString();
                    //进度条值的显示 
                    this.progressBar1.PerformStep();
                }
            }
            this.progressBar1.Value = this.progressBar1.Maximum;
            //关闭文件流 
            myfilestream.Close();
            //关闭套接字 
            client.Close();
            this.button1.Enabled = true;
            MessageBox.Show("文件接收完毕!");
        }
        #endregion


        private void button1_Click(object sender, EventArgs e)
        {//开启接收线程 
            Thread TempThread = new Thread(new ThreadStart(this.StartReceive));
            TempThread.Start();
            this.button1.Enabled = false;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
