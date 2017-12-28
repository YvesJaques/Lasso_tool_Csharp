using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Implementacao_Csharp_XML
{
    public partial class FormPrincipal : Form
    {
        public Point current = new Point();
        public Point old = new Point();
        public Pen p = new Pen(Color.Red, 2);
        public Graphics g;
        SizeMoveablePicBox picBox;
        GraphicsPath gp = new GraphicsPath();

        public FormPrincipal()
        {
            InitializeComponent();
            g = pnlCamCapture.CreateGraphics();
            p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
        }


        private void pnlCamCapture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                gp.AddLine(old, e.Location);
                g.DrawLine(p, old, e.Location);
                old = e.Location;
            }
        }

        private void pnlCamCapture_MouseDown(object sender, MouseEventArgs e)
        {
            old = e.Location;
            gp.Reset();
        }

        private void pnlCamCapture_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                gp.CloseFigure();
                pnlCamCapture.BackColor = Color.Transparent;
                pnlCamCapture.Refresh();

                Rectangle rectangle = Rectangle.Truncate(gp.GetBounds());

                picBox = new SizeMoveablePicBox(rectangle.Location, rectangle.Size);

                Bitmap bmpImage = new Bitmap(pnlCamCapture.BackgroundImage.Width, pnlCamCapture.BackgroundImage.Height);

                Graphics bg = Graphics.FromImage(bmpImage);
                bg.Clip = new Region(gp);
                bg.DrawImage(pnlCamCapture.BackgroundImage, 0, 0);

                Bitmap bmpCrop;
                try
                {
                    bmpCrop = bmpImage.Clone(gp.GetBounds(), bmpImage.PixelFormat);
                }
                catch (System.ArgumentException)
                {
                    MessageBox.Show("Área selecionada muito pequena");
                    return;
                };

                //picBox.Location = e.Location;
                //picBox.Location = rectangle.Location;
                picBox.Image = bmpCrop;                
                pnlCamCapture.Controls.Add(picBox);
            }
        }

        private void btnCarregarImagem_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.ShowDialog();

            if (string.IsNullOrEmpty(fd.FileName)) return;

            pnlCamCapture.BackgroundImage = Image.FromFile(fd.FileName);
            g = pnlCamCapture.CreateGraphics();
        }

        private void numUDAumentoSilueta_ValueChanged(object sender, EventArgs e)
        {
            Config.fatorAumento = (int)numUDAumentoSilueta.Value;
        }
    }//public partial class FormPrincipal : Form


}
