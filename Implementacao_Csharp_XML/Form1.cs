using System;
using System.Collections.Generic;
using System.Drawing;
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
            //leftLimit = PointToScreen(leftLimit);
            //rightLimit = PointToScreen(rightLimit);
            //upperLimit = PointToScreen(upperLimit);
            //bottomLimit = PointToScreen(bottomLimit);
            Rectangle rectangle = new Rectangle(leftLimit.X, upperLimit.Y, rightLimit.X - leftLimit.X, upperLimit.Y - bottomLimit.Y);

            Graphics g = pnlCamCapture.CreateGraphics();

            Bitmap bmp = new Bitmap(rectangle.Width, rectangle.Height);

            g = Graphics.FromImage(bmp);

            Point controlZeroPoint = pnlCamCapture.PointToScreen(new Point(0, 0));

            g.CopyFromScreen(controlZeroPoint.X + leftLimit.X, controlZeroPoint.Y + bottomLimit.Y, 0, 0, rectangle.Size);

            //pnlCamCapture.DrawToBitmap(bmp, boundsOfShot);

            SizeMoveablePicBox captura = new SizeMoveablePicBox();
            captura.Size = rectangle.Size;
            captura.Image = bmp;
            captura.Refresh();
            captura.Location = e.Location;

            //    //adição do picbox ao painel da imagem
            pnlCamCapture.Controls.Add(captura);

        }
    }//public partial class FormPrincipal : Form


}
