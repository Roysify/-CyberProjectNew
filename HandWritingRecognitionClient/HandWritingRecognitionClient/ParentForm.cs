using HandWritingRecognitionClient.Data;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace HandWritingRecognitionClient
{
    public partial class ParentForm : Form
    {
        protected int portNo = 500; //port number used for transaction
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

        protected void SendPublicKey(string message, int type)
        /*
             Sends public key from client to server
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

        protected string CreateProtocol(string msg, int type)
        /*
             combines message with type to one string by protocol
            Arguments:
                msg (string) - message
                type (int) - type of message
             Return:
                string
        */
        {
            return type + "#" + msg;
        }

        protected void ReceiveMessage(IAsyncResult ar)
        /*
             receives message from server
            Arguments:
                IAsyncResult (interface) - Represents the status of an asynchronous operation
             Return:
                void
        */
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

        protected void CreateTCPConnection()
        /*
             creates connection using the TCP client object
            Arguments:
                none
             Return:
                void
        */
        {
            try
            {
                ipAddress = GetLocalIPAddress();
                rsa = new RSA();
                client = new TcpClient();
                client.Connect(ipAddress, portNo);
                clientConnected = true;

                data = new byte[client.ReceiveBufferSize];

                SendPublicKey(rsa.GetPublicKey(), PaintClientProtocolType.SendPublicKey);

                client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client.ReceiveBufferSize), ReceiveMessage, null);
            }
            catch (Exception)
            {

                MessageBox.Show("could not find server");
            }
        }

        private void ReadProtocol(string messageFromServer)
        /*
             Gets the message that was transferred from server and splits it to get valuable info
            Arguments:
                messageFromServer (string) - exact string that was sent by the server
             Return:
                void
        */
        {
            string[] str = messageFromServer.Split('#'); //splits the string into an array: num 1st, info 2nd...
            int num = int.Parse(str[0]); //getting the number which states about the content of the msg
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

                case PaintClientProtocolType.IncorrectEmailCode:
                    MessageBox.Show("Code is incorrect.");
                    break;

                default:

                    break;
            }
        }

        protected bool FieldCheck()
        /*
             calls password and username check methods in order to confirm valid details
            Arguments:
                none
             Return:
                bool
        */
        {
            return PasswordCheck() && UsernameCheck();
        }
        protected bool PasswordCheck()
        /*
             Checks password
            Arguments:
                none
             Return:
                bool
        */
        {
            string pass = Password_Box.Text;
            return pass.Length > 4 && !pass.Contains('#');
        }
        protected bool UsernameCheck()
        /*
             Checks username
            Arguments:
                none
             Return:
                bool
        */
        {
            string usr = Username_Box.Text;
            return usr.Length > 4 && !usr.Contains('#');
        }


        protected void TryToConnect(string username, string password)
        /*
             Sends message contains username and password in order to log in
            Arguments:
                username (string) - username
                password (string) - password
             Return:
                void
        */
        {
            SendMessage(username + "#" + password, PaintClientProtocolType.SendDetails);
        }

        protected delegate void DelSuccessfullyLoggedIn(); //delegate
        protected void SuccessfullyLoggedIn()
        /*
             opens paint form
            Arguments:
                none
             Return:
                void
        */
        {
            this.Hide();
            pf = new PaintForm();
            pf.Show();

        }

        protected delegate void DelSuccessfullyRegistered(); //deleagte
        private void SuccessfullyRegistered()
        /*
             opens login form
            Arguments:
                none
             Return:
                void
        */
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();
        }


        protected delegate void DelEmailExists(); //delegate
        private void EmailExists()
        /*
             In case email exists, call for email validation method
            Arguments:
                none
             Return:
                void
        */
        {
            ForgotPassword.ValidateEmail();
        }

        protected delegate void DelLoginStepTwo(string emailCode);
        /*
             delegate
            Arguments:
                emailCode (string) - email authentication code received from server
             Return:
                void
        */
        private void LoginStepTwo(string emailCode)
        /*
             opens login step two form
            Arguments:
                none
             Return:
                void
        */
        {
            this.Hide();
            LoginStepTwo lst = new LoginStepTwo(emailCode, pf);
            lst.Show();
        }


        protected void RenewPassword(string password, string email)
        /*
             sends new password in form of hash code to server 
            Arguments:
                password (string) - users password
                email (string) - users email used to identify user
             Return:
                void
        */
        {
            SendMessage(password.GetHashCode() + '#' + email, PaintClientProtocolType.SendPassword);
        }

        public static string GetLocalIPAddress()
        /*
             gets local ip address
            Arguments:
                none
             Return:
                ip addres (string)
        */
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
}
