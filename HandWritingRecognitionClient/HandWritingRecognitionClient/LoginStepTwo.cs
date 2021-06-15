using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HandWritingRecognitionClient
{
    public partial class LoginStepTwo : HandWritingRecognitionClient.ParentForm
    {
        protected string emailCode = ""; //email authentication code received from user
        protected PaintForm pf; //used to transfer the paint form requierd info

        public LoginStepTwo(string emailCode,PaintForm pf)
        /*
         construction method that gets email code and paint form
        Arguments:
            emailCode (string) - email code found on users email
            pf (PaintForm) - used to transfer the paint form requierd info
        */
        {
            InitializeComponent();
            this.emailCode = emailCode;
            this.pf = pf;
        }

        private void emailCodeBtn_Click(object sender, EventArgs e)
        /*
         comparing users unput to original email code in order to gain access
        Arguments:
            winform defult
        return:
            void
        */
        {
            if (emailCode == emailCodeBox.Text)
            {
                this.Hide();
                pf.Show();
            }
            else
            {
                MessageBox.Show("verify yourself by code sent to your email");
            }
        }
    }
}
