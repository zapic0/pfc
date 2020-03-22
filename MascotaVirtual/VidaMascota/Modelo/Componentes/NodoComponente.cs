using System;
using System.Collections.Generic;
using System.Text;
using MascotaVirtual.VidaMascota.Modelo.Componentes;

namespace MascotaVirtual.VidaMascota.Modelo.Componentes
{
    /// <summary>
    /// Cada nodo de la Lista de Componentes
    /// </summary>
    public class NodoComponente
    {
        private Componente info;
        private NodoComponente siguiente;

        #region Getters y Setters
        /// <summary>
        /// Información del Objeto que está guardado en este Nodo
        /// </summary>
        public Componente Info
        {
            get { return info; }
            set { info = value; }
        }

        /// <summary>
        /// Referencia al siguiente Nodo
        /// </summary>
        public NodoComponente Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
        #endregion
    }
}
