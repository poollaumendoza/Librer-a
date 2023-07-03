using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librer�a.Entidades
{
	public class TipoDocumentoCollection : ObservableCollection<TipoDocumento> { }

	public class TipoDocumento
	{
		public int IdTipoDocumento { get; set; }
		public ClasificacionTipoDocumento oClasificacionTipoDocumento { get; set; }
		public string NombreTipoDocumento { get; set; }
		public Estado oEstado { get; set; }
	}
}

