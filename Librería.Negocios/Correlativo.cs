using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class Correlativo
    {
        Data.Correlativo dCorrelativo = new Data.Correlativo();

        public bool AgregarCorrelativo(Entidades.Correlativo eCorrelativo)
        {
            return dCorrelativo.AgregarCorrelativo(eCorrelativo);
        }

        public string ConstruirCorrelativoArticulo(string codigo)
        {
            return dCorrelativo.ConstruirCorrelativoArticulo(codigo);
        }

        public string ConstruirCorrelativoDocumento(int IdCorrelativo)
        {
            return dCorrelativo.ConstruirCorrelativoDocumento(IdCorrelativo);
        }

        public List<Entidades.Correlativo> ListaCorrelativo()
        {
            return dCorrelativo.ListaCorrelativo();
        }

        public List<Entidades.Correlativo> ListaCorrelativo(int IdCorrelativo)
        {
            return dCorrelativo.ListaCorrelativo(IdCorrelativo);
        }

        public List<Entidades.Correlativo> ListaCorrelativo(string Abreviatura)
        {
            return dCorrelativo.ListaCorrelativo(Abreviatura);
        }

        public bool EditarCorrelativo(Entidades.Correlativo eCorrelativo)
        {
            return dCorrelativo.EditarCorrelativo(eCorrelativo);
        }

        public bool EliminarCorrelativo(Entidades.Correlativo eCorrelativo)
        {
            return dCorrelativo.EliminarCorrelativo(eCorrelativo);
        }

        public List<Entidades.Correlativo> ObtenerSerie(string NombreTabla, string Abreviatura)
        {
            return dCorrelativo.ObtenerSerie(NombreTabla, Abreviatura);
        }

        public int ObtenerCorrelativo(int IdCorrelativo)
        {
            return dCorrelativo.ObtenerCorrelativo(IdCorrelativo);
        }
    }
}