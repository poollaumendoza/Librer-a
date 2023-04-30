using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class ClasificacionTipoDocumentoCollection : ObservableCollection<ClasificacionTipoDocumento> { }

	public class ClasificacionTipoDocumento
	{
		public int IdClasificacionTipoDocumento { get; set; }
		public string NombreClasificacionTipoDocumento { get; set; }
		public int IdEstado { get; set; }
	}
}

