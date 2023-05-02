using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
    public class MovimientoCollection : ObservableCollection<Movimiento> { }

    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public int IdEmpresa { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int IdEstado { get; set; }
    }
}