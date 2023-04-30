using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librer�a.Entidades
{
	public class CompraDetalleCollection : ObservableCollection<CompraDetalle> { }

	public class CompraDetalle
	{
		public int IdCompraDetalle { get; set; }
		public int IdCompra { get; set; }
		public int Cantidad { get; set; }
		public string Descripcion { get; set; }
		public decimal Precio { get; set; }
		public decimal Importe { get; set; }
		public int IdEstado { get; set; }
	}
}

