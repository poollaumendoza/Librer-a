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
	public class TipoDocumento
	{
        Data.TipoDocumento dTipoDocumento = new Data.TipoDocumento();

        public List<Entidades.TipoDocumento> Listar()
        {
            return dTipoDocumento.Listar();
        }

        public int Registrar(Entidades.TipoDocumento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oClasificacionTipoDocumento.IdClasificacionTipoDocumento == 0)
                Mensaje = "Debe seleccionar una clasificación";
            else if (string.IsNullOrEmpty(obj.NombreTipoDocumento) || string.IsNullOrWhiteSpace(obj.NombreTipoDocumento))
                Mensaje = "El nombre no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dTipoDocumento.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.TipoDocumento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oClasificacionTipoDocumento.IdClasificacionTipoDocumento == 0)
                Mensaje = "Debe seleccionar una clasificación";
            else if (string.IsNullOrEmpty(obj.NombreTipoDocumento) || string.IsNullOrWhiteSpace(obj.NombreTipoDocumento))
                Mensaje = "El nombre no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dTipoDocumento.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dTipoDocumento.Eliminar(id, out Mensaje);
        }
    }
}