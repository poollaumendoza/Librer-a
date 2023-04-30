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
	public class Entidad
	{
		Entidades.Entidad eEntidad = new Entidades.Entidad();
		Data.Entidad dEntidad = new Data.Entidad();

		public void AgregarEntidad(Entidades.Entidad eEntidad)
		{
			dEntidad.AgregarEntidad(eEntidad);
		}

		public void EliminarEntidad(Entidades.Entidad eEntidad)
		{
			dEntidad.EliminarEntidad(eEntidad);
		}

		public void EditarEntidad(Entidades.Entidad eEntidad)
		{
			dEntidad.EditarEntidad(eEntidad);
		}

		public ObservableCollection<Entidades.Entidad> ListaEntidad()
		{
			return dEntidad.ListaEntidad();
		}
		public ObservableCollection<Entidades.Entidad> ListaEntidad(Entidades.Entidad eEntidad)
		{
			return dEntidad.ListaEntidad(eEntidad);
		}
	}
}	

