using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class __CompraDetalle
    {
        Data.__CompraDetalle dCompraDetalle = new Data.__CompraDetalle();

        public bool AgregarCompraDetalle(Entidades.__CompraDetalle eCompraDetalle)
        {
            return dCompraDetalle.AgregarCompraDetalle(eCompraDetalle);
        }

        public List<Entidades.__CompraDetalle> ListaCompraDetalle()
        {
            return dCompraDetalle.ListaCompraDetalle();
        }

        public List<Entidades.__CompraDetalle> ListaCompraDetalle(string nombreObjeto, string valor)
        {
            return dCompraDetalle.ListaCompraDetalle(nombreObjeto, valor);
        }

        public List<Entidades.__CompraDetalle> ListaCompraDetalle(int IdCompraDetalle)
        {
            return dCompraDetalle.ListaCompraDetalle(IdCompraDetalle);
        }

        public bool EditarCompraDetalle(Entidades.__CompraDetalle eCompraDetalle)
        {
            return dCompraDetalle.EditarCompraDetalle(eCompraDetalle);
        }

        public bool EliminarCompraDetalle(Entidades.__CompraDetalle eCompraDetalle)
        {
            return dCompraDetalle.EliminarCompraDetalle(eCompraDetalle);
        }
    }
}
