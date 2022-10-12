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
        public Form1()
        {
            InitializeComponent();
            communication = new communication(this);

            
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
    }
}

