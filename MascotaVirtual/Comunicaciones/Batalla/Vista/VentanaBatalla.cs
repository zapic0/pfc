using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MascotaVirtual.VidaMascota.Modelo;

namespace MascotaVirtual.Comunicaciones.Batalla.Vista
{
    /// <summary>
    /// Ventana de batalla con conexión
    /// </summary>
    public partial class VentanaBatalla : Form
    {
        Batalla.Controlador.ControladorBatalla controladorBatalla;

        #region Delegado y Evento del cierre de la ventana
        /// <summary>
        /// Manejador del evento del cierre de la ventana
        /// </summary>
        /// <param name="source">Fuente del evento</param>
        /// <param name="e">Argumentos del evento</param>
        public delegate void ManejadorVentanaCerrada(object source, EventArgs e);
        /// <summary>
        /// Evento del cierre de la ventana
        /// </summary>
        public event ManejadorVentanaCerrada OnVentanaCerrada;
        #endregion

        #region Inicializar
        /// <summary>
        /// Inicializar la batalla.
        /// </summary>
        /// <param name="mascota">Mascota del jugador.</param>
        /// <param name="comunicador">Comunicador que se usará en la batalla.</param>
        public void Inicializar(Mascota mascota, Comunicaciones.IComunicaciones comunicador)
        {
            bool turno = this.controladorBatalla.Inicializar(mascota, comunicador);
            this.pBImagenMascota.Image = controladorBatalla.Mascota.GenerarImagenMascota(pBImagenMascota.Width, pBImagenMascota.Height, this.pActividad.BackColor);
            if (turno)
            {
                this.lAccion.Text = "TÚ PEGAS";
            }
            else
            {
                this.lAccion.Text = "TÚ ESQUIVAS";
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VentanaBatalla()
        {
            InitializeComponent();
            controladorBatalla = new MascotaVirtual.Comunicaciones.Batalla.Controlador.ControladorBatalla();
            controladorBatalla.OnErrorComunicaciones += new MascotaVirtual.Comunicaciones.Batalla.Controlador.ControladorBatalla.ManejadorErrorComunicaciones(errorComunicaciones);
            controladorBatalla.OnAtributosCargados += new MascotaVirtual.Comunicaciones.Batalla.Controlador.ControladorBatalla.ManejadorAtributosCargados(controladorBatalla_OnAtributosCargados);
            controladorBatalla.OnAccionPropiaRecibida += new MascotaVirtual.Comunicaciones.Batalla.Controlador.ControladorBatalla.ManejadorAccionPropiaRecibida(controladorBatalla_OnAccionPropiaRecibida);
            controladorBatalla.OnAccionRemotaRecibida += new MascotaVirtual.Comunicaciones.Batalla.Controlador.ControladorBatalla.ManejadorAccionRemotaRecibida(controladorBatalla_OnAccionRemotaRecibida);
            controladorBatalla.OnCombateGanado += new MascotaVirtual.Comunicaciones.Batalla.Controlador.ControladorBatalla.ManejadorCombateGanado(controladorBatalla_OnCombateGanado);
            controladorBatalla.OnCombatePerdido += new MascotaVirtual.Comunicaciones.Batalla.Controlador.ControladorBatalla.ManejadorCombatePerdido(controladorBatalla_OnCombatePerdido);
        }
        #endregion


        #region Combate Perdido
        void controladorBatalla_OnCombatePerdido(object source, EventArgs e)
        {
            mostrarCombatePerdido();
        }
        #endregion

        #region CombateGanado
        void controladorBatalla_OnCombateGanado(object source, EventArgs e)
        {
            mostrarCombateGanado();
        }
        #endregion

        #region Mostrar Combate Perdido
        /// <summary>
        /// Delegado de la muestra del combate perdido.
        /// </summary>
        delegate void delegadoMuestraCombatePerdido();
        /// <summary>
        /// Muestra el combate perdido.
        /// </summary>
        private void mostrarCombatePerdido()
        {
            if (bEnviar.InvokeRequired)
            {
                delegadoMuestraCombatePerdido d = new delegadoMuestraCombatePerdido(mostrarCombatePerdido);
                this.Invoke(d);
            }
            else
            {
                this.lAccion.Text = "Has Perdido";
                MessageBox.Show("Has perdido el combate");
                bAccion.Enabled = false;
                bEnviar.Enabled = false;
            }
        }
        #endregion

        #region Mostrar Combate Ganado
        /// <summary>
        /// Delegado de la muestra del combate ganado.
        /// </summary>
        delegate void delegadoMuestraCombateGanado();
        /// <summary>
        /// Muestra el combate ganado.
        /// </summary>
        private void mostrarCombateGanado()
        {
            if (bEnviar.InvokeRequired)
            {
                delegadoMuestraCombateGanado d = new delegadoMuestraCombateGanado(mostrarCombateGanado);
                this.Invoke(d);
            }
            else
            {
                this.lAccion.Text = "Has Ganado";
                MessageBox.Show("Has ganado el combate");
                bAccion.Enabled = false;
                bEnviar.Enabled = false;
            }
        }
        #endregion


        #region Controlador acción remota recibida
        /// <summary>
        /// Evento que se lanza cuando se recibe la acción remota.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void controladorBatalla_OnAccionRemotaRecibida(object source, EventArgs e)
        {
            mostrarAccionRemota();
        }
        #endregion

        #region Controlador acción propia recibida
        /// <summary>
        /// Evento que se lanza cuando ejecutamos nuestra propia acción.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void controladorBatalla_OnAccionPropiaRecibida(object source, EventArgs e)
        {
            mostrarAccionPropia();
        }
        #endregion

        #region Mostrar acción propia
        /// <summary>
        /// Delegado de mostrar la acción propia.
        /// </summary>
        delegate void delegadoMuestraAccionPropia();
        /// <summary>
        /// Muestra la acción principal.
        /// </summary>
        private void mostrarAccionPropia()
        {
            if (this.bAccion.InvokeRequired)
            {
                delegadoMuestraAccionPropia d = new delegadoMuestraAccionPropia(mostrarAccionPropia);
                this.Invoke(d);
            }
            else
            {
                if (controladorBatalla.Comunicador.Servidor)
                {
                    bAccion.Enabled = false;
                    sBEstado.Text = "Esperando acción remota";
                    if (controladorBatalla.Estado == 3)
                    {
                        lAccion.Text = "TÚ ESQUIVAS";
                    }
                    if (controladorBatalla.Estado == 4)
                    {
                        lAccion.Text = "TÚ PEGAS";
                    }
                }
                else
                {
                    bAccion.Enabled = false;
                    sBEstado.Text = "Esperando resultado golpes";
                    if (controladorBatalla.Estado == 3)
                    {
                        lAccion.Text = "TÚ PEGAS";
                    }
                    if (controladorBatalla.Estado == 4)
                    {
                        lAccion.Text = "TÚ ESQUIVAS";
                    }
                }
            }
        }
        #endregion

        #region Mostrar acción remota
        /// <summary>
        /// Delegado de mostrar la recepción de la acción remota.
        /// </summary>
        delegate void delegadoMuestraAccionRemota();
        /// <summary>
        /// Muestra la recepción de la acción remota.
        /// </summary>
        private void mostrarAccionRemota()
        {
            if (this.bAccion.InvokeRequired)
            {
                delegadoMuestraAccionRemota d = new delegadoMuestraAccionRemota(mostrarAccionRemota);
                this.Invoke(d);
            }
            else
            {
                if (controladorBatalla.Comunicador.Servidor)
                {
                    bAccion.Enabled = true;
                    sBEstado.Text = "Esperando acción propia";
                }
                else
                {
                    bAccion.Enabled = true;
                    sBEstado.Text = "Esperando enviar acción";
                    if (controladorBatalla.Estado == 4)
                    {
                        lAccion.Text = "TÚ ESQUIVAS";
                    }
                    if (controladorBatalla.Estado == 3)
                    {
                        lAccion.Text = "TÚ PEGAS";
                    }
                }
            }
        }
        #endregion

        #region Evento Atributos Recibidos
        /// <summary>
        /// Manejador del evento cuando se cargan todos los atributos.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        void controladorBatalla_OnAtributosCargados(object source, EventArgs e)
        {
            inicializarAtributos();
        }
        #endregion

        #region Inicialización de los atributos de las mascotas
        /// <summary>
        /// Delegado inicialización atributos.
        /// </summary>
        delegate void DelegadoInicializarAtributos();
        /// <summary>
        /// Inicializa los atributos de la mascota remota y de la propia.
        /// </summary>
        private void inicializarAtributos()
        {
            if (this.vDestreza.InvokeRequired)
            {
                DelegadoInicializarAtributos d = new DelegadoInicializarAtributos(inicializarAtributos);
                this.Invoke(d);
            }
            else
            {
                this.vDestreza.Text = controladorBatalla.AtributosMascotaRemota.Destreza.ToString();
                this.vFuerza.Text = controladorBatalla.AtributosMascotaRemota.Fuerza.ToString();
                this.vInteligencia.Text = controladorBatalla.AtributosMascotaRemota.Inteligencia.ToString();
                this.vNivel.Text = controladorBatalla.AtributosMascotaRemota.Nivel.ToString();
                this.vResistencia.Text = controladorBatalla.AtributosMascotaRemota.Resistencia.ToString();
                this.pBVida.Value = controladorBatalla.AtributosMascotaRemota.PuntosVida;

                this.vDestrezaPropia.Text = controladorBatalla.AtributosMascotaPropia.Destreza.ToString();
                this.vFuerzaPropia.Text = controladorBatalla.AtributosMascotaPropia.Fuerza.ToString();
                this.vInteligenciaPropia.Text = controladorBatalla.AtributosMascotaPropia.Inteligencia.ToString();
                this.vNivelPropio.Text = controladorBatalla.AtributosMascotaPropia.Nivel.ToString();
                this.vResistenciaPropia.Text = controladorBatalla.AtributosMascotaPropia.Resistencia.ToString();
                this.pBVidaPropia.Value = controladorBatalla.AtributosMascotaPropia.PuntosVida;

                this.sBEstado.Text = "Datos cargados, batalla en curso.";
                if (!controladorBatalla.Comunicador.Servidor)
                {
                    this.bAccion.Enabled = true;
                }
            }
        }
        #endregion

        #region Error en las comunicaciones
        /// <summary>
        /// Delegado del error en comunicaciones
        /// </summary>
        delegate void DelegadoErrorComunicaciones();
        /// <summary>
        /// Manejador del evento cuando se produce un error en las comunicaciones.
        /// </summary>
        /// <param name="source">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void errorComunicaciones(object source, EventArgs e)
        {
            mostrarError();
        }
        /// <summary>
        /// Muestra el error en la barra de estado
        /// </summary>
        private void mostrarError()
        {
            if (this.sBEstado.InvokeRequired)
            {
                DelegadoErrorComunicaciones d = new DelegadoErrorComunicaciones(mostrarError);
                this.Invoke(d);
            }
            else
            {
                this.sBEstado.Text = "Error en la conexión.";
            }
        }
        #endregion

        #region Salir
        /// <summary>
        /// Click en salir. Cierra la ventana.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bSalir_Click(object sender, EventArgs e)
        {
            this.controladorBatalla.Salir();
            if (OnVentanaCerrada != null)
            {
                OnVentanaCerrada(this, new EventArgs());
            }
        }
        #endregion

        #region Enviar la mascota
        /// <summary>
        /// Envía los datos de la mascota cuando se pulsa el botón enviar.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bEnviar_Click(object sender, EventArgs e)
        {
            bEnviar.Enabled = false;
            controladorBatalla.EnviarMascota();
        }
        #endregion

        #region Click en el botón acción
        /// <summary>
        /// Ejecuta la acción seleccionada.
        /// </summary>
        /// <param name="sender">Fuente del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void bAccion_Click(object sender, EventArgs e)
        {
            if(rBAlto.Checked)
            {
                controladorBatalla.ejecutarAccion(rBAlto.Text);
            }
            if (rBBajo.Checked)
            {
                controladorBatalla.ejecutarAccion(rBBajo.Text);
            }
            if (rBMedio.Checked)
            {
                controladorBatalla.ejecutarAccion(rBMedio.Text);
            }
        }
        #endregion
    }
}