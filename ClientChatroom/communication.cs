using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientChatroom
{
    internal class communication
    {
        TcpClient client;
        NetworkStream flux;

        public communication()
        {

        }

        public void conection()
        {
            IPAddress iplocal = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(iplocal, 7);
            client = new TcpClient();
            client.Connect(ep);
            flux = client.GetStream();

        }

        public void envoyer(String text)
        {
            byte[] buffer = ASCIIEncoding.ASCII.GetBytes(text);
            flux.Write(buffer, 0, buffer.Length);
        }
        public void deconection()
        {

        }
        public void resevoire()
        {

        }
    }
}
