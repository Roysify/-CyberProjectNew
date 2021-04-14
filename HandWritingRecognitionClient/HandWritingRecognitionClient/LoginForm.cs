using System;
using System.Windows.Forms;


namespace HandWritingRecognitionClient
{
    public partial class LoginForm : HandWritingRecognitionClient.ParentForm
    {
        public LoginForm() : base()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //logging in
        {
            if (FieldCheck())
            {
                try
                {
                    // connect to the server
                    if (!clientConnected)
                    {
                        CreateTCPConnection();
                    }
                    else
                    {
                        TryToConnect(Username_Box.Text, Password_Box.Text);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
                MessageBox.Show("Details are not viable");

        }

        private void Client_Login_FormClosed(object sender, FormClosedEventArgs e) //window closed
        {
            Application.Exit();

        }

        private void Registration_Btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword fp = new ForgotPassword();
            fp.Show();
        }
    }
}
