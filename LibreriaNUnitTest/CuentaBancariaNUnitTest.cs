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
    public class CuentaBancariaNUnitTest
    {
        private CuentaBancaria cuentaBancaria;

        [SetUp]
        public void Setup()
        {
            cuentaBancaria = new CuentaBancaria(new MiLogger());
            //cuentaBancaria = new CuentaBancaria(new LoggerFake());
        }

        [Test]
        public void Depositar_InputMonto300_ReturnTrue()
        {
            var resultado = cuentaBancaria.Depositar(300);
            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.ObtenerBalance, Is.EqualTo(300));
        }

        [Test]
        public void Depositar_InputMonto300Mocking_ReturnTrue()
        {
            var mocking = new Mock<IMiLogger>();
            mocking.SetupAllProperties();
            //var logger = new MiLogger();
            CuentaBancaria otraCuenta = new CuentaBancaria(mocking.Object);

            var resultado = otraCuenta.Depositar(300);

            Assert.IsTrue(resultado);
            Assert.That(otraCuenta.ObtenerBalance, Is.EqualTo(300));
        }

        [Test]
        [TestCase(300, 100)]
        [TestCase(300, 150)]
        public void Retirar_Retirar100DesdeSaldo300_ReturnTrue(double saldoActual, double montoRetiro)
        {
            var loggerMock = new Mock<IMiLogger>();

            //loggerMock.Setup(s => s.EscribirCantidadRetiro(It.IsAny<double>())).Returns(true);
            //loggerMock.Setup(s => s.EscribirSaldoDespuesRetiro(It.IsAny<double>())).Returns(true);

            loggerMock.Setup(s => s.EscribirCantidadRetiro(It.Is<double>(x => x > 0))).Returns(true);
            loggerMock.Setup(s => s.EscribirSaldoDespuesRetiro(It.Is<double>(x => x > 0))).Returns(true);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Depositar(saldoActual);

            var resultado = cuentaBancaria.Retirar(montoRetiro);

            Assert.That(resultado, Is.True);

        }

        [Test]
        [TestCase(300, 400)]
        public void Retirar_Retirar400DesdeSaldo300_ReturnFalse(double saldoActual, double montoRetiro)
        {
            var loggerMock = new Mock<IMiLogger>();

            //loggerMock.Setup(s => s.EscribirCantidadRetiro(It.Is<double>(x => x > 0))).Returns(true);
            loggerMock.Setup(s => s.EscribirSaldoDespuesRetiro(It.IsInRange<double>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Depositar(saldoActual);

            var resultado = cuentaBancaria.Retirar(montoRetiro);

            Assert.That(resultado, Is.False);

        }

        [Test]
        public void CuentaBancariaMiLog_LogMocking_ReturnTrue()
        {
            var miLoggerMock = new Mock<IMiLogger>();
            string mensajeEsperado = "texto de test";

            miLoggerMock.Setup(x => x.VerMensajeFormateado(It.IsAny<string>())).Returns((string cadena) => cadena.ToLower());

            var resultado = miLoggerMock.Object.VerMensajeFormateado("teXto de Test");
            Assert.That(resultado, Is.EqualTo(mensajeEsperado));
        }

        [Test]
        public void CuentaBancariaMiLog_LogMockingOutPut_ReturnTrue()
        {

            var miLoggerMock = new Mock<IMiLogger>();
            string textoPrueba = "Ver saldo";

            miLoggerMock.Setup(x => x.ValidarSaldoConOutPut(It.IsAny<double>(), out textoPrueba)).Returns(true);

            string parametroOutput = string.Empty;
            var resultado = miLoggerMock.Object.ValidarSaldoConOutPut(300, out parametroOutput);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void CuentaBancariaMiLog_LogMockingObjetoReferencia_ReturnTrue()
        {

            var miLoggerMock = new Mock<IMiLogger>();
            Cliente clienteUsado = new Cliente();
            Cliente clienteNoUsado = new Cliente();

            miLoggerMock.Setup(x => x.MensajeConObjetoReferencia(ref clienteUsado)).Returns(true);

            Assert.IsTrue(miLoggerMock.Object.MensajeConObjetoReferencia(ref clienteUsado));

            Assert.IsFalse(miLoggerMock.Object.MensajeConObjetoReferencia(ref clienteNoUsado));
        }

        [Test]
        public void CuentaBancariaMiLog_LogMockingDestinoNivel_ReturnTrue()
        {
            var miLoggerMock = new Mock<IMiLogger>();
            miLoggerMock.SetupAllProperties();
            miLoggerMock.Setup(x => x.Destino).Returns("consola");
            miLoggerMock.Setup(x => x.Nivel).Returns(1);

            //miLoggerMock.Object.Nivel = 10;

            Assert.That(miLoggerMock.Object.Destino, Is.EqualTo("consola"));
            Assert.That(miLoggerMock.Object.Nivel, Is.EqualTo(1));

            //CALLBACKS
            string cadenaIngresadaPorUsuario = "Hola";
            miLoggerMock.Setup(x => x.EscribirEnConsola(It.IsAny<string>()))
                .Callback((string parametro) =>
                {
                    cadenaIngresadaPorUsuario = cadenaIngresadaPorUsuario + parametro;
                });

            miLoggerMock.Object.EscribirEnConsola(" mundo");

            Assert.That(cadenaIngresadaPorUsuario, Is.EqualTo("Hola mundo"));
        }

        [Test]
        public void CuentaBancariaMiLogger_VerificarCantidadUsoLogger()
        {
            var miLoggerMock = new Mock<IMiLogger>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(miLoggerMock.Object);

            cuentaBancaria.Depositar(100);

            //Assert.That(cuentaBancaria.ObtenerBalance, Is.EqualTo(100));

            //verificar cuantas veces el mock está llamando  al método EscribirEnConsola
            miLoggerMock.Verify(x => x.EscribirEnConsola(It.IsAny<string>()), Times.Exactly(3));

            miLoggerMock.Verify(x => x.EscribirEnConsola(It.IsAny<string>()), Times.AtLeastOnce);

            miLoggerMock.VerifySet(x => x.Nivel = 2, Times.Exactly(1));

        }
    }

}
