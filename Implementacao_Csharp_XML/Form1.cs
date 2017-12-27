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
            gp.CloseFigure();
            pnlCamCapture.BackColor = Color.Transparent;
            pnlCamCapture.Refresh();

            picBox = new SizeMoveablePicBox();

            Rectangle rectangle = Rectangle.Truncate(gp.GetBounds());

            Bitmap bmpImage = new Bitmap(pnlCamCapture.BackgroundImage.Width, pnlCamCapture.BackgroundImage.Height);

            Graphics bg = Graphics.FromImage(bmpImage);
            bg.Clip = new Region(gp);
            bg.DrawImage(pnlCamCapture.BackgroundImage, 0, 0);

            Bitmap bmpCrop = bmpImage.Clone(gp.GetBounds(), bmpImage.PixelFormat);


            picBox.Location = e.Location;
            picBox.Image = bmpCrop;
            picBox.Size = rectangle.Size;
            pnlCamCapture.Controls.Add(picBox);
        }

        private void btnCarregarImagem_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.ShowDialog();

            if (string.IsNullOrEmpty(fd.FileName)) return;

            pnlCamCapture.BackgroundImage = Image.FromFile(fd.FileName);
            g = pnlCamCapture.CreateGraphics();
        }
    }//public partial class FormPrincipal : Form


}
