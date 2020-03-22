using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MascotaVirtual.Interface;
using MascotaVirtual.VidaMascota.Modelo.Objetos;
using System.IO;
using System.Threading;
using MascotaVirtual.Utilidades;
using System.Xml.Serialization;
using MascotaVirtual.Interface.Controles;
using MascotaVirtual.VidaMascota.Modelo;

namespace MascotaVirtual.Comunicaciones
{
    public partial class CompraVenta : Form
    {
        private IComunicaciones comunicador;

        private ListaObjetos inventario;
        private ListaObjetos inventarioRemoto;
        private ListaObjetos ofertaPropia;
        private ListaObjetos ofertaRemoto;
        private Objeto seleccionadoOferta;
        private bool ofertaSeleccionadoPropio;
        private bool inventarioRemotoInicializado;

        private bool esperandoOferta;
        private bool esperandoOfertaPropia;

        private ThreadStart inicioHiloLectura;
        private Thread hiloLectura;

        #region Delegado y Evento del cierre de la ventana
        /// <summary>
        /// Manejador del evento del cierre de la ventana
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Argumentos del evento</param>
        public delegate void ManejadorVentanaCerrada(object source, EventArgs e);
        /// <summary>
        /// Evento del cierre de la ventana
        /// </summary>
        public event ManejadorVentanaCerrada OnVentanaCerrada;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CompraVenta()
        {
            inventario = new ListaObjetos();
            inventarioRemoto = new ListaObjetos();
            ofertaPropia = new ListaObjetos();
            ofertaRemoto = new ListaObjetos();
            ofertaSeleccionadoPropio = true;
            InitializeComponent();
            this.pOferta.Visible = false;
            this.bAceptar.Enabled = false;
            this.bRechazar.Enabled = false;
            this.pInventario.Visible = true;
            this.pInventarioRemoto.Visible = true;
            inicioHiloLectura = new ThreadStart(Leer);
            hiloLectura = new Thread(inicioHiloLectura);
            inventarioRemotoInicializado = false;
            esperandoOferta = false;
            esperandoOfertaPropia = false;
        }
        #endregion


