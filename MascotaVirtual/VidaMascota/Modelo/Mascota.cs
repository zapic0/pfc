using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using MascotaVirtual.VidaMascota.Modelo.Objetos;
using MascotaVirtual.VidaMascota.Modelo.Componentes;
using System.Xml.Serialization;
using System.Windows.Forms;
using MascotaVirtual.Utilidades;
using System.Collections;

namespace MascotaVirtual.VidaMascota.Modelo
{
    /// <summary>
    /// Clase de tipo Mascota que define el comportamiento y propiedades de una mascota
    /// </summary>
    public class Mascota
    {
        #region Constantes
        private static int MIN = 0;
        private static int MAX = 100;
        #endregion

        #region Variables
        /// <summary>
        /// Imagen que se cargará como fondo
        /// </summary>
        protected Bitmap fondo;
        /// <summary>
        /// Imagen que se mostrará cuando la mascota esté muerta
        /// </summary>
        protected Bitmap tumba;
        /// <summary>
        /// Animación mostrada por la mascota
        /// </summary>
        protected int animacion;
        /// <summary>
        /// Lista de las imágenes de los componentes, así se ahorra en tiempo de ejecución
        /// </summary>
        protected ArrayList ListaImagenes;
        /// <summary>
        /// Lista de componentes de la mascota (cabeza, brazos, piernas...)
        /// </summary>
        protected ListaComponentes componentes;
        /// <summary>
        /// Mascota a partir de la cual serializamos y deserializamos los datos en XML
        /// </summary>
        protected MascotaSerializable mascotaSerializable;
        #endregion

        #region Delegados
        #region Delegado y Evento del cambio de Imagen
        /// <summary>
        /// Manejador del cambio de imagen de la mascota
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Nueva imagen de la mascota</param>
        public delegate void ManejadorImagenCambiada(object source, Bitmap e);
        /// <summary>
        /// Evento del cambio de imagen de la mascota
        /// </summary>
        public event ManejadorImagenCambiada OnImagenCambiada;
        #endregion
        #region Delegados y Eventos del cambio de valores de vida
        #region Hambre
        /// <summary>
        /// Manejador del cambio del valor del hambre de la mascota
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Nuevo valor del hambre</param>
        public delegate void ManejadorHambreCambiada(object source, int e);
        /// <summary>
        /// Evento del cambio de valor del hambre
        /// </summary>
        public event ManejadorHambreCambiada OnHambreCambiada;
        #endregion
        #region Higiene
        /// <summary>
        /// Manejador del cambio del valor de la higiene de la mascota
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Nuevo valor de la higiene</param>
        public delegate void ManejadorHigieneCambiada(object source, int e);
        /// <summary>
        /// Evento del cambio de Higiene de la mascota
        /// </summary>
        public event ManejadorHigieneCambiada OnHigieneCambiada;
        #endregion
        #region Educación
        /// <summary>
        /// Manejador del cambio de educación de la mascota
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Nuevo valor de la educación</param>
        public delegate void ManejadorEducacionCambiada(object source, int e);
        /// <summary>
        /// Evento del cambio de educación
        /// </summary>
        public event ManejadorEducacionCambiada OnEducacionCambiada;
        #endregion
        #region Salud
        /// <summary>
        /// Manejador del cambio de salud de la mascota
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Nuevo valor de la salud</param>
        public delegate void ManejadorSaludCambiada(object source, int e);
        /// <summary>
        /// Evento del cambio de salud de la mascota
        /// </summary>
        public event ManejadorSaludCambiada OnSaludCambiada;
        #endregion
        #region Diversión
        /// <summary>
        /// Manejador del cambio de diversión de la mascota
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Nuevo valor de la diversión</param>
        public delegate void ManejadorDiversionCambiada(object source, int e);
        /// <summary>
        /// Evento del cambio de diversión de la mascota
        /// </summary>
        public event ManejadorDiversionCambiada OnDiversionCambiada;
        #endregion
        #region Puntos de Vida
        /// <summary>
        /// Manejador del cambio de puntos de vida
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Nuevo valor de la vida</param>
        public delegate void ManejadorPuntosVidaCambiada(object source, int e);
        /// <summary>
        /// Evento del cambio de puntos de vida de la mascota
        /// </summary>
        public event ManejadorPuntosVidaCambiada OnPuntosVidaCambiada;
        #endregion
        #region Subida Dinero
        /// <summary>
        /// Manejador de la subida del dinero.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Nuevo valor del dinero.</param>
        public delegate void ManejadorDineroCambiado(object source, int e);
        /// <summary>
        /// Evento del cambio de dinero de la mascota.
        /// </summary>
        public event ManejadorDineroCambiado OnDineroCambiado;
        #endregion
        #region Nivel
        /// <summary>
        /// Manejador del cambio de nivel de la mascota
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Nuevo valor del nivel</param>
        public delegate void ManejadorNivelCambiado(object source, int e);
        /// <summary>
        /// Evento del cambio de valor del nivel
        /// </summary>
        public event ManejadorNivelCambiado OnNivelCambiado;
        #endregion
        #endregion
        #endregion

