using System;
using System.Collections.Generic;
using System.Text;

namespace MascotaVirtual.VidaMascota.Modelo.Objetos
{
    /// <summary>
    /// Cola de objetos
    /// </summary>
    public class ListaObjetos
    {
        private NodoObjeto cab;
        private NodoObjeto cola;
        private int numeroObjetos;

        #region Número de Objetos
        /// <summary>
        /// Número de Objetos que tenemos en el inventario
        /// </summary>
        public int NumeroObjetos
        {
            get { return numeroObjetos; }
            set { numeroObjetos = value; }
        }
        #endregion

        #region Setter y Getter de cab
        /// <summary>
        /// Cabeza de la lista de Objetos
        /// Cuando se serializa, tendrá toda la lista de Objetos anidados
        /// </summary>
        public NodoObjeto Cab
        {
            get { return cab; }
            set { cab = value; }
        }
        /// <summary>
        /// Cola de la lista de Objetos
        /// </summary>
        public NodoObjeto Cola
        {
            get { return cola; }
            set { cola = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ListaObjetos()
        {
            cab = cola = null;
            numeroObjetos = 0;
        }
        #endregion

        #region Eliminar Objeto
        /// <summary>
        /// Elimina el Objeto que le pasamos por parámetro
        /// </summary>
        /// <param name="objeto">Objeto que queremos eliminar</param>
        public void Eliminar(Objeto objeto)
        {
            NodoObjeto aux = new NodoObjeto();
            NodoObjeto anteriorAux = new NodoObjeto();
            bool borrado = false;
            aux = cab;
            anteriorAux = cab;
            while ((aux != null) && (!borrado))
            {
                if (aux.Info.Nombre == objeto.Nombre)
                {
                    if (aux.Info.Tipo == objeto.Tipo)
                    {
                        if (aux.Info.Capacidad == objeto.Capacidad)
                        {
                            if (aux == cab)
                            {
                                cab = cab.Siguiente;
                            }
                            else
                            {
                                anteriorAux.Siguiente = aux.Siguiente;
                                aux = null;
                            }
                            borrado = true;
                            numeroObjetos--;
                        }
                    }
                }
                if (!borrado)
                {
                    anteriorAux = aux;
                    aux = aux.Siguiente;
                }
            }
        }
        #endregion

        #region Insertar
        /// <summary>
        /// Inserta un objeto al principio de la lista
        /// </summary>
        /// <param name="objeto">Objeto que queremos insertar</param>
        public void Insertar(Objeto objeto)
        {
            NodoObjeto aux = new NodoObjeto();
            aux.Info = objeto;
            aux.Siguiente = cab;
            cab = aux;
            numeroObjetos++;
        }
        #endregion

        #region Imprimir
        /// <summary>
        /// Devuelve una cadena con el texto de toda la lista
        /// </summary>
        /// <returns>Cadena con el texto de la lista de objetos</returns>
        public string Imprimir()
        {
            NodoObjeto aux = cab;
            string cadena = "";
            while (aux != null)
            {
                cadena += aux.Info.Imprimir();
                aux = aux.Siguiente;
                cadena += "\n";
            }
            cadena += "Fin de la lista";
            return cadena;
        }
        #endregion
    }
}
