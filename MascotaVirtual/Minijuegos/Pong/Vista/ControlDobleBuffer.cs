using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace MascotaVirtual.Minijuegos.Pong.Vista
{
    /// <summary>
    /// Control de doble buffer de los gráficos del Pong.
    /// Tiene métodos especiales para pintar cada elemento del modelo.
    /// </summary>
    public class ControlDobleBuffer : System.Windows.Forms.Control
    {
        private Graphics grafico;
        private Graphics offGrafico;
        private Bitmap offDibujo;
        private Bitmap raqueta;
        private Bitmap pelota;
        private Bitmap pista;
        private ImageAttributes atributos;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ControlDobleBuffer()
        {
            grafico = this.CreateGraphics();
            offDibujo = new Bitmap(1,1);
            offGrafico = Graphics.FromImage(offDibujo);
            raqueta = new Bitmap(1, 1);
            pelota = new Bitmap(1, 1);
            pista = new Bitmap(1, 1);
        }
        #endregion

        #region Incialización del control
        /// <summary>
        /// Inicializa el control.
        /// </summary>
        /// <param name="width">Ancho.</param>
        /// <param name="height">Alto.</param>
        public void Inicializa(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            string directorio = new Utilidades.DirectorioRaiz().Directorio;
            raqueta = new Bitmap(directorio + "graficos//zombieRaqueta.bmp");
            pelota = new Bitmap(directorio + "graficos//cerebroPelota.bmp");
            pista = new Bitmap(directorio + "graficos//pista.bmp");
            atributos = new ImageAttributes();
            atributos.SetColorKey(raqueta.GetPixel(0,0),raqueta.GetPixel(0,0));
            offDibujo = new Bitmap(this.Width, this.Height);
            offGrafico = Graphics.FromImage(offDibujo);
        }
        #endregion

        #region Pinta en segundo plano
        /// <summary>
        /// Pinta en segundo plano el trozo enmarcado por fuente de la imagen nuevoDibujo en el trozo enmarcado por destino.
        /// </summary>
        /// <param name="destino">El rectángulo de destino.</param>
        /// <param name="fuente">El rectángulo fuente.</param>
        /// <param name="nuevoDibujo">El nuevo dibujo.</param>
        public void Pinta(Rectangle destino, Rectangle fuente, Bitmap nuevoDibujo)
        {
            int sourceX = fuente.X;
            int sourceY = fuente.Y;
            int width = fuente.Width;
            int height = fuente.Height;
            ImageAttributes atributos = new ImageAttributes();
            Color color = nuevoDibujo.GetPixel(0, 0);
            atributos.SetColorKey(color, color);
            offGrafico.DrawImage(nuevoDibujo, destino, sourceX, sourceY, width, height, GraphicsUnit.Pixel, atributos);
        }
        #endregion

        #region Pintar Cadena
        /// <summary>
        /// Pinta una cadena de texto donde nosotros decimos, con la fuente que le pasamos.
        /// </summary>
        /// <param name="texto">Texto a pintar.</param>
        /// <param name="punto">Punto en que se pintara (X e Y superior izquierda).</param>
        /// <param name="fuente">Fuente de texto.</param>
        public void PintaString(string texto, Point punto, Font fuente)
        {
            SolidBrush pincel = new SolidBrush(Color.Black);
            offGrafico.DrawString(texto, fuente, pincel, punto.X, punto.Y);
        }
        #endregion

        #region Pintar Raqueta
        /// <summary>
        /// Pinta una raqueta de la longitud que indicamos donde nosotros pedimos.
        /// Modificada, versión final sólo pinta la imagen que le indicamos.
        /// </summary>
        /// <param name="longitud">Longitud de la raqueta</param>
        /// <param name="rectangulo">Rectángulo en que se pintará</param>
        /// <param name="color">Color de la raqueta</param>
        public void PintaRaqueta(int longitud, Rectangle rectangulo, Color color)
        {
            //offGrafico.DrawImage(raqueta,rectangulo,new Rectangle(0,0,raqueta.Width,raqueta.Height),GraphicsUnit.Pixel);
            offGrafico.DrawImage(raqueta, rectangulo, 0, 0, raqueta.Width, raqueta.Height, GraphicsUnit.Pixel, atributos);
            //Pen boligrafo = new Pen(color,1);
            //offGrafico.DrawRectangle(boligrafo, rectangulo);
        }
        #endregion

        #region Pintar Bala
        /// <summary>
        /// Pinta una bala en la posición que indicamos.
        /// </summary>
        /// <param name="Posicion">Posición en que pintar la bala.</param>
        /// <param name="color">Color de la bala.</param>
        public void PintaBala(Point Posicion,Color color)
        {
            Pen boligrafo = new Pen(color, 2);
            offGrafico.DrawRectangle(boligrafo,new Rectangle(Posicion.X,Posicion.Y,1,1));
        }
        #endregion

        #region Pintar Bola
        /// <summary>
        /// Pintar la Bola en la posición indicada.
        /// Versión final: ahora se pinta una imagen.
        /// </summary>
        /// <param name="Posicion">Posición en la que se pinta la bala</param>
        public void PintaBola(Point Posicion)
        {
            Rectangle rectangulo = new Rectangle(Posicion.X - 10, Posicion.Y - 10, 20, 20);
            offGrafico.DrawImage(pelota, rectangulo, 0, 0, pelota.Width, pelota.Height, GraphicsUnit.Pixel, atributos);
            //Pen boligrafo=new Pen(Color.Black, 5);
            //offGrafico.DrawEllipse(boligrafo,new Rectangle(Posicion.X,Posicion.Y,1,1));
        }
        #endregion

        #region Mostrar
        /// <summary>
        /// Pinta en primer plano (lo que se ve por pantalla) y borra el segundo plano
        /// </summary>
        public void Muestra()
        {
            Rectangle source = new Rectangle(0, 0, this.Width, this.Height);
            grafico.DrawImage(offDibujo, 0, 0, source, GraphicsUnit.Pixel);
            //this.offGrafico.DrawImage(pista, 0, 0, new Rectangle(0, 0, pista.Width, pista.Height), GraphicsUnit.Pixel);
            this.offGrafico.DrawImage(pista, new Rectangle(0, 0, offDibujo.Width, offDibujo.Height), new Rectangle(0, 0, pista.Width, pista.Height), GraphicsUnit.Pixel);
            //this.offGrafico.Clear(Color.Brown);
        }
        #endregion
    }
}
