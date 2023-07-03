using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class CompraDetalle
	{
		public int IdCompraDetalle { get; set; }
		public Compra oCompra { get; set; }
        public Articulo oArticulo { get; set; }
        public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal Importe { get; set; }
		public Estado oEstado { get; set; }
	}
}