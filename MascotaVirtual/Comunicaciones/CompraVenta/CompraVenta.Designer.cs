namespace MascotaVirtual.Comunicaciones
{
    /// <summary>
    /// Vista y Controlador del intercambio de objetos entre dos dispositivos
    /// </summary>
    partial class CompraVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompraVenta));
            this.tcInventarios = new System.Windows.Forms.TabControl();
            this.tPInventarioPropio = new System.Windows.Forms.TabPage();
            this.pInventario = new System.Windows.Forms.Panel();
            this.bSeleccionar = new System.Windows.Forms.Button();
            this.lTextoCapacidad = new System.Windows.Forms.Label();
            this.lCapacidad = new System.Windows.Forms.Label();
            this.lNombreSeleccionado = new System.Windows.Forms.Label();
            this.pBSeleccionado = new System.Windows.Forms.PictureBox();
            this.tInventario = new System.Windows.Forms.TabControl();
            this.tAlimentos = new System.Windows.Forms.TabPage();
            this.tCuraciones = new System.Windows.Forms.TabPage();
            this.tLimpiadores = new System.Windows.Forms.TabPage();
            this.tEducadores = new System.Windows.Forms.TabPage();
            this.tOtros = new System.Windows.Forms.TabPage();
            this.tPInventarioRemoto = new System.Windows.Forms.TabPage();
            this.pInventarioRemoto = new System.Windows.Forms.Panel();
            this.bSeleccionarRemoto = new System.Windows.Forms.Button();
            this.lCapacidadRemoto = new System.Windows.Forms.Label();
            this.lNCapacidadRemoto = new System.Windows.Forms.Label();
            this.lNombreSeleccionadoRemoto = new System.Windows.Forms.Label();
            this.pBSeleccionadoRemoto = new System.Windows.Forms.PictureBox();
            this.tcInventarioRemoto = new System.Windows.Forms.TabControl();
            this.tAlimentosRemoto = new System.Windows.Forms.TabPage();
            this.tCuracionesRemoto = new System.Windows.Forms.TabPage();
            this.tLimpiadoresRemoto = new System.Windows.Forms.TabPage();
            this.tEducadoresRemoto = new System.Windows.Forms.TabPage();
            this.tOtrosRemoto = new System.Windows.Forms.TabPage();
            this.pOpciones = new System.Windows.Forms.Panel();
            this.bSalir = new System.Windows.Forms.Button();
            this.bInventarios = new System.Windows.Forms.Button();
            this.bOferta = new System.Windows.Forms.Button();
            this.pOferta = new System.Windows.Forms.Panel();
            this.bEliminar = new System.Windows.Forms.Button();
            this.lCapacidadObservado = new System.Windows.Forms.Label();
            this.lNumeroObservado = new System.Windows.Forms.Label();
            this.lNombreObservado = new System.Windows.Forms.Label();
            this.pBObjetoObservado = new System.Windows.Forms.PictureBox();
            this.bRechazar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bOfertar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lObjetosPropios = new System.Windows.Forms.Label();
            this.pObjetosRemotos = new System.Windows.Forms.Panel();
            this.pObjetosPropios = new System.Windows.Forms.Panel();
            this.tcInventarios.SuspendLayout();
            this.tPInventarioPropio.SuspendLayout();
            this.pInventario.SuspendLayout();
            this.tInventario.SuspendLayout();
            this.tPInventarioRemoto.SuspendLayout();
            this.pInventarioRemoto.SuspendLayout();
            this.tcInventarioRemoto.SuspendLayout();
            this.pOpciones.SuspendLayout();
            this.pOferta.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcInventarios
            // 
            resources.ApplyResources(this.tcInventarios, "tcInventarios");
            this.tcInventarios.Controls.Add(this.tPInventarioPropio);
            this.tcInventarios.Controls.Add(this.tPInventarioRemoto);
            this.tcInventarios.Name = "tcInventarios";
            this.tcInventarios.SelectedIndex = 0;
            // 
            // tPInventarioPropio
            // 
            resources.ApplyResources(this.tPInventarioPropio, "tPInventarioPropio");
            this.tPInventarioPropio.Controls.Add(this.pInventario);
            this.tPInventarioPropio.Name = "tPInventarioPropio";
            // 
            // pInventario
            // 
            resources.ApplyResources(this.pInventario, "pInventario");
            this.pInventario.BackColor = System.Drawing.Color.LightYellow;
            this.pInventario.Controls.Add(this.bSeleccionar);
            this.pInventario.Controls.Add(this.lTextoCapacidad);
            this.pInventario.Controls.Add(this.lCapacidad);
            this.pInventario.Controls.Add(this.lNombreSeleccionado);
            this.pInventario.Controls.Add(this.pBSeleccionado);
            this.pInventario.Controls.Add(this.tInventario);
            this.pInventario.Name = "pInventario";
            // 
            // bSeleccionar
            // 
            resources.ApplyResources(this.bSeleccionar, "bSeleccionar");
            this.bSeleccionar.Name = "bSeleccionar";
            this.bSeleccionar.Click += new System.EventHandler(this.bSeleccionar_Click);
            // 
            // lTextoCapacidad
            // 
            resources.ApplyResources(this.lTextoCapacidad, "lTextoCapacidad");
            this.lTextoCapacidad.Name = "lTextoCapacidad";
            // 
            // lCapacidad
            // 
            resources.ApplyResources(this.lCapacidad, "lCapacidad");
            this.lCapacidad.Name = "lCapacidad";
            // 
            // lNombreSeleccionado
            // 
            resources.ApplyResources(this.lNombreSeleccionado, "lNombreSeleccionado");
            this.lNombreSeleccionado.Name = "lNombreSeleccionado";
            // 
            // pBSeleccionado
            // 
            resources.ApplyResources(this.pBSeleccionado, "pBSeleccionado");
            this.pBSeleccionado.Name = "pBSeleccionado";
            // 
            // tInventario
            // 
            resources.ApplyResources(this.tInventario, "tInventario");
            this.tInventario.Controls.Add(this.tAlimentos);
            this.tInventario.Controls.Add(this.tCuraciones);
            this.tInventario.Controls.Add(this.tLimpiadores);
            this.tInventario.Controls.Add(this.tEducadores);
            this.tInventario.Controls.Add(this.tOtros);
            this.tInventario.Name = "tInventario";
            this.tInventario.SelectedIndex = 0;
            // 
            // tAlimentos
            // 
            resources.ApplyResources(this.tAlimentos, "tAlimentos");
            this.tAlimentos.BackColor = System.Drawing.Color.PeachPuff;
            this.tAlimentos.Name = "tAlimentos";
            // 
            // tCuraciones
            // 
            resources.ApplyResources(this.tCuraciones, "tCuraciones");
            this.tCuraciones.BackColor = System.Drawing.Color.PeachPuff;
            this.tCuraciones.Name = "tCuraciones";
            // 
            // tLimpiadores
            // 
            resources.ApplyResources(this.tLimpiadores, "tLimpiadores");
            this.tLimpiadores.BackColor = System.Drawing.Color.PeachPuff;
            this.tLimpiadores.Name = "tLimpiadores";
            // 
            // tEducadores
            // 
            resources.ApplyResources(this.tEducadores, "tEducadores");
            this.tEducadores.BackColor = System.Drawing.Color.PeachPuff;
            this.tEducadores.Name = "tEducadores";
            // 
            // tOtros
            // 
            resources.ApplyResources(this.tOtros, "tOtros");
            this.tOtros.BackColor = System.Drawing.Color.PeachPuff;
            this.tOtros.Name = "tOtros";
            // 
            // tPInventarioRemoto
            // 
            resources.ApplyResources(this.tPInventarioRemoto, "tPInventarioRemoto");
            this.tPInventarioRemoto.Controls.Add(this.pInventarioRemoto);
            this.tPInventarioRemoto.Name = "tPInventarioRemoto";
            this.tPInventarioRemoto.Click += new System.EventHandler(this.tPInventarioRemoto_GotFocus);
            this.tPInventarioRemoto.GotFocus += new System.EventHandler(this.tPInventarioRemoto_GotFocus);
            // 
            // pInventarioRemoto
            // 
            resources.ApplyResources(this.pInventarioRemoto, "pInventarioRemoto");
            this.pInventarioRemoto.BackColor = System.Drawing.Color.LightYellow;
            this.pInventarioRemoto.Controls.Add(this.bSeleccionarRemoto);
            this.pInventarioRemoto.Controls.Add(this.lCapacidadRemoto);
            this.pInventarioRemoto.Controls.Add(this.lNCapacidadRemoto);
            this.pInventarioRemoto.Controls.Add(this.lNombreSeleccionadoRemoto);
            this.pInventarioRemoto.Controls.Add(this.pBSeleccionadoRemoto);
            this.pInventarioRemoto.Controls.Add(this.tcInventarioRemoto);
            this.pInventarioRemoto.Name = "pInventarioRemoto";
            this.pInventarioRemoto.Click += new System.EventHandler(this.tPInventarioRemoto_GotFocus);
            this.pInventarioRemoto.GotFocus += new System.EventHandler(this.tPInventarioRemoto_GotFocus);
            // 
            // bSeleccionarRemoto
            // 
            resources.ApplyResources(this.bSeleccionarRemoto, "bSeleccionarRemoto");
            this.bSeleccionarRemoto.Name = "bSeleccionarRemoto";
            this.bSeleccionarRemoto.Click += new System.EventHandler(this.bSeleccionarRemoto_Click);
            // 
            // lCapacidadRemoto
            // 
            resources.ApplyResources(this.lCapacidadRemoto, "lCapacidadRemoto");
            this.lCapacidadRemoto.Name = "lCapacidadRemoto";
            // 
            // lNCapacidadRemoto
            // 
            resources.ApplyResources(this.lNCapacidadRemoto, "lNCapacidadRemoto");
            this.lNCapacidadRemoto.Name = "lNCapacidadRemoto";
            // 
            // lNombreSeleccionadoRemoto
            // 
            resources.ApplyResources(this.lNombreSeleccionadoRemoto, "lNombreSeleccionadoRemoto");
            this.lNombreSeleccionadoRemoto.Name = "lNombreSeleccionadoRemoto";
            // 
            // pBSeleccionadoRemoto
            // 
            resources.ApplyResources(this.pBSeleccionadoRemoto, "pBSeleccionadoRemoto");
            this.pBSeleccionadoRemoto.Name = "pBSeleccionadoRemoto";
            // 
            // tcInventarioRemoto
            // 
            resources.ApplyResources(this.tcInventarioRemoto, "tcInventarioRemoto");
            this.tcInventarioRemoto.Controls.Add(this.tAlimentosRemoto);
            this.tcInventarioRemoto.Controls.Add(this.tCuracionesRemoto);
            this.tcInventarioRemoto.Controls.Add(this.tLimpiadoresRemoto);
            this.tcInventarioRemoto.Controls.Add(this.tEducadoresRemoto);
            this.tcInventarioRemoto.Controls.Add(this.tOtrosRemoto);
            this.tcInventarioRemoto.Name = "tcInventarioRemoto";
            this.tcInventarioRemoto.SelectedIndex = 0;
            this.tcInventarioRemoto.GotFocus += new System.EventHandler(this.tPInventarioRemoto_GotFocus);
            // 
            // tAlimentosRemoto
            // 
            resources.ApplyResources(this.tAlimentosRemoto, "tAlimentosRemoto");
            this.tAlimentosRemoto.BackColor = System.Drawing.Color.PeachPuff;
            this.tAlimentosRemoto.Name = "tAlimentosRemoto";
            this.tAlimentosRemoto.Click += new System.EventHandler(this.tPInventarioRemoto_GotFocus);
            this.tAlimentosRemoto.GotFocus += new System.EventHandler(this.tPInventarioRemoto_GotFocus);
            // 
            // tCuracionesRemoto
            // 
            resources.ApplyResources(this.tCuracionesRemoto, "tCuracionesRemoto");
            this.tCuracionesRemoto.BackColor = System.Drawing.Color.PeachPuff;
            this.tCuracionesRemoto.Name = "tCuracionesRemoto";
            // 
            // tLimpiadoresRemoto
            // 
            resources.ApplyResources(this.tLimpiadoresRemoto, "tLimpiadoresRemoto");
            this.tLimpiadoresRemoto.BackColor = System.Drawing.Color.PeachPuff;
            this.tLimpiadoresRemoto.Name = "tLimpiadoresRemoto";
            // 
            // tEducadoresRemoto
            // 
            resources.ApplyResources(this.tEducadoresRemoto, "tEducadoresRemoto");
            this.tEducadoresRemoto.BackColor = System.Drawing.Color.PeachPuff;
            this.tEducadoresRemoto.Name = "tEducadoresRemoto";
            // 
            // tOtrosRemoto
            // 
            resources.ApplyResources(this.tOtrosRemoto, "tOtrosRemoto");
            this.tOtrosRemoto.BackColor = System.Drawing.Color.PeachPuff;
            this.tOtrosRemoto.Name = "tOtrosRemoto";
            // 
            // pOpciones
            // 
            resources.ApplyResources(this.pOpciones, "pOpciones");
            this.pOpciones.BackColor = System.Drawing.Color.DarkKhaki;
            this.pOpciones.Controls.Add(this.bSalir);
            this.pOpciones.Controls.Add(this.bInventarios);
            this.pOpciones.Controls.Add(this.bOferta);
            this.pOpciones.Name = "pOpciones";
            // 
            // bSalir
            // 
            resources.ApplyResources(this.bSalir, "bSalir");
            this.bSalir.Name = "bSalir";
            this.bSalir.Click += new System.EventHandler(this.bSalir_Click);
            // 
            // bInventarios
            // 
            resources.ApplyResources(this.bInventarios, "bInventarios");
            this.bInventarios.Name = "bInventarios";
            this.bInventarios.Click += new System.EventHandler(this.bInventarios_Click);
            // 
            // bOferta
            // 
            resources.ApplyResources(this.bOferta, "bOferta");
            this.bOferta.Name = "bOferta";
            this.bOferta.Click += new System.EventHandler(this.bOferta_Click);
            // 
            // pOferta
            // 
            resources.ApplyResources(this.pOferta, "pOferta");
            this.pOferta.BackColor = System.Drawing.Color.PeachPuff;
            this.pOferta.Controls.Add(this.bEliminar);
            this.pOferta.Controls.Add(this.lCapacidadObservado);
            this.pOferta.Controls.Add(this.lNumeroObservado);
            this.pOferta.Controls.Add(this.lNombreObservado);
            this.pOferta.Controls.Add(this.pBObjetoObservado);
            this.pOferta.Controls.Add(this.bRechazar);
            this.pOferta.Controls.Add(this.bAceptar);
            this.pOferta.Controls.Add(this.bOfertar);
            this.pOferta.Controls.Add(this.label1);
            this.pOferta.Controls.Add(this.lObjetosPropios);
            this.pOferta.Controls.Add(this.pObjetosRemotos);
            this.pOferta.Controls.Add(this.pObjetosPropios);
            this.pOferta.Name = "pOferta";
            // 
            // bEliminar
            // 
            resources.ApplyResources(this.bEliminar, "bEliminar");
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // lCapacidadObservado
            // 
            resources.ApplyResources(this.lCapacidadObservado, "lCapacidadObservado");
            this.lCapacidadObservado.Name = "lCapacidadObservado";
            // 
            // lNumeroObservado
            // 
            resources.ApplyResources(this.lNumeroObservado, "lNumeroObservado");
            this.lNumeroObservado.Name = "lNumeroObservado";
            // 
            // lNombreObservado
            // 
            resources.ApplyResources(this.lNombreObservado, "lNombreObservado");
            this.lNombreObservado.Name = "lNombreObservado";
            // 
            // pBObjetoObservado
            // 
            resources.ApplyResources(this.pBObjetoObservado, "pBObjetoObservado");
            this.pBObjetoObservado.Name = "pBObjetoObservado";
            // 
            // bRechazar
            // 
            resources.ApplyResources(this.bRechazar, "bRechazar");
            this.bRechazar.Name = "bRechazar";
            this.bRechazar.Click += new System.EventHandler(this.bRechazar_Click);
            // 
            // bAceptar
            // 
            resources.ApplyResources(this.bAceptar, "bAceptar");
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bOfertar
            // 
            resources.ApplyResources(this.bOfertar, "bOfertar");
            this.bOfertar.Name = "bOfertar";
            this.bOfertar.Click += new System.EventHandler(this.bOfertar_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lObjetosPropios
            // 
            resources.ApplyResources(this.lObjetosPropios, "lObjetosPropios");
            this.lObjetosPropios.Name = "lObjetosPropios";
            // 
            // pObjetosRemotos
            // 
            resources.ApplyResources(this.pObjetosRemotos, "pObjetosRemotos");
            this.pObjetosRemotos.Name = "pObjetosRemotos";
            // 
            // pObjetosPropios
            // 
            resources.ApplyResources(this.pObjetosPropios, "pObjetosPropios");
            this.pObjetosPropios.Name = "pObjetosPropios";
            // 
            // CompraVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pOferta);
            this.Controls.Add(this.pOpciones);
            this.Controls.Add(this.tcInventarios);
            this.Name = "CompraVenta";
            this.tcInventarios.ResumeLayout(false);
            this.tPInventarioPropio.ResumeLayout(false);
            this.pInventario.ResumeLayout(false);
            this.tInventario.ResumeLayout(false);
            this.tPInventarioRemoto.ResumeLayout(false);
            this.pInventarioRemoto.ResumeLayout(false);
            this.tcInventarioRemoto.ResumeLayout(false);
            this.pOpciones.ResumeLayout(false);
            this.pOferta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcInventarios;
        private System.Windows.Forms.TabPage tPInventarioPropio;
        private System.Windows.Forms.Panel pInventario;
        private System.Windows.Forms.Button bSeleccionar;
        private System.Windows.Forms.Label lTextoCapacidad;
        private System.Windows.Forms.Label lCapacidad;
        private System.Windows.Forms.Label lNombreSeleccionado;
        private System.Windows.Forms.PictureBox pBSeleccionado;
        private System.Windows.Forms.TabControl tInventario;
        private System.Windows.Forms.TabPage tAlimentos;
        private System.Windows.Forms.TabPage tCuraciones;
        private System.Windows.Forms.TabPage tLimpiadores;
        private System.Windows.Forms.TabPage tEducadores;
        private System.Windows.Forms.TabPage tOtros;
        private System.Windows.Forms.TabPage tPInventarioRemoto;
        private System.Windows.Forms.Panel pInventarioRemoto;
        private System.Windows.Forms.Button bSeleccionarRemoto;
        private System.Windows.Forms.Label lCapacidadRemoto;
        private System.Windows.Forms.Label lNCapacidadRemoto;
        private System.Windows.Forms.Label lNombreSeleccionadoRemoto;
        private System.Windows.Forms.PictureBox pBSeleccionadoRemoto;
        private System.Windows.Forms.TabControl tcInventarioRemoto;
        private System.Windows.Forms.TabPage tAlimentosRemoto;
        private System.Windows.Forms.TabPage tCuracionesRemoto;
        private System.Windows.Forms.TabPage tLimpiadoresRemoto;
        private System.Windows.Forms.TabPage tEducadoresRemoto;
        private System.Windows.Forms.TabPage tOtrosRemoto;
        private System.Windows.Forms.Panel pOpciones;
        private System.Windows.Forms.Button bInventarios;
        private System.Windows.Forms.Button bOferta;
        private System.Windows.Forms.Panel pOferta;
        private System.Windows.Forms.Panel pObjetosRemotos;
        private System.Windows.Forms.Panel pObjetosPropios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lObjetosPropios;
        private System.Windows.Forms.Button bRechazar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bOfertar;
        private System.Windows.Forms.Label lCapacidadObservado;
        private System.Windows.Forms.Label lNumeroObservado;
        private System.Windows.Forms.Label lNombreObservado;
        private System.Windows.Forms.PictureBox pBObjetoObservado;
        private System.Windows.Forms.Button bSalir;
        private System.Windows.Forms.Button bEliminar;


    }
}