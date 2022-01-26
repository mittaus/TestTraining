using Libreria;
using Xunit;
using System;
using System.Linq;

namespace LibreriaNUnitTest
{
    public class CalculadoraXUnitTest
    {
        [Fact]
        public void SumarNumeros_Input2Numeros_GetValorCorrecto()
        {
            //1. Arrange
            decimal primerNumero = 1;
            decimal segundoNumero = 2;
            CalculadoraBasica calc = new CalculadoraBasica();

            //2. Act
            decimal resultado = calc.Sumar(primerNumero, segundoNumero);

            //3. Assert
            Assert.Equal(3, resultado);
        }


        [Fact]
        public void SumarNumeros_Input2Numeros_ModeloClasico_ReturnFalse()
        {
            //1. Arrange
            int[] array = new int[] { 1, 2, 3, 4 };

            //2. Act
            int totalCoincidencias = array.Where(x => x == 4).Count();

            //3. Assert
            Assert.Equal(1, totalCoincidencias);
        }


        [Fact]
        public void SumarNumeros_Input2Numeros_ModeloRestricciones()
        {
            //1. Arrange
            int[] array = new int[] { 1, 2, 3, 4 };

            //2. Act
            //3. Assert
            //Assert.That(array, Has.Exactly(1).EqualTo(4));
            //Assert.All(array, item => Assert.Equal(1, item));
            Assert.Contains(4, array);
        }



        [Fact]
        public void EsValorPar_InputNumeroPar_ReturnFalse()
        {
            //1. Arrange
            int numeroImpar = 1;
            CalculadoraBasica calc = new CalculadoraBasica();

            //2. Act
            bool esPar = calc.EsValorPar(numeroImpar);

            //3. Assert
            Assert.False(esPar);
        }

        [Fact]
        public void EsValorPar_InputNumeroPar_ReturnTrue()
        {
            //1. Arrange
            int numeroImpar = 4;
            CalculadoraBasica calc = new CalculadoraBasica();

            //2. Act
            bool esPar = calc.EsValorPar(numeroImpar);

            //3. Assert
            Assert.True(esPar);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(101)]
        [InlineData(33)]
        public void EsValorPar_InputNumeroPar_ReturnFalse_v2(int numeroImpar)
        {
            //1. Arrange
            CalculadoraBasica calc = new CalculadoraBasica();

            //2. Act
            bool esPar = calc.EsValorPar(numeroImpar);

            //3. Assert
            Assert.False(esPar);
        }

        [Theory]
        [InlineData(2, 4, 8)]
        [InlineData(1, 2, 2)]
        [InlineData(60.5, 2, 121)]
        public void Multiplicar_Input2Numero_GetValorCorrecto(decimal numero1, decimal numero2, decimal expectedResult)
        {
            CalculadoraBasica calc = new CalculadoraBasica();

            decimal resultado = calc.Multiplicar(numero1, numero2);

            Assert.Equal(expectedResult, resultado);
        }

        [Theory]
        [InlineData(3.1, 1)]//3.1
        [InlineData(1.5, 2)]//3
        public void Multiplicar_Input2Numero_GetValorCorrectoEnRango(decimal numero1, decimal numero2)
        {
            CalculadoraBasica calc = new CalculadoraBasica();

            decimal resultado = calc.Multiplicar(numero1, numero2);

            Assert.Equal(3, (double)resultado, 0);
        }


    }
}
