using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento
{
    public class ProcesarFechas : IProcesarFechas, IProcesarFechaTipo
    {
        public List<EventoFecha> lstEventoFecha;
        private List<IProcesarFechaTipo> lstIvalidarFechas;
        private IProcesarFechaTipo IProcesarTipo;

        public int Meses { get; set; }
        public int Dias { get; set; }
        public int Horas { get; set; }
        public int Minutos { get; set; }

        public int iTipovalor { get; set; }
        public int iTipoTiempo { get; set; }
        public string cTipoEvento { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="_lstEventoFecha">Lista del tipo Evento Fecha que contiene la lista de eventos con sus fechas</param>
        /// <param name="_lstIvalidarFechas">Lista de eventos del tipo IProcesarFechaTipo</param>
        /// <param name="_IProcesarTipo">Interface que implementa a una clase especifica</param>
        public ProcesarFechas(List<EventoFecha> _lstEventoFecha, List<IProcesarFechaTipo> _lstIvalidarFechas, IProcesarFechaTipo _IProcesarTipo)
        {
            this.lstEventoFecha = _lstEventoFecha;
            this.lstIvalidarFechas = _lstIvalidarFechas;
            this.IProcesarTipo = _IProcesarTipo;
        }      

        /// <summary>
        /// Método que recorre la lista de eventos
        /// </summary>
        public void RecorrerListaEventos()
        {
            DateTime dtValidar = DateTime.Now;
            if (lstEventoFecha.Any())
            {
                foreach (EventoFecha item in lstEventoFecha)
                {
                    AsignarValorPropiedadesTipo(item.cEvento, dtValidar, item.dtFechaEvento);
                    ObtenerCadenaTipoValor();
                    ObtenerEnteroTipoValor();
                    AsignarValoresTipo();
                }
            }
        }

        /// <summary>
        /// Asigna los valores a las propiedades de la clase
        /// </summary>
        /// <param name="_dtValidar">Fecha actual</param>
        /// <param name="_dtFechaEvento">Fecha de la lista evento a validar</param>
        private void AsignarValorPropiedadesTipo(string _cEvento, DateTime _dtValidar, DateTime _dtFechaEvento)
        {
            this.Meses = _dtFechaEvento.Month - _dtValidar.Month;
            this.Dias = (_dtFechaEvento - _dtValidar).Days;
            this.Horas = (_dtFechaEvento - _dtValidar).Hours;
            this.Minutos = (_dtFechaEvento - _dtValidar).Minutes;
            this.cTipoEvento = _cEvento;
        }

        /// <summary>
        /// Método que se encarga de validar el tipo de fecha
        /// </summary>
        private void ObtenerCadenaTipoValor()
        {
            iTipoTiempo = (this.Meses >= (int)BanderaTipoTiempo.TiempoValor.Mes ? (int)BanderaTipoTiempo.TipoTiempo.Mes :
                                    (Math.Abs(this.Dias) >= (int)BanderaTipoTiempo.TiempoValor.Dia ? (int)BanderaTipoTiempo.TipoTiempo.Dia :
                                        (Math.Abs(this.Horas) < (int)BanderaTipoTiempo.TiempoValor.Hora && Math.Abs(this.Horas) > (int)decimal.Zero ? 
                                            (int)BanderaTipoTiempo.TipoTiempo.Hora : 
                                                (int)BanderaTipoTiempo.TipoTiempo.Minuto)));
        }

        /// <summary>
        /// Método que se encarga de validar el tipo de fecha po valorIProcesarFechaTipo
        /// </summary>
        private void ObtenerEnteroTipoValor()
        {
            iTipovalor = (this.Meses >= (int)BanderaTipoTiempo.TiempoValor.Mes ? this.Meses :
                                    (Math.Abs(this.Dias) >= (int)BanderaTipoTiempo.TiempoValor.Dia ? this.Dias :
                                        (Math.Abs(this.Horas) < (int)BanderaTipoTiempo.TiempoValor.Hora && Math.Abs(this.Horas) > (int)decimal.Zero ? 
                                            this.Horas : this.Minutos)));
        }

        /// <summary>
        /// Método que asigna los valores a la lista de tipo
        /// </summary>
        private void AsignarValoresTipo()
        {
            IProcesarFechaTipo IProcesarTipo = new ArmarCadena();
            IProcesarTipo.iTipovalor = iTipovalor;
            IProcesarTipo.iTipoTiempo = iTipoTiempo;
            IProcesarTipo.cTipoEvento = cTipoEvento;
            this.lstIvalidarFechas.Add(IProcesarTipo);
        }
    }
}
