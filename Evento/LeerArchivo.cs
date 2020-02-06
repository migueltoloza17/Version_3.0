using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    public class LeerArchivo : ILeerArchivo
    {
        public string cRuta { get; set; }

        /// <summary>
        /// Método que se encarga de obtener un archivo 
        /// </summary>
        /// <param name="_cRuta">Ruta de la ubicación del archivo</param>
        /// <returns>Array de strings</returns>
        public string[] ObtenerArchivo(string _cRuta)
        {
            return System.IO.File.ReadAllLines(_cRuta);
        }
    }
}
