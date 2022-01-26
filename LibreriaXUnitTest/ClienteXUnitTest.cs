using Libreria;
using Xunit;
using System;

namespace LibreriaNUnitTest
{
    public class ClienteXUnitTest
    {

        private Cliente cliente = null;

        public ClienteXUnitTest()
        {
            cliente = new Cliente();
        }

        [Fact]
        public void CrearNombreCompleto_InputNombreApellido_ObtenerNombreCompleto()
        {
            //Arrange
            //Cliente cliente = new Cliente();

            //Act
            string nombreCompleto = cliente.CrearNombreCompleto("Diana", "Larrea");

            //Assert
            //Assert.Multiple(() =>
            //{
            Assert.Equal("Diana Larrea", nombreCompleto);
            Assert.Equal("Diana Larrea", nombreCompleto);
            Assert.Contains("Larrea", nombreCompleto);
            Assert.Contains("larrea", nombreCompleto, StringComparison.OrdinalIgnoreCase);//case sensitive
            Assert.StartsWith("Diana", nombreCompleto);
            Assert.EndsWith("Larrea", nombreCompleto);
            //});
        }

        [Fact]
        public void ClienteNombreCompleto_NoValues_ReturnNull()
        {
            //Cliente cliente = new Cliente();
            cliente.CrearNombreCompleto("José Luis", "Obregon");
            Assert.NotNull(cliente.NombreCompleto);
        }

        [Fact]
        public void CrearNombreCompleto_InputNombre_ReturnNotNull()
        {
            cliente.CrearNombreCompleto("Isaias", "");
            Assert.NotNull(cliente.NombreCompleto);
            Assert.False(string.IsNullOrEmpty(cliente.NombreCompleto));
        }

        [Fact]
        public void ClienteNombreCompleto_InputNombreEnBlanco_ThrowException()
        {
            var detalleError = Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto(null, null));
            Assert.Equal("Ingrese nombre", detalleError.Message);
        }

        [Fact]
        public void ObtenerSegmentoCliente_CrearClienteMenorEdad_ReturnClienteMenorEdad()
        {
            cliente.Edad = 17;
            var resultado = cliente.ObtenerSegmentoCliente();
            Assert.IsType<ClienteMenorEdad>(resultado);
        }

        [Fact]
        public void ObtenerSegmentoCliente_CrearClienteMayorEdad_ReturnClienteMayorEdad()
        {
            cliente.Edad = 31;
            var resultado = cliente.ObtenerSegmentoCliente();
            Assert.IsType<ClienteMayorEdad>(resultado);
        }
    }
}
