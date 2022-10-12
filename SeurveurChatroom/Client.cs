using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeurveurChatroom
{
    internal class Client
    {
        public Client(TcpClient tcpClient)
        {
            Thread thread = new Thread(() => run(tcpClient));
            thread.Start();
        }
        public void run(TcpClient tcpClient)
        {
            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = new byte[1024];
            do
            {
                try
                {

                    int lu = stream.Read(buffer, 0, buffer.Length);
                    if (lu == 0)
                    {

                        break;
                    }
                    string message = ASCIIEncoding.Unicode.GetString(buffer, 0, lu);
                    Console.WriteLine(message);
                    stream.Write(buffer, 0, lu);

                }
                catch
                {
                    break;
                }

            } while (true);
            tcpClient.Close();

        }


    }
}
