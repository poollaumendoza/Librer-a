using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class __VentaDetalle
    {
        Data.__VentaDetalle dVentaDetalle = new Data.__VentaDetalle();

        public bool AgregarVentaDetalle(Entidades.__VentaDetalle eVentaDetalle)
        {
            return dVentaDetalle.AgregarVentaDetalle(eVentaDetalle);
        }

        public List<Entidades.__VentaDetalle> ListaVentaDetalle()
        {
            return dVentaDetalle.ListaVentaDetalle();
        }

        public List<Entidades.__VentaDetalle> ListaVentaDetalle(string nombreObjeto, string valor)
        {
            return dVentaDetalle.ListaVentaDetalle(nombreObjeto, valor);
        }

        public List<Entidades.__VentaDetalle> ListaVentaDetalle(int IdVentaDetalle)
        {
            return dVentaDetalle.ListaVentaDetalle(IdVentaDetalle);
        }

        public bool EditarVentaDetalle(Entidades.__VentaDetalle eVentaDetalle)
        {
            return dVentaDetalle.EditarVentaDetalle(eVentaDetalle);
        }

        public bool EliminarVentaDetalle(Entidades.__VentaDetalle eVentaDetalle)
        {
            return dVentaDetalle.EliminarVentaDetalle(eVentaDetalle);
        }
    }
}