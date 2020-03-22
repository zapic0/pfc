using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MascotaVirtual.Minijuegos.Palomas.Modelo
{
    /// <summary>
    /// Clase paloma para el minijuego de las palomas.
    /// </summary>
    public class Paloma
    {
        int numeroFrame;
        int framesMuerta;
        bool girado;

        #region Viva
        private bool viva;
        /// <summary>
        /// Devuelve si la paloma está viva o no.
        /// </summary>
        public bool Viva
        {
            get { return viva; }
            set { viva = value; }
        }
        #endregion

        #region Desaparecida
        private bool desaparecida;
        /// <summary>
        /// Devuelve si la paloma debe mostrarse o no.
        /// </summary>
        public bool Desaparecida
        {
            get { return desaparecida; }
            set { desaparecida = value; }
        }
        #endregion

        #region Imagen
        private Bitmap imagen;
        /// <summary>
        /// Devuelve la imagen de la paloma.
        /// </summary>
        public Bitmap Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        #endregion

        #region Imagen al Revés
        private Bitmap imagenFlip;
        /// <summary>
        /// Devuelve la imagen de la paloma girada.
        /// </summary>
        public Bitmap ImagenFlip
        {
            get { return imagenFlip; }
            set { imagenFlip = value; }
        }
        #endregion


        #region Posicion
        private Point posicion;
        /// <summary>
        /// Posición de la paloma.
        /// </summary>
        public Point Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
        #endregion

        #region Tamaño
        private Size tamano;
        /// <summary>
        /// Tamaño de la paloma.
        /// </summary>
        public Size Tamano
        {
            get { return tamano; }
            set { tamano = value; }
        }
        #endregion

        #region Frame
        private Rectangle frame;
        /// <summary>
        /// Rectángulo que enmarca el frame actual de la animación de la paloma.
        /// </summary>
        public Rectangle Frame
        {
            get { return frame; }
            set { frame = value; }
        }
        #endregion


        #region Constructor
        /// <summary>
        /// Constructor de la paloma.
        /// </summary>
        public Paloma()
        {
            posicion = new Point(0, 0);
            tamano = new Size(0, 0);
            imagen = new Bitmap(tamano.Width, tamano.Height);
        }
        #endregion

        #region Constructor con parámetros
        /// <summary>
        /// Constructor con parámetros de la paloma.
        /// </summary>
        /// <param name="posicionX">Coordenada X de la posición de la paloma.</param>
        /// <param name="posicionY">Coordenada Y de la posición de la paloma.</param>
        /// <param name="tamanoAncho">Ancho de la paloma.</param>
        /// <param name="tamanoAlto">Alto de la paloma.</param>
        /// <param name="rutaImagen">Ruta de la imagen de la paloma.</param>
        public Paloma(int posicionX, int posicionY, int tamanoAncho, int tamanoAlto, string rutaImagen)
        {
            posicion = new Point(posicionX, posicionY);
            tamano = new Size(tamanoAncho, tamanoAlto);
            imagen = new Bitmap(rutaImagen);
            numeroFrame = 0;
            framesMuerta = 5;
            desaparecida = false;
            viva = true;
            girado = false;
            frame = new Rectangle(0, 0, 22, imagen.Height);
        }
        #endregion

        #region Mover Paloma
        /// <summary>
        /// Mover la paloma a la velocidad indicada.
        /// </summary>
        /// <param name="velocidadX">Píxels que se moverá en horizontal.</param>
        /// <param name="velocidadY">Píxels que se moverá en vertical.</param>
        public void Mover(int velocidadX, int velocidadY)
        {
            posicion.X += velocidadX;
            posicion.Y += velocidadY;
            if (numeroFrame <= 5)
            {
                numeroFrame++;
            }
            else
            {
                if (numeroFrame == 6)
                {
                    frame = new Rectangle(22, 0, 23, imagen.Height);
                }
                if (numeroFrame < 10)
                {
                    numeroFrame++;
                }
                else
                {
                    numeroFrame = 0;
                    frame = new Rectangle(0, 0, 22, imagen.Height);
                }
            }
        }
        #endregion
        #region Girar paloma
        /// <summary>
        /// Girar la paloma.
        /// </summary>
        public void GirarPaloma()
        {
            girado = true;
            imagenFlip = new Bitmap(new Utilidades.DirectorioRaiz().Directorio + "graficos//palomaflip.bmp");
            Graphics pintador = Graphics.FromImage(imagenFlip);
            Rectangle source = new Rectangle(0, 0, imagen.Width, imagen.Height);
            Rectangle destino = new Rectangle(imagen.Width, 0, -imagen.Width, imagen.Height);
            pintador.DrawImage(imagen, destino, source, GraphicsUnit.Pixel);
            Imagen = imagenFlip;
        }
        #endregion
        #region Pegamos a la Paloma
        /// <summary>
        /// Devuelve si hemos pegado a la paloma en el punto en el que hemos disparado.
        /// </summary>
        /// <param name="coordenadaX">Coordenada X en la que disparamos.</param>
        /// <param name="coordenadaY">Coordenada Y en la que disparamos.</param>
        /// <returns>True si pegamos a la paloma, false en caso contrario.</returns>
        public bool Tocado(int coordenadaX, int coordenadaY)
        {
            Rectangle rectanguloPaloma = new Rectangle(posicion.X, posicion.Y, tamano.Width, tamano.Height);
            Point puntoPulsado = new Point(coordenadaX, coordenadaY);
            if (rectanguloPaloma.Contains(puntoPulsado))
            {
                viva = false;
                if (!girado)
                {
                    this.imagen = new Bitmap(new Utilidades.DirectorioRaiz().Directorio + "graficos//palomaMuerta.bmp");
                }
                else
                {
                    this.imagen = new Bitmap(new Utilidades.DirectorioRaiz().Directorio + "graficos//palomaMuertaFlip.bmp");
                }
                frame = new Rectangle(0, 0, imagen.Width, imagen.Height);
                return true;
            }
            return false;
        }
        #endregion
        #region Matar a la Paloma
        /// <summary>
        /// Mata la paloma.
        /// </summary>
        public void Matar()
        {
            if (framesMuerta > 0)
            {
                framesMuerta--;
            }
            else
            {
                desaparecida = true;
                framesMuerta = 5;
            }
        }
        #endregion
    }
}
