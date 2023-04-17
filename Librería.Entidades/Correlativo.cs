using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
    public class Correlativo
    {
        public int IdCorrelativo { get; set; }
        public int IdEmpresa { get; set; }
        public string NombreTabla { get; set; }
        public string Abreviatura { get; set; }
        public string Serie { get; set; }
        public int NroCorrelativo { get; set; }
        public int IdEstado { get; set; }
    }
}