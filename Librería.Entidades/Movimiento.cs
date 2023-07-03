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
        public Empresa oEmpresa { get; set; }
        public TipoMovimiento oTipoMovimiento { get; set; }
        public Usuario oUsuario { get; set; }
        public string FechaMovimiento { get; set; }
        public string NroMovimiento { get; set; }
        public Estado oEstado { get; set; }
        public List<Movimiento> oListaMovimiento { get; set; }
    }
}