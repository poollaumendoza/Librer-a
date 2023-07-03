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
    public class Articulo
    {
        Data.Articulo dArticulo = new Data.Articulo();

        public List<Entidades.Articulo> Listar()
        {
            return dArticulo.Listar();
        }

        public int Registrar(Entidades.Articulo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar una entidad";
            else if (string.IsNullOrEmpty(obj.CodigoArticulo) || string.IsNullOrWhiteSpace(obj.CodigoArticulo))
                Mensaje = "El código del artículo no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.DescripcionArticulo) || string.IsNullOrWhiteSpace(obj.DescripcionArticulo))
                Mensaje = "La descripción del artículo no puede ser vacía";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad del artículo no puede ser 0";
            else if (obj.PrecioCompra == 0)
                Mensaje = "El precio compra no puede ser 0";
            else if (obj.PrecioVenta == 0)
                Mensaje = "El precio venta no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este Articulo";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticulo.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.Articulo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar una entidad";
            else if (string.IsNullOrEmpty(obj.CodigoArticulo) || string.IsNullOrWhiteSpace(obj.CodigoArticulo))
                Mensaje = "El código del artículo no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.DescripcionArticulo) || string.IsNullOrWhiteSpace(obj.DescripcionArticulo))
                Mensaje = "La descripción del artículo no puede ser vacía";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad del artículo no puede ser 0";
            else if (obj.PrecioCompra == 0)
                Mensaje = "El precio compra no puede ser 0";
            else if (obj.PrecioVenta == 0)
                Mensaje = "El precio venta no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este Articulo";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticulo.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dArticulo.Eliminar(id, out Mensaje);
        }
    }
}