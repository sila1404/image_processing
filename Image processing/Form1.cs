namespace Image_processing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap srcBitmap = new Bitmap(pictureBox1.Image);
            for (int x = 0; x < 120; x++)
            {
                srcBitmap.SetPixel(x, x, Color.Red);
            }
            pictureBox1.Image = srcBitmap;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            if (bmp != null)
            {
                int x = e.X;
                int y = e.Y;

                if (x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
                {
                    Color clr = bmp.GetPixel(x, y);
                    label1.Text = "R: " + clr.R.ToString();
                    label2.Text = "G: " + clr.G.ToString();
                    label3.Text = "B: " + clr.B.ToString();
                }
            }
        }

        public Bitmap ConvertToGray(Bitmap source)
        {
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            for(int x =0; x < source.Width; x++ )
            {
                for(int y = 0; y < source.Height; y++)
                {
                    Color clr = source.GetPixel(x, y);
                    int avg = (clr.R + clr.G + clr.B) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }

            return bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);

            pictureBox2.Image = ConvertToGray(bmp);

        }
    }
}