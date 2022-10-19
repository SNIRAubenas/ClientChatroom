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
        bool ok=true;
        communication communication;

        private byte paintCounter = 0;
        public Graphics canvas;
        public String pseudonym;

        private String paintBuffer = "";

        bool roundPen = true, mousePressed = false;


        private String stringColor = "0,0,0";
        private Color drawColor;
        public Form1()
        {
            InitializeComponent();
            communication = new communication(this);
            ColorPick.SelectedIndex = 0;

            canvas = Canvas.CreateGraphics();

            paintBuffer = "2" + "​" + stringColor + "​";

    }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if(MessageTextBox.Text.Length > 0)
            {
                communication.envoyer(MessageTextBox.Text);

            }



        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (PseudoBox.Text == "") 
            {
                ErrorLabel.Text = "Entrez un Psuedonym svp";
                ErrorLabel.ForeColor = Color.Red;
                ErrorLabel.Visible = true;
                IPTextBox.Enabled = true;
                PseudoBox.Enabled = true;
                return;
            }

            Regex ipV4 = new Regex("^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            if (ipV4.IsMatch(IPTextBox.Text))
            {
                bool marche = communication.conection(IPTextBox.Text,(int)PortNum.Value);
                if (marche)
                {
                    
                    MessageTextBox.Enabled = true;
                    sendButton.Enabled = true;
                    Canvas.Enabled = true;
                    Deconnexion.Visible = true;
                    Deconnexion.Enabled = true;
                    PortNum.Enabled = false;
                    PseudoBox.Enabled = false;
                    IPTextBox.Enabled = false;
                    ErrorLabel.Visible = false;
                    Connexion.Visible = false;

                    this.pseudonym = PseudoBox.Text.Replace("​", ""); ;
               
                    ErrorLabel.Visible = false;
                    //Canvas.Enabled = true;
                    

                }
                else
                {
                    Connexion.Visible = true;
                    Deconnexion.Visible = false;
                    Deconnexion.Enabled = false;
                    Canvas.Enabled = false;
                    IPTextBox.Enabled = true;
                    PseudoBox.Enabled = true;
                }

            }
            else
            {
                ErrorLabel.Text = "Adresse IP invalide";
                ErrorLabel.ForeColor = Color.Red;
                ErrorLabel.Visible = true;
                IPTextBox.Enabled = true;
                PseudoBox.Enabled = true;
            }
        }


        private void Disconnect_Click(object sender, EventArgs e)
        {
            communication.deconection();
            deconnexion_affichage();

            
        }
        public void deconnexion_affichage()
        {
            Deconnexion.Visible = false;
            Deconnexion.Enabled = false;
            Canvas.Enabled = false;
            Connexion.Visible = true;
            IPTextBox.Enabled = true;
            PortNum.Enabled = true;
            PseudoBox.Enabled = true;
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
                    stringColor = "0,0,0";
                    return Color.FromArgb(0, 0, 0);//Black
                case 1:
                    stringColor = "255,255,255";
                    return Color.FromArgb(255, 255, 255);//White
                case 2:
                    stringColor = "255,0,0";
                    return Color.FromArgb(255, 0, 0);//Red
                case 3:
                    stringColor = "255,128,0";
                    return Color.FromArgb(255, 128, 0);//Orange
                case 4:
                    stringColor = "255,255,0";
                    return Color.FromArgb(255, 255, 0);//Yellow
                case 5:
                    stringColor = "128,255,0";
                    return Color.FromArgb(128, 255, 0);//Jungle
                case 6:
                    stringColor = "0,255,0";
                    return Color.FromArgb(0, 255, 0);//Green
                case 7:
                    stringColor = "0,255,128";
                    return Color.FromArgb(0, 255, 128);//Teal
                case 8:
                    stringColor = "0,255,255";
                    return Color.FromArgb(0, 255, 255);//Cyan
                case 9:
                    stringColor = "0,128,255";
                    return Color.FromArgb(0, 128, 255);//Sky
                case 10:
                    stringColor = "0,0,255";
                    return Color.FromArgb(0, 0, 255);//Blue
                case 11:
                    stringColor = "128,0,255";
                    return Color.FromArgb(128, 0, 255);//Purple
                case 12:
                    stringColor = "255,0,255";
                    return Color.FromArgb(255, 0, 255);//Magenta
                case 13:
                    stringColor = "255,0,128";
                    return Color.FromArgb(255, 0, 128);//Fushia
                case 14:
                    stringColor = "128,128,128";
                    return Color.FromArgb(128, 128, 128);//Gray
                case 15:
                    stringColor = "64,64,64";
                    return Color.FromArgb(64, 64, 64);//DarkGray
                default:
                    Random rd = new Random();
                    byte r = (byte)rd.Next(256); byte g = (byte)rd.Next(256); byte b = (byte)rd.Next(256);
                    stringColor = r + "," + g + "," + b;
                    return Color.FromArgb(r,g,b);

            }
        }
        private void ColorPick_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fin du switch
            drawColor = ColorSetter(ColorPick.SelectedIndex);
            ColorPickedLabel.BackColor = drawColor;

            paintBuffer = "2" + "​" + stringColor + "​";
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

            
            
                if (mousePressed && (paintCounter < 24))
                {
                    paintCounter++;
                    byte px = (byte)PxUpDown.Value;

                short xpos = (short)((mousePos.X - (px >> 1)) + 1);
                short ypos = (short)((mousePos.Y - (px >> 1)) + 1);

                byte[] instructions = new byte[6];

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

                paintBuffer += UnicodeEncoding.Unicode.GetString(instructions);

            }
            else
            {
                if (paintCounter == 0) return;
                communication.envoyer(paintBuffer,true);
                paintCounter = 0;
                paintBuffer = "2" + "​" + stringColor + "​";
                richTextBox1.AppendText(" sent draw ");
            }



        }

        private void Canvas_Click(object sender, EventArgs mouse)
        {
            byte px = (byte)PxUpDown.Value;

            MouseEventArgs mea = (MouseEventArgs)mouse;

            short xpos = (short)((mea.X - (px >> 1)) + 1);
            short ypos = (short)((mea.Y - (px >> 1)) + 1);

            byte[] instructions = new byte[6];

            if (roundPen)
            {
                instructions[0] = 0b01_000000;
            }
            else
            {
                instructions[0] = 0b10_000000;
            }
            instructions[0] |= px;
            instructions[1] = (byte)(xpos & 0b11111111);
            instructions[2] = (byte)((xpos & 0b11111111_00000000) >> 8);
            instructions[3] = (byte)(ypos & 0b11111111);
            instructions[4] = (byte)((ypos & 0b11111111_00000000) >> 8);
            instructions[5] = 0;

            communication.envoyer("2" + "​" + stringColor + "​" + UnicodeEncoding.Unicode.GetString(instructions), true);
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mousePressed = false;
            
        }

    }
}

