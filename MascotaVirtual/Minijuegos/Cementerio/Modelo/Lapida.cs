using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MascotaVirtual.Minijuegos.Cementerio.Modelo
{
    /// <summary>
    /// Lápida que representa cada posible enemigo del juego.
    /// </summary>
    public class Lapida
    {
        private int frame;
        private bool tocable;
        private int muerta;
        private Rectangle dibujo;
        private int ancho;
        private int alto;
        private Rectangle destino;

        #region Alto
        /// <summary>
        /// Getter del Alto de la lápida
        /// </summary>
        public int Alto
        {
            get { return alto; }
        }
        #endregion

        #region Ancho
        /// <summary>
        /// Getter del ancho de la lápida
        /// </summary>
        public int Ancho
        {
            get { return ancho; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Lapida()
        {
            frame = 0;
            tocable = false;
            muerta = 0;
            alto = 67;
            ancho = 44;
            dibujo = new Rectangle(0, 0, ancho, alto);
        }
        #endregion

        #region Tocado
        /// <summary>
        /// Pasa la lápida al estado Tocado.
        /// </summary>
        public void Tocado()
        {
            frame = 6;
            muerta = 7;
            tocable = false;
        }
        #endregion

        #region Pasar Frame
        /// <summary>
        /// Pasa un Frame de la animación de la lápida.
        /// Si es el último Frame y no se ha matado al enemigo, devuelve true.
        /// </summary>
        /// <returns>Boleano, true si el enemigo nos pega.</returns>
        public bool PasarFrame()
        {
            bool pasado = false;

            if (muerta > 0)
            {
                muerta--;
                if (muerta == 0)
                {
                    frame = 0;
                }
            }
            if (tocable)
            {
                if (frame < 5)
                {
                    frame++;
                }
                else
                {
                    frame = 0;
                    tocable = false;
                    pasado = true;
                }
            }
            calcularSourceDibujo();
            return pasado;
        }
        #endregion

        #region Activar
        /// <summary>
        /// Activa una lápida a menos que ya esté activada o el enemigo esté muerto.
        /// </summary>
        public void Activar()
        {
            if ((!tocable)&&(muerta==0))
            {
                tocable = true;
                frame++;
                calcularSourceDibujo();
            }
        }
        #endregion

        #region Dibujo
        /// <summary>
        /// Getter y Setter del dibujo de la lápida.
        /// </summary>
        public Rectangle Dibujo
        {
            get { return dibujo; }
            set { dibujo = value; }
        }
        #endregion

        #region Destino
        /// <summary>
        /// Getter y Setter del Destino de la lápida.
        /// </summary>
        public Rectangle Destino
        {
            get { return destino; }
            set { destino = value; }
        }
        #endregion

        #region Calcular Fuente del Dibujo
        /// <summary>
        /// Calcula la fuente del dibujo en función del frame que se deba dibujar.
        /// </summary>
        private void calcularSourceDibujo()
        {
            Dibujo = new Rectangle(frame * ancho, 0, ancho, alto);
        }
        #endregion

        #region Muerto
        /// <summary>
        /// Comprueba si han matado al enemigo de esta lápida.
        /// </summary>
        /// <param name="X">Coordenada X en la que se disparó.</param>
        /// <param name="Y">Coordenada Y en la que se disparó.</param>
        /// <returns>Boleano, true si se mata al enemigo y false en caso contrario.</returns>
        public bool Muerto(int X, int Y)
        {
            if ((X >= destino.X) && (X <= (destino.Width+destino.X)) && (Y >= destino.Y) && (Y <= (destino.Height+destino.Y))&&(this.tocable))
            {
                this.Tocado();
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
