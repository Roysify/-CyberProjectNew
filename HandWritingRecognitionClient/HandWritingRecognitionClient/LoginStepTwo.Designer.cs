
namespace HandWritingRecognitionClient
{
    partial class LoginStepTwo
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
            this.emailCodeBtn = new System.Windows.Forms.Button();
            this.emailCodeBox = new System.Windows.Forms.TextBox();
            this.emailCodeLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Password_Box
            // 
            this.Password_Box.Location = new System.Drawing.Point(450, 149);
            this.Password_Box.Visible = false;
            // 
            // Username_Box
            // 
            this.Username_Box.Location = new System.Drawing.Point(450, 99);
            this.Username_Box.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(350, 147);
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(350, 98);
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(103, 27);
            this.label1.Text = "Safe Login";
            // 
            // emailCodeBtn
            // 
            this.emailCodeBtn.BackColor = System.Drawing.Color.Salmon;
            this.emailCodeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.emailCodeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailCodeBtn.ForeColor = System.Drawing.Color.White;
            this.emailCodeBtn.Location = new System.Drawing.Point(138, 174);
            this.emailCodeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.emailCodeBtn.Name = "emailCodeBtn";
            this.emailCodeBtn.Size = new System.Drawing.Size(63, 23);
            this.emailCodeBtn.TabIndex = 23;
            this.emailCodeBtn.Text = "Send";
            this.emailCodeBtn.UseVisualStyleBackColor = false;
            this.emailCodeBtn.Click += new System.EventHandler(this.emailCodeBtn_Click);
            // 
            // emailCodeBox
            // 
            this.emailCodeBox.Location = new System.Drawing.Point(138, 149);
            this.emailCodeBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.emailCodeBox.Name = "emailCodeBox";
            this.emailCodeBox.Size = new System.Drawing.Size(114, 20);
            this.emailCodeBox.TabIndex = 22;
            // 
            // emailCodeLable
            // 
            this.emailCodeLable.AutoSize = true;
            this.emailCodeLable.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailCodeLable.ForeColor = System.Drawing.Color.Gainsboro;
            this.emailCodeLable.Location = new System.Drawing.Point(38, 149);
            this.emailCodeLable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailCodeLable.Name = "emailCodeLable";
            this.emailCodeLable.Size = new System.Drawing.Size(80, 20);
            this.emailCodeLable.TabIndex = 21;
            this.emailCodeLable.Text = "Email Code";
            // 
            // LoginStepTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.emailCodeBtn);
            this.Controls.Add(this.emailCodeBox);
            this.Controls.Add(this.emailCodeLable);
            this.Name = "LoginStepTwo";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.Username_Box, 0);
            this.Controls.SetChildIndex(this.Password_Box, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.emailCodeLable, 0);
            this.Controls.SetChildIndex(this.emailCodeBox, 0);
            this.Controls.SetChildIndex(this.emailCodeBtn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button emailCodeBtn;
        private System.Windows.Forms.TextBox emailCodeBox;
        private System.Windows.Forms.Label emailCodeLable;
    }
}
