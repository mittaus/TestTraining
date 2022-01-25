using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Colector
    {
        public List<int> NumerosPares { get; set; }

        public List<int> ObtenerNumerosPares(int numeroMinimo, int numeroMaximo)
        {
            NumerosPares = new List<int>();
            for (int i = numeroMinimo; i <= numeroMaximo; i++)
            {
                if (i % 2 == 0)
                {
                    NumerosPares.Add(i);
                }
            }

            return NumerosPares;
        }
    }
}
