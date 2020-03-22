namespace MascotaVirtual.Minijuegos.Puntuaciones
{
    /// <summary>
    /// Ventana que muestra las puntuaciones de un juego
    /// </summary>
    partial class VentanaPuntuaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bCerrar = new System.Windows.Forms.Button();
            this.l1 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.l3 = new System.Windows.Forms.Label();
            this.l4 = new System.Windows.Forms.Label();
            this.l5 = new System.Windows.Forms.Label();
            this.l6 = new System.Windows.Forms.Label();
            this.l7 = new System.Windows.Forms.Label();
            this.l8 = new System.Windows.Forms.Label();
            this.l9 = new System.Windows.Forms.Label();
            this.l10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.l10);
            this.panel1.Controls.Add(this.l9);
            this.panel1.Controls.Add(this.l8);
            this.panel1.Controls.Add(this.l7);
            this.panel1.Controls.Add(this.l6);
            this.panel1.Controls.Add(this.l5);
            this.panel1.Controls.Add(this.l4);
            this.panel1.Controls.Add(this.l3);
            this.panel1.Controls.Add(this.l2);
            this.panel1.Controls.Add(this.l1);
            this.panel1.Location = new System.Drawing.Point(26, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 241);
            // 
            // bCerrar
            // 
            this.bCerrar.Location = new System.Drawing.Point(85, 247);
            this.bCerrar.Name = "bCerrar";
            this.bCerrar.Size = new System.Drawing.Size(72, 20);
            this.bCerrar.TabIndex = 1;
            this.bCerrar.Text = "Cerrar";
            this.bCerrar.Click += new System.EventHandler(this.bCerrar_Click);
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(44, 17);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(100, 20);
            this.l1.Text = "Primero";
            this.l1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(44, 37);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(100, 20);
            this.l2.Text = "Segundo";
            this.l2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(44, 57);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(100, 20);
            this.l3.Text = "Tercero";
            this.l3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // l4
            // 
            this.l4.Location = new System.Drawing.Point(44, 77);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(100, 20);
            this.l4.Text = "Cuarto";
            this.l4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // l5
            // 
            this.l5.Location = new System.Drawing.Point(44, 97);
            this.l5.Name = "l5";
            this.l5.Size = new System.Drawing.Size(100, 20);
            this.l5.Text = "Quinto";
            this.l5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // l6
            // 
            this.l6.Location = new System.Drawing.Point(44, 117);
            this.l6.Name = "l6";
            this.l6.Size = new System.Drawing.Size(100, 20);
            this.l6.Text = "Sexto";
            this.l6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // l7
            // 
            this.l7.Location = new System.Drawing.Point(44, 137);
            this.l7.Name = "l7";
            this.l7.Size = new System.Drawing.Size(100, 20);
            this.l7.Text = "Septimo";
            this.l7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // l8
            // 
            this.l8.Location = new System.Drawing.Point(44, 157);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(100, 20);
            this.l8.Text = "Octavo";
            this.l8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // l9
            // 
            this.l9.Location = new System.Drawing.Point(44, 177);
            this.l9.Name = "l9";
            this.l9.Size = new System.Drawing.Size(100, 20);
            this.l9.Text = "Noveno";
            this.l9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // l10
            // 
            this.l10.Location = new System.Drawing.Point(44, 197);
            this.l10.Name = "l10";
            this.l10.Size = new System.Drawing.Size(100, 20);
            this.l10.Text = "Decimo";
            this.l10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // VentanaPuntuaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.bCerrar);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "VentanaPuntuaciones";
            this.Text = "Puntuaciones";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label l9;
        private System.Windows.Forms.Label l8;
        private System.Windows.Forms.Label l7;
        private System.Windows.Forms.Label l6;
        private System.Windows.Forms.Label l5;
        private System.Windows.Forms.Label l4;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Button bCerrar;
        private System.Windows.Forms.Label l10;
    }
}