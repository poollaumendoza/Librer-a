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
	public class Usuario
	{
		Entidades.Usuario eUsuario = new Entidades.Usuario();
		Data.Usuario dUsuario = new Data.Usuario();

		public void AgregarUsuario(Entidades.Usuario eUsuario)
		{
			dUsuario.AgregarUsuario(eUsuario);
		}

		public void EliminarUsuario(Entidades.Usuario eUsuario)
		{
			dUsuario.EliminarUsuario(eUsuario);
		}

		public void EditarUsuario(Entidades.Usuario eUsuario)
		{
			dUsuario.EditarUsuario(eUsuario);
		}

		public ObservableCollection<Entidades.Usuario> ListaUsuario()
		{
			return dUsuario.ListaUsuario();
		}
		public ObservableCollection<Entidades.Usuario> ListaUsuario(Entidades.Usuario eUsuario)
		{
			return dUsuario.ListaUsuario(eUsuario);
		}
	}
}	

