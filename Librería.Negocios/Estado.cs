using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class Estado
    {
        Data.Estado dEstado = new Data.Estado();

        public bool AgregarEstado(Entidades.Estado eEstado)
        {
            return dEstado.AgregarEstado(eEstado);
        }

        public List<Entidades.Estado> ListaEstado()
        {
            return dEstado.ListaEstado();
        }

        public List<Entidades.Estado> ListaEstado(int IdEstado)
        {
            return dEstado.ListaEstado(IdEstado);
        }

        public bool EditarEstado(Entidades.Estado eEstado)
        {
            return dEstado.EditarEstado(eEstado);
        }

        public bool EliminarEstado(Entidades.Estado eEstado)
        {
            return dEstado.EliminarEstado(eEstado);
        }
    }
}
