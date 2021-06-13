using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Linq;
using System.Net.Sockets;
using HandWritingRecognitionClient.Data;
using System.Net;
using System.Threading;

namespace HandWritingRecognitionClient
{
    public partial class ForgotPassword : HandWritingRecognitionClient.ParentForm
    {
        private static string userEmail;//email from user
        private static string randomCode = "";// random code used for varificition


        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void Send_BTN_Click(object sender, EventArgs e)//sends the email to the server
        {
            if (EmailCheck())
            {
                try
                {
                    CreateTCPConnection();
                    Thread.Sleep(600);
                    SendEmail(userEmail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        protected bool EmailCheck()
        {
            userEmail = Email_Box.Text;
            if (userEmail.Length > 4 && !userEmail.Contains('#'))
            {
                return true;
            }
            else
            {
                MessageBox.Show("email is not valid");
                return false;
            }
        }

        protected void SendEmail(string email) //send email
        {
            try
            {
                // send message to the server
                string message = "";
                NetworkStream ns = client.GetStream();
                message = CreateProtocol(email, PaintClientProtocolType.SendEmail);
                byte[] data = System.Text.Encoding.ASCII.GetBytes(rsa.Encrypt(message));
                // send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Submit_Btn_Click(object sender, EventArgs e)
        {
            if (randomCode == Code_Box.Text)
            {
                ResetPassword rp = new ResetPassword(userEmail);
                this.Hide();
                rp.Show();
            }
        }

        private void Back_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();
        }
        public static void ValidateEmail()
        {
            EmailValidation ev = new EmailValidation(userEmail);
            randomCode = ev.GetRandomCode();
            ev.SendResetCode();
        }
    }
}
