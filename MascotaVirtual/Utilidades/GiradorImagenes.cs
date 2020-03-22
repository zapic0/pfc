using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MascotaVirtual.Utilidades
{
    /// <summary>
    /// Clase cuyo único método permite girar imágenes.
    /// </summary>
    public class GiradorImagenes
    {
        #region Girar Imagen
        /// <summary>
        /// Gira la imagen que se le pasa por parámetros y la devuelve.
        /// </summary>
        /// <param name="imagen">Bitmap con la imagen a girar.</param>
        /// <returns>Imagen girada 180 grados.</returns>
        public Bitmap GirarImagen(Bitmap imagen)
        {
            Bitmap imagenFlip = new Bitmap(imagen.Width, imagen.Height);
            Graphics pintador = Graphics.FromImage(imagenFlip);
            Rectangle source = new Rectangle(0, 0, imagen.Width, imagen.Height);
            Rectangle destino = new Rectangle(imagen.Width, 0, -imagen.Width, imagen.Height);
            pintador.DrawImage(imagen, destino, source, GraphicsUnit.Pixel);
            imagenFlip.Save(new DirectorioRaiz().Directorio + "graficos//cuerpoReves.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            return imagenFlip;
        }
        #endregion
    }
}
