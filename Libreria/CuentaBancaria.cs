using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class CuentaBancaria
    {
        private readonly IMiLogger _logger;
        public double Saldo { get; set; }

        public CuentaBancaria(IMiLogger logger)
        {
            _logger = logger;
            Saldo = 0;
        }

        public bool Depositar(double monto)
        {
            this._logger.Nivel = 1;
            _logger.EscribirEnConsola($"Está depositando el monto de: ${monto}");

            this._logger.Nivel = 2;
            //this._logger.Nivel = 2;
            _logger.EscribirEnConsola("Se usa otra vez");

            this._logger.Nivel = 3;
            _logger.EscribirEnConsola("Desde las pruebas unitarias");

            Saldo += monto;
            return true;
        }

        public bool Retirar(double monto)
        {
            if (monto <= Saldo)
            {
                _logger.EscribirCantidadRetiro(monto);
                Saldo -= monto;
                return _logger.EscribirSaldoDespuesRetiro(Saldo);
            }

            return _logger.EscribirSaldoDespuesRetiro(Saldo);
        }

        public double ObtenerBalance()
        {
            return Saldo;
        }
    }
}
