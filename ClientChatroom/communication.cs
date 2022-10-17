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

            byte[] buffer = UnicodeEncoding.Unicode.GetBytes(text + "​" + pseudo + "​" + "1" /*Le 1 represente le type "text"*/ + "​" + "5,5,5");
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
        
        public void envoyer(String Brosse,byte size,Point coords, Color paint)//Envoie dessin
        {
            byte[] rgb = BitConverter.GetBytes(paint.ToArgb());
            String instruction = Brosse + ";" + size + ";" + coords.X + ";" + coords.Y;
            

            byte[] buffer = ASCIIEncoding.Unicode.GetBytes(instruction + "​" + "anonym" + "​" + "2" /*Le 2 represente le type "Dessin"*/ + "​" + rgb[0] + "," + rgb[1] + "," + rgb[2]);
            flux.Write(buffer, 0, buffer.Length);
        }
        
        public void resevoire()
        {
            do
            {
                //try
                {

                    
                    byte[] buffer = new byte[1024];
                    
                    flux.Read(buffer, 0, buffer.Length);
                    String message = UnicodeEncoding.Unicode.GetString(buffer);
                    
                    String[] split = message.Split('​');

                    
                    String[] rgbSplit = split[3].Split(',');
                    Color printClr = Color.FromArgb(int.Parse(rgbSplit[0]), int.Parse(rgbSplit[1]), int.Parse(rgbSplit[2]));

                    switch(split[2])
                    {
                        case "0":
                            break;
                            case "1":

                            form1.Invoke((MethodInvoker)delegate
                            {
                                /*if (split[1] == form1.pseudonym)
                                {
                                    form1.ForeColor = Color.Black;
                                }
                                else
                                {
                                    form1.ForeColor = printClr;
                                }
                                */
                                form1.richTextBox1.Text += split[1];
                                form1.richTextBox1.Text += "\n";
                                form1.richTextBox1.Text += split[0];
                                form1.richTextBox1.Text += "\n";
                            });
                            break;
                            /*
                            case"2":
                            form1.Invoke((MethodInvoker)delegate
                            {
                            
                                String[] instructions = split[0].Split(';');

                                byte px = (byte)int.Parse(instructions[1]);

                                Brush brush = new SolidBrush(printClr);
                                Point pos = new Point();
                                pos.X = int.Parse(instructions[2]);
                                pos.Y = int.Parse(instructions[3]);

                                if (instructions[0] == "S")
                                form1.canvas.FillRectangle(brush, pos.X, pos.Y, px, px);
                                else
                                form1.canvas.FillEllipse(brush, pos.X, pos.Y, px, px);
                            });
                            break;
                            */
                            
                    }

                    
                    
                }
                //catch
                {
                    break;
                }

            }while(true);
            //deconection();
        }
    }
}
