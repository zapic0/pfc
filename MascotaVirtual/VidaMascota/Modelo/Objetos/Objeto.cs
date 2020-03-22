using System;
using System.Collections.Generic;
using System.Text;

namespace MascotaVirtual.VidaMascota.Modelo.Objetos
{
    /// <summary>
    /// Clase abstracta de tipo Objeto
    /// </summary>
    public abstract class Objeto
    {
        #region Propiedades
        /// <summary>
        /// Valor en porcentaje de la característica principal del objeto
        /// </summary>
        protected int capacidad;
        /// <summary>
        /// Nombre del objeto
        /// </summary>
        protected string nombre;
        /// <summary>
        /// Ruta de la imagen
        /// </summary>
        protected string imagen;
        /// <summary>
        /// Tipo del Objeto
        /// </summary>
        protected string tipo;
        #endregion

        #region Getter y Setter
        /// <summary>
        /// Getter y Setter del tipo de objeto
        /// </summary>
        public abstract string Tipo
        {
            get;
        }
        /// <summary>
        /// Getter y Setter de capacidad
        /// </summary>
        public int Capacidad
        {
            get{return capacidad;}
            set{capacidad=value;}
        }
        /// <summary>
        /// Getter y Setter de nombre
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        /// <summary>
        /// Getter y Setter de imagen
        /// </summary>
        public string Imagen
        {
            get{return imagen;}
            set { imagen = value; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Propiedades capacidad y nombre en texto
        /// </summary>
        /// <returns>Cadena con la capacidad y el nombre del objeto</returns>
        public abstract string Imprimir();
        #endregion
    }
}
