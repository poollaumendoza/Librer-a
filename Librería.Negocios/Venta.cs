using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class Venta
    {
        Data.Venta dVenta = new Data.Venta();

        public bool AgregarVenta(Entidades.Venta eVenta)
        {
            return dVenta.AgregarVenta(eVenta);
        }

        public List<Entidades.Venta> ListaVenta()
        {
            return dVenta.ListaVenta();
        }

        public List<Entidades.Venta> ListaVenta(int IdVenta)
        {
            return dVenta.ListaVenta(IdVenta);
        }

        public bool EditarVenta(Entidades.Venta eVenta)
        {
            return dVenta.EditarVenta(eVenta);
        }

        public bool EliminarVenta(Entidades.Venta eVenta)
        {
            return dVenta.EliminarVenta(eVenta);
        }
    }
}
