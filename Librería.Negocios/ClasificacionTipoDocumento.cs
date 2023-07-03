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
	public class ClasificacionTipoDocumento
	{
        Data.ClasificacionTipoDocumento dClasificacionTipoDocumento = new Data.ClasificacionTipoDocumento();

        public List<Entidades.ClasificacionTipoDocumento> Listar()
        {
            return dClasificacionTipoDocumento.Listar();
        }

        public int Registrar(Entidades.ClasificacionTipoDocumento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreClasificacionTipoDocumento) || string.IsNullOrWhiteSpace(obj.NombreClasificacionTipoDocumento))
                Mensaje = "El nombre del almacén no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dClasificacionTipoDocumento.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.ClasificacionTipoDocumento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreClasificacionTipoDocumento) || string.IsNullOrWhiteSpace(obj.NombreClasificacionTipoDocumento))
                Mensaje = "El nombre del almacén no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dClasificacionTipoDocumento.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dClasificacionTipoDocumento.Eliminar(id, out Mensaje);
        }
    }
}