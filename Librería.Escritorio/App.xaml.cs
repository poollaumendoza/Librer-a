using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Librería.Escritorio
{
    public partial class App : Application
    {
        public static string IdEmpresa;
        public static bool Resultado = false;
        public static int IdArticulo = 0;
        public static int IdProveedor = 0;

        public class CompraTemporal
        {
            public int id { get; set; }
            public int Cantidad { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public decimal Importe { get; set; }
        }

        public static ObservableCollection<CompraTemporal> oCompra = new ObservableCollection<CompraTemporal>();
    }
}