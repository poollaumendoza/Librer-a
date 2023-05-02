using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class MovimientoDetalle
    {
        Data.MovimientoDetalle dMovimientoDetalle = new Data.MovimientoDetalle();

        public void AgregarMovimientoDetalle(Entidades.MovimientoDetalle eMovimientoDetalle)
        {
            dMovimientoDetalle.AgregarMovimientoDetalle(eMovimientoDetalle);
        }
    }
}