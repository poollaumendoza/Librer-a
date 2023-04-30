using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class VentaCollection : ObservableCollection<Venta> { }

	public class Venta
	{
		public int IdVenta { get; set; }
		public int IdEmpresa { get; set; }
		public int IdEntidad { get; set; }
		public int IdTipoDocumento { get; set; }
		public int IdUsuario { get; set; }
		public int IdCorrelativo { get; set; }
		public string Correlativo { get; set; }
        public string NroDocumento { get; set; }
		public DateTime FechaVenta { get; set; }
		public DateTime FechaRegistro { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Impuesto { get; set; }
		public decimal Total { get; set; }
		public int IdEstado { get; set; }
	}
}