using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace SocketMainMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InfoBtn_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }

        private void ServerBtn_Click(object sender, EventArgs e)
        {
            Process.Start(@"..\..\..\..\socketProgram\SocketServer\bin\Debug\SocketServer.exe");
        }

        private void ClientBtn_Click(object sender, EventArgs e)
        {
            Process.Start(@"..\..\..\..\socketProgram\SocketClient\bin\Debug\SocketClient.exe");
        }
    }
}
