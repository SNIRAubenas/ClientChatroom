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
        Communication Communication;
        NetworkStream stream;
        TcpClient tcpClient;

        public Client(TcpClient tcpClient,Communication communication)
        {
            this.Communication = communication;
            this.tcpClient = tcpClient;

            stream = tcpClient.GetStream();
            communication.add(stream);

            ThreadStart ts = new ThreadStart(run);
            Thread thread = new Thread(ts);
            thread.Start();
        }
        public void run()
        {

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
                    string message = UnicodeEncoding.Unicode.GetString(buffer, 0, lu);

                    this.Communication.message(buffer);
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
