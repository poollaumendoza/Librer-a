using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class AlmacenCollection : ObservableCollection<Almacen> { }

	public class Almacen
	{
		public int IdAlmacen { get; set; }
		public string NombreAlmacen { get; set; }
		public string Direccion { get; set; }
		public int IdEstado { get; set; }
	}
}

