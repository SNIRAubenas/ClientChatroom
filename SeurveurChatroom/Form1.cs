using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeurveurChatroom
{
    public partial class Form1 : Form
    {
        Communication communication;
        public Form1()
        {
            InitializeComponent();
            communication = new Communication(this);
        }

        bool workin = false;

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!workin)
                {
                    OnOff.BackColor = Color.Orange;
                    communication.init();
                    button.Text = "OFF";
                    OnOff.BackColor = Color.Green;
                    return;
                }
            }
            catch
            {

            }

            button.Text = "ON";
            OnOff.BackColor = Color.Red;
        }
    }
}
