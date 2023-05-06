using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Librería.Desktop.Models;

namespace Librería.Desktop
{
    public partial class App : Application
    {
        public static DbLibEntities db = new DbLibEntities();
        public static int IdEmpresa = 0;
        public static int IdUsuario = 0;
        public static int IdEntidad = 0;
        public static int IdCompra = 0;
        public static bool Resultado = false;

        public static int StockActual(int IdArticulo)
        {
            int resultado = 0;

            int stockinicial = Convert.ToInt32(db.Articulo.Find(IdArticulo).Cantidad);
            int ingresos = Convert.ToInt32(db.MovimientoDetalle.Where(x => x.IdArticulo == IdArticulo).Select(y => y.Ingreso).Sum());
            int salidas = Convert.ToInt32(db.MovimientoDetalle.Where(x => x.IdArticulo == IdArticulo).Select(y => y.Salida).Sum());
            resultado = stockinicial + (ingresos - salidas);

            return resultado;
        }
    }
}