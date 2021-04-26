
namespace HandWritingRecognitionClient
{
    partial class ResetPassword
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
            this.Send_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Password_Box
            // 
            this.Password_Box.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            // 
            // Username_Box
            // 
            this.Username_Box.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            // 
            // label3
            // 
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Size = new System.Drawing.Size(73, 40);
            this.label3.Text = "Confirm\r\nPassword";
            // 
            // label2
            // 
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "Password";
            // 
            // Send_BTN
            // 
            this.Send_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Send_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Send_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_BTN.ForeColor = System.Drawing.Color.White;
            this.Send_BTN.Location = new System.Drawing.Point(113, 211);
            this.Send_BTN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Send_BTN.Name = "Send_BTN";
            this.Send_BTN.Size = new System.Drawing.Size(73, 27);
            this.Send_BTN.TabIndex = 17;
            this.Send_BTN.Text = "Send";
            this.Send_BTN.UseVisualStyleBackColor = false;
            this.Send_BTN.Click += new System.EventHandler(this.Send_BTN_Click);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.Send_BTN);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ResetPassword";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.Username_Box, 0);
            this.Controls.SetChildIndex(this.Password_Box, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.Send_BTN, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Send_BTN;
    }
}
