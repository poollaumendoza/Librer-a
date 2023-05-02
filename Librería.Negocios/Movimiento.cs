using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class Movimiento
    {
        Data.Movimiento dMovimiento = new Data.Movimiento();

        public int AgregarMovimiento(Entidades.Movimiento eMovimiento)
        {
            return dMovimiento.AgregarMovimiento(eMovimiento);
        }
    }
}