using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientChatroom
{
    public partial class Form1 : Form
    {
        communication communication;


        Graphics canvas;

        bool roundPen = true, mousePressed = false;



        private Color drawColor;
        public Form1()
        {
            InitializeComponent();
            communication = new communication(this);
            ColorPick.SelectedIndex = 0;

            canvas = Canvas.CreateGraphics();
           
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if(MessageTextBox.Text.Length > 0)
            {
                communication.envoyer(MessageTextBox.Text,PseudoBox.Text);

            }



        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            Regex ipV4 = new Regex("^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            if (ipV4.IsMatch(IPTextBox.Text))
            {
                bool marche = communication.conection(IPTextBox.Text,(int)PortNum.Value);
                if (marche)
                {
                    ErrorLabel.Visible = false;
                    MessageTextBox.Enabled = true;
                    sendButton.Enabled = true;
                    Connexion.Visible = false;
                    Deconnexion.Visible = true;
                    PortNum.Enabled = false;
                    PseudoBox.Enabled = false;
                    IPTextBox.Enabled = false;


               
                    ErrorLabel.Visible = false;
                    //Canvas.Enabled = true;
                

                }
                else
                {
                    Connexion.Visible = true;
                    Deconnexion.Visible = false;
                    IPTextBox.Enabled = true;
                }

            }
            else
            {
                ErrorLabel.Text = "Adresse IP invalide";
                ErrorLabel.ForeColor = Color.Red;
                ErrorLabel.Visible = true;
                IPTextBox.Enabled = true;
            }
        }


        private void Canvas_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs) e;
            Point pos = mea.Location;

            


        }


        private void Disconnect_Click(object sender, EventArgs e)
        {

            communication.deconection();

            Deconnexion.Visible = false;
            Connexion.Visible = true;
            IPTextBox.Enabled = true;
            PortNum.Enabled = true;
            //Canvas.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            communication.deconection();
            e.Cancel = false;
            

        }
        private Color ColorSetter(int colorIdx)
        {
            

            switch (colorIdx)
            {
                case 0:
                    return Color.FromArgb(0, 0, 0);//Black
                    
                case 1:
                    return Color.FromArgb(255, 255, 255);//White
                case 2:
                    return Color.FromArgb(255, 0, 0);//Red
                case 3:
                    return Color.FromArgb(255, 128, 0);//Orange
                case 4:
                    return Color.FromArgb(255, 255, 0);//Yellow
                case 5:
                    return Color.FromArgb(128, 255, 0);//Jungle
                case 6:
                    return Color.FromArgb(0, 255, 0);//Green
                case 7:
                    return Color.FromArgb(0, 255, 128);//Teal
                case 8:
                    return Color.FromArgb(0, 255, 255);//Cyan
                case 9:
                    return Color.FromArgb(0, 128, 255);//Sky
                case 10:
                    return Color.FromArgb(0, 0, 255);//Blue
                case 11:
                    return Color.FromArgb(128, 0, 255);//Purple
                case 12:
                    return Color.FromArgb(255, 0, 255);//Magenta
                case 13:
                    return Color.FromArgb(255, 0, 128);//Fushia
                case 14:
                    return Color.FromArgb(128, 128, 128);//Gray
                case 15:
                    return Color.FromArgb(64, 64, 64);//DarkGray
                default:
                    Random rd = new Random();
                    return Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256));

            }
        }
        private void ColorPick_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fin du switch
            drawColor = ColorSetter(ColorPick.SelectedIndex);
            ColorPickedLabel.BackColor = drawColor;
        }

        private void RoundBrush_Click(object sender, EventArgs e)
        {
            RoundBrush.Enabled = false;
            SquareBrush.Enabled = true;
            roundPen = true;
        }

        private void SquareBrush_Click(object sender, EventArgs e)
        {
            SquareBrush.Enabled = false;
            RoundBrush.Enabled = true;
            roundPen = false;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            mousePressed = true;
            

        }

        private void Canvas_MouseMove(object sender, MouseEventArgs mousePos)
        {

            
            {
                if (mousePressed)
                {
                    byte px = (byte)PxUpDown.Value;

                    Brush brush = new SolidBrush(drawColor);
                    Point pos = new Point();
                    pos.X = (mousePos.X - (px >> 1)) + 1;
                    pos.Y = (mousePos.Y - (px >> 1)) + 1;
                
                    if (roundPen)
                    {
                        //communication.envoyer("C", px, pos,drawColor);
                        canvas.FillEllipse(brush, pos.X, pos.Y, px, px);

                    }
                    else
                    {
                        canvas.FillRectangle(brush, pos.X, pos.Y, px, px);
                        //communication.envoyer("S",px,pos,drawColor);
                    }



                
                }
            }
            
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mousePressed = false;
            
        }

        
            
            

        

    }
}

