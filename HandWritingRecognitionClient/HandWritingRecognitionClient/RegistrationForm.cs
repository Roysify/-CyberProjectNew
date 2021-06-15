using HandWritingRecognitionClient.Data;
using System;
using System.Threading;
using System.Windows.Forms;


namespace HandWritingRecognitionClient
{
    public partial class RegistrationForm : HandWritingRecognitionClient.ParentForm
    {
        bool first = false;


        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void Register_BTN_Click(object sender, EventArgs e)
            /*
         creates connection and sends users details to server
        Arguments:
            winform defult
         Return:
            void
        */
        {
            if (FieldCheck())
            {
                try
                {
                    if (!first) //בדיקה ראשונה שבה נוצר הקליינט
                    {
                        CreateTCPConnection();
                        Thread.Sleep(400); //sleeps to allow right flow of messaging
                        first = true;
                        Register(Username_Box.Text, Password_Box.Text.GetHashCode().ToString(), EmailBox.Text);
                    }
                    else
                        Register(Username_Box.Text, Password_Box.Text.GetHashCode().ToString(), EmailBox.Text);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
                MessageBox.Show("details are unavailable");

        }

        private void Register(string user, string password, string email)
        {
            SendMessage(user + "#" + password + "#" + email, PaintClientProtocolType.Register);
        }//sends message to the server with username from user

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        /*
         closes application
        Arguments:
            winform defult
         Return:
            void
        */
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        /*
        return to login form
       Arguments:
           winform defult
        Return:
           void
       */
        {
            this.Hide();
            LoginForm clientLogin = new LoginForm();
            clientLogin.Show();
        }
    }
}
