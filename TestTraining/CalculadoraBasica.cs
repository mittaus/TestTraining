using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class CalculadoraBasica
    {
        public decimal Sumar(decimal a, decimal b)
        {
            return a + b;
        }

        public decimal Restar(decimal a, decimal b)
        {
            return a + b;
        }

        public decimal Multiplicar(decimal a, decimal b)
        {
            return a * b;
        }


        public decimal Dividir(decimal a, decimal b)
        {
            return a / b;
        }

        public bool EsValorPar(int numero)
        {
            return numero % 2 == 0;
        }
    }
}
