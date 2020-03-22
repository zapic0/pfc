using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MascotaVirtual.VidaMascota;
using MascotaVirtual.VidaMascota.Modelo.Objetos;
using MascotaVirtual.Interface;
using System.Threading;
using MascotaVirtual.Comunicaciones;
using MascotaVirtual.VidaMascota.Controlador;
using MascotaVirtual.VidaMascota.Modelo;

namespace MascotaVirtual.Ventanas
{
    /// <summary>
    /// Clase que controla la apertura y cierre de las demás ventanas.
    /// Tiene en memoria la mascota y su controlador y va generando las ventanas que se requieren en cada momento.
    /// Una vez que se cierra una ventana, la elimina de la memoria.
    /// </summary>
    public class ControlVentanas
    {
        Mascota mascota;
        ControladorVida controlador;

        #region Ventanas
        VidaMascota.Vista.VentanaPrincipal ventanaPrincipal;
        Minijuegos.Minijuegos ventanaMinijuegos;
        Minijuegos.Cementerio.Vista.VentanaCementerio ventanaCementerio;
        Minijuegos.Palomas.Vista.VentanaPalomas ventanaPalomas;
        Minijuegos.Pong.Vista.VentanaPong ventanaPong;
        Comunicaciones.VentanaComunicaciones ventanaComunicaciones;
        Comunicaciones.ChatSeleccion chat;
        Comunicaciones.CompraVenta compraVenta;
        Comunicaciones.Batalla.Vista.VentanaBatalla ventanaBatalla;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ControlVentanas()
        {
            int iniMascota, finMascota, iniControlador, finControlador, iniVentana, finVentana;
            int tiempoMascota, tiempoControlador, tiempoVentana;

            iniMascota = Environment.TickCount;
            mascota = new Mascota();
            GC.Collect();
            finMascota = Environment.TickCount;
            tiempoMascota = finMascota - iniMascota;
            
            iniControlador = Environment.TickCount;
            controlador = new ControladorVida(mascota);
            finControlador = Environment.TickCount;
            tiempoControlador = finControlador - iniControlador;

            iniVentana = Environment.TickCount;
            ventanaPrincipal = new MascotaVirtual.VidaMascota.Vista.VentanaPrincipal(controlador, mascota);
            ventanaPrincipal.OnVentanaCambiada += new MascotaVirtual.VidaMascota.Vista.VentanaPrincipal.ManejadorVentanaCambiada(ventanaPrincipal_OnVentanaCambiada);
            finVentana = Environment.TickCount;
            tiempoVentana = finVentana - iniVentana;
        }
        #endregion

        #region Iniciar Juegos
        /// <summary>
        /// Inicia la ventana de selección de juegos
        /// </summary>
        void IniciarJugar()
        {
            ventanaMinijuegos = new MascotaVirtual.Minijuegos.Minijuegos();
            ventanaMinijuegos.Show();
            ventanaMinijuegos.OnVentanaCerrada += new MascotaVirtual.Minijuegos.Minijuegos.ManejadorVentanaCerrada(ventanaMinijuegos_OnVentanaCerrada);
            ventanaMinijuegos.OnInicioCementerio += new MascotaVirtual.Minijuegos.Minijuegos.ManejadorInicioCementerio(ventanaMinijuegos_OnInicioCementerio);
            ventanaMinijuegos.OnInicioPalomas += new MascotaVirtual.Minijuegos.Minijuegos.ManejadorInicioPalomas(ventanaMinijuegos_OnInicioPalomas);
            ventanaMinijuegos.OnInicioPong += new MascotaVirtual.Minijuegos.Minijuegos.ManejadorInicioPong(ventanaMinijuegos_OnInicioPong);
        }
        #endregion

        #region Manejador del inicio del pong
        /// <summary>
        /// Manejador del inicio del pong de la ventana de juegos.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void ventanaMinijuegos_OnInicioPong(object source, EventArgs e)
        {
            ventanaMinijuegos.Dispose();
            ventanaMinijuegos = null;

            ventanaPong = new MascotaVirtual.Minijuegos.Pong.Vista.VentanaPong();
            ventanaPong.Show();
            ventanaPong.OnVentanaCerrada += new MascotaVirtual.Minijuegos.Pong.Vista.VentanaPong.ManejadorVentanaCerrada(ventanaPong_OnVentanaCerrada);
        }
        #endregion

