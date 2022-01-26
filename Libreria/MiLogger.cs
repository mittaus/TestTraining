using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public interface IMiLogger
    {
        string Destino { get; set; }
        int Nivel { get; set; }
        void EscribirEnConsola(string mensaje);
        bool EscribirCantidadRetiro(double monto);
        bool EscribirSaldoDespuesRetiro(double saldo);
        string VerMensajeFormateado(string mensaje);
        bool ValidarSaldoConOutPut(double saldo, out string saldoEnTexto);
        bool MensajeConObjetoReferencia(ref Cliente cliente);
    }

    public class MiLogger : IMiLogger
    {
        public string Destino { get; set;}
        public int Nivel { get; set; }

        public void EscribirEnConsola(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public bool EscribirCantidadRetiro(double monto)
        {
            Console.WriteLine($"Está retirando ${monto}");
            return true;
        }

        public bool EscribirSaldoDespuesRetiro(double saldo)
        {
            if (saldo >= 0)
            {
                Console.WriteLine($"Satisfactorio. Su saldo actual es: ${saldo}");
                return true;
            }

            Console.WriteLine($"Error. No tiene saldo suficiente para esta operación. Saldo: ${saldo}");
            return false;
        }

        public string VerMensajeFormateado(string mensaje)
        {
            Console.WriteLine(mensaje);
            return mensaje.ToUpper();
        }

        public bool ValidarSaldoConOutPut(double saldo, out string saldoEnTexto)
        {
            if (saldo > 0)
                saldoEnTexto = $"Saldo positivo. Saldo a favor: ${saldo.ToString("N2")}";
            else
                saldoEnTexto = $"Saldo negativo. Saldo a favor: ${saldo.ToString("N2")}";

            return saldo > 0;
        }

        public bool MensajeConObjetoReferencia(ref Cliente cliente)
        {
            return true;
        }
    }

    public class OtroLogger
    {
        public void Mensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
