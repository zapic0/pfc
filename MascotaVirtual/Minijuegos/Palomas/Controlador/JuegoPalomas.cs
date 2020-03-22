using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MascotaVirtual.Minijuegos.Palomas;
using MascotaVirtual.Minijuegos.Palomas.Modelo;

namespace MascotaVirtual.Minijuegos.Palomas.Controlador
{
    /// <summary>
    /// Controlador del juego de las Palomas
    /// </summary>
    public class JuegoPalomas
    {
        #region Puntuación
        private int puntuacion;
        /// <summary>
        /// Puntuación del juego.
        /// </summary>
        public int Puntuacion
        {
            get { return puntuacion; }
            set { puntuacion = value; }
        }
        #endregion

        #region Vida del Zombi
        private int vidaZombi;
        /// <summary>
        /// Vida del Zombie.
        /// </summary>
        public int VidaZombi
        {
            get { return vidaZombi; }
            set { vidaZombi = value; }
        }
        #endregion

        Paloma paloma;
        int ancho;
        int alto;
        int dificultad;
        Rectangle zombie;

        Timer animacion;
        Timer subirDificultad;

        Random semilla;
        Graphics pintarAqui;
        Bitmap dibujo;
        Bitmap fondo;
        Bitmap imagenZombie;

        #region Delegado y Evento del cambio de Imagen
        /// <summary>
        /// Manejador del evento de cambio de Imagen en el juego.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorImagenCambiada(object source, Bitmap e);
        /// <summary>
        /// Evento del cambio de imagen en el juego.
        /// </summary>
        public event ManejadorImagenCambiada OnImagenCambiada;
        #endregion

        #region Delegado y Evento de la bajada de vida
        /// <summary>
        /// Manejador del evento de bajada de vida del Zombie.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorVidaBajada(object source, EventArgs e);
        /// <summary>
        /// Evento de la bajada de vida.
        /// </summary>
        public event ManejadorVidaBajada OnVidaBajada;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ancho">Ancho de la ventana de juego.</param>
        /// <param name="alto">Alto de la ventana de juego.</param>
        public JuegoPalomas(int ancho, int alto)
        {
            semilla = new Random(this.alto);
            this.ancho = ancho;
            this.alto = alto;
            paloma = null;
            dificultad = 1;
            puntuacion = 0;
            vidaZombi = 10;

            animacion = new Timer();
            subirDificultad = new Timer();

            animacion.Interval = 20;
            subirDificultad.Interval = 15000;

            animacion.Tick += new EventHandler(animacion_Tick);
            subirDificultad.Tick += new EventHandler(subirDificultad_Tick);

            animacion.Enabled = false;
            subirDificultad.Enabled = false;

            Utilidades.DirectorioRaiz directorio = new MascotaVirtual.Utilidades.DirectorioRaiz();
            fondo = new Bitmap(directorio.Directorio + "graficos//campo.bmp");
            imagenZombie = new Bitmap(directorio.Directorio + "graficos//zombi.bmp");

            zombie = new Rectangle(ancho / 2 - imagenZombie.Width / 2, alto - imagenZombie.Height, imagenZombie.Width, imagenZombie.Height);

            dibujo = new Bitmap(ancho, alto);
            pintarAqui = Graphics.FromImage(dibujo);
        }
        #endregion

        #region Tick de pasar un turno
        /// <summary>
        /// Manejador del evento tick del temporizador animación.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void animacion_Tick(object sender, EventArgs e)
        {
            pasarTurno();
            this.pintarAqui.DrawImage(fondo, 0, 0);
            ImageAttributes atributos = new ImageAttributes();
            Color color = paloma.Imagen.GetPixel(0, 0);
            atributos.SetColorKey(color, color);
            pintarAqui.DrawImage(imagenZombie, zombie, 0, 0, imagenZombie.Width, imagenZombie.Height, GraphicsUnit.Pixel, atributos);
            pintarAqui.DrawImage(paloma.Imagen, new Rectangle(paloma.Posicion.X,paloma.Posicion.Y,paloma.Tamano.Width, paloma.Tamano.Height),paloma.Frame.X, paloma.Frame.Y, paloma.Frame.Width, paloma.Frame.Height, GraphicsUnit.Pixel, atributos);
            if (OnImagenCambiada != null)
            {
                OnImagenCambiada(this, dibujo);
            }
        }
        #endregion

        #region Tick de subir la dificultad
        /// <summary>
        /// Manejador del evento tick del temporizador subirDificultad.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void subirDificultad_Tick(object sender, EventArgs e)
        {
            dificultad++;
        }
        #endregion