        #region Manejador del cierre de la ventana del Pong
        /// <summary>
        /// Manejador del cierre de la ventana del Pong (cierra la ventana).
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void ventanaPong_OnVentanaCerrada(object source, EventArgs e)
        {
            ventanaPong.Dispose();
            ventanaPong = null;
        }
        #endregion

        #region Manejador del inicio del juego de las palomas
        /// <summary>
        /// Manejador del inicio del juego de las palomas.
        /// Cierra la ventana de selección de juegos y crea la nueva ventana.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void ventanaMinijuegos_OnInicioPalomas(object source, EventArgs e)
        {
            ventanaMinijuegos.Dispose();
            ventanaMinijuegos = null;

            ventanaPalomas = new MascotaVirtual.Minijuegos.Palomas.Vista.VentanaPalomas();
            ventanaPalomas.Inicializar(mascota);
            ventanaPalomas.Show();
            ventanaPalomas.OnVentanaCerrada += new MascotaVirtual.Minijuegos.Palomas.Vista.VentanaPalomas.ManejadorVentanaCerrada(ventanaPalomas_OnVentanaCerrada);
        }
        #endregion

        #region Manejador del cierre de la ventana del juego de las palomas
        /// <summary>
        /// Manejador del cierre de la ventana del juego de las palomas (cierra la ventana).
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void ventanaPalomas_OnVentanaCerrada(object source, EventArgs e)
        {
            ventanaPalomas.Dispose();
            ventanaPalomas = null;
        }
        #endregion

        #region Manejador del inicio del juego del cementerio
        /// <summary>
        /// Manejador del inicio del juego del cementerio.
        /// Cierra la ventana de selección de juegos y crea la nueva ventana.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void ventanaMinijuegos_OnInicioCementerio(object source, EventArgs e)
        {
            ventanaMinijuegos.Dispose();
            ventanaMinijuegos = null;

            ventanaCementerio = new MascotaVirtual.Minijuegos.Cementerio.Vista.VentanaCementerio();
            ventanaCementerio.Inicializar(mascota);

            ventanaCementerio.Show();
            ventanaCementerio.OnVentanaCerrada += new MascotaVirtual.Minijuegos.Cementerio.Vista.VentanaCementerio.ManejadorVentanaCerrada(ventanaCementerio_OnVentanaCerrada);
        }
        #endregion

        #region Manejador del cierre de la ventana de los juegos
        /// <summary>
        /// Manejador del cierre de la ventana de juegos.
        /// Cierra la ventana de selección de juegos.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void ventanaMinijuegos_OnVentanaCerrada(object source, EventArgs e)
        {
            ventanaMinijuegos.Dispose();
            ventanaMinijuegos = null;
        }
        #endregion

        #region Manejador del cambio de ventanas desde la principal
        /// <summary>
        /// Manejador del cambio de ventanas desde la ventana principal.
        /// En función del botón pulsado iniciará la ventana de conexiones o la de juegos.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void ventanaPrincipal_OnVentanaCambiada(object source, string e)
        {
            switch (e)
            {
                case "Jugar": IniciarJugar();
                    break;
                case "Conexiones":
                    ventanaComunicaciones = new MascotaVirtual.Comunicaciones.VentanaComunicaciones();
                    ventanaComunicaciones.Show();
                    ventanaComunicaciones.OnInicioComunicacion += new MascotaVirtual.Comunicaciones.VentanaComunicaciones.ManejadorInicioComunicacion(ventanaComunicaciones_OnInicioComunicacion);
                    ventanaComunicaciones.OnVentanaCerrada += new MascotaVirtual.Comunicaciones.VentanaComunicaciones.ManejadorVentanaCerrada(ventanaComunicaciones_OnVentanaCerrada);
                    break;
            }
        }
        #endregion

