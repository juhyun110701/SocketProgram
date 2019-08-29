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
        public StreamReader STR;    //상대방의 메시지를 불러들이는 데에 사용
        public StreamWriter STW;    //나의 메시지를 저장하는 데에 사용
        public string receive;      //BackgroundWorker1_DoWork를 통해 받아온 메시지를 저장, 출력
        public string text_to_send; //BackgroundWorker2_DoWork를 통해 보낼 메시지를 저장, 출력
        public string myNic="";     //나의 닉네임을 저장하는 변수
        public string myNewNic = "";//내가 변경한 닉네임을 저장하는 변수

        private bool nicButtonClicked = false;  //닉네임을 변경하는 버튼을 클릭했는지 확인하는 bool타입 변수

        public Form1()
        {
            InitializeComponent();

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());  //내 PC의 IP 주소를 받아옴
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox5.Text = address.ToString();
                    myNic = address.ToString()+" CLIENT";       //나의 닉네임 변수에 IP주소+CLIENT 를 저장함
                    myNewNic = address.ToString()+" CLIENT";    //내가 변경한 닉네임을 저장하는 변수에 IP주소+CLIENT 를 저장함
                }
            }
        }

        //서버에 연결하는 버튼
        private void Button3_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(textBox5.Text), int.Parse(textBox6.Text));   
            //IP주소가 담겨있는 textBox를 IPAddress 형식으로 바꾸고, Port번호가 담겨있는 textBox를 int 형식으로 바꾸어 IPEndPoint에 저장

            try
            {
                client.Connect(IP_End);//작성된 IP주소와 Port번호에 해당하는 방에 연결
                if (client.Connected)   //만약 클라이언트가 연결되었다면
                {
                    textBox2.AppendText(myNic + "님이 입장하셨습니다" + "\r\n"); //닉네임 + 님이 입장하셨습니다 라는 문구를 채팅창에 띄워줌
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;

                    backgroundWorker1.RunWorkerAsync();     //BackgroundWorker1을 사용해 메시지를 받아오기 시작
                    backgroundWorker2.WorkerSupportsCancellation = true;    //이 스레드를 취소할 수 있도록 함
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());  
            }
        }

        //BackgroundWorker1 : 메시지를 받아옴
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)    //클라이언트가 연결되었을 시
            {
                try
                {
                    receive = STR.ReadLine();   //STR에 담겨있는 내용을 한 줄씩 읽어 receive 변수에 저장
                    this.textBox2.Invoke(new MethodInvoker(delegate () {
                        textBox2.AppendText(receive + "\r\n");  //채팅창에 receive에 담겨있는 내용을 출력
                    }));
                    receive = "";   //receive 변수를 비워줌
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
            }
        }

        //BackgroundWorker2 : 내가 작성한 메시지를 전달할 때에 사용
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)   //만약 클라이언트가 연결되었을 시
            {
                this.textBox2.Invoke(new MethodInvoker(delegate ()
                {
                    text_to_send = myNewNic + " : " + text_to_send + "\r\n";    //text_to_send 변수에 나의 닉네임 + 보낼 메시지를 저장
                    textBox2.AppendText(text_to_send);  //채팅창에 text_to_send 변수에 담겨있는 내용을 출력
                }));
                STW.WriteLine(text_to_send);    //STW에 text_to_send 변수에 담겨있는 내용을 전달
            }
            else
            {
                MessageBox.Show("전송에 실패하였습니다");
            }
            backgroundWorker2.CancelAsync();
        }

        //메시지 전송 버튼
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")    //만약 메시지를 작성하는 칸이 비어있지 않다면
            {
                text_to_send = textBox1.Text;   //text_to_send  변수에 메시지를 작성하는 칸에 담긴 내용을 저장
                backgroundWorker2.RunWorkerAsync();
            }
            textBox1.Text = "";
        }

        //닉네임 변경 버튼
        private void NicButton_Click(object sender, EventArgs e)
        {
            nicButtonClicked = true;    //닉네임을 변경하는 버튼이 클릭되었을 때 bool 타입 nicButtonClicked 변수에 true 값을 저장
            myNewNic = nicTextBox.Text.ToString();  //나의 새로운 닉네임 변수에 바꿀 닉네임을 입력한 칸의 내용을 저장
            string changeNic = myNic + "님이 " + myNewNic + "으로 닉네임을 변경하였습니다"+"\r\n";

            this.textBox2.Invoke(new MethodInvoker(delegate ()
            {
                textBox2.AppendText(changeNic); //닉네임을 변경하였다는 문구 띄워줌
            }));
            STW.WriteLine(changeNic);
        }
    }
}
