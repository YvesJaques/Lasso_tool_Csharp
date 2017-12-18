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
        public List<Point> listaPontosSilueta = new List<Point>();
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
                listaPontosSilueta.Add(e.Location);
                g.DrawLine(p, old, e.Location);
                old = e.Location;
            }
        }

        private void pnlCamCapture_MouseDown(object sender, MouseEventArgs e)
        {
            listaPontosSilueta.Clear();
            old = e.Location;
            gp.Reset();
        }

        private void pnlCamCapture_MouseUp(object sender, MouseEventArgs e)
        {
            gp.CloseFigure();
            pnlCamCapture.BackColor = Color.Transparent;
            pnlCamCapture.Refresh();

            picBox = new SizeMoveablePicBox();
            RectangleF rectangleF = gp.GetBounds();
            int rectWidth = Convert.ToInt32(rectangleF.Width);
            int rectHeight = Convert.ToInt32(rectangleF.Height);
            int rectTop = Convert.ToInt32(gp.GetBounds().Top);
            int rectBottom = Convert.ToInt32(gp.GetBounds().Bottom);
            Rectangle rectangle = new Rectangle(new Point(rectTop, rectBottom), new Size(rectWidth, rectHeight));

            Bitmap bmp = new Bitmap(pnlCamCapture.BackgroundImage.Width, pnlCamCapture.BackgroundImage.Height);
            Graphics bg = Graphics.FromImage(bmp);
            bg.Clip = new Region(gp);
            bg.DrawImage(pnlCamCapture.BackgroundImage, 0, 0);
            bmp.Save(@"C:\Users\Yves\Desktop\test.bmp");
            picBox.Image = bmp;
            pnlCamCapture.Controls.Add(picBox);

        }




    }//public partial class FormPrincipal : Form


}
