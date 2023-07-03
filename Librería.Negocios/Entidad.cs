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
	public class Entidad
	{
        Data.Entidad dEntidad = new Data.Entidad();

        public List<Entidades.Entidad> Listar()
        {
            return dEntidad.Listar();
        }

        public int Registrar(Entidades.Entidad obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.RazonSocial) || string.IsNullOrWhiteSpace(obj.RazonSocial))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
                Mensaje = "El número de documento no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dEntidad.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.Entidad obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.RazonSocial) || string.IsNullOrWhiteSpace(obj.RazonSocial))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
                Mensaje = "El número de documento no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dEntidad.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dEntidad.Eliminar(id, out Mensaje);
        }
    }
}	

