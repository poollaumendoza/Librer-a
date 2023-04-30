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
	public class Almacen
	{
		Entidades.Almacen eAlmacen = new Entidades.Almacen();
		Data.Almacen dAlmacen = new Data.Almacen();

		public void AgregarAlmacen(Entidades.Almacen eAlmacen)
		{
			dAlmacen.AgregarAlmacen(eAlmacen);
		}

		public void EliminarAlmacen(Entidades.Almacen eAlmacen)
		{
			dAlmacen.EliminarAlmacen(eAlmacen);
		}

		public void EditarAlmacen(Entidades.Almacen eAlmacen)
		{
			dAlmacen.EditarAlmacen(eAlmacen);
		}

		public ObservableCollection<Entidades.Almacen> ListaAlmacen()
		{
			return dAlmacen.ListaAlmacen();
		}
		public ObservableCollection<Entidades.Almacen> ListaAlmacen(Entidades.Almacen eAlmacen)
		{
			return dAlmacen.ListaAlmacen(eAlmacen);
		}
	}
}	

