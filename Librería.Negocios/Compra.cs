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
	public class Compra
	{
        Data.Compra dCompra = new Data.Compra();

        public List<Entidades.Compra> Listar()
        {
            return dCompra.Listar();
        }

        public int Registrar(Entidades.Compra obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (obj.oUsuario.IdUsuario == 0)
                Mensaje = "Debe seleccionar un usuario";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.FechaCompra) || string.IsNullOrWhiteSpace(obj.FechaCompra))
                Mensaje = "Debe seleccionar una fecha";
            else if (string.IsNullOrEmpty(obj.FechaRegistro) || string.IsNullOrWhiteSpace(obj.FechaRegistro))
                Mensaje = "Debe seleccionar una fecha";
            else if(obj.SubTotal == 0)
                Mensaje = "El subtotal no puede ser 0";
            else if (obj.Impuesto == 0)
                Mensaje = "El impuesto no puede ser 0";
            else if (obj.Total == 0)
                Mensaje = "El total no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dCompra.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.Compra obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (obj.oUsuario.IdUsuario == 0)
                Mensaje = "Debe seleccionar un usuario";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.FechaCompra) || string.IsNullOrWhiteSpace(obj.FechaCompra))
                Mensaje = "Debe seleccionar una fecha";
            else if (string.IsNullOrEmpty(obj.FechaRegistro) || string.IsNullOrWhiteSpace(obj.FechaRegistro))
                Mensaje = "Debe seleccionar una fecha";
            else if (obj.SubTotal == 0)
                Mensaje = "El subtotal no puede ser 0";
            else if (obj.Impuesto == 0)
                Mensaje = "El impuesto no puede ser 0";
            else if (obj.Total == 0)
                Mensaje = "El total no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dCompra.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dCompra.Eliminar(id, out Mensaje);
        }
    }
}