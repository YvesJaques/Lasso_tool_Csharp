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
            this.btnCarregarImagem = new System.Windows.Forms.Button();
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
            this.pnlCamCapture.AutoSize = true;
            this.pnlCamCapture.BackgroundImage = global::Implementacao_Csharp_XML.Properties.Resources.image;
            this.pnlCamCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlCamCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCamCapture.Location = new System.Drawing.Point(12, 43);
            this.pnlCamCapture.Name = "pnlCamCapture";
            this.pnlCamCapture.Size = new System.Drawing.Size(722, 420);
            this.pnlCamCapture.TabIndex = 0;
            this.pnlCamCapture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCamCapture_MouseDown);
            this.pnlCamCapture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlCamCapture_MouseMove);
            this.pnlCamCapture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlCamCapture_MouseUp);
            // 
            // btnCarregarImagem
            // 
            this.btnCarregarImagem.Location = new System.Drawing.Point(12, 12);
            this.btnCarregarImagem.Name = "btnCarregarImagem";
            this.btnCarregarImagem.Size = new System.Drawing.Size(102, 23);
            this.btnCarregarImagem.TabIndex = 1;
            this.btnCarregarImagem.Text = "Carregar Imagem";
            this.btnCarregarImagem.UseVisualStyleBackColor = true;
            this.btnCarregarImagem.Click += new System.EventHandler(this.btnCarregarImagem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(746, 475);
            this.Controls.Add(this.btnCarregarImagem);
            this.Controls.Add(this.pnlCamCapture);
            this.Name = "FormPrincipal";
            this.Text = "Visualizador de equipamentos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private App_code.BufferedPanel pnlCamCapture;
        private System.Windows.Forms.Button btnCarregarImagem;
    }
}

