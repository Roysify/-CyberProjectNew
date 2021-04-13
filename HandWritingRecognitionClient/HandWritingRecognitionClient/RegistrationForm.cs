using HandWritingRecognitionClient.Data;
using System;
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
        {
            if (FieldCheck())
            {
                try
                {
                    if (!first) //בדיקה ראשונה שבה נוצר הקליינט
                    {
                        CreateTCPConnection();
                    }
                    else
                        IsUsernameExists(Username_Box.Text);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
                MessageBox.Show("username already exists");

        }

        private void IsUsernameExists(string user)
        {
            SendMessage(user, PaintClientProtocolType.SendUsername);
        }

        private void Back_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm clientLogin = new LoginForm();
            clientLogin.Show();

        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
