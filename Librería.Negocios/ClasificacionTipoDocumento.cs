using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;
using Librería.Entidades;
using Librería.Data;

namespace Librería.Negocios
{
	public class ClasificacionTipoDocumento
	{
		Entidades.ClasificacionTipoDocumento eClasificacionTipoDocumento = new Entidades.ClasificacionTipoDocumento();
		Data.ClasificacionTipoDocumento dClasificacionTipoDocumento = new Data.ClasificacionTipoDocumento();

		public void AgregarClasificacionTipoDocumento(Entidades.ClasificacionTipoDocumento eClasificacionTipoDocumento)
		{
			dClasificacionTipoDocumento.AgregarClasificacionTipoDocumento(eClasificacionTipoDocumento);
		}

		public void EliminarClasificacionTipoDocumento(Entidades.ClasificacionTipoDocumento eClasificacionTipoDocumento)
		{
			dClasificacionTipoDocumento.EliminarClasificacionTipoDocumento(eClasificacionTipoDocumento);
		}

		public void EditarClasificacionTipoDocumento(Entidades.ClasificacionTipoDocumento eClasificacionTipoDocumento)
		{
			dClasificacionTipoDocumento.EditarClasificacionTipoDocumento(eClasificacionTipoDocumento);
		}

		public ObservableCollection<Entidades.ClasificacionTipoDocumento> ListaClasificacionTipoDocumento()
		{
			return dClasificacionTipoDocumento.ListaClasificacionTipoDocumento();
		}
		public ObservableCollection<Entidades.ClasificacionTipoDocumento> ListaClasificacionTipoDocumento(Entidades.ClasificacionTipoDocumento eClasificacionTipoDocumento)
		{
			return dClasificacionTipoDocumento.ListaClasificacionTipoDocumento(eClasificacionTipoDocumento);
		}
	}
}	

