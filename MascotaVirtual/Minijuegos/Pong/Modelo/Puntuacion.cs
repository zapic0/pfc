using System;
using System.Collections.Generic;
using System.Text;

namespace MascotaVirtual.Minijuegos.Pong.Modelo
{
    /// <summary>
    /// Marcador de la partida
    /// </summary>
    public class Puntuacion
    {

        #region Jugador
        private int jugador;
        /// <summary>
        /// Puntuación que lleva el jugador
        /// </summary>
        public int Jugador
        {
            get { return jugador; }
            set { jugador = value; }
        }
        #endregion

        #region Enemigo
        private int enemigo;
        /// <summary>
        /// Puntuación que lleva el enemigo
        /// </summary>
        public int Enemigo
        {
            get { return enemigo; }
            set { enemigo = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Puntuacion()
        {
            jugador = 0;
            enemigo = 0;
        }
        #endregion

        #region Gol del Jugador
        /// <summary>
        /// Suma un gol al jugador
        /// </summary>
        public void GolJugador(){
            jugador++;
        }
        #endregion

        #region Gol del Enemigo
        /// <summary>
        /// Suma un gol al enemigo
        /// </summary>
        public void GolEnemigo()
        {
            enemigo++;
        }
        #endregion

        #region To String
        /// <summary>
        /// Escribe la puntuación con ":" por el medio
        /// </summary>
        /// <returns>Cadena con la puntuación</returns>
        public override string ToString()
        {
            return (jugador.ToString() + ":" + enemigo.ToString());
        }
        #endregion
    }
}
