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
	public class Empresa
	{
		Entidades.Empresa eEmpresa = new Entidades.Empresa();
		Data.Empresa dEmpresa = new Data.Empresa();

		public void AgregarEmpresa(Entidades.Empresa eEmpresa)
		{
			dEmpresa.AgregarEmpresa(eEmpresa);
		}

		public void EliminarEmpresa(Entidades.Empresa eEmpresa)
		{
			dEmpresa.EliminarEmpresa(eEmpresa);
		}

		public void EditarEmpresa(Entidades.Empresa eEmpresa)
		{
			dEmpresa.EditarEmpresa(eEmpresa);
		}

		public ObservableCollection<Entidades.Empresa> ListaEmpresa()
		{
			return dEmpresa.ListaEmpresa();
		}
		public ObservableCollection<Entidades.Empresa> ListaEmpresa(Entidades.Empresa eEmpresa)
		{
			return dEmpresa.ListaEmpresa(eEmpresa);
		}
	}
}	

