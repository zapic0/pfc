namespace MascotaVirtual.Minijuegos
{
    partial class Minijuegos
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
            this.pMenuRapido = new System.Windows.Forms.Panel();
            this.bSalir = new System.Windows.Forms.Button();
            this.pJuegos = new System.Windows.Forms.Panel();
            this.bPong = new System.Windows.Forms.Button();
            this.bPalomas = new System.Windows.Forms.Button();
            this.bCementerio = new System.Windows.Forms.Button();
            this.pMenuRapido.SuspendLayout();
            this.pJuegos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMenuRapido
            // 
            this.pMenuRapido.BackColor = System.Drawing.Color.DarkKhaki;
            this.pMenuRapido.Controls.Add(this.bSalir);
            this.pMenuRapido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pMenuRapido.Location = new System.Drawing.Point(0, 260);
            this.pMenuRapido.Name = "pMenuRapido";
            this.pMenuRapido.Size = new System.Drawing.Size(240, 34);
            // 
            // bSalir
            // 
            this.bSalir.Location = new System.Drawing.Point(31, 3);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(179, 27);
            this.bSalir.TabIndex = 0;
            this.bSalir.Text = "Salir";
            this.bSalir.Click += new System.EventHandler(this.bSalir_Click);
            // 
            // pJuegos
            // 
            this.pJuegos.BackColor = System.Drawing.Color.PeachPuff;
            this.pJuegos.Controls.Add(this.bPong);
            this.pJuegos.Controls.Add(this.bPalomas);
            this.pJuegos.Controls.Add(this.bCementerio);
            this.pJuegos.Location = new System.Drawing.Point(0, 3);
            this.pJuegos.Name = "pJuegos";
            this.pJuegos.Size = new System.Drawing.Size(240, 254);
            // 
            // bPong
            // 
            this.bPong.Location = new System.Drawing.Point(58, 181);
            this.bPong.Name = "bPong";
            this.bPong.Size = new System.Drawing.Size(125, 39);
            this.bPong.TabIndex = 2;
            this.bPong.Text = "Pong";
            this.bPong.Click += new System.EventHandler(this.bPong_Click);
            // 
            // bPalomas
            // 
            this.bPalomas.Location = new System.Drawing.Point(58, 107);
            this.bPalomas.Name = "bPalomas";
            this.bPalomas.Size = new System.Drawing.Size(125, 39);
            this.bPalomas.TabIndex = 1;
            this.bPalomas.Text = "Palomas";
            this.bPalomas.Click += new System.EventHandler(this.bPalomas_Click);
            // 
            // bCementerio
            // 
            this.bCementerio.Location = new System.Drawing.Point(58, 33);
            this.bCementerio.Name = "bCementerio";
            this.bCementerio.Size = new System.Drawing.Size(125, 39);
            this.bCementerio.TabIndex = 0;
            this.bCementerio.Text = "Cementerio";
            this.bCementerio.Click += new System.EventHandler(this.bCementerio_Click);
            // 
            // Minijuegos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.pJuegos);
            this.Controls.Add(this.pMenuRapido);
            this.Name = "Minijuegos";
            this.Text = "MVZ: Minijuegos";
            this.pMenuRapido.ResumeLayout(false);
            this.pJuegos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMenuRapido;
        private System.Windows.Forms.Button bSalir;
        private System.Windows.Forms.Panel pJuegos;
        private System.Windows.Forms.Button bPong;
        private System.Windows.Forms.Button bPalomas;
        private System.Windows.Forms.Button bCementerio;
    }
}