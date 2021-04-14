using HandWritingRecognitionClient.Data;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;


namespace HandWritingRecognitionClient
{
    public partial class PaintForm : HandWritingRecognitionClient.ParentForm
    {
        Point lastPoint = Point.Empty;//Point.Empty represents null for a Point object
        bool isMouseDown = new Boolean();//this is used to evaluate whether our mousebutton is down or not

        public PaintForm()
        {
            InitializeComponent();
        }

        private void Delete_BTN_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)

            {

                pictureBox1.Image = null;

                Invalidate();

            }

        }//earse the board

        private void button2_Click(object sender, EventArgs e)//send picture button press
        {
            SendMessage("picture", PaintClientProtocolType.SendPicture);
            Thread.Sleep(1000);
            SendPicture(ImageToByteArray(pictureBox1.Image));

        }

        private void SendPicture(byte[] pictureByte) //sends picture
        {
            try
            {
                // send message to the server
                NetworkStream ns = client.GetStream();
                //byte[] message = Combine(pictureByte, BitConverter.GetBytes(type));
                byte[] data = pictureByte;
                // send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
                //MessageBox.Show("Sent !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn) //image to byte array
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(imageIn, typeof(byte[]));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;//we assign the lastPoint to the current mouse position: e.Location ('e' is from the MouseEventArgs passed into the MouseDown event)

            isMouseDown = true;//we set to true because our mouse button is down (clicked)
        }//used to locate mouse movment

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

            lastPoint = Point.Empty;

            //set the previous point back to null if the user lets go of the mouse button

        }//used to locate mouse movment

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)//check to see if the mouse button is down

            {

                if (lastPoint != null)//if our last point is not null, which in this case we have assigned above

                {

                    if (pictureBox1.Image == null)//if no available bitmap exists on the picturebox to draw on

                    {
                        //create a new bitmap
                        Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

                        pictureBox1.Image = bmp; //assign the picturebox.Image property to the bitmap created

                    }

                    using (Graphics g = Graphics.FromImage(pictureBox1.Image))

                    {//we need to create a Graphics object to draw on the picture box, its our main tool

                        //when making a Pen object, you can just give it color only or give it color and pen size

                        g.DrawLine(new Pen(Color.Black, 2), lastPoint, e.Location);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        //this is to give the drawing a more smoother, less sharper look

                    }

                    pictureBox1.Invalidate();//refreshes the picturebox

                    lastPoint = e.Location;//keep assigning the lastPoint to the current mouse position

                }

            }

        }//used to locate mouse movment

        public void GotAResult(string result)
        {
            this.Invoke(new DelGotAResult(ShowResult), result);
        } //using delegate to show the result from server
        protected delegate void DelGotAResult(string result);

        public void ShowResult(string result) //shows result
        {
            ResultTxtBox.Text = result;
        }

    }
}
