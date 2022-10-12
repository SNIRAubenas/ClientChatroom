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
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.IpLabel = new System.Windows.Forms.Label();
            this.PortNum = new System.Windows.Forms.NumericUpDown();
            this.PortLabel = new System.Windows.Forms.Label();
            this.PseudoLabel = new System.Windows.Forms.Label();
            this.PseudoBox = new System.Windows.Forms.TextBox();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.RoundBrush = new System.Windows.Forms.Button();
            this.SquareBrush = new System.Windows.Forms.Button();
            this.Deconnexion = new System.Windows.Forms.Button();
            this.ColorPick = new System.Windows.Forms.ComboBox();
            this.ColorPickedLabel = new System.Windows.Forms.Label();
            this.PxUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelDebug = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PxUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Connexion
            // 
            this.Connexion.Location = new System.Drawing.Point(278, 390);
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
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(449, 449);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(35, 392);
            this.IPTextBox.MaxLength = 19;
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(135, 20);
            this.IPTextBox.TabIndex = 2;
            this.IPTextBox.Text = "127.0.0.1";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(60, 428);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(35, 13);
            this.ErrorLabel.TabIndex = 4;
            this.ErrorLabel.Text = "label2";
            this.ErrorLabel.Visible = false;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Enabled = false;
            this.MessageTextBox.Location = new System.Drawing.Point(16, 264);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(242, 20);
            this.MessageTextBox.TabIndex = 5;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(278, 264);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "Envoyer";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(12, 395);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(17, 13);
            this.IpLabel.TabIndex = 7;
            this.IpLabel.Text = "IP";
            // 
            // PortNum
            // 
            this.PortNum.Location = new System.Drawing.Point(212, 392);
            this.PortNum.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.PortNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortNum.Name = "PortNum";
            this.PortNum.Size = new System.Drawing.Size(46, 20);
            this.PortNum.TabIndex = 8;
            this.PortNum.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(176, 395);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(26, 13);
            this.PortLabel.TabIndex = 9;
            this.PortLabel.Text = "Port";
            // 
            // PseudoLabel
            // 
            this.PseudoLabel.AutoSize = true;
            this.PseudoLabel.Location = new System.Drawing.Point(22, 352);
            this.PseudoLabel.Name = "PseudoLabel";
            this.PseudoLabel.Size = new System.Drawing.Size(62, 13);
            this.PseudoLabel.TabIndex = 10;
            this.PseudoLabel.Text = "Pseudonym";
            // 
            // PseudoBox
            // 
            this.PseudoBox.Location = new System.Drawing.Point(107, 352);
            this.PseudoBox.MaxLength = 21;
            this.PseudoBox.Name = "PseudoBox";
            this.PseudoBox.Size = new System.Drawing.Size(246, 20);
            this.PseudoBox.TabIndex = 11;
            // 
            // Canvas
            // 
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.Location = new System.Drawing.Point(16, 16);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(224, 224);
            this.Canvas.TabIndex = 12;
            this.Canvas.TabStop = false;
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // RoundBrush
            // 
            this.RoundBrush.Enabled = false;
            this.RoundBrush.Location = new System.Drawing.Point(246, 16);
            this.RoundBrush.Name = "RoundBrush";
            this.RoundBrush.Size = new System.Drawing.Size(40, 40);
            this.RoundBrush.TabIndex = 13;
            this.RoundBrush.Text = "○";
            this.RoundBrush.UseVisualStyleBackColor = true;
            this.RoundBrush.Click += new System.EventHandler(this.RoundBrush_Click);
            // 
            // SquareBrush
            // 
            this.SquareBrush.Location = new System.Drawing.Point(292, 16);
            this.SquareBrush.Name = "SquareBrush";
            this.SquareBrush.Size = new System.Drawing.Size(40, 40);
            this.SquareBrush.TabIndex = 14;
            this.SquareBrush.Text = "▬";
            this.SquareBrush.UseVisualStyleBackColor = true;
            this.SquareBrush.Click += new System.EventHandler(this.SquareBrush_Click);
            // 
            // Deconnexion
            // 
            this.Deconnexion.Location = new System.Drawing.Point(278, 390);
            this.Deconnexion.Name = "Deconnexion";
            this.Deconnexion.Size = new System.Drawing.Size(75, 23);
            this.Deconnexion.TabIndex = 15;
            this.Deconnexion.Text = "Deconnexion";
            this.Deconnexion.UseVisualStyleBackColor = true;
            this.Deconnexion.Visible = false;
            this.Deconnexion.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // ColorPick
            // 
            this.ColorPick.FormattingEnabled = true;
            this.ColorPick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ColorPick.ItemHeight = 13;
            this.ColorPick.Items.AddRange(new object[] {
            "Black",
            "White",
            "Red",
            "Orange",
            "Yellow",
            "Jungle",
            "Green",
            "Teal",
            "Cyan",
            "Sky",
            "Blue",
            "Purple",
            "Magenta",
            "Fushia",
            "Gray",
            "DarkGray",
            "RaInBoW"});
            this.ColorPick.Location = new System.Drawing.Point(246, 62);
            this.ColorPick.Name = "ColorPick";
            this.ColorPick.Size = new System.Drawing.Size(86, 21);
            this.ColorPick.TabIndex = 16;
            this.ColorPick.SelectedIndexChanged += new System.EventHandler(this.ColorPick_SelectedIndexChanged);
            // 
            // ColorPickedLabel
            // 
            this.ColorPickedLabel.AutoSize = true;
            this.ColorPickedLabel.BackColor = System.Drawing.Color.White;
            this.ColorPickedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPickedLabel.Location = new System.Drawing.Point(350, 62);
            this.ColorPickedLabel.Name = "ColorPickedLabel";
            this.ColorPickedLabel.Size = new System.Drawing.Size(18, 15);
            this.ColorPickedLabel.TabIndex = 17;
            this.ColorPickedLabel.Text = "   ";
            // 
            // PxUpDown
            // 
            this.PxUpDown.Location = new System.Drawing.Point(338, 28);
            this.PxUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.PxUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PxUpDown.Name = "PxUpDown";
            this.PxUpDown.Size = new System.Drawing.Size(44, 20);
            this.PxUpDown.TabIndex = 18;
            this.PxUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // labelDebug
            // 
            this.labelDebug.AutoSize = true;
            this.labelDebug.Location = new System.Drawing.Point(246, 127);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(29, 13);
            this.labelDebug.TabIndex = 19;
            this.labelDebug.Text = "false";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 461);
            this.Controls.Add(this.labelDebug);
            this.Controls.Add(this.PxUpDown);
            this.Controls.Add(this.ColorPickedLabel);
            this.Controls.Add(this.ColorPick);
            this.Controls.Add(this.Deconnexion);
            this.Controls.Add(this.SquareBrush);
            this.Controls.Add(this.RoundBrush);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.PseudoBox);
            this.Controls.Add(this.PseudoLabel);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.PortNum);
            this.Controls.Add(this.IpLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.IPTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Connexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PortNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PxUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connexion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.NumericUpDown PortNum;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label PseudoLabel;
        private System.Windows.Forms.TextBox PseudoBox;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Button RoundBrush;
        private System.Windows.Forms.Button SquareBrush;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Deconnexion;
        private System.Windows.Forms.ComboBox ColorPick;
        private System.Windows.Forms.Label ColorPickedLabel;
        private System.Windows.Forms.NumericUpDown PxUpDown;
        private System.Windows.Forms.Label labelDebug;
    }
}

