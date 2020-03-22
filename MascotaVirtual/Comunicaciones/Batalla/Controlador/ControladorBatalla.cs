using System;
using System.Collections.Generic;
using System.Text;
using MascotaVirtual.VidaMascota;
using MascotaVirtual.Comunicaciones.Batalla.Modelo;
using System.Xml.Serialization;
using System.IO;
using MascotaVirtual.Utilidades;
using System.Threading;
using MascotaVirtual.VidaMascota.Modelo;

namespace MascotaVirtual.Comunicaciones.Batalla.Controlador
{
    /// <summary>
    /// Controlador de la batalla con conexión
    /// </summary>
    public class ControladorBatalla
    {
        const int _RECIBIRENVIARDATOS = 0;
        const int _ENVIARDATOS = 1;
        const int _RECIBIRDATOS = 2;
        const int _ENVIARGOLPE = 3;
        const int _RECIBIRGOLPE = 4;
        const int _ESPERARENVIARGOLPE = 5;
        const int _ESPERARRECIBIRGOLPE = 6;

        Random aleatorio;

        private ThreadStart inicioHiloLectura;
        private Thread hiloLectura;

        #region Estado
        private int estado;
        /// <summary>
        /// Estado de la batalla.
        /// </summary>
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        #endregion

        #region Delegado y Evento del error con las comunicaciones
        /// <summary>
        /// Manejador del error en las comunicaciones.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorErrorComunicaciones(object source, EventArgs e);
        /// <summary>
        /// Evento del error con las comunicaciones
        /// </summary>
        public event ManejadorErrorComunicaciones OnErrorComunicaciones;
        #endregion
        #region Delegado y Evento datos de atributos cargados
        /// <summary>
        /// Manejador del evento de los datos de atributos cargados.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorAtributosCargados(object source, EventArgs e);
        /// <summary>
        /// Evento de datos de la mascota remota recibidos.
        /// </summary>
        public event ManejadorAtributosCargados OnAtributosCargados;
        #endregion
        #region Delegado y Evento accion remota recibida
        /// <summary>
        /// Manejador del evento de la acción remota recibida.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorAccionRemotaRecibida(object source, EventArgs e);
        /// <summary>
        /// Evento de acción remota recibida.
        /// </summary>
        public event ManejadorAccionRemotaRecibida OnAccionRemotaRecibida;
        #endregion
        #region Delegado y Evento acción propia recibida
        /// <summary>
        /// Manejador del evento de la acción propia realizada.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorAccionPropiaRecibida(object source, EventArgs e);
        /// <summary>
        /// Evento de acción propia recibida.
        /// </summary>
        public event ManejadorAccionPropiaRecibida OnAccionPropiaRecibida;
        #endregion
        #region Delegado y Evento combate ganado
        /// <summary>
        /// Manejador del evento del combate ganado.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorCombateGanado(object source, EventArgs e);
        /// <summary>
        /// Evento de combate ganado.
        /// </summary>
        public event ManejadorCombateGanado OnCombateGanado;
        #endregion
        #region Delegado y Evento combate perdido
        /// <summary>
        /// Manejador del evento del combate perdido.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        public delegate void ManejadorCombatePerdido(object source, EventArgs e);
        /// <summary>
        /// Evento de combate perdido.
        /// </summary>
        public event ManejadorCombatePerdido OnCombatePerdido;
        #endregion

        #region Acción Propia
        private string accionPropia;
        /// <summary>
        /// Acción que queremos ejecutar.
        /// </summary>
        public string AccionPropia
        {
            get { return accionPropia; }
            set { accionPropia = value; }
        }
        #endregion
        #region Acción Remota
        private string accionRemota;
        /// <summary>
        /// Acción que quiere realizar el remoto.
        /// </summary>
        public string AccionRemota
        {
            get { return accionRemota; }
            set { accionRemota = value; }
        }
        #endregion
        #region Atributos Mascota Propia
        private AtributosMascota atributosMascotaPropia;
        /// <summary>
        /// Atributos de la mascota del jugador.
        /// </summary>
        public AtributosMascota AtributosMascotaPropia
        {
            get { return atributosMascotaPropia; }
            set { atributosMascotaPropia = value; }
        }
        #endregion
        #region Atributos Mascota Remota
        private AtributosMascota atributosMascotaRemota;
        /// <summary>
        /// Atributos de la mascota del oponente.
        /// </summary>
        public AtributosMascota AtributosMascotaRemota
        {
            get { return atributosMascotaRemota; }
            set { atributosMascotaRemota = value; }
        }
        #endregion

        #region Mascota
        private Mascota mascota;
        /// <summary>
        /// Mascota del jugador.
        /// </summary>
        public Mascota Mascota
        {
            get { return mascota; }
            set { mascota = value; }
        }
        #endregion

        #region Comunicador
        private IComunicaciones comunicador;
        /// <summary>
        /// Comunicador usado durante la batalla.
        /// </summary>
        public IComunicaciones Comunicador
        {
            get { return comunicador; }
            set { comunicador = value; }
        }
        #endregion


        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ControladorBatalla()
        {
            estado = _RECIBIRENVIARDATOS;
            mascota = null;
            comunicador = null;
            atributosMascotaPropia = new AtributosMascota();
            atributosMascotaRemota = new AtributosMascota();
            inicioHiloLectura = new ThreadStart(leer);
            hiloLectura = new Thread(inicioHiloLectura);
        }
        #endregion

        #region Inicializar
        /// <summary>
        /// Inicializa el controlador con la mascota y el comunicador que se usarán.
        /// </summary>
        /// <param name="mascota">Mascota del jugador.</param>
        /// <param name="comunicador">Comunicador que se usará.</param>
        /// <returns>Devuelve true si el comunicador está actuando como Servidor y false en caso contrario.</returns>
        public bool Inicializar(Mascota mascota, Comunicaciones.IComunicaciones comunicador)
        {
            this.mascota = mascota;
            this.comunicador = comunicador;
            this.hiloLectura.Start();

            this.atributosMascotaPropia.Destreza = mascota.Destreza;
            this.atributosMascotaPropia.Fuerza = mascota.Fuerza;
            this.atributosMascotaPropia.Inteligencia = mascota.Inteligencia;
            this.atributosMascotaPropia.Nivel = mascota.Nivel;
            this.atributosMascotaPropia.PuntosVida = mascota.PuntosVida;
            this.atributosMascotaPropia.Resistencia = mascota.Resistencia;
            aleatorio = new Random(mascota.Destreza * 30);

            return this.comunicador.Servidor;
        }
        #endregion


