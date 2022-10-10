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
                communication.envoyer(MessageTextBox.Text);

            }



        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            Regex ipV4 = new Regex("^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            if (ipV4.IsMatch(IPTextBox.Text))
            {
                Connexion.Enabled = false;
                bool marche = communication.conection(IPTextBox.Text);
                if (marche)
                {
                    label2.Visible = false;
                    MessageTextBox.Enabled = true;
                    sendButton.Enabled = true;
                    Connexion.Enabled = false;

                }
                else
                {
                    Connexion.Enabled = true;
                }
            }
            else
            {
                label2.Text = "Adresse IP invalide";
                label2.ForeColor = Color.Red;
                label2.Visible = true;
            }
        }


        private void Canvas_Click(object sender, EventArgs e)
        {
       


        }

        private void MessageTextBox_Validated(object sender, EventArgs e)
        {
            if (MessageTextBox.Text.Length > 0)
            {
                communication.envoyer(MessageTextBox.Text);

            }
        }
    }
}

