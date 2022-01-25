using Libreria;
using NUnit.Framework;
using System;
using System.Linq;

namespace LibreariaNUnitTest
{
    [TestFixture]
    public class CalculadoraNUnitTest
    {
        [Test]
        public void SumarNumeros_Input2Numeros_GetValorCorrecto()
        {
            //1. Arrange
            decimal primerNumero = 1;
            decimal segundoNumero = 2;
            CalculadoraBasica calc = new CalculadoraBasica();

            //2. Act
            decimal resultado = calc.Sumar(primerNumero, segundoNumero);

            //3. Assert
            Assert.AreEqual(3, resultado);
        }


        [Test]
        public void SumarNumeros_Input2Numeros_ModeloClasico_ReturnFalse()
        {
            //1. Arrange
            int[] array = new int[] { 1, 2, 3, 4 };

            //2. Act
            int totalCoincidencias = array.Where(x => x == 4).Count();

            //3. Assert
            Assert.AreEqual(1, totalCoincidencias);
        }


        [Test]
        public void SumarNumeros_Input2Numeros_ModeloRestricciones()
        {
            //1. Arrange
            int[] array = new int[] { 1, 2, 3, 4 };

            //2. Act
            //3. Assert
            Assert.That(array, Has.Exactly(1).EqualTo(4));
        }



        [Test]
        public void EsValorPar_InputNumeroPar_ReturnFalse()
        {
            //1. Arrange
            int numeroImpar = 1;
            CalculadoraBasica calc = new CalculadoraBasica();

            //2. Act
            bool esPar = calc.EsValorPar(numeroImpar);

            //3. Assert
            Assert.IsFalse(esPar);
            Assert.That(esPar, Is.EqualTo(false));
        }

        [Test]
        public void EsValorPar_InputNumeroPar_ReturnTrue()
        {
            //1. Arrange
            int numeroImpar = 4;
            CalculadoraBasica calc = new CalculadoraBasica();

            //2. Act
            bool esPar = calc.EsValorPar(numeroImpar);

            //3. Assert
            Assert.IsTrue(esPar);
            Assert.That(esPar, Is.EqualTo(true));
        }

        [Test]
        [TestCase(1)]
        [TestCase(101)]
        [TestCase(33)]
        public void EsValorPar_InputNumeroPar_ReturnFalse_v2(int numeroImpar)
        {
            //1. Arrange
            CalculadoraBasica calc = new CalculadoraBasica();

            //2. Act
            bool esPar = calc.EsValorPar(numeroImpar);

            //3. Assert
            Assert.IsFalse(esPar);
            Assert.That(esPar, Is.EqualTo(false));
        }

        [Test]
        [TestCase(2, 4, ExpectedResult = 8)]
        [TestCase(1, 2, ExpectedResult = 2)]
        [TestCase(60.5, 2, ExpectedResult = 121)]
        public decimal Multiplicar_Input2Numero_GetValorCorrecto(decimal numero1, decimal numero2)
        {
            CalculadoraBasica calc = new CalculadoraBasica();

            decimal resultado = calc.Multiplicar(numero1, numero2);

            return resultado;
        }

        [Test]
        [TestCase(3.1, 1)]//3.1
        [TestCase(1.5, 2)]//3
        public void Multiplicar_Input2Numero_GetValorCorrectoEnRango(decimal numero1, decimal numero2)
        {
            CalculadoraBasica calc = new CalculadoraBasica();

            decimal resultado = calc.Multiplicar(numero1, numero2);

            Assert.AreEqual(3, (double)resultado, 0.2);
        }


    }
}
