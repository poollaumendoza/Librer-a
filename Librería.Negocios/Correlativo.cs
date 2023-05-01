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
	public class Correlativo
	{
		Entidades.Correlativo eCorrelativo = new Entidades.Correlativo();
		Data.Correlativo dCorrelativo = new Data.Correlativo();

		public void AgregarCorrelativo(Entidades.Correlativo eCorrelativo)
		{
			dCorrelativo.AgregarCorrelativo(eCorrelativo);
		}

		public void EliminarCorrelativo(Entidades.Correlativo eCorrelativo)
		{
			dCorrelativo.EliminarCorrelativo(eCorrelativo);
		}

		public void EditarCorrelativo(Entidades.Correlativo eCorrelativo)
		{
			dCorrelativo.EditarCorrelativo(eCorrelativo);
		}

		public ObservableCollection<Entidades.Correlativo> ListaCorrelativo()
		{
			return dCorrelativo.ListaCorrelativo();
		}

		public ObservableCollection<Entidades.Correlativo> ListaCorrelativo(Entidades.Correlativo eCorrelativo)
		{
			return dCorrelativo.ListaCorrelativo(eCorrelativo);
		}

        public string ObtenerAbreviatura(int IdTipoDocumento, string NombreTabla)
        {
            return dCorrelativo.ObtenerAbreviatura(IdTipoDocumento, NombreTabla);
        }

        public string ConstruirCorrelativoDocumento(int IdCorrelativo)
        {
            return dCorrelativo.ConstruirCorrelativoDocumento(IdCorrelativo);
        }

        public string ConstruirCorrelativoArticulo(string codigo)
        {
            return dCorrelativo.ConstruirCorrelativoArticulo(codigo);
        }

        public ObservableCollection<Entidades.Correlativo> ListaSerie(string NombreTabla, string Abreviatura)
        {
            return dCorrelativo.ObtenerSerie(NombreTabla, Abreviatura);
        }

        public void ActualizarCorrelativoArticulo(string NombreTabla, string Abreviatura)
        {
            dCorrelativo.ActualizarCorrelativoArticulo(NombreTabla, Abreviatura);
        }
    }
}