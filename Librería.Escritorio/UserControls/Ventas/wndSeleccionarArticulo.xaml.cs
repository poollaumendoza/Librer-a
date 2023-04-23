using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Librería.Escritorio.UserControls.Ventas
{
    public partial class wndSeleccionarArticulo : MetroWindow
    {
        Negocios.Articulo nArticulo = new Negocios.Articulo();

        public wndSeleccionarArticulo()
        {
            InitializeComponent();
            CargarArticulos();
        }

        void CargarArticulos()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = nArticulo.ListaArticulo();
        }

        void CargarArticulos(string criterio)
        {
            dg.ItemsSource = null;
            dg.ItemsSource = nArticulo.ListaArticulo(criterio);
        }
    }
}