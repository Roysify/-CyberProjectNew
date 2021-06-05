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
        bool first = false;
        string email;//email from user

        public ResetPassword(string email)
        {
            this.email = email;
            InitializeComponent();
        }

        private void Send_BTN_Click(object sender, EventArgs e)
        {
            if (FieldCheck())
            {
                try
                {
                    if (!first) //בדיקה ראשונה שבה נוצר הקליינט
                    {
                        CreateTCPConnection();
                        Thread.Sleep(800);
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
