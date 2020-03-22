using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace MascotaVirtual.Minijuegos.Puntuaciones
{
    public partial class VentanaPuntuaciones : Form
    {
        private ListaPuntuaciones listaPuntos;
        private XmlSerializer serializer;

        private string ficheroPuntuaciones;
        
        System.IO.StreamWriter writer;
        System.IO.StreamReader reader;


        #region Constructor
        /// <summary>
        /// Inicializa la ventana y deserializa las puntuaciones
        /// </summary>
        public VentanaPuntuaciones()
        {
            InitializeComponent();
            ficheroPuntuaciones = "";
        }
        #endregion

        #region Inicializar
        /// <summary>
        /// Inicializar las puntuaciones a partir del fichero que le pasamos
        /// </summary>
        /// <param name="ficheroPuntuaciones">Ruta del fichero XML con las puntuaciones a cargar</param>
        public void Inicializar(string ficheroPuntuaciones)
        {
            this.ficheroPuntuaciones = ficheroPuntuaciones;
            serializer = new XmlSerializer(typeof(ListaPuntuaciones));
            reader = new System.IO.StreamReader(new Utilidades.DirectorioRaiz().Directorio+ "archivos\\"+ficheroPuntuaciones);
            listaPuntos = (ListaPuntuaciones)serializer.Deserialize(reader);
            reader.Close();
            this.MostrarPuntos();
        }
        #endregion

        #region InsertarPuntos
        /// <summary>
        /// Inserta una puntuación en el top ten y llama a mostrar puntos.
        /// </summary>
        /// <param name="puntos">Valor de la puntuación que queremos insertar.</param>
        public void InsertarPuntos(int puntos)
        {
            this.listaPuntos.InsertarPuntos(puntos);
            this.MostrarPuntos();
        }
        #endregion

        #region MostrarPuntos
        /// <summary>
        /// Da el valor del top ten a las etiquetas de la ventana.
        /// </summary>
        private void MostrarPuntos()
        {
            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0: this.l1.Text = this.listaPuntos.GetPuntos(i).ToString();
                        break;
                    case 1: this.l2.Text = this.listaPuntos.GetPuntos(i).ToString();
                        break;
                    case 2: this.l3.Text = this.listaPuntos.GetPuntos(i).ToString();
                        break;
                    case 3: this.l4.Text = this.listaPuntos.GetPuntos(i).ToString();
                        break;
                    case 4: this.l5.Text = this.listaPuntos.GetPuntos(i).ToString();
                        break;
                    case 5: this.l6.Text = this.listaPuntos.GetPuntos(i).ToString();
                        break;
                    case 6: this.l7.Text = this.listaPuntos.GetPuntos(i).ToString();
                        break;
                    case 7: this.l8.Text = this.listaPuntos.GetPuntos(i).ToString();
                        break;
                    case 8: this.l9.Text = this.listaPuntos.GetPuntos(i).ToString();
                        break;
                    case 9: this.l10.Text = this.listaPuntos.GetPuntos(i).ToString();
                        break;
                }
            }
        }
        #endregion

        #region Botones
        /// <summary>
        /// Cerrar la ventana de puntuaciones.
        /// </summary>
        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        #region Serializar
        /// <summary>
        /// Serializa el objeto convirtiéndolo en un archivo XML.
        /// </summary>
        public void Serializar()
        {
            writer = new System.IO.StreamWriter(new Utilidades.DirectorioRaiz().Directorio + "archivos\\"+this.ficheroPuntuaciones);
            serializer.Serialize(writer, listaPuntos);
            writer.Close();
        }
        #endregion
    }
}