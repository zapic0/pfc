using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MascotaVirtual.Minijuegos.Pong.Modelo
{
    /// <summary>
    /// Clase de los disparos
    /// </summary>
    public class Bala
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Bala()
        {
            this.Posicion = new Point(0, 0);
            this.velocidad = 5;
            this.Potencia = 1;
        }
        #endregion

        #region Velocidad
        private int velocidad;
        /// <summary>
        /// Velocidad que lleva la bala
        /// </summary>
        public int Velocidad
        {
            get { return velocidad; }
            set { velocidad = value; }
        }
        #endregion

        #region Posición
        private Point posicion;

        /// <summary>
        /// Posición de la bala
        /// </summary>
        public Point Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
        #endregion

        #region Potencia
        private int potencia;
        /// <summary>
        /// Potencia, daño que hace la bala al pegar a la raqueta
        /// </summary>
        public int Potencia
        {
            get { return potencia; }
            set { potencia = value; }
        }
        #endregion

        #region Situación anterio
        /// <summary>
        /// Calcula la posición anterior de la bala
        /// Se usa porque no se dibujan todos los estados de la bala si va muy rápido y si no controlásemos eso, a menos que se dibujase EXACTAMENTE cuando pega a una raqueta, nunca tendría efectos
        /// </summary>
        /// <returns>Coordenada Y en la que se encontraba</returns>
        public int SituacionAnterior()
        {
            if (this.posicion.Y < 0)
            {
                return this.posicion.Y + this.velocidad;
            }
            else
            {
                return this.posicion.Y + this.velocidad;
            }
        }
        #endregion

        #region Mover la bala
        /// <summary>
        /// Mueve la bala
        /// Si el parámetro es true, se mueve hacia arriba, sino hacia abajo
        /// </summary>
        /// <param name="arriba">Va hacia arriba o no</param>
        public void Mover(bool arriba)
        {
            if (arriba)
            {
                this.posicion.Y = this.posicion.Y - velocidad;
            }
            else
            {
                this.posicion.Y = this.posicion.Y + velocidad;
            }
        }
        #endregion
    }
}
