namespace MascotaVirtual.Comunicaciones
{
    /// <summary>
    /// Vista y controlador del chat que servirá también como selección de acciones una vez conectado
    /// </summary>
    partial class ChatSeleccion
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatSeleccion));
            this.pSeleccion = new System.Windows.Forms.Panel();
            this.bSalir = new System.Windows.Forms.Button();
            this.bCambio = new System.Windows.Forms.Button();
            this.bJugar = new System.Windows.Forms.Button();
            this.bEnviar = new System.Windows.Forms.Button();
            this.pChat = new System.Windows.Forms.Panel();
            this.lUsuarioLocal = new System.Windows.Forms.Label();
            this.lUsuarioRemoto = new System.Windows.Forms.Label();
            this.tBTextoPropio = new System.Windows.Forms.TextBox();
            this.tBMensajes = new System.Windows.Forms.TextBox();
            this.iPTeclado = new Microsoft.WindowsCE.Forms.InputPanel();
            this.menu = new System.Windows.Forms.MainMenu();
            this.pSeleccion.SuspendLayout();
            this.pChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // pSeleccion
            // 
            resources.ApplyResources(this.pSeleccion, "pSeleccion");
            this.pSeleccion.BackColor = System.Drawing.Color.DarkKhaki;
            this.pSeleccion.Controls.Add(this.bSalir);
            this.pSeleccion.Controls.Add(this.bCambio);
            this.pSeleccion.Controls.Add(this.bJugar);
            this.pSeleccion.Name = "pSeleccion";
            // 
            // bSalir
            // 
            resources.ApplyResources(this.bSalir, "bSalir");
            this.bSalir.BackColor = System.Drawing.Color.Green;
            this.bSalir.ForeColor = System.Drawing.Color.White;
            this.bSalir.Name = "bSalir";
            this.bSalir.Click += new System.EventHandler(this.bSalir_Click);
            // 
            // bCambio
            // 
            resources.ApplyResources(this.bCambio, "bCambio");
            this.bCambio.Name = "bCambio";
            this.bCambio.Click += new System.EventHandler(this.bCambio_Click);
            // 
            // bJugar
            // 
            resources.ApplyResources(this.bJugar, "bJugar");
            this.bJugar.Name = "bJugar";
            this.bJugar.Click += new System.EventHandler(this.bJugar_Click);
            // 
            // bEnviar
            // 
            resources.ApplyResources(this.bEnviar, "bEnviar");
            this.bEnviar.Name = "bEnviar";
            this.bEnviar.Click += new System.EventHandler(this.bEnviar_Click);
            // 
            // pChat
            // 
            resources.ApplyResources(this.pChat, "pChat");
            this.pChat.BackColor = System.Drawing.Color.PeachPuff;
            this.pChat.Controls.Add(this.lUsuarioLocal);
            this.pChat.Controls.Add(this.bEnviar);
            this.pChat.Controls.Add(this.lUsuarioRemoto);
            this.pChat.Controls.Add(this.tBTextoPropio);
            this.pChat.Controls.Add(this.tBMensajes);
            this.pChat.Name = "pChat";
            // 
            // lUsuarioLocal
            // 
            resources.ApplyResources(this.lUsuarioLocal, "lUsuarioLocal");
            this.lUsuarioLocal.Name = "lUsuarioLocal";
            // 
            // lUsuarioRemoto
            // 
            resources.ApplyResources(this.lUsuarioRemoto, "lUsuarioRemoto");
            this.lUsuarioRemoto.Name = "lUsuarioRemoto";
            // 
            // tBTextoPropio
            // 
            resources.ApplyResources(this.tBTextoPropio, "tBTextoPropio");
            this.tBTextoPropio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tBTextoPropio.Name = "tBTextoPropio";
            // 
            // tBMensajes
            // 
            resources.ApplyResources(this.tBMensajes, "tBMensajes");
            this.tBMensajes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tBMensajes.Name = "tBMensajes";
            this.tBMensajes.ReadOnly = true;
            // 
            // iPTeclado
            // 
            this.iPTeclado.Enabled = true;
            // 
            // ChatSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.Controls.Add(this.pChat);
            this.Controls.Add(this.pSeleccion);
            this.Menu = this.menu;
            this.MinimizeBox = false;
            this.Name = "ChatSeleccion";
            this.pSeleccion.ResumeLayout(false);
            this.pChat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSeleccion;
        private System.Windows.Forms.Button bCambio;
        private System.Windows.Forms.Button bJugar;
        private System.Windows.Forms.Button bSalir;
        private System.Windows.Forms.Panel pChat;
        private System.Windows.Forms.TextBox tBTextoPropio;
        private System.Windows.Forms.TextBox tBMensajes;
        private Microsoft.WindowsCE.Forms.InputPanel iPTeclado;
        private System.Windows.Forms.Button bEnviar;
        private System.Windows.Forms.Label lUsuarioLocal;
        private System.Windows.Forms.Label lUsuarioRemoto;
        private System.Windows.Forms.MainMenu menu;
    }
}