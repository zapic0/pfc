namespace MascotaVirtual.VidaMascota.Vista
{
    partial class VentanaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu MenuVentanaPrincipal;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPrincipal));
            this.pInventario = new System.Windows.Forms.Panel();
            this.bEliminar = new System.Windows.Forms.Button();
            this.bUsar = new System.Windows.Forms.Button();
            this.lTextoCapacidad = new System.Windows.Forms.Label();
            this.lCapacidad = new System.Windows.Forms.Label();
            this.lNombreSeleccionado = new System.Windows.Forms.Label();
            this.pBSeleccionado = new System.Windows.Forms.PictureBox();
            this.tInventario = new System.Windows.Forms.TabControl();
            this.tAlimentos = new System.Windows.Forms.TabPage();
            this.tCuraciones = new System.Windows.Forms.TabPage();
            this.tLimpiadores = new System.Windows.Forms.TabPage();
            this.tEducadores = new System.Windows.Forms.TabPage();
            this.tOtros = new System.Windows.Forms.TabPage();
            this.MenuVentanaPrincipal = new System.Windows.Forms.MainMenu();
            this.MIArchivo = new System.Windows.Forms.MenuItem();
            this.MISalir = new System.Windows.Forms.MenuItem();
            this.MIOpciones = new System.Windows.Forms.MenuItem();
            this.MIVerInventario = new System.Windows.Forms.MenuItem();
            this.mIGenerarNuevaMascota = new System.Windows.Forms.MenuItem();
            this.mICompras = new System.Windows.Forms.MenuItem();
            this.mIAlimentos = new System.Windows.Forms.MenuItem();
            this.mIBocadillo = new System.Windows.Forms.MenuItem();
            this.mICerebro = new System.Windows.Forms.MenuItem();
            this.mICuraciones = new System.Windows.Forms.MenuItem();
            this.mIBotiquin = new System.Windows.Forms.MenuItem();
            this.mIPildora = new System.Windows.Forms.MenuItem();
            this.mITermometro = new System.Windows.Forms.MenuItem();
            this.mILimpieza = new System.Windows.Forms.MenuItem();
            this.mIPatito = new System.Windows.Forms.MenuItem();
            this.mIEducacion = new System.Windows.Forms.MenuItem();
            this.mILibro = new System.Windows.Forms.MenuItem();
            this.mIOtros = new System.Windows.Forms.MenuItem();
            this.BVerInventario = new System.Windows.Forms.Button();
            this.PInformacion = new System.Windows.Forms.Panel();
            this.lDinero = new System.Windows.Forms.Label();
            this.pBDinero = new System.Windows.Forms.PictureBox();
            this.LNumeroNivel = new System.Windows.Forms.Label();
            this.LNivel = new System.Windows.Forms.Label();
            this.LPuntosVida = new System.Windows.Forms.Label();
            this.LDiversion = new System.Windows.Forms.Label();
            this.LEducacion = new System.Windows.Forms.Label();
            this.LSalud = new System.Windows.Forms.Label();
            this.LHigiene = new System.Windows.Forms.Label();
            this.LHambre = new System.Windows.Forms.Label();
            this.pBHigiene = new System.Windows.Forms.ProgressBar();
            this.pBDiversion = new System.Windows.Forms.ProgressBar();
            this.pBEducacion = new System.Windows.Forms.ProgressBar();
            this.pBSalud = new System.Windows.Forms.ProgressBar();
            this.pBPuntosVida = new System.Windows.Forms.ProgressBar();
            this.pBHambre = new System.Windows.Forms.ProgressBar();
            this.PBotones = new System.Windows.Forms.Panel();
            this.bConexiones = new System.Windows.Forms.Button();
            this.BJuegos = new System.Windows.Forms.Button();
            this.PGraficos = new System.Windows.Forms.Panel();
            this.graficoAnimacion = new MascotaVirtual.Interface.Controles.ControlGrafico();
            this.pInventario.SuspendLayout();
            this.tInventario.SuspendLayout();
            this.PInformacion.SuspendLayout();
            this.PBotones.SuspendLayout();
            this.PGraficos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pInventario
            // 
            resources.ApplyResources(this.pInventario, "pInventario");
            this.pInventario.BackColor = System.Drawing.Color.LightYellow;
            this.pInventario.Controls.Add(this.bEliminar);
            this.pInventario.Controls.Add(this.bUsar);
            this.pInventario.Controls.Add(this.lTextoCapacidad);
            this.pInventario.Controls.Add(this.lCapacidad);
            this.pInventario.Controls.Add(this.lNombreSeleccionado);
            this.pInventario.Controls.Add(this.pBSeleccionado);
            this.pInventario.Controls.Add(this.tInventario);
            this.pInventario.Name = "pInventario";
            // 
            // bEliminar
            // 
            resources.ApplyResources(this.bEliminar, "bEliminar");
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // bUsar
            // 
            resources.ApplyResources(this.bUsar, "bUsar");
            this.bUsar.Name = "bUsar";
            this.bUsar.Click += new System.EventHandler(this.bUsar_Click);
            // 
            // lTextoCapacidad
            // 
            resources.ApplyResources(this.lTextoCapacidad, "lTextoCapacidad");
            this.lTextoCapacidad.Name = "lTextoCapacidad";
            // 
            // lCapacidad
            // 
            resources.ApplyResources(this.lCapacidad, "lCapacidad");
            this.lCapacidad.Name = "lCapacidad";
            // 
            // lNombreSeleccionado
            // 
            resources.ApplyResources(this.lNombreSeleccionado, "lNombreSeleccionado");
            this.lNombreSeleccionado.Name = "lNombreSeleccionado";
            // 
            // pBSeleccionado
            // 
            resources.ApplyResources(this.pBSeleccionado, "pBSeleccionado");
            this.pBSeleccionado.Name = "pBSeleccionado";
            // 
            // tInventario
            // 
            resources.ApplyResources(this.tInventario, "tInventario");
            this.tInventario.Controls.Add(this.tAlimentos);
            this.tInventario.Controls.Add(this.tCuraciones);
            this.tInventario.Controls.Add(this.tLimpiadores);
            this.tInventario.Controls.Add(this.tEducadores);
            this.tInventario.Controls.Add(this.tOtros);
            this.tInventario.Name = "tInventario";
            this.tInventario.SelectedIndex = 0;
            // 
            // tAlimentos
            // 
            resources.ApplyResources(this.tAlimentos, "tAlimentos");
            this.tAlimentos.BackColor = System.Drawing.Color.PeachPuff;
            this.tAlimentos.Name = "tAlimentos";
            // 
            // tCuraciones
            // 
            resources.ApplyResources(this.tCuraciones, "tCuraciones");
            this.tCuraciones.BackColor = System.Drawing.Color.PeachPuff;
            this.tCuraciones.Name = "tCuraciones";
            // 
            // tLimpiadores
            // 
            resources.ApplyResources(this.tLimpiadores, "tLimpiadores");
            this.tLimpiadores.BackColor = System.Drawing.Color.PeachPuff;
            this.tLimpiadores.Name = "tLimpiadores";
            // 
            // tEducadores
            // 
            resources.ApplyResources(this.tEducadores, "tEducadores");
            this.tEducadores.BackColor = System.Drawing.Color.PeachPuff;
            this.tEducadores.Name = "tEducadores";
            // 
            // tOtros
            // 
            resources.ApplyResources(this.tOtros, "tOtros");
            this.tOtros.BackColor = System.Drawing.Color.PeachPuff;
            this.tOtros.Name = "tOtros";
            // 
            // MenuVentanaPrincipal
            // 
            this.MenuVentanaPrincipal.MenuItems.Add(this.MIArchivo);
            this.MenuVentanaPrincipal.MenuItems.Add(this.MIOpciones);
            this.MenuVentanaPrincipal.MenuItems.Add(this.mICompras);
            // 
            // MIArchivo
            // 
            resources.ApplyResources(this.MIArchivo, "MIArchivo");
            this.MIArchivo.MenuItems.Add(this.MISalir);
            // 
            // MISalir
            // 
            resources.ApplyResources(this.MISalir, "MISalir");
            this.MISalir.Click += new System.EventHandler(this.MISalir_Click);
            // 
            // MIOpciones
            // 
            resources.ApplyResources(this.MIOpciones, "MIOpciones");
            this.MIOpciones.MenuItems.Add(this.MIVerInventario);
            this.MIOpciones.MenuItems.Add(this.mIGenerarNuevaMascota);
            // 
            // MIVerInventario
            // 
            resources.ApplyResources(this.MIVerInventario, "MIVerInventario");
            this.MIVerInventario.Click += new System.EventHandler(this.MIVerInventario_Click);
            // 
            // mIGenerarNuevaMascota
            // 
            resources.ApplyResources(this.mIGenerarNuevaMascota, "mIGenerarNuevaMascota");
            this.mIGenerarNuevaMascota.Click += new System.EventHandler(this.mIGenerarNuevaMascota_Click);
            // 
            // mICompras
            // 
            resources.ApplyResources(this.mICompras, "mICompras");
            this.mICompras.MenuItems.Add(this.mIAlimentos);
            this.mICompras.MenuItems.Add(this.mICuraciones);
            this.mICompras.MenuItems.Add(this.mILimpieza);
            this.mICompras.MenuItems.Add(this.mIEducacion);
            this.mICompras.MenuItems.Add(this.mIOtros);
            // 
            // mIAlimentos
            // 
            resources.ApplyResources(this.mIAlimentos, "mIAlimentos");
            this.mIAlimentos.MenuItems.Add(this.mIBocadillo);
            this.mIAlimentos.MenuItems.Add(this.mICerebro);
            // 
            // mIBocadillo
            // 
            resources.ApplyResources(this.mIBocadillo, "mIBocadillo");
            this.mIBocadillo.Click += new System.EventHandler(this.mIBocadillo_Click);
            // 
            // mICerebro
            // 
            resources.ApplyResources(this.mICerebro, "mICerebro");
            this.mICerebro.Click += new System.EventHandler(this.mICerebro_Click);
            // 
            // mICuraciones
            // 
            resources.ApplyResources(this.mICuraciones, "mICuraciones");
            this.mICuraciones.MenuItems.Add(this.mIBotiquin);
            this.mICuraciones.MenuItems.Add(this.mIPildora);
            this.mICuraciones.MenuItems.Add(this.mITermometro);
            // 
            // mIBotiquin
            // 
            resources.ApplyResources(this.mIBotiquin, "mIBotiquin");
            this.mIBotiquin.Click += new System.EventHandler(this.mIBotiquin_Click);
            // 
            // mIPildora
            // 
            resources.ApplyResources(this.mIPildora, "mIPildora");
            this.mIPildora.Click += new System.EventHandler(this.mIPildora_Click);
            // 
            // mITermometro
            // 
            resources.ApplyResources(this.mITermometro, "mITermometro");
            this.mITermometro.Click += new System.EventHandler(this.mITermometro_Click);
            // 
            // mILimpieza
            // 
            resources.ApplyResources(this.mILimpieza, "mILimpieza");
            this.mILimpieza.MenuItems.Add(this.mIPatito);
            // 
            // mIPatito
            // 
            resources.ApplyResources(this.mIPatito, "mIPatito");
            this.mIPatito.Click += new System.EventHandler(this.mIPatito_Click);
            // 
            // mIEducacion
            // 
            resources.ApplyResources(this.mIEducacion, "mIEducacion");
            this.mIEducacion.MenuItems.Add(this.mILibro);
            // 
            // mILibro
            // 
            resources.ApplyResources(this.mILibro, "mILibro");
            this.mILibro.Click += new System.EventHandler(this.mILibro_Click);
            // 
            // mIOtros
            // 
            resources.ApplyResources(this.mIOtros, "mIOtros");
            // 
            // BVerInventario
            // 
            resources.ApplyResources(this.BVerInventario, "BVerInventario");
            this.BVerInventario.Name = "BVerInventario";
            this.BVerInventario.Click += new System.EventHandler(this.BVerInventario_Click);
            // 
            // PInformacion
            // 
            resources.ApplyResources(this.PInformacion, "PInformacion");
            this.PInformacion.BackColor = System.Drawing.Color.DarkKhaki;
            this.PInformacion.Controls.Add(this.lDinero);
            this.PInformacion.Controls.Add(this.pBDinero);
            this.PInformacion.Controls.Add(this.LNumeroNivel);
            this.PInformacion.Controls.Add(this.LNivel);
            this.PInformacion.Controls.Add(this.LPuntosVida);
            this.PInformacion.Controls.Add(this.LDiversion);
            this.PInformacion.Controls.Add(this.LEducacion);
            this.PInformacion.Controls.Add(this.LSalud);
            this.PInformacion.Controls.Add(this.LHigiene);
            this.PInformacion.Controls.Add(this.LHambre);
            this.PInformacion.Controls.Add(this.pBHigiene);
            this.PInformacion.Controls.Add(this.pBDiversion);
            this.PInformacion.Controls.Add(this.pBEducacion);
            this.PInformacion.Controls.Add(this.pBSalud);
            this.PInformacion.Controls.Add(this.pBPuntosVida);
            this.PInformacion.Controls.Add(this.pBHambre);
            this.PInformacion.Name = "PInformacion";
            // 
            // lDinero
            // 
            resources.ApplyResources(this.lDinero, "lDinero");
            this.lDinero.BackColor = System.Drawing.Color.DarkKhaki;
            this.lDinero.Name = "lDinero";
            // 
            // pBDinero
            // 
            resources.ApplyResources(this.pBDinero, "pBDinero");
            this.pBDinero.BackColor = System.Drawing.Color.DarkKhaki;
            this.pBDinero.Name = "pBDinero";
            // 
            // LNumeroNivel
            // 
            resources.ApplyResources(this.LNumeroNivel, "LNumeroNivel");
            this.LNumeroNivel.Name = "LNumeroNivel";
            // 
            // LNivel
            // 
            resources.ApplyResources(this.LNivel, "LNivel");
            this.LNivel.Name = "LNivel";
            // 
            // LPuntosVida
            // 
            resources.ApplyResources(this.LPuntosVida, "LPuntosVida");
            this.LPuntosVida.Name = "LPuntosVida";
            // 
            // LDiversion
            // 
            resources.ApplyResources(this.LDiversion, "LDiversion");
            this.LDiversion.Name = "LDiversion";
            // 
            // LEducacion
            // 
            resources.ApplyResources(this.LEducacion, "LEducacion");
            this.LEducacion.Name = "LEducacion";
            // 
            // LSalud
            // 
            resources.ApplyResources(this.LSalud, "LSalud");
            this.LSalud.Name = "LSalud";
            // 
            // LHigiene
            // 
            resources.ApplyResources(this.LHigiene, "LHigiene");
            this.LHigiene.Name = "LHigiene";
            // 
            // LHambre
            // 
            resources.ApplyResources(this.LHambre, "LHambre");
            this.LHambre.Name = "LHambre";
            // 
            // pBHigiene
            // 
            resources.ApplyResources(this.pBHigiene, "pBHigiene");
            this.pBHigiene.Name = "pBHigiene";
            // 
            // pBDiversion
            // 
            resources.ApplyResources(this.pBDiversion, "pBDiversion");
            this.pBDiversion.Name = "pBDiversion";
            // 
            // pBEducacion
            // 
            resources.ApplyResources(this.pBEducacion, "pBEducacion");
            this.pBEducacion.Name = "pBEducacion";
            // 
            // pBSalud
            // 
            resources.ApplyResources(this.pBSalud, "pBSalud");
            this.pBSalud.Name = "pBSalud";
            // 
            // pBPuntosVida
            // 
            resources.ApplyResources(this.pBPuntosVida, "pBPuntosVida");
            this.pBPuntosVida.Maximum = 1000;
            this.pBPuntosVida.Name = "pBPuntosVida";
            // 
            // pBHambre
            // 
            resources.ApplyResources(this.pBHambre, "pBHambre");
            this.pBHambre.Name = "pBHambre";
            // 
            // PBotones
            // 
            resources.ApplyResources(this.PBotones, "PBotones");
            this.PBotones.BackColor = System.Drawing.Color.DarkKhaki;
            this.PBotones.Controls.Add(this.bConexiones);
            this.PBotones.Controls.Add(this.BJuegos);
            this.PBotones.Controls.Add(this.BVerInventario);
            this.PBotones.Name = "PBotones";
            // 
            // bConexiones
            // 
            resources.ApplyResources(this.bConexiones, "bConexiones");
            this.bConexiones.Name = "bConexiones";
            this.bConexiones.Click += new System.EventHandler(this.Juegos_Click);
            // 
            // BJuegos
            // 
            resources.ApplyResources(this.BJuegos, "BJuegos");
            this.BJuegos.Name = "BJuegos";
            this.BJuegos.Click += new System.EventHandler(this.Juegos_Click);
            // 
            // PGraficos
            // 
            resources.ApplyResources(this.PGraficos, "PGraficos");
            this.PGraficos.Controls.Add(this.pInventario);
            this.PGraficos.Controls.Add(this.PBotones);
            this.PGraficos.Controls.Add(this.graficoAnimacion);
            this.PGraficos.Name = "PGraficos";
            // 
            // graficoAnimacion
            // 
            resources.ApplyResources(this.graficoAnimacion, "graficoAnimacion");
            this.graficoAnimacion.Name = "graficoAnimacion";
            this.graficoAnimacion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graficoAnimacion_MouseDown);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.PGraficos);
            this.Controls.Add(this.PInformacion);
            this.KeyPreview = true;
            this.Menu = this.MenuVentanaPrincipal;
            this.Name = "VentanaPrincipal";
            this.Load += new System.EventHandler(this.VentanaPrincipal_Load);
            this.pInventario.ResumeLayout(false);
            this.tInventario.ResumeLayout(false);
            this.PInformacion.ResumeLayout(false);
            this.PBotones.ResumeLayout(false);
            this.PGraficos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem MIArchivo;
        private System.Windows.Forms.MenuItem MISalir;
        private System.Windows.Forms.MenuItem MIOpciones;
        private System.Windows.Forms.MenuItem MIVerInventario;
        private System.Windows.Forms.Panel PInformacion;
        private System.Windows.Forms.Panel PBotones;
        private System.Windows.Forms.Panel PGraficos;
        private System.Windows.Forms.ProgressBar pBHambre;
        private System.Windows.Forms.ProgressBar pBSalud;
        private System.Windows.Forms.ProgressBar pBPuntosVida;
        private System.Windows.Forms.ProgressBar pBDiversion;
        private System.Windows.Forms.ProgressBar pBEducacion;
        private System.Windows.Forms.ProgressBar pBHigiene;
        private System.Windows.Forms.Label LHambre;
        private System.Windows.Forms.Label LEducacion;
        private System.Windows.Forms.Label LSalud;
        private System.Windows.Forms.Label LHigiene;
        private System.Windows.Forms.Label LDiversion;
        private System.Windows.Forms.Label LNumeroNivel;
        private System.Windows.Forms.Label LNivel;
        private System.Windows.Forms.Label LPuntosVida;
        private System.Windows.Forms.Button BJuegos;
        private MascotaVirtual.Interface.Controles.ControlGrafico graficoAnimacion;
        private System.Windows.Forms.Button BVerInventario;
        private System.Windows.Forms.TabPage tAlimentos;
        private System.Windows.Forms.TabPage tCuraciones;
        private System.Windows.Forms.TabPage tLimpiadores;
        private System.Windows.Forms.TabPage tEducadores;
        private System.Windows.Forms.TabPage tOtros;
        private System.Windows.Forms.PictureBox pBSeleccionado;
        private System.Windows.Forms.Label lNombreSeleccionado;
        private System.Windows.Forms.Label lTextoCapacidad;
        private System.Windows.Forms.Label lCapacidad;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Button bUsar;
        private System.Windows.Forms.Button bConexiones;
        private System.Windows.Forms.Panel pInventario;
        private System.Windows.Forms.TabControl tInventario;
        private System.Windows.Forms.PictureBox pBDinero;
        private System.Windows.Forms.Label lDinero;
        private System.Windows.Forms.MenuItem mIGenerarNuevaMascota;
        private System.Windows.Forms.MenuItem mICompras;
        private System.Windows.Forms.MenuItem mIAlimentos;
        private System.Windows.Forms.MenuItem mICuraciones;
        private System.Windows.Forms.MenuItem mILimpieza;
        private System.Windows.Forms.MenuItem mIEducacion;
        private System.Windows.Forms.MenuItem mIOtros;
        private System.Windows.Forms.MenuItem mIBocadillo;
        private System.Windows.Forms.MenuItem mICerebro;
        private System.Windows.Forms.MenuItem mIBotiquin;
        private System.Windows.Forms.MenuItem mIPildora;
        private System.Windows.Forms.MenuItem mITermometro;
        private System.Windows.Forms.MenuItem mIPatito;
        private System.Windows.Forms.MenuItem mILibro;
    }
}