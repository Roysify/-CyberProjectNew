
namespace HandWritingRecognitionClient
{
    partial class PaintForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Delete_BTN = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ResultTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Password_Box
            // 
            this.Password_Box.Visible = false;
            // 
            // Username_Box
            // 
            this.Username_Box.Visible = false;
            // 
            // label3
            // 
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(190, 9);
            this.label1.Size = new System.Drawing.Size(189, 27);
            this.label1.Text = "Write to get a result";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(11, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(477, 270);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Delete_BTN
            // 
            this.Delete_BTN.Location = new System.Drawing.Point(515, 195);
            this.Delete_BTN.Margin = new System.Windows.Forms.Padding(2);
            this.Delete_BTN.Name = "Delete_BTN";
            this.Delete_BTN.Size = new System.Drawing.Size(68, 29);
            this.Delete_BTN.TabIndex = 12;
            this.Delete_BTN.Text = "Delete";
            this.Delete_BTN.UseVisualStyleBackColor = true;
            this.Delete_BTN.Click += new System.EventHandler(this.Delete_BTN_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(515, 162);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 29);
            this.button2.TabIndex = 11;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ResultTxtBox
            // 
            this.ResultTxtBox.Location = new System.Drawing.Point(67, 335);
            this.ResultTxtBox.Name = "ResultTxtBox";
            this.ResultTxtBox.Size = new System.Drawing.Size(121, 20);
            this.ResultTxtBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(11, 335);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Result";
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ResultTxtBox);
            this.Controls.Add(this.Delete_BTN);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PaintForm";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.Username_Box, 0);
            this.Controls.SetChildIndex(this.Password_Box, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.Delete_BTN, 0);
            this.Controls.SetChildIndex(this.ResultTxtBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Delete_BTN;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox ResultTxtBox;
        private System.Windows.Forms.Label label4;
    }
}
