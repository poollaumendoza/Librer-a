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
        #region Variables
        public static bool Resultado = false;
        public static int IdEmpresa = 0;
        public static int IdArticulo = 0;
        public static int IdEntidad = 0;
        public static int IdUsuario = 0;
        public static string NombreTabla = string.Empty;

        public static ObservableCollection<CompraTemporal> oCompra = new ObservableCollection<CompraTemporal>();
        public static ObservableCollection<VentaTemporal> oVenta = new ObservableCollection<VentaTemporal>();
        #endregion

        #region Clases
        public class CompraTemporal
        {
            public int id { get; set; }
            public int Cantidad { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public decimal Importe { get; set; }
        }

        public class VentaTemporal
        {
            public int id { get; set; }
            public int Cantidad { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public decimal Importe { get; set; }
        }
        #endregion
    }
}