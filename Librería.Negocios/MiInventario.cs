using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class MiInventario
    {
        Data.MiInventario dMiInventario = new Data.MiInventario();

        public List<Entidades.MiInventario> ListaProductos(bool existencia)
        {
            return dMiInventario.ListaProductos(existencia);
        }
    }
}