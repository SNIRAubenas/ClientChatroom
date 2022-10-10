namespace ClientChatroom
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Connexion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connexion
            // 
            this.Connexion.Location = new System.Drawing.Point(264, 390);
            this.Connexion.Name = "Connexion";
            this.Connexion.Size = new System.Drawing.Size(75, 23);
            this.Connexion.TabIndex = 0;
            this.Connexion.Text = "Connexion";
            this.Connexion.UseVisualStyleBackColor = true;
            this.Connexion.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(384, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 456);
            this.panel1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(449, 449);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(64, 390);
            this.IPTextBox.MaxLength = 19;
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(173, 20);
            this.IPTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Enabled = false;
            this.MessageTextBox.Location = new System.Drawing.Point(63, 329);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(174, 20);
            this.MessageTextBox.TabIndex = 5;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(264, 329);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "Envoyer";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 461);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IPTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Connexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connexion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.RichTextBox richTextBox1;
    }
}

