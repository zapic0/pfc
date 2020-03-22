using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace MascotaVirtual.Comunicaciones
{
    public partial class ChatSeleccion : Form
    {
        private IComunicaciones comunicador;
        private ThreadStart inicioHiloLectura;
        private Thread hiloLectura;

        #region Delegado y Evento del cierre de la ventana
        /// <summary>
        /// Manejador del evento de cierre de la ventana.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorVentanaCerrada(object source, EventArgs e);
        /// <summary>
        /// Evento del cierre de la ventana
        /// </summary>
        public event ManejadorVentanaCerrada OnVentanaCerrada;
        #endregion

        #region Delegado y Evento del paso a intercambio de objetos
        /// <summary>
        /// Manejador del evento de paso al intercambio de objetos
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="comunicador">Comunicador que se utilizará en el intercambio</param>
        public delegate void ManejadorPasoIntercambio(object source, IComunicaciones comunicador);
        /// <summary>
        /// Evento del paso al intercambio de objetos
        /// </summary>
        public event ManejadorPasoIntercambio OnPasoIntercambio;
        #endregion

        #region Delegado y Evento del paso a juego
        /// <summary>
        /// Manejador del evento de paso al juego
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="comunicador">Comunicador que se utilizará en el juego</param>
        public delegate void ManejadorPasoJuego(object source, IComunicaciones comunicador);
        /// <summary>
        /// Evento del paso al juego
        /// </summary>
        public event ManejadorPasoJuego OnPasoJuego;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ChatSeleccion()
        {
            InitializeComponent();
            inicioHiloLectura = new ThreadStart(Leer);
            hiloLectura = new Thread(inicioHiloLectura);
        }
        #endregion

        #region Iniciar el servicio o la conexión
        /// <summary>
        /// Iniciar el servicio o conexión.
        /// </summary>
        public void Iniciar()
        {
            if (comunicador.Servidor)
            {
                try
                {
                    this.bEnviar.Enabled = false;
                    this.bCambio.Enabled = false;
                    this.bJugar.Enabled = false;
                    comunicador.OnAlguienConectado += new IComunicaciones.AlguienConectado(comunicador_OnAlguienConectado);
                    comunicador.SirveConHilo();
                }
                catch
                {
                    this.SetTextoRecibido("No se pudo iniciar el servicio");
                    this.bEnviar.Enabled = false;
                    this.bCambio.Enabled = false;
                    this.bJugar.Enabled = false;
                }
            }
            else
            {
                try
                {
                    comunicador.OnConectadoAAlguien += new IComunicaciones.ConectadoAAlguien(comunicador_OnConectadoAAlguien);
                    comunicador.Conectar();
                    this.bEnviar.Enabled = true;
                    this.bCambio.Enabled = true;
                    this.bJugar.Enabled = true;
                }
                catch (Exception e)
                {
                    this.SetTextoRecibido("No se pudo completar la conexión");
                    this.SetTextoRecibido(e.Message);
                    this.SetTextoRecibido(e.StackTrace);
                    this.bEnviar.Enabled = false;
                    this.bCambio.Enabled = false;
                    this.bJugar.Enabled = false;
                }
            }
        }
        #endregion

        #region Evento cuando alguien se conecta
        /// <summary>
        /// Evento que ocurre cuando alguien se conecta.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public void comunicador_OnAlguienConectado(object source, EventArgs e)
        {
            IComunicaciones comunicadorDelEvento = (IComunicaciones)source;
            string nombre = comunicadorDelEvento.GetNombreRemoto();
            this.SetTextoUsuarioRemoto(nombre + " se ha conectado");
            this.ActivarBotonesServidor();
            this.hiloLectura.Start();
        }
        #endregion

        #region Evento cuando te conectas a alguien
        /// <summary>
        /// Evento que ocurre cuando te conectas a alguien.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void comunicador_OnConectadoAAlguien(object source, EventArgs e)
        {
            IComunicaciones comunicadorDelEvento = (IComunicaciones)source;
            string nombre = comunicadorDelEvento.GetNombreRemoto();
            this.SetTextoUsuarioRemoto("Conectado a " + nombre);
            this.hiloLectura.Start();
        }
        #endregion

        #region Establecimiento del Comunicador
        /// <summary>
        /// Asigna el comunicador con el que pasamos por parámetros.
        /// </summary>
        /// <param name="comunicador">El comunicador.</param>
        public void SetComunicador(IComunicaciones comunicador)
        {
            this.comunicador = comunicador;
        }
        #endregion

        #region Salir
        /// <summary>
        /// Manejador del evento click en el botón salir.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bSalir_Click(object sender, EventArgs e)
        {
            comunicador.Parar();
            this.hiloLectura.Abort();
            if (OnVentanaCerrada != null)
            {
                OnVentanaCerrada(this, e);
            }
        }
        #endregion

        #region Escribir
        /// <summary>
        /// Escribe el mensaje contenido en la caja de texto propio al dispositivo remoto.
        /// </summary>
        private void Escribir()
        {
            Stream remotoStream = comunicador.GetStream();
            string mensaje = this.tBTextoPropio.Text;
            mensaje += '\r';
            mensaje += '\n';
            byte[] palabra = new byte[mensaje.Length];
            for (int i = 0; i < mensaje.Length; i++)
            {
                palabra[i] = (byte)mensaje[i];
            }
            try
            {
                remotoStream.Write(palabra, 0, mensaje.Length);
                string escribible = "Tu escribiste: ";
                escribible += '\r';
                escribible += '\n';
                escribible += mensaje;
                mensaje += " ";
                SetTextoRecibido(escribible);
                SetTextoPropio("");
            }
            catch (Exception e)
            {
                SetTextoRecibido("No se pudo enviar el mensaje\r\n");
                SetTextoRecibido(e.Message);
            }
        }
        #endregion

        #region Leer
        /// <summary>
        /// Lee los mensajes del dispositivo remoto.
        /// </summary>
        private void Leer()
        {
            Stream remotoStream = comunicador.GetStream();
            byte[] palabra = new byte[128];
            try
            {
                if (remotoStream.CanRead)
                {
                    remotoStream.Read(palabra, 0, 128);
                }
                string mensaje = "Remoto escribió: ";
                mensaje += '\r';
                mensaje += '\n';
                string escrito = "";
                for (int i = 0; i < palabra.Length; i++)
                {
                    if ((char)palabra[i] != '\0')
                    {
                        escrito += (char)palabra[i];
                    }
                }
                mensaje += escrito;
                switch (escrito)
                {
                    case ("/-#SI#-/"):
                        {
                            InicioIntercambio();
                            break;
                        }
                    case ("/-#SIJUGAR#-/"):
                        {
                            InicioJuego();
                            break;
                        }
                    case ("/-#NO#-/"):
                        {
                            SetTextoRecibido("El usuario remoto no aceptó la propuesta");
                            this.Leer();
                            break;
                        }
                    case ("/-#Jugar#-/"):
                        {
                            DialogResult resultado = MessageBox.Show("El usuario remoto desea iniciar un juego, ¿Deseas aceptar?", "Intercambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (resultado == DialogResult.No)
                            {
                                mensaje = "/-#NO#-/";
                            }
                            else
                            {
                                mensaje = "/-#SIJUGAR#-/";
                            }
                            palabra = new byte[mensaje.Length];
                            for (int i = 0; i < mensaje.Length; i++)
                            {
                                palabra[i] = (byte)mensaje[i];
                            }
                            remotoStream.Write(palabra, 0, mensaje.Length);
                            if (resultado == DialogResult.Yes)
                            {
                                InicioJuego();
                            }
                            else
                            {
                                this.Leer();
                            }
                            break;
                        }
                    case ("/-#Intercambio#-/"):
                        {
                            DialogResult resultado = MessageBox.Show("El usuario remoto desea iniciar un intercambio, ¿Deseas aceptar?", "Intercambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (resultado == DialogResult.No)
                            {
                                mensaje = "/-#NO#-/";
                            }
                            else
                            {
                                mensaje = "/-#SI#-/";
                            }
                            palabra = new byte[mensaje.Length];
                            for (int i = 0; i < mensaje.Length; i++)
                            {
                                palabra[i] = (byte)mensaje[i];
                            }
                            remotoStream.Write(palabra, 0, mensaje.Length);
                            if (resultado == DialogResult.Yes)
                            {
                                InicioIntercambio();
                            }
                            else
                            {
                                this.Leer();
                            }
                            break;
                        }
                    default:
                        {
                            SetTextoRecibido(mensaje);
                            this.Leer();
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                try
                {
                    SetTextoRecibido(e.Message + '\r' + '\n');
                    SetTextoRecibido("Error intentando leer\r\n");
                    SetTextoRecibido("Se perdió la conexión con el usuario remoto\r\n");
                }
                catch
                { }
            }
        }
        #endregion

        #region Delegado que inicia el intercambio
        /// <summary>
        /// Delegado del inicio de intercambio
        /// </summary>
        delegate void SetInicioIntercambio();
        #endregion
        #region Iniciar la ventana del intercambio
        /// <summary>
        /// Inicia el intercambio.
        /// </summary>
        private void InicioIntercambio()
        {
            if (tBMensajes.InvokeRequired)
            {
                SetInicioIntercambio d = new SetInicioIntercambio(InicioIntercambio);
                this.Invoke(d);
            }
            else
            {
                tBMensajes.Text += "Iniciamos Intercambio";
                Cursor.Current = Cursors.Default;
                if (OnPasoIntercambio != null)
                {
                    OnPasoIntercambio(this, comunicador);
                }
            }
        }
        #endregion

        #region Delegado que inicia el juego
        /// <summary>
        /// Delegado del inicio del juego
        /// </summary>
        delegate void SetInicioJuego();
        #endregion
        #region Iniciar la ventana del Juego
        /// <summary>
        /// Inicia el juego.
        /// </summary>
        private void InicioJuego()
        {
            if (tBMensajes.InvokeRequired)
            {
                SetInicioJuego d = new SetInicioJuego(InicioJuego);
                this.Invoke(d);
            }
            else
            {
                tBMensajes.Text += "Iniciamos Juego";
                Cursor.Current = Cursors.Default;
                if (OnPasoJuego != null)
                {
                    OnPasoJuego(this, comunicador);
                }
            }
        }
        #endregion

        #region Delegado que escribe desde hilos distintos
        /// <summary>
        /// Delegado para escribir un texto desde hilos distintos.
        /// </summary>
        /// <param name="text">Texto que queremos escribir</param>
        delegate void SetTextCallback(string text);
        #endregion
        #region Delegado que activa los botones desde hilos distintos
        /// <summary>
        /// Delegado que activa los botones desde hilos distintos
        /// </summary>
        delegate void EnableButtons();
        #endregion

        #region Activación de los botones del servidor
        /// <summary>
        /// Activar botones 
        /// </summary>
        private void ActivarBotonesServidor()
        {
            if (bEnviar.InvokeRequired)
            {
                EnableButtons d = new EnableButtons(ActivarBotonesServidor);
                this.Invoke(d);
            }
            else
            {
                this.bEnviar.Enabled = true;
                this.bCambio.Enabled = true;
                this.bJugar.Enabled = true;
            }
        }
        #endregion

        #region Escribir en el TextBox del texto recibido
        /// <summary>
        /// Escribe el texto recibido en el TextBox correspondiente.
        /// </summary>
        /// <param name="text">Texto recibido.</param>
        private void SetTextoRecibido(string text)
        {
            if (tBMensajes.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextoRecibido);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                string mensajes = text;
                mensajes += this.tBMensajes.Text;
                this.tBMensajes.Text = mensajes;
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region Escribir en el TextBox del texto propio
        /// <summary>
        /// Escribe el texto propio en el TextBox indicado.
        /// </summary>
        /// <param name="text">El texto.</param>
        private void SetTextoPropio(string text)
        {
            if (tBTextoPropio.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextoPropio);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.tBTextoPropio.Text = "";
            }
        }
        #endregion

        #region Escribir en la etiqueta del Usuario Remoto
        /// <summary>
        /// Escribe en el texto del usuario remoto.
        /// </summary>
        /// <param name="text">El texto.</param>
        private void SetTextoUsuarioRemoto(string text)
        {
            if (lUsuarioRemoto.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextoUsuarioRemoto);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lUsuarioRemoto.Text = text;
            }
        }
        #endregion

        #region Enviar Mensaje
        /// <summary>
        /// Manejador del evento click en el botón enviar.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bEnviar_Click(object sender, EventArgs e)
        {
            this.Escribir();
        }
        #endregion



        #region Pasar al Intercambio
        /// <summary>
        /// Manejador del evento click en el botón Cambio.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bCambio_Click(object sender, EventArgs e)
        {
            Stream remotoStream = comunicador.GetStream();
            string mensaje = "/-#Intercambio#-/";
            byte[] palabra = new byte[mensaje.Length];
            for (int i = 0; i < mensaje.Length; i++)
            {
                palabra[i] = (byte)mensaje[i];
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                remotoStream.Write(palabra, 0, mensaje.Length);
            }
            catch { }
        }
        #endregion
        
        #region Pasar a Jugar
        /// <summary>
        /// Manejador del evento click en el botón Jugar.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bJugar_Click(object sender, EventArgs e)
        {
            Stream remotoStream = comunicador.GetStream();
            string mensaje = "/-#Jugar#-/";
            byte[] palabra = new byte[mensaje.Length];
            for (int i = 0; i < mensaje.Length; i++)
            {
                palabra[i] = (byte)mensaje[i];
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                remotoStream.Write(palabra, 0, mensaje.Length);
            }
            catch { }
        }
        #endregion
    }
}