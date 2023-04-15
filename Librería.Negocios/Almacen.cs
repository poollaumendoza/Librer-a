using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class Almacen
    {
        Data.Almacen dAlmacen = new Data.Almacen();

        public bool AgregarAlmacen(Entidades.Almacen eAlmacen)
        {
            return dAlmacen.AgregarAlmacen(eAlmacen);
        }

        public List<Entidades.Almacen> ListaAlmacen()
        {
            return dAlmacen.ListaAlmacen();
        }

        public List<Entidades.Almacen> ListaAlmacen(int IdAlmacen)
        {
            return dAlmacen.ListaAlmacen(IdAlmacen);
        }

        public bool EditarAlmacen(Entidades.Almacen eAlmacen)
        {
            return dAlmacen.EditarAlmacen(eAlmacen);
        }

        public bool EliminarAlmacen(Entidades.Almacen eAlmacen)
        {
            return dAlmacen.EliminarAlmacen(eAlmacen);
        }
    }
}