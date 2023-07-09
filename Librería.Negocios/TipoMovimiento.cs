using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Negocios
{
    public class TipoMovimiento
    {
        Data.TipoMovimiento dTipoMovimiento = new Data.TipoMovimiento();

        public List<Entidades.TipoMovimiento> Listar()
        {
            return dTipoMovimiento.Listar();
        }

        public int Registrar(Entidades.TipoMovimiento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreTipoMovimiento) || string.IsNullOrWhiteSpace(obj.NombreTipoMovimiento))
                Mensaje = "El nombre no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dTipoMovimiento.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(Entidades.TipoMovimiento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreTipoMovimiento) || string.IsNullOrWhiteSpace(obj.NombreTipoMovimiento))
                Mensaje = "El nombre no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dTipoMovimiento.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dTipoMovimiento.Eliminar(id, out Mensaje);
        }
    }
}