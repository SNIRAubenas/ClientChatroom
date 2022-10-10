using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace ClientChatroom
{
    internal class communication
    {
        TcpClient client;
        NetworkStream flux;
        private Form1 form1;


        public communication(Form1 form1)
        {
            this.form1 = form1;
        }

        public void conection(String text)
        {
            IPAddress iplocal = IPAddress.Parse(text);
            IPEndPoint ep = new IPEndPoint(iplocal, 18);
            client = new TcpClient();
            client.Connect(ep);
            flux = client.GetStream();
            Thread thread = new Thread(() => resevoire());
            thread.Start();


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
            do
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    flux.Write(buffer, 0, buffer.Length);
                    form1.Invoke((MethodInvoker)delegate
                    {
                        form1.richTextBox1.Text = ASCIIEncoding.ASCII.GetString(buffer);
                    });

                }
                catch
                {
                    break;
                }

            }while(true);

        }
    }
}
