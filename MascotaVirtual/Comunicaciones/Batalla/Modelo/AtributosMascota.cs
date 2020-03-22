using System;
using System.Collections.Generic;
using System.Text;

namespace MascotaVirtual.Comunicaciones.Batalla.Modelo
{
    /// <summary>
    /// Atributos de una mascota.
    /// </summary>
    public class AtributosMascota
    {
        #region Nivel
        /// <summary>
        /// Nivel de progreso de la mascota
        /// </summary>
        protected int nivel;
        /// <summary>
        /// Getter y Setter de la propiedad nivel
        /// </summary>
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
        #endregion

        #region Resistencia
        /// <summary>
        /// Resistencia de la mascota
        /// </summary>
        protected int resistencia;
        /// <summary>
        /// Getter y Setter de la propiedad resistencia
        /// </summary>
        public int Resistencia
        {
            get { return resistencia; }
            set { resistencia = value; }
        }
        #endregion

        #region Fuerza
        /// <summary>
        /// Fuerza de la mascota
        /// </summary>
        protected int fuerza;
        /// <summary>
        /// Getter y Setter de la propiedad fuerza
        /// </summary>
        public int Fuerza
        {
            get { return fuerza; }
            set { fuerza = value; }
        }
        #endregion

        #region Destreza
        /// <summary>
        /// Destreza de la mascota
        /// </summary>
        protected int destreza;
        /// <summary>
        /// Getter y Setter de la propiedad destreza
        /// </summary>
        public int Destreza
        {
            get { return destreza; }
            set { destreza = value; }
        }
        #endregion

        #region Inteligencia
        /// <summary>
        /// Inteligencia de la mascota
        /// </summary>
        protected int inteligencia;
        /// <summary>
        /// Getter y Setter de la propiedad inteligencia
        /// </summary>
        public int Inteligencia
        {
            get { return inteligencia; }
            set { inteligencia = value; }
        }
        #endregion

        #region PuntosVida
        /// <summary>
        /// Puntos de vida de la mascota
        /// </summary>
        protected int puntosVida;
        /// <summary>
        /// Getter y Setter de la propiedad puntosVida
        /// </summary>
        public int PuntosVida
        {
            get { return puntosVida; }
            set
            {
                puntosVida = value;
            }
        }
        #endregion
    }
}