        #region Manejador del inicio de la ventana del chat
        /// <summary>
        /// Manejador del inicio de la ventana del chat.
        /// Cierra la ventana de selección de comunicaciones y crea la nueva ventana.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void ventanaComunicaciones_OnInicioComunicacion(object source, MascotaVirtual.Comunicaciones.IComunicaciones e)
        {
            chat = new MascotaVirtual.Comunicaciones.ChatSeleccion();
            chat.OnVentanaCerrada += new MascotaVirtual.Comunicaciones.ChatSeleccion.ManejadorVentanaCerrada(chat_OnVentanaCerrada);
            chat.OnPasoIntercambio += new MascotaVirtual.Comunicaciones.ChatSeleccion.ManejadorPasoIntercambio(chat_OnPasoIntercambio);
            chat.OnPasoJuego += new ChatSeleccion.ManejadorPasoJuego(chat_OnPasoJuego);
            chat.SetComunicador(e);
            chat.Iniciar();
            chat.Enabled = true;
            chat.Show();
            ventanaComunicaciones.Dispose();
            ventanaComunicaciones = null;
        }
        #endregion

        #region Manejador del inicio del intercambio de objetos
        /// <summary>
        /// Manejador del inicio de intercambio de objetos.
        /// Cierra la ventana de chat y crea la nueva ventana.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="comunicador">Comunicador que se utilizará en el intercambio.</param>
        void chat_OnPasoIntercambio(object source, IComunicaciones comunicador)
        {
            compraVenta = new MascotaVirtual.Comunicaciones.CompraVenta();
            compraVenta.OnVentanaCerrada += new MascotaVirtual.Comunicaciones.CompraVenta.ManejadorVentanaCerrada(compraVenta_OnVentanaCerrada);
            compraVenta.Inicializar(mascota.Inventario, comunicador);
            compraVenta.Enabled = true;
            compraVenta.Show();
            chat_OnVentanaCerrada(this, new EventArgs());
        }
        #endregion

        #region Manejador del inicio de la Batalla
        /// <summary>
        /// Manejador del inicio de la Batalla.
        /// Cierra la ventana de chat y crea la nueva ventana.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="comunicador">Comunicador que se utilizará en el intercambio.</param>
        void chat_OnPasoJuego(object source, IComunicaciones comunicador)
        {
            ventanaBatalla = new MascotaVirtual.Comunicaciones.Batalla.Vista.VentanaBatalla();
            ventanaBatalla.OnVentanaCerrada += new MascotaVirtual.Comunicaciones.Batalla.Vista.VentanaBatalla.ManejadorVentanaCerrada(ventanaBatalla_OnVentanaCerrada);
            ventanaBatalla.Inicializar(mascota, comunicador);
            ventanaBatalla.Enabled = true;
            ventanaBatalla.Show();
            chat_OnVentanaCerrada(this, new EventArgs());
        }
        #endregion

        #region Manejador del cierre de la ventana de Batalla
        /// <summary>
        /// Manejador del cierre de la ventana del juego.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void ventanaBatalla_OnVentanaCerrada(object source, EventArgs e)
        {
            ventanaBatalla.Dispose();
            ventanaBatalla = null;
        }
        #endregion

        #region Manejador del cierre de la ventana del intercambio de objetos
        /// <summary>
        /// Manejador del cierre de la ventana de intercambio de objetos.
        /// Cierra la ventana.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void compraVenta_OnVentanaCerrada(object source, EventArgs e)
        {
            compraVenta.Dispose();
            compraVenta = null;
        }
        #endregion

        #region Manejador del cierre de la ventana del chat
        /// <summary>
        /// Manejador del cierre de la ventana del chat.
        /// Cierra la ventana.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void chat_OnVentanaCerrada(object source, EventArgs e)
        {
            chat.Dispose();
            chat = null;
        }
        #endregion

        #region Manejador del cierre de la ventana del juego del cementerio
        /// <summary>
        /// Manejador del cierre de la ventana del juego del cementerio.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void ventanaCementerio_OnVentanaCerrada(object source, EventArgs e)
        {
            ventanaCementerio.Dispose();
            ventanaCementerio = null;
        }
        #endregion

        #region Manejador del cierre de la ventana de comunicaciones
        /// <summary>
        /// Manejador del cierre de la ventana de comunicaciones.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void ventanaComunicaciones_OnVentanaCerrada(object source, EventArgs e)
        {
            ventanaComunicaciones.Dispose();
            ventanaComunicaciones = null;
        }
        #endregion

        #region Inicio del Programa
        /// <summary>
        /// Inicia el programa ejecutando la ventana principal.
        /// </summary>
        [MTAThread]
        public void IniciarPrograma()
        {
            Application.Run(ventanaPrincipal);
        }
        #endregion
    }
}
