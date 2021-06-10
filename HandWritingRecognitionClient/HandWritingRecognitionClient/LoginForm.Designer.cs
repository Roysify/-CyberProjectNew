
namespace HandWritingRecognitionClient
{
    partial class LoginForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.Registration_Btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.verBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Password_Box
            // 
            this.Password_Box.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Password_Box.Text = "roei12345";
            // 
            // Username_Box
            // 
            this.Username_Box.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(227, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(14, 191);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Forgot Your Password ?";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Registration_Btn
            // 
            this.Registration_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Registration_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Registration_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Registration_Btn.ForeColor = System.Drawing.Color.White;
            this.Registration_Btn.Location = new System.Drawing.Point(201, 322);
            this.Registration_Btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Registration_Btn.Name = "Registration_Btn";
            this.Registration_Btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Registration_Btn.Size = new System.Drawing.Size(161, 27);
            this.Registration_Btn.TabIndex = 12;
            this.Registration_Btn.Text = "Create an account";
            this.Registration_Btn.UseVisualStyleBackColor = false;
            this.Registration_Btn.Click += new System.EventHandler(this.Registration_Btn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(113, 294);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // verBtn
            // 
            this.verBtn.BackColor = System.Drawing.Color.Salmon;
            this.verBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.verBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verBtn.ForeColor = System.Drawing.Color.White;
            this.verBtn.Location = new System.Drawing.Point(113, 252);
            this.verBtn.Margin = new System.Windows.Forms.Padding(2);
            this.verBtn.Name = "verBtn";
            this.verBtn.Size = new System.Drawing.Size(61, 23);
            this.verBtn.TabIndex = 16;
            this.verBtn.Text = "Verify";
            this.verBtn.UseVisualStyleBackColor = false;
            this.verBtn.Click += new System.EventHandler(this.verBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 228);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(232, 219);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 41);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.verBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Registration_Btn);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoginForm";
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.Registration_Btn, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.verBtn, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.Username_Box, 0);
            this.Controls.SetChildIndex(this.Password_Box, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Registration_Btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button verBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
