﻿using System;
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
        Thread thread;


        public communication(Form1 form1)
        {
            this.form1 = form1;
        }

        public bool conection(String text,int port)
        {
            try
            {
                IPAddress iplocal = IPAddress.Parse(text);
                IPEndPoint ep = new IPEndPoint(iplocal, port);
                client = new TcpClient();
                client.Connect(ep);
                flux = client.GetStream();
                thread = new Thread(() => resevoire());
                thread.Start();

            }
            catch
            {
                return false;
            }
            return true;
        }

        public void envoyer(String text,String pseudo)
        {
            byte[] buffer = ASCIIEncoding.ASCII.GetBytes(pseudo + ";" + text + ";" + "" + ";" + "" + "\n");
            flux.Write(buffer, 0, buffer.Length);
        }
        public void deconection()
        {
            flux.Close();
        }
        public void resevoire()
        {
            do
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    flux.Read(buffer, 0, buffer.Length);
                    String message = ASCIIEncoding.ASCII.GetString(buffer);
                    String[] split = message.Split(';');

                    form1.Invoke((MethodInvoker)delegate
                    {
                        form1.richTextBox1.Text += split[0];
                        form1.richTextBox1.Text += "\n";
                        form1.richTextBox1.Text += split[1];
                        form1.richTextBox1.Text += "\n";

                    });

                }
                catch
                {
                    break;
                }

            }while(true);
            deconection();
        }
    }
}
