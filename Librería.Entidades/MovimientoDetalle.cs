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
        public int IdMovimiento { get; set; }
        public int IdArticulo { get; set; }
        public int StockInicial { get; set; }
        public int Ingreso { get; set; }
        public int Salida { get; set; }
        public int IdEstado { get; set; }
    }
}