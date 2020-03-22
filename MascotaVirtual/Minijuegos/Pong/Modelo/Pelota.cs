using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MascotaVirtual.Minijuegos.Pong.Modelo
{
    /// <summary>
    /// Clase Pelota
    /// </summary>
    public class Pelota
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Pelota()
        {
            this.pendiente = 1;
            this.velocidad = 5;
            this.direccion = true;
            this.Posicion = new Point(0, 0);
        }
        #endregion

        #region Dirección
        private bool direccion;
        /// <summary>
        /// Marca la dirección de la bola, hacia arriba o hacia abajo
        /// </summary>
        public bool Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        #endregion

        #region Velocidad
        private int velocidad;
        /// <summary>
        /// Velocidad con que se mueve la pelota
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
        /// Posición en que se encuentra
        /// </summary>
        public Point Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
        #endregion

        #region Mover pelota
        /// <summary>
        /// Mueve la pelota en X e Y
        /// </summary>
        /// <param name="aumentoX">Movimiento X</param>
        /// <param name="aumentoY">Movimiento Y</param>
        public void Mover(int aumentoX, int aumentoY)
        {
            posicion.X += aumentoX;
            posicion.Y += aumentoY;
        }
        #endregion

        #region Pendiente
        private int pendiente;
        /// <summary>
        /// Pendiente que lleva la pelota
        /// La usamos para calcular dónde se va dibujando la pelota mediante la ecuación de punto-pendiente
        /// </summary>
        public int Pendiente
        {
            get { return pendiente; }
            set { pendiente = value; }
        }
        #endregion
    }
}
