using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librer�a.Entidades
{
	public class EntidadCollection : ObservableCollection<Entidad> { }

	public class Entidad
	{
		public int IdEntidad { get; set; }
		public int IdEmpresa { get; set; }
		public int IdTipoDocumento { get; set; }
		public string NroDocumento { get; set; }
		public string RazonSocial { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }
		public bool EsCliente { get; set; }
		public bool EsProveedor { get; set; }
		public int IdEstado { get; set; }
	}
}

