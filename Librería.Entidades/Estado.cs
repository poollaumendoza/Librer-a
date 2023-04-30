using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class EstadoCollection : ObservableCollection<Estado> { }

	public class Estado
	{
		public int IdEstado { get; set; }
		public string NombreEstado { get; set; }
	}
}

