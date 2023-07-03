using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class EntidadCollection : ObservableCollection<Entidad> { }

	public class Entidad
	{
		public int IdEntidad { get; set; }
		public Empresa oEmpresa { get; set; }
		public TipoDocumento oTipoDocumento { get; set; }
		public string NroDocumento { get; set; }
		public string RazonSocial { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }
		public bool EsCliente { get; set; }
		public bool EsProveedor { get; set; }
		public Estado oEstado { get; set; }
	}
}

