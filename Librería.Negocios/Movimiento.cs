using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class Movimiento
    {
        Data.Movimiento dMovimiento = new Data.Movimiento();

        public List<Entidades.Movimiento> Listar()
        {
            return dMovimiento.Listar();
        }

        public int Registrar(Entidades.Movimiento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oTipoMovimiento.IdTipoMovimiento == 0)
                Mensaje = "Debe seleccionar un tipo de movimiento";
            else if (obj.oUsuario.IdUsuario == 0)
                Mensaje = "Debe seleccionar un usuario";
            else if (string.IsNullOrEmpty(obj.NroMovimiento) || string.IsNullOrWhiteSpace(obj.NroMovimiento))
                Mensaje = "El número de movimiento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.FechaMovimiento) || string.IsNullOrWhiteSpace(obj.FechaMovimiento))
                Mensaje = "Debe seleccionar una fecha";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dMovimiento.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.Movimiento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (obj.oTipoMovimiento.IdTipoMovimiento == 0)
                Mensaje = "Debe seleccionar un tipo de movimiento";
            else if (obj.oUsuario.IdUsuario == 0)
                Mensaje = "Debe seleccionar un usuario";
            else if (string.IsNullOrEmpty(obj.NroMovimiento) || string.IsNullOrWhiteSpace(obj.NroMovimiento))
                Mensaje = "El número de movimiento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.FechaMovimiento) || string.IsNullOrWhiteSpace(obj.FechaMovimiento))
                Mensaje = "Debe seleccionar una fecha";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dMovimiento.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dMovimiento.Eliminar(id, out Mensaje);
        }
    }
}