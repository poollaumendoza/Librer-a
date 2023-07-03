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
	public class VentaDetalle
	{
        Data.VentaDetalle dVentaDetalle = new Data.VentaDetalle();

        public List<Entidades.VentaDetalle> Listar()
        {
            return dVentaDetalle.Listar();
        }

        public int Registrar(Entidades.VentaDetalle obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oVenta.IdVenta == 0)
                Mensaje = "Debe seleccionar una venta";
            else if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un artículo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.Precio == 0)
                Mensaje = "La precio no puede ser 0";
            else if (obj.Importe == 0)
                Mensaje = "La importe no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dVentaDetalle.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.VentaDetalle obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oVenta.IdVenta == 0)
                Mensaje = "Debe seleccionar una venta";
            else if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un artículo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.Precio == 0)
                Mensaje = "La precio no puede ser 0";
            else if (obj.Importe == 0)
                Mensaje = "La importe no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dVentaDetalle.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dVentaDetalle.Eliminar(id, out Mensaje);
        }
    }
}