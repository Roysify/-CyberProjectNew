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
        protected string emailCode = "";
        protected PaintForm pf;
        public LoginStepTwo(string emailCode,PaintForm pf)
        {
            InitializeComponent();
            this.emailCode = emailCode;
            this.pf = pf;
        }

        private void emailCodeBtn_Click(object sender, EventArgs e)
        {
            if (emailCode == emailCodeBox.Text)
            {
                //this.Invoke(new DelSuccessfullyLoggedIn(SuccessfullyLoggedIn));
                //SuccessfullyLoggedIn();
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
