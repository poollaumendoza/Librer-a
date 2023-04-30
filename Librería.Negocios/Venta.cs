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
	public class Venta
	{
		Entidades.Venta eVenta = new Entidades.Venta();
		Data.Venta dVenta = new Data.Venta();

		public int AgregarVenta(Entidades.Venta eVenta)
		{
			return dVenta.AgregarVenta(eVenta);
		}

		public void EliminarVenta(Entidades.Venta eVenta)
		{
			dVenta.EliminarVenta(eVenta);
		}

		public void EditarVenta(Entidades.Venta eVenta)
		{
			dVenta.EditarVenta(eVenta);
		}

		public ObservableCollection<Entidades.Venta> ListaVenta()
		{
			return dVenta.ListaVenta();
		}
		public ObservableCollection<Entidades.Venta> ListaVenta(Entidades.Venta eVenta)
		{
			return dVenta.ListaVenta(eVenta);
		}
	}
}	

