using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class TipoDocumento
    {
        Data.TipoDocumento dTipoDocumento = new Data.TipoDocumento();

        public bool AgregarTipoDocumento(Entidades.TipoDocumento eTipoDocumento)
        {
            return dTipoDocumento.AgregarTipoDocumento(eTipoDocumento);
        }

        public List<Entidades.TipoDocumento> ListaTipoDocumento()
        {
            return dTipoDocumento.ListaTipoDocumento();
        }

        public List<Entidades.TipoDocumento> ListaTipoDocumento(int IdTipoDocumento)
        {
            return dTipoDocumento.ListaTipoDocumento(IdTipoDocumento);
        }

        public bool EditarTipoDocumento(Entidades.TipoDocumento eTipoDocumento)
        {
            return dTipoDocumento.EditarTipoDocumento(eTipoDocumento);
        }

        public bool EliminarTipoDocumento(Entidades.TipoDocumento eTipoDocumento)
        {
            return dTipoDocumento.EliminarTipoDocumento(eTipoDocumento);
        }
    }
}