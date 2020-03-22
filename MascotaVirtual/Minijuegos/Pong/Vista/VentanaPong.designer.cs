namespace MascotaVirtual.Minijuegos.Pong.Vista
{
    /// <summary>
    /// Ventana del juego Pong
    /// </summary>
    partial class VentanaPong
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu menuPrincipal;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuPrincipal = new System.Windows.Forms.MainMenu();
            this.IArchivo = new System.Windows.Forms.MenuItem();
            this.ISalir = new System.Windows.Forms.MenuItem();
            this.animacion = new System.Windows.Forms.Timer();
            this.imagen = new MascotaVirtual.Minijuegos.Pong.Vista.ControlDobleBuffer();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.MenuItems.Add(this.IArchivo);
            // 
            // IArchivo
            // 
            this.IArchivo.MenuItems.Add(this.ISalir);
            this.IArchivo.Text = "Archivo";
            // 
            // ISalir
            // 
            this.ISalir.Text = "Salir";
            this.ISalir.Click += new System.EventHandler(this.ISalir_Click);
            // 
            // animacion
            // 
            this.animacion.Interval = 50;
            this.animacion.Tick += new System.EventHandler(this.animacion_Tick);
            // 
            // imagen
            // 
            this.imagen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imagen.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.imagen.Location = new System.Drawing.Point(18, 9);
            this.imagen.Name = "imagen";
            this.imagen.Size = new System.Drawing.Size(200, 250);
            this.imagen.TabIndex = 0;
            this.imagen.Text = "controlDobleBuffer1";
            this.imagen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imagen_MouseDown);
            // 
            // VentanaPong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.imagen);
            this.KeyPreview = true;
            this.Menu = this.menuPrincipal;
            this.MinimizeBox = false;
            this.Name = "VentanaPong";
            this.Text = "Pong";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.VentanaPong_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VentanaPrincipal_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Pong.Vista.ControlDobleBuffer imagen;
        private System.Windows.Forms.Timer animacion;
        private System.Windows.Forms.MenuItem IArchivo;
        private System.Windows.Forms.MenuItem ISalir;
    }
}

