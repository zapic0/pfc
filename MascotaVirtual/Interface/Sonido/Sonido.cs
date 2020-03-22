using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace MascotaVirtual.Interface.Sonido
{
    /// <summary>
    /// Clase Sonido, permite reproducir un sonido en cada momento.
    /// </summary>
    public class Sonido
    {
        private byte[] m_soundBytes;
        private string m_fileName;

        #region Flags
        /// <summary>
        /// Enumeración para guardar los valores de cada flag.
        /// </summary>
        private enum Flags
        {
            SND_SYNC = 0x0000,  /* play synchronously (default) */
            SND_ASYNC = 0x0001,  /* play asynchronously */
            SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
            SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
            SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
            SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
            SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
            SND_ALIAS = 0x00010000, /* name is a registry alias */
            SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
            SND_FILENAME = 0x00020000, /* name is file name */
            SND_RESOURCE = 0x00040004  /* name is resource name or atom */
        }
        #endregion

        #region Reproducir un Sonido desde una ruta
        /// <summary>
        /// Reproduce un sonido
        /// </summary>
        /// <param name="szSound">Ruta del sonido.</param>
        /// <param name="hMod">HMod.</param>
        /// <param name="flags">Flags de opciones que queremos usar.</param>
        /// <returns></returns>
        [DllImport("CoreDll.DLL", EntryPoint = "PlaySound", SetLastError = true)]
        private extern static int WCE_PlaySound(string szSound, IntPtr hMod, int flags);
        #endregion

        #region Reproducir un Sonido definido por un array de bytes
        /// <summary>
        /// Reproduce un sonido definido por un array de bytes.
        /// </summary>
        /// <param name="szSound">Sonido a reproducir.</param>
        /// <param name="hMod">hMod.</param>
        /// <param name="flags">Flags de opciones.</param>
        /// <returns></returns>
        [DllImport("CoreDll.DLL", EntryPoint = "PlaySound", SetLastError = true)]
        private extern static int WCE_PlaySoundBytes(byte[] szSound, IntPtr hMod, int flags);
        #endregion

        #region Constructor a partir de un fichero
        /// <summary>
        /// Construye el sonido a partir del fichero especificado por parámetros
        /// </summary>
        public Sonido(string fileName)
        {
            m_fileName = this.GetAppPath()+"sonidos\\"+fileName;
        }
        #endregion

        #region Constructor a partir de un stream
        /// <summary>
        /// Construye el sonido a partir del stream especificado por parámetros
        /// </summary>
        public Sonido(Stream stream)
        {
            // lee los datos del stream
            m_soundBytes = new byte[stream.Length];
            stream.Read(m_soundBytes, 0, (int)stream.Length);
        }
        #endregion

        #region Reproducir el sonido construído
        /// <summary>
        /// Reproduce el sonido
        /// </summary>
        public void Play()
        {
            if (m_fileName != null)
                WCE_PlaySound(m_fileName, IntPtr.Zero, (int)(Flags.SND_ASYNC | Flags.SND_FILENAME));
            else
                WCE_PlaySoundBytes(m_soundBytes, IntPtr.Zero, (int)(Flags.SND_ASYNC | Flags.SND_MEMORY));
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