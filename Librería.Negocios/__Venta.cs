using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class __Venta
    {
        Data.__Venta dVenta = new Data.__Venta();

        public bool AgregarVenta(Entidades.__Venta eVenta)
        {
            return dVenta.AgregarVenta(eVenta);
        }

        public List<Entidades.__Venta> ListaVenta()
        {
            return dVenta.ListaVenta();
        }

        public List<Entidades.__Venta> ListaVenta(int IdVenta)
        {
            return dVenta.ListaVenta(IdVenta);
        }

        public bool EditarVenta(Entidades.__Venta eVenta)
        {
            return dVenta.EditarVenta(eVenta);
        }

        public bool EliminarVenta(Entidades.__Venta eVenta)
        {
            return dVenta.EliminarVenta(eVenta);
        }
    }
}
