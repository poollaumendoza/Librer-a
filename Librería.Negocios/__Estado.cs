using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class __Estado
    {
        Data.__Estado dEstado = new Data.__Estado();

        public bool AgregarEstado(Entidades.__Estado eEstado)
        {
            return dEstado.AgregarEstado(eEstado);
        }

        public List<Entidades.__Estado> ListaEstado()
        {
            return dEstado.ListaEstado();
        }

        public List<Entidades.__Estado> ListaEstado(int IdEstado)
        {
            return dEstado.ListaEstado(IdEstado);
        }

        public bool EditarEstado(Entidades.__Estado eEstado)
        {
            return dEstado.EditarEstado(eEstado);
        }

        public bool EliminarEstado(Entidades.__Estado eEstado)
        {
            return dEstado.EliminarEstado(eEstado);
        }
    }
}
