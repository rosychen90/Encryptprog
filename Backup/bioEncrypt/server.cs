using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace server
{
    public partial class server : Form
    {
        public server()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //选择要进行传输的文件
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo MyFile = new FileInfo(this.openFileDialog1.FileName);
                this.textBox1.Text = MyFile.FullName;
                this.textBox2.Text = MyFile.Name;
                this.textBox3.Text = MyFile.Length.ToString();

            }
        }


        public void StartSend()
        {
            //创建一个文件对象
            FileInfo MyFile = new FileInfo(this.textBox1.Text);
            //打开文件流
            FileStream MyStream = MyFile.OpenRead();
            //包的大小
            int PacketSize = int.Parse(this.textBox6.Text);
            //包的数量
            int PacketCount = (int)(MyStream.Length / ((long)PacketSize));
            this.textBox8.Text = PacketCount.ToString();
            this.progressBar1.Maximum = PacketCount;
            //最后一个包的大小
            int LastDataPacket = (int)(MyStream.Length - ((long)(PacketSize * PacketCount)));
            this.textBox9.Text = LastDataPacket.ToString();

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
            //确认连接
            Socket client = server.Accept();

            // MessageBox.Show(client.ToString());


            //获得客户端节点对象
            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
            //获得客户端的IP地址
            this.textBox7.Text = clientep.Address.ToString();
            //发送[文件名]到客户端
            TransferFiles.TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(MyFile.Name));
            //发送[包的大小]到客户端
            TransferFiles.TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(PacketSize.ToString()));
            //发送[包的总数量]到客户端
            TransferFiles.TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(PacketCount.ToString()));
            //发送[最后一个包的大小]到客户端
            TransferFiles.TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(LastDataPacket.ToString()));

            //数据包
            byte[] data = new byte[PacketSize];
            //开始循环发送数据包
            for (int i = 0; i < PacketCount; i++)
            {
                //从文件流读取数据并填充数据包
                MyStream.Read(data, 0, data.Length);
                //发送数据包
                TransferFiles.TransferFiles.SendVarData(client, data);
                //显示发送数据包的个数
                this.textBox10.Text = ((int)(i + 1)).ToString();
                //进度条值的显示
                this.progressBar1.PerformStep();
            }

            //如果还有多余的数据包,则应该发送完毕!
            if (LastDataPacket != 0)
            {
                data = new byte[LastDataPacket];
                MyStream.Read(data, 0, data.Length);
                TransferFiles.TransferFiles.SendVarData(client, data);
                this.progressBar1.Value = this.progressBar1.Maximum;
            }

            //关闭套接字
            client.Close();
            //server.Close();
            //关闭文件流
            MyStream.Close();
            this.button2.Enabled = true;
            MessageBox.Show("文件传输完毕!");
        }


        private void button2_Click(object sender, EventArgs e)
        {//开启文件传输子线程
            Thread TempThread = new Thread(new ThreadStart(this.StartSend));
            TempThread.Start();
            this.button2.Enabled = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox4.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //string hostname=Dns.GetHostName();


        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

