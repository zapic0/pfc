using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MascotaVirtual.VidaMascota.Modelo.Componentes
{
    /// <summary>
    /// Clase que contiene los datos que se necesitan para cada frame de un componente
    /// El rectángulo del que se carga la imagen
    /// La distancia respecto al punto de referencia en la que se debe dibujar
    /// </summary>
    public class DatosComponente
    {
        #region Constructor
        /// <summary>
        /// Constructor de DatosComponente
        /// </summary>
        public DatosComponente()
        {
            this.rectanguloFuente = new Rectangle(-1, -1, -1, -1);
            this.distanciaPuntoReferencia = new Point(-1, -1);
        }
        #endregion

        #region Rectángulo Fuente
        private Rectangle rectanguloFuente;
        /// <summary>
        /// Rectángulo fuente en que se enmarca la imagen a cargar del componente
        /// </summary>
        public Rectangle RectanguloFuente
        {
            get { return rectanguloFuente; }
            set { rectanguloFuente = value; }
        }
        #endregion

        #region Distancia al Punto de Referencia
        private Point distanciaPuntoReferencia;
        /// <summary>
        /// Distancia respecto al punto de referencia en la que se pintará el componente
        /// Se define como un punto
        /// </summary>
        public Point DistanciaPuntoReferencia
        {
            get { return distanciaPuntoReferencia; }
            set { distanciaPuntoReferencia = value; }
        }
        #endregion
    }
}
