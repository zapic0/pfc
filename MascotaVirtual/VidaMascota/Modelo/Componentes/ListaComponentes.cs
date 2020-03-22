using System;
using System.Collections.Generic;
using System.Text;
using MascotaVirtual.VidaMascota.Modelo.Componentes;

namespace MascotaVirtual.VidaMascota.Modelo.Componentes
{
    /// <summary>
    /// Lista de componentes que forman parte de una mascota
    /// </summary>
    public class ListaComponentes
    {
        private NodoComponente cab;
        private NodoComponente cola;

        #region Setter y Getter de cab
        /// <summary>
        /// Cabeza de la lista de Componentes
        /// Cuando se serializa, tendrá toda la lista de Componentes anidados
        /// </summary>
        public NodoComponente Cab
        {
            get { return cab; }
            set { cab = value; }
        }
        /// <summary>
        /// Cola de la lista de Componentes
        /// </summary>
        public NodoComponente Cola
        {
            get { return cola; }
            set { cola = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ListaComponentes()
        {
            cab = cola = null;
        }
        #endregion

        #region Insertar
        /// <summary>
        /// Inserta un componente al final de la lista
        /// </summary>
        /// <param name="componente">Componente que queremos insertar</param>
        public void Insertar(Componente componente)
        {
            if (cab == null)
            {
                cab = new NodoComponente();
                cola = new NodoComponente();
                cab.Info = componente;
                cab.Siguiente = null;
                cola = cab;
            }
            else
            {
                NodoComponente aux = new NodoComponente();
                aux.Info = componente;
                aux.Siguiente = null;
                cola.Siguiente = aux;
                cola = cola.Siguiente;
            }
        }
        #endregion

        #region Imprimir
        /// <summary>
        /// Devuelve una cadena con el texto de toda la lista
        /// </summary>
        /// <returns>Cadena con el texto de la lista de componentes</returns>
        public string Imprimir()
        {
            NodoComponente aux = cab;
            string cadena = "";
            while (aux != null)
            {
                //cadena+=aux.Info.Imprimir();
                aux = aux.Siguiente;
                cadena += "\n";
            }
            cadena += "Fin de la lista";
            return cadena;
        }
        #endregion
    }
}
