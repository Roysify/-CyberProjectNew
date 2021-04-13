using HandWritingRecognitionClient.Data;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;

namespace HandWritingRecognitionClient
{
    public partial class ParentForm : Form
    {
        protected int portNo = 500;
        protected string ipAddress = "127.0.0.1";
        protected static TcpClient client;
        protected byte[] data;
        protected bool gotPublicKey = false;
        protected string messageReceived = "";
        protected bool clientConnected = false;
        protected static RSA rsa;
        PaintForm pf;

        public ParentForm()
        {
            InitializeComponent();

        }

        protected void SendMessage(string message, int type)
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
                MessageBox.Show(ex.ToString());
            }
        }

        protected void SendPublicKey(string message, int type)
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
        {
            return type + "#" + msg;
        }

        protected void ReceiveMessage(IAsyncResult ar)
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
        {
            rsa = new RSA();
            client = new TcpClient();
            client.Connect(ipAddress, portNo);
            clientConnected = true;

            data = new byte[client.ReceiveBufferSize];

            SendPublicKey(rsa.GetPublicKey(), PaintClientProtocolType.SendPublicKey);

            client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client.ReceiveBufferSize), ReceiveMessage, null);

        }

        private void ReadProtocol(string msg)
        {
            string[] str = msg.Split('#'); //num 1st, info 2nd
            int num = int.Parse(str[0]);
            switch (num)
            {
                case PaintClientProtocolType.ErvrorInvalidPasswordAndUsername:
                    this.Invoke(new IncorrectDetails(SetsignedInVisibleMode), true);
                    break;

                case PaintClientProtocolType.OkValidPasswordAndUsername:

                    this.Invoke(new DelSuccessfullyLoggedIn(SuccessfullyLoggedIn));
                    this.Invoke(new IncorrectDetails(SetsignedInVisibleMode), false);
                    break;

                case PaintClientProtocolType.SendPublicKey:
                    rsa.setOtherPublicKey(str[1]);
                    gotPublicKey = true;
                    TryToConnect(Username_Box.Text, Password_Box.Text);
                    break;

                case PaintClientProtocolType.SendMessage:
                    //this.Invoke(new delUpdateHistory(UpdateHistory), str[1]);
                    break;
                case PaintClientProtocolType.result:
                    pf.GotAResult(str[1]);
                    break;
                default:

                    break;


            }
        }

        protected bool FieldCheck()
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


        protected void TryToConnect(string username, string password)
        {
            SendMessage(username + "#" + password, PaintClientProtocolType.SendDetails);
        }

        protected delegate void DelSuccessfullyLoggedIn();
        protected void SuccessfullyLoggedIn()
        {
            this.Hide();
            pf = new PaintForm();
            pf.Show();

        }

        protected delegate void IncorrectDetails(bool visible_mode);
        protected void SetsignedInVisibleMode(bool visible_mode)
        {
            //user_and_pass_inc.Visible = visible_mode;
        }

    }
}
