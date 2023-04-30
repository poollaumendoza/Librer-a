using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
    public class __Entidad
    {
        public int IdEntidad { get; set; }
        public int IdEmpresa { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int EsCliente { get; set; }
        public int EsProveedor { get; set; }
        public int IdEstado { get; set; }
    }
}