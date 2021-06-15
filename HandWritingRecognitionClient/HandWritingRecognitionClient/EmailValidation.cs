using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace HandWritingRecognitionClient
{
    class EmailValidation
    {
        private string userEmail; //email from user
        private string randomCode; // random code used for varificition
        private string senderEmail = "cyberprojectph@gmail.com"; //sender email
        public EmailValidation(string userEmail)
        /*
         construction method that gets clients email and generates a random code
        Arguments:
            userEmail (string) - users email used to send the random code
         Return:
            void
        */
        {
            Random rnd = new Random();
            randomCode = rnd.Next(100000, 999999).ToString();
            this.userEmail = userEmail;
        }

        public string GetRandomCode()
        /*
         gets random code
        Arguments:
            none
         Return:
            random code (string)
        */

        {
            return randomCode;
        }

        public void SendResetCode()
        /*
         sends user random code used for varification
        Arguments:
            none
         Return:
            void
        */

        {
            try
            {
                MailMessage mm = new MailMessage(senderEmail, userEmail);
                mm.Subject = "Password Recovery";
                mm.Body = string.Format($"Random code: {randomCode}");
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "cyberprojectph@gmail.com";
                NetworkCred.Password = "cyberp12345";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                MessageBox.Show("Confirmation code was sent to your email");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
