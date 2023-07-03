using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class Correlativo
	{
		public int IdCorrelativo { get; set; }
		public Empresa oEmpresa { get; set; }
        public TipoDocumento oTipoDocumento { get; set; }
		public string NombreTabla { get; set; }
		public string Abreviatura { get; set; }
		public string Serie { get; set; }
		public int NroCorrelativo { get; set; }
        public Estado oEstado { get; set; }
	}
}