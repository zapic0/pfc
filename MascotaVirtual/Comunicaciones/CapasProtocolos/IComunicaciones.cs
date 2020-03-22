using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace MascotaVirtual.Comunicaciones
{
    /// <summary>
    /// Interface que implementan las capas de comunicaciones utilizadas (Infrarrojos, Bluetooth e Internet)
    /// </summary>
    public abstract class IComunicaciones
    {
        #region Propiedad Servidor
        private bool servidor;
        /// <summary>
        /// Devuelve si el comunicador está haciendo de servidor o no.
        /// </summary>
        public bool Servidor
        {
            get { return servidor; }
            set { servidor = value; }
        }
        #endregion
        #region Propiedad Seleccionado
        private int seleccionado;
        /// <summary>
        /// Devuelve el dispositivo seleccionado de la lista de dispositivos encontrados.
        /// </summary>
        public int Seleccionado
        {
            get { return seleccionado; }
            set { seleccionado = value; }
        }
        #endregion

        #region Buscar Dispositivos
        /// <summary>
        /// Busca Dispositivos y devuelve un arraylist con los mismos en caso de que sea necesario
        /// </summary>
        /// <returns>ArrayList con los Dispositivos</returns>
        public abstract ArrayList BuscarDispositivos();
        #endregion
        #region Servir
        /// <summary>
        /// Da comienzo a un servicio de comunicaciones como Servidor.
        /// </summary>
        public abstract void Servir();
        #endregion
        #region Conectar
        /// <summary>
        /// Intenta conectarse a un servidor.
        /// </summary>
        public abstract void Conectar();
        #endregion
        #region Servir con hilo
        /// <summary>
        /// Comienza a servir en un hilo diferente
        /// </summary>
        public abstract void SirveConHilo();
        #endregion
        #region Parar
        /// <summary>
        /// Detiene la conexión.
        /// </summary>
        public abstract void Parar();
        #endregion
        #region Get Nombre Remoto
        /// <summary>
        /// Devuelve el nombre del dispositivo remoto al que estamos conectados.
        /// </summary>
        /// <returns>Cadena con el nombre</returns>
        public abstract string GetNombreRemoto();
        #endregion
        #region Get Stream
        /// <summary>
        /// Devuelve el Stream con el que nos comunicamos al dispositivo remoto
        /// </summary>
        /// <returns>El Stream</returns>
        public abstract Stream GetStream();
        #endregion
        #region Get IP
        /// <summary>
        /// Devuelve la IP.
        /// </summary>
        /// <returns>Cadena con la IP</returns>
        public abstract string GetIP();
        #endregion
        #region Set IP Remota
        /// <summary>
        /// Da valor a la IP del dispositivo remoto.
        /// </summary>
        /// <param name="IPRemota">La IP remota.</param>
        public abstract void SetIPRemota(string IPRemota);
        #endregion

        #region Delegado y Evento cuando alguien se conecta
        /// <summary>
        /// Delegado cuando alguien se conecta
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Argumentos del evento</param>
        public delegate void AlguienConectado (object source, EventArgs e);
        /// <summary>
        /// Evento cuando alguien se conecta
        /// </summary>
        public abstract event AlguienConectado OnAlguienConectado;
        #endregion

        #region Delegado y Evento cuando te conectas a alguien
        /// <summary>
        /// Delegado cuando nos conectamos a alguien
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Argumentos del evento</param>
        public delegate void ConectadoAAlguien(object source, EventArgs e);
        /// <summary>
        /// Evento cuando nos conectamos a alguien
        /// </summary>
        public abstract event ConectadoAAlguien OnConectadoAAlguien;
        #endregion
    }
}
