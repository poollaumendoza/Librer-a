using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class Entidad
    {
        Data.Entidad dEntidad = new Data.Entidad();

        public bool AgregarEntidad(Entidades.Entidad eEntidad)
        {
            return dEntidad.AgregarEntidad(eEntidad);
        }

        public List<Entidades.Entidad> ListaEntidad()
        {
            return dEntidad.ListaEntidad();
        }

        public List<Entidades.Entidad> ListaEntidad(int IdEntidad)
        {
            return dEntidad.ListaEntidad(IdEntidad);
        }

        public bool EditarEntidad(Entidades.Entidad eEntidad)
        {
            return dEntidad.EditarEntidad(eEntidad);
        }

        public bool EliminarEntidad(Entidades.Entidad eEntidad)
        {
            return dEntidad.EliminarEntidad(eEntidad);
        }
    }
}