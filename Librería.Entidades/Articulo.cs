using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class ArticuloCollection : ObservableCollection<Articulo> { }

	public class Articulo
	{
		public int IdArticulo { get; set; }
		public int IdEmpresa { get; set; }
		public int IdEntidad { get; set; }
		public string CodigoArticulo { get; set; }
		public string DescripcionArticulo { get; set; }
		public int Cantidad { get; set; }
		public decimal PrecioCompra { get; set; }
		public decimal PrecioVenta { get; set; }
		public int IdEstado { get; set; }
	}
}

