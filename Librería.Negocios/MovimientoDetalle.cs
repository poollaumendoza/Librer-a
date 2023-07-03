using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librería.Data;

namespace Librería.Negocios
{
    public class MovimientoDetalle
    {
        Data.MovimientoDetalle dMovimientoDetalle = new Data.MovimientoDetalle();

        public List<Entidades.MovimientoDetalle> Listar()
        {
            return dMovimientoDetalle.Listar();
        }

        public int Registrar(Entidades.MovimientoDetalle obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oMovimiento.IdMovimiento == 0)
                Mensaje = "Debe seleccionar un movimiento";
            else if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un artículo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dMovimientoDetalle.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.MovimientoDetalle obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oMovimiento.IdMovimiento == 0)
                Mensaje = "Debe seleccionar un movimiento";
            else if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un artículo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dMovimientoDetalle.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dMovimientoDetalle.Eliminar(id, out Mensaje);
        }
    }
}