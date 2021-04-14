using System;
using System.Windows.Forms;

namespace HandWritingRecognitionClient
{
    public partial class ForgotPassword : HandWritingRecognitionClient.ParentForm
    {
        string email = "";//email from user
        string randomCode;// random code used for varificition

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void Send_BTN_Click(object sender, EventArgs e)//sends the email to the server
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