        #region Iniciar Paloma
        /// <summary>
        /// Iniciar la paloma.
        /// </summary>
        private void iniciarPaloma()
        {
            if (paloma == null)
            {
                int posicionX;
                int posicionY;
                int ancho;
                int alto;
                posicionY = semilla.Next(this.alto);
                int i = semilla.Next(2);
                ancho = 20;
                alto = 20;
                if (i == 0)
                {
                    posicionX = 0;
                    paloma = new Paloma(posicionX, posicionY, ancho, alto, new Utilidades.DirectorioRaiz().Directorio + "graficos//animacionPaloma.bmp");
                    paloma.GirarPaloma();
                }
                else
                {
                    posicionX = this.ancho;
                    paloma = new Paloma(posicionX, posicionY, ancho, alto, new Utilidades.DirectorioRaiz().Directorio + "graficos//animacionPaloma.bmp");
                }
            }
        }
        #endregion

        #region Impacto Paloma contra Zombie
        /// <summary>
        /// Captura el impacto de la paloma contra el Zombie.
        /// </summary>
        /// <returns>True si impacta, false en caso contrario.</returns>
        private bool palomaImpacto()
        {
            Rectangle rectanguloPaloma = new Rectangle(paloma.Posicion.X, paloma.Posicion.Y, paloma.Tamano.Width, paloma.Tamano.Height);
            if (zombie.IntersectsWith(rectanguloPaloma))
            {
                vidaZombi--;
                return true;
            }
            return false;
        }
        #endregion

        #region Disparar a la Paloma
        /// <summary>
        /// Dispara sobre el punto en el que hemos pulsado.
        /// </summary>
        /// <param name="coordenadaX">Coordenada X sobre la que hemos pulsado.</param>
        /// <param name="coordenadaY">Coordenada Y sobre la que hemos pulsado.</param>
        public void Disparar(int coordenadaX, int coordenadaY)
        {
            if (paloma != null)
            {
                if (paloma.Viva)
                {
                    if (paloma.Tocado(coordenadaX, coordenadaY))
                    {
                        puntuacion++;
                        paloma.Matar();
                    }
                }
            }
        }
        #endregion

        #region Mover Paloma
        /// <summary>
        /// Mueve la paloma.
        /// </summary>
        /// <param name="movimientoX">El movimiento X.</param>
        /// <param name="movimientoY">El movimiento Y.</param>
        private void moverPaloma(int movimientoX, int movimientoY)
        {
            paloma.Mover(movimientoX, movimientoY);
        }
        #endregion

        #region Pasar Turno
        /// <summary>
        /// Pasar el turno.
        /// </summary>
        private void pasarTurno()
        {
            int movimientoX = 0;
            int movimientoY = 0;
            iniciarPaloma();
            if (paloma.Viva)
            {
                if (palomaImpacto())
                {
                    paloma = null;
                    if (OnVidaBajada != null)
                    {
                        OnVidaBajada(this, new EventArgs());
                    }
                    iniciarPaloma();
                }
                if (paloma.Posicion.X < zombie.X)
                {
                    movimientoX = semilla.Next(1, dificultad);
                }
                else if (paloma.Posicion.X > zombie.X + zombie.Width - 5)
                {
                    movimientoX = -semilla.Next(1, dificultad);
                }

                if (paloma.Posicion.Y > zombie.Y - 5)
                {
                    movimientoY = -semilla.Next(1, dificultad);
                }
                else if (paloma.Posicion.Y < zombie.Y - 5)
                {
                    movimientoY = semilla.Next(1, dificultad);
                }
                moverPaloma(movimientoX, movimientoY);
            }
            else
            {
                if (!paloma.Desaparecida)
                {
                    paloma.Matar();
                }
                else
                {
                    paloma = null;
                    iniciarPaloma();
                }
            }
        }
        #endregion


        #region Empezar el Juego
        /// <summary>
        /// Empieza el juego.
        /// </summary>
        public void Empezar()
        {
            this.puntuacion = 0;
            this.animacion.Enabled = true;
            this.dificultad = 1;
            this.vidaZombi = 10;
            this.subirDificultad.Enabled = true;
        }
        #endregion

        #region Parar el Juego
        /// <summary>
        /// Detiene el juego.
        /// </summary>
        public void Parar()
        {
            this.animacion.Enabled = false;
            this.subirDificultad.Enabled = false;
        }
        #endregion

    }
}
