using Libreria;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNUnitTest
{

    public class ColectorXUnitTest
    {
        [Fact]
        public void ObtenerNumerosPares_InputIntervaloMinimoMaximo_ObtenerListaPares()
        {
            Colector colector = new Colector();
            List<int> numerosParesEsperados = new List<int>() { 2, 4, 6, 8, 10 };

            List<int> numerosParesDevueltos = colector.ObtenerNumerosPares(1, 10);

            Assert.Equal(numerosParesEsperados, numerosParesDevueltos);

            Assert.Contains(6, numerosParesDevueltos);
            Assert.Contains(6, numerosParesDevueltos);

            Assert.NotEmpty(numerosParesDevueltos);

            Assert.Equal(5, numerosParesDevueltos.Count);

            Assert.DoesNotContain(100, numerosParesDevueltos);

            Assert.Equal(numerosParesDevueltos.OrderBy(u => u), numerosParesDevueltos);
        }

        [Fact]
        public void ObtenerDeuda_Input10PorCientoDescuento_ObtenerCorrecto()
        {
            Cliente cliente = new Cliente();
            cliente.Deuda = 120;
            double descuento = 10;

            cliente.AgregarDescuento10PorCiento(descuento);

            double deudaActual = cliente.ObtenerDeuda();

            Assert.InRange(deudaActual, 100, 120);
        }
    }
}
