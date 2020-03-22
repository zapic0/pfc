using System;
using System.Collections.Generic;
using System.Text;

namespace MascotaVirtual.VidaMascota.Modelo.Objetos
{
    /// <summary>
    /// Clase de Objeto con propiedades Higiénicas
    /// </summary>
    public class Limpiador : Objeto
    {
        #region Implementación métodos abstractos
        /// <summary>
        /// Devuelve el tipo de objeto
        /// </summary>
        public override string Tipo
        {
            get
            {
                return "Limpiador";
            }
        }
        /// <summary>
        /// Implementa el método abstracto toString de la clase Objeto
        /// </summary>
        /// <returns>Cadena con el nombre y la capacidad del objeto</returns>
        public override string Imprimir()
        {
            return (nombre + ' ' + capacidad.ToString());
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre">Nombre del limpiador</param>
        /// <param name="capacidad">Capacidad de limpieza</param>
        /// <param name="imagen">Ruta de la imagen</param>
        public Limpiador(string nombre, int capacidad, string imagen)
        {
            this.nombre = nombre;
            this.capacidad = capacidad;
            this.imagen = imagen;
        }
        /// <summary>
        /// Constructor por defecto del limpiador
        /// </summary>
        public Limpiador()
        {
            Nombre = "";
            Capacidad = 0;
            Imagen = "";
        }
        #endregion
    }
}