        #region Serializar atributos mascota
        /// <summary>
        /// Serializa los atributos de la mascota.
        /// </summary>
        /// <param name="mascota">Mascota que queremos serializar.</param>
        /// <returns>Cadena con los atributos serializados</returns>
        private string serializarAtributosMascota(AtributosMascota mascota)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AtributosMascota));
            System.IO.StreamWriter writer = new System.IO.StreamWriter(new MascotaVirtual.Utilidades.DirectorioRaiz().Directorio + "archivos\\atributosPropia.xml");
            serializer.Serialize(writer, mascota);
            writer.Close();

            System.IO.StreamReader reader = new StreamReader(new MascotaVirtual.Utilidades.DirectorioRaiz().Directorio + "archivos\\atributosPropia.xml");
            string linea = reader.ReadLine();
            reader.Close();
            return linea;
        }
        #endregion

        #region Deserializar atributos mascota
        /// <summary>
        /// Deserializa los atributos de la mascota.
        /// </summary>
        /// <param name="mascota">The mascota.</param>
        /// <param name="remota">Si vale true, deserializa la mascota remota, en caso contrario la propia.</param>
        private void deserializarAtributosMascota(string mascota, bool remota)
        {
            System.IO.StreamWriter writer = new StreamWriter(new MascotaVirtual.Utilidades.DirectorioRaiz().Directorio + "archivos\\datosMascota.xml");
            writer.Write(mascota);
            writer.Close();

            XmlSerializer serializer = new XmlSerializer(typeof(AtributosMascota));
            System.IO.StreamReader lector = new System.IO.StreamReader(new DirectorioRaiz().Directorio + "archivos\\datosMascota.xml");

            if (remota)
            {
                atributosMascotaRemota = (AtributosMascota)serializer.Deserialize(lector);
            }
            else
            {
                atributosMascotaPropia = (AtributosMascota)serializer.Deserialize(lector);
            }
            lector.Close();
        }
        #endregion


        #region Escribir
        /// <summary>
        /// Escribe el mensaje especificado.
        /// </summary>
        /// <param name="mensaje">El mensaje.</param>
        private void Escribir(string mensaje)
        {
            byte[] palabra = new byte[mensaje.Length];
            for (int i = 0; i < mensaje.Length; i++)
            {
                if (mensaje[i] != '\0')
                {
                    palabra[i] = (byte)mensaje[i];
                }
            }
            Stream remotoStream = comunicador.GetStream();
            try
            {
                remotoStream.Write(palabra, 0, palabra.Length);
            }
            catch
            {
                if (OnErrorComunicaciones != null)
                {
                    OnErrorComunicaciones(this, new EventArgs());
                }
            }
        }
        #endregion

        #region Leer
        /// <summary>
        /// Lee del dispositivo remoto.
        /// </summary>
        private void leer()
        {
            Stream remotoStream = comunicador.GetStream();
            byte[] palabra = new byte[15000];
            try
            {
                remotoStream.Read(palabra, 0, 15000);

                string mensaje = "";
                for (int i = 0; i < palabra.Length; i++)
                {
                    if ((char)palabra[i] != '\0')
                    {
                        mensaje += (char)palabra[i];
                    }
                }
                deserializarAtributosMascota(mensaje, true);
                postLeerDatosMascota();
            }
            catch
            {
                if (OnErrorComunicaciones != null)
                {
                    OnErrorComunicaciones(this, new EventArgs());
                }
            }
        }
        #endregion

        #region Después de Leer datos mascota
        private void postLeerDatosMascota()
        {
            if (estado == _RECIBIRENVIARDATOS)
            {
                estado = _ENVIARDATOS;
            }
            if (estado == _RECIBIRDATOS)
            {
                if (OnAtributosCargados != null)
                {
                    OnAtributosCargados(this, new EventArgs());
                }
                if (comunicador.Servidor)
                {
                    estado = _ESPERARENVIARGOLPE;
                }
                if (!comunicador.Servidor)
                {
                    estado = _RECIBIRGOLPE;
                }
            }

            if (comunicador.Servidor)
            {
                leerGolpesServidor();
            }
            if (!comunicador.Servidor)
            {
                leerGolpesCliente();
            }
        }
        #endregion


        #region Leer Golpes Cliente
        /// <summary>
        /// Lee los golpes de la batalla si es el cliente.
        /// </summary>
        private void leerGolpesCliente()
        {
            Stream remotoStream = comunicador.GetStream();
            byte[] palabra = new byte[15000];
            try
            {
                remotoStream.Read(palabra, 0, 15000);

                string mensaje = "";
                for (int i = 0; i < palabra.Length; i++)
                {
                    if ((char)palabra[i] != '\0')
                    {
                        mensaje += (char)palabra[i];
                    }
                }
                if (estado == _ESPERARRECIBIRGOLPE)
                {
                    deserializarAtributosMascota(mensaje, false);
                    if (atributosMascotaPropia.PuntosVida == 0)
                    {
                        if (OnCombatePerdido != null)
                        {
                            OnCombatePerdido(this, new EventArgs());
                        }
                    }
                    estado = _ENVIARGOLPE;
                    if (OnAccionRemotaRecibida != null)
                    {
                        OnAccionRemotaRecibida(this, new EventArgs());
                    }
                    if (OnAtributosCargados != null)
                    {
                        OnAtributosCargados(this, new EventArgs());
                    }
                    leerGolpesCliente();
                }
                if (estado == _ESPERARENVIARGOLPE)
                {
                    deserializarAtributosMascota(mensaje, true);
                    if (atributosMascotaRemota.PuntosVida == 0)
                    {
                        int subir = aleatorio.Next(1, 5);
                        switch (subir)
                        {
                            case 1:
                                {
                                    mascota.Destreza++;
                                    mascota.Nivel++;
                                    break;
                                }
                            case 2:
                                {
                                    mascota.Fuerza++;
                                    mascota.Nivel++;
                                    break;
                                }
                            case 3:
                                {
                                    mascota.Nivel++;
                                    mascota.Resistencia++;
                                    break;
                                }
                            case 4:
                                {
                                    mascota.Nivel++;
                                    mascota.Inteligencia++;
                                    break;
                                }
                        }
                        if (OnCombateGanado != null)
                        {
                            OnCombateGanado(this, new EventArgs());
                        }
                    }
                    estado = _RECIBIRGOLPE;
                    if (OnAccionRemotaRecibida != null)
                    {
                        OnAccionRemotaRecibida(this, new EventArgs());
                    }
                    if (OnAtributosCargados != null)
                    {
                        OnAtributosCargados(this, new EventArgs());
                    }
                    leerGolpesCliente();
                }
            }
            catch
            {
                if (OnErrorComunicaciones != null)
                {
                    OnErrorComunicaciones(this, new EventArgs());
                }
            }
        }
        #endregion

        #region Leer Golpes Servidor
        /// <summary>
        /// Lee los golpes de la batalla si es el servidor.
        /// </summary>
        private void leerGolpesServidor()
        {
            Stream remotoStream = comunicador.GetStream();
            byte[] palabra = new byte[15000];
            try
            {
                remotoStream.Read(palabra, 0, 15000);

                string mensaje = "";
                for (int i = 0; i < palabra.Length; i++)
                {
                    if ((char)palabra[i] != '\0')
                    {
                        mensaje += (char)palabra[i];
                    }
                }
                switch (mensaje)
                {
                    case ("/-#Alto#-/"):
                        {
                            accionRemota = "Alto";
                            break;
                        }
                    case ("/-#Medio#-/"):
                        {
                            accionRemota = "Medio";
                            break;
                        }
                    case ("/-#Bajo#-/"):
                        {
                            accionRemota = "Bajo";
                            break;
                        }
                }
                if (OnAccionRemotaRecibida != null)
                {
                    OnAccionRemotaRecibida(this, new EventArgs());
                }
                if (estado == _ESPERARENVIARGOLPE)
                {
                    estado = _ENVIARGOLPE;
                }
                if (estado == _ESPERARRECIBIRGOLPE)
                {
                    estado = _RECIBIRGOLPE;
                }
                leerGolpesServidor();
            }
            catch
            {
                if (OnErrorComunicaciones != null)
                {
                    OnErrorComunicaciones(this, new EventArgs());
                }
            }
        }
        #endregion


        #region Enviar atributos de la mascota
        /// <summary>
        /// Envía los atributos de la mascota al dispositivo remoto.
        /// </summary>
        public void EnviarMascota()
        {
            string mascotaSerializada = serializarAtributosMascota(atributosMascotaPropia);
            Escribir(mascotaSerializada);
            if (estado == _RECIBIRENVIARDATOS)
            {
                estado = _RECIBIRDATOS;
            }
            if (estado == _ENVIARDATOS)
            {
                if (comunicador.Servidor)
                {
                    estado = _ESPERARENVIARGOLPE;
                }
                if (!comunicador.Servidor)
                {
                    estado = _RECIBIRGOLPE;
                }
                if (OnAtributosCargados != null)
                {
                    OnAtributosCargados(this, new EventArgs());
                }
            }
        }
        #endregion

        #region Ejecutar Acción
        /// <summary>
        /// Guarda la acción seleccionada como propia.
        /// </summary>
        /// <param name="accion">Acción seleccionada.</param>
        public void ejecutarAccion(string accion)
        {
            if (OnAccionPropiaRecibida != null)
            {
                OnAccionPropiaRecibida(this, new EventArgs());
            }
            if ((estado == _ENVIARGOLPE) || (estado == _RECIBIRGOLPE))
            {
                if (!comunicador.Servidor)
                {
                    Escribir("/-#" + accion + "#-/");
                    if (estado == _ENVIARGOLPE)
                    {
                        estado = _ESPERARENVIARGOLPE;
                    }
                    else
                    {
                        estado = _ESPERARRECIBIRGOLPE;
                    }
                }
                else
                {
                    accionPropia = accion;
                    calcularGolpe();
                    if (OnAtributosCargados != null)
                    {
                        OnAtributosCargados(this, new EventArgs());
                    }
                }
            }
            else
            {
                if (OnErrorComunicaciones != null)
                {
                    OnErrorComunicaciones(this, new EventArgs());
                }
            }
        }
        #endregion


        #region Calcular golpe
        private void calcularGolpe()
        {
            if (estado == _ENVIARGOLPE)
            {
                if (accionPropia.CompareTo(accionRemota) == 0)
                {
                    AtributosMascotaRemota.PuntosVida = AtributosMascotaRemota.PuntosVida - (atributosMascotaPropia.Fuerza * 100 - atributosMascotaRemota.Resistencia * 50);
                    if (AtributosMascotaRemota.PuntosVida <= 0)
                    {
                        AtributosMascotaRemota.PuntosVida = 0;

                        int subir=aleatorio.Next(1, 5);
                        switch (subir)
                        {
                            case 1:
                                {
                                    mascota.Destreza++;
                                    mascota.Nivel++;
                                    break;
                                }
                            case 2:
                                {
                                    mascota.Fuerza++;
                                    mascota.Nivel++;
                                    break;
                                }
                            case 3:
                                {
                                    mascota.Nivel++;
                                    mascota.Resistencia++;
                                    break;
                                }
                            case 4:
                                {
                                    mascota.Nivel++;
                                    mascota.Inteligencia++;
                                    break;
                                }
                        }

                        if (OnCombateGanado != null)
                        {
                            OnCombateGanado(this, new EventArgs());
                        }
                    }
                }
                Escribir(serializarAtributosMascota(atributosMascotaRemota));
                estado = _ESPERARRECIBIRGOLPE;
            }
            else
            {
                if (accionPropia.CompareTo(accionRemota) == 0)
                {
                    AtributosMascotaPropia.PuntosVida = AtributosMascotaPropia.PuntosVida - (atributosMascotaRemota.Fuerza * 100 - atributosMascotaPropia.Resistencia);
                    if (atributosMascotaPropia.PuntosVida <= 0)
                    {
                        atributosMascotaPropia.PuntosVida = 0;
                        if (OnCombatePerdido != null)
                        {
                            OnCombatePerdido(this, new EventArgs());
                        }
                    }
                }
                Escribir(serializarAtributosMascota(atributosMascotaPropia));
                estado = _ESPERARENVIARGOLPE;
            }
        }
        #endregion


        #region Salir
        /// <summary>
        /// Cierra las comunicaciones.
        /// </summary>
        public void Salir()
        {
            hiloLectura.Abort();
            comunicador.Parar();
        }
        #endregion
    }
}
