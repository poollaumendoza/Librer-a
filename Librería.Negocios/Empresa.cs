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
    public class Empresa
    {
        Data.Empresa dEmpresa = new Data.Empresa();

        public List<Entidades.Empresa> Listar()
        {
            return dEmpresa.Listar();
        }

        public int Registrar(Entidades.Empresa obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oTipoDocumento.IdTipoDocumento == 0)
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
                Mensaje = "Debe seleccionar un estado para este Empresa";

            if (string.IsNullOrEmpty(Mensaje))
                return dEmpresa.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.Empresa obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oTipoDocumento.IdTipoDocumento == 0)
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
                Mensaje = "Debe seleccionar un estado para este Empresa";

            if (string.IsNullOrEmpty(Mensaje))
                return dEmpresa.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dEmpresa.Eliminar(id, out Mensaje);
        }
    }
}