using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using MascotaVirtual.VidaMascota.Modelo.Objetos;
using MascotaVirtual.Comunicaciones;
using MascotaVirtual.VidaMascota.Modelo;

namespace MascotaVirtual.VidaMascota.Controlador
{
    /// <summary>
    /// Controlador que emula la vida de la mascota
    /// </summary>
    public class ControladorVida
    {
        private Mascota mascota;

        #region Temporizadores
        private Timer animacion;
        private Timer hambre;
        private Timer salud;
        private Timer higiene;
        private Timer educacion;
        private Timer diversion;
        private Timer dinero;
        private Timer puntosDeVida;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ControladorVida(Mascota mascota)
        {
            this.mascota = mascota;
            inicializarTemporizadores();
            this.animacion.Interval = 1000/90;
            this.hambre.Interval = 10000;
            this.salud.Interval = 30000;
            this.higiene.Interval = 50000;
            this.educacion.Interval = 60000;
            this.diversion.Interval = 20000;
            this.puntosDeVida.Interval = 100000;
            this.dinero.Interval = 120000;
        }
        #endregion

        #region Lógica Temporizadores
        #region Inicializar los Temporizadores
        /// <summary>
        /// Inicializar los temporizadores.
        /// </summary>
        private void inicializarTemporizadores()
        {
            this.animacion = new Timer();
            this.salud = new Timer();
            this.puntosDeVida = new Timer();
            this.educacion = new Timer();
            this.diversion = new Timer();
            this.hambre = new Timer();
            this.higiene = new Timer();
            this.dinero = new Timer();

            animacion.Tick += new EventHandler(animacion_Tick);
            salud.Tick += new EventHandler(salud_Tick);
            puntosDeVida.Tick += new EventHandler(puntosDeVida_Tick);
            educacion.Tick += new EventHandler(educacion_Tick);
            diversion.Tick += new EventHandler(diversion_Tick);
            hambre.Tick += new EventHandler(hambre_Tick);
            higiene.Tick += new EventHandler(higiene_Tick);
            dinero.Tick += new EventHandler(dinero_Tick);

            this.animacion.Enabled = true;
            this.salud.Enabled = true;
            this.puntosDeVida.Enabled = true;
            this.educacion.Enabled = true;
            this.diversion.Enabled = true;
            this.hambre.Enabled = true;
            this.higiene.Enabled = true;
            this.dinero.Enabled = true;
        }
        #endregion

        #region Subir dinero
        /// <summary>
        /// Maneja el evento de enviar el dinero.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void dinero_Tick(object sender, EventArgs e)
        {
            mascota.Dinero = mascota.Dinero+(mascota.Higiene + mascota.Salud + mascota.Educacion + mascota.Diversion - mascota.Hambre) / 10;
        }
        #endregion
        #region Higiene
        /// <summary>
        /// Maneja el evento Tick event del control higiene.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumento.</param>
        void higiene_Tick(object sender, EventArgs e)
        {
            this.mascota.Higiene--;
        }
        #endregion
        #region Salud
        /// <summary>
        /// Maneja el evento Tick event del control salud.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumento.</param>
        void salud_Tick(object sender, EventArgs e)
        {
            this.mascota.Salud--;
        }
        #endregion
        #region Puntos de Vida
        /// <summary>
        /// Maneja el evento Tick event del control puntos de vida.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumento.</param>
        void puntosDeVida_Tick(object sender, EventArgs e)
        {
            this.mascota.PuntosVida--;
        }
        #endregion
        #region Educación
        /// <summary>
        /// Maneja el evento Tick event del control educación.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumento.</param>
        void educacion_Tick(object sender, EventArgs e)
        {
            this.mascota.Educacion--;
        }
        #endregion
        #region Diversión
        /// <summary>
        /// Maneja el evento Tick event del control diversión.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumento.</param>
        void diversion_Tick(object sender, EventArgs e)
        {
            this.mascota.Diversion--;
        }
        #endregion
        #region Hambre
        /// <summary>
        /// Maneja el evento Tick event del control hambre.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumento.</param>
        void hambre_Tick(object sender, EventArgs e)
        {
            this.mascota.Hambre++;
        }
        #endregion
        #region Temporizador avisa del refresco de la imagen
        /// <summary>
        /// Maneja el evento Tick del control animación.
        /// Avisa de que hay que refrescar la imagen.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumento.</param>
        void animacion_Tick(object sender, EventArgs e)
        {
            this.mascota.PasarFrame();
            if (mascota.PuntoReferencia.X > mascota.Destino.X)
            {
                int x = mascota.PuntoReferencia.X - 1;
                int y = mascota.PuntoReferencia.Y;
                mascota.PuntoReferencia = new Point(x, y);
            }
            else if (mascota.PuntoReferencia.X < mascota.Destino.X)
            {
                int x = mascota.PuntoReferencia.X + 1;
                int y = mascota.PuntoReferencia.Y;
                mascota.PuntoReferencia = new Point(x, y);
            }
            else if (mascota.PuntoReferencia.X == mascota.Destino.X)
            {
                mascota.Girar(false);
                mascota.SeleccionarAnimacion(0);
            }
        }
        #endregion
        #endregion

