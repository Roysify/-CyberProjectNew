using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Linq;
using System.Net.Sockets;
using HandWritingRecognitionClient.Data;
using System.Net;

namespace HandWritingRecognitionClient
{
    public partial class ForgotPassword : HandWritingRecognitionClient.ParentForm
    {
        string email;//email from user
        string randomCode;// random code used for varificition

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void Send_BTN_Click(object sender, EventArgs e)//sends the email to the server
        {
            if (EmailCheck())
            {
                email = Email_Box.Text;
                try
                {
                    CreateTCPConnection();
                    SendEmail(email);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            }
            else
            {
                MessageBox.Show("email is not valid");
            }

        }
        protected bool EmailCheck()
        {
            string usr = Email_Box.Text;
            return usr.Length > 4 && !usr.Contains('#');
        }
        protected void SendEmail(string email) //send email
        {
            try
            {
                // send message to the server
                string message = "";
                NetworkStream ns = client.GetStream();
                message = CreateProtocol(email,PaintClientProtocolType.SendEmail);
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
        public void EmailExits()
        {
            string from, pass, messageBody;
            Random rnd = new Random();
            randomCode = rnd.Next(100000, 999999).ToString();
            MailMessage message = new MailMessage();
            from = "csemailsndr@gmail.com";
            pass = "tsntest123";
            messageBody = "your reset code is " + randomCode;
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "password reseting code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("code was sent");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Submit_Btn_Click(object sender, EventArgs e)
        {
            if(randomCode==Code_Box.ToString())
            {
                //missing
            }
        }
    }
}
