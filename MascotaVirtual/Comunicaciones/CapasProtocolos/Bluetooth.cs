using System;
using System.Collections.Generic;
using System.Text;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using InTheHand.Net;
using System.Collections;
using System.Threading;
using System.Windows.Forms;

namespace MascotaVirtual.Comunicaciones
{
    /// <summary>
    /// Capa de acceso al Bluetooth.
    /// </summary>
    public class Bluetooth : IComunicaciones
    {
        private int seleccionado;
        private string nombreRemoto;
        private BluetoothClient clienteBT;
        private BluetoothListener escuchaBT;
        private BluetoothEndPoint extremoBT;
        private BluetoothDeviceInfo[] informacionBT;

        #region Evento Alguien Conectado
        /// <summary>
        /// Evento cuando alguien se conecta a nosotros.
        /// </summary>
        public override event AlguienConectado OnAlguienConectado;
        #endregion
        #region Evento cuando nos conectamos a Alguien
        /// <summary>
        /// Evento cuando nos conectamos a otro dispositivo.
        /// </summary>
        public override event ConectadoAAlguien OnConectadoAAlguien;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la capa de uso del Bluetooth.
        /// </summary>
        public Bluetooth()
        {
            seleccionado = 0;
        }
        #endregion

        #region Buscar
        /// <summary>
        /// Busca dispositivos haciendo uso del Bluetooth.
        /// </summary>
        /// <returns>ArrayList con los dispositivos encontrados</returns>
        public override ArrayList BuscarDispositivos()
        {
            clienteBT = new BluetoothClient();
            ArrayList listaDispositivos = new ArrayList();
            this.informacionBT = this.clienteBT.DiscoverDevices(3);
            for (int i = 0; i < informacionBT.Length; i++)
            {
                listaDispositivos.Add(informacionBT[i].DeviceName);
            }
            return listaDispositivos;
        }
        #endregion

        #region Servir
        /// <summary>
        /// Comienza a servir en un hilo distinto
        /// </summary>
        public override void SirveConHilo()
        {
            ThreadStart inicioHilo = new ThreadStart(Servir);
            Thread hilo = new Thread(inicioHilo);
            hilo.Start();
        }
        /// <summary>
        /// Comienza el proceso de servir
        /// </summary>
        public override void Servir()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                clienteBT = new BluetoothClient();
                extremoBT = new BluetoothEndPoint(informacionBT[seleccionado].DeviceAddress, new Guid("Dame una Vida"));
                escuchaBT = new BluetoothListener(extremoBT);
                escuchaBT.Start();
                clienteBT = escuchaBT.AcceptBluetoothClient();
                Cursor.Current = Cursors.Default;
                this.nombreRemoto = clienteBT.GetRemoteMachineName(informacionBT[seleccionado].DeviceAddress);
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
        /// Detiene la conexión con el dispositivo remoto.
        /// </summary>
        public override void Parar()
        {
            if (clienteBT != null)
            {
                clienteBT.Close();
            }
        }
        #endregion

        #region Conectar
        /// <summary>
        /// Se conecta al dispositivo seleccionado de la lista devuelta por "BuscarDispositivos".
        /// </summary>
        public override void Conectar()
        {
            extremoBT = new BluetoothEndPoint(this.informacionBT[seleccionado].DeviceAddress, new Guid("Dame una Vida"));
            this.clienteBT.Connect(extremoBT);
            this.nombreRemoto = clienteBT.GetRemoteMachineName(this.informacionBT[seleccionado].DeviceAddress);
            if (OnConectadoAAlguien != null)
            {
                OnConectadoAAlguien(this, new EventArgs());
            }
        }
        #endregion

        #region Get Nombre Remoto
        /// <summary>
        /// Devuelve el nombre del dispositivo remoto.
        /// </summary>
        /// <returns>Cadena con el nombre del dispositivo remoto.</returns>
        public override string GetNombreRemoto()
        {
            return clienteBT.RemoteMachineName;
        }
        #endregion

        #region Get Stream
        /// <summary>
        /// Devuelve el Stream con el que nos comunicaremos con el dispositivo remoto.
        /// </summary>
        /// <returns>Stream de comunicación con el dispositivo remoto.</returns>
        public override System.IO.Stream GetStream()
        {
            return clienteBT.GetStream();
        }
        #endregion


        #region No utilizados en esta capa
        #region Get IP
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
