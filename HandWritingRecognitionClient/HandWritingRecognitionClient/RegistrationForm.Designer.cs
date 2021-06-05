﻿
namespace HandWritingRecognitionClient
{
    partial class RegistrationForm
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
            this.Confirm_Box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Register_BTN = new System.Windows.Forms.Button();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Password_Box
            // 
            this.Password_Box.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.Password_Box.Text = "123456";
            // 
            // Username_Box
            // 
            this.Username_Box.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.Username_Box.Text = "123456";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(297, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Size = new System.Drawing.Size(256, 41);
            this.label1.Text = "User Registration";
            // 
            // Confirm_Box
            // 
            this.Confirm_Box.Location = new System.Drawing.Point(170, 306);
            this.Confirm_Box.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Confirm_Box.Name = "Confirm_Box";
            this.Confirm_Box.PasswordChar = '*';
            this.Confirm_Box.Size = new System.Drawing.Size(169, 26);
            this.Confirm_Box.TabIndex = 12;
            this.Confirm_Box.Text = "123456";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(20, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 58);
            this.label4.TabIndex = 11;
            this.label4.Text = "Confirm\r\nPassword";
            // 
            // Register_BTN
            // 
            this.Register_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Register_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_BTN.ForeColor = System.Drawing.Color.White;
            this.Register_BTN.Location = new System.Drawing.Point(170, 465);
            this.Register_BTN.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Register_BTN.Name = "Register_BTN";
            this.Register_BTN.Size = new System.Drawing.Size(135, 42);
            this.Register_BTN.TabIndex = 10;
            this.Register_BTN.Text = "Register";
            this.Register_BTN.UseVisualStyleBackColor = false;
            this.Register_BTN.Click += new System.EventHandler(this.Register_BTN_Click);
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(170, 392);
            this.EmailBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(208, 26);
            this.EmailBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(20, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "Email";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(758, 495);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 42);
            this.button1.TabIndex = 16;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(876, 555);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Confirm_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Register_BTN);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "RegistrationForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistrationForm_FormClosed);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.Username_Box, 0);
            this.Controls.SetChildIndex(this.Password_Box, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.Register_BTN, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.Confirm_Box, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.EmailBox, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Confirm_Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Register_BTN;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}
