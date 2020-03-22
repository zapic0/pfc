using System;
using System.Collections.Generic;
using System.Text;

namespace MascotaVirtual.Minijuegos.Puntuaciones
{
    /// <summary>
    /// Clase que maneja las puntuaciones del juego
    /// </summary>
    public class ListaPuntuaciones
    {
        /// <summary>
        /// Array de puntos, público para poder serializar la clase
        /// </summary>
        public int[] puntos;

        #region Constructores
        /// <summary>
        /// Constructor por defecto de la Lista de Puntos
        /// </summary>
        public ListaPuntuaciones()
        {
            puntos = new int[10];
        }

        /// <summary>
        /// Constructor que inicializa el top ten al mismo valor
        /// </summary>
        /// <param name="puntuacion">Entero con el valor inicial de las puntuaciones</param>
        public ListaPuntuaciones(int puntuacion)
        {
            puntos = new int[10];
            for (int i = 0; i < 10; i++)
            {
                puntos[i] = puntuacion;
            }
        }
        #endregion

        #region GetPuntos
        /// <summary>
        /// Devuelve el número de puntos de un puesto determinado
        /// </summary>
        /// <param name="puesto">Puesto en la clasificación del que se quieren obtener los puntos</param>
        /// <returns></returns>
        public int GetPuntos(int puesto)
        {
            return puntos[puesto];
        }
        #endregion

        #region InsertarPuntos
        /// <summary>
        /// Guarda los puntos que se le pasan por parámetro en el lugar en que les corresponde dentro de la lista
        /// </summary>
        /// <param name="nuevosPuntos">int con el valor de los puntos que se quieren insertar</param>
        public void InsertarPuntos(int nuevosPuntos)
        {
            int i = 9;
            
            if (nuevosPuntos > puntos[9])
            {
                puntos[9] = nuevosPuntos;
            }

            while (puntos[i] > puntos[i - 1])
            {
                int aux = puntos[i - 1];
                puntos[i - 1] = puntos[i];
                puntos[i] = aux;
                i--;
                if (i == 0)
                {
                    i = 1;
                }
            }
        }
        #endregion
    }
}
