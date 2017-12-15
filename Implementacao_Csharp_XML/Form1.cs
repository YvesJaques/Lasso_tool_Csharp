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
        public Point upperLimit;
        public Point bottomLimit;
        public Point rightLimit;
        public Point leftLimit;

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
                listaPontosSilueta.Add(e.Location);
                current = e.Location;
                g.DrawLine(p, old, current);
                old = current;
            }
        }

        private void pnlCamCapture_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && cbxNovoComponente.Checked == true)
            //{
            //    Componente componente = new Componente();
            //    componente.picBoxComponente.Location = e.Location;

            //    //adição do controle ao painel de componentes
            //    pnlCamCapture.Controls.Add(componente.picBoxComponente);
            //}  
        }

        private void pnlCamCapture_MouseDown(object sender, MouseEventArgs e)
        {
            listaPontosSilueta.Clear();
            old = e.Location;
        }

        private void pnlCamCapture_MouseUp(object sender, MouseEventArgs e)
        {
            upperLimit = e.Location;
            bottomLimit = e.Location;
            rightLimit = e.Location;
            leftLimit = e.Location;
            foreach (Point point in listaPontosSilueta)
            {
                if (point.X < leftLimit.X) leftLimit = point;
                if (point.X > rightLimit.X) rightLimit = point;
                if (point.Y > upperLimit.Y) upperLimit = point;
                if (point.Y < bottomLimit.Y) bottomLimit = point;
            }

            Point[] arrayPontos = listaPontosSilueta.ToArray();

            pnlCamCapture.Invalidate();
            pnlCamCapture.Refresh();
            Rectangle rectangle = new Rectangle(leftLimit.X, upperLimit.Y, rightLimit.X - leftLimit.X, upperLimit.Y - bottomLimit.Y);

            Graphics pnlGraphics = pnlCamCapture.CreateGraphics();

            //pnlGraphics = Graphics.FromImage(bmp);

            //Point controlZeroPoint = pnlCamCapture.PointToScreen(new Point(0, 0));

            //pnlGraphics.CopyFromScreen(controlZeroPoint.X + leftLimit.X, controlZeroPoint.Y + bottomLimit.Y, 0, 0, rectangle.Size);
            Bitmap bmp1 = new Bitmap(rectangle.Width, rectangle.Height);

            Point[] contour = new Point[] { new Point(0, 0), new Point(50, 0), new Point(50, 50) };

            GraphicsPath gp = new GraphicsPath();
            gp.AddPolygon(arrayPontos);
            gp.CloseAllFigures();

            SizeMoveablePicBox captura = new SizeMoveablePicBox();
            //gp.AddPolygon(arrayPontos);
            //captura.Region = new Region(gp);
            //captura.Invalidate();
            using (Bitmap bmp = new Bitmap(rectangle.Width, rectangle.Height))
            using (Graphics G = Graphics.FromImage(bmp1))
            {
                pnlGraphics.Clip = new Region(gp);
                pnlGraphics.DrawImage(bmp, 0, 0);
                captura.Image = bmp1;
            }

            captura.Size = rectangle.Size;
            captura.Region = new Region(gp);
            captura.Refresh();
            captura.Location = e.Location;
            captura.Refresh();

            pnlCamCapture.Controls.Add(captura);
            captura.BringToFront();
            captura.BorderStyle = BorderStyle.FixedSingle;


        }
    }//public partial class FormPrincipal : Form


}
