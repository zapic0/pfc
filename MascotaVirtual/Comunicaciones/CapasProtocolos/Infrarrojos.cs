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
    /// Capa de acceso a los Infrarrojos
    /// </summary>
    public class Infrarrojos : IComunicaciones
    {
        private IrDAClient clienteIR;
        private IrDAListener escuchaIR;
        private IrDAEndPoint extremoIR;
        private IrDADeviceInfo[] informacionIR;
        private int seleccionado;
        private string nombreRemoto;

        #region Evento cuando alguien se conecta
        /// <summary>
        /// Evento cuando alguen se nos conecta
        /// </summary>
        public override event AlguienConectado OnAlguienConectado;
        #endregion

        #region Evento cuando nos conectamos a alguien
        /// <summary>
        /// Evento cuando nos conectamos a alguien
        /// </summary>
        public override event ConectadoAAlguien OnConectadoAAlguien;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Infrarrojos()
        {
            seleccionado = 0;
        }
        #endregion

        #region Buscar
        /// <summary>
        /// Buscar Dispositivos.
        /// </summary>
        /// <returns>Array List con los dispositivos encontrados.</returns>
        public override ArrayList BuscarDispositivos()
        {
            clienteIR = new IrDAClient();
            ArrayList listaDispositivos = new ArrayList();
            this.informacionIR = this.clienteIR.DiscoverDevices(3);
            for (int i = 0; i < informacionIR.Length; i++)
            {
                listaDispositivos.Add(informacionIR[i].DeviceName);
            }
            return listaDispositivos;
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
                clienteIR = new IrDAClient();
                extremoIR = new IrDAEndPoint(informacionIR[seleccionado].DeviceID, "Dame una Vida");
                escuchaIR = new IrDAListener(extremoIR);
                escuchaIR.Start();
                clienteIR = escuchaIR.AcceptIrDAClient();
                Cursor.Current = Cursors.Default;
                this.nombreRemoto = clienteIR.RemoteMachineName;
                if (OnAlguienConectado != null)
                {
                    OnAlguienConectado(this, new EventArgs());
                }
            }
            catch { }
        }
        #endregion

        #region Parar
        /// <summary>
        /// Detiene la conexión.
        /// </summary>
        public override void Parar()
        {
            if (clienteIR != null)
            {
                clienteIR.Close();
                clienteIR = null;
                if (escuchaIR != null)
                {
                    escuchaIR.Stop();
                }
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region Conectar
        /// <summary>
        /// Intenta conectarse a un servidor.
        /// </summary>
        public override void Conectar()
        {
            extremoIR = new IrDAEndPoint(this.informacionIR[seleccionado].DeviceID, "Dame una Vida");
            this.clienteIR.Connect(extremoIR);
            this.nombreRemoto = clienteIR.RemoteMachineName;
            if (OnConectadoAAlguien != null)
            {
                OnConectadoAAlguien(this, new EventArgs());
            }
        }
        #endregion

        #region Get Nombre Remoto
        /// <summary>
        /// Devuelve el nombre del dispositivo remoto al que estamos conectados.
        /// </summary>
        /// <returns>Cadena con el nombre</returns>
        public override string GetNombreRemoto()
        {
            return this.nombreRemoto;
        }
        #endregion

        #region Get Stream
        /// <summary>
        /// Devuelve el Stream con el que nos comunicamos al dispositivo remoto
        /// </summary>
        /// <returns>El Stream</returns>
        public override Stream GetStream()
        {
            return clienteIR.GetStream();
        }
        #endregion

        #region No utilizados por esta capa
        #region GetIP
        /// <summary>
        /// Devuelve una cadena vacía en esta capa
        /// </summary>
        /// <returns>Cadena vacía ""</returns>
        public override string GetIP()
        {
            return "";
        }
        #endregion

        #region Set IP Remota
        /// <summary>
        /// No se utiliza en esta capa.
        /// </summary>
        /// <param name="IPRemota">Nada</param>
        public override void SetIPRemota(string IPRemota)
        {
        }
        #endregion
        #endregion
    }
}
