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
            Assert.That(nombreCompleto, Is.EqualTo("Diana Larrea"));
            Assert.AreEqual(nombreCompleto, "Diana Larrea");
            Assert.That(nombreCompleto, Does.Contain("Larrea"));
            Assert.That(nombreCompleto, Does.Contain("larrea").IgnoreCase);//case sensitive
            Assert.That(nombreCompleto, Does.StartWith("Diana"));
            Assert.That(nombreCompleto, Does.EndWith("Larrea"));
        }

        [Test]
        public void ClienteNombreCompleto_NoValues_ReturnNull()
        {
            //Cliente cliente = new Cliente();
            cliente.CrearNombreCompleto("José Luis", "Obregon");
            Assert.IsNotNull(cliente.NombreCompleto);
        }
    }
}
