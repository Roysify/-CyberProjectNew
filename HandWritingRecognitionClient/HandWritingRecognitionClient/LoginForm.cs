using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace HandWritingRecognitionClient
{
    public partial class LoginForm : HandWritingRecognitionClient.ParentForm
    {
        public LoginForm() : base()
        {
            InitializeComponent();
            loadCaptchaImage(); //loads cpatcha image
        }
        private bool captchaVerified = false; //has the client verified captcha
        private int captchaNumber; //random generated captcha number

        private void button1_Click(object sender, EventArgs e)
        /*
         creates connection and sends users email to server
        Arguments:
            winform defult
         Return:
            void
        */

        {
            if (accessGainCheck())
            {
                try
                {
                    // connect to the server
                    if (!clientConnected)
                    {
                        CreateTCPConnection();
                        Thread.Sleep(400); //sleeps to allow right flow of messaging
                        TryToConnect(Username_Box.Text, Password_Box.Text.GetHashCode().ToString());
                    }
                    else
                    {
                        TryToConnect(Username_Box.Text, Password_Box.Text.GetHashCode().ToString());
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Client_Login_FormClosed(object sender, FormClosedEventArgs e)
        /*
         Closes window
        Arguments:
            winform defult
         Return:
            void
        */
        {
            Application.Exit();
        }

        private void Registration_Btn_Click(object sender, EventArgs e)
        /*
         opens registration form
        Arguments:
            winform defult
         Return:
            void
        */
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        /*
         opens forgot password form
        Arguments:
            winform defult
         Return:
            void
        */
        {
            this.Hide();
            ForgotPassword fp = new ForgotPassword();
            fp.Show();
        }

        private void verBtn_Click(object sender, EventArgs e)
        /*
         comparing input numbers aginst captcha for validation
        Arguments:
            winform defult
         Return:
            void
        */
        {
            if (textBox1.Text == captchaNumber.ToString())
            {
                captchaVerified = true;
                verBtn.Text = "verified";
                verBtn.BackColor = Color.LightSeaGreen;
                verBtn.Enabled = false;
            }
            else
            {
                captchaVerified = false;
                MessageBox.Show("invalid");
            }

        }

        private bool accessGainCheck()
        /*
         evaluating access confirmation
        Arguments:
            none
         Return:
            bool
        */
        {
            if (captchaVerified)
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
                return false;
            }
            return true;
        }

        private void loadCaptchaImage()
        /*
         loads captcha image
        Arguments:
            none
         Return:
            void
        */
        {
            Random r1 = new Random();
            captchaNumber = r1.Next(100, 1000);
            var image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("TimesNewRoman", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(captchaNumber.ToString(), font, Brushes.Green, new Point(0, 0));
            pictureBox1.Image = image;
        }


    }
}
