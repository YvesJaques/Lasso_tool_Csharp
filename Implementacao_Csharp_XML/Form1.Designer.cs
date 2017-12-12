namespace Implementacao_Csharp_XML
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlCamCapture = new Implementacao_Csharp_XML.App_code.BufferedPanel();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlCamCapture
            // 
            this.pnlCamCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCamCapture.BackgroundImage = global::Implementacao_Csharp_XML.Properties.Resources.image;
            this.pnlCamCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCamCapture.Location = new System.Drawing.Point(12, 12);
            this.pnlCamCapture.Name = "pnlCamCapture";
            this.pnlCamCapture.Size = new System.Drawing.Size(694, 402);
            this.pnlCamCapture.TabIndex = 0;
            this.pnlCamCapture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlCamCapture_MouseClick);
            this.pnlCamCapture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCamCapture_MouseDown);
            this.pnlCamCapture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlCamCapture_MouseMove);
            this.pnlCamCapture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlCamCapture_MouseUp);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(718, 426);
            this.Controls.Add(this.pnlCamCapture);
            this.Name = "FormPrincipal";
            this.Text = "Visualizador de equipamentos";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private App_code.BufferedPanel pnlCamCapture;
    }
}

