using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bioEncrypt
{
    public partial class 双机加密 : Form
    {
        public 双机加密()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void send_Click(object sender, EventArgs e)
        {
            server.server frm = new server.server();
            frm.Show();
        }

        private void receive_Click(object sender, EventArgs e)
        {
            Client.Form1 frm1 = new Client.Form1();
            frm1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DH.Form1 DHsent = new DH.Form1();
            DHsent.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DHcli.Form1 DHrec = new DHcli.Form1();
            DHrec.Show();
        }
    }
}
