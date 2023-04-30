using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class __Entidad
    {
        Data.__Entidad dEntidad = new Data.__Entidad();

        public bool AgregarEntidad(Entidades.__Entidad eEntidad)
        {
            return dEntidad.AgregarEntidad(eEntidad);
        }

        public List<Entidades.__Entidad> ListaEntidad()
        {
            return dEntidad.ListaEntidad();
        }

        public List<Entidades.__Entidad> ListaEntidad(int IdEntidad)
        {
            return dEntidad.ListaEntidad(IdEntidad);
        }

        public bool EditarEntidad(Entidades.__Entidad eEntidad)
        {
            return dEntidad.EditarEntidad(eEntidad);
        }

        public bool EliminarEntidad(Entidades.__Entidad eEntidad)
        {
            return dEntidad.EliminarEntidad(eEntidad);
        }
    }
}