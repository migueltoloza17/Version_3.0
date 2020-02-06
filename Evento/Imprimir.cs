using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    public class Imprimir : IImprimirCadena
    {
        private string[] aMensajes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_aMensajes"></param>
        /// <param name="_IImprimirCadena"></param>
        public Imprimir(string[] _aMensajes)
        {
            this.aMensajes = _aMensajes;
        }

        /// <summary>
        /// Método que se encarga de recorrer una lista e imprimir la cadena
        /// </summary>
        public void ImprimirCadena()
        {
            foreach (string item in aMensajes)
            {
                this.ImprimirResultado(item);
            }
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        /// <summary>
        /// Método que se encarga de recorrer el array y se imprime el registro
        /// por evento
        /// </summary>
        public void ImprimirResultado(string _cCadena)
        {
            Console.WriteLine("\t" + _cCadena);
        }
    }
}
