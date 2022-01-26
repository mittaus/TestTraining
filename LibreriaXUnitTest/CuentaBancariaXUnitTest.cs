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
    public class CuentaBancariaXUnitTest
    {
        private CuentaBancaria cuentaBancaria;

        public CuentaBancariaXUnitTest()
        {
            cuentaBancaria = new CuentaBancaria(new MiLogger());
        }

        [Fact]
        public void Depositar_InputMonto300_ReturnTrue()
        {
            var resultado = cuentaBancaria.Depositar(300);
            Assert.True(resultado);
            Assert.Equal(300, cuentaBancaria.ObtenerBalance());
        }

        [Fact]
        public void Depositar_InputMonto300Mocking_ReturnTrue()
        {
            var mocking = new Mock<IMiLogger>();
            mocking.SetupAllProperties();
            //var logger = new MiLogger();
            CuentaBancaria otraCuenta = new CuentaBancaria(mocking.Object);

            var resultado = otraCuenta.Depositar(300);

            Assert.True(resultado);
            Assert.Equal(300, otraCuenta.ObtenerBalance());
        }

        [Theory]
        [InlineData(300, 100)]
        [InlineData(300, 150)]
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

            Assert.True(resultado);

        }

        [Theory]
        [InlineData(300, 400)]
        public void Retirar_Retirar400DesdeSaldo300_ReturnFalse(double saldoActual, double montoRetiro)
        {
            var loggerMock = new Mock<IMiLogger>();

            //loggerMock.Setup(s => s.EscribirCantidadRetiro(It.Is<double>(x => x > 0))).Returns(true);
            loggerMock.Setup(s => s.EscribirSaldoDespuesRetiro(It.IsInRange<double>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Depositar(saldoActual);

            var resultado = cuentaBancaria.Retirar(montoRetiro);

            Assert.False(resultado);

        }

        [Fact]
        public void CuentaBancariaMiLog_LogMocking_ReturnTrue()
        {
            var miLoggerMock = new Mock<IMiLogger>();
            string mensajeEsperado = "texto de test";

            miLoggerMock.Setup(x => x.VerMensajeFormateado(It.IsAny<string>())).Returns((string cadena) => cadena.ToLower());

            var resultado = miLoggerMock.Object.VerMensajeFormateado("teXto de Test");
            Assert.Equal(mensajeEsperado, resultado);
        }

        [Fact]
        public void CuentaBancariaMiLog_LogMockingOutPut_ReturnTrue()
        {

            var miLoggerMock = new Mock<IMiLogger>();
            string textoPrueba = "Ver saldo";

            miLoggerMock.Setup(x => x.ValidarSaldoConOutPut(It.IsAny<double>(), out textoPrueba)).Returns(true);

            string parametroOutput = string.Empty;
            var resultado = miLoggerMock.Object.ValidarSaldoConOutPut(300, out parametroOutput);

            Assert.True(resultado);
        }

        [Fact]
        public void CuentaBancariaMiLog_LogMockingObjetoReferencia_ReturnTrue()
        {

            var miLoggerMock = new Mock<IMiLogger>();
            Cliente clienteUsado = new Cliente();
            Cliente clienteNoUsado = new Cliente();

            miLoggerMock.Setup(x => x.MensajeConObjetoReferencia(ref clienteUsado)).Returns(true);

            Assert.True(miLoggerMock.Object.MensajeConObjetoReferencia(ref clienteUsado));

            Assert.False(miLoggerMock.Object.MensajeConObjetoReferencia(ref clienteNoUsado));
        }

        [Fact]
        public void CuentaBancariaMiLog_LogMockingDestinoNivel_ReturnTrue()
        {
            var miLoggerMock = new Mock<IMiLogger>();
            miLoggerMock.SetupAllProperties();
            miLoggerMock.Setup(x => x.Destino).Returns("consola");
            miLoggerMock.Setup(x => x.Nivel).Returns(1);

            //miLoggerMock.Object.Nivel = 10;

            Assert.Equal("consola", miLoggerMock.Object.Destino);
            Assert.Equal(1, miLoggerMock.Object.Nivel);

            //CALLBACKS
            string cadenaIngresadaPorUsuario = "Hola";
            miLoggerMock.Setup(x => x.EscribirEnConsola(It.IsAny<string>()))
                .Callback((string parametro) =>
                {
                    cadenaIngresadaPorUsuario = cadenaIngresadaPorUsuario + parametro;
                });

            miLoggerMock.Object.EscribirEnConsola(" mundo");

            Assert.Equal("Hola mundo", cadenaIngresadaPorUsuario);
        }

        [Fact]
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
