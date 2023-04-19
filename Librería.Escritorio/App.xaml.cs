using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Librería.Escritorio
{
    public partial class App : Application
    {
        public static int IdEmpresa;
        public static bool Resultado = false;
        public static int IdArticulo = 0;
        public static int IdProveedor = 0;

        public class CompraTemporal
        {
            public int Cantidad { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public decimal Importe { get; set; }
        }

        public static List<CompraTemporal> oCompra = new List<CompraTemporal>();
    }
}