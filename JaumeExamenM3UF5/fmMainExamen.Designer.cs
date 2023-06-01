namespace JaumeExamenM3UF5
{
    partial class fmMainExamen
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMainExamen));
            this.niExamen = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmMenuIcona = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activarCamaratoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarCamaratoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortirtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbCameraWeb = new System.Windows.Forms.PictureBox();
            this.btnEnviarFoto = new System.Windows.Forms.Button();
            this.cmMenuIcona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCameraWeb)).BeginInit();
            this.SuspendLayout();
            // 
            // niExamen
            // 
            this.niExamen.ContextMenuStrip = this.cmMenuIcona;
            this.niExamen.Icon = ((System.Drawing.Icon)(resources.GetObject("niExamen.Icon")));
            this.niExamen.Text = "ExamenM3UF5";
            this.niExamen.Visible = true;
            // 
            // cmMenuIcona
            // 
            this.cmMenuIcona.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmMenuIcona.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activarCamaratoolStripMenuItem,
            this.desactivarCamaratoolStripMenuItem,
            this.sortirtoolStripMenuItem});
            this.cmMenuIcona.Name = "cmMenuIcona";
            this.cmMenuIcona.Size = new System.Drawing.Size(210, 76);
            // 
            // activarCamaratoolStripMenuItem
            // 
            this.activarCamaratoolStripMenuItem.Name = "activarCamaratoolStripMenuItem";
            this.activarCamaratoolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.activarCamaratoolStripMenuItem.Text = "Activar Webcam";
            this.activarCamaratoolStripMenuItem.Click += new System.EventHandler(this.activarCamaratoolStripMenuItem_Click);
            // 
            // desactivarCamaratoolStripMenuItem
            // 
            this.desactivarCamaratoolStripMenuItem.Name = "desactivarCamaratoolStripMenuItem";
            this.desactivarCamaratoolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.desactivarCamaratoolStripMenuItem.Text = "Desactivar Webcam";
            this.desactivarCamaratoolStripMenuItem.Click += new System.EventHandler(this.desactivarCamaratoolStripMenuItem_Click);
            // 
            // sortirtoolStripMenuItem
            // 
            this.sortirtoolStripMenuItem.Name = "sortirtoolStripMenuItem";
            this.sortirtoolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.sortirtoolStripMenuItem.Text = "Sortir";
            this.sortirtoolStripMenuItem.Click += new System.EventHandler(this.sortirtoolStripMenuItem_Click);
            // 
            // pbCameraWeb
            // 
            this.pbCameraWeb.Image = ((System.Drawing.Image)(resources.GetObject("pbCameraWeb.Image")));
            this.pbCameraWeb.Location = new System.Drawing.Point(103, 76);
            this.pbCameraWeb.Name = "pbCameraWeb";
            this.pbCameraWeb.Size = new System.Drawing.Size(325, 267);
            this.pbCameraWeb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCameraWeb.TabIndex = 1;
            this.pbCameraWeb.TabStop = false;
            // 
            // btnEnviarFoto
            // 
            this.btnEnviarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnEnviarFoto.Location = new System.Drawing.Point(483, 301);
            this.btnEnviarFoto.Name = "btnEnviarFoto";
            this.btnEnviarFoto.Size = new System.Drawing.Size(105, 42);
            this.btnEnviarFoto.TabIndex = 2;
            this.btnEnviarFoto.Text = "Go";
            this.btnEnviarFoto.UseVisualStyleBackColor = false;
            this.btnEnviarFoto.Click += new System.EventHandler(this.btnEnviarFoto_Click);
            // 
            // fmMainExamen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEnviarFoto);
            this.Controls.Add(this.pbCameraWeb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "fmMainExamen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SongEmocion";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmMainExamen_FormClosing);
            this.Load += new System.EventHandler(this.fmMainExamen_Load);
            this.cmMenuIcona.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCameraWeb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niExamen;
        private System.Windows.Forms.ContextMenuStrip cmMenuIcona;
        private System.Windows.Forms.ToolStripMenuItem activarCamaratoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactivarCamaratoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortirtoolStripMenuItem;
        private System.Windows.Forms.PictureBox pbCameraWeb;
        private System.Windows.Forms.Button btnEnviarFoto;
    }
}

