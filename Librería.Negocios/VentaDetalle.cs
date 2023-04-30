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
	public class VentaDetalle
	{
		Entidades.VentaDetalle eVentaDetalle = new Entidades.VentaDetalle();
		Data.VentaDetalle dVentaDetalle = new Data.VentaDetalle();

		public void AgregarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
		{
			dVentaDetalle.AgregarVentaDetalle(eVentaDetalle);
		}

		public void EliminarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
		{
			dVentaDetalle.EliminarVentaDetalle(eVentaDetalle);
		}

		public void EditarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
		{
			dVentaDetalle.EditarVentaDetalle(eVentaDetalle);
		}

		public ObservableCollection<Entidades.VentaDetalle> ListaVentaDetalle()
		{
			return dVentaDetalle.ListaVentaDetalle();
		}

		public ObservableCollection<Entidades.VentaDetalle> ListaVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
		{
			return dVentaDetalle.ListaVentaDetalle(eVentaDetalle);
		}
    }
}	

