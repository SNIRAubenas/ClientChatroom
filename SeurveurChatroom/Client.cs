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

        String clientColor;

        public Client(TcpClient tcpClient,Communication communication)
        {
            this.Communication = communication;
            this.tcpClient = tcpClient;

            stream = tcpClient.GetStream();
            communication.add(stream);

            clientColor = ColorPicker();

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
                    message = ParseMessage(message);

                    this.Communication.message(UnicodeEncoding.Unicode.GetBytes(message));
                }
                catch
                {
                    break;
                }

            } while (true);
            //
            this.Communication.del(stream);
            tcpClient.Close();

        }

        private String ParseMessage(String fluxDentree)
        {
            String parsedMessage = "0";
            String[] splitMessage = fluxDentree.Split('​');
            //{type  ,  pseudo , message}
            //{type  ,  couleur , instructions}

            switch (splitMessage[0])
            {
                case "1":
                    parsedMessage = splitMessage[0] + "​" + clientColor + "​" + splitMessage[1] + "​" + splitMessage[2];
                    break;

                case "2":
                    parsedMessage = fluxDentree;
                    break;
            }
            return parsedMessage;
        }

        private String ColorPicker()
        {
            Random rand = new Random();
            byte r, g, b;
            bool colorful = false;

            do
            {
                byte grayCounter = 0;
                r = (byte)(rand.Next(12,236));
                g = (byte)(rand.Next(12,236));
                b = (byte)(rand.Next(12,236));
                
                if (Math.Abs(r - b) < 32)
                    grayCounter++;
                if (Math.Abs(b - g) < 32)
                    grayCounter++;
                if (Math.Abs(r - g) < 32)
                    grayCounter++;

                if (grayCounter != 3)
                    colorful = true;

            } while (!colorful);
            return r + "," + g + "," + b;

        }
    }
}
