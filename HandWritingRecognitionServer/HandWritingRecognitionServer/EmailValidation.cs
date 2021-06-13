using System;
using System.Net;
using System.Net.Mail;

namespace HandWritingRecognitionServer
{
    class EmailValidation
    {
        private string userEmail;//email from user
        private string randomCode;// random code used for varificition
        private string senderEmail = "cyberprojectph@gmail.com";
        public EmailValidation(string userEmail)
        {
            Random rnd = new Random();
            randomCode = rnd.Next(100000, 999999).ToString();
            this.userEmail = userEmail;
        }

        public string GetRandomCode()
        {
            return randomCode;
        }
        public void SendValidationCode()
        {
            try
            {
                MailMessage mm = new MailMessage(senderEmail, userEmail);
                mm.Subject = "Authentication";
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