        #region Pasar Turno
        /// <summary>
        /// Pasa un turno para la mascota con las consecuencias que acarree en su comportamiento
        /// </summary>
        public void PasaTurno()
        {
            mascota.Hambre++;
            mascota.Higiene--;
            mascota.Diversion--;
            mascota.Educacion--;
            mascota.PuntosVida--;
            mascota.Salud--;
        }
        #endregion

        #region Set Destino
        /// <summary>
        /// Pone el punto de destino al que se dirige la mascota
        /// </summary>
        /// <param name="punto">Punto al que se dirige la mascota</param>
        public void SetDestino(int punto)
        {
            int y = mascota.PuntoReferencia.Y;
            int x = punto;
            mascota.Destino = new Point(x, y);
        }
        #endregion

        #region Botones Inventario y Seleccionado
        private Objeto seleccionado;
        private Point posicionAlimentos;
        private Point posicionCuradores;
        private Point posicionLimpiadores;
        private Point posicionOtros;
        private Point posicionEducadores;

        #region Seleccionado
        /// <summary>
        /// Getter y Setter del objeto seleccionado
        /// </summary>
        public Objeto Seleccionado
        {
            get { return seleccionado; }
            set { seleccionado = value; }
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

        #region Usar objeto Seleccionado
        /// <summary>
        /// Usa el objeto seleccionado
        /// </summary>
        public void UsarSeleccionado()
        {
            if (seleccionado.Nombre != "No seleccionado")
            {
                switch (seleccionado.Tipo)
                {
                    case ("Alimento"):
                        {
                            this.mascota.Alimentar((Alimento)seleccionado);
                            break;
                        }
                    case ("Curador"):
                        {
                            this.mascota.Curar((Curador)seleccionado);
                            break;
                        }
                    case ("Educador"):
                        {
                            this.mascota.Educar((Educador)seleccionado);
                            break;
                        }
                    case ("Limpiador"):
                        {
                            this.mascota.Limpiar((Limpiador)seleccionado);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                this.EliminarSeleccionado();
            }
        }
        #endregion

        #region Eliminar Objeto Seleccionado
        /// <summary>
        /// Elimina el objeto seleccionado del inventario
        /// </summary>
        public void EliminarSeleccionado()
        {
            this.mascota.Inventario.Eliminar(seleccionado);
            this.InicializarSeleccionado();
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

        #region Numero de Objetos
        /// <summary>
        /// Devuelve el número de Objetos del inventario
        /// </summary>
        /// <returns>Número de Objetos del inventario</returns>
        public int NumeroObjetos()
        {
            return this.mascota.NumeroObjetos();
        }
        #endregion

        #region Inventario
        /// <summary>
        /// Devuelve el inventario de la mascota
        /// </summary>
        /// <returns>Lista de Objetos con el inventario</returns>
        public ListaObjetos Inventario()
        {
            return this.mascota.Inventario;
        }
        #endregion
        #endregion

        #region Paralizar y reiniciar la animación
        #region Parar la Animación
        /// <summary>
        /// Para la animación en la ventana principal
        /// </summary>
        public void PararAnimacion()
        {
            this.animacion.Enabled = false;
        }
        #endregion

        #region Volver a iniciar la animación
        /// <summary>
        /// Reinicia la animación de la mascota
        /// </summary>
        public void ReiniciarAnimacion()
        {
            this.animacion.Enabled = true;
        }
        #endregion
        #endregion

        #region Serializar
        /// <summary>
        /// Serializa la mascota para que la podamos usar en el futuro en el punto en que la dejamos.
        /// </summary>
        public void Serializar()
        {
            mascota.Serializar(false);
        }
        #endregion
        #region Generar nueva mascota
        /// <summary>
        /// Genera una nueva mascota.
        /// </summary>
        public void GenerarNuevaMascota()
        {
            mascota.GenerarNuevaMascota();
        }
        #endregion
    }
}
