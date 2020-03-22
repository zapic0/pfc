using System;
using System.Collections.Generic;
using System.Text;
using MascotaVirtual.VidaMascota.Modelo.Objetos;
using MascotaVirtual.VidaMascota.Modelo.Componentes;
using System.Drawing;
using MascotaVirtual.Utilidades;
using System.Collections;

namespace MascotaVirtual.VidaMascota.Modelo
{
    /// <summary>
    /// Clase serializable con la información necesaria para guardar y cargar una mascota
    /// </summary>
    public class MascotaSerializable
    {
        private bool estaViva;
        private int hambre;
        private int higiene;
        private int educacion;
        private int salud;
        private int diversion;
        private int puntosVida;
        private int nivel;
        private int resistencia;
        private int fuerza;
        private int destreza;
        private int inteligencia;
        private int dinero;
        private ListaObjetos inventario;
        private ListaComponentes componentes;
        private Alimento alimentoCualquiera;
        private Limpiador limpiadorCualquiera;
        private Educador libroCualquiera;
        private Curador curadorCualquiera;
        private Componente componenteCualquiera;

        #region Componente
        /// <summary>
        /// Getter y Setter de la cabeza
        /// </summary>
        public Componente ComponenteCualquiera
        {
            get { return componenteCualquiera; }
            set { componenteCualquiera = value; }
        }
        #endregion
        #region Curador
        /// <summary>
        /// Getter y Setter del curador
        /// </summary>
        public Curador CuradorCualquiera
        {
            get { return curadorCualquiera; }
            set { curadorCualquiera = value; }
        }
        #endregion
        #region Libro
        /// <summary>
        /// Getter y Setter del libro
        /// </summary>
        public Educador LibroCualquiera
        {
            get { return libroCualquiera; }
            set { libroCualquiera = value; }
        }
        #endregion
        #region Alimento
        /// <summary>
        /// Getter y Setter del alimento
        /// </summary>
        public Alimento AlimentoCualquiera
        {
            get { return alimentoCualquiera; }
            set { alimentoCualquiera = value; }
        }
        #endregion
        #region Limpiador
        /// <summary>
        /// Getter y Setter del limpiador
        /// </summary>
        public Limpiador LimpiadorCualquiera
        {
            get { return limpiadorCualquiera; }
            set { limpiadorCualquiera = value; }
        }
        #endregion

