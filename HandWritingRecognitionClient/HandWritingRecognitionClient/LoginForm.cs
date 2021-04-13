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

        private void button1_Click(object sender, EventArgs e)
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
                MessageBox.Show("Bad");

        }

        private void Client_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

    }
}
