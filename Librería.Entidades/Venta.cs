using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class Venta
	{
		public int IdVenta { get; set; }
		public Empresa oEmpresa { get; set; }
		public Entidad oEntidad { get; set; }
		public TipoDocumento oTipoDocumento { get; set; }
		public Usuario oUsuario { get; set; }
		public Correlativo oCorrelativo { get; set; }
        public string NroDocumento { get; set; }
		public string FechaVenta { get; set; }
		public string FechaRegistro { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Impuesto { get; set; }
		public decimal Total { get; set; }
		public Estado oEstado { get; set; }
        public List<VentaDetalle> oListaVenta { get; set; }
    }
}