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
	public class Estado
	{
		Entidades.Estado eEstado = new Entidades.Estado();
		Data.Estado dEstado = new Data.Estado();

		public void AgregarEstado(Entidades.Estado eEstado)
		{
			dEstado.AgregarEstado(eEstado);
		}

		public void EliminarEstado(Entidades.Estado eEstado)
		{
			dEstado.EliminarEstado(eEstado);
		}

		public void EditarEstado(Entidades.Estado eEstado)
		{
			dEstado.EditarEstado(eEstado);
		}

		public ObservableCollection<Entidades.Estado> ListaEstado()
		{
			return dEstado.ListaEstado();
		}
		public ObservableCollection<Entidades.Estado> ListaEstado(Entidades.Estado eEstado)
		{
			return dEstado.ListaEstado(eEstado);
		}
	}
}	

