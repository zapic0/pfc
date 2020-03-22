namespace MascotaVirtual.Minijuegos.Cementerio.Vista
{
    partial class VentanaCementerio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaCementerio));
            this.animacion = new System.Windows.Forms.Timer();
            this.activador = new System.Windows.Forms.Timer();
            this.nivel = new System.Windows.Forms.Timer();
            this.segundo = new System.Windows.Forms.Timer();
            this.lPuntuacion = new System.Windows.Forms.Label();
            this.bRecargar = new System.Windows.Forms.Button();
            this.AnimacionJuego = new MascotaVirtual.Interface.Controles.ControlAnimacion();
            this.menuCementerio = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.nuevoJuego = new System.Windows.Forms.MenuItem();
            this.Salir = new System.Windows.Forms.MenuItem();
            this.Opciones = new System.Windows.Forms.MenuItem();
            this.verPuntuaciones = new System.Windows.Forms.MenuItem();
            this.lVidasRestantes = new System.Windows.Forms.Label();
            this.lBalasRestantes = new System.Windows.Forms.Label();
            this.pBVida = new System.Windows.Forms.PictureBox();
            this.pBBalas = new System.Windows.Forms.PictureBox();
            this.lGameOver = new System.Windows.Forms.Label();
            this.lInstrucciones = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // animacion
            // 
            this.animacion.Interval = 42;
            this.animacion.Tick += new System.EventHandler(this.animacion_Tick);
            // 
            // activador
            // 
            this.activador.Interval = 2000;
            this.activador.Tick += new System.EventHandler(this.activador_Tick);
            // 
            // nivel
            // 
            this.nivel.Interval = 10000;
            this.nivel.Tick += new System.EventHandler(this.nivel_Tick);
            // 
            // segundo
            // 
            this.segundo.Enabled = true;
            this.segundo.Interval = 1000;
            this.segundo.Tick += new System.EventHandler(this.segundo_Tick);
            // 
            // lPuntuacion
            // 
            this.lPuntuacion.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lPuntuacion, "lPuntuacion");
            this.lPuntuacion.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lPuntuacion.Name = "lPuntuacion";
            // 
            // bRecargar
            // 
            this.bRecargar.BackColor = System.Drawing.Color.PeachPuff;
            resources.ApplyResources(this.bRecargar, "bRecargar");
            this.bRecargar.Name = "bRecargar";
            this.bRecargar.Click += new System.EventHandler(this.bRecargar_Click);
            // 
            // AnimacionJuego
            // 
            this.AnimacionJuego.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.AnimacionJuego, "AnimacionJuego");
            this.AnimacionJuego.Name = "AnimacionJuego";
            this.AnimacionJuego.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnimacionJuego_MouseDown);
            // 
            // menuCementerio
            // 
            this.menuCementerio.MenuItems.Add(this.menuItem1);
            this.menuCementerio.MenuItems.Add(this.Opciones);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.nuevoJuego);
            this.menuItem1.MenuItems.Add(this.Salir);
            resources.ApplyResources(this.menuItem1, "menuItem1");
            // 
            // nuevoJuego
            // 
            resources.ApplyResources(this.nuevoJuego, "nuevoJuego");
            this.nuevoJuego.Click += new System.EventHandler(this.nuevoJuego_Click);
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
            // lVidasRestantes
            // 
            this.lVidasRestantes.BackColor = System.Drawing.Color.Black;
            this.lVidasRestantes.ForeColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.lVidasRestantes, "lVidasRestantes");
            this.lVidasRestantes.Name = "lVidasRestantes";
            // 
            // lBalasRestantes
            // 
            this.lBalasRestantes.BackColor = System.Drawing.Color.Black;
            this.lBalasRestantes.ForeColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.lBalasRestantes, "lBalasRestantes");
            this.lBalasRestantes.Name = "lBalasRestantes";
            // 
            // pBVida
            // 
            resources.ApplyResources(this.pBVida, "pBVida");
            this.pBVida.Name = "pBVida";
            // 
            // pBBalas
            // 
            resources.ApplyResources(this.pBBalas, "pBBalas");
            this.pBBalas.Name = "pBBalas";
            // 
            // lGameOver
            // 
            this.lGameOver.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.lGameOver, "lGameOver");
            this.lGameOver.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lGameOver.Name = "lGameOver";
            // 
            // lInstrucciones
            // 
            this.lInstrucciones.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lInstrucciones.ForeColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.lInstrucciones, "lInstrucciones");
            this.lInstrucciones.Name = "lInstrucciones";
            // 
            // VentanaCementerio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lGameOver);
            this.Controls.Add(this.lInstrucciones);
            this.Controls.Add(this.pBBalas);
            this.Controls.Add(this.pBVida);
            this.Controls.Add(this.lBalasRestantes);
            this.Controls.Add(this.lVidasRestantes);
            this.Controls.Add(this.bRecargar);
            this.Controls.Add(this.lPuntuacion);
            this.Controls.Add(this.AnimacionJuego);
            this.Menu = this.menuCementerio;
            this.MinimizeBox = false;
            this.Name = "VentanaCementerio";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.VentanaCementerio_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer animacion;
        private System.Windows.Forms.Timer activador;
        private System.Windows.Forms.Timer nivel;
        private System.Windows.Forms.Timer segundo;
        private System.Windows.Forms.Label lPuntuacion;
        private MascotaVirtual.Interface.Controles.ControlAnimacion AnimacionJuego;
        private System.Windows.Forms.Button bRecargar;
        private System.Windows.Forms.MainMenu menuCementerio;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem nuevoJuego;
        private System.Windows.Forms.MenuItem Salir;
        private System.Windows.Forms.MenuItem Opciones;
        private System.Windows.Forms.MenuItem verPuntuaciones;
        private System.Windows.Forms.Label lVidasRestantes;
        private System.Windows.Forms.Label lBalasRestantes;
        private System.Windows.Forms.PictureBox pBVida;
        private System.Windows.Forms.PictureBox pBBalas;
        private System.Windows.Forms.Label lGameOver;
        private System.Windows.Forms.Label lInstrucciones;
    }
}