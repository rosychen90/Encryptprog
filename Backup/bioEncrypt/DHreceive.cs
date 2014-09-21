using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;


using System.Collections;



using System.Net;

using System.IO;
using System.Threading;

namespace DHcli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public byte[] ReceiveVarData(Socket s)
        {
            int total = 0;
            int recv;
            byte[] datasize = new byte[4];
            recv = s.Receive(datasize, 0, 4, SocketFlags.None);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];
            while (total < size)
            {
                recv = s.Receive(data, total, dataleft, SocketFlags.None);
                if (recv == 0)
                {
                    data = null;
                    break;
                }
                total += recv;
                dataleft -= recv;
            }
            return data;
        }

        /* public double Compute()
         {
             int p = 5;
             int g = int.Parse();
             int a = int.Parse(this.textBox1.Text);
             double n;
             n = System.Math.Pow(g, a) % p;
             return n;
         }*/
        private void StartReceive()
        {
            Byte[] RecvBytes = new Byte[256];
            //指向远程服务端节点 
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(this.textBox6.Text), int.Parse(this.textBox11.Text));
            //创建套接字 
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //连接到发送端 
            client.Connect(ipep);
            //创建套接字 

            //String strRetPage = null;
            //Int32 bytes=client.Receive(RecvBytes, RecvBytes.Length,0);
            //Socket server = client.Accept();
            string num = System.Text.Encoding.Unicode.GetString(ReceiveVarData(client));



            this.textBox15.Text = num;//client.Receive(RecvBytes, RecvBytes.Length, SocketFlags.None).ToString();

            int p = 50;
            int g = int.Parse(num);
            int a = int.Parse(this.textBox2.Text);
            double n;
            n = System.Math.Pow(g, a) % p;
            this.textBox16.Text = n.ToString();



            //关闭套接字 
            client.Close();
            //this.button1.Enabled = true;
            MessageBox.Show("文件接收完毕!");
        }
        private void button2_Click(object sender, EventArgs e)
        {

            Thread TempThread = new Thread(new ThreadStart(this.StartReceive));
            TempThread.Start();
            this.button2.Enabled = false;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //获得本机的ip地址 
            this.textBox7.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();


        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
