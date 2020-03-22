using System;
using System.Collections.Generic;
using System.Text;

namespace MascotaVirtual.VidaMascota.Modelo.Objetos
{
    /// <summary>
    /// Cada Nodo de ListaObjeto tiene un Objeto y una referencia al siguiente Nodo
    /// </summary>
    public class NodoObjeto
    {
        private Objeto info;
        private NodoObjeto siguiente;

        #region Getters y Setters
        /// <summary>
        /// Información del Objeto que está guardado en este Nodo
        /// </summary>
        public Objeto Info
        {
            get { return info; }
            set { info = value; }
        }

        /// <summary>
        /// Referencia al siguiente Nodo
        /// </summary>
        public NodoObjeto Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
        #endregion
    }
}
