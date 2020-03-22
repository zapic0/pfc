using System;
using System.Collections.Generic;
using System.Text;

namespace MascotaVirtual.Utilidades
{
    /// <summary>
    /// Utilidad para obtener el directorio raíz de la aplicación.
    /// </summary>
    public class DirectorioRaiz
    {
        #region Directorio
        private string directorio;
        /// <summary>
        /// Directorio raíz en el que se encuentra la aplicación.
        /// </summary>
        public string Directorio
        {
            get { return directorio; }
            set { directorio = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public DirectorioRaiz()
        {
            directorio = this.GetAppPath();
        }
        #endregion

        #region GetAppPath
        /// <summary>
        /// Obtiene la ruta en el que se está ejecutando la aplicación
        /// </summary>
        /// <returns>Cadena con la ruta</returns>
        private string GetAppPath()
        {

            System.Reflection.Module[] modules = System.Reflection.Assembly.GetExecutingAssembly().GetModules();

            string aPath = System.IO.Path.GetDirectoryName(modules[0].FullyQualifiedName);

            if ((aPath != "") && (aPath[aPath.Length - 1] != '\\'))

                aPath += '\\';

            return aPath;

        }
        #endregion
    }
}
