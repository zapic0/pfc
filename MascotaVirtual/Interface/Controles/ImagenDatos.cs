using System;
using System.Collections.Generic;
using System.Text;
using MascotaVirtual.VidaMascota.Modelo.Objetos;

namespace MascotaVirtual.Interface.Controles
{
    /// <summary>
    /// Control que muestra una imagen y guarda datos en su interior.
    /// </summary>
    public class ImagenDatos : System.Windows.Forms.PictureBox
    {
        #region Datos
        private Objeto datos;
        /// <summary>
        /// Objeto que se guarda dentro del control.
        /// </summary>
        public Objeto Datos
        {
            get { return datos; }
            set { datos = value; }
        }
        #endregion

        #region Capacidad
        private int capacidad;
        /// <summary>
        /// Capacidad del objeto que guarda.
        /// </summary>
        public int Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }
        }
        #endregion

        #region Nombre
        private String nombre;
        /// <summary>
        /// Nombre del objeto que guarda.
        /// </summary>
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        #endregion

        #region Ruta de la Imagen
        private String rutaImagen;
        /// <summary>
        /// Ruta de la Imagen del objeto que guarda.
        /// </summary>
        public String RutaImagen
        {
            get { return rutaImagen; }
            set { rutaImagen = value; }
        }
        #endregion

        #region Inicializar
        /// <summary>
        /// Inicialización del control, que guardará los datos del objeto que le pasamos por parámetros.
        /// </summary>
        /// <param name="objeto">Objeto a guardar (alimento, limpiador...).</param>
        public void Inicializar(Objeto objeto)
        {
            Utilidades.DirectorioRaiz directorio = new MascotaVirtual.Utilidades.DirectorioRaiz();
            this.datos = objeto;
            this.capacidad = objeto.Capacidad;
            this.nombre = objeto.Nombre;
            this.Size = new System.Drawing.Size(50, 50);
            this.rutaImagen = directorio.Directorio + objeto.Imagen;
            try
            {
                this.Image = new System.Drawing.Bitmap(this.rutaImagen);
            }
            catch
            {
                this.Image = new System.Drawing.Bitmap(directorio.Directorio + "graficos\\noSeleccionado.bmp");
            }
        }
        #endregion
    }
}
