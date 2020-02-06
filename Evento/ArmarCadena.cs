using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    public class ArmarCadena : IProcesarCadena, IProcesarFechaTipo
    {
        public int iTipovalor { get; set; }
        public int iTipoTiempo { get; set; }
        public string cTipoEvento { get; set; }

        List<IProcesarFechaTipo> lstIProcesarFechaTipo;
        List<string> lstCadenasMensajes = new List<string>();

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ArmarCadena()
        {
          
        }

        /// <summary>
        /// Método que se encarga de obtener un array con las cadenas de los mensajes
        /// </summary>
        /// <param name="_lstIProcesarFechaTipo">Lista de tipo IProcesarFechaTipo</param>
        /// <returns>Retornar array de cadena</returns>
        public string[] ObtenerCadenaMensaje(List<IProcesarFechaTipo> _lstIProcesarFechaTipo)
        {
            this.lstIProcesarFechaTipo = _lstIProcesarFechaTipo;
            this.RecorrerListaTipo();

            return this.lstCadenasMensajes.ToArray();
        }

        /// <summary>
        /// Método que se encarga de recorrer una lista para obtener los valores
        /// </summary>
        public void RecorrerListaTipo()
        {
            foreach (IProcesarFechaTipo item in lstIProcesarFechaTipo)
            {
                this.AsignarValoresPropiedadesTipo(item);
                this.AgregarCadenaPorTipo();
            }
        }

        /// <summary>
        /// Método que se encarga de asignar los valores a las propiedades
        /// </summary>
        /// <param name="_item">Propiedad de tipo Interfaz</param>
        private void AsignarValoresPropiedadesTipo(IProcesarFechaTipo _item)
        {
            this.iTipovalor = _item.iTipovalor;
            this.iTipoTiempo = _item.iTipoTiempo;
            this.cTipoEvento = _item.cTipoEvento;
        }

        /// <summary>
        /// Método que se encarga de agregar una cadena a la lista
        /// </summary>
        private void AgregarCadenaPorTipo()
        {
            this.lstCadenasMensajes.Add(this.ObtenerCadena());
        }

        /// <summary>
        /// Método que se encarga de formar la cadena
        /// </summary>
        /// <returns>cadena con el texto a visualizar</returns>
        public string ObtenerCadena()
        {
            string cCadenaMensaje = string.Empty;

            cCadenaMensaje = string.Format("{0} {1} {2} {3} {4}",
                                            this.cTipoEvento,
                                            this.iTipovalor > (int)decimal.Zero ? "ocurrirá" : "ocurrió",
                                            this.iTipovalor > (int)decimal.Zero ? "dentro de" : "hace",
                                            Math.Abs(this.iTipovalor),
                                            Enum.Parse(typeof(BanderaTipoTiempo.TipoTiempo), this.iTipoTiempo.ToString()));

            return cCadenaMensaje;
        }
        
    }
}
