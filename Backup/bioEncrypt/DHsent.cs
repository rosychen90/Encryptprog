using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;


using System.Collections;



using System.Net;

using System.IO;
using System.Threading;

namespace DH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        public double Compute()
        {
            int p = 50;
            int g = 30;
            int a = int.Parse(this.textBox8.Text);
            double n;
            n = System.Math.Pow(g, a) % p;
            return n;
        }
        public int SendVarData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            sent = s.Send(datasize);

            while (total < size)
            {
                sent = s.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }

            return total;
        }
        public void StartSend()
        {
            double n = Compute();
            this.textBox3.Text = n.ToString();
            ////创建一个网络端点
            //IPEndPoint ipep = new IPEndPoint(IPAddress.Any, int.Parse(this.textBox5.Text));

            //MessageBox.Show(IPAddress.Any);

            ////创建一个套接字
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //MessageBox.Show(server.ToString());



            //指向远程服务端节点
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, int.Parse(this.textBox5.Text));
            //创建套接字
            //Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //连接到发送端
            //client.Connect(ipep);

            ////绑定套接字到端口
            server.Bind(ipep);

            //MessageBox.Show(ipep.ToString());


            ////开始侦听(并堵塞该线程)
            server.Listen(10);
            Socket client = server.Accept();
            //获得客户端节点对象
            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
            //获得客户端的IP地址
            this.textBox1.Text = clientep.Address.ToString();
            String num = n.ToString();
            Byte[] ByteGet = System.Text.Encoding.Unicode.GetBytes(num);
            //server.Send(ByteGet,ByteGet.Length,SocketFlags.None);
            SendVarData(client, ByteGet);
            //确认连接



            server.Close();
            client.Close();
            MessageBox.Show("文件发送完毕!");

        }


        private void button1_Click(object sender, EventArgs e)
        {//开启接收线程 
            Thread TempThread = new Thread(new ThreadStart(this.StartSend));
            TempThread.Start();
            this.button1.Enabled = false;


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //获得本机的ip地址 
            this.textBox4.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
