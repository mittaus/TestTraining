using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public interface ICliente
    {
        int Edad { get; set; }
        bool EsAdultoMayor { get; set; }
        string NombreCompleto { get; set; }

        void AgregarDescuento10PorCiento(double descuento);
        string CrearNombreCompleto(string nombre, string apellido);
        double ObtenerDeuda();
        SegmentoCliente ObtenerSegmentoCliente();
    }

    public class Cliente : ICliente
    {
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
        public double Deuda { get; set; }
        public bool EsAdultoMayor { get; set; }

        public Cliente()
        {
            Deuda = 100;
            EsAdultoMayor = false;
        }

        public string CrearNombreCompleto(string nombre, string apellido)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("Ingrese nombre");
            }

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

        public SegmentoCliente ObtenerSegmentoCliente()
        {
            if (Edad < 18)
                return new ClienteMenorEdad();

            return new ClienteMayorEdad();
        }
    }

    public class SegmentoCliente { }

    public class ClienteMenorEdad : SegmentoCliente { }
    public class ClienteMayorEdad : SegmentoCliente { }
    public class ClienteAdultoMayor : SegmentoCliente { }

}
