using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
   public class __Articulo
    {
        Data.__Articulo dArticulo = new Data.__Articulo();

        public bool AgregarArticulo(Entidades.__Articulo eArticulo)
        {
            return dArticulo.AgregarArticulo(eArticulo);
        }

        public List<Entidades.__Articulo> ListaArticulo()
        {
            return dArticulo.ListaArticulo();
        }

        public List<Entidades.__Articulo> ListaArticulo(string criterio)
        {
            return dArticulo.ListaArticulo(criterio);
        }

        public List<Entidades.__Articulo> ListaArticulo(Entidades.__Articulo eArticulo)
        {
            return dArticulo.ListaArticulo(eArticulo);
        }

        public bool EditarArticulo(Entidades.__Articulo eArticulo)
        {
            return dArticulo.EditarArticulo(eArticulo);
        }

        public bool EliminarArticulo(Entidades.__Articulo eArticulo)
        {
            return dArticulo.EliminarArticulo(eArticulo);
        }
    }
}
