using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MascotaVirtual.Minijuegos.Pong.Vista
{
    /// <summary>
    /// Ventana del juego del Pong
    /// </summary>
    public partial class VentanaPong : Form
    {
        private MascotaVirtual.Minijuegos.Pong.Controlador.Controlador controlador;

        #region Delegado y Evento del cierre de la ventana
        /// <summary>
        /// Manejador del cierre de la ventana del pong.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorVentanaCerrada(object source, EventArgs e);
        /// <summary>
        /// Evento del cierre de ventana del pong.
        /// </summary>
        public event ManejadorVentanaCerrada OnVentanaCerrada;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VentanaPong()
        {
            InitializeComponent();
            controlador = new Controlador.Controlador();
            this.imagen.Inicializa(imagen.Width, imagen.Height);
            animacion.Enabled = true;
        }
        #endregion

        #region Tick de la animación
        /// <summary>
        /// Maneja el evento Tick del control animacion.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void animacion_Tick(object sender, EventArgs e)
        {
            this.controlador.Mover();
            this.imagen.PintaString(this.controlador.Marcador.ToString(), new Point(0, 0), this.Font);
            this.imagen.PintaRaqueta(this.controlador.RaquetaJugador.Longitud, this.controlador.RaquetaJugador.OcupacionRaqueta,Color.Red);
            this.imagen.PintaRaqueta(this.controlador.RaquetaEnemigo.Longitud, this.controlador.RaquetaEnemigo.OcupacionRaqueta,Color.Blue);
            this.imagen.PintaBala(this.controlador.PosicionBalaJugador(),Color.Red);
            this.imagen.PintaBala(this.controlador.PosicionBalaEnemigo(),Color.Blue);
            this.imagen.PintaBola(this.controlador.Bola.Posicion);
            this.imagen.Muestra();
        }
        #endregion

        #region KeyDown de la Ventana Principal del Pong
        /// <summary>
        /// Maneja cuando pulsamos un botón en la ventana del pong.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento</param>
        private void VentanaPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                this.controlador.Destino = new Point(this.controlador.RaquetaJugador.Posicion.X, controlador.RaquetaJugador.Posicion.Y-1);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                this.controlador.Destino = new Point(this.controlador.RaquetaJugador.Posicion.X, controlador.RaquetaJugador.Posicion.Y+2);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                int destinoX = this.controlador.Destino.X;
                int destinoY = this.controlador.Destino.Y;
                this.controlador.Destino = new Point(destinoX-1, destinoY);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                int destinoX = this.controlador.Destino.X;
                int destinoY = this.controlador.Destino.Y;
                this.controlador.Destino = new Point(destinoX + 1, destinoY);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                this.controlador.Disparar();
            }
        }
        #endregion

        #region Click en Salir
        /// <summary>
        /// Manejador del evento de hacer click en el botón Salir.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void ISalir_Click(object sender, EventArgs e)
        {
            this.animacion.Enabled = false;
            if (OnVentanaCerrada != null)
            {
                OnVentanaCerrada(this, e);
            }
        }
        #endregion

        #region Pulsar en la imagen
        /// <summary>
        /// Maneja el evento MouseDown en el control imagen.
        /// Cuando pulsamos, marca el lugar pulsado como destino de la raqueta.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void imagen_MouseDown(object sender, MouseEventArgs e)
        {
            controlador.Destino = new Point(e.X, e.Y);
        }
        #endregion

        #region Cierre con el aspa
        /// <summary>
        /// Llama al cierre "normal" del juego.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void VentanaPong_Closing(object sender, CancelEventArgs e)
        {
            ISalir_Click(sender, e);
        }
        #endregion
    }
}