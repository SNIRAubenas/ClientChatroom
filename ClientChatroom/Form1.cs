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
            communication = new communication();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            communication.conection(textBox1.Text);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {

        }
    }
}
