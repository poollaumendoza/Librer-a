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
	public class Estado
	{
        Data.Estado dEstado = new Data.Estado();

        public List<Entidades.Estado> Listar()
        {
            return dEstado.Listar();
        }

        public int Registrar(Entidades.Estado obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreEstado) || string.IsNullOrWhiteSpace(obj.NombreEstado))
                Mensaje = "El nombre del estado no puede ser vacío";

            if (string.IsNullOrEmpty(Mensaje))
                return dEstado.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.Estado obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreEstado) || string.IsNullOrWhiteSpace(obj.NombreEstado))
                Mensaje = "El nombre del estado no puede ser vacío";

            if (string.IsNullOrEmpty(Mensaje))
                return dEstado.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dEstado.Eliminar(id, out Mensaje);
        }
    }
}	

