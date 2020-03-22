using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using MascotaVirtual.VidaMascota.Modelo.Componentes;

namespace MascotaVirtual.VidaMascota.Modelo.Componentes
{
    /// <summary>
    /// Clase abstracta de la que heredar�n todos los componentes de la mascota
    /// </summary>
    public class Componente
    {
        #region Constructor
        /// <summary>
        /// Clase que especifica los diferentes componentes que conforman una misma mascota
        /// Por ejemplo son componentes la cabeza o las piernas de la mascota
        /// </summary>
        public Componente()
        {
            nombre = "";
            rutaImagen = "";

            this.datosAnimacionQuieto = new DatosComponente[2];
            this.datosAnimacionCaminar = new DatosComponente[6];
            this.datosAnimacionCaminarGirado = new DatosComponente[6];
            this.datosAnimacionQuietoGirado = new DatosComponente[2];

            gradoVida = 0;
            frame = 0;
            this.datosAnimacionQuieto[0] = new DatosComponente();
            this.datosAnimacionQuieto[1] = new DatosComponente();
            this.datosAnimacionQuietoGirado[0] = new DatosComponente();
            this.datosAnimacionQuietoGirado[1] = new DatosComponente();
            for (int i = 0; i < 6; i++)
            {
                this.datosAnimacionCaminar[i] = new DatosComponente();
                this.datosAnimacionCaminarGirado[i] = new DatosComponente();
            }
            arraySeleccionado = datosAnimacionQuieto;
        }
        #endregion

        #region Girado
        private bool girado;
        /// <summary>
        /// Nos indica si el componente est� girado (mirando a la derecha) o no
        /// </summary>
        public bool Girado
        {
            get { return girado; }
            set { girado = value; }
        }
        #endregion

        #region Nombre
        private string nombre;
        /// <summary>
        /// Nombre del Componente
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        #endregion

        #region Ruta Imagen
        private string rutaImagen;
        /// <summary>
        /// Ruta en la que se encuentra la imagen de la que se carga la animaci�n del componente
        /// </summary>
        public string RutaImagen
        {
            get { return rutaImagen; }
            set { rutaImagen = value; }
        }

        #endregion


        #region Array Seleccionado
        private DatosComponente[] arraySeleccionado;
        /// <summary>
        /// Array seleccionado en funci�n de si se est� girado o en movimiento
        /// </summary>
        public DatosComponente[] ArraySeleccionado
        {
            get { return arraySeleccionado; }
            set { arraySeleccionado = value; }
        }

        #endregion

        #region Array de datos de la animaci�n quieto
        private DatosComponente[] datosAnimacionQuieto;
        /// <summary>
        /// Array que contiene los rect�ngulos y la separaci�n respecto al punto de referencia cuando la mascota est� parada
        /// </summary>
        public DatosComponente[] DatosAnimacionQuieto
        {
            get { return datosAnimacionQuieto; }
            set { datosAnimacionQuieto = value; }
        }
        #endregion

        #region Array de datos de la animaci�n caminar
        private DatosComponente[] datosAnimacionCaminar;
        /// <summary>
        /// Array que contiene los rect�ngulos y la separaci�n respecto al punto de referencia cuando la mascota est� andando
        /// </summary>
        public DatosComponente[] DatosAnimacionCaminar
        {
            get { return datosAnimacionCaminar; }
            set { datosAnimacionCaminar = value; }
        }
        #endregion

        #region Array de datos de la animaci�n quieto girado
        private DatosComponente[] datosAnimacionQuietoGirado;
        /// <summary>
        /// Array que contiene los rect�ngulos y la separaci�n respecto al punto de referencia cuando la mascota est� parada y girada hacia la derecha
        /// </summary>
        public DatosComponente[] DatosAnimacionQuietoGirado
        {
            get { return datosAnimacionQuietoGirado; }
            set { datosAnimacionQuietoGirado = value; }
        }
        #endregion

        #region Array de datos de la animaci�n caminar girado
        private DatosComponente[] datosAnimacionCaminarGirado;
        /// <summary>
        /// Array que contiene los rect�ngulos y la separaci�n respecto al punto de referencia cuando la mascota est� andando y girada a la derecha
        /// </summary>
        public DatosComponente[] DatosAnimacionCaminarGirado
        {
            get { return datosAnimacionCaminarGirado; }
            set { datosAnimacionCaminarGirado = value; }
        }
        #endregion


        #region Grado de vida
        private int gradoVida;
        /// <summary>
        /// Indica el grado de vida de la mascota
        /// </summary>
        public int GradoVida
        {
            get { return gradoVida; }
            set { gradoVida = value; }
        }
        #endregion

        #region Frame de la animaci�n actual
        private int frame;
        /// <summary>
        /// Indica el frame de la animaci�n que toca cargar a continuaci�n
        /// </summary>
        public int Frame
        {
            get { return frame; }
            set { frame = value; }
        }
        #endregion

        #region Datos del componente que enmarca el frame actual
        /// <summary>
        /// Datos del componente del frame actual de la animaci�n
        /// </summary>
        public DatosComponente DatoComponente
        {
            get
            {
                return arraySeleccionado[frame / 10];
            }
            set
            {
                arraySeleccionado[frame / 10] = value;
            }
        }
        #endregion


        #region Pasar Frame
        /// <summary>
        /// Pasa un Frame de la animaci�n que se est� mostrando en pantalla
        /// </summary>
        public void PasarFrame()
        {
            if (frame < (arraySeleccionado.Length * 10) - 1)
            {
                frame++;
                if (DatoComponente.RectanguloFuente.Width == -1)
                {
                    frame = 0;
                }
            }
            else
            {
                frame = 0;
            }
        }
        #endregion

        #region Seleccionar Animaci�n
        /// <summary>
        /// Selecciona la animaci�n en funci�n de si est� en movimiento y si est� girado
        /// </summary>
        /// <param name="animacion">0 � 1, quieto o parado</param>
        /// <param name="girado">Es verdadero si la mascota mira a la derecha, sino ser� false</param>
        public void SeleccionarAnimacion(int animacion,bool girado)
        {
            this.girado = girado;
            if (animacion == 0)
            {
                if (girado)
                {
                    arraySeleccionado = datosAnimacionQuietoGirado;
                }
                else
                {
                    arraySeleccionado = datosAnimacionQuieto;
                }
            }
            if (animacion == 1)
            {
                if (girado)
                {
                    arraySeleccionado = datosAnimacionCaminarGirado;
                }
                else
                {
                    arraySeleccionado = datosAnimacionCaminar;
                }
            }
        }
        #endregion

        #region Calcular giro
        /// <summary>
        /// Calcula los nuevos valores de los rect�ngulos a partir de los cuales se carga la mascota cuando est� girada
        /// </summary>
        public void CalcularGiro()
        {
            int anchoTotal = datosAnimacionCaminar[datosAnimacionCaminar.Length - 1].RectanguloFuente.Width + datosAnimacionCaminar[datosAnimacionCaminar.Length - 1].RectanguloFuente.X;
            int ancho = 0;
            for (int i = 0; i < datosAnimacionCaminar.Length; i++)
            {
                DatosComponente dato = datosAnimacionCaminar[datosAnimacionCaminar.Length - 1 - i];
                Rectangle rectanguloFrame = dato.RectanguloFuente;
                Rectangle rectanguloResultado = new Rectangle(ancho, rectanguloFrame.Y, rectanguloFrame.Width, rectanguloFrame.Height);
                datosAnimacionCaminarGirado[i].RectanguloFuente = rectanguloResultado;
                
                ancho = ancho + datosAnimacionCaminarGirado[i].RectanguloFuente.Width;
                if (ancho == anchoTotal)
                {
                    ancho = 0;
                }
            }
        }
        #endregion
    }
}
