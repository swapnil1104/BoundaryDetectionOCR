using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Classifier
{
    public partial class BoundaryDetection : Form
    {

        public BoundaryDetection()
        {
            InitializeComponent();
        }
       static int[] yaxis = new int[ymax];
        static int ymax;
        static int index = 0;
        static int index2 = 0;

        private void processImgBtn_Click(object sender, EventArgs e)
        {
            StringValues sv = new StringValues();
            int q = 11;
            int z = 1;
            for (int w = 0; w < 26; w++)
            {
                string loc = sv.datasetPath + Convert.ToString(q);

                String[] straimageloc = System.IO.Directory.GetFiles(loc, "*.*");
                q++;
                List<Bitmap> imageList = new List<Bitmap>();

                foreach (var path in straimageloc)
                {
                    Bitmap image = new Bitmap(path);
                    imageList.Add(image);
                }
                System.IO.Directory.CreateDirectory(sv.dataStorePath + Convert.ToString(z));
                string loc1 = sv.dataStorePath + Convert.ToString(z);
                z++;
                for (int n = 0; n < 40; n++)
                {
                    Bitmap bmp = new Bitmap(imageList[n]);


                    int xmax = bmp.Width;
                    int ymax = bmp.Height;
                    Bitmap bwimage = processImage(bmp);
                    int[] xaxis = new int[xmax];
                    int[] yline = new int[ymax];
                    int[] tempx = new int[xmax];
                    int[] tempy = new int[ymax];
                    int i = 1, j = 1;

                    //calculated y axis
                    yaxis = getYArray(xmax, ymax, bwimage);

                    //todo- calculate yaxis for each character and store it.

                    xaxis = getXArray(xmax, ymax, bwimage, yline);

                    int k;
                    Bitmap[] croppedImg = new Bitmap[30];
                    for (i = 1, j = 2, k = 0; k < (xaxis.Length) / 2; k++)
                    {
                        try
                        {
                            Crop filter = new Crop(new Rectangle(xaxis[i], yaxis[1], (xaxis[j] - xaxis[i]), yaxis[2] - yaxis[1]));
                            croppedImg[k] = filter.Apply(bwimage);
                            ResizeBicubic rbc = new ResizeBicubic(60, 90);
                            croppedImg[k] = rbc.Apply(croppedImg[k]);
                            croppedImg[k].Save(loc1 + "\\img_" + k + n + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        catch
                        {
                            break;
                        }
                        i = i + 2;
                        j = j + 2;
                    }


                }
            }

        }
        public Bitmap processImage(Bitmap img)
        {
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayimage = filter.Apply(img);

            Threshold th = new Threshold();
            th.ApplyInPlace(grayimage);

            return grayimage;
        }

        public int[] getYArray(int xmax, int ymax, Bitmap bwimage)
        {
            int y, x, iy = 1, i = 1;
            int[] tempy = new int[ymax];
            int[] yaxis = new int[ymax];
            for (y = 1; y < ymax; y++)
            {
                for (x = 1; x < xmax; x++)
                {
                    if (bwimage.GetPixel(x, y).Name == "ff000000")
                    {
                        tempy[iy++] = y;
                        break;
                    }
                }
            }
            for (int p = 1; p < ymax; p++)
            {

                if ((tempy[p - 1] != tempy[p] - 1) || (tempy[p] + 1 != tempy[p + 1]))
                {
                    yaxis[i++] = tempy[p] + 1;
                }
            }
            return yaxis;
        }

        public int[] getXArray(int xmax, int ymax, Bitmap bwimage, int[] yline)
        {
            int y, x, ix = 1, i = 1;
            int[] tempx = new int[xmax];
            int[] xaxis = new int[xmax];
            for (x = 1; x < xmax; x++)
            {
                for (y = 0; y < ymax; y++)
                {
                    if (bwimage.GetPixel(x, y).Name == "ff000000")
                    {
                        tempx[ix++] = x;
                        break;
                    }
                }
            }
            i = 1;
            for (int p = 1; p < xmax; p++)
            {

                if ((tempx[p - 1] != tempx[p] - 1) || (tempx[p] + 1 != tempx[p + 1]))
                {
                    xaxis[i] = tempx[p] + 1;
                    i++;
                }
            }


            return xaxis;
        }

        private void featureExtractionBtn_Click(object sender, EventArgs e)
        {
            StringValues sv = new StringValues();
            int label = 1;
            for (int q = 1; q < 27; q++)
            {
                string loc1 = sv.dataStorePath + Convert.ToString(q);
                FileStream fs = new FileStream(sv.trainFilePath, FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);

                String[] straimageloc = System.IO.Directory.GetFiles(loc1, "*.*");
                List<Bitmap> imageList = new List<Bitmap>();
                foreach (var path in straimageloc)
                {
                    Bitmap image = new Bitmap(path);
                    imageList.Add(image);
                }

                string data = label + " ";
                for (int n = 0; n < imageList.Count; n++)
                {
                    float norvar = 0;

                    Bitmap bmp = new Bitmap(imageList[n]);


                    Bitmap grayimage = processImage(bmp);

                    ResizeBicubic filter = new ResizeBicubic(60, 90);
                    grayimage = filter.Apply(grayimage);
                    float[,] zone = new float[90, 60];
                    int index = 1;
                    for (int j = 0; j < 90; j += 10)
                    {
                        for (int i = 0; i < 60; i += 10)
                        {
                            float x = 0;
                            Bitmap sector = grayimage.Clone(new System.Drawing.Rectangle(i, j, 10, 10), grayimage.PixelFormat);
                            for (int k = 0; k < 10; k++)
                            {
                                for (int l = 0; l < 10; l++)
                                {
                                    if (sector.GetPixel(k, l).Name == "ff000000") x++;
                                }
                            }
                            norvar += x;
                           
                        }
                    }
                    for (int j = 0; j < 90; j += 10)
                    {
                        for (int i = 0; i < 60; i += 10)
                        {
                            float x = 0;
                            Bitmap sector = grayimage.Clone(new System.Drawing.Rectangle(i, j, 10, 10), grayimage.PixelFormat);
                            for (int k = 0; k < 10; k++)
                            {
                                for (int l = 0; l < 10; l++)
                                {
                                    if (sector.GetPixel(k, l).Name == "ff000000") x++;
                                }
                            }
                            zone[j, i] = x / norvar;
                            data += index++ + ":" + zone[j, i] + " ";

                        }
                    }

                    index = 0;

                    sr.WriteLine(data);


                    data = label + " ";


                }
                label++;
                sr.Flush();
                sr.Close();
                fs.Close();
            }

        }
        string inputFilePath;
        private void browseBtn_Click(object sender, EventArgs e)
        {
            StringValues sv = new StringValues();

            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Image files (*.jpg) | *.jpg; ";
            fdlg.FilterIndex = 2;

            DialogResult result = fdlg.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = fdlg.FileName;
                try
                {
                    string text = File.ReadAllText(file);

                    inputFilePath = file;

                    browseLabel.Text = sv.browseFilePath;
                }
                catch (IOException)
                {
                }

            }


        }
       
        private void detectBtn_Click(object sender, EventArgs e)
        {
            StringValues sv = new StringValues();
            Bitmap bmp = new Bitmap(inputFilePath);
            int xmax = bmp.Width;
            int ymax = bmp.Height;
            Bitmap bwimage = processImage(bmp);
            int[] xaxis = new int[xmax];
            int[] yline = new int[ymax];
            int[] tempx = new int[xmax];
            int[] tempy = new int[ymax];
            int i = 1, j = 1;

            //calculated y axis
            yaxis = getYArray(xmax, ymax, bwimage);

            //todo- calculate yaxis for each character and store it.

            xaxis = getXArray(xmax, ymax, bwimage, yline);

            int k;
            Bitmap[] croppedImg = new Bitmap[30];
            for (i = 1, j = 2, k = 0; k < (xaxis.Length) / 2; k++)
            {
                try
                {
                    Crop filter = new Crop(new Rectangle(xaxis[i], yaxis[1], (xaxis[j] - xaxis[i]), yaxis[2] - yaxis[1]));
                    croppedImg[k] = filter.Apply(bwimage);
                    ResizeBicubic rbc = new ResizeBicubic(60, 90);
                    croppedImg[k] = rbc.Apply(croppedImg[k]);
                    croppedImg[k].Save(sv.browseFileBoundaryDetectionPath + "\\img_" + k + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch
                {
                    break;
                }
                i = i + 2;
                j = j + 2;
            }




            string loc1 = sv.browseFileBoundaryDetectionPath;
            FileStream fs = new FileStream(sv.browseFileFeatureExtractionFile, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);

            String[] straimageloc = System.IO.Directory.GetFiles(loc1, "*.jpg*");
            List<Bitmap> imageList = new List<Bitmap>();
            foreach (var path in straimageloc)
            {
                Bitmap image = new Bitmap(path);
                imageList.Add(image);
            }
            int label = 0;
            string data = label + " ";
            for (int n = 0; n < imageList.Count; n++)
            {
                float norvar = 0;
                Bitmap grayimage = processImage(new Bitmap(imageList[n]));

                ResizeBicubic filter = new ResizeBicubic(60, 90);
                grayimage = filter.Apply(grayimage);
                float[,] zone = new float[90, 60];
                int index = 1;
                for ( j = 0; j < 90; j += 10)
                {
                    for ( i = 0; i < 60; i += 10)
                    {
                        float x = 0;
                        Bitmap sector = grayimage.Clone(new System.Drawing.Rectangle(i, j, 10, 10), grayimage.PixelFormat);
                        for ( k = 0; k < 10; k++)
                        {
                            for (int l = 0; l < 10; l++)
                            {
                                if (sector.GetPixel(k, l).Name == "ff000000") x++;
                            }
                        }
                        norvar += x;

                    }
                }
                for ( j = 0; j < 90; j += 10)
                {
                    for ( i = 0; i < 60; i += 10)
                    {
                        float x = 0;
                        Bitmap sector = grayimage.Clone(new System.Drawing.Rectangle(i, j, 10, 10), grayimage.PixelFormat);
                        for ( k = 0; k < 10; k++)
                        {
                            for (int l = 0; l < 10; l++)
                            {
                                if (sector.GetPixel(k, l).Name == "ff000000") x++;
                            }
                        }
                        zone[j, i] = x / norvar;
                        data += index++ + ":" + zone[j, i] + " ";

                    }
                }

                index = 0;

                sr.WriteLine(data);


                data = label + " ";


            }
            label++;
            sr.Flush();
            sr.Close();
            fs.Close();

            SVMClassifier svm = new SVMClassifier();
            svm.Classify();

         
            foreach (string line in File.ReadLines(sv.finalOutputFile, Encoding.UTF8))
            {
                Console.WriteLine(line);
                string c = Char.ConvertFromUtf32(Int32.Parse(line)+64);
                outputLabel.Text += c;

            }
        }

        private void classifierBtn_Click(object sender, EventArgs e)
        {
          //  cf = new SVMClassifier();
            //StringValues sv = new StringValues();
         //   cf.trainClassifier(sv.trainFilePath);
        }
    }
}
