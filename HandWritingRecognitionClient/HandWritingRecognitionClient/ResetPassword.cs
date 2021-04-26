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
        public ResetPassword()
        {
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
                        SendPassword(Password_Box.Text);
                    }
                    else
                        SendPassword(Password_Box.Text);


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
