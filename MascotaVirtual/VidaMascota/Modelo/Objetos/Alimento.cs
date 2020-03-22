using System;
using System.Collections.Generic;
using System.Text;

namespace MascotaVirtual.VidaMascota.Modelo.Objetos
{
    /// <summary>
    /// Clase de Objetos con propiedades alimenticias
    /// </summary>
    public class Alimento:Objeto
    {
        #region Implementación métodos abstractos
        /// <summary>
        /// Getter y Setter de la propiedad Tipo, heredada de la clase Objeto
        /// </summary>

        public override string Tipo
        {
            get { return "Alimento"; }
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
        /// <param name="nombre">Nombre del Alimento</param>
        /// <param name="capacidad">Capacidad alimenticia</param>
        /// <param name="imagen">Ruta de la imagen</param>
        public Alimento(string nombre, int capacidad, string imagen)
        {
            this.nombre = nombre;
            this.capacidad = capacidad;
            this.imagen = imagen;
        }
        /// <summary>
        /// Constructor por defecto del Alimento
        /// </summary>
        public Alimento()
        {
            Nombre = "";
            Capacidad = 0;
            Imagen = "";
        }
        #endregion

        
    }
}
