using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MascotaVirtual.Comunicaciones
{
    /// <summary>
    /// Ventana que contiene todas las opciones de las comunicaciones
    /// </summary>
    public class VentanaComunicaciones : Form
    {
        #region Variables
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        #endregion

        #region Dispose
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
        #endregion

        #region Código generado por el Diseñador de Windows Forms
        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaComunicaciones));
            this.pMenuRapido = new System.Windows.Forms.Panel();
            this.bVolver = new System.Windows.Forms.Button();
            this.bSalir = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MainMenu();
            this.teclado = new Microsoft.WindowsCE.Forms.InputPanel();
            this.pMenuRapido.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMenuRapido
            // 
            resources.ApplyResources(this.pMenuRapido, "pMenuRapido");
            this.pMenuRapido.BackColor = System.Drawing.Color.DarkKhaki;
            this.pMenuRapido.Controls.Add(this.bVolver);
            this.pMenuRapido.Controls.Add(this.bSalir);
            this.pMenuRapido.Name = "pMenuRapido";
            // 
            // bVolver
            // 
            resources.ApplyResources(this.bVolver, "bVolver");
            this.bVolver.Name = "bVolver";
            this.bVolver.Click += new System.EventHandler(this.bVolver_Click_1);
            // 
            // bSalir
            // 
            resources.ApplyResources(this.bSalir, "bSalir");
            this.bSalir.Name = "bSalir";
            this.bSalir.Click += new System.EventHandler(this.bVolver_Click);
            // 
            // VentanaComunicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pMenuRapido);
            this.Menu = this.menu;
            this.MinimizeBox = false;
            this.Name = "VentanaComunicaciones";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.VentanaComunicaciones_Closing);
            this.pMenuRapido.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region Delegado y Evento del cierre de la ventana
        /// <summary>
        /// Manejador cuando se cierra la ventana
        /// </summary>
        /// <param name="source">Fuente que solicita su cierre</param>
        /// <param name="e">Argumentos</param>
        public delegate void ManejadorVentanaCerrada(object source, EventArgs e);
        /// <summary>
        /// Evento cuando se cierra la ventana
        /// </summary>
        public event ManejadorVentanaCerrada OnVentanaCerrada;
        #endregion

        #region Delegado y Evento del comienzo de la conexión
        /// <summary>
        /// Manejador cuando se inicia la conexión
        /// </summary>
        /// <param name="source">Fuente</param>
        /// <param name="e">Argumentos</param>
        public delegate void ManejadorInicioComunicacion(object source, IComunicaciones e);
        /// <summary>
        /// Evento cuando se inicia la comunicación
        /// </summary>
        public event ManejadorInicioComunicacion OnInicioComunicacion;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la ventana de comunicaciones
        /// </summary>
        public VentanaComunicaciones()
        {
            InitializeComponent();
            generarPanelSeleccion(this.Width, this.Height-this.pMenuRapido.Height, 0, 0);
            this.Controls.Add(panelConexiones);
            panelConexiones.Visible = true;
        }
        #endregion

        #region Panel Incial
        private Panel pMenuRapido;
        private Button bSalir;
        private TextBox cuadroTexto;
        private bool usuariosEncontrados;

        #region Variables Necesarias
        private IComunicaciones comunicador;
        private Panel panelConexiones;
        private ListBox lListaDispositivos;
        private Button bServir;
        private Button bConectar;
        private MainMenu menu;
        private Microsoft.WindowsCE.Forms.InputPanel teclado;
        private Button bVolver;
        #endregion

        #region Método Generar Panel
        /// <summary>
        /// Genera el panel de seleccion.
        /// </summary>
        /// <param name="ancho">Ancho del panel.</param>
        /// <param name="alto">Alto del panel.</param>
        /// <param name="x_supiz">Coordenada X de la esquina superior izquierda.</param>
        /// <param name="y_supiz">Coordenada Y de la esquina superior izquierda.</param>
        private void generarPanelSeleccion(int ancho, int alto, int x_supiz, int y_supiz)
        {
            panelConexiones = new Panel();
            panelConexiones.BackColor = System.Drawing.Color.PeachPuff;
            panelConexiones.Size = new System.Drawing.Size(ancho, alto);
            panelConexiones.Location = new System.Drawing.Point(x_supiz, y_supiz);
            this.bVolver.Enabled = false;
            agregarBotones();
        }
        #endregion

        #region Método Agregar Botonres
        /// <summary>
        /// Agrega los botones.
        /// </summary>
        private void agregarBotones()
        {
            Button bBluetooth = new Button();
            Button bInfrarrojos = new Button();
            Button bInternet = new Button();

            System.Drawing.Size tamano = new System.Drawing.Size(panelConexiones.Width / 2, panelConexiones.Height / 7);
            bBluetooth.Size = tamano;
            bInfrarrojos.Size = tamano;
            bInternet.Size = tamano;

            bBluetooth.Location = new System.Drawing.Point(panelConexiones.Width / 4, tamano.Height * 1);
            bInfrarrojos.Location = new System.Drawing.Point(panelConexiones.Width / 4, tamano.Height * 3);
            bInternet.Location = new System.Drawing.Point(panelConexiones.Width / 4, tamano.Height * 5);

            bBluetooth.Text = "Bluetooth";
            bInfrarrojos.Text = "Infrarrojos";
            bInternet.Text = "Internet";

            bBluetooth.Click += new EventHandler(bBluetooth_Click);
            bInfrarrojos.Click += new EventHandler(bInfrarrojos_Click);
            bInternet.Click += new EventHandler(bInternet_Click);

            panelConexiones.Controls.Add(bInternet);
            panelConexiones.Controls.Add(bInfrarrojos);
            panelConexiones.Controls.Add(bBluetooth);
        }
        #endregion

        #region Click Selección Bluetooth
        /// <summary>
        /// Selección del bluetooth.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bBluetooth_Click(object sender, EventArgs e)
        {
            comunicador = new Bluetooth();
            cargarMenuBusqueda();
        }
        #endregion

        #region Click Selección Infrarrojos
        /// <summary>
        /// Selección de los infrarrojos.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bInfrarrojos_Click(object sender, EventArgs e)
        {
            comunicador = new Infrarrojos();
            cargarMenuBusqueda();
        }
        #endregion

        #region Click Selección Internet
        /// <summary>
        /// Selección de internet.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bInternet_Click(object sender, EventArgs e)
        {
            comunicador = new Internet();
            cargarMenuInternet();
        }
        #endregion

        #region Carga del Menú de Internet
        /// <summary>
        /// Carga el menu de internet.
        /// </summary>
        private void cargarMenuInternet()
        {
            this.bVolver.Enabled = true;
            panelConexiones.Controls.Clear();
            bServir = new Button();
            bConectar = new Button();

            System.Drawing.Size tamano = new System.Drawing.Size(panelConexiones.Width / 2, panelConexiones.Height / 7);
            bServir.Size = tamano;
            bConectar.Size = tamano;

            bServir.Location = new System.Drawing.Point(panelConexiones.Width/2 - bServir.Width/2, panelConexiones.Height / 9 * 2);
            bConectar.Location = new System.Drawing.Point(panelConexiones.Width/2 - bConectar.Width/2, panelConexiones.Height / 9 * 5);

            bServir.Text = "Servir";
            bConectar.Text = "Conectar";

            Label lIpPropia = new Label();
            lIpPropia.Size = tamano;
            lIpPropia.Location = new Point(panelConexiones.Width / 2 - lIpPropia.Width / 2, panelConexiones.Height / 9);
            lIpPropia.Text = comunicador.GetIP();

            cuadroTexto = new TextBox();
            cuadroTexto.Size = tamano;
            cuadroTexto.Location = new Point(panelConexiones.Width / 2 - cuadroTexto.Width / 2, panelConexiones.Height / 9 * 4);

            //lListaDispositivos.Location = new System.Drawing.Point(panelConexiones.Width / 8, panelConexiones.Height / 9 * 3);

            //bServir.Enabled = false;
            //bConectar.Enabled = false;
            bServir.Click += new EventHandler(bServir_Click);
            bConectar.Click += new EventHandler(bConectar_Click);

            teclado.Enabled = true;

            panelConexiones.Controls.Add(bServir);
            panelConexiones.Controls.Add(bConectar);
            panelConexiones.Controls.Add(cuadroTexto);
            panelConexiones.Controls.Add(lIpPropia);
        }
        #endregion

        #region Carga del Menú de Búsqueda
        /// <summary>
        /// Carga el menu de busqueda.
        /// </summary>
        private void cargarMenuBusqueda()
        {
            this.usuariosEncontrados = false;
            this.bVolver.Enabled = true;
            panelConexiones.Controls.Clear();
            Button bBuscar = new Button();
            bServir = new Button();
            bConectar = new Button();
            this.lListaDispositivos = new ListBox();

            System.Drawing.Size tamano = new System.Drawing.Size(panelConexiones.Width / 2, panelConexiones.Height / 7);
            bBuscar.Size = tamano;
            bServir.Size = tamano;
            bConectar.Size = tamano;

            bBuscar.Location = new System.Drawing.Point(panelConexiones.Width / 4, panelConexiones.Height / 9);
            bServir.Location = new System.Drawing.Point(0, panelConexiones.Height / 9 * 7);
            bConectar.Location = new System.Drawing.Point(panelConexiones.Width / 10 * 5, panelConexiones.Height / 9 * 7);

            bBuscar.Text = "Buscar";
            bServir.Text = "Servir";
            bConectar.Text = "Conectar";

            lListaDispositivos.Size = new System.Drawing.Size(tamano.Width + tamano.Width / 2, tamano.Height * 3);
            lListaDispositivos.Location = new System.Drawing.Point(panelConexiones.Width / 8, panelConexiones.Height / 9 * 3);

            bBuscar.Click += new EventHandler(bBuscar_Click);
            
            lListaDispositivos.SelectedIndexChanged += new EventHandler(lListaDispositivos_SelectedIndexChanged);

            bServir.Enabled = false;
            bConectar.Enabled = false;
            bServir.Click += new EventHandler(bServir_Click);
            bConectar.Click += new EventHandler(bConectar_Click);

            panelConexiones.Controls.Add(bBuscar);
            panelConexiones.Controls.Add(bServir);
            panelConexiones.Controls.Add(bConectar);
            panelConexiones.Controls.Add(lListaDispositivos);
        }
        #endregion

        #region Click para Conectarse
        /// <summary>
        /// Click en el botón de conectarse.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void bConectar_Click(object sender, EventArgs e)
        {
            comunicador.Servidor=false;
            if (comunicador.GetIP() != "")
            {
                comunicador.SetIPRemota(cuadroTexto.Text);
            }
            if (OnInicioComunicacion != null)
            {
                OnInicioComunicacion(this, comunicador);
            }
        }
        #endregion

        #region Click para Servir
        /// <summary>
        /// Click en el botón servir.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void bServir_Click(object sender, EventArgs e)
        {
            comunicador.Servidor=true;
            if (OnInicioComunicacion != null)
            {
                OnInicioComunicacion(this, comunicador);
            }
        }
        #endregion

        #region Seleccionado Objeto en la Lista de Dispositivos
        /// <summary>
        /// Manejador del cambio de dispositivo seleccionado.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void lListaDispositivos_SelectedIndexChanged(object sender, EventArgs e)
        {  
            if (usuariosEncontrados)
            {
                this.comunicador.Seleccionado=lListaDispositivos.SelectedIndex;
                this.bServir.Enabled = true;
                this.bConectar.Enabled = true;
            }
        }
        #endregion

        #region Click Buscar
        /// <summary>
        /// Manejador del click en el botón de buscar dispositivos.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bBuscar_Click(object sender, EventArgs e)
        {
            lListaDispositivos.Items.Clear();
            this.bConectar.Enabled = false;
            this.bServir.Enabled = false;
            System.Collections.ArrayList listaDispositivos = new System.Collections.ArrayList();
            try
            {
                listaDispositivos = comunicador.BuscarDispositivos();

                if (listaDispositivos.Count == 0)
                {
                    this.usuariosEncontrados = false;
                    lListaDispositivos.Items.Add("No encontrados");
                }

                else
                {
                    this.usuariosEncontrados = true;
                    foreach (string cadena in listaDispositivos)
                    {
                        lListaDispositivos.Items.Add(cadena);
                    }
                }
            }
            catch
            {
                lListaDispositivos.Items.Add("Hubo problemas al buscar");
            }
        }
        #endregion

        #region Cuando se cierra la ventana
        /// <summary>
        /// Click en el botón de salir a la ventana principal.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bVolver_Click(object sender, EventArgs e)
        {
            if (OnVentanaCerrada != null)
            {
                OnVentanaCerrada(this,e);
            }
        }

        /// <summary>
        /// Manejador del cierre de la ventana.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void VentanaComunicaciones_Closing(object sender, CancelEventArgs e)
        {
            if (OnVentanaCerrada != null)
            {
                OnVentanaCerrada(this, e);
            }
        }
        #endregion

        #region Click Volver
        /// <summary>
        /// Manejador del click en el botón volver a la ventana anterior.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bVolver_Click_1(object sender, EventArgs e)
        {
            panelConexiones.Dispose();
            generarPanelSeleccion(this.Width, this.Height - this.pMenuRapido.Height, 0, 0);
            this.Controls.Add(panelConexiones);
            panelConexiones.Visible = true;
        }
        #endregion
        #endregion
    }
}