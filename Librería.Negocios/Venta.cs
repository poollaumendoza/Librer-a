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
	public class Venta
	{
        Data.Venta dVenta = new Data.Venta();

        public List<Entidades.Venta> Listar()
        {
            return dVenta.Listar();
        }

        public int Registrar(Entidades.Venta obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un cliente";
            else if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (obj.oUsuario.IdUsuario == 0)
                Mensaje = "Debe seleccionar un usuario";
            else if (obj.oCorrelativo.IdCorrelativo == 0)
                Mensaje = "Debe seleccionar un correlativo";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El n�mero de documento no puede ser vac�o";
            else if (string.IsNullOrEmpty(obj.FechaVenta) || string.IsNullOrWhiteSpace(obj.FechaVenta))
                Mensaje = "La fecha de venta no puede ser vac�a";
            else if (string.IsNullOrEmpty(obj.FechaRegistro) || string.IsNullOrWhiteSpace(obj.FechaRegistro))
                Mensaje = "La fecha de registro no puede ser vac�o";
            else if (obj.SubTotal == 0)
                Mensaje = "El subtotal no puede ser 0";
            else if (obj.Impuesto == 0)
                Mensaje = "El impuesto no puede ser 0";
            else if (obj.Total == 0)
                Mensaje = "El total no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dVenta.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.Venta obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un cliente";
            else if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (obj.oUsuario.IdUsuario == 0)
                Mensaje = "Debe seleccionar un usuario";
            else if (obj.oCorrelativo.IdCorrelativo == 0)
                Mensaje = "Debe seleccionar un correlativo";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El n�mero de documento no puede ser vac�o";
            else if (string.IsNullOrEmpty(obj.FechaVenta) || string.IsNullOrWhiteSpace(obj.FechaVenta))
                Mensaje = "La fecha de venta no puede ser vac�a";
            else if (string.IsNullOrEmpty(obj.FechaRegistro) || string.IsNullOrWhiteSpace(obj.FechaRegistro))
                Mensaje = "La fecha de registro no puede ser vac�o";
            else if (obj.SubTotal == 0)
                Mensaje = "El subtotal no puede ser 0";
            else if (obj.Impuesto == 0)
                Mensaje = "El impuesto no puede ser 0";
            else if (obj.Total == 0)
                Mensaje = "El total no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dVenta.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dVenta.Eliminar(id, out Mensaje);
        }
    }
}