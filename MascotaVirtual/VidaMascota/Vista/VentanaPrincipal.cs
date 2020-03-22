using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MascotaVirtual.Minijuegos;
using MascotaVirtual.Utilidades;
using System.Threading;
using MascotaVirtual.VidaMascota;
using MascotaVirtual.Interface.Controles;
using MascotaVirtual.VidaMascota.Controlador;
using MascotaVirtual.VidaMascota.Modelo;
using MascotaVirtual.VidaMascota.Modelo.Objetos;

namespace MascotaVirtual.VidaMascota.Vista
{
    /// <summary>
    /// Ventana Principal del Proyecto
    /// </summary>
    public partial class VentanaPrincipal : Form
    {
        private Mascota mascota;
        private VidaMascota.Controlador.ControladorVida controlador;

        #region Delegado y Evento del cambio de ventanas
        /// <summary>
        /// Manejador cuando cambia la Ventana que hay que mostrar
        /// </summary>
        /// <param name="source">Fuente que lanza el evento</param>
        /// <param name="e">Cadena del botón que lanza el evento</param>
        public delegate void ManejadorVentanaCambiada(object source, string e);
        /// <summary>
        /// Evento del cambio de Ventana que se muestra
        /// </summary>
        public event ManejadorVentanaCambiada OnVentanaCambiada;
        #endregion

        #region Inicializar Ventana
        /// <summary>
        /// Inicializa la Ventana
        /// </summary>
        public VentanaPrincipal(ControladorVida controlador, Mascota mascota)
        {
            InitializeComponent();
            this.mascota = mascota;
            this.controlador = controlador;
            mascota.OnImagenCambiada += new Mascota.ManejadorImagenCambiada(OnImagenCambiada);
            mascota.OnDiversionCambiada += new Mascota.ManejadorDiversionCambiada(mascota_OnDiversionCambiada);
            mascota.OnEducacionCambiada += new Mascota.ManejadorEducacionCambiada(mascota_OnEducacionCambiada);
            mascota.OnHambreCambiada += new Mascota.ManejadorHambreCambiada(mascota_OnHambreCambiada);
            mascota.OnHigieneCambiada += new Mascota.ManejadorHigieneCambiada(mascota_OnHigieneCambiada);
            mascota.OnPuntosVidaCambiada += new Mascota.ManejadorPuntosVidaCambiada(mascota_OnPuntosVidaCambiada);
            mascota.OnSaludCambiada += new Mascota.ManejadorSaludCambiada(mascota_OnSaludCambiada);
            mascota.OnDineroCambiado += new Mascota.ManejadorDineroCambiado(mascota_OnDineroCambiado);
            mascota.OnNivelCambiado += new Mascota.ManejadorNivelCambiado(mascota_OnNivelCambiado);
        }
        #endregion
        #region Publicación de cambio de Salud
        /// <summary>
        /// Muestra el cambio de salud en la mascota
        /// </summary>
        /// <param name="source">La mascota que publica el cambio.</param>
        /// <param name="e">El nuevo valor de salud.</param>
        void mascota_OnSaludCambiada(object source, int e)
        {
            this.pBSalud.Value = e;
        }
        #endregion
        #region Publicación de cambio de Puntos de Vida
        /// <summary>
        /// Muestra el cambio de puntos de vida en la mascota
        /// </summary>
        /// <param name="source">La mascota que publica el cambio.</param>
        /// <param name="e">El nuevo valor de puntos de vida.</param>
        void mascota_OnPuntosVidaCambiada(object source, int e)
        {
            this.pBPuntosVida.Value = e;
            if (!mascota.EstaViva)
            {
                this.desactivarOpciones();
            }
        }
        #endregion
        #region Publicación de cambio de Higiene
        /// <summary>
        /// Muestra el cambio de higiene en la mascota
        /// </summary>
        /// <param name="source">La mascota que publica el cambio.</param>
        /// <param name="e">El nuevo valor de higiene.</param>
        void mascota_OnHigieneCambiada(object source, int e)
        {
            this.pBHigiene.Value = e;
        }
        #endregion
        #region Publicación de cambio de Hambre
        /// <summary>
        /// Muestra el cambio de hambre en la mascota
        /// </summary>
        /// <param name="source">La mascota que publica el cambio.</param>
        /// <param name="e">El nuevo valor de hambre.</param>
        void mascota_OnHambreCambiada(object source, int e)
        {
            this.pBHambre.Value = e;
        }
        #endregion
        #region Publicación de cambio de Educación
        /// <summary>
        /// Muestra el cambio de educación en la mascota
        /// </summary>
        /// <param name="source">La mascota que publica el cambio.</param>
        /// <param name="e">El nuevo valor de educación.</param>
        void mascota_OnEducacionCambiada(object source, int e)
        {
            this.pBEducacion.Value = e;
        }
        #endregion
        #region Publicación de cambio de Diversión
        /// <summary>
        /// Muestra el cambio de diversión en la mascota
        /// </summary>
        /// <param name="source">La mascota que publica el cambio.</param>
        /// <param name="e">El nuevo valor de diversión.</param>
        void mascota_OnDiversionCambiada(object source, int e)
        {
            this.pBDiversion.Value = e;
        }
        #endregion
        #region Publicación de cambio de Imagen
        /// <summary>
        /// Se ejecuta cuando cambia la imagen.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="dibujo">Dibujo que se pintará.</param>
        private void OnImagenCambiada(object source, Bitmap dibujo)
        {
            this.graficoAnimacion.Muestra(dibujo);
        }
        #endregion
        #region Publicación de cambio del Dinero
        /// <summary>
        /// Se ejecuta cuando cambia el valor del dinero.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void mascota_OnDineroCambiado(object source, int e)
        {
            this.lDinero.Text = e.ToString();
            this.comprobarCompras(e);
        }
        #endregion
        #region Publicación de cambio del Nivel
        /// <summary>
        /// Se ejecuta cuando cambia el valor del nivel.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void mascota_OnNivelCambiado(object source, int e)
        {
            this.LNumeroNivel.Text = e.ToString();
        }
        #endregion

        #region Comprueba activación opciones de compra
        /// <summary>
        /// Activa o desactiva las opciones de compra en función del dinero de que dispone.
        /// </summary>
        /// <param name="dinero">Dinero de la mascota.</param>
        private void comprobarCompras(int dinero)
        {
            mIBocadillo.Enabled = false; //10
            mIBotiquin.Enabled = false; //90
            mICerebro.Enabled = false; //50
            mILibro.Enabled = false; //20
            mIPatito.Enabled = false; //80
            mIPildora.Enabled = false; //50
            mITermometro.Enabled = false; //20
            if (dinero >= 10)
            {
                mIBocadillo.Enabled = true;
            }
            if (dinero >= 20)
            {
                mILibro.Enabled = true;
                mITermometro.Enabled = true;
            }
            if (dinero >= 50)
            {
                mICerebro.Enabled = true;
                mIPildora.Enabled = true;
            }
            if (dinero >= 80)
            {
                mIPatito.Enabled = true;
            }
            if (dinero >= 90)
            {
                mIBotiquin.Enabled = true;
            }
        }
        #endregion

        #region Botones
        #region Botón Inventario
        /// <summary>
        /// Click en la opción de menú "ver inventario".
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void MIVerInventario_Click(object sender, EventArgs e)
        {
            BVerInventario_Click(this, new EventArgs());
        }
        /// <summary>
        /// Muestra el inventario de la mascota.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BVerInventario_Click(object sender, EventArgs e)
        {
            if (!this.pInventario.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                this.controlador.InicializarSeleccionado();
                this.InicializarInventario();
                this.pInventario.Visible = true;
                this.BVerInventario.ForeColor = Color.White;
                Cursor.Current = Cursors.Default;
            }
            else
            {
                this.pInventario.Visible = false;
                this.BorrarInventario();
                this.BVerInventario.ForeColor = Color.Black;
            }
        }
        #endregion
        #region Botón Jugar/Conexiones
        /// <summary>
        /// Inicia la selección de juegos.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Juegos_Click(object sender, EventArgs e)
        {
            //controlador.PararAnimacion();
            Button emisor = (Button)sender;
            if (OnVentanaCambiada != null)
            {
                OnVentanaCambiada(this, emisor.Text);
            }
        }
        #endregion
        #region Salir
        /// <summary>
        /// Sale del programa
        /// </summary>
        private void MISalir_Click(object sender, EventArgs e)
        {
            controlador.Serializar();
            this.Close();
        }
        #endregion
        #region Botón Usar
        /// <summary>
        /// Botón que activa el uso del objeto seleccionado
        /// </summary>
        private void bUsar_Click(object sender, EventArgs e)
        {
            this.controlador.UsarSeleccionado();
            this.BorrarInventario();
            this.InicializarInventario();
            pintarSeleccionado();
        }
        #endregion
        #region Eliminar Objeto
        /// <summary>
        /// Botón que activa la eliminación del objeto seleccionado
        /// </summary>
        private void bEliminar_Click(object sender, EventArgs e)
        {
            this.controlador.EliminarSeleccionado();
            this.BorrarInventario();
            this.InicializarInventario();
            pintarSeleccionado();
        }
        #endregion
        #endregion

        #region Cargando Ventana Principal
        /// <summary>
        /// Carga de la ventana principal poniendo los valores iniciales.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            this.pBDiversion.Value = this.mascota.Diversion;
            this.pBEducacion.Value = this.mascota.Educacion;
            this.pBHambre.Value = this.mascota.Hambre;
            this.pBHigiene.Value = this.mascota.Higiene;
            this.pBPuntosVida.Value = this.mascota.PuntosVida;
            this.pBSalud.Value = this.mascota.Salud;
            this.LNumeroNivel.Text = this.mascota.Nivel.ToString();
            this.lDinero.Text = this.mascota.Dinero.ToString();
            this.comprobarCompras(mascota.Dinero);

            if (!mascota.EstaViva)
            {
                this.desactivarOpciones();
            }
        }
        #endregion

        #region Inicialización del Inventario
        /// <summary>
        /// Inicializa el inventario.
        /// Carga cada objeto en su pestaña en función de su tipo.
        /// </summary>
        private void InicializarInventario()
        {
            this.controlador.InicializarSeleccionado();
            this.controlador.InicializarPuntos();
            ImagenDatos imagenDatos;
            NodoObjeto nodoAux;
            ListaObjetos inventario = this.controlador.Inventario();
            nodoAux = inventario.Cab;

            while (nodoAux != null)
            {
                imagenDatos = new ImagenDatos();
                imagenDatos.Inicializar(nodoAux.Info);

                imagenDatos.Click += new EventHandler(this.seleccionar_Click);
                imagenDatos.Location = this.controlador.CalcularPosicionItem(nodoAux.Info.Tipo);

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

        #region Seleccionar objeto
        /// <summary>
        /// Selecciona el objeto que se ha pulsado
        /// </summary>
        private void seleccionar_Click(object sender, EventArgs e)
        {
            ImagenDatos seleccionado = (ImagenDatos)sender;
            this.controlador.Seleccionar(seleccionado.Datos);
            pintarSeleccionado();
        }
        #endregion

        #region Pintar Objeto Seleccionado
        /// <summary>
        /// Pinta el objeto seleccionado en el área correspondiente
        /// </summary>
        private void pintarSeleccionado()
        {
            Utilidades.DirectorioRaiz directorio = new DirectorioRaiz();
            this.lNombreSeleccionado.Text = this.controlador.Seleccionado.Nombre;
            this.lCapacidad.Text = this.controlador.Seleccionado.Capacidad.ToString();
            try
            {
                this.pBSeleccionado.Image = new Bitmap(directorio.Directorio + this.controlador.Seleccionado.Imagen);
            }
            catch
            {
                this.pBSeleccionado.Image = new Bitmap(directorio.Directorio + "graficos\\noSeleccionado.bmp");
            }
        }
        #endregion

        #region Borrar Inventario
        /// <summary>
        /// Borra los controles del Inventario porque no se va a usar
        /// </summary>
        private void BorrarInventario()
        {
            this.tAlimentos.Controls.Clear();
            this.tCuraciones.Controls.Clear();
            this.tEducadores.Controls.Clear();
            this.tLimpiadores.Controls.Clear();
            this.tOtros.Controls.Clear();

            this.controlador.InicializarPuntos();
        }
        #endregion

        #region Señalar destino de la mascota
        /// <summary>
        /// Manejador de la pulsación sobre la pantalla.
        /// Cuando pulsamos se marca la coordenada X como destino de la mascota.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void graficoAnimacion_MouseDown(object sender, MouseEventArgs e)
        {
            if (mascota.EstaViva)
            {
                controlador.SetDestino(e.X);
            }
        }
        #endregion

        #region Generar Nueva Mascota
        /// <summary>
        /// Click en la opción de menú "Generar nueva mascota".
        /// Genera una mascota nueva.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void mIGenerarNuevaMascota_Click(object sender, EventArgs e)
        {
            controlador.GenerarNuevaMascota();
            this.activarOpciones();
        }
        #endregion

        #region Generación de objetos
        #region Bocadillo
        /// <summary>
        /// Comprar un bocadillo.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void mIBocadillo_Click(object sender, EventArgs e)
        {
            mascota.Inventario.Insertar(new Alimento("Bocadillo", 20, "graficos//bocata.bmp"));
            mascota.Dinero = mascota.Dinero - 10;
        }
        #endregion

        #region Cerebro
        /// <summary>
        /// Genera un nuevo cerebro, resta su precio y lo inserta en el inventario.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void mICerebro_Click(object sender, EventArgs e)
        {
            mascota.Inventario.Insertar(new Alimento("Cerebro", 70, "graficos//cerebro.bmp"));
            mascota.Dinero = mascota.Dinero - 50;
        }
        #endregion

        #region Botiquín
        /// <summary>
        /// Genera un nuevo botiquín, resta su precio y lo inserta en el inventario.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void mIBotiquin_Click(object sender, EventArgs e)
        {
            mascota.Inventario.Insertar(new Curador("Botiquín", 100, "graficos//botiquin.bmp"));
            mascota.Dinero = mascota.Dinero - 90;
        }
        #endregion

        #region Píldora
        /// <summary>
        /// Genera una nueva píldora, resta su precio y lo inserta en el inventario.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void mIPildora_Click(object sender, EventArgs e)
        {
            mascota.Inventario.Insertar(new Curador("Píldora", 40, "graficos//pildora.bmp"));
            mascota.Dinero = mascota.Dinero - 50;
        }
        #endregion

        #region Termómetro
        /// <summary>
        /// Genera un nuevo termómetro, resta su precio y lo inserta en el inventario.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void mITermometro_Click(object sender, EventArgs e)
        {
            mascota.Inventario.Insertar(new Curador("Termómetro", 8, "graficos//termometro.bmp"));
            mascota.Dinero = mascota.Dinero - 20;
        }
        #endregion

        #region Patito
        /// <summary>
        /// Genera un nuevo patito, resta su precio y lo inserta en el inventario.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void mIPatito_Click(object sender, EventArgs e)
        {
            mascota.Inventario.Insertar(new Limpiador("Patito de goma", 70, "graficos//higiene.bmp"));
            mascota.Dinero = mascota.Dinero - 80;
        }
        #endregion

        #region Libro
        /// <summary>
        /// Genera un nuevo libro, resta su precio y lo inserta en el inventario.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void mILibro_Click(object sender, EventArgs e)
        {
            mascota.Inventario.Insertar(new Educador("Libro", 10, "graficos//libro.bmp"));
            mascota.Dinero = mascota.Dinero-20;
        }
        #endregion
        #endregion


        #region Desactivar Opciones por mascota muerta
        /// <summary>
        /// Desactiva todas las opciones que no tienen sentido cuando la mascota está muerta.
        /// </summary>
        private void desactivarOpciones()
        {
            this.bConexiones.Enabled = false;
            this.BVerInventario.Enabled = false;
            this.BJuegos.Enabled = false;
            this.mICompras.Enabled = false;
            this.MIVerInventario.Enabled = false;
        }
        #endregion

        #region Activar Opciones por mascota nueva
        /// <summary>
        /// Activa las opciones cuando generamos una nueva mascota.
        /// </summary>
        private void activarOpciones()
        {
            this.bConexiones.Enabled = true;
            this.BVerInventario.Enabled = true;
            this.BJuegos.Enabled = true;
            this.mICompras.Enabled = true;
            this.MIVerInventario.Enabled = true;
        }
        #endregion
    }
}