using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class VentaDetalle
    {
        Data.VentaDetalle dVentaDetalle = new Data.VentaDetalle();

        public bool AgregarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
        {
            return dVentaDetalle.AgregarVentaDetalle(eVentaDetalle);
        }

        public List<Entidades.VentaDetalle> ListaVentaDetalle()
        {
            return dVentaDetalle.ListaVentaDetalle();
        }

        public List<Entidades.VentaDetalle> ListaVentaDetalle(string nombreObjeto, string valor)
        {
            return dVentaDetalle.ListaVentaDetalle(nombreObjeto, valor);
        }

        public List<Entidades.VentaDetalle> ListaVentaDetalle(int IdVentaDetalle)
        {
            return dVentaDetalle.ListaVentaDetalle(IdVentaDetalle);
        }

        public bool EditarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
        {
            return dVentaDetalle.EditarVentaDetalle(eVentaDetalle);
        }

        public bool EliminarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
        {
            return dVentaDetalle.EliminarVentaDetalle(eVentaDetalle);
        }
    }
}