using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class CompraCollection : ObservableCollection<Compra> { }

	public class Compra
	{
		public int IdCompra { get; set; }
		public int IdEmpresa { get; set; }
		public int IdEntidad { get; set; }
		public int IdTipoDocumento { get; set; }
		public int IdUsuario { get; set; }
		public string NroDocumento { get; set; }
		public DateTime FechaCompra { get; set; }
		public DateTime FechaRegistro { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Impuesto { get; set; }
		public decimal Total { get; set; }
		public int IdEstado { get; set; }
	}
}

