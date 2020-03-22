using System;
using System.Collections.Generic;
using System.Text;

namespace MascotaVirtual.VidaMascota.Modelo.Objetos
{
    /// <summary>
    /// Clase de Objeto con propiedades Educativas
    /// </summary>
    public class Educador : Objeto
    {
        #region Implementación métodos abstractos
        /// <summary>
        /// Getter y Setter de la propiedad Tipo, heredada de la clase Objeto
        /// </summary>

        public override string Tipo
        {
            get { return "Educador"; }
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
        /// <param name="nombre">Nombre del educador</param>
        /// <param name="capacidad">Capacidad educativa</param>
        /// <param name="imagen">Ruta de la imagen</param>
        public Educador(string nombre, int capacidad, string imagen)
        {
            this.nombre = nombre;
            this.capacidad = capacidad;
            this.imagen = imagen;
        }
        /// <summary>
        /// Contructor por defecto del Educador
        /// </summary>
        public Educador()
        {
            Nombre = "";
            Capacidad = 0;
            Imagen = "";
        }
        #endregion
    }
}
