using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace MascotaVirtual.Interface.Controles
{
    /// <summary>
    /// Control utilizado para mostrar animaciones.
    /// Se le pasa una imagen ya generada y se encarga de pintarla.
    /// </summary>
    public class ControlGrafico : System.Windows.Forms.Control
    {
        #region Gráfico
        /// <summary>
        /// Gráfico que usaremos para pintar en pantalla.
        /// </summary>
        protected Graphics grafico;
        #endregion

        #region Liberación de memoria
        /// <summary>
        /// Libera la memoria del control.
        /// </summary>
        /// <param name="disposing">True si hay que seguir liberando memoria de la base.</param>
        new public void Dispose(bool disposing)
        {
            grafico.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public ControlGrafico()
        {
            grafico = this.CreateGraphics();
        }
        #endregion

        #region Inicializar
        /// <summary>
        /// Inicializa el control con los valores del ancho y alto del mismo.
        /// </summary>
        /// <param name="width">Ancho.</param>
        /// <param name="height">Alto.</param>
        public void Inicializa(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        #endregion

        #region Muestra
        /// <summary>
        /// Muestra en pantalla del dibujo que se le pasa por parámetro.
        /// </summary>
        /// <param name="dibujo">Dibujo que queremos pintar.</param>
        public void Muestra(Bitmap dibujo)
        {
            Rectangle source = new Rectangle(0, 0, dibujo.Width, dibujo.Height);
            grafico.DrawImage(dibujo, 0, 0, source, GraphicsUnit.Pixel);
        }
        #endregion
    }
}