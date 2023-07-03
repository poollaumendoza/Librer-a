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
	public class Usuario
	{
        Data.Usuario dUsuario = new Data.Usuario();

        public List<Entidades.Usuario> Listar()
        {
            return dUsuario.Listar();
        }

        public int Registrar(Entidades.Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oPersona.IdPersona == 0)
                Mensaje = "Debe seleccionar una persona";
            if (string.IsNullOrEmpty(obj.NombreUsuario) || string.IsNullOrWhiteSpace(obj.NombreUsuario))
                Mensaje = "El nombre del usuario no puede ser vac�o";
            else if (string.IsNullOrEmpty(obj.Contrase�a) || string.IsNullOrWhiteSpace(obj.Contrase�a))
                Mensaje = "La direcci�n del almac�n no puede ser vac�o";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dUsuario.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oPersona.IdPersona == 0)
                Mensaje = "Debe seleccionar una persona";
            if (string.IsNullOrEmpty(obj.NombreUsuario) || string.IsNullOrWhiteSpace(obj.NombreUsuario))
                Mensaje = "El nombre del usuario no puede ser vac�o";
            else if (string.IsNullOrEmpty(obj.Contrase�a) || string.IsNullOrWhiteSpace(obj.Contrase�a))
                Mensaje = "La direcci�n del almac�n no puede ser vac�o";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dUsuario.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dUsuario.Eliminar(id, out Mensaje);
        }
    }
}