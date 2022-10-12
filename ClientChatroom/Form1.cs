using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientChatroom
{
    public partial class Form1 : Form
    {
        communication communication;


        Graphics canvas;



        private Color drawColor;
        public Form1()
        {
            InitializeComponent();
            communication = new communication(this);
            ColorPick.SelectedIndex = 0;
            

            //canvas = System.Windows.Forms.PaintEventArgs(Graphics);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

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
       


        }

        private void MessageTextBox_Validated(object sender, EventArgs e)
        {
            if (MessageTextBox.Text.Length > 0)
            {
                communication.envoyer(MessageTextBox.Text, PseudoBox.Text);

            }
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {

            communication.deconection();

            Deconnexion.Visible = false;
            Connexion.Visible = true;
            IPTextBox.Enabled = true;
            PortNum.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            communication.deconection();
            e.Cancel = false;
            

        }

        private void ColorPick_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ColorPick.SelectedIndex)
            {
                case 0:
                    drawColor = Color.FromArgb(0, 0, 0);//Black
                    break;
                case 1:
                    drawColor = Color.FromArgb(255, 255, 255);//White
                    break;
                case 2:
                    drawColor = Color.FromArgb(255, 0, 0);//Red
                    break;
                case 3:
                    drawColor = Color.FromArgb(255, 128, 0);//Orange
                    break;
                case 4:
                    drawColor = Color.FromArgb(255, 255, 0);//Yellow
                    break;
                case 5:
                    drawColor = Color.FromArgb(128, 255, 0);//Jungle
                    break;
                case 6:
                    drawColor = Color.FromArgb(0, 255, 0);//Green
                    break;
                case 7:
                    drawColor = Color.FromArgb(0, 255, 128);//Teal
                    break;
                case 8:
                    drawColor = Color.FromArgb(0, 255, 255);//Cyan
                    break;
                case 9:
                    drawColor = Color.FromArgb(0, 128, 255);//Sky
                    break;
                case 10:
                    drawColor = Color.FromArgb(0, 0, 255);//Blue
                    break;
                case 11:
                    drawColor = Color.FromArgb(128, 0, 255);//Purple
                    break;
                case 12:
                    drawColor = Color.FromArgb(255, 0, 255);//Magenta
                    break;
                case 13:
                    drawColor = Color.FromArgb(255, 0, 128);//Fushia
                    break;

            }//fin du switch

            ColorPickedLabel.BackColor = drawColor;
        }








    }
}

