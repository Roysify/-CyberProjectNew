using HandWritingRecognitionClient.Data;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace HandWritingRecognitionClient
{
    public partial class ForgotPassword : HandWritingRecognitionClient.ParentForm
    {
        private static string userEmail; //email from user
        private static string randomCode = ""; //random code used for varificition


        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void Send_BTN_Click(object sender, EventArgs e)
        /*
         creates connection and sends users email to server
        Arguments:
            winform defult
         Return:
            void
        */

        {
            if (EmailCheck())
            {
                try
                {
                    CreateTCPConnection();
                    Thread.Sleep(600); //sleeps to allow right flow of messaging
                    SendEmail(userEmail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        protected bool EmailCheck()
        /*
         checks email
        Arguments:
            none
         Return:
            bool
        */

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

        protected void SendEmail(string email)
        /*
         sends email to server
        Arguments:
            Email (string) - users email
         Return:
            void
        */

        {
            try
            {
                string message = "";
                NetworkStream ns = client.GetStream();
                message = CreateProtocol(email, PaintClientProtocolType.SendEmail);
                byte[] data = System.Text.Encoding.ASCII.GetBytes(rsa.Encrypt(message));
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Submit_Btn_Click(object sender, EventArgs e)
        /*
         opens reset password form
        Arguments:
            winform defult
         Return:
            void
        */

        {
            if (randomCode == Code_Box.Text)
            {
                ResetPassword rp = new ResetPassword(userEmail);
                this.Hide();
                rp.Show();
            }
        }

        private void Back_BTN_Click(object sender, EventArgs e)
        /*
         return to login form
        Arguments:
            winform defult
         Return:
            void
        */

        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();
        }
        public static void ValidateEmail()
        /*
         opens email validation form
        Arguments:
            none
         Return:
            void
        */

        {
            EmailValidation ev = new EmailValidation(userEmail);
            randomCode = ev.GetRandomCode();
            ev.SendResetCode();
        }
    }
}
