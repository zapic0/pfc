using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MascotaVirtual.Minijuegos.Pong.Modelo;

namespace MascotaVirtual.Minijuegos.Pong.Controlador
{
    /// <summary>
    /// Clase del controlador del minijuego Pong
    /// </summary>
    public class Controlador
    {
        private Random aleatorio = new Random(100);

        #region Destino
        private Point destino;
        /// <summary>
        /// Punto de destio de la Raqueta
        /// </summary>
        public Point Destino
        {
            get { return destino; }
            set { destino = value; }
        }
        #endregion

        #region Punto Inicial
        private Point puntoInicial;
        /// <summary>
        /// Punto inicial de la Raqueta
        /// </summary>
        public Point PuntoInicial
        {
            get { return puntoInicial; }
            set { puntoInicial = value; }
        }
        #endregion

        #region Pelota
        private Pelota bola;
        /// <summary>
        /// Pelota del juego
        /// </summary>
        public Pelota Bola
        {
            get { return bola; }
            set { bola = value; }
        }
        #endregion

        #region Balas del Jugador
        private Bala balasJugador;
        /// <summary>
        /// Bala del jugador
        /// </summary>
        public Bala BalasJugador
        {
            get { return balasJugador; }
            set { balasJugador = value; }
        }
        #endregion

        #region Balas del Enemigo
        private Bala balasEnemigo;
        /// <summary>
        /// Bala del Enemigo
        /// </summary>
        public Bala BalasEnemigo
        {
            get { return balasEnemigo; }
            set { balasEnemigo = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
	    /// Constructor
	    /// </summary>
        public Controlador()
        {
            this.raquetaEnemigo = new Raqueta();
            this.raquetaJugador = new Raqueta();
            this.raquetaJugador.Pegada = 8;
            this.raquetaEnemigo.Pegada = 6;
            this.marcador = new Puntuacion();
            this.raquetaJugador.Posicion = new System.Drawing.Point(100, 235);
            this.destino = this.RaquetaJugador.Posicion;
            this.raquetaJugador.Velocidad = 3;
            this.raquetaEnemigo.Velocidad = 2;
            this.raquetaEnemigo.Posicion = new System.Drawing.Point(100, 5);
            this.bola = new Pelota();
            this.ComienzaJuego();
        }
        #endregion

        #region Raqueta del Jugador
        private Raqueta raquetaJugador;
        /// <summary>
        /// Raqueta del Jugador
        /// </summary>
        public Raqueta RaquetaJugador
        {
            get { return raquetaJugador; }
            set { raquetaJugador = value; }
        }
        #endregion

        #region Raqueta del Enemigo
        private Raqueta raquetaEnemigo;
        /// <summary>
        /// Raqueta del Enemigo
        /// </summary>
        public Raqueta RaquetaEnemigo
        {
            get { return raquetaEnemigo; }
            set { raquetaEnemigo = value; }
        }
        #endregion

        #region Marcador
        private Puntuacion marcador;
        /// <summary>
        /// Marcador
        /// </summary>
        public Puntuacion Marcador
        {
            get { return marcador; }
            set { marcador = value; }
        }
        #endregion

        #region Pegar al Jugador
        /// <summary>
        /// El jugador recibe un disparo
        /// </summary>
        /// <param name="balasera">Bala que le pega</param>
        public void PegarJugador(Bala balasera)
        {
            raquetaJugador.RecibirDisparo(balasera);
        }
        #endregion

        #region Pegar al Enemigo
        /// <summary>
        /// El Enemigo recibe un disparo
        /// </summary>
        /// <param name="balasera">Bala que le pega</param>
        public void PegarEnemigo(Bala balasera)
        {
            raquetaEnemigo.RecibirDisparo(balasera);
        }
        #endregion

        #region Mover Raqueta del Jugador
        /// <summary>
        /// Mueve la raqueta del jugador
        /// </summary>
        /// <param name="movimientoX">Movimiento horizontal</param>
        /// <param name="movimientoY">Movimiento vertical</param>
        public void MoverJugador(int movimientoX,int movimientoY)
        {
            raquetaJugador.Mover(movimientoX, movimientoY);
        }
        #endregion

        #region Mover Raqueta del Enemigo
        /// <summary>
        /// Mueve la raqueta del enemigo
        /// </summary>
        /// <param name="movimientoX">Movimiento horizontal</param>
        /// <param name="movimientoY">Movimiento vertical</param>
        public void MoverEnemigo(int movimientoX, int movimientoY)
        {
            raquetaEnemigo.Mover(movimientoX, movimientoY);
        }
        #endregion

        #region Jugador dispara bala
        /// <summary>
        /// El jugador dispara una bala (la crea)
        /// </summary>
        public void Disparar()
        {
            if (balasJugador == null)
            {
                this.balasJugador = this.raquetaJugador.Disparar();
            }
        }
        #endregion

        #region Mover todos los objetos que hay en pantalla
        /// <summary>
        /// Mueve todo lo que hay en pantalla, la pelota, las balas y las raquetas
        /// </summary>
        public void Mover()
        {
            if (this.bola.Direccion)
            {
                this.bola.Posicion = this.NuevoPunto(this.bola.Posicion.Y + this.bola.Velocidad);
            }
            else
            {
                this.bola.Posicion = this.NuevoPunto(this.bola.Posicion.Y - this.bola.Velocidad);
            }
            bool acertado = false;
            if (this.balasJugador != null)
            {
                this.balasJugador.Mover(true);
                acertado=this.raquetaEnemigo.RecibirDisparo(balasJugador);
                if (acertado||this.balasJugador.Posicion.Y<0)
                {
                    this.balasJugador = null;
                }
            }

            if (this.balasEnemigo != null)
            {
                this.balasEnemigo.Mover(false);
                acertado = this.raquetaJugador.RecibirDisparo(balasEnemigo);
                if (acertado || this.balasEnemigo.Posicion.Y > 250)
                {
                    this.balasEnemigo = null;
                }
            }

            if (bola.Posicion.X < raquetaEnemigo.Posicion.X)
            {
                raquetaEnemigo.Mover(-1, 0);
            }
            else
            {
                raquetaEnemigo.Mover(1, 0);
            }
            if (this.balasEnemigo == null)
            {
                this.balasEnemigo=raquetaEnemigo.Disparar();
            }
            if (destino.X > raquetaJugador.Posicion.X)
            {
                raquetaJugador.Mover(raquetaJugador.Velocidad, 0);
            }
            if (destino.X < raquetaJugador.Posicion.X)
            {
                raquetaJugador.Mover(-raquetaJugador.Velocidad, 0);
            }
            if (destino.Y > raquetaJugador.Posicion.Y)
            {
                raquetaJugador.Mover(0, raquetaJugador.Velocidad);
            }
            if (destino.Y < raquetaJugador.Posicion.Y)
            {
                raquetaJugador.Mover(0, -raquetaJugador.Velocidad);
            }
        }
        #endregion

        #region Posición bala del enemigo
        /// <summary>
        /// Devuelve la posición de la bala del enemigo
        /// </summary>
        /// <returns>Posición de la bala del enemigo</returns>
        public Point PosicionBalaEnemigo()
        {
            if (this.balasEnemigo != null)
            {
                return this.balasEnemigo.Posicion;
            }
            else
            {
                return new Point(-2, -2);
            }
        }
        #endregion

        #region Posición bala del jugador
        /// <summary>
        /// Posición de la bala del jugador
        /// </summary>
        /// <returns>Posición de la bala</returns>
        public Point PosicionBalaJugador()
        {
            if (this.balasJugador != null)
            {
                return this.balasJugador.Posicion;
            }
            else return new Point(-2, -2);
        }
        #endregion

        #region Calcular nuevo punto de la pelota
        /// <summary>
        /// Calcula el nuevo punto en el que se situará la pelota
        /// Si no choca, se usa la punto-pendiente
        /// Si choca con una pared, cambia el signo de la pendiente
        /// Si choca con una raqueta, el punto inicial de la punto-pendiente cambia, así como la dirección y la pendiente
        /// </summary>
        /// <param name="Y">Nueva ordenada Y, Y anterior más su velocidad</param>
        /// <returns>Punto siguiente de la trayectoria de la bola</returns>
        public Point NuevoPunto(int Y)
        {
            //Y - Y0 = m * (X - X0)
            int X;

            if (this.comprobarInterseccion())
            {
                Y = this.bola.Posicion.Y;
            }

            if (this.bola.Posicion.Y > 250)
            {
                this.marcador.GolEnemigo();
                this.ComienzaJuego();
                Y = this.bola.Posicion.Y;
            }
            else if (this.bola.Posicion.Y < 0)
            {
                this.marcador.GolJugador();
                this.ComienzaJuego();
                Y = this.bola.Posicion.Y;
            }

            if ((this.bola.Posicion.X < 200) && (this.bola.Posicion.X > 0))
            {
                X = (this.bola.Pendiente * this.puntoInicial.X - this.puntoInicial.Y + Y) / this.bola.Pendiente;
            }
            else
            {
                this.bola.Pendiente = -this.bola.Pendiente;
                this.puntoInicial = this.bola.Posicion;
                X = (this.bola.Pendiente * this.puntoInicial.X - this.puntoInicial.Y + Y) / this.bola.Pendiente;
            }

            return new Point(X, Y);
        }
        #endregion

        #region Comprobar si la pelota choca con una raqueta
        /// <summary>
        /// Comprueba si una pelota ha chocado con una raqueta
        /// </summary>
        /// <returns>True si pega, False en caso contrario</returns>
        private bool comprobarInterseccion()
        {
            if (this.bola.Direccion)
            {
                //if ((balasera.Posicion.X >= this.posicion.X - this.longitud / 2) && (balasera.Posicion.X <= this.posicion.X + this.longitud / 2) && ((balasera.Posicion.Y <= this.posicion.Y)&&(balasera.SituacionAnterior() >= this.posicion.Y)))
                if ((bola.Posicion.X >= raquetaJugador.Posicion.X - raquetaJugador.Longitud / 2) && (bola.Posicion.X <= raquetaJugador.Posicion.X + raquetaJugador.Longitud / 2) && (bola.Posicion.Y <= raquetaJugador.Posicion.Y) && (bola.Posicion.Y + bola.Velocidad >= raquetaJugador.Posicion.Y))
                {
                    bola.Direccion = false;
                    bola.Velocidad = raquetaJugador.Pegada;
                    this.bola.Pendiente = -this.bola.Pendiente;
                    this.puntoInicial = this.bola.Posicion;
                    return true;
                }
            }
            else
            {
                if ((bola.Posicion.X >= raquetaEnemigo.Posicion.X - raquetaEnemigo.Longitud / 2) && (bola.Posicion.X <= raquetaEnemigo.Posicion.X + raquetaEnemigo.Longitud / 2) && (bola.Posicion.Y <= raquetaEnemigo.Posicion.Y) && (bola.Posicion.Y + bola.Velocidad >= raquetaEnemigo.Posicion.Y))
                {
                    bola.Direccion = true;
                    bola.Velocidad = raquetaEnemigo.Pegada;
                    this.bola.Pendiente = -this.bola.Pendiente;
                    this.puntoInicial = this.bola.Posicion;
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Iniciar el juego
        /// <summary>
        /// Inicia el juego, la pendiente es aleatoria
        /// </summary>
        public void ComienzaJuego()
        {
            this.bola.Posicion = new Point(100, 125);
            this.bola.Velocidad = 2;
            puntoInicial = this.bola.Posicion;
            int aux = aleatorio.Next(2);
            this.bola.Direccion = aux == 1;
            this.bola.Pendiente = aleatorio.Next(10);
            if (this.bola.Pendiente == 0)
            {
                this.bola.Pendiente = 1;
            }
        }
        #endregion
    }
}
