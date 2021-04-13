using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HandWritingRecognitionClient
{
    public partial class ForgotPassword : HandWritingRecognitionClient.ParentForm
    {
        string email = "";
        string randomCode;

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void Send_BTN_Click(object sender, EventArgs e)
        {
            if (Email_Box.Text != null)
            {
                email = Email_Box.Text;
                try
                {
                    CreateTCPConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    MessageBox.Show("Please enter your Email.");

                }

            }
            else
            {
                //TryToConnect(Email_Box.Text);
            }

        }
    }
}
