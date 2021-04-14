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
            this.Back_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(198, 9);
            this.label1.Size = new System.Drawing.Size(169, 27);
            this.label1.Text = "User Registration";
            // 
            // Confirm_Box
            // 
            this.Confirm_Box.Location = new System.Drawing.Point(113, 199);
            this.Confirm_Box.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Confirm_Box.Name = "Confirm_Box";
            this.Confirm_Box.PasswordChar = '*';
            this.Confirm_Box.Size = new System.Drawing.Size(114, 20);
            this.Confirm_Box.TabIndex = 12;
            this.Confirm_Box.Text = "123456";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(13, 195);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 40);
            this.label4.TabIndex = 11;
            this.label4.Text = "Confirm\r\nPassword";
            // 
            // Register_BTN
            // 
            this.Register_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Register_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_BTN.ForeColor = System.Drawing.Color.White;
            this.Register_BTN.Location = new System.Drawing.Point(113, 267);
            this.Register_BTN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Register_BTN.Name = "Register_BTN";
            this.Register_BTN.Size = new System.Drawing.Size(90, 27);
            this.Register_BTN.TabIndex = 10;
            this.Register_BTN.Text = "Register";
            this.Register_BTN.UseVisualStyleBackColor = false;
            this.Register_BTN.Click += new System.EventHandler(this.Register_BTN_Click);
            // 
            // Back_BTN
            // 
            this.Back_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Back_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Back_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back_BTN.ForeColor = System.Drawing.Color.White;
            this.Back_BTN.Location = new System.Drawing.Point(438, 322);
            this.Back_BTN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Back_BTN.Name = "Back_BTN";
            this.Back_BTN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Back_BTN.Size = new System.Drawing.Size(135, 27);
            this.Back_BTN.TabIndex = 13;
            this.Back_BTN.Text = "Back to login";
            this.Back_BTN.UseVisualStyleBackColor = false;
            this.Back_BTN.Click += new System.EventHandler(this.Back_BTN_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.Back_BTN);
            this.Controls.Add(this.Confirm_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Register_BTN);
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
            this.Controls.SetChildIndex(this.Back_BTN, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Confirm_Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Register_BTN;
        private System.Windows.Forms.Button Back_BTN;
    }
}