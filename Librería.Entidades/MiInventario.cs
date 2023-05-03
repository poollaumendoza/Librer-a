using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
    public class MiInventario
    {
        public string CodigoArticulo { get; set; }
        public string RazonSocial { get; set; }
        public string DescripcionArticulo { get; set; }
        public int Inicial { get; set; }
        public int Ingreso { get; set; }
        public int Salida { get; set; }
        public int Existencia { get; set; }
    }
}