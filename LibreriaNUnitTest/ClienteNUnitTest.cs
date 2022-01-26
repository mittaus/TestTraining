using Libreria;
using NUnit.Framework;
using System;

namespace LibreriaNUnitTest
{
    [TestFixture]
    public class ClienteNUnitTest
    {

        private Cliente cliente = null;

        [SetUp]
        public void Setup()
        {
            cliente = new Cliente();
        }

        [Test]
        public void CrearNombreCompleto_InputNombreApellido_ObtenerNombreCompleto()
        {
            //Arrange
            //Cliente cliente = new Cliente();

            //Act
            string nombreCompleto = cliente.CrearNombreCompleto("Diana", "Larrea");

            //Assert
            //Assert.Multiple(() =>
            //{
                Assert.That(nombreCompleto, Is.EqualTo("Diana Larrea"));
                Assert.AreEqual(nombreCompleto, "Diana Larrea");
                Assert.That(nombreCompleto, Does.Contain("Larrea"));
                Assert.That(nombreCompleto, Does.Contain("larrea").IgnoreCase);//case sensitive
                Assert.That(nombreCompleto, Does.StartWith("Diana"));
                Assert.That(nombreCompleto, Does.EndWith("Larrea"));
            //});
        }

        [Test]
        public void ClienteNombreCompleto_NoValues_ReturnNull()
        {
            //Cliente cliente = new Cliente();
            cliente.CrearNombreCompleto("José Luis", "Obregon");
            Assert.IsNotNull(cliente.NombreCompleto);
        }

        [Test]
        public void CrearNombreCompleto_InputNombre_ReturnNotNull()
        {
            cliente.CrearNombreCompleto("Isaias", "");
            Assert.IsNotNull(cliente.NombreCompleto);
            Assert.IsFalse(string.IsNullOrEmpty(cliente.NombreCompleto));
        }

        [Test]
        public void ClienteNombreCompleto_InputNombreEnBlanco_ThrowException()
        {
            Assert.That(() => cliente.CrearNombreCompleto("", "Mi apellido"), Throws.ArgumentException);
            
            var detalleError = Assert.Throws<ArgumentException>(()=> cliente.CrearNombreCompleto(null, null));
            Assert.AreEqual("Ingrese nombre", detalleError.Message);


            Assert.That(() => cliente.CrearNombreCompleto("", "Mi apellido"), Throws.ArgumentException.With.Message.EqualTo("Ingrese nombre"));

        }

        [Test]
        public void ObtenerSegmentoCliente_CrearClienteMenorEdad_ReturnClienteMenorEdad()
        {
            cliente.Edad = 17;
            var resultado = cliente.ObtenerSegmentoCliente();
            Assert.That(resultado, Is.TypeOf<ClienteMenorEdad>());
        }

        [Test]
        public void ObtenerSegmentoCliente_CrearClienteMayorEdad_ReturnClienteMayorEdad()
        {
            cliente.Edad = 31;
            var resultado = cliente.ObtenerSegmentoCliente();
            Assert.That(resultado, Is.TypeOf<ClienteMayorEdad>());
        }
    }
}
