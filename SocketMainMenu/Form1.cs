using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;   //Process.Start() 사용을 위한 임포트

namespace SocketMainMenu
{
    public partial class Form1 : Form
    {
        //Socket Program의 메인 화면
        //Info창을 띄우거나, 서버창을 열거나 클라이언트 창을 열 수 있음
        public Form1()
        {
            InitializeComponent();
        }

        //Info
        private void InfoBtn_Click(object sender, EventArgs e)
        {
            //Info 버튼(? 버튼)을 클릭할 시 소켓 프로그램에 관련된 정보를 알려주는 Info창을 띄워줌
            //ShowDialog()처리를 하여 Info창을 띄울 시 다른 창을 클릭하지 못하게 함
            Info info = new Info();
            info.ShowDialog();
        }

        //Server창
        private void ServerBtn_Click(object sender, EventArgs e)
        {
            //SERVER 버튼을 클릭할 시 소켓 프로그램의 서버창을 띄워줌
            Process.Start(@"..\..\..\..\socketProgram\SocketServer\bin\Debug\SocketServer.exe");    
            //System.Diagnostics의 Process.Start()를 사용해 상대경로로 서버 프로그램 창을 띄워줌
        }

        //Client창
        private void ClientBtn_Click(object sender, EventArgs e)
        {
            //CLIENT 버튼을 클릭할 시 소켓 프로그램의 클라이언트창을 띄워줌
            Process.Start(@"..\..\..\..\socketProgram\SocketClient\bin\Debug\SocketClient.exe");
            //System.Diagnostics의 Process.Start()를 사용해 상대경로로 클라이언트 프로그램 창을 띄워줌
        }
    }
}
