using Libreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNUnitTest
{
    public class LoggerFake : IMiLogger
    {
        public string Destino { get; set; }
        public int Nivel { get; set; }

        public bool EscribirCantidadRetiro(double monto)
        {
            return false;
        }

        public void EscribirEnConsola(string mensaje)
        {
        }

        public bool EscribirSaldoDespuesRetiro(double saldo)
        {
            return false;
        }

        public bool MensajeConObjetoReferencia(ref Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool ValidarSaldoConOutPut(double saldo, out string saldoEnTexto)
        {
            throw new NotImplementedException();
        }

        public string VerMensajeFormateado(string mensaje)
        {
            return mensaje;
        }
    }
}
