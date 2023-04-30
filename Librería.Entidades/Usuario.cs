using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
	public class UsuarioCollection : ObservableCollection<Usuario> { }

	public class Usuario
	{
		public int IdUsuario { get; set; }
		public int IdPersona { get; set; }
		public string NombreUsuario { get; set; }
		public string Contraseña { get; set; }
		public int IdEstado { get; set; }
	}
}

