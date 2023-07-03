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
	public class Persona
	{
        Data.Persona dPersona = new Data.Persona();

        public List<Entidades.Persona> Listar()
        {
            return dPersona.Listar();
        }

        public int Registrar(Entidades.Persona obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El número de documento no puede ser vacío";
            else if(string.IsNullOrEmpty(obj.ApellidoPaterno) || string.IsNullOrWhiteSpace(obj.ApellidoPaterno))
                Mensaje = "El apellido paterno no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.ApellidoMaterno) || string.IsNullOrWhiteSpace(obj.ApellidoMaterno))
                Mensaje = "El apellido materno no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
                Mensaje = "El primer nombre no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.SegundoNombre) || string.IsNullOrWhiteSpace(obj.SegundoNombre))
                Mensaje = "El segundo nombre no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
                Mensaje = "El nombre del almacén no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
                Mensaje = "La dirección del almacén no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
                Mensaje = "La dirección del almacén no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPersona.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.Persona obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.ApellidoPaterno) || string.IsNullOrWhiteSpace(obj.ApellidoPaterno))
                Mensaje = "El apellido paterno no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.ApellidoMaterno) || string.IsNullOrWhiteSpace(obj.ApellidoMaterno))
                Mensaje = "El apellido materno no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
                Mensaje = "El primer nombre no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.SegundoNombre) || string.IsNullOrWhiteSpace(obj.SegundoNombre))
                Mensaje = "El segundo nombre no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
                Mensaje = "El nombre del almacén no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
                Mensaje = "La dirección del almacén no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
                Mensaje = "La dirección del almacén no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPersona.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dPersona.Eliminar(id, out Mensaje);
        }
    }
}