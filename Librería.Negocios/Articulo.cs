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
                Mensaje = "El c�digo del art�culo no puede ser vac�o";
            else if (string.IsNullOrEmpty(obj.DescripcionArticulo) || string.IsNullOrWhiteSpace(obj.DescripcionArticulo))
                Mensaje = "La descripci�n del art�culo no puede ser vac�a";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad del art�culo no puede ser 0";
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
                Mensaje = "El c�digo del art�culo no puede ser vac�o";
            else if (string.IsNullOrEmpty(obj.DescripcionArticulo) || string.IsNullOrWhiteSpace(obj.DescripcionArticulo))
                Mensaje = "La descripci�n del art�culo no puede ser vac�a";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad del art�culo no puede ser 0";
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