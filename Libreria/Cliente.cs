using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Cliente
    {
        public string NombreCompleto { get; set; }
        public double Deuda = 100;
        public string CrearNombreCompleto(string nombre, string apellido)
        {
            NombreCompleto = $"{nombre} {apellido}";
            return NombreCompleto;
        }

        public void AgregarDescuento10PorCiento(double descuento)
        {
            Deuda = Deuda - (Deuda * 0.1);
        }

        public double ObtenerDeuda()
        {
            return Deuda;
        }
    }
}
