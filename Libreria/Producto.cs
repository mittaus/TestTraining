using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public double ObtenerPrecio(Cliente cliente)
        {
            if (cliente.EsAdultoMayor)
            {
                return Precio * 0.9;
            }

            return Precio;
        }

        public double ObtenerPrecio(ICliente cliente)
        {
            if (cliente.EsAdultoMayor)
            {
                return Precio * 0.9;
            }

            return Precio;
        }

    }
}
