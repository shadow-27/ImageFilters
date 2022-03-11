using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Project_1
{
    



    public partial class Form1 : Form
    {
        Image file;
        private Bitmap pic;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG (*.JPG)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(f.FileName);
                pictureBox1.Image = file;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "JPG (*.JPG)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                file.Save(f.FileName);

            }

        }

        private void inversionButton_Click(object sender, EventArgs e)
        {
           DisplayScrollbarPicture();

            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    Color inv = pic.GetPixel(x, y);
                    inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                }
            }
            pictureBox2.Image = pic;
        }

        

        private void brightnessButton_CheckedChanged(object sender, EventArgs e)
        {
            DisplayScrollbarPicture();
        }

        private void contrastButton_CheckedChanged(object sender, EventArgs e)
        {
            DisplayScrollbarPicture();
        }


        private void gammaButton_CheckedChanged(object sender, EventArgs e)
        {
           DisplayScrollbarPicture();
        }

        private void brightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            if (brightnessButton.Checked == true)
            {
                contrastButton.Checked = false;
                gammaButton.Checked = false;
                pictureBox2.Image = AdjustBrightness(pic, (float)(trackBar.Value / 100.0));
                textBox1.Text = "Brightness = " + (trackBar.Value / 100.0).ToString();
                pictureBox2.Refresh();
            }

            if (contrastButton.Checked == true)
            {
                pictureBox2.Image = AdjustContrast(pic, (float)(trackBar.Value / 100.0));
                textBox1.Text = "Contrast = " + (trackBar.Value / 100.0).ToString();
                pictureBox2.Refresh();
            }

            if (gammaButton.Checked == true)
            {
                pictureBox2.Image = AdjustGamma(pic, (float)(trackBar.Value / 100.0));
                textBox1.Text = "Gamma = " + (trackBar.Value / 100.0).ToString();
                pictureBox2.Refresh();
            }
            
        }

        private void DisplayScrollbarPicture()
        {
            trackBar.Visible = true;
            textBox1.Visible = true;
            if (pictureBox2.IsNullOrEmpty())
            {
                if (pictureBox1.IsNullOrEmpty())
                {
                    MessageBox.Show("Open an image to apply filters");
                    
                }
                
                pic = new Bitmap(pictureBox1.Image);

            }
            else
            {
                pic = new Bitmap(pictureBox2.Image);
            }
        }

        private Bitmap AdjustBrightness(Image image, float brightness)
        {
            // Make the ColorMatrix.
            float b = brightness;
            ColorMatrix cm = new ColorMatrix(new float[][]
            {
                new float[] {b, 0, 0, 0, 0},
                new float[] {0, b, 0, 0, 0},
                new float[] {0, 0, b, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1},
            });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while applying the new ColorMatrix.
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect, GraphicsUnit.Pixel, attributes);
            }

            // Return the result.
            return bm;
        }

        private  Bitmap AdjustContrast(Bitmap Image, float Value)
        {
            Value = (100.0f + Value) / 100.0f;
            Value *= Value;
            Bitmap NewBitmap = (Bitmap)Image.Clone();
            BitmapData data = NewBitmap.LockBits(
                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                ImageLockMode.ReadWrite,
                NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2];

                        float Red = R / 255.0f;
                        float Green = G / 255.0f;
                        float Blue = B / 255.0f;
                        Red = (((Red - 0.5f) * Value) + 0.5f) * 255.0f;
                        Green = (((Green - 0.5f) * Value) + 0.5f) * 255.0f;
                        Blue = (((Blue - 0.5f) * Value) + 0.5f) * 255.0f;

                        int iR = (int)Red;
                        iR = iR > 255 ? 255 : iR;
                        iR = iR < 0 ? 0 : iR;
                        int iG = (int)Green;
                        iG = iG > 255 ? 255 : iG;
                        iG = iG < 0 ? 0 : iG;
                        int iB = (int)Blue;
                        iB = iB > 255 ? 255 : iB;
                        iB = iB < 0 ? 0 : iB;

                        row[columnOffset] = (byte)iB;
                        row[columnOffset + 1] = (byte)iG;
                        row[columnOffset + 2] = (byte)iR;

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }

        private Bitmap AdjustGamma(Image image, float gamma)
        {
            // Set the ImageAttributes object's gamma value.
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetGamma(gamma);

            // Draw the image onto the new bitmap
            // while applying the new gamma value.
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect =
                new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect,
                    GraphicsUnit.Pixel, attributes);
            }

            // Return the result.
            return bm;
        }

        private void convolutionFilterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            switch (convolutionFilterBox.SelectedItem.ToString())
            {
                case "Blur":
                    DisplayScrollbarPicture();
                    Blur3x3Filter blurfilter = new Blur3x3Filter();
                    pictureBox2.Image=pic.ConvolutionFilter(blurfilter);
                    break;

                case "Gaussian Blur":
                    DisplayScrollbarPicture();
                    GausianFilter gfilter = new GausianFilter();
                    pictureBox2.Image = pic.ConvolutionFilter(gfilter);
                    break;

                case "Sharpen":
                    DisplayScrollbarPicture();
                    SharpenFilter sfilter = new SharpenFilter();
                    pictureBox2.Image = pic.ConvolutionFilter(sfilter);
                    break;

                case "Edge Detection":
                    DisplayScrollbarPicture();
                    HorizontalEdgeDetectionFilter heFilter = new HorizontalEdgeDetectionFilter();
                    pictureBox2.Image = pic.ConvolutionFilter(heFilter);
                    break;

                case "Emboss":
                    DisplayScrollbarPicture();
                    SouthEmbossFilter seFilter = new SouthEmbossFilter();
                    pictureBox2.Image = pic.ConvolutionFilter(seFilter);
                    break;



            }
        }

        private void revertButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.IsNullOrEmpty())
            {
                throw new Exception("No Image is selected");
            }

            pictureBox2.Image = pictureBox1.Image;
        }
    }

    public abstract class ConvolutionFilterBase
    {
        public abstract string FilterName
        {
            get;
        }


        public abstract double Factor
        {
            get;
        }


        public abstract double Bias
        {
            get;
        }


        public abstract double[,] FilterMatrix
        {
            get;
        }
    }

    public class Blur3x3Filter : ConvolutionFilterBase
    {
        public override string FilterName
        {
            get { return "Blur3x3Filter"; }
        }


        private double factor = 1.0;

        public override double Factor
        {
            get { return factor; }
        }


        private double bias = 0.0;

        public override double Bias
        {
            get { return bias; }
        }


        private double[,] filterMatrix =
            new double[,]
            {
                { 0.0, 0.2, 0.0, },
                { 0.2, 0.2, 0.2, },
                { 0.0, 0.2, 0.2, },
            };


        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
    //change to int

    public class GausianFilter : ConvolutionFilterBase
    {
        public override string FilterName
        {
            get { return "Gausian smoothing"; }
        }


        private double factor = 1.0 / 8.0;
        public override double Factor
        {
            get { return factor; }
        }


        private double bias = 0;
        public override double Bias
        {
            get { return bias; }
        }


        private double[,] filterMatrix =
            new double[,] { { 0, 1, 0, },
                { 1, 4, 1, },
                { 0, 1, 0, }, };


        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }


    public class SharpenFilter : ConvolutionFilterBase
    {
        public override string FilterName
        {
            get { return "SharpenFilter"; }
        }


        private double factor = 1.0;
        public override double Factor
        {
            get { return factor; }
        }


        private double bias = 0.0;
        public override double Bias
        {
            get { return bias; }
        }

        /*
            where s = b − 4a
            Example (a = 1, b = 5):
         */

        private double[,] filterMatrix =
            new double[,] { { 0, -1, 0, },
                { -1,  5, -1, },
                { 0, -1, 0, }, };


        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    public class HorizontalEdgeDetectionFilter : ConvolutionFilterBase
    {
        public override string FilterName
        {
            get { return "HorizontalEdgeDetectionFilter"; }
        }


        private double factor = 1.0;
        public override double Factor
        {
            get { return factor; }
        }


        private double bias = 128;
        public override double Bias
        {
            get { return bias; }
        }


        private double[,] filterMatrix =
            new double[,] { {0,-1,0},
                {0,1,0},
                {0,0,0},
            };


        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }

    public class SouthEmbossFilter : ConvolutionFilterBase
    {
        public override string FilterName
        {
            get { return "EmbossFilter"; }
        }


        private double factor = 1.0;
        public override double Factor
        {
            get { return factor; }
        }


        private double bias = 0;
        public override double Bias
        {
            get { return bias; }
        }


        private double[,] filterMatrix =
            new double[,] { { -1,  -1,  -1, },
                { 0, 1,  0, },
                { 1,  1, 1, }, };


        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
