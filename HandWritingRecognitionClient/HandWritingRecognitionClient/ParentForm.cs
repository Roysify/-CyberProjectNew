using HandWritingRecognitionClient.Data;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;

namespace HandWritingRecognitionClient
{
    public partial class ParentForm : Form
    {
        protected int portNo = 500; //port number
        protected string ipAddress = "127.0.0.1";//ip address
        protected static TcpClient client;//tcp client
        protected byte[] data;//conatains the transferd data
        protected bool gotPublicKey = false; //has gotten public key from server yet
        protected string messageReceived = "";//string of message received
        protected bool clientConnected = false;//connection been estublished
        protected static RSA rsa; //used for encryption and decryption
        PaintForm pf; //used to transfer the paint form requierd info

        public ParentForm()
        {
            InitializeComponent();

        }

        protected void SendMessage(string message, int type)
        /*
             Sends message from client to server
            Arguments:
                message (string) - message content
                type (int) - type of message
             Return:
                void
        */
        {
            try
            {
                // send message to the server
                NetworkStream ns = client.GetStream();
                message = CreateProtocol(message, type);
                byte[] data = System.Text.Encoding.ASCII.GetBytes(rsa.Encrypt(message));
                // send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void SendPublicKey(string message, int type) //sends public key
        {
            try
            {
                // send message to the server
                NetworkStream ns = client.GetStream();
                message = CreateProtocol(message, type);
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                // send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected string CreateProtocol(string msg, int type) //creats protocol
        {
            return type + "#" + msg;
        }

        protected void ReceiveMessage(IAsyncResult ar) //receives messages
        {
            try
            {
                int bytesRead;

                // read the data from the server
                bytesRead = client.GetStream().EndRead(ar);

                if (bytesRead < 1)
                {
                    return;
                }
                else
                {
                    // invoke the delegate to display the recived data
                    if (!gotPublicKey)
                    {
                        messageReceived = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                    }
                    else
                    {
                        messageReceived = rsa.Decrypt(System.Text.Encoding.ASCII.GetString(data, 0, bytesRead));

                    }
                    ReadProtocol(messageReceived);

                }

                // continue reading
                client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client.ReceiveBufferSize), ReceiveMessage, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void CreateTCPConnection()//creates connection using the tcp client object
        {
            try
            {
                rsa = new RSA();
                client = new TcpClient();
                client.Connect(ipAddress, portNo);
                clientConnected = true;

                data = new byte[client.ReceiveBufferSize];

                SendPublicKey(rsa.GetPublicKey(), PaintClientProtocolType.SendPublicKey);

                client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client.ReceiveBufferSize), ReceiveMessage, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show("could not find server");
            }
        }

        private void ReadProtocol(string msg) //used to locate the right place for the message
        {
            string[] str = msg.Split('#'); //num 1st, info 2nd
            int num = int.Parse(str[0]);
            switch (num)
            {
                case PaintClientProtocolType.ErvrorInvalidPasswordAndUsername:
                    MessageBox.Show("Incorrect details");
                    break;

                case PaintClientProtocolType.OkValidPasswordAndUsername:
                    string emailCode = str[1];
                    pf = new PaintForm();
                    this.Invoke(new DelLoginStepTwo(LoginStepTwo), emailCode);
                    break;

                case PaintClientProtocolType.SendPublicKey:
                    rsa.setOtherPublicKey(str[1]);
                    gotPublicKey = true;
                    break;

                case PaintClientProtocolType.SendMessage:
                    //this.Invoke(new delUpdateHistory(UpdateHistory), str[1]);
                    break;
                case PaintClientProtocolType.Result:
                    pf.GotAResult(str[1]);
                    break;
                case PaintClientProtocolType.UsernameOrEmailUnavailable:
                    MessageBox.Show("Username or email are unavailable. Try something else.");
                    break;
                case PaintClientProtocolType.UserAdded:
                    MessageBox.Show("Registered");
                    this.Invoke(new DelSuccessfullyRegistered(SuccessfullyRegistered));
                    break;
                case PaintClientProtocolType.PasswordChanged:
                    MessageBox.Show("Password Changed");
                    this.Invoke(new DelSuccessfullyRegistered(SuccessfullyRegistered));
                    break;
                case PaintClientProtocolType.EmailExists:
                    this.Invoke(new DelEmailExists(EmailExists));
                    break;
                case PaintClientProtocolType.CorrectEmailCode:
                    //this.Invoke(new DelSuccessfullyLoggedIn(SuccessfullyLoggedIn));

                    break;
                case PaintClientProtocolType.IncorrectEmailCode:
                    MessageBox.Show("Code is incorrect.");
                    break;


                default:

                    break;


            }
        }

        protected bool FieldCheck() //cheacks password and username length and such
        {
            return PasswordCheck() && UsernameCheck();
        }
        protected bool PasswordCheck()
        {
            string pass = Password_Box.Text;
            return pass.Length > 4 && !pass.Contains('#');
        }
        protected bool UsernameCheck()
        {
            string usr = Username_Box.Text;
            return usr.Length > 4 && !usr.Contains('#');
        }


        protected void TryToConnect(string username, string password) //sends message with username and password from client
        {
            SendMessage(username + "#" + password, PaintClientProtocolType.SendDetails);
        }

        protected delegate void DelSuccessfullyLoggedIn();
        protected void SuccessfullyLoggedIn() //in case of a successful log in
        {
            this.Hide();
            pf = new PaintForm();
            pf.Show();

        }

        protected delegate void DelSuccessfullyRegistered();
        private void SuccessfullyRegistered()
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();
        }

        protected delegate void DelEmailExists();
        private void EmailExists()
        {
            ForgotPassword.ValidateEmail();
        }

        protected delegate void DelLoginStepTwo(string emailCode);
        private void LoginStepTwo(string emailCode)
        {
            this.Hide();
            LoginStepTwo lst = new LoginStepTwo(emailCode,pf);
            lst.Show();
        }


        protected void RenewPassword(string password, string email)
        {
            SendMessage(password.GetHashCode() + '#' + email, PaintClientProtocolType.SendPassword);
        }
    }
}
