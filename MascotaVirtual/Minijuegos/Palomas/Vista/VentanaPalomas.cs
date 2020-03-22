using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MascotaVirtual.Interface;
using MascotaVirtual.Minijuegos.Puntuaciones;
using MascotaVirtual.Minijuegos.Palomas.Controlador;
using MascotaVirtual.VidaMascota.Modelo;
using MascotaVirtual.Interface.Sonido;

namespace MascotaVirtual.Minijuegos.Palomas.Vista
{
    /// <summary>
    /// Ventana Principal del juego de las palomas
    /// </summary>
    public partial class VentanaPalomas : Form
    {
        #region Delegado y Evento del cierre de la ventana
        /// <summary>
        /// Manejador del cierre de la ventana del juego de las palomas.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorVentanaCerrada(object source, EventArgs e);
        /// <summary>
        /// Evento del cierre de la ventana
        /// </summary>
        public event ManejadorVentanaCerrada OnVentanaCerrada;
        #endregion

        JuegoPalomas juego;
        Sonido disparo;
        Sonido ay;
        VentanaPuntuaciones puntuaciones;
        Mascota mascota;

        #region Constructor
        /// <summary>
        /// Constructor de la ventana del juego de las palomas
        /// </summary>
        public VentanaPalomas()
        {
            InitializeComponent();
            juego = new JuegoPalomas(graficosJuego.Width, graficosJuego.Height);
            disparo = new Sonido("disparo.wav");
            ay = new Sonido("ay.wav");
            juego.OnImagenCambiada += new JuegoPalomas.ManejadorImagenCambiada(juego_OnImagenCambiada);
            juego.OnVidaBajada += new JuegoPalomas.ManejadorVidaBajada(juego_OnVidaBajada);
            puntuaciones = new VentanaPuntuaciones();
            puntuaciones.Inicializar("XMLPuntosPaloma.xml");
        }
        #endregion

        #region Inicializar
        /// <summary>
        /// Inicializamos el valor de la mascota con la que le pasamos por parámetro.
        /// </summary>
        /// <param name="mascota">Mascota del jugador.</param>
        public void Inicializar(Mascota mascota)
        {
            this.mascota = mascota;
        }
        #endregion

        #region Evento cuando baja la vida del zombie
        /// <summary>
        /// Evento del instante cuando la vida del zombie baja.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void juego_OnVidaBajada(object source, EventArgs e)
        {
            this.pBVidaZombie.Value=juego.VidaZombi;
            ay.Play();
            if (pBVidaZombie.Value == 0)
            {
                juego.Parar();
                this.lInstrucciones.Visible = true;
                this.lGameOver.Visible = true;

                this.mascota.AcumuladoAtributoResistenciaFuerza = this.mascota.AcumuladoAtributoResistenciaFuerza + juego.Puntuacion;
                this.mascota.Diversion = this.mascota.Diversion + juego.Puntuacion / 10;
                
                puntuaciones.InsertarPuntos(juego.Puntuacion);
            }
        }
        #endregion

        #region Cuando cambia la Imagen
        /// <summary>
        /// Evento cuando cambia la imagen a mostrar.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void juego_OnImagenCambiada(object source, Bitmap e)
        {
            this.graficosJuego.Muestra(e);
            this.Puntuacion.Text = juego.Puntuacion.ToString();
        }
        #endregion

        #region Tocar la pantalla
        /// <summary>
        /// Evento por el disparo. Se ejecuta cuando el usuario pulsa la pantalla.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento de ratón.</param>
        private void graficosJuego_MouseDown(object sender, MouseEventArgs e)
        {
            disparo.Play();
            juego.Disparar(e.X, e.Y);
        }
        #endregion

        #region Salir
        /// <summary>
        /// Click en el botón salir. Sale del juego.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Salir_Click(object sender, EventArgs e)
        {
            juego.Parar();
            puntuaciones.Serializar();
            if (OnVentanaCerrada != null)
            {
                OnVentanaCerrada(this, e);
            }
        }
        #endregion

        #region Nuevo Juego
        /// <summary>
        /// Click en iniciar un nuevo juego. Inicia un nuevo juego.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void NuevoJuego_Click(object sender, EventArgs e)
        {
            this.lInstrucciones.Visible = false;
            this.lGameOver.Visible = false;
            this.pBVidaZombie.Value = this.juego.VidaZombi;
            this.juego.Empezar();
        }
        #endregion

        #region Ver mejores puntuaciones
        /// <summary>
        /// Click en ver las mejores puntuaciones. Muestra la ventana de mejores puntuaciones.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void verPuntuaciones_Click(object sender, EventArgs e)
        {
            puntuaciones.Show();
        }
        #endregion

        #region Cierre con el aspa
        /// <summary>
        /// Llama a la salida "normal".
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void VentanaPalomas_Closing(object sender, CancelEventArgs e)
        {
            Salir_Click(sender, e);
        }
        #endregion
    }
}