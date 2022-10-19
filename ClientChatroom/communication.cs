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
                thread = new Thread(() => recevoire());
                thread.Start();

            }
            catch
            {
                return false;
            }
            return true;
        }

        public void envoyer(String text)//Envoie Text
        {

            text = text.Replace("​","");//supprime les characteres invisible qui seront utilisé comme séparateur

            byte[] buffer = UnicodeEncoding.Unicode.GetBytes("1" + "​" + form1.pseudonym + "​" + text);//Le serveur doit décider de la couleur
            flux.Write(buffer, 0, buffer.Length);
        }

        
        public void deconection()
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    flux.Close();
                    form1.deconnexion_affichage();

                }
                   
            }
        }
        
        public void envoyer(String instru,bool formated)//Envoie dessin
        {
            byte[] buffer = UnicodeEncoding.Unicode.GetBytes(instru);
            flux.Write(buffer, 0, buffer.Length);

        }
        
        public void recevoire()
        {
            do
            {
                
                byte[] buffer = new byte[1024];
                try
                {
                    flux.Read(buffer, 0, buffer.Length);
                }catch (System.IO.IOException)
                {
                    continue;
                }
                

                    
                String message = UnicodeEncoding.Unicode.GetString(buffer);
                if (message.StartsWith("\0\0\0\0\0\0\0\0") )
                {
                    form1.Invoke((MethodInvoker)delegate
                    {
                        form1.deconnexion_affichage();
                    });
                    continue;
                };
                String[] split = message.Split('​');

                String[] rgbSplit = split[1].Split(',');
                Color printClr = Color.FromArgb(int.Parse(rgbSplit[0]), int.Parse(rgbSplit[1]), int.Parse(rgbSplit[2]));

                switch (split[0])
                {
                    case "0":
                        continue;
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
                        /*
                            byte px = (byte)PxUpDown.Value;

                            short xpos = (short)((mousePos.X - (px >> 1)) + 1);
                            short ypos = (short)((mousePos.Y - (px >> 1)) + 1);

                            byte[] instructions = new byte[5];

                            if (roundPen)
                            {
                                instructions[0] = 0b01_000000;
                            }
                            else
                            {
                                instructions[0] = 0b10_000000;
                            }
                            instructions[0] |= px;
                            instructions[1] = (byte) (xpos & 0b11111111);
                            instructions[2] = (byte) ((xpos & 0b11111111_00000000) >> 8);
                            instructions[3] = (byte)(ypos & 0b11111111);
                            instructions[4] = (byte)((ypos & 0b11111111_00000000) >> 8);
                            instructions[5] = 0;
                         */
                        byte[] allInstructions = UnicodeEncoding.Unicode.GetBytes(split[2]);

                        byte brush = 0;
                        byte px = 0;
                        short xPos = 0,yPos = 0;


                        for (short i = 0; i < allInstructions.Length - 3; i += 6)
                        {
                            if ((allInstructions[i] & 0b01_000000) == 0b01_000000) brush = 1;
                            else brush = 2;
                            px = (byte)(allInstructions[i] & 0b00_111111);

                            xPos = (short)((allInstructions[i + 1] & 0b1111_1111) + ((allInstructions[i + 2] & 0b1111_1111) << 8));
                            yPos = (short)((allInstructions[i + 3] & 0b1111_1111) + ((allInstructions[i + 4] & 0b1111_1111) << 8));


                            form1.Invoke((MethodInvoker)delegate
                            {
                                Brush b = new SolidBrush(printClr);
                                form1.richTextBox1.AppendText(" RECU ");
                                if (brush == 0b01_000000)
                                {


                                    form1.canvas.FillEllipse(b, xPos, yPos, px, px);
                                }
                                else if (brush == 0b10_000000)
                                {
                                    form1.canvas.FillRectangle(b, xPos, yPos, px, px);
                                }
                            });
                        }

                        
                        break;

                }
                    //String[] rgbSplit = split[3].Split(',');
                    

                    

                            
                            
                            
                    

                    
              

            }while(true);
            //deconection();
        }
    }
}
