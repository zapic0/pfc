using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using MascotaVirtual.Minijuegos.Cementerio.Modelo;

namespace MascotaVirtual.Minijuegos.Cementerio.Controlador
{
    /// <summary>
    /// Controlador del juego del cementerio
    /// </summary>
    public class Cementerio
    {
        private Bitmap fondo;
        private Lapida[] lapidas;
        private int anchoCementerio;
        private int altoCementerio;
        private Random aleatorio;
        private int escopeta;
        private int vidas;

        #region Vidas
        /// <summary>
        /// Getter y Setter de Vidas del Jugador
        /// </summary>
        public int Vidas
        {
            get { return vidas; }
            set { vidas = value; }
        }
        #endregion

        #region Cementerio
        /// <summary>
        /// Constructor
        /// </summary>
        public Cementerio(int ancho, int alto)
        {
            Utilidades.DirectorioRaiz directorio = new MascotaVirtual.Utilidades.DirectorioRaiz();
            fondo = new Bitmap(directorio.Directorio + "graficos\\lapidasAnimacion.bmp");
            lapidas = new Lapida[9];
            escopeta = 7;
            vidas = 5;
            anchoCementerio = ancho;
            altoCementerio = alto;
            aleatorio = new Random(1000);

            for (int i = 0; i < 9; i++)
            {
                lapidas[i] = new Lapida();
            }
        }
        #endregion

        #region Escopeta
        /// <summary>
        /// Getter y Setter de Escopeta (n�mero de disparos).
        /// </summary>
        public int Escopeta
        {
            get { return escopeta; }
            set { escopeta = value; }
        }
        #endregion

        #region Imagen de Fondo
        /// <summary>
        /// Devuelve la imagen a cargar en el juego.
        /// </summary>
        /// <returns>Bitmap con la imagen a cargar.</returns>
        public Bitmap ImagenFondo()
        {
            return fondo;
        }
        #endregion

        #region Pasar Frame
        /// <summary>
        /// Pasar el Frame de la l�pida que indicamos.
        /// </summary>
        /// <param name="numero">Entero de la l�pida que queremos "avanzar".</param>
        public void PasaFrame(int numero)
        {
            if (lapidas[numero].PasarFrame())
            {
                vidas--;
            }
        }
        #endregion

        #region Pasar Turno
        /// <summary>
        /// Pasa un turno, activando aleatoriamente una l�pida.
        /// Hay un 10% de posibilidades de que no se active ninguna.
        /// </summary>
        public void PasaTurno()
        {
            int numero=aleatorio.Next(0,9);
            if (numero != 9)
            {
                lapidas[numero].Activar();
            }
        }
        #endregion

        #region Rect�ngulo fuente de la L�pida
        /// <summary>
        /// Devuelve el Rect�ngulo de donde hay que cargar el dibujo de la L�pida indicada.
        /// </summary>
        /// <param name="numero">Entero de la L�pida que queremos dibujar.</param>
        /// <returns>Rect�ngulo que indica qu� parte del Bitmap hay que cargar.</returns>
        public Rectangle SourceLapida(int numero)
        {
            return lapidas[numero].Dibujo;
        }
        #endregion

        #region Get Rect�ngulo Destino de la L�pida
        /// <summary>
        /// Devuelve el Rect�ngulo en el que hay que dibujar una L�pida.
        /// </summary>
        /// <param name="numero">Entero de la L�pida que queremos dibujar.</param>
        /// <returns>Rect�ngulo en el que tenemos que dibujar.</returns>
        public Rectangle GetDestinoLapida(int numero)
        {
            return lapidas[numero].Destino;
        }
        #endregion

        #region Set Destino de la L�pida
        /// <summary>
        /// Atribuye un rect�ngulo de destino a la l�pida indicada.
        /// </summary>
        /// <param name="numero">Entero que indica la l�pida que queremos setear.</param>
        public void SetDestinoLapida(int numero)
        {
            Rectangle destino;

            int anchuraCuadro = this.anchoCementerio / 3;
            int alturaCuadro = this.altoCementerio / 3;

            int upLeftX = 240 / 3;
            int upLeftY = 300 / 3;

            if ((numero == 0) || (numero == 3) || (numero == 6))
            {
                upLeftX = 0+(anchuraCuadro-lapidas[numero].Ancho)/2;
            }
            else if ((numero == 1) || (numero == 4) || (numero == 7))
            {
                upLeftX = anchuraCuadro+(anchuraCuadro-lapidas[numero].Ancho)/2;
            }
            else
            {
                upLeftX = anchuraCuadro*2 + (anchuraCuadro-lapidas[numero].Ancho)/2;
            }

            if (numero <= 2)
            {
                upLeftY = 0+(alturaCuadro-lapidas[numero].Alto)/2;
            }
            else if (numero <= 5)
            {
                upLeftY = alturaCuadro+(alturaCuadro-lapidas[numero].Alto)/2;
            }
            else if (numero <= 8)
            {
                upLeftY = alturaCuadro*2+(alturaCuadro-lapidas[numero].Alto)/2;
            }
            destino = new Rectangle(upLeftX, upLeftY, lapidas[numero].Ancho, lapidas[numero].Alto);
            lapidas[numero].Destino = destino;
        }
        #endregion

        #region Matar
        /// <summary>
        /// Comprueba si un disparo ha matado alg�n enemigo.
        /// </summary>
        /// <param name="X">Coordenada X en la que se ha disparado.</param>
        /// <param name="Y">Coordenada Y en la que se ha disparado.</param>
        /// <returns>Boleano indicando si se ha matado a alguien o no.</returns>
        public bool Matar(int X, int Y)
        {
            bool muerto = false;
            int i=0;
            while((i<9)&&(!muerto))
            {
                muerto=lapidas[i].Muerto(X, Y);
                i++;
            }
            return muerto;
        }
        #endregion
    }
}