        #region EstaViva
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
            }
        }
        #endregion
        #region Higiene
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
            }
        }
        #endregion
        #region Educacion
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
            }
        }
        #endregion
        #region Salud
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
            }
        }
        #endregion
        #region Diversion
        /// <summary>
        /// Getter y Setter de la propiedad diversion
        /// </summary>
        public int Diversion
        {
            get { return diversion; }
            set
            {
                diversion = value;
            }
        }
        #endregion
        #region PuntosVida
        /// <summary>
        /// Getter y Setter de la propiedad puntosVida
        /// </summary>
        public int PuntosVida
        {
            get { return puntosVida; }
            set { puntosVida = value; }
        }
        #endregion
        #region Nivel
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
        /// Getter y Setter de la propiedad inteligencia
        /// </summary>
        public int Inteligencia
        {
            get { return inteligencia; }
            set { inteligencia = value; }
        }
        #endregion
        #region Dinero
        /// <summary>
        /// Dinero de la mascota.
        /// </summary>
        public int Dinero
        {
            get { return dinero; }
            set { dinero = value; }
        }
        #endregion
        #region Inventario
            /// <summary>
        /// Getter y Setter de la propiedad inventario
        /// </summary>
        public ListaObjetos Inventario
        {
            get { return inventario; }
            set { inventario = value; }
        }
        #endregion
        #region Lista de Componentes
        /// <summary>
        /// Get y Set de la lista de componentes
        /// </summary>
        public ListaComponentes Componentes
        {
            get { return componentes; }
            set { componentes = value; }
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
                }
            }
        }
        #endregion

        #region Constructor con parámetros
        /// <summary>
        /// Constructor de prueba para serializar
        /// </summary>
        public MascotaSerializable(bool estaViva, int hambre, int higiene, int educacion, int salud, int diversion, int puntosVida, int nivel, int resistencia, int fuerza, int destreza, int inteligencia)
        {
            EstaViva = estaViva;
            Hambre = hambre;
            Higiene = higiene;
            Educacion = educacion;
            Salud = salud;
            Diversion = diversion;
            PuntosVida = puntosVida;
            Nivel = nivel;
            Resistencia = resistencia;
            Fuerza = fuerza;
            Destreza = destreza;
            Inteligencia = inteligencia;
            inventario = new ListaObjetos();
        }
        #endregion

        #region Mascota de valores predeterminados
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public MascotaSerializable() 
        {
            EstaViva = true;
            Hambre = 0;
            Higiene = 100;
            Educacion = 0;
            Salud = 100;
            Diversion = 100;
            PuntosVida = 1000;
            Dinero = 0;

            acumuladoAtributoDestrezaInteligencia = 0;
            acumuladoAtributoResistenciaFuerza = 0;

            Resistencia = 1;
            Fuerza = 3;
            Destreza = 1;
            Inteligencia = 1;
            Nivel = resistencia + fuerza + destreza + inteligencia;

            Inventario = new ListaObjetos();
            Componentes = new ListaComponentes();

            Educador libro = new Educador("Libro", 10, "graficos\\libro.bmp");
            Alimento cerebro = new Alimento("Cerebro", 80, "graficos\\cerebro.bmp");
            Alimento bocadillo = new Alimento("Bocadillo", 10, "graficos\\bocata.bmp");
            Limpiador patito = new Limpiador("Patito de Goma", 70, "graficos\\higiene.bmp");
            Curador botiquin = new Curador("Botiquín", 100, "graficos\\botiquin.bmp");
            inventario.Insertar(libro);
            inventario.Insertar(cerebro);
            inventario.Insertar(bocadillo);
            inventario.Insertar(patito);
            inventario.Insertar(botiquin);

            Point puntoMedio = new Point(200, 150);

            #region Pierna Derecha
            Componente piernaDerecha = new Componente();

            piernaDerecha.DatosAnimacionQuieto[0].RectanguloFuente = new Rectangle(0, 0, 34, 21);
            piernaDerecha.DatosAnimacionQuieto[0].DistanciaPuntoReferencia = new Point(0, -40);
            piernaDerecha.DatosAnimacionQuieto[1].RectanguloFuente = new Rectangle(0, 0, 34, 21);
            piernaDerecha.DatosAnimacionQuieto[1].DistanciaPuntoReferencia = new Point(0, -40);

            for (int i = 0; i < 6; i++)
            {
                piernaDerecha.DatosAnimacionCaminar[i].RectanguloFuente = new Rectangle(34*i, 0, 34, 21);
                piernaDerecha.DatosAnimacionCaminar[i].DistanciaPuntoReferencia = new Point(0, -40);
                piernaDerecha.DatosAnimacionCaminarGirado[i].DistanciaPuntoReferencia = new Point(0, -40);
            }

            piernaDerecha.CalcularGiro();
            piernaDerecha.Frame = 0;
            piernaDerecha.GradoVida = 0;
            piernaDerecha.Nombre = "piernaDerecha";
            piernaDerecha.RutaImagen = "graficos//pieDerechoAndando.bmp";
            #endregion
            #region Pierna Izquierda
            Componente piernaIzquierda = new Componente();

            piernaIzquierda.DatosAnimacionQuieto[0].RectanguloFuente = new Rectangle(0, 0, 32, 21);
            piernaIzquierda.DatosAnimacionQuieto[0].DistanciaPuntoReferencia = new Point(0, -40);
            piernaIzquierda.DatosAnimacionQuieto[1].RectanguloFuente = new Rectangle(0, 0, 32, 21);
            piernaIzquierda.DatosAnimacionQuieto[1].DistanciaPuntoReferencia = new Point(0, -40);

            for (int i = 0; i < 6; i++)
            {
                piernaIzquierda.DatosAnimacionCaminar[i].RectanguloFuente = new Rectangle(32 * i, 0, 32, 21);
                piernaIzquierda.DatosAnimacionCaminar[i].DistanciaPuntoReferencia = new Point(0, -40);
                piernaIzquierda.DatosAnimacionCaminarGirado[i].DistanciaPuntoReferencia = new Point(0, -40);
            }

            piernaIzquierda.CalcularGiro();
            piernaIzquierda.Frame = 0;
            piernaIzquierda.GradoVida = 0;
            piernaIzquierda.Nombre = "piernaIzquierda";
            piernaIzquierda.RutaImagen = "graficos//pieIzquierdoAndando.bmp";
            #endregion
            #region Brazo Derecho
            Componente brazoDerecho = new Componente();
            brazoDerecho.DatoComponente.RectanguloFuente = new Rectangle(0, 0, 24, 29);
            brazoDerecho.DatoComponente.DistanciaPuntoReferencia = new Point(0, -62);

            for (int i = 0; i < 6; i++)
            {
                brazoDerecho.DatosAnimacionCaminar[i].RectanguloFuente = new Rectangle(0, 0, 24, 29);
                brazoDerecho.DatosAnimacionCaminar[i].DistanciaPuntoReferencia = new Point(2, -62);
                brazoDerecho.DatosAnimacionCaminarGirado[i].DistanciaPuntoReferencia = new Point(4, -62);
            }

            brazoDerecho.CalcularGiro();
            brazoDerecho.DatosAnimacionQuieto[0].RectanguloFuente = new Rectangle(0, 0, 24, 29);
            brazoDerecho.DatosAnimacionQuieto[0].DistanciaPuntoReferencia = new Point(0, -62);
            brazoDerecho.Frame = 0;
            brazoDerecho.GradoVida = 0;
            brazoDerecho.Nombre = "brazoDerecho";
            brazoDerecho.RutaImagen = "graficos//brazoZombieCorbata.bmp";
            #endregion
            #region Brazo Izquierdo
            Componente brazoIzquierdo = new Componente();
            brazoIzquierdo.DatoComponente.RectanguloFuente = new Rectangle(0, 0, 24, 29);
            brazoIzquierdo.DatoComponente.DistanciaPuntoReferencia = new Point(0, -62);

            for (int i = 0; i < 6; i++)
            {
                brazoIzquierdo.DatosAnimacionCaminar[i].RectanguloFuente = new Rectangle(0, 0, 24, 29);
                brazoIzquierdo.DatosAnimacionCaminar[i].DistanciaPuntoReferencia = new Point(2, -62);
                brazoIzquierdo.DatosAnimacionCaminarGirado[i].DistanciaPuntoReferencia = new Point(4, -62);
            }
            brazoIzquierdo.DatosAnimacionQuieto[1].RectanguloFuente = new Rectangle(0, 0, 24, 29);
            brazoIzquierdo.DatosAnimacionQuieto[1].DistanciaPuntoReferencia = new Point(0, -62);

            brazoIzquierdo.CalcularGiro();
            brazoIzquierdo.Frame = 0;
            brazoIzquierdo.GradoVida = 0;
            brazoIzquierdo.Nombre = "brazoIzquierdo";
            brazoIzquierdo.RutaImagen = "graficos//brazoZombieCorbata.bmp";
            #endregion
            #region Tronco
            Componente tronco = new Componente();
            tronco.DatosAnimacionQuieto[0].RectanguloFuente = new Rectangle(0, 0, 32, 33);
            tronco.DatosAnimacionQuieto[0].DistanciaPuntoReferencia = new Point(0, -71);
            tronco.DatosAnimacionQuieto[1].RectanguloFuente = new Rectangle(0, 0, 32, 33);
            tronco.DatosAnimacionQuieto[1].DistanciaPuntoReferencia = new Point(0, -71);

            for (int i = 0; i < 6; i++)
            {
                tronco.DatosAnimacionCaminar[i].RectanguloFuente = new Rectangle(32*i, 0, 32, 33);
                tronco.DatosAnimacionCaminar[i].DistanciaPuntoReferencia = new Point(0, -71);
                tronco.DatosAnimacionCaminarGirado[i].DistanciaPuntoReferencia = new Point(0, -71);
            }

            tronco.CalcularGiro();
            tronco.Frame = 0;
            tronco.GradoVida = 0;
            tronco.Nombre = "tronco";
            tronco.RutaImagen = "graficos//cuerpoZombieAndando.bmp";
            #endregion
            #region Cabeza
            Componente cabeza = new Componente();
            cabeza.GradoVida = 0;
            cabeza.Frame = 0;
            for (int i = 0; i < 6; i++)
            {
                cabeza.DatosAnimacionCaminar[i].RectanguloFuente = new Rectangle(0, 0, 42, 44);
            }
            cabeza.DatosAnimacionQuieto[0].DistanciaPuntoReferencia = new Point(-20, -105);
            cabeza.DatosAnimacionQuieto[0].RectanguloFuente = new Rectangle(0, 0, 42, 44);
            cabeza.DatosAnimacionQuieto[1].DistanciaPuntoReferencia = new Point(-20, -105);
            cabeza.DatosAnimacionQuieto[1].RectanguloFuente = new Rectangle(0, 0, 42, 44);
            
            cabeza.DatosAnimacionCaminar[0].DistanciaPuntoReferencia = new Point(-20, -105);
            cabeza.DatosAnimacionCaminar[1].DistanciaPuntoReferencia = new Point(-20, -105);
            cabeza.DatosAnimacionCaminar[2].DistanciaPuntoReferencia = new Point(-13, -107);
            cabeza.DatosAnimacionCaminar[3].DistanciaPuntoReferencia = new Point(-20, -105);
            cabeza.DatosAnimacionCaminar[4].DistanciaPuntoReferencia = new Point(-20, -105);
            cabeza.DatosAnimacionCaminar[5].DistanciaPuntoReferencia = new Point(-13, -107);
            cabeza.DatosAnimacionCaminarGirado[0].DistanciaPuntoReferencia = new Point(3, -107);
            cabeza.DatosAnimacionCaminarGirado[1].DistanciaPuntoReferencia = new Point(10, -105);
            cabeza.DatosAnimacionCaminarGirado[2].DistanciaPuntoReferencia = new Point(10, -105);
            cabeza.DatosAnimacionCaminarGirado[3].DistanciaPuntoReferencia = new Point(3, -107);
            cabeza.DatosAnimacionCaminarGirado[4].DistanciaPuntoReferencia = new Point(10, -105);
            cabeza.DatosAnimacionCaminarGirado[5].DistanciaPuntoReferencia = new Point(10, -105);

            cabeza.CalcularGiro();

            cabeza.Nombre = "Cabeza";
            cabeza.RutaImagen = "graficos//cabezaZombieCorbata.bmp";
            #endregion

            componentes.Insertar(piernaDerecha);
            componentes.Insertar(brazoDerecho);
            componentes.Insertar(tronco);
            componentes.Insertar(piernaIzquierda);
            componentes.Insertar(brazoIzquierdo);
            componentes.Insertar(cabeza);
        }
        #endregion
    }
}
