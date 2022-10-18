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

            byte[] buffer = UnicodeEncoding.Unicode.GetBytes("1" + "​" + pseudo + "​" + text);//Le serveur doit décider de la couleur
            flux.Write(buffer, 0, buffer.Length);
        }
        public void deconection()
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    flux.Close();
                    

                }
                   
            }
        }
        
        public void envoyer(String Brosse,byte size,Point coords, Color paint)//Envoie dessin
        {
            byte[] rgb = BitConverter.GetBytes(paint.ToArgb());
            String instruction = Brosse + ";" + size + ";" + coords.X + ";" + coords.Y;
            
            byte[] buffer = ASCIIEncoding.Unicode.GetBytes("2"+ "​" + rgb[0] + "," + rgb[1] + "," + rgb[2] + "​" + instruction);
            flux.Write(buffer, 0, buffer.Length);
            
        }
        
        public void resevoire()
        {
            do
            {
                
                byte[] buffer = new byte[1024];
                    
                flux.Read(buffer, 0, buffer.Length);

                    
                String message = UnicodeEncoding.Unicode.GetString(buffer);
                if (message == null) break;
                String[] split = message.Split('​');

                String[] rgbSplit = split[1].Split(',');
                Color printClr = Color.FromArgb(int.Parse(rgbSplit[0]), int.Parse(rgbSplit[1]), int.Parse(rgbSplit[2]));

                switch (split[0])
                {
                    case "0":
                        break;
                    case "1":
                        String pseudo = "\n" + split[2] + "\n";
                        String txt = split[3] + "\n";
                        form1.Invoke((MethodInvoker)delegate
                        {
                            form1.richTextBox1.SelectionColor = printClr;
                            form1.richTextBox1.SelectionFont = new Font(form1.richTextBox1.Font, FontStyle.Bold);
                            form1.richTextBox1.AppendText(pseudo);
                            form1.richTextBox1.SelectionFont = new Font(form1.richTextBox1.Font, FontStyle.Regular);
                            form1.richTextBox1.AppendText(txt);
                            form1.richTextBox1.ScrollToCaret();
                        });
                        break;
                    case "2":
                        String[] instructionSplit = split[2].Split(';');

                        byte px = byte.Parse(instructionSplit[1]);

                        Brush brush = new SolidBrush(printClr);
                        //String instruction = Brosse + ";" + size + ";" + coords.X + ";" + coords.Y;

                        form1.Invoke((MethodInvoker)delegate
                        {
                            if (instructionSplit[0] == "C")
                            {
                                //communication.envoyer("C", px, pos, drawColor);
                                form1.canvas.FillEllipse(brush, byte.Parse(instructionSplit[2]), byte.Parse(instructionSplit[3]), px, px);

                            }
                            else
                            {
                                //canvas.FillRectangle(brush, pos.X, pos.Y, px, px);
                                form1.canvas.FillRectangle(brush, byte.Parse(instructionSplit[2]), byte.Parse(instructionSplit[3]), px, px);
                            }
                        });
                        break;

                }
                    //String[] rgbSplit = split[3].Split(',');
                    

                    

                            
                            
                            
                    

                    
              

            }while(true);
            //deconection();
        }
    }
}
