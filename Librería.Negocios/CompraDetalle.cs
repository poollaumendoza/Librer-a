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
	public class CompraDetalle
	{
		Entidades.CompraDetalle eCompraDetalle = new Entidades.CompraDetalle();
		Data.CompraDetalle dCompraDetalle = new Data.CompraDetalle();

		public void AgregarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
		{
			dCompraDetalle.AgregarCompraDetalle(eCompraDetalle);
		}

		public void EliminarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
		{
			dCompraDetalle.EliminarCompraDetalle(eCompraDetalle);
		}

		public void EditarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
		{
			dCompraDetalle.EditarCompraDetalle(eCompraDetalle);
		}

		public ObservableCollection<Entidades.CompraDetalle> ListaCompraDetalle()
		{
			return dCompraDetalle.ListaCompraDetalle();
		}

		public ObservableCollection<Entidades.CompraDetalle> ListaCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
		{
			return dCompraDetalle.ListaCompraDetalle(eCompraDetalle);
		}

        public List<Entidades.CompraDetalle> ListaCompraDetalle(string nombreObjeto, string valor)
        {
            return dCompraDetalle.ListaCompraDetalle(nombreObjeto, valor);
        }

    }
}