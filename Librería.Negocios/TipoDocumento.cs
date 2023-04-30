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
	public class TipoDocumento
	{
		Entidades.TipoDocumento eTipoDocumento = new Entidades.TipoDocumento();
		Data.TipoDocumento dTipoDocumento = new Data.TipoDocumento();

		public void AgregarTipoDocumento(Entidades.TipoDocumento eTipoDocumento)
		{
			dTipoDocumento.AgregarTipoDocumento(eTipoDocumento);
		}

		public void EliminarTipoDocumento(Entidades.TipoDocumento eTipoDocumento)
		{
			dTipoDocumento.EliminarTipoDocumento(eTipoDocumento);
		}

		public void EditarTipoDocumento(Entidades.TipoDocumento eTipoDocumento)
		{
			dTipoDocumento.EditarTipoDocumento(eTipoDocumento);
		}

		public ObservableCollection<Entidades.TipoDocumento> ListaTipoDocumento()
		{
			return dTipoDocumento.ListaTipoDocumento();
		}
		public ObservableCollection<Entidades.TipoDocumento> ListaTipoDocumento(Entidades.TipoDocumento eTipoDocumento)
		{
			return dTipoDocumento.ListaTipoDocumento(eTipoDocumento);
		}
	}
}	

