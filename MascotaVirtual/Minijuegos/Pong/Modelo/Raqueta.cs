using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MascotaVirtual.Minijuegos.Pong.Modelo;

namespace MascotaVirtual.Minijuegos.Pong.Modelo
{
    /// <summary>
    /// Clase Raqueta del juego
    /// </summary>
    public class Raqueta
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Raqueta()
        {
            this.longitud = 50;
            this.posicion = new Point(10, 10);
            this.velocidad = 1;
            this.fuerza = 1;
            this.velocidadRecarga = 1;
            this.ocupacionRaqueta=this.CalcularOcupacion();
        }
        #endregion

        #region Longitud
        private int longitud;
        /// <summary>
        /// Gets or sets the longitud.
        /// </summary>
        /// <value>The longitud.</value>
        public int Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }
        #endregion

        #region Velocidad
        private int velocidad;
        /// <summary>
        /// Gets or sets the velocidad de la raqueta.
        /// </summary>
        /// <value>La velocidad de la raqueta.</value>
        public int Velocidad
        {
            get { return velocidad; }
            set { velocidad = value; }
        }
        #endregion

        #region Fuerza
        private int fuerza;
        /// <summary>
        /// Gets or sets la fuerza de los disparos.
        /// </summary>
        /// <value>La fuerza.</value>
        public int Fuerza
        {
            get { return fuerza; }
            set { fuerza = value; }
        }
        #endregion

        #region Pegada
        private int pegada;
        /// <summary>
        /// Gets or sets la velocidad de pegada.
        /// </summary>
        /// <value>La pegada.</value>
        public int Pegada
        {
            get { return pegada; }
            set { pegada = value; }
        }
        #endregion

        #region Velocidad a la que se puede recargar las balas (no usado).
        private int velocidadRecarga;
        /// <summary>
        /// Gets or sets la velocidad en que se pueden disparar balaseras.
        /// (Al final no se usó)
        /// </summary>
        /// <value>La velocidad de recarga de balaseras.</value>
        public int VelocidadRecarga
        {
            get { return velocidadRecarga; }
            set { velocidadRecarga = value; }
        }
        #endregion

        #region Posición
        private Point posicion;
        /// <summary>
        /// Gets or sets the posicion of the raqueta.
        /// </summary>
        /// <value>The posicion of the raqueta.</value>
        public Point Posicion
        {
            get { return posicion; }
            set 
            { 
                posicion = value;
                this.ocupacionRaqueta = this.CalcularOcupacion();
            }
        }
        #endregion

        #region Ocupación de la Raqueta
        private Rectangle ocupacionRaqueta;
        /// <summary>
        /// Devuelve el rectángulo que ocupa la raqueta
        /// Se usa para saber si impacta la pelota o una bala contra su superficie
        /// </summary>
        public Rectangle OcupacionRaqueta
        {
            get { return ocupacionRaqueta; }
            set { ocupacionRaqueta = value; }
        }
        #endregion

        #region Mover la raqueta
        /// <summary>
        /// Mueve la raqueta el aumento que se le pasa para X e Y.
        /// </summary>
        /// <param name="aumentoX">The aumento X.</param>
        /// <param name="aumentoY">The aumento Y.</param>
        public void Mover(int aumentoX, int aumentoY)
        {
            posicion.X += aumentoX*velocidad;
            //posicion.Y += aumentoY*velocidad;
            this.ocupacionRaqueta = this.CalcularOcupacion();
        }
        #endregion

        #region Disparar
        /// <summary>
        /// Lanza una bala a su enemigo
        /// </summary>
        /// <returns>La bala disparada</returns>
        public Bala Disparar()
        {
            Bala balasera = new Bala();
            balasera.Posicion = this.posicion;
            return balasera;
        }
        #endregion

        #region Recibir el disparo
        /// <summary>
        /// Recibir el disparo.
        /// </summary>
        /// <param name="balasera">Bala que nos dispara.</param>
        public bool RecibirDisparo(Bala balasera)
        {
            if ((balasera.Posicion.X >= this.posicion.X - this.longitud / 2) && (balasera.Posicion.X <= this.posicion.X + this.longitud / 2) && ((balasera.Posicion.Y <= this.posicion.Y)&&(balasera.SituacionAnterior() >= this.posicion.Y)))
            {
                this.longitud = this.longitud - balasera.Potencia * 2;
                this.ocupacionRaqueta=this.CalcularOcupacion();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Calcular la ocupación de la raqueta
        /// <summary>
        /// Calcula la ocupación de la raqueta
        /// </summary>
        /// <returns>Rectángulo de lo que ocupa la raqueta</returns>
        private Rectangle CalcularOcupacion()
        {
            Rectangle nuevaOcupacion = new Rectangle();
            nuevaOcupacion.X = this.posicion.X - this.longitud / 2;
            nuevaOcupacion.Y = this.posicion.Y;
            nuevaOcupacion.Width = longitud;
            nuevaOcupacion.Height = 20;
            return nuevaOcupacion;
        }
        #endregion
    }
}
