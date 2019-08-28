using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public string text_to_send;
        public string myNic="";
        public string myNewNic = "";
        public int count = 0;

        private bool nicButtonClicked = false;

        public Form1()
        {
            InitializeComponent();

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());//get my own ip
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox5.Text = address.ToString();
                    myNic = address.ToString()+" CLIENT";
                    myNewNic = address.ToString()+" CLIENT";
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(textBox5.Text), int.Parse(textBox6.Text));

            try
            {
                client.Connect(IP_End);
                if (client.Connected)
                {
                    textBox2.AppendText(myNic+"님이 입장하셨습니다" + "\r\n");
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;

                    backgroundWorker1.RunWorkerAsync();//start receiving data in background
                    backgroundWorker2.WorkerSupportsCancellation = true;//ability to cancel this thread
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();
                    this.textBox2.Invoke(new MethodInvoker(delegate () {
                        textBox2.AppendText(receive+"\r\n");
                    }));
                    receive = "";
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
            }
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                this.textBox2.Invoke(new MethodInvoker(delegate ()
                {                   
                    text_to_send = myNewNic + " : " + text_to_send + "\r\n";
                    textBox2.AppendText(text_to_send);
                }));
                STW.WriteLine(text_to_send);
            }
            else
            {
                MessageBox.Show("전송에 실패하였습니다");
            }
            backgroundWorker2.CancelAsync();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                text_to_send = textBox1.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            textBox1.Text = "";
        }

        private void NicButton_Click(object sender, EventArgs e)
        {
            nicButtonClicked = true;
            myNewNic = nicTextBox.Text.ToString();
            string changeNic = myNic + "님이 " + myNewNic + "으로 닉네임을 변경하였습니다" + "\r\n";

            this.textBox2.Invoke(new MethodInvoker(delegate ()
            {
                textBox2.AppendText(changeNic);
            }));
            STW.WriteLine(changeNic);
        }
    }
}
