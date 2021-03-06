//classe de controle herdeira de PictureBox
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Implementacao_Csharp_XML;


class SizeMoveablePicBox : PictureBox
{
    //protected override void OnPaint(PaintEventArgs pe)
    //{
    //    base.OnPaint(pe);
    //}
    public Point initialLocation;
    public int initialWidth;
    public int initialHeight;
    public Size initialSize;
    public ContextMenu componentContxtMenu = new ContextMenu();

    public SizeMoveablePicBox(Point location, Size size)
    {
        //this.ResizeRedraw = true;
        this.BackColor = Color.Transparent;
        this.BorderStyle = BorderStyle.None;
        //AutoSize = true;
        this.SizeMode = PictureBoxSizeMode.StretchImage;
        this.Cursor = Cursors.Hand;
        this.Location = location;
        this.Size = size;
        this.Refresh();

        //adição de event handlers para movimentação da picBox com o botão do meio do mouse
        this.MouseDown += new MouseEventHandler(SizeMoveAblePicBox_MouseDown);
        this.MouseMove += new MouseEventHandler(SizeMoveAblePicBox_MouseMove);
        this.Move += new EventHandler(SizeMoveAblePicBox_Move);

        this.ContextMenu = componentContxtMenu;
        componentContxtMenu.MenuItems.Add(mnuItemDelete);
        componentContxtMenu.MenuItems.Add(mnuItemReset);
        mnuItemDelete.Click += new EventHandler(mnuItemDelete_Click);
        mnuItemReset.Click += new EventHandler(mnuItemReset_Click);

        initialLocation = location;
        initialWidth = size.Width;
        initialHeight = size.Height;
        initialSize = size;


    }

    //definição de items do menu de contexto    
    private MenuItem mnuItemDelete = new MenuItem()
    {
        Text = "Deletar"
    };

    private MenuItem mnuItemReset = new MenuItem()
    {
        Text = "Resetar"
    };

    private void mnuItemDelete_Click(object sender, EventArgs e)
    {
        this.Dispose();
    }

    private void mnuItemReset_Click(object sender, EventArgs e)
    {
        this.Size = initialSize;
        this.Location = initialLocation;
    }

    //resize do pictureBox conforme descloamento no eixo Y
    public void SizeMoveAblePicBox_Move(object sender, EventArgs e)
    {
        if (this.Location.Y == initialLocation.Y)
        {
            Height = initialHeight;
            Width = initialWidth;
        }//posição inicial, reset do tamanho
        else
        {
            int newWidth = initialWidth;
            int newHeight = initialHeight;
            if (this.Location.Y > initialLocation.Y)
            {
                newHeight = initialHeight + (Location.Y - initialLocation.Y) * Config.fatorAumento;
                newWidth = (int)Math.Floor(initialWidth * ((double)newHeight / (double)initialHeight));
            }
            else if (this.Location.Y < initialLocation.Y)
            {
                newHeight = initialHeight - (initialLocation.Y - Location.Y) * Config.fatorAumento;
                newWidth = (int)Math.Floor(initialWidth * ((double)newHeight / (double)initialHeight));
            }
            Width = newWidth;
            Height = newHeight;
        }
    }//public void SizeMoveAblePicBox_Move(object sender, EventArgs e)



    //ponto auxiliar de referencia para reposicionamento da picbox
    Point picBoxMouseDownLocation;

    //identificação do clique e arraste do mouse na pictureBox
    public void SizeMoveAblePicBox_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) picBoxMouseDownLocation = e.Location;
    }
    //movimentação da pictureBox
    public void SizeMoveAblePicBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            //alteração das coordenadas da pictureBox baseado no movimento do mouse, quando clicando
            this.Left += e.X - picBoxMouseDownLocation.X;
            this.Top += e.Y - picBoxMouseDownLocation.Y;
        }
    }

    /*essa porção gera o controle de drag resize no canto da moldura da picture box
    foi comentada pois não era desejada a visualização do controle*/
    //protected override void OnPaint(PaintEventArgs e)
    //{
    //    base.OnPaint(e);
    //    var rc = new Rectangle(this.ClientSize.Width - grab, this.ClientSize.Height - grab, grab, grab);
    //    ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
    //}

    /*identificação se o cursor se encontra nos limites da pictureBox no momento do clique
    e modificação do tamanho da picture box*/

    //class Foo : PictureBox
    //{
    //    public Foo(int argument)
    //        : base()
    //    {
    //        Console.WriteLine(argument);//different in the real application of course.
    //                                    //MyProject.Properties.Resources.TRANSPARENCYTEST.MakeTransparent(MyProject.Properties.Resources.TRANSPARENCYTEST.GetPixel(1,1)); //<-- also tried this
    //        //Image = Implementacao_Csharp_XML.Properties.Resources.transparent_image.png;
    //        ((Bitmap)this.Image).MakeTransparent(((Bitmap)this.Image).GetPixel(1, 1));
    //        this.SizeMode = PictureBoxSizeMode.StretchImage;
    //        this.BackColor = System.Drawing.Color.Transparent;
    //    }
    //}

    //protected override void WndProc(ref Message m)
    //{
    //    base.WndProc(ref m);

    //    if (m.Msg == 0x84)
    //    {  // Trap WM_NCHITTEST
    //        var pos = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
    //        if (pos.X >= this.ClientSize.Width - grab && pos.Y >= this.ClientSize.Height - grab)
    //            m.Result = new IntPtr(17);  // HT_BOTTOMRIGHT
    //    }
    //}

    /*variavel de tamanho em pixel da borda para referencia ao click na picture box para movimentação,
    identificação da área útil de clique e arraste*/
    //private const int grab = 16;

    //override da função de encapsulamento de informaçãoes quando da criação do controle para exibição da borda diferente
    //protected override CreateParams CreateParams
    //{
    //    get
    //    {
    //        var cp = base.CreateParams;
    //        //cp.Style |= 0x840000;  // Turn on WS_BORDER + WS_THICKFRAME            
    //        //cp.Style |= 0x20000;
    //        //cp.Style |= 0;
    //        return cp;
    //    }
    //}

}