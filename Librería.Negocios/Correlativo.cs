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
        Data.Correlativo dCorrelativo = new Data.Correlativo();

        public List<Entidades.Correlativo> Listar()
        {
            return dCorrelativo.Listar();
        }

        public int Registrar(Entidades.Correlativo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (string.IsNullOrEmpty(obj.NombreTabla) || string.IsNullOrWhiteSpace(obj.NombreTabla))
                Mensaje = "El nombre de la tabla no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Abreviatura) || string.IsNullOrWhiteSpace(obj.Abreviatura))
                Mensaje = "La abreviatura no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Serie) || string.IsNullOrWhiteSpace(obj.Serie))
                Mensaje = "La abreviatura no puede ser vacío";
            else if (obj.NroCorrelativo == 0)
                Mensaje = "La abreviatura no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dCorrelativo.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.Correlativo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (string.IsNullOrEmpty(obj.NombreTabla) || string.IsNullOrWhiteSpace(obj.NombreTabla))
                Mensaje = "El nombre de la tabla no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Abreviatura) || string.IsNullOrWhiteSpace(obj.Abreviatura))
                Mensaje = "La abreviatura no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Serie) || string.IsNullOrWhiteSpace(obj.Serie))
                Mensaje = "La abreviatura no puede ser vacío";
            else if (obj.NroCorrelativo == 0)
                Mensaje = "La abreviatura no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dCorrelativo.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dCorrelativo.Eliminar(id, out Mensaje);
        }
    }
}