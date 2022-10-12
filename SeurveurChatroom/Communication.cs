using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SeurveurChatroom
{
    internal class Communication
    {
        private Form1 form1;
        private List<NetworkStream> networkStream;
        private TcpListener listener;

        public Communication(Form1 form1)
        {
            this.form1 = form1;
            networkStream = new List<NetworkStream>();
        }
        public void conection()
        {
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            int port = 18;
            listener = new TcpListener(iPAddress, port);
            listener.Start();
            do
            {
                try
                {
                    TcpClient tcpClient = listener.AcceptTcpClient();
                    Client client = new Client(tcpClient,this);

                }
                catch
                {
                    break;
                }

            } while (true);

        }
        public void init()
        {
            Thread thread = new Thread(() => conection());
            thread.Start();
            

        }
        public void deconexion()
        {
            foreach (NetworkStream stream in networkStream)
            {
                stream.Close();
            }
            listener.Stop();
        }
        public void add(NetworkStream stream)
        {
            networkStream.Add(stream);
        }
        public void message(String message)
        {
            Byte[] bytes = Encoding.Unicode.GetBytes(message);

            foreach(NetworkStream stream in networkStream)
            {
                stream.Write(bytes,0,bytes.Length);
            }
        }

    }
}
