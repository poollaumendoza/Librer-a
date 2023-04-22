using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class CompraDetalle
    {
        Data.CompraDetalle dCompraDetalle = new Data.CompraDetalle();

        public bool AgregarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
        {
            return dCompraDetalle.AgregarCompraDetalle(eCompraDetalle);
        }

        public List<Entidades.CompraDetalle> ListaCompraDetalle()
        {
            return dCompraDetalle.ListaCompraDetalle();
        }

        public List<Entidades.CompraDetalle> ListaCompraDetalle(string nombreObjeto, string valor)
        {
            return dCompraDetalle.ListaCompraDetalle(nombreObjeto, valor);
        }

        public List<Entidades.CompraDetalle> ListaCompraDetalle(int IdCompraDetalle)
        {
            return dCompraDetalle.ListaCompraDetalle(IdCompraDetalle);
        }

        public bool EditarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
        {
            return dCompraDetalle.EditarCompraDetalle(eCompraDetalle);
        }

        public bool EliminarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
        {
            return dCompraDetalle.EliminarCompraDetalle(eCompraDetalle);
        }
    }
}
