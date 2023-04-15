using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class Compra
    {
        Data.Compra dCompra = new Data.Compra();

        public bool AgregarCompra(Entidades.Compra eCompra)
        {
            return dCompra.AgregarCompra(eCompra);
        }

        public List<Entidades.Compra> ListaCompra()
        {
            return dCompra.ListaCompra();
        }

        public List<Entidades.Compra> ListaCompra(int IdCompra)
        {
            return dCompra.ListaCompra(IdCompra);
        }

        public bool EditarCompra(Entidades.Compra eCompra)
        {
            return dCompra.EditarCompra(eCompra);
        }

        public bool EliminarCompra(Entidades.Compra eCompra)
        {
            return dCompra.EliminarCompra(eCompra);
        }
    }
}