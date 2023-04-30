using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class __Almacen
    {
        Data.__Almacen dAlmacen = new Data.__Almacen();

        public bool AgregarAlmacen(Entidades.__Almacen eAlmacen)
        {
            return dAlmacen.AgregarAlmacen(eAlmacen);
        }

        public List<Entidades.__Almacen> ListaAlmacen()
        {
            return dAlmacen.ListaAlmacen();
        }

        public List<Entidades.__Almacen> ListaAlmacen(int IdAlmacen)
        {
            return dAlmacen.ListaAlmacen(IdAlmacen);
        }

        public bool EditarAlmacen(Entidades.__Almacen eAlmacen)
        {
            return dAlmacen.EditarAlmacen(eAlmacen);
        }

        public bool EliminarAlmacen(Entidades.__Almacen eAlmacen)
        {
            return dAlmacen.EliminarAlmacen(eAlmacen);
        }
    }
}