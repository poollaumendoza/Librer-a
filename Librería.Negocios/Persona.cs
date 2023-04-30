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
	public class Persona
	{
		Entidades.Persona ePersona = new Entidades.Persona();
		Data.Persona dPersona = new Data.Persona();

		public void AgregarPersona(Entidades.Persona ePersona)
		{
			dPersona.AgregarPersona(ePersona);
		}

		public void EliminarPersona(Entidades.Persona ePersona)
		{
			dPersona.EliminarPersona(ePersona);
		}

		public void EditarPersona(Entidades.Persona ePersona)
		{
			dPersona.EditarPersona(ePersona);
		}

		public ObservableCollection<Entidades.Persona> ListaPersona()
		{
			return dPersona.ListaPersona();
		}
		public ObservableCollection<Entidades.Persona> ListaPersona(Entidades.Persona ePersona)
		{
			return dPersona.ListaPersona(ePersona);
		}
	}
}	

