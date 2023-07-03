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
	public class CompraDetalleDetalle
	{
        Data.CompraDetalle dCompraDetalle = new Data.CompraDetalle();

        public List<Entidades.CompraDetalle> Listar()
        {
            return dCompraDetalle.Listar();
        }

        public int Registrar(Entidades.CompraDetalle obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oCompra.IdCompra == 0)
                Mensaje = "Debe seleccionar una CompraDetalle";
            else if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un art�culo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.Precio == 0)
                Mensaje = "El precio no puede ser 0";
            else if (obj.Importe == 0)
                Mensaje = "El importe no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dCompraDetalle.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.CompraDetalle obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oCompra.IdCompra == 0)
                Mensaje = "Debe seleccionar una CompraDetalle";
            else if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un art�culo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.Precio == 0)
                Mensaje = "El precio no puede ser 0";
            else if (obj.Importe == 0)
                Mensaje = "El importe no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dCompraDetalle.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dCompraDetalle.Eliminar(id, out Mensaje);
        }
    }
}