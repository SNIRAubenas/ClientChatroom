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
using System.Drawing;

namespace ClientChatroom
{
    internal class communication
    {
        TcpClient client;
        NetworkStream flux;
        private Form1 form1;
        private Thread thread;


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
                form1.richTextBox1.Text += "ThreadStarted\n";
                if ( flux.CanWrite) form1.richTextBox1.Text += "devrais Marcher\n";

            }
            catch
            {
                return false;
            }
            return true;
        }

        public void envoyer(String text,String pseudo)//Envoie Text
        {
            text = text.Replace("​","");//supprime les characteres invisible qui seront utilisé comme séparateur

            byte[] buffer = UnicodeEncoding.Unicode.GetBytes(text + "​" + pseudo + "​" + "1" /*Le 1 represente le type "text"*/ + "​");
            flux.Write(buffer, 0, buffer.Length);
        }
        public void deconection()
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    flux.Close();
                    form1.richTextBox1.Text += "Flux closed\n";

                }
                   
            }
        }
        /*
        public void envoyer(String Brosse,byte size,Point coords, Color paint)//Envoie dessin
        {
            byte[] rgb = BitConverter.GetBytes(paint.ToArgb());
            String instruction = Brosse + ";" + size + ";" + coords.X + ";" + coords.Y;
            

            //byte[] buffer = ASCIIEncoding.Unicode.GetBytes(instruction + "​" + "anonym" + "​" + "2" /*Le 2 represente le type "Dessin"*//* + "​" );
            //flux.Write(buffer, 0, buffer.Length);
        }
        */
        public void resevoire()
        {
            do
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    //flux.Position = 0;
                    flux.Read(buffer, 0, buffer.Length);
                    String message = UnicodeEncoding.Unicode.GetString(buffer);

                    String[] split = message.Split('​');

                    form1.Invoke((MethodInvoker)delegate
                    {

                            form1.richTextBox1.Text += split[1];
                            form1.richTextBox1.Text += "\n";
                            form1.richTextBox1.Text += split[0];
                            form1.richTextBox1.Text += "\n";
                        

                    });

                }
                catch
                {
                    break;
                }

            }while(true);
            //deconection();
        }
    }
}
