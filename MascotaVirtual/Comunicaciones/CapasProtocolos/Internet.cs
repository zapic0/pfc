using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace MascotaVirtual.Comunicaciones
{
    /// <summary>
    /// Capa de acceso a Internet.
    /// </summary>
    public class Internet : IComunicaciones
    {
        private TcpClient clienteTCP;
        private TcpListener escuchaTCP;
        private string IPRemota;
        private string nombreRemoto;

        #region Evento alguien se nos conecta
        /// <summary>
        /// Evento cuando alguien se nos conecta.
        /// </summary>
        public override event AlguienConectado OnAlguienConectado;
        #endregion
        #region Evento cuando nos conectamos a alguien
        /// <summary>
        /// Eventos cuando nos conectamos a alguien
        /// </summary>
        public override event ConectadoAAlguien OnConectadoAAlguien;
        #endregion

        #region Buscar
        /// <summary>
        /// En esta capa no tiene sentido
        /// </summary>
        /// <returns>ArrayList vacío</returns>
        public override ArrayList BuscarDispositivos()
        {
            return new ArrayList();
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public Internet()
        {
            this.clienteTCP = new TcpClient();
        }
        #endregion
        #region Servir
        /// <summary>
        /// Comienza a servir en un hilo diferente
        /// </summary>
        public override void SirveConHilo()
        {
            ThreadStart inicioHilo = new ThreadStart(Servir);
            Thread hilo = new Thread(inicioHilo);
            hilo.Start();
        }
        /// <summary>
        /// Da comienzo a un servicio de comunicaciones como Servidor.
        /// </summary>
        public override void Servir()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IPAddress direccionIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
                
                escuchaTCP = new TcpListener(direccionIP, 1234);
                escuchaTCP.Start();
                clienteTCP = escuchaTCP.AcceptTcpClient();
                escuchaTCP.Stop();
                Cursor.Current = Cursors.Default;
                this.nombreRemoto = "Remoto";
                if (OnAlguienConectado != null)
                {
                    OnAlguienConectado(this, new EventArgs());
                }
            }
            catch { }
        }
        #endregion
        #region Conectar
        /// <summary>
        /// Intenta conectarse a un servidor.
        /// </summary>
        public override void Conectar()
        {
            clienteTCP = new TcpClient(IPRemota, 1234);
            //clienteTCP.Connect(IPAddress.Parse(IPRemota), 1234);
            NetworkStream remotoStream = clienteTCP.GetStream();
            this.nombreRemoto = IPRemota;
            if (OnConectadoAAlguien != null)
            {
                OnConectadoAAlguien(this, new EventArgs());
            }
        }
        #endregion
        #region Nombre Remoto
        /// <summary>
        /// Devuelve el nombre del dispositivo remoto al que estamos conectados.
        /// </summary>
        /// <returns>Cadena con el nombre</returns>
        public override string GetNombreRemoto()
        {
            return nombreRemoto;
        }
        #endregion
        #region GetStream
        /// <summary>
        /// Devuelve el Stream con el que nos comunicamos al dispositivo remoto
        /// </summary>
        /// <returns>El Stream</returns>
        public override Stream GetStream()
        {
            return this.clienteTCP.GetStream();
        }
        #endregion
        #region Parar
        /// <summary>
        /// Detiene la conexión.
        /// </summary>
        public override void Parar()
        {
            if (clienteTCP != null)
            {
                clienteTCP.Close();
                clienteTCP = new TcpClient();
                if (escuchaTCP != null)
                {
                    escuchaTCP.Stop();
                }
            }
        }
        #endregion

        #region Get IP
        /// <summary>
        /// Devuelve la IP.
        /// </summary>
        /// <returns>Cadena con la IP</returns>
        public override string GetIP()
        {
            IPAddress direccion = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            return direccion.ToString();
        }
        #endregion
        #region Set IP Remota
        /// <summary>
        /// Da valor a la IP del dispositivo remoto.
        /// </summary>
        /// <param name="IPRemota">La IP remota.</param>
        public override void SetIPRemota(string IPRemota)
        {
            this.IPRemota = IPRemota;
        }
        #endregion
    }
}
