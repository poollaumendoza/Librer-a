using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public string IdEmpresa { get; set; }
        public string IdProveedor { get; set; }
        public string IdTipoDocumento { get; set; }
        public string IdUsuario { get; set; }
        public string NroDocumento { get; set; }
        public string FechaCompra { get; set; }
        public string FechaRegistro { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public int IdEstado { get; set; }
    }
}