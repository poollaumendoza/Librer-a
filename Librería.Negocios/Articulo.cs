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
	public class Articulo
	{
		Entidades.Articulo eArticulo = new Entidades.Articulo();
		Data.Articulo dArticulo = new Data.Articulo();

		public void AgregarArticulo(Entidades.Articulo eArticulo)
		{
			dArticulo.AgregarArticulo(eArticulo);
		}

		public void EliminarArticulo(Entidades.Articulo eArticulo)
		{
			dArticulo.EliminarArticulo(eArticulo);
		}

		public void EditarArticulo(Entidades.Articulo eArticulo)
		{
			dArticulo.EditarArticulo(eArticulo);
		}

		public ObservableCollection<Entidades.Articulo> ListaArticulo()
		{
			return dArticulo.ListaArticulo();
		}
		public ObservableCollection<Entidades.Articulo> ListaArticulo(Entidades.Articulo eArticulo)
		{
			return dArticulo.ListaArticulo(eArticulo);
		}
	}
}	

