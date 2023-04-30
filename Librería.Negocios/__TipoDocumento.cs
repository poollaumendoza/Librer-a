using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class __TipoDocumento
    {
        Data.__TipoDocumento dTipoDocumento = new Data.__TipoDocumento();

        public bool AgregarTipoDocumento(Entidades.__TipoDocumento eTipoDocumento)
        {
            return dTipoDocumento.AgregarTipoDocumento(eTipoDocumento);
        }

        public List<Entidades.__TipoDocumento> ListaTipoDocumento()
        {
            return dTipoDocumento.ListaTipoDocumento();
        }

        public List<Entidades.__TipoDocumento> ListaTipoDocumento(int IdTipoDocumento)
        {
            return dTipoDocumento.ListaTipoDocumento(IdTipoDocumento);
        }

        public bool EditarTipoDocumento(Entidades.__TipoDocumento eTipoDocumento)
        {
            return dTipoDocumento.EditarTipoDocumento(eTipoDocumento);
        }

        public bool EliminarTipoDocumento(Entidades.__TipoDocumento eTipoDocumento)
        {
            return dTipoDocumento.EliminarTipoDocumento(eTipoDocumento);
        }
    }
}