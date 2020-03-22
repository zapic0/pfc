using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MascotaVirtual.VidaMascota;
using MascotaVirtual.VidaMascota.Modelo.Objetos;
using MascotaVirtual.Interface;
using System.Threading;
using MascotaVirtual.Ventanas;

namespace MascotaVirtual
{
    /// <summary>
    /// Punto de entrada al programa
    /// </summary>
    public static class Principal
    {
        /// <summary>
        /// Main
        /// </summary>
        [MTAThread]
        static void Main()
        {
            ControlVentanas controlVentanas = new ControlVentanas();
            controlVentanas.IniciarPrograma();
        }
    }
}
