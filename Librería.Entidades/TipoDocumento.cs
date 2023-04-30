using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class TipoDocumentoCollection : ObservableCollection<TipoDocumento> { }

	public class TipoDocumento
	{
		public int IdTipoDocumento { get; set; }
		public int IdClasificacionTipoDocumento { get; set; }
		public string NombreTipoDocumento { get; set; }
		public int IdEstado { get; set; }
	}
}