        #region Getters y Setters de las Propiedades
        #region Inventario
        /// <summary>
        /// Lista de objetos de la mascota (alimentos, libros, limpiadores...)
        /// </summary>
        protected ListaObjetos inventario;
        /// <summary>
        /// Get y Set del Inventario
        /// </summary>
        public ListaObjetos Inventario
        {
            get { return inventario; }
            set { inventario = value; }
        }
        #endregion
        #region EstaViva
        /// <summary>
        /// Devuelve si la mascota continua viva o ha muerto
        /// </summary>
        protected bool estaViva;
        /// <summary>
        /// Getter y Setter de la propiedad estaViva
        /// Devuelve true si la Mascota está viva y false en caso contrario
        /// </summary>
        public bool EstaViva
        {
            get
            {
                return estaViva;
            }
            set
            {
                estaViva = value;
            }
        }
        #endregion

        #region Hambre
        /// <summary>
        /// Hambre de la mascota
        /// </summary>
        protected int hambre;
        /// <summary>
        /// Getter y Setter de la propiedad hambre
        /// </summary>
        public int Hambre
        {
            get
            {
                return hambre;
            }
            set
            {
                hambre = value;
                if (hambre >= MAX)
                {
                    this.salud -= 10;
                    hambre = MAX;
                }
                if (hambre < MIN)
                {
                    hambre = MIN;
                }
                if (OnHambreCambiada != null)
                {
                    OnHambreCambiada(this, hambre);
                }
            }
        }
        #endregion
        #region Higiene
        /// <summary>
        /// Higiene de la mascota
        /// </summary>
        protected int higiene;
        /// <summary>
        /// Getter y Setter de la propiedad higiene
        /// </summary>
        public int Higiene
        {
            get
            {
                return higiene;
            }
            set
            {
                higiene = value;
                if (higiene <= MIN)
                {
                    this.salud -= 5;
                    higiene = MIN;
                }
                if (higiene > MAX)
                {
                    higiene = MAX;
                }
                if (OnHigieneCambiada != null)
                {
                    OnHigieneCambiada(this, higiene);
                }
            }
        }
        #endregion
        #region Educacion
        /// <summary>
        /// Educación de la mascota
        /// </summary>
        protected int educacion;
        /// <summary>
        /// Getter y Setter de la propiedad educacion
        /// </summary>
        public int Educacion
        {
            get
            {
                return educacion;
            }
            set
            {
                educacion = value;
                if (educacion < MIN)
                {
                    this.diversion -= 5;
                    educacion = MIN;
                }
                if (educacion > MAX)
                {
                    educacion = MAX;
                }
                if (OnEducacionCambiada != null)
                {
                    OnEducacionCambiada(this, educacion);
                }
            }
        }
        #endregion
        #region Salud
        /// <summary>
        /// Salud de la mascota
        /// </summary>
        protected int salud;
        /// <summary>
        /// Getter y Setter de la propiedad salud
        /// </summary>
        public int Salud
        {
            get
            {
                return salud;
            }
            set
            {
                salud = value;
                if (salud <= MIN)
                {
                    salud = MIN;
                    this.puntosVida -= 10;
                }
                if (salud >= MAX)
                {
                    salud = MAX;
                }
                if (OnSaludCambiada != null)
                {
                    OnSaludCambiada(this, salud);
                }
            }
        }
        #endregion
        #region Diversion
        /// <summary>
        /// Diversión de la mascota
        /// </summary>
        protected int diversion;
        /// <summary>
        /// Getter y Setter de la propiedad diversion
        /// </summary>
        public int Diversion
        {
            get { return diversion; }
            set
            {
                diversion = value;
                if (diversion <= MIN)
                {
                    diversion = MIN;
                }
                if (diversion > MAX)
                {
                    diversion = MAX;
                }
                if (OnDiversionCambiada != null)
                {
                    OnDiversionCambiada(this, diversion);
                }
            }
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
                if (puntosVida < MIN)
                {
                    puntosVida = MIN;
                }
                if (puntosVida == MIN)
                {
                    this.hambre = MIN;
                    this.higiene = MIN;
                    this.salud = MIN;
                    this.diversion = MIN;
                    this.educacion = MIN;
                    this.estaViva = false;
                }
                if (OnPuntosVidaCambiada != null)
                {
                    OnPuntosVidaCambiada(this, puntosVida);
                }
            }
        }
        #endregion

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
            set 
            {
                nivel = value;
                if (OnNivelCambiado != null)
                {
                    OnNivelCambiado(this, nivel);
                }
            }
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
            set 
            {
                resistencia = value;
            }
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
            set
            {
                fuerza = value;
            }
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
            set
            {
                destreza = value;
            }
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
            set
            {
                inteligencia = value;
            }
        }
        #endregion

        #region Acumulado atributo resistencia y fuerza
        private int acumuladoAtributoResistenciaFuerza;
        /// <summary>
        /// Puntuaciones aculumadas para mejorar los atributos resistencia y fuerza.
        /// Si suma más de 1000 se aumenta un atributo.
        /// Si tiene más higiene que salud se mejora la resistencia.
        /// En caso contrario se mejora la fuerza.
        /// </summary>
        public int AcumuladoAtributoResistenciaFuerza
        {
            get { return acumuladoAtributoResistenciaFuerza; }
            set
            {
                acumuladoAtributoResistenciaFuerza = value;
                if (acumuladoAtributoResistenciaFuerza >= 1000)
                {
                    acumuladoAtributoResistenciaFuerza = acumuladoAtributoResistenciaFuerza - 1000;
                    if (higiene > salud)
                    {
                        resistencia++;
                    }
                    else
                    {
                        fuerza++;
                    }
                    Nivel++;
                }
            }
        }
        #endregion

        #region Acumulador atributo destreza e inteligencia
        private int acumuladoAtributoDestrezaInteligencia;
        /// <summary>
        /// Puntuaciones aculumadas para mejorar los atributos destreza e inteligencia.
        /// Si suma más de 1000 se aumenta un atributo.
        /// Si tiene más educación que la mitad de la diversión se mejora la inteligencia.
        /// En caso contrario se mejora la destreza.
        /// </summary>
        public int AcumuladorAtributoDestrezaIngeligencia
        {
            get { return acumuladoAtributoDestrezaInteligencia; }
            set
            {
                acumuladoAtributoDestrezaInteligencia = value;
                if (acumuladoAtributoDestrezaInteligencia >= 1000)
                {
                    acumuladoAtributoDestrezaInteligencia = acumuladoAtributoDestrezaInteligencia - 1000;
                    if (educacion > diversion / 2)
                    {
                        inteligencia++;
                    }
                    else
                    {
                        destreza++;
                    }
                    Nivel++;
                }
            }
        }
        #endregion


        #region Dinero
        private int dinero;
        /// <summary>
        /// Dinero de que dispone la mascota.
        /// </summary>
        public int Dinero
        {
            get { return dinero; }
            set 
            {
                dinero = value;
                if (dinero < 0)
                {
                    dinero = 0;
                }
                if (OnDineroCambiado != null)
                {
                    OnDineroCambiado(this, dinero);
                }
            }
        }
        #endregion

        #region Bmp
        /// <summary>
        /// Imagen sobre la que se van pintando los diferentes frames del juego
        /// </summary>
        protected Bitmap bmp;
        /// <summary>
        /// Getter y Setter de la propiedad bmp
        /// </summary>
        public Bitmap Bmp
        {
            get
            {
                return bmp;
            }
            set
            {
                bmp = value;
            }
        }
        #endregion
        #region Pintable
        /// <summary>
        /// Gráfico que utilizaremos para pintar sobre "bmp"
        /// </summary>
        protected Graphics pintable;
        /// <summary>
        /// Grafico usado para pintar sobre "bmp"
        /// </summary>
        public Graphics Pintable
        {
            get { return pintable; }
            set { pintable = value; }
        }
        #endregion
        #region Girado
        /// <summary>
        /// Indica si la animación está girada (mirando a la derecha) o no
        /// </summary>
        protected bool girado;
        /// <summary>
        /// Get y set de la propiedad girado, que indica si la animación está girada o no
        /// </summary>
        public bool Girado
        {
            get { return girado; }
            set { girado = value; }
        }
        #endregion
        #region Punto de Referencia
        /// <summary>
        /// Punto de referencia en el que se pinta la mascota
        /// </summary>
        protected Point puntoReferencia;
        /// <summary>
        /// Get y Set del punto de referencia donde se pintará la mascota
        /// </summary>
        public Point PuntoReferencia
        {
            get { return puntoReferencia; }
            set { puntoReferencia = value; }
        }
        #endregion
        #region Destino
        /// <summary>
        /// Punto al que se dirige la mascota
        /// </summary>
        protected Point destino;
        /// <summary>
        /// Get y Set del punto al que se dirige la mascota
        /// </summary>
        public Point Destino
        {
            get { return destino; }
            set
            {
                destino = value;
                if (puntoReferencia.X < destino.X)
                {
                    this.Girar(true);
                    this.SeleccionarAnimacion(1);
                }
                else if (puntoReferencia.X > destino.X)
                {
                    this.Girar(false);
                    this.SeleccionarAnimacion(1);
                }
            }
        }
        #endregion
        #endregion

        #region Métodos
        #region Alimentar
        /// <summary>
        /// Alimenta a la Mascota disminuyendo su Hambre en función de la Capacidad del Alimento
        /// </summary>
        /// <param name="comida">Alimento</param>
        public void Alimentar(Alimento comida)
        {
            Hambre = Hambre - comida.Capacidad;
            if (Hambre < MIN)
            {
                Hambre = MIN;
            }
        }
        #endregion
        #region Limpiar
        /// <summary>
        /// Limpia a la Mascota
        /// </summary>
        /// <param name="limpiador">Limpiador</param>
        public void Limpiar(Limpiador limpiador)
        {
            Higiene = Higiene + limpiador.Capacidad;
            if (Higiene > MAX)
            {
                Higiene = MAX;
            }
        }
        #endregion
        #region Educar
        /// <summary>
        /// Educa a la Mascota
        /// </summary>
        /// <param name="educador">Educador</param>
        public void Educar(Educador educador)
        {
            Educacion = Educacion + educador.Capacidad;
            if (Educacion > MAX)
            {
                educacion = MAX;
            }
        }
        #endregion
        #region Curar
        /// <summary>
        /// Restablece la Salud a la Mascota
        /// </summary>
        /// <param name="cura">Curador</param>
        public void Curar(Curador cura)
        {
            Salud = Salud + cura.Capacidad;
            if (Salud > MAX)
            {
                Salud = MAX;
            }
        }
        #endregion

        #region Generar Imagen de la Mascota
        /// <summary>
        /// Devuelve una imagen de la mascota con el ancho y el alto especificado.
        /// </summary>
        /// <param name="ancho">Ancho de la imagen.</param>
        /// <param name="alto">Alto de la imagen.</param>
        /// <param name="color">El color que se usará como fondo.</param>
        /// <returns>Imagen de la mascota.</returns>
        public Bitmap GenerarImagenMascota(int ancho, int alto, Color color)
        {
            NodoComponente aux = componentes.Cab;
            ImageAttributes atributos = new ImageAttributes();
            Color colorTransparente = ((Bitmap)ListaImagenes[0]).GetPixel(0, 0);
            atributos.SetColorKey(colorTransparente, colorTransparente);

            Bitmap imagen = new Bitmap(ancho, alto);
            Graphics pintador = Graphics.FromImage(imagen);
            pintador.Clear(color);

            int i = 0;
            while (aux != null)
            {
                Bitmap dibujo = (Bitmap)ListaImagenes[i];
                Rectangle destino = new Rectangle(ancho / 2 + aux.Info.DatoComponente.DistanciaPuntoReferencia.X, alto + aux.Info.DatoComponente.DistanciaPuntoReferencia.Y +20, aux.Info.DatoComponente.RectanguloFuente.Width, aux.Info.DatoComponente.RectanguloFuente.Height);
                pintador.DrawImage(dibujo, destino, aux.Info.DatoComponente.RectanguloFuente.X, aux.Info.DatoComponente.RectanguloFuente.Y, aux.Info.DatoComponente.RectanguloFuente.Width, aux.Info.DatoComponente.RectanguloFuente.Height, GraphicsUnit.Pixel, atributos);
                aux = aux.Siguiente;
                i++;
            }

            return imagen;
        }
        #endregion

        #region Pasar Frame
        /// <summary>
        /// Pasa los frames necesarios de la aplicación
        /// </summary>
        public Bitmap PasarFrame()
        {
            NodoComponente aux = componentes.Cab;
            ImageAttributes atributos = new ImageAttributes();
            this.pintable.DrawImage(fondo, 0, 0);
            int i;
            i = 0;
            if (estaViva)
            {
                Color color = ((Bitmap)ListaImagenes[0]).GetPixel(0, 0);
                atributos.SetColorKey(color, color);
                while (aux != null)
                {
                    aux.Info.PasarFrame();
                    Rectangle destino = new Rectangle(puntoReferencia.X + aux.Info.DatoComponente.DistanciaPuntoReferencia.X, puntoReferencia.Y + aux.Info.DatoComponente.DistanciaPuntoReferencia.Y, aux.Info.DatoComponente.RectanguloFuente.Width, aux.Info.DatoComponente.RectanguloFuente.Height);
                    Bitmap dibujo = (Bitmap)ListaImagenes[i];
                    pintable.DrawImage(dibujo, destino, aux.Info.DatoComponente.RectanguloFuente.X, aux.Info.DatoComponente.RectanguloFuente.Y, aux.Info.DatoComponente.RectanguloFuente.Width, aux.Info.DatoComponente.RectanguloFuente.Height, GraphicsUnit.Pixel, atributos);
                    aux = aux.Siguiente;
                    i++;
                }
            }
            else
            {
                Color color = tumba.GetPixel(0, 0);
                atributos.SetColorKey(color, color);
                pintable.DrawImage(tumba, new Rectangle(puntoReferencia.X - tumba.Width / 2, puntoReferencia.Y - tumba.Height, tumba.Width, tumba.Height), 0, 0, tumba.Width, tumba.Height, GraphicsUnit.Pixel, atributos);
            }
            if (OnImagenCambiada != null)
            {
                OnImagenCambiada(this, bmp);
            }
            return bmp;
        }
        #endregion
        #region Seleccionar Animación
        /// <summary>
        /// Selecciona la animación que se le pasa por parámetros (andar o estarse quieto)
        /// </summary>
        /// <param name="animacion">Número de la animación a seleccionar</param>
        public void SeleccionarAnimacion(int animacion)
        {
            this.animacion = animacion;
            NodoComponente aux = this.componentes.Cab;
            while (aux != null)
            {
                aux.Info.SeleccionarAnimacion(animacion, girado);
                aux = aux.Siguiente;
            }
        }
        #endregion
        #region Girar Mascota
        /// <summary>
        /// Gira la mascota
        /// </summary>
        /// <param name="derecha">True si hay que girarla a la derecha, false en caso contrario</param>
        public void Girar(bool derecha)
        {
            if (derecha)
            {
                if (!girado)
                {
                    girarImagenes();
                    girado = true;
                }
            }
            else
            {
                if (girado)
                {
                    girarImagenes();
                    girado = false;
                }
            }
        }
        #endregion
        #region Girar Imágenes
        /// <summary>
        /// Gira las imágenes de cada componente de la mascota.
        /// </summary>
        private void girarImagenes()
        {
            Utilidades.GiradorImagenes girador = new GiradorImagenes();
            for (int i = 0; i < ListaImagenes.Count; i++)
            {
                ListaImagenes[i] = girador.GirarImagen((Bitmap)ListaImagenes[i]);
            }
        }
        #endregion

        #region Numero de Objetos
        /// <summary>
        /// Devuelve el número de objetos que hay en el inventario
        /// </summary>
        /// <returns>Entero con el número de objetos del inventario</returns>
        public int NumeroObjetos()
        {
            return this.inventario.NumeroObjetos;
        }
        #endregion

        #region Serializar
        /// <summary>
        /// Serializa la mascota.
        /// </summary>
        public void Serializar(bool nuevo)
        {
            if (!nuevo)
            {
                mascotaSerializable.EstaViva = estaViva;
                mascotaSerializable.Hambre = hambre;
                mascotaSerializable.Higiene = higiene;
                mascotaSerializable.Educacion = educacion;
                mascotaSerializable.Salud = salud;
                mascotaSerializable.Diversion = diversion;
                mascotaSerializable.PuntosVida = puntosVida;
                mascotaSerializable.Nivel = nivel;
                mascotaSerializable.Resistencia = resistencia;
                mascotaSerializable.Fuerza = fuerza;
                mascotaSerializable.Destreza = destreza;
                mascotaSerializable.Inteligencia = inteligencia;
                mascotaSerializable.Dinero = dinero;
                mascotaSerializable.AcumuladoAtributoResistenciaFuerza = acumuladoAtributoResistenciaFuerza;
                mascotaSerializable.AcumuladorAtributoDestrezaIngeligencia = acumuladoAtributoDestrezaInteligencia;

                mascotaSerializable.Componentes = componentes;
                mascotaSerializable.Inventario = inventario;
            }
            
            System.IO.StreamWriter writer;
            XmlSerializer serializer = new XmlSerializer(typeof(MascotaSerializable));

            writer = new System.IO.StreamWriter(new DirectorioRaiz().Directorio + "archivos\\XMLMascotaSerializable.xml");
            serializer.Serialize(writer, mascotaSerializable);
            writer.Close();
        }
        #endregion
        #region Deserializar
        /// <summary>
        /// Deserializa la mascota Serializable.
        /// </summary>
        public void Deserializar()
        {
            try
            {
                long memoria = new long();
                memoria = GC.GetTotalMemory(false);
                MascotaSerializable mascotaDeserializada;
                XmlSerializer serializer = new XmlSerializer(typeof(MascotaSerializable));

                using (System.IO.StreamReader reader = new System.IO.StreamReader(new DirectorioRaiz().Directorio + "archivos\\XMLMascotaSerializable.xml"))
                {
                    mascotaDeserializada = (MascotaSerializable)serializer.Deserialize(reader);
                    reader.Close();
                    serializer = null;
                }

                GC.Collect();

                EstaViva = mascotaDeserializada.EstaViva;
                Hambre = mascotaDeserializada.Hambre;
                Higiene = mascotaDeserializada.Higiene;
                Educacion = mascotaDeserializada.Educacion;
                Salud = mascotaDeserializada.Salud;
                Diversion = mascotaDeserializada.Diversion;
                PuntosVida = mascotaDeserializada.PuntosVida;
                Nivel = mascotaDeserializada.Nivel;
                Resistencia = mascotaDeserializada.Resistencia;
                Fuerza = mascotaDeserializada.Fuerza;
                Destreza = mascotaDeserializada.Destreza;
                Inteligencia = mascotaDeserializada.Inteligencia;
                Dinero = mascotaDeserializada.Dinero;
                AcumuladoAtributoResistenciaFuerza = mascotaDeserializada.AcumuladoAtributoResistenciaFuerza;
                AcumuladorAtributoDestrezaIngeligencia = mascotaDeserializada.AcumuladorAtributoDestrezaIngeligencia;

                componentes = mascotaDeserializada.Componentes;

                inventario = mascotaDeserializada.Inventario;
                mascotaDeserializada = null;
                GC.Collect();
                memoria = GC.GetTotalMemory(true);

                if (OnDiversionCambiada != null)
                {
                    OnDiversionCambiada(this, diversion);
                }
                if (OnEducacionCambiada != null)
                {
                    OnEducacionCambiada(this, educacion);
                }
                if (OnHambreCambiada != null)
                {
                    OnHambreCambiada(this, hambre);
                }
                if (OnHigieneCambiada != null)
                {
                    OnHigieneCambiada(this, higiene);
                }
                if (OnPuntosVidaCambiada != null)
                {
                    OnPuntosVidaCambiada(this, puntosVida);
                }
                if (OnSaludCambiada != null)
                {
                    OnSaludCambiada(this, salud);
                }
                if (OnDineroCambiado != null)
                {
                    OnDineroCambiado(this, dinero);
                }
            }
            catch
            {
                Serializar(true);
                Deserializar();
            }
        }
        #endregion
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor sin parámetros que inicializa todas las variables a sus valores básicos
        /// </summary>
        public Mascota()
        {
            bmp = new Bitmap(237, 188);
            fondo = new Bitmap(new DirectorioRaiz().Directorio + "graficos\\silla.jpg");
            tumba = new Bitmap(new DirectorioRaiz().Directorio + "graficos\\tumba.bmp");

            componentes = new ListaComponentes();
            inventario = new ListaObjetos();

            mascotaSerializable = new MascotaSerializable();
            //Serializar();
            Deserializar();

            ListaImagenes = new ArrayList();
            NodoComponente aux = new NodoComponente();
            aux = this.componentes.Cab;
            PuntoReferencia = new Point(200, 185);
            Destino = puntoReferencia;
            while (aux != null)
            {
                ListaImagenes.Add(new Bitmap(new DirectorioRaiz().Directorio + aux.Info.RutaImagen));
                aux = aux.Siguiente;
            }

            GC.Collect();
            animacion = 0;
            pintable = Graphics.FromImage(bmp);
            girado = false;
        }
        #endregion

        #region Generar nueva mascota
        /// <summary>
        /// Genera una nueva mascota.
        /// </summary>
        public void GenerarNuevaMascota()
        {
            mascotaSerializable = new MascotaSerializable();
            this.Serializar(true);
            this.Deserializar();
        }
        #endregion
    }
}
