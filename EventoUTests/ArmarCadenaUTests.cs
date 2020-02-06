using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Evento.Tests
{
    [TestClass()]
    public class ArmarCadenaUTests
    {
        [TestMethod()]
        public void ArmarCadena_TieneUnRegistro_ListaUnRegistro()
        {
            var DOCILeerArchivo = new Mock<IProcesarFechaTipo>();
            List<IProcesarFechaTipo> lst = new List<IProcesarFechaTipo>();
            lst.Add(DOCILeerArchivo.Object);
            lst.Add(DOCILeerArchivo.Object);

            var SUT = new ArmarCadena();

            SUT.ObtenerCadenaMensaje(lst);
            Assert.AreEqual(2, lst.Count);

        }
    }
}