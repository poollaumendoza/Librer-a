using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librer�a.Entidades
{
	public class Empresa
	{
		public int IdEmpresa { get; set; }
		public TipoDocumento oTipoDocumento { get; set; }
		public string NroDocumento { get; set; }
		public string RazonSocial { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }
		public Estado oEstado { get; set; }
	}
}