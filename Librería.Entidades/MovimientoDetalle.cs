using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
    public class MovimientoDetalleCollection : ObservableCollection<MovimientoDetalle> { }

    public class MovimientoDetalle
    {
        public int IdMovimientoDetalle { get; set; }
        public Movimiento oMovimiento { get; set; }
        public Articulo oArticulo { get; set; }
        public int Cantidad { get; set; }
        public Estado oEstado { get; set; }
    }
}