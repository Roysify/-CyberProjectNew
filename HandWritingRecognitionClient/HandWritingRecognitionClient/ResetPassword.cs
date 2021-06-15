using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HandWritingRecognitionClient
{
    public partial class ResetPassword : HandWritingRecognitionClient.ParentForm
    {
        bool first = false; //is it first click
        string email;//email from user

        public ResetPassword(string email)
        {
            this.email = email;
            InitializeComponent();
        }

        private void Send_BTN_Click(object sender, EventArgs e)
        /*
         creates connection and sends users password
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
                    if (!first) //first time clicking
                    {
                        CreateTCPConnection();
                        Thread.Sleep(800);//sleeps to allow right flow of messaging
                        first = true;
                        RenewPassword(Password_Box.Text,email);
                    }
                    else
                        RenewPassword(Password_Box.Text,email);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
                MessageBox.Show("username already exists");

        }
    }
}
