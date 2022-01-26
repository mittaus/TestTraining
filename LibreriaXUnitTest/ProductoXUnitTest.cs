using Libreria;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNUnitTest
{
    public class ProductoXUnitTest
    {
        [Fact]
        public void ObtenerPrecio_ClienteEsAdultoMayor_ReturnPrecio90PorCiento()
        {
            Producto producto = new Producto()
            {
                Precio = 100
            };

            var resultado = producto.ObtenerPrecio(new Cliente() { EsAdultoMayor = true });


            Assert.Equal(90, resultado);
        }

        [Fact]
        public void ObtenerPrecio_ClienteEsAdultoMayorMoq_ReturnPrecio90PorCiento()
        {
            Producto producto = new Producto()
            {
                Precio = 100
            };

            var clienteMoq = new Mock<ICliente>();
            clienteMoq.Setup(s => s.EsAdultoMayor).Returns(true);

            var resultado = producto.ObtenerPrecio(clienteMoq.Object);


            Assert.Equal(90, resultado);
        }
    }
}
