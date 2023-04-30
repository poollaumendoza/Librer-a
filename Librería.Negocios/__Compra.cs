using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class __Compra
    {
        Data.__Compra dCompra = new Data.__Compra();

        public bool AgregarCompra(Entidades.__Compra eCompra)
        {
            return dCompra.AgregarCompra(eCompra);
        }

        public List<Entidades.__Compra> ListaCompra()
        {
            return dCompra.ListaCompra();
        }

        public List<Entidades.__Compra> ListaCompra(int IdCompra)
        {
            return dCompra.ListaCompra(IdCompra);
        }

        public bool EditarCompra(Entidades.__Compra eCompra)
        {
            return dCompra.EditarCompra(eCompra);
        }

        public bool EliminarCompra(Entidades.__Compra eCompra)
        {
            return dCompra.EliminarCompra(eCompra);
        }
    }
}