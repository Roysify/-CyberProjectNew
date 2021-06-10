using System;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;


namespace HandWritingRecognitionClient
{
    public partial class LoginForm : HandWritingRecognitionClient.ParentForm
    {
        public LoginForm() : base()
        {
            InitializeComponent();
            loadCaptchaImage();
        }
        private bool verified = false;
        private int number;

        private void button1_Click(object sender, EventArgs e) //logging in
        {
            if (accessGainCheck())
            {
                try
                {
                    // connect to the server
                    if (!clientConnected)
                    {
                        CreateTCPConnection();
                        Thread.Sleep(400);
                        TryToConnect(Username_Box.Text, Password_Box.Text);
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

        private void verBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == number.ToString())
            {
                verified = true;
                MessageBox.Show("verified");
            }
            else
            {
                verified = false;
                MessageBox.Show("invalid");
            }

        }
        private bool accessGainCheck()
        {
            if (verified)
            {

            }
            else
            {
                MessageBox.Show("Are you even human?");
                return false;
            }
            if (FieldCheck())
            {

            }
            else
            {
                MessageBox.Show("Details are not viable");
            }
            return true;
        }
        private void loadCaptchaImage()
        {
            Random r1 = new Random();
            number = r1.Next(100, 1000);
            var image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("TimesNewRoman", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(number.ToString(), font, Brushes.Green, new Point(0, 0));
            pictureBox1.Image = image;
        }

    }
}
