using IMClient.Utitity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMClient
{
    public partial class Form1 : Form
    {
        Socket socket = null; 
        public Form1()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint port = new IPEndPoint(ip, 3001);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(port);
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            var userName = this.txt_userName.Text.Trim();
            var password = this.txt_passWord.Text.Trim();
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("请填写完整账号密码密码!");
                return;
            }

            var message = $"Login {userName} {password} \r\n";


            SocketTool.Send(socket, message);

        }
    }
}
