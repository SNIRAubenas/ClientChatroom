using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SeurveurChatroom
{
    internal class communication
    {
        private Form1 form1;

        public communication(Form1 form1)
        {
            this.form1 = form1;

        }
        public void conection()
        {
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            int port = 18;
            TcpListener listener = new TcpListener(iPAddress, port);
            listener.Start();
            do
            {

                TcpClient tcpClient = listener.AcceptTcpClient();
                Client client = new Client(tcpClient);

            } while (true);

        }

    }
}
