namespace MascotaVirtual.Minijuegos.Palomas.Vista
{
    partial class VentanaPalomas
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu menuPalomas;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPalomas));
            this.menuPalomas = new System.Windows.Forms.MainMenu();
            this.Archivo = new System.Windows.Forms.MenuItem();
            this.NuevoJuego = new System.Windows.Forms.MenuItem();
            this.Salir = new System.Windows.Forms.MenuItem();
            this.Opciones = new System.Windows.Forms.MenuItem();
            this.verPuntuaciones = new System.Windows.Forms.MenuItem();
            this.pBVidaZombie = new System.Windows.Forms.ProgressBar();
            this.lVidaZombie = new System.Windows.Forms.Label();
            this.Puntuacion = new System.Windows.Forms.Label();
            this.lInstrucciones = new System.Windows.Forms.Label();
            this.graficosJuego = new MascotaVirtual.Interface.Controles.ControlGrafico();
            this.lGameOver = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menuPalomas
            // 
            this.menuPalomas.MenuItems.Add(this.Archivo);
            this.menuPalomas.MenuItems.Add(this.Opciones);
            // 
            // Archivo
            // 
            this.Archivo.MenuItems.Add(this.NuevoJuego);
            this.Archivo.MenuItems.Add(this.Salir);
            resources.ApplyResources(this.Archivo, "Archivo");
            // 
            // NuevoJuego
            // 
            resources.ApplyResources(this.NuevoJuego, "NuevoJuego");
            this.NuevoJuego.Click += new System.EventHandler(this.NuevoJuego_Click);
            // 
            // Salir
            // 
            resources.ApplyResources(this.Salir, "Salir");
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // Opciones
            // 
            this.Opciones.MenuItems.Add(this.verPuntuaciones);
            resources.ApplyResources(this.Opciones, "Opciones");
            // 
            // verPuntuaciones
            // 
            resources.ApplyResources(this.verPuntuaciones, "verPuntuaciones");
            this.verPuntuaciones.Click += new System.EventHandler(this.verPuntuaciones_Click);
            // 
            // pBVidaZombie
            // 
            resources.ApplyResources(this.pBVidaZombie, "pBVidaZombie");
            this.pBVidaZombie.Maximum = 10;
            this.pBVidaZombie.Name = "pBVidaZombie";
            this.pBVidaZombie.Value = 10;
            // 
            // lVidaZombie
            // 
            resources.ApplyResources(this.lVidaZombie, "lVidaZombie");
            this.lVidaZombie.Name = "lVidaZombie";
            // 
            // Puntuacion
            // 
            resources.ApplyResources(this.Puntuacion, "Puntuacion");
            this.Puntuacion.Name = "Puntuacion";
            // 
            // lInstrucciones
            // 
            this.lInstrucciones.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lInstrucciones.ForeColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.lInstrucciones, "lInstrucciones");
            this.lInstrucciones.Name = "lInstrucciones";
            // 
            // graficosJuego
            // 
            this.graficosJuego.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.graficosJuego, "graficosJuego");
            this.graficosJuego.Name = "graficosJuego";
            this.graficosJuego.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graficosJuego_MouseDown);
            // 
            // lGameOver
            // 
            this.lGameOver.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.lGameOver, "lGameOver");
            this.lGameOver.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lGameOver.Name = "lGameOver";
            // 
            // VentanaPalomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.Controls.Add(this.lGameOver);
            this.Controls.Add(this.lInstrucciones);
            this.Controls.Add(this.Puntuacion);
            this.Controls.Add(this.graficosJuego);
            this.Controls.Add(this.lVidaZombie);
            this.Controls.Add(this.pBVidaZombie);
            this.Menu = this.menuPalomas;
            this.MinimizeBox = false;
            this.Name = "VentanaPalomas";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.VentanaPalomas_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBVidaZombie;
        private System.Windows.Forms.Label lVidaZombie;
        private MascotaVirtual.Interface.Controles.ControlGrafico graficosJuego;
        private System.Windows.Forms.MenuItem Archivo;
        private System.Windows.Forms.MenuItem Salir;
        private System.Windows.Forms.MenuItem NuevoJuego;
        private System.Windows.Forms.Label Puntuacion;
        private System.Windows.Forms.Label lInstrucciones;
        private System.Windows.Forms.MenuItem Opciones;
        private System.Windows.Forms.MenuItem verPuntuaciones;
        private System.Windows.Forms.Label lGameOver;
    }
}