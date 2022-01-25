using Libreria;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNUnitTest
{
    [TestFixture]
    public class ColectorNUnitTest
    {
        [Test]
        public void ObtenerNumerosPares_InputIntervaloMinimoMaximo_ObtenerListaPares()
        {
            Colector colector = new Colector();
            List<int> numerosParesEsperados = new List<int>() { 2, 4, 6, 8, 10 };

            List<int> numerosParesDevueltos = colector.ObtenerNumerosPares(1, 10);

            Assert.That(numerosParesDevueltos, Is.EquivalentTo(numerosParesEsperados));

            Assert.AreEqual(numerosParesDevueltos, numerosParesEsperados);

            Assert.That(numerosParesDevueltos, Does.Contain(5));
            Assert.Contains(5, numerosParesDevueltos);

            Assert.That(numerosParesDevueltos, Is.Not.Empty);

            Assert.That(numerosParesDevueltos.Count, Is.EqualTo(3));

            Assert.That(numerosParesDevueltos, Has.No.Member(100));

            Assert.That(numerosParesDevueltos, Is.Ordered);//.Ascending
            Assert.That(numerosParesDevueltos, Is.Ordered.Descending);
            Assert.That(numerosParesDevueltos, Is.Unique);
        }

        [Test]
        public void ObtenerDeuda_Input10PorCientoDescuento_ObtenerCorrecto()
        {
            Cliente cliente = new Cliente();
            cliente.Deuda = 112;
            double descuento = 10;

            cliente.AgregarDescuento10PorCiento(descuento);

            double deudaActual = cliente.ObtenerDeuda();

            Assert.That(deudaActual, Is.InRange(100, 120));
        }
    }
}
