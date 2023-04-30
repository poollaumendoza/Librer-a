using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class VentaDetalleCollection : ObservableCollection<VentaDetalle> { }

	public class VentaDetalle
	{
		public int IdVentaDetalle { get; set; }
		public int IdVenta { get; set; }
		public int Cantidad { get; set; }
		public string Descripcion { get; set; }
		public decimal Precio { get; set; }
		public decimal Importe { get; set; }
		public int IdEstado { get; set; }
	}
}

