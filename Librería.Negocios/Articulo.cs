using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
   public class Articulo
    {
        Data.Articulo dArticulo = new Data.Articulo();

        public bool AgregarArticulo(Entidades.Articulo eArticulo)
        {
            return dArticulo.AgregarArticulo(eArticulo);
        }

        public List<Entidades.Articulo> ListaArticulo()
        {
            return dArticulo.ListaArticulo();
        }

        public List<Entidades.Articulo> ListaArticulo(int IdArticulo)
        {
            return dArticulo.ListaArticulo(IdArticulo);
        }

        public bool EditarArticulo(Entidades.Articulo eArticulo)
        {
            return dArticulo.EditarArticulo(eArticulo);
        }

        public bool EliminarArticulo(Entidades.Articulo eArticulo)
        {
            return dArticulo.EliminarArticulo(eArticulo);
        }
    }
}
