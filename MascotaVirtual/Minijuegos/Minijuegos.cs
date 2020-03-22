using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MascotaVirtual.Minijuegos
{
    /// <summary>
    /// Ventana que da el paso a los diferentes minijuegos
    /// </summary>
    public partial class Minijuegos : Form
    {
        #region Delegado y Evento del cierre de la ventana
        /// <summary>
        /// Manejador del cierre de la ventana
        /// </summary>
        /// <param name="source">Fuente que solicita el cierre</param>
        /// <param name="e">Argumentos</param>
        public delegate void ManejadorVentanaCerrada(object source, EventArgs e);
        /// <summary>
        /// Evento cuando se cierra la ventana
        /// </summary>
        public event ManejadorVentanaCerrada OnVentanaCerrada;
        #endregion

        #region Delegado y Evento del inicio de juego del Cementerio
        /// <summary>
        /// Manejador cuando se inicia el juego del cementerio
        /// </summary>
        /// <param name="source">Fuente que solicita el inicio</param>
        /// <param name="e">Argumentos</param>
        public delegate void ManejadorInicioCementerio(object source, EventArgs e);
        /// <summary>
        /// Evento cuando se inicia el juego del cementerio
        /// </summary>
        public event ManejadorInicioCementerio OnInicioCementerio;
        #endregion

        #region Delegado y Evento del inicio de juego de las Palomas
        /// <summary>
        /// Manejador cuando se inicia el juego de las palomas
        /// </summary>
        /// <param name="source">Fuente que solicita el inicio</param>
        /// <param name="e">Argumentos</param>
        public delegate void ManejadorInicioPalomas(object source, EventArgs e);
        /// <summary>
        /// Evento cuando se inicia el juego de las palomas
        /// </summary>
        public event ManejadorInicioPalomas OnInicioPalomas;
        #endregion

        #region Delegado y Evento del inicio del Pong
        /// <summary>
        /// Manejador cuando se inicia el juego del Pong
        /// </summary>
        /// <param name="source">Fuente que solicita el inicio</param>
        /// <param name="e">Argumentos</param>
        public delegate void ManejadorInicioPong(object source, EventArgs e);
        /// <summary>
        /// Evento del inicio del pong
        /// </summary>
        public event ManejadorInicioPong OnInicioPong;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de los minijuegos
        /// </summary>
        public Minijuegos()
        {
            InitializeComponent();
        }
        #endregion

        #region Iniciar Cementerio
        /// <summary>
        /// Manejador click botón cementerio. Inicio del cementerio.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bCementerio_Click(object sender, EventArgs e)
        {
            if (OnInicioCementerio != null)
            {
                OnInicioCementerio(this, e);
            }
        }
        #endregion

        #region Iniciar Palomas
        /// <summary>
        /// Manejador click botón Palomas. Inicio del juego de las palomas.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bPalomas_Click(object sender, EventArgs e)
        {
            if (OnInicioPalomas != null)
            {
                OnInicioPalomas(this, e);
            }
        }
        #endregion

        #region Iniciar Pong
        /// <summary>
        /// Manejador click botón Pong. Inicio del juego del Pong.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bPong_Click(object sender, EventArgs e)
        {
            if (OnInicioPong != null)
            {
                OnInicioPong(this, e);
            }
        }
        #endregion

        #region Salir
        /// <summary>
        /// Manejador click botón salir. Cierre de la ventana.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bSalir_Click(object sender, EventArgs e)
        {
            if (OnVentanaCerrada != null)
            {
                OnVentanaCerrada(this, e);
            }
        }
        #endregion
    }
}