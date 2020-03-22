using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace MascotaVirtual.Interface.Controles
{
    /// <summary>
    /// Control de Animaci�n.
    /// Se usa para pintar gr�ficos en segundo plano y despu�s mostrar todo junto mediante la t�cnica del doble buffer.
    /// </summary>
    public class ControlAnimacion : System.Windows.Forms.Control
    {
        #region Gr�fico
        /// <summary>
        /// Gr�fico que se pinta en pantalla
        /// </summary>
        protected Graphics grafico;
        #endregion

        #region Gr�fico en segundo plano
        /// <summary>
        /// Gr�fico que utilizamos para pintar en segundo plano
        /// </summary>
        protected Graphics offGrafico;
        #endregion

        #region Dibujo
        /// <summary>
        /// Dibujo que iremos pintando en "grafico"
        /// </summary>
        protected Bitmap dibujo;
        /// <summary>
        /// Dibujo que iremos pintando en "grafico"
        /// </summary>
        public Bitmap Dibujo
        {
            get
            {
                return dibujo;
            }
            set
            {
                dibujo = value;
            }
        }
        #endregion

        #region Dibujo en segundo plano
        /// <summary>
        /// Dibujo sobre el que dibuja "offGrafico"
        /// </summary>
        protected Bitmap offDibujo;
        #endregion

        #region Liberaci�n de la memoria
        /// <summary>
        /// Liberaci�n de la memoria.
        /// </summary>
        /// <param name="disposing">True si hay que liberar la base</param>
        new public void Dispose(bool disposing)
        {
            grafico.Dispose();
            offGrafico.Dispose();
            dibujo.Dispose();
            offDibujo.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ControlAnimacion()
        {
            grafico = this.CreateGraphics();
            offDibujo = new Bitmap(1,1);
            offGrafico = Graphics.FromImage(offDibujo);
        }
        #endregion

        #region Iniciacilizar
        /// <summary>
        /// Inicializa el ancho y alto de la animaci�n.
        /// Inicializa el dibujo y el gr�fico del segundo plano.
        /// </summary>
        /// <param name="width">Ancho de la animaci�n.</param>
        /// <param name="height">Alto de la animaci�n.</param>
        public void Inicializa(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            offDibujo = new Bitmap(this.Width, this.Height);
            offGrafico = Graphics.FromImage(offDibujo);
        }
        #endregion

        #region Pintar
        /// <summary>
        /// Pinta el trozo enmarcado por el rect�ngulo fuente de la imagen "dibujo" dentro del rect�ngulo destino del "gr�fico".
        /// </summary>
        /// <param name="destino">Rect�ngulo en el que queremos pintar</param>
        /// <param name="fuente">Rect�ngulo del que queremos pintar</param>
        public void Pinta(Rectangle destino, Rectangle fuente)
        {
            int sourceX = fuente.X;
            int sourceY = fuente.Y;
            int width = fuente.Width;
            int height = fuente.Height;
            ImageAttributes atributos = new ImageAttributes();
            Color color = dibujo.GetPixel(0, 0);
            atributos.SetColorKey(color, color);
            offGrafico.DrawImage(dibujo, destino, sourceX, sourceY, width, height, GraphicsUnit.Pixel, atributos);
        }
        #endregion

        #region Muestra
        /// <summary>
        /// Muestra todo lo que est� pintado en segundo plano pint�ndolo sobre el gr�fico de primer plano.
        /// </summary>
        /// <param name="color">Color con el que queremos "limpiar" el fondo del gr�fico de segundo plano.</param>
        public void Muestra(Color color)
        {
            Rectangle source = new Rectangle(0,0,offDibujo.Width,offDibujo.Height);
            grafico.DrawImage(offDibujo, 0, 0, source, GraphicsUnit.Pixel);
            this.offGrafico.Clear(color);
        }
        #endregion
    }
}
