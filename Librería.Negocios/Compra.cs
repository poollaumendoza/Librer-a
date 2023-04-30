using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;
using Librer�a.Entidades;
using Librer�a.Data;

namespace Librer�a.Negocios
{
	public class Compra
	{
		Entidades.Compra eCompra = new Entidades.Compra();
		Data.Compra dCompra = new Data.Compra();

		public int AgregarCompra(Entidades.Compra eCompra)
		{
			return dCompra.AgregarCompra(eCompra);
		}

		public void EliminarCompra(Entidades.Compra eCompra)
		{
			dCompra.EliminarCompra(eCompra);
		}

		public void EditarCompra(Entidades.Compra eCompra)
		{
			dCompra.EditarCompra(eCompra);
		}

		public ObservableCollection<Entidades.Compra> ListaCompra()
		{
			return dCompra.ListaCompra();
		}
		public ObservableCollection<Entidades.Compra> ListaCompra(Entidades.Compra eCompra)
		{
			return dCompra.ListaCompra(eCompra);
		}
	}
}	

