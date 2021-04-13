
namespace HandWritingRecognitionClient
{
    partial class ForgotPassword
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
            this.Submit_Btn = new System.Windows.Forms.Button();
            this.Send_BTN = new System.Windows.Forms.Button();
            this.Code_Box = new System.Windows.Forms.TextBox();
            this.Email_Box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Password_Box
            // 
            this.Password_Box.Location = new System.Drawing.Point(441, 147);
            // 
            // Username_Box
            // 
            this.Username_Box.Location = new System.Drawing.Point(441, 97);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(341, 145);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(341, 96);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(196, 9);
            this.label1.Size = new System.Drawing.Size(160, 27);
            this.label1.Text = "Forgot Password";
            // 
            // Submit_Btn
            // 
            this.Submit_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Submit_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Submit_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit_Btn.ForeColor = System.Drawing.Color.White;
            this.Submit_Btn.Location = new System.Drawing.Point(15, 289);
            this.Submit_Btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Submit_Btn.Name = "Submit_Btn";
            this.Submit_Btn.Size = new System.Drawing.Size(73, 27);
            this.Submit_Btn.TabIndex = 17;
            this.Submit_Btn.Text = "Submit";
            this.Submit_Btn.UseVisualStyleBackColor = false;
            // 
            // Send_BTN
            // 
            this.Send_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Send_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Send_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_BTN.ForeColor = System.Drawing.Color.White;
            this.Send_BTN.Location = new System.Drawing.Point(15, 146);
            this.Send_BTN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Send_BTN.Name = "Send_BTN";
            this.Send_BTN.Size = new System.Drawing.Size(73, 27);
            this.Send_BTN.TabIndex = 16;
            this.Send_BTN.Text = "Send";
            this.Send_BTN.UseVisualStyleBackColor = false;
            this.Send_BTN.Click += new System.EventHandler(this.Send_BTN_Click);
            // 
            // Code_Box
            // 
            this.Code_Box.Location = new System.Drawing.Point(111, 236);
            this.Code_Box.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Code_Box.Name = "Code_Box";
            this.Code_Box.PasswordChar = '*';
            this.Code_Box.Size = new System.Drawing.Size(114, 20);
            this.Code_Box.TabIndex = 15;
            // 
            // Email_Box
            // 
            this.Email_Box.Location = new System.Drawing.Point(111, 96);
            this.Email_Box.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Email_Box.Name = "Email_Box";
            this.Email_Box.Size = new System.Drawing.Size(114, 20);
            this.Email_Box.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(11, 233);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(11, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Email";
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.Submit_Btn);
            this.Controls.Add(this.Send_BTN);
            this.Controls.Add(this.Code_Box);
            this.Controls.Add(this.Email_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Name = "ForgotPassword";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.Username_Box, 0);
            this.Controls.SetChildIndex(this.Password_Box, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.Email_Box, 0);
            this.Controls.SetChildIndex(this.Code_Box, 0);
            this.Controls.SetChildIndex(this.Send_BTN, 0);
            this.Controls.SetChildIndex(this.Submit_Btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Submit_Btn;
        private System.Windows.Forms.Button Send_BTN;
        private System.Windows.Forms.TextBox Code_Box;
        private System.Windows.Forms.TextBox Email_Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