        #region Serialización y Deserialización de datos
        #region Serializar inventario
        /// <summary>
        /// Serializa el inventario.
        /// </summary>
        /// <param name="inventario">El inventario.</param>
        /// <returns>Cadena con el inventario serializado</returns>
        private string serializarInventario(ListaObjetos inventario)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ListaObjetos));
            System.IO.StreamWriter writer = new System.IO.StreamWriter(new MascotaVirtual.Utilidades.DirectorioRaiz().Directorio + "archivos\\inventario.xml");
            serializer.Serialize(writer, inventario);
            writer.Close();

            System.IO.StreamReader reader = new StreamReader(new MascotaVirtual.Utilidades.DirectorioRaiz().Directorio + "archivos\\inventario.xml");
            string linea = reader.ReadLine();
            reader.Close();
            return linea;
        }
        #endregion

        #region Deserializar inventario remoto
        /// <summary>
        /// Deserializa el inventario remoto.
        /// </summary>
        /// <param name="inventarioRemoto">El inventario remoto.</param>
        private void deserializarInventarioRemoto(string inventarioRemoto)
        {
            System.IO.StreamWriter writer = new StreamWriter(new MascotaVirtual.Utilidades.DirectorioRaiz().Directorio + "archivos\\inventarioRemoto.xml");
            writer.Write(inventarioRemoto);
            writer.Close();

            XmlSerializer serializer = new XmlSerializer(typeof(MascotaSerializable));
            System.IO.StreamReader lector = new System.IO.StreamReader(new DirectorioRaiz().Directorio + "archivos\\inventarioRemoto.xml");

            ListaObjetos nuevoInventario;
            nuevoInventario = (ListaObjetos)serializer.Deserialize(lector);
            lector.Close();

            this.inventarioRemoto = nuevoInventario;
            this.InicializarInventarioRemoto();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Deserializar oferta remota
        /// <summary>
        /// Deserializa la oferta remota.
        /// </summary>
        /// <param name="inventarioRemoto">La oferta remota.</param>
        private void deserializarOfertaRemota(string inventarioRemoto)
        {
            System.IO.StreamWriter writer = new StreamWriter(new MascotaVirtual.Utilidades.DirectorioRaiz().Directorio + "archivos\\ofertaRemota.xml");
            writer.Write(inventarioRemoto);
            writer.Close();

            XmlSerializer serializer = new XmlSerializer(typeof(MascotaSerializable));
            System.IO.StreamReader lector = new System.IO.StreamReader(new DirectorioRaiz().Directorio + "archivos\\ofertaRemota.xml");

            ListaObjetos nuevoInventario;
            nuevoInventario = (ListaObjetos)serializer.Deserialize(lector);
            lector.Close();

            if (!esperandoOfertaPropia)
            {
                this.ofertaRemoto = nuevoInventario;
                this.pintarObjetosOfertaRemoto();
                esperandoOferta = false;
                esperandoOfertaPropia = true;
            }
            else
            {
                this.ofertaPropia = nuevoInventario;
                this.pintarObjetosOferta();
                esperandoOfertaPropia = false;
            }
            Cursor.Current = Cursors.Default;
        }
        #endregion
        #endregion

        #region Escribir y Leer
        #region Escribir
        /// <summary>
        /// Escribe el mensaje especificado.
        /// </summary>
        /// <param name="mensaje">El mensaje.</param>
        private void Escribir(string mensaje)
        {
            byte[] palabra = new byte[mensaje.Length];
            for (int i = 0; i < mensaje.Length; i++)
            {
                if (mensaje[i] != '\0')
                {
                    palabra[i] = (byte)mensaje[i];
                }
            }
            Stream remotoStream = comunicador.GetStream();
            try
            {
                remotoStream.Write(palabra, 0, palabra.Length);
            }
            catch
            {
                MessageBox.Show("Falló al escribir");
            }
        }
        #endregion

        #region Leer
        /// <summary>
        /// Lee del dispositivo remoto.
        /// </summary>
        private void Leer()
        {
            Stream remotoStream = comunicador.GetStream();
            byte[] palabra = new byte[15000];
            try
            {
                remotoStream.Read(palabra, 0, 15000);

                string mensaje = "";
                for (int i = 0; i < palabra.Length; i++)
                {
                    if ((char)palabra[i] != '\0')
                    {
                        mensaje += (char)palabra[i];
                    }
                }

                //MessageBox.Show(mensaje);
                switch (mensaje)
                {
                    case ("/-#A#-/"):
                        {
                            Escribir(serializarInventario(this.inventario));
                            break;
                        }
                    case ("/-#RECHAZADA#-/"):
                        {
                            MessageBox.Show("El usuario remoto rechazó la oferta");
                            ActivacionTodo();
                            break;
                        }

                    case ("/-#ACEPTADA#-/"):
                        {
                            RealizacionIntercambio();
                            break;
                        }
                    case ("/-#OFERTA#-/"):
                        {
                            DialogResult respuesta = MessageBox.Show("Oferta recibida, ¿desea verla?", "Oferta Recibida", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (respuesta == DialogResult.No)
                            {
                                Escribir("/-#NO#-/");
                            }
                            else
                            {
                                Escribir("/-#SI#-/");
                                esperandoOferta = true;
                                this.ActivacionBotones();
                            }
                            break;
                        }
                    case ("/-#SI#-/"):
                        {
                            IniciarEnvioOfertas();
                            break;
                        }
                    case ("/-#NO#-/"):
                        {
                            MessageBox.Show("El usuario remoto no quiere ver su oferta", "No se aceptó", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            this.ActivacionBotones();
                            break;
                        }
                    default:
                        {
                            if (esperandoOferta || esperandoOfertaPropia)
                            {
                                IniciarDeserializacionOferta(mensaje);
                                if (!esperandoOfertaPropia)
                                {
                                    PintarOfertas();
                                }
                            }
                            else
                            {
                                InicioDeserializar(mensaje);
                            }
                            break;
                        }
                }
                Leer();
            }
            catch
            {
                MessageBox.Show("Error al leer, se perdió la conexión con el usuario remoto");
            }
        }
        #endregion
        #endregion


        #region Inicializar
        /// <summary>
        /// Inicializa el intercambio
        /// </summary>
        /// <param name="inventario">Objetos de la mascota</param>
        /// <param name="comunicador">Comunicador usado para la comunicación</param>
        public void Inicializar(ListaObjetos inventario, IComunicaciones comunicador)
        {
            this.inventario = inventario;
            this.inventarioRemoto = new ListaObjetos();
            this.comunicador = comunicador;
            this.hiloLectura.Start();
            this.InicializarInventario();
            this.InicializarInventarioRemoto();
        }
        #endregion

        #region Botones
        #region Click Salir
        /// <summary>
        /// Manejador del evento Click en el botón Salir.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Arguentos del evento.</param>
        private void bSalir_Click(object sender, EventArgs e)
        {
            this.comunicador.Parar();
            this.hiloLectura.Abort();
            Cursor.Current = Cursors.Default;
            if (OnVentanaCerrada != null)
            {
                OnVentanaCerrada(this, e);
            }
        }
        #endregion

        #region Click en el botón "Oferta"
        /// <summary>
        /// Manejador del evento Click en el botón Oferta.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Arguentos del evento.</param>
        private void bOferta_Click(object sender, EventArgs e)
        {
            pintarObjetosOferta();
            InicializarSeleccionadoOferta();
            pintarSeleccionadoOferta();
            pintarObjetosOfertaRemoto();
            this.pOferta.Visible = true;
            this.tcInventarios.Visible = false;
            this.pInventario.Visible = false;
            this.pInventarioRemoto.Visible = false;
        }
        #endregion

        #region Click en el botón "Inventarios"
        /// <summary>
        /// Manejador del evento Click en el botón Inventarios.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Arguentos del evento.</param>
        private void bInventarios_Click(object sender, EventArgs e)
        {
            this.pOferta.Visible = false;
            this.tcInventarios.Visible = true;
            this.pInventario.Visible = true;
            this.pInventarioRemoto.Visible = true;
        }
        #endregion

        #region Click en Seleccionar un objeto propio para meterlo en la Oferta
        /// <summary>
        /// Manejador del evento Click en el botón Seleccionar.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Arguentos del evento.</param>
        private void bSeleccionar_Click(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                this.ofertaPropia.Insertar(this.seleccionado);
            }
        }
        #endregion

        #region Click en Seleccionar un Objeto Remoto para meterlo en la Oferta
        /// <summary>
        /// Manejador del evento Click en el botón Seleccionar Remoto.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Arguentos del evento.</param>
        private void bSeleccionarRemoto_Click(object sender, EventArgs e)
        {
            if (seleccionadoRemoto != null)
            {
                this.ofertaRemoto.Insertar(seleccionadoRemoto);
            }
        }
        #endregion

        #region Rechazar la oferta
        /// <summary>
        /// Manejador del evento Click en el botón Rechazar.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Arguentos del evento.</param>
        private void bRechazar_Click(object sender, EventArgs e)
        {
            this.ofertaPropia = new ListaObjetos();
            this.ofertaRemoto = new ListaObjetos();
            bAceptar.Enabled = false;
            bRechazar.Enabled = false;
            bOfertar.Enabled = true;
            bEliminar.Enabled = true;
            bInventarios.Enabled = true;
            bOferta.Enabled = true;
            this.pOferta.Visible = true;
            this.tcInventarios.Visible = false;
            this.pInventario.Visible = false;
            this.pInventarioRemoto.Visible = false;
            Escribir("/-#RECHAZADA#-/");
        }
        #endregion

        #region Aceptar la oferta
        /// <summary>
        /// Manejador del evento Click en el botón Aceptar.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Arguentos del evento.</param>
        private void bAceptar_Click(object sender, EventArgs e)
        {
            intercambioPost();
            Escribir("/-#ACEPTADA#-/");
        }
        #endregion
        #endregion

        #region Oferta
        #region Pintar Objetos Propios en la Oferta
        /// <summary>
        /// Pinta los objetos de la oferta.
        /// </summary>
        private void pintarObjetosOferta()
        {
            pObjetosPropios.Controls.Clear();
            int objetos = 1;
            NodoObjeto nodoAux = ofertaPropia.Cab;
            Point punto = new Point(0, 0);
            while (nodoAux != null)
            {
                ImagenDatos imagenDatos = new ImagenDatos();
                imagenDatos.Inicializar(nodoAux.Info);
                imagenDatos.Location = punto;
                imagenDatos.Click += new EventHandler(imagenDatosOferta_Click);
                pObjetosPropios.Controls.Add(imagenDatos);
                if (objetos < 4)
                {
                    punto.X = punto.X + 50;
                    objetos++;
                }
                else
                {
                    punto.X = 0;
                    punto.Y = punto.Y + 50;
                    objetos = 1;
                }
                nodoAux = nodoAux.Siguiente;
            }
        }
        #endregion

        #region Pintar Objetos Remotos en la Oferta
        /// <summary>
        /// Pinta los objetos de la oferta remota.
        /// </summary>
        private void pintarObjetosOfertaRemoto()
        {
            pObjetosRemotos.Controls.Clear();
            int objetos = 1;
            NodoObjeto nodoAux = ofertaRemoto.Cab;
            Point punto = new Point(0, 0);
            while (nodoAux != null)
            {
                ImagenDatos imagenDatos = new ImagenDatos();
                imagenDatos.Inicializar(nodoAux.Info);
                imagenDatos.Location = punto;
                imagenDatos.Click += new EventHandler(imagenDatosOfertaRemoto_Click);
                pObjetosRemotos.Controls.Add(imagenDatos);
                if (objetos < 4)
                {
                    punto.X = punto.X + 50;
                    objetos++;
                }
                else
                {
                    punto.X = 0;
                    punto.Y = punto.Y + 50;
                    objetos = 1;
                }
                nodoAux = nodoAux.Siguiente;
            }
        }
        #endregion

        #region Inicializar el Objeto seleccionado de la Oferta
        /// <summary>
        /// Inicializa el objeto seleccionado de la oferta.
        /// </summary>
        private void InicializarSeleccionadoOferta()
        {
            this.seleccionadoOferta = new Alimento();
            this.seleccionadoOferta.Nombre = "No seleccionado";
            this.seleccionadoOferta.Capacidad = 0;
            this.seleccionadoOferta.Imagen = "graficos\\noSeleccionado.bmp";
        }
        #endregion

        #region Pintar el Objeto Seleccionado de la Oferta
        /// <summary>
        /// Pinta el objeto seleccionado de la oferta.
        /// </summary>
        private void pintarSeleccionadoOferta()
        {
            Utilidades.DirectorioRaiz directorio = new Utilidades.DirectorioRaiz();
            lCapacidadObservado.Text = seleccionadoOferta.Capacidad.ToString();
            lNombreObservado.Text = seleccionadoOferta.Nombre;
            try
            {
                pBObjetoObservado.Image = new Bitmap(directorio.Directorio + this.seleccionadoOferta.Imagen);
            }
            catch
            {
                pBObjetoObservado.Image = new Bitmap(directorio.Directorio + "graficos\\noSeleccionado.bmp");
            }
        }
        #endregion

        #region Click en una Imagen de la Oferta Propio
        /// <summary>
        /// Manejador del evento click en una imagen de la oferta propia.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void imagenDatosOferta_Click(object sender, EventArgs e)
        {
            ImagenDatos seleccionado = (ImagenDatos)sender;
            seleccionadoOferta = seleccionado.Datos;
            ofertaSeleccionadoPropio = true;
            pintarSeleccionadoOferta();
        }
        #endregion

        #region Click en una Imagen de la Oferta Remoto
        /// <summary>
        /// Manejador del evento click en una imagen de la oferta remota.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void imagenDatosOfertaRemoto_Click(object sender, EventArgs e)
        {
            ImagenDatos seleccionado = (ImagenDatos)sender;
            seleccionadoOferta = seleccionado.Datos;
            ofertaSeleccionadoPropio = false;
            pintarSeleccionadoOferta();
        }
        #endregion

        #region Eliminar objeto seleccionado de la Oferta
        /// <summary>
        /// Manejador del evento click en el botón eliminar.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (ofertaSeleccionadoPropio)
            {
                this.ofertaPropia.Eliminar(seleccionadoOferta);
                pintarObjetosOferta();
            }
            else
            {
                this.ofertaRemoto.Eliminar(seleccionadoOferta);
                pintarObjetosOfertaRemoto();
            }
            InicializarSeleccionadoOferta();
            pintarSeleccionadoOferta();
        }
        #endregion
        #endregion

        #region Mostrar por pantalla actividades de otros hilos
        #region Delegados
        #region Delegado que inicia el intercambio
        delegate void DelegadoInicioDeserializar(string mensaje);
        #endregion

        #region Delegado que activa todo tras oferta
        delegate void DelegadoActivacionTodo();
        #endregion

        #region Delegado que activa botones desde hilo de lectura
        delegate void DelegadoActivacionBotones();
        #endregion

        #region Delegado que inicia la deserialización de oferta remota
        delegate void InicioDeserializacionOferta(string mensaje);
        #endregion

        #region Delegado que pinta las ofertas
        delegate void DelegadoPintaOfertas();
        #endregion

        #region Delegado que envia las ofertas
        delegate void InicioEnvioOfertas();
        #endregion

        #region Delegado que ejecuta la realización del intercambio
        delegate void DelegadoRealizarIntercambio();
        #endregion
        #endregion

        #region Iniciar la deserialización
        /// <summary>
        /// Inicia la deserialización.
        /// </summary>
        /// <param name="mensaje">El mensaje.</param>
        private void InicioDeserializar(string mensaje)
        {
            if (this.bOfertar.InvokeRequired)
            {
                DelegadoInicioDeserializar d = new DelegadoInicioDeserializar(InicioDeserializar);
                this.Invoke(d, new object[] { mensaje });
            }
            else
            {
                deserializarInventarioRemoto(mensaje);
            }
        }
        #endregion

        #region Activar todo desde el hilo de lectura
        /// <summary>
        /// Activa todos los controles.
        /// </summary>
        private void ActivacionTodo()
        {
            if (this.bAceptar.InvokeRequired)
            {
                DelegadoActivacionTodo d = new DelegadoActivacionTodo(ActivacionTodo);
                this.Invoke(d);
            }
            else
            {
                bAceptar.Enabled = false;
                bRechazar.Enabled = false;
                bOfertar.Enabled = true;
                bInventarios.Enabled = true;
                bOferta.Enabled = true;
                this.pOferta.Visible = true;
                this.tcInventarios.Visible = false;
                this.pInventario.Visible = false;
                this.pInventarioRemoto.Visible = false;
                this.ofertaPropia = new ListaObjetos();
                this.ofertaRemoto = new ListaObjetos();
                pintarObjetosOferta();
                pintarObjetosOfertaRemoto();
                InicializarSeleccionadoOferta();
                pintarSeleccionadoOferta();
                InicializarInventario();
                InicializarInventarioRemoto();
            }
        }
        #endregion

        #region Activar botones desde el hilo de lectura
        /// <summary>
        /// Activa todos los botones.
        /// </summary>
        private void ActivacionBotones()
        {
            if (this.bAceptar.InvokeRequired)
            {
                DelegadoActivacionBotones d = new DelegadoActivacionBotones(ActivacionBotones);
                this.Invoke(d);
            }
            else
            {
                bAceptar.Enabled = true;
                bRechazar.Enabled = true;
                bEliminar.Enabled = false;
            }
        }
        #endregion

        #region Iniciar Deserialización Oferta
        /// <summary>
        /// Inicia la deserialización de la oferta.
        /// </summary>
        /// <param name="mensaje">El mensaje.</param>
        private void IniciarDeserializacionOferta(string mensaje)
        {
            if (this.bAceptar.InvokeRequired)
            {
                InicioDeserializacionOferta d = new InicioDeserializacionOferta(IniciarDeserializacionOferta);
                this.Invoke(d, new object[] { mensaje });
            }
            else
            {
                deserializarOfertaRemota(mensaje);
            }
        }
        #endregion

        #region Pintar las Ofertas
        /// <summary>
        /// Pinta las ofertas.
        /// </summary>
        private void PintarOfertas()
        {
            if (this.bAceptar.InvokeRequired)
            {
                DelegadoPintaOfertas d = new DelegadoPintaOfertas(PintarOfertas);
                this.Invoke(d);
            }
            else
            {
                pintarObjetosOferta();
                pintarObjetosOfertaRemoto();
                MessageBox.Show("Oferta Recibida", "Oferta Recibida", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                bAceptar.Enabled = true;
                bRechazar.Enabled = true;
                bOfertar.Enabled = false;
                bInventarios.Enabled = false;
                bOferta.Enabled = false;
                bEliminar.Enabled = false;
                this.pOferta.Visible = true;
                this.tcInventarios.Visible = false;
                this.pInventario.Visible = false;
                this.pInventarioRemoto.Visible = false;
            }
        }
        #endregion

        #region Iniciar Envío de Ofertas
        /// <summary>
        /// Inicia el envio de ofertas.
        /// </summary>
        private void IniciarEnvioOfertas()
        {
            if (this.bAceptar.InvokeRequired)
            {
                InicioEnvioOfertas d = new InicioEnvioOfertas(IniciarEnvioOfertas);
                this.Invoke(d);
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                Escribir(serializarInventario(ofertaPropia));
                Escribir(serializarInventario(ofertaRemoto));
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region Ejecutar la Realización del Intercambio
        /// <summary>
        /// Realización del intercambio.
        /// </summary>
        private void RealizacionIntercambio()
        {
            if (this.bAceptar.InvokeRequired)
            {
                DelegadoRealizarIntercambio d = new DelegadoRealizarIntercambio(RealizacionIntercambio);
                this.Invoke(d);
            }
            else
            {
                MessageBox.Show("El usuario remoto aceptó la oferta");
                intercambioPost();
            }
        }
        #endregion
        #endregion


        #region Enviar la oferta
        /// <summary>
        /// Manejador del click en el botón ofertar.
        /// Envía la oferta al dispositivo remoto.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bOfertar_Click(object sender, EventArgs e)
        {
            bAceptar.Enabled = false;
            bRechazar.Enabled = false;
            bOfertar.Enabled = false;
            bInventarios.Enabled = false;
            bOferta.Enabled = false;
            this.pOferta.Visible = true;
            this.tcInventarios.Visible = false;
            this.pInventario.Visible = false;
            this.pInventarioRemoto.Visible = false;
            string mensaje = "/-#OFERTA#-/";
            Escribir(mensaje);
        }
        #endregion

        #region Pide el inventario al usuario remoto
        /// <summary>
        /// Cuando el inventario remoto tiene el foco, solicita el inventario remoto.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void tPInventarioRemoto_GotFocus(object sender, EventArgs e)
        {
            if (!inventarioRemotoInicializado)
            {
                Cursor.Current = Cursors.WaitCursor;
                string mensaje = "/-#A#-/";
                Escribir(mensaje);
                inventarioRemotoInicializado = true;
            }
        }
        #endregion

        #region Post - Intercambio activamos botones y reinicializamos inventarios
        /// <summary>
        /// Lista de acciones a ejecutar tras el intercambio.
        /// </summary>
        private void intercambioPost()
        {
            realizarIntercambio();
            this.ofertaPropia = new ListaObjetos();
            this.ofertaRemoto = new ListaObjetos();
            this.inventarioRemoto = new ListaObjetos();
            this.pintarObjetosOferta();
            this.pintarObjetosOfertaRemoto();
            borrarControlesInventario();
            borrarControlesInventarioRemoto();
            InicializarInventario();
            InicializarInventarioRemoto();
            bAceptar.Enabled = false;
            bRechazar.Enabled = false;
            bOfertar.Enabled = true;
            bInventarios.Enabled = true;
            bOferta.Enabled = true;
            this.pOferta.Visible = true;
            this.tcInventarios.Visible = false;
            this.pInventario.Visible = false;
            this.pInventarioRemoto.Visible = false;
        }
        #endregion

        #region Realizar el Intercambio aceptado
        /// <summary>
        /// Realiza el intercambio.
        /// </summary>
        private void realizarIntercambio()
        {
            NodoObjeto auxOferta = ofertaPropia.Cab;
            NodoObjeto auxInventario = this.inventario.Cab;
            while (auxOferta != null)
            {
                this.inventario.Eliminar(auxOferta.Info);
                auxOferta = auxOferta.Siguiente;
            }

            auxOferta = ofertaRemoto.Cab;
            while (auxOferta != null)
            {
                this.inventario.Insertar(auxOferta.Info);
                auxOferta = auxOferta.Siguiente;
            }
            inventarioRemotoInicializado = false;
        }
        #endregion


        #region Inventarios
        #region Inventario Propio
        private MascotaVirtual.VidaMascota.Modelo.Objetos.Objeto seleccionado;
        private Point posicionAlimentos;
        private Point posicionCuradores;
        private Point posicionLimpiadores;
        private Point posicionOtros;
        private Point posicionEducadores;
        #region Seleccionar
        /// <summary>
        /// Selecciona el objeto que se pasa por parámetro
        /// </summary>
        /// <param name="seleccionado">Objeto seleccionado</param>
        public void Seleccionar(Objeto seleccionado)
        {
            this.seleccionado = seleccionado;
        }
        #endregion
        #region Inicializar Seleccionado
        /// <summary>
        /// Inicializa el objeto seleccionado en el inventario
        /// </summary>
        public void InicializarSeleccionado()
        {
            this.seleccionado = new Alimento();
            this.seleccionado.Nombre = "No seleccionado";
            this.seleccionado.Capacidad = 0;
            this.seleccionado.Imagen = "graficos\\noSeleccionado.bmp";
        }
        #endregion
        #region Inicializar Puntos de Posición
        /// <summary>
        /// Inicializa the puntos en que se posicionan los items
        /// </summary>
        public void InicializarPuntos()
        {
            this.posicionAlimentos = new Point(5, 5);
            this.posicionCuradores = posicionAlimentos;
            this.posicionLimpiadores = posicionAlimentos;
            this.posicionOtros = posicionAlimentos;
            this.posicionEducadores = posicionAlimentos;
        }
        #endregion
        #region Calcular Posición del Item
        /// <summary>
        /// Calcula la posición del item dentro del inventario
        /// </summary>
        /// <param name="tipo">Cadena con el tipo del item a mostrar</param>
        /// <returns>Punto en el que se posiciona</returns>
        public Point CalcularPosicionItem(String tipo)
        {
            Point nuevoPunto = new Point();
            switch (tipo)
            {
                case ("Limpiador"):
                    {
                        nuevoPunto = this.posicionLimpiadores;
                        if (posicionLimpiadores.X >= 150)
                        {
                            posicionLimpiadores.X = 5;
                            posicionLimpiadores.Y = posicionLimpiadores.Y + 55;
                        }
                        else { posicionLimpiadores.X = posicionLimpiadores.X + 55; }
                        break;
                    }
                case ("Curador"):
                    {
                        nuevoPunto = this.posicionCuradores;
                        if (posicionCuradores.X >= 150)
                        {
                            posicionCuradores.X = 5;
                            posicionCuradores.Y = posicionLimpiadores.Y + 55;
                        }
                        else { posicionCuradores.X = posicionCuradores.X + 55; }
                        break;
                    }
                case ("Educador"):
                    {
                        nuevoPunto = this.posicionEducadores;
                        if (posicionEducadores.X >= 150)
                        {
                            posicionEducadores.X = 5;
                            posicionEducadores.Y = posicionEducadores.Y + 55;
                        }
                        else { posicionEducadores.X = posicionEducadores.X + 55; }
                        break;
                    }
                case ("Alimento"):
                    {
                        nuevoPunto = this.posicionAlimentos;
                        if (posicionAlimentos.X >= 150)
                        {
                            posicionAlimentos.X = 5;
                            posicionAlimentos.Y = posicionAlimentos.Y + 55;
                        }
                        else { posicionAlimentos.X = posicionAlimentos.X + 55; }
                        break;
                    }
                default:
                    {
                        nuevoPunto = this.posicionOtros;
                        if (posicionOtros.X >= 150)
                        {
                            posicionOtros.X = 5;
                            posicionOtros.Y = posicionOtros.Y + 55;
                        }
                        else { posicionOtros.X = posicionOtros.X + 55; }
                        break;
                    }
            }
            return nuevoPunto;
        }
        #endregion
        #region Seleccionar objeto
        /// <summary>
        /// Selecciona el objeto que se ha pulsado
        /// </summary>
        private void seleccionar_Click(object sender, EventArgs e)
        {
            ImagenDatos seleccionado = (ImagenDatos)sender;
            this.Seleccionar(seleccionado.Datos);
            pintarSeleccionado();
        }
        #endregion
        #region Pintar Objeto Seleccionado
        /// <summary>
        /// Pinta el objeto seleccionado en el área correspondiente
        /// </summary>
        private void pintarSeleccionado()
        {
            Utilidades.DirectorioRaiz directorio = new Utilidades.DirectorioRaiz();
            this.lNombreSeleccionado.Text = this.seleccionado.Nombre;
            this.lCapacidad.Text = this.seleccionado.Capacidad.ToString();
            try
            {
                this.pBSeleccionado.Image = new Bitmap(directorio.Directorio + this.seleccionado.Imagen);
            }
            catch
            {
                this.pBSeleccionado.Image = new Bitmap(directorio.Directorio + "graficos\\noSeleccionado.bmp");
            }
        }
        #endregion

        #region Inicialización del Inventario
        /// <summary>
        /// Inicializa el inventario.
        /// </summary>
        private void InicializarInventario()
        {
            this.InicializarSeleccionado();
            this.InicializarPuntos();
            ImagenDatos imagenDatos;
            NodoObjeto nodoAux;
            ListaObjetos inventario = this.inventario;
            nodoAux = inventario.Cab;

            while (nodoAux != null)
            {
                imagenDatos = new ImagenDatos();
                imagenDatos.Inicializar(nodoAux.Info);

                imagenDatos.Click += new EventHandler(this.seleccionar_Click);
                imagenDatos.Location = this.CalcularPosicionItem(nodoAux.Info.Tipo);

                switch (nodoAux.Info.Tipo)
                {
                    case ("Alimento"):
                        {
                            this.tAlimentos.Controls.Add(imagenDatos);
                            break;
                        }
                    case ("Curador"):
                        {
                            this.tCuraciones.Controls.Add(imagenDatos);
                            break;
                        }
                    case ("Limpiador"):
                        {
                            this.tLimpiadores.Controls.Add(imagenDatos);
                            break;
                        }
                    case ("Educador"):
                        {
                            this.tEducadores.Controls.Add(imagenDatos);
                            break;
                        }
                    default:
                        {
                            this.tOtros.Controls.Add(imagenDatos);
                            break;
                        }
                }
                nodoAux = nodoAux.Siguiente;
            }
            pintarSeleccionado();
        }
        #endregion

        #region Borrar controles inventario
        /// <summary>
        /// Borra los controles del inventario.
        /// </summary>
        private void borrarControlesInventario()
        {
            this.tAlimentos.Controls.Clear();
            this.tCuraciones.Controls.Clear();
            this.tLimpiadores.Controls.Clear();
            this.tEducadores.Controls.Clear();
            this.tOtros.Controls.Clear();
        }
        #endregion
        #endregion

        #region Inventario Remoto
        private Objeto seleccionadoRemoto;
        private Point posicionAlimentosRemoto;
        private Point posicionCuradoresRemoto;
        private Point posicionLimpiadoresRemoto;
        private Point posicionOtrosRemoto;
        private Point posicionEducadoresRemoto;
        #region Seleccionar Remoto
        /// <summary>
        /// Selecciona el objeto que se pasa por parámetro
        /// </summary>
        /// <param name="seleccionado">Objeto seleccionado</param>
        public void SeleccionarRemoto(Objeto seleccionado)
        {
            this.seleccionadoRemoto = seleccionado;
        }
        #endregion
        #region Inicializar Seleccionado Remoto
        /// <summary>
        /// Inicializa el objeto seleccionado en el inventario
        /// </summary>
        public void InicializarSeleccionadoRemoto()
        {
            this.seleccionadoRemoto = new Alimento();
            this.seleccionadoRemoto.Nombre = "No seleccionado";
            this.seleccionadoRemoto.Capacidad = 0;
            this.seleccionadoRemoto.Imagen = "graficos\\noSeleccionado.bmp";
        }
        #endregion
        #region Inicializar Puntos de Posición Remoto
        /// <summary>
        /// Inicializa the puntos en que se posicionan los items
        /// </summary>
        public void InicializarPuntosRemoto()
        {
            this.posicionAlimentosRemoto = new Point(5, 5);
            this.posicionCuradoresRemoto = posicionAlimentosRemoto;
            this.posicionLimpiadoresRemoto = posicionAlimentosRemoto;
            this.posicionOtrosRemoto = posicionAlimentosRemoto;
            this.posicionEducadoresRemoto = posicionAlimentosRemoto;
        }
        #endregion
        #region Calcular Posición del Item Remoto
        /// <summary>
        /// Calcula la posición del item dentro del inventario
        /// </summary>
        /// <param name="tipo">Cadena con el tipo del item a mostrar</param>
        /// <returns>Punto en el que se posiciona</returns>
        public Point CalcularPosicionItemRemoto(String tipo)
        {
            Point nuevoPunto = new Point();
            switch (tipo)
            {
                case ("Limpiador"):
                    {
                        nuevoPunto = this.posicionLimpiadoresRemoto;
                        if (posicionLimpiadoresRemoto.X >= 150)
                        {
                            posicionLimpiadoresRemoto.X = 5;
                            posicionLimpiadoresRemoto.Y = posicionLimpiadoresRemoto.Y + 55;
                        }
                        else { posicionLimpiadoresRemoto.X = posicionLimpiadoresRemoto.X + 55; }
                        break;
                    }
                case ("Curador"):
                    {
                        nuevoPunto = this.posicionCuradoresRemoto;
                        if (posicionCuradoresRemoto.X >= 150)
                        {
                            posicionCuradoresRemoto.X = 5;
                            posicionCuradoresRemoto.Y = posicionCuradoresRemoto.Y + 55;
                        }
                        else { posicionCuradoresRemoto.X = posicionCuradoresRemoto.X + 55; }
                        break;
                    }
                case ("Educador"):
                    {
                        nuevoPunto = this.posicionEducadoresRemoto;
                        if (posicionEducadoresRemoto.X >= 150)
                        {
                            posicionEducadoresRemoto.X = 5;
                            posicionEducadoresRemoto.Y = posicionEducadoresRemoto.Y + 55;
                        }
                        else { posicionEducadoresRemoto.X = posicionEducadoresRemoto.X + 55; }
                        break;
                    }
                case ("Alimento"):
                    {
                        nuevoPunto = this.posicionAlimentosRemoto;
                        if (posicionAlimentosRemoto.X >= 150)
                        {
                            posicionAlimentosRemoto.X = 5;
                            posicionAlimentosRemoto.Y = posicionAlimentosRemoto.Y + 55;
                        }
                        else { posicionAlimentosRemoto.X = posicionAlimentosRemoto.X + 55; }
                        break;
                    }
                default:
                    {
                        nuevoPunto = this.posicionOtrosRemoto;
                        if (posicionOtrosRemoto.X >= 150)
                        {
                            posicionOtrosRemoto.X = 5;
                            posicionOtrosRemoto.Y = posicionOtrosRemoto.Y + 55;
                        }
                        else { posicionOtrosRemoto.X = posicionOtrosRemoto.X + 55; }
                        break;
                    }
            }
            return nuevoPunto;
        }
        #endregion
        #region Seleccionar objeto Remoto
        /// <summary>
        /// Selecciona el objeto que se ha pulsado
        /// </summary>
        private void seleccionarRemoto_Click(object sender, EventArgs e)
        {
            ImagenDatos seleccionadoRemoto = (ImagenDatos)sender;
            this.SeleccionarRemoto(seleccionadoRemoto.Datos);
            pintarSeleccionadoRemoto();
        }
        #endregion
        #region Pintar Objeto Seleccionado
        /// <summary>
        /// Pinta el objeto seleccionado en el área correspondiente
        /// </summary>
        private void pintarSeleccionadoRemoto()
        {
            Utilidades.DirectorioRaiz directorio = new Utilidades.DirectorioRaiz();
            this.lNombreSeleccionadoRemoto.Text = this.seleccionadoRemoto.Nombre;
            this.lNCapacidadRemoto.Text = this.seleccionadoRemoto.Capacidad.ToString();
            try
            {
                this.pBSeleccionadoRemoto.Image = new Bitmap(directorio.Directorio + this.seleccionadoRemoto.Imagen);
            }
            catch
            {
                this.pBSeleccionadoRemoto.Image = new Bitmap(directorio.Directorio + "graficos\\noSeleccionado.bmp");
            }
        }
        #endregion

        #region Inicialización del Inventario Remoto
        /// <summary>
        /// Inicializa el inventario.
        /// </summary>
        private void InicializarInventarioRemoto()
        {
            this.InicializarSeleccionadoRemoto();
            this.InicializarPuntosRemoto();
            ImagenDatos imagenDatos;
            NodoObjeto nodoAux;
            ListaObjetos inventario = this.inventarioRemoto;
            nodoAux = inventario.Cab;

            while (nodoAux != null)
            {
                imagenDatos = new ImagenDatos();
                imagenDatos.Inicializar(nodoAux.Info);

                imagenDatos.Click += new EventHandler(this.seleccionarRemoto_Click);
                imagenDatos.Location = this.CalcularPosicionItemRemoto(nodoAux.Info.Tipo);

                switch (nodoAux.Info.Tipo)
                {
                    case ("Alimento"):
                        {
                            this.tAlimentosRemoto.Controls.Add(imagenDatos);
                            break;
                        }
                    case ("Curador"):
                        {
                            this.tCuracionesRemoto.Controls.Add(imagenDatos);
                            break;
                        }
                    case ("Limpiador"):
                        {
                            this.tLimpiadoresRemoto.Controls.Add(imagenDatos);
                            break;
                        }
                    case ("Educador"):
                        {
                            this.tEducadoresRemoto.Controls.Add(imagenDatos);
                            break;
                        }
                    default:
                        {
                            this.tOtrosRemoto.Controls.Add(imagenDatos);
                            break;
                        }
                }
                nodoAux = nodoAux.Siguiente;
            }
            pintarSeleccionadoRemoto();
        }
        #endregion

        #region Borrar controles inventario Remoto
        /// <summary>
        /// Borra los controles del inventario remoto.
        /// </summary>
        private void borrarControlesInventarioRemoto()
        {
            this.tAlimentosRemoto.Controls.Clear();
            this.tCuracionesRemoto.Controls.Clear();
            this.tLimpiadoresRemoto.Controls.Clear();
            this.tEducadoresRemoto.Controls.Clear();
            this.tOtrosRemoto.Controls.Clear();
        }
        #endregion
        #endregion
        #endregion
    }
}