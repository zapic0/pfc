using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MascotaVirtual.Interface;
using MascotaVirtual.Minijuegos.Puntuaciones;
using MascotaVirtual.VidaMascota.Modelo;
using MascotaVirtual.Interface.Sonido;

namespace MascotaVirtual.Minijuegos.Cementerio.Vista
{
    /// <summary>
    /// Ventana para el juego del cementerio (wack-a-mole)
    /// </summary>
    public partial class VentanaCementerio : Form
    {
        #region Variables
        private bool activado;
        private int puntuacion;
        private int fps;
        private Sonido sonidoDisparo;
        private Sonido sonidoRecarga;
        private Sonido sonidoSinBalas;
        private VentanaPuntuaciones puntuaciones;
        private Cementerio.Controlador.Cementerio cementerio;
        private Mascota mascota;
        #endregion

        #region Delegado y Evento del cierre de la ventana
        /// <summary>
        /// Manejador del cierre de la ventana del juego del cementerio.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorVentanaCerrada(object source, EventArgs e);
        /// <summary>
        /// Evento del cierre de la ventana del cementerio
        /// </summary>
        public event ManejadorVentanaCerrada OnVentanaCerrada;
        #endregion

        #region Constructor
        /// <summary>
        /// Crea e inicializa una Ventana de Juego
        /// </summary>
        public VentanaCementerio()
        {
            InitializeComponent();

            sonidoDisparo = new Sonido("disparo.wav");
            sonidoRecarga = new Sonido("recarga.wav");
            sonidoSinBalas = new Sonido("sinbalas.wav");
            cementerio = new Cementerio.Controlador.Cementerio(AnimacionJuego.Width, AnimacionJuego.Height);

            this.AnimacionJuego.Inicializa(AnimacionJuego.Width, AnimacionJuego.Height);
            //this.AnimacionJuego.Inicializa(240, 264);
            fps = 7;
            this.animacion.Interval = 1000 / fps;

            puntuaciones = new VentanaPuntuaciones();
            puntuaciones.Inicializar("XMLPuntosCementerio.xml");
        }
        #endregion

        #region Inicializar
        /// <summary>
        /// Inicializa el valor de la mascota con la que le pasamos por parámetros.
        /// </summary>
        /// <param name="mascota">Mascota del jugador.</param>
        public void Inicializar(Mascota mascota)
        {
            this.mascota = mascota;
        }
        #endregion

        #region Timer Animacion
        /// <summary>
        /// Tick del temporizador que avisa del cambio de frame.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void animacion_Tick(object sender, EventArgs e)
        {
            if (activado)
            {
                for (int i = 0; i < 9; i++)
                {
                    Rectangle destino = this.cementerio.GetDestinoLapida(i);
                    Rectangle fuente = this.cementerio.SourceLapida(i);
                    this.AnimacionJuego.Pinta(destino, fuente);
                    cementerio.PasaFrame(i);
                }
                this.AnimacionJuego.Muestra(Color.Black);
            }

            this.lVidasRestantes.Text = cementerio.Vidas.ToString();

            if(cementerio.Vidas == 0)
            {
                this.animacion.Enabled = false;
                this.activador.Enabled = false;
                this.nivel.Enabled = false;
                activado = false;
                this.puntuaciones.InsertarPuntos(this.puntuacion);

                mascota.AcumuladorAtributoDestrezaIngeligencia = mascota.AcumuladorAtributoDestrezaIngeligencia + puntuacion;
                mascota.Diversion = mascota.Diversion + puntuacion / 10;

                this.lInstrucciones.Visible = true;
                this.lGameOver.Visible = true;
            }
        }
        #endregion

        #region Timer Activador
        /// <summary>
        /// Pasa un turno en el juego, con lo que se activa alguna animación
        /// </summary>
        private void activador_Tick(object sender, EventArgs e)
        {
            cementerio.PasaTurno();
        }
        #endregion

        #region Tocar Control de la Animación
        /// <summary>
        /// Se ejecuta al tocar la animación y se encarga de comprobar si una lápida activa ha sido tocada.
        /// Resta una bala al cargador.
        /// Reproduce el sonido del disparo.
        /// </summary>
        private void AnimacionJuego_MouseDown(object sender, MouseEventArgs e)
        {
            if (cementerio.Escopeta > 0)
            {
                sonidoDisparo.Play();
                bool asesino = cementerio.Matar(e.X, e.Y);
                if (asesino)
                {
                    puntuacion++;
                    this.lPuntuacion.Text = puntuacion.ToString();
                }
                cementerio.Escopeta--;
                this.lBalasRestantes.Text = cementerio.Escopeta.ToString();
            }
            else
            {
                sonidoSinBalas.Play();
            }
        }
        #endregion

        #region Botón Recargar
        /// <summary>
        /// Recarga el cargador de la escopeta a 7 balas.
        /// Reproduce el sonido de recargar.
        /// </summary>
        private void bRecargar_Click(object sender, EventArgs e)
        {
            sonidoRecarga.Play();
            cementerio.Escopeta = 7;
            this.lBalasRestantes.Text = cementerio.Escopeta.ToString();
        }
        #endregion

        #region Timer Nivel
        /// <summary>
        /// Disminuye el intervalo de tiempo que tarda en salir un nuevo enemigo.
        /// </summary>
        private void nivel_Tick(object sender, EventArgs e)
        {
            if (this.activador.Interval >= 600)
            {
                this.activador.Interval = this.activador.Interval - 100;
            }
        }
        #endregion

        #region Timer Segundo
        /// <summary>
        /// Muestra los fps.
        /// </summary>
        private void segundo_Tick(object sender, EventArgs e)
        {
            //this.lFps.Text = fpsReales.ToString();
            //fpsReales = 0;
        }
        #endregion

        #region Opción Ver Puntos
        /// <summary>
        /// Muestra la Ventana de las 10 mejores Puntuaciones.
        /// </summary>
        private void verPuntuaciones_Click(object sender, EventArgs e)
        {
            this.puntuaciones.Show();
        }
        #endregion

        #region Opción Salir
        /// <summary>
        /// Devuelve el control a la ventana principal escondiendo la ventana del cementerio.
        /// </summary>
        private void Salir_Click(object sender, EventArgs e)
        {
            this.puntuaciones.Serializar();
            this.animacion.Enabled = false;
            this.activador.Enabled = false;
            if (OnVentanaCerrada != null)
            {
                OnVentanaCerrada(this, e);
            }
        }
        #endregion

        #region Opción Empezar
        /// <summary>
        /// Inicializa algunos parámetros e inicia el juego.
        /// </summary>
        private void nuevoJuego_Click(object sender, EventArgs e)
        {
            activado = true;

            this.lInstrucciones.Visible = false;
            this.lGameOver.Visible = false;

            this.animacion.Enabled = true;
            this.activador.Enabled = true;
            this.nivel.Enabled = true;

            this.activador.Interval = 2000;
            this.puntuacion = 0;

            this.cementerio.Vidas = 5;
            this.cementerio.Escopeta = 7;

            this.AnimacionJuego.Dibujo = cementerio.ImagenFondo();
            for (int i = 0; i < 9; i++)
            {
                this.cementerio.SetDestinoLapida(i);
            }
        }
        #endregion

        #region Cerrar ventana
        /// <summary>
        /// Sale de la aplicación normalmente.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void VentanaCementerio_Closing(object sender, CancelEventArgs e)
        {
            Salir_Click(sender, e);
        }
        #endregion
    }
}