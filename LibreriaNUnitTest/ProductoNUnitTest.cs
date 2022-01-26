using Libreria;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNUnitTest
{
    [TestFixture]
    public class ProductoNUnitTest
    {
        [Test]
        public void ObtenerPrecio_ClienteEsAdultoMayor_ReturnPrecio90PorCiento()
        {
            Producto producto = new Producto()
            {
                Precio = 100
            };

            var resultado = producto.ObtenerPrecio(new Cliente() { EsAdultoMayor = true });


            Assert.That(resultado, Is.EqualTo(90));
        }

        [Test]
        public void ObtenerPrecio_ClienteEsAdultoMayorMoq_ReturnPrecio90PorCiento()
        {
            Producto producto = new Producto()
            {
                Precio = 100
            };

            var clienteMoq = new Mock<ICliente>();
            clienteMoq.Setup(s => s.EsAdultoMayor).Returns(true);

            var resultado = producto.ObtenerPrecio(clienteMoq.Object);


            Assert.That(resultado, Is.EqualTo(90));
        }
    }
}
