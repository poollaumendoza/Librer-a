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

namespace Librería.Escritorio.UserControls.Compras
{
    public partial class wndSeleccionarArticulo : Window
    {
        Negocios.Articulo nArticulo = new Negocios.Articulo();
        Entidades.Articulo eArticulo;

        public wndSeleccionarArticulo(int IdProveedor = 0, string criterio = "")
        {
            InitializeComponent();
            CargarArticulos(IdProveedor, criterio);
        }

        void CargarArticulos(int IdProveedor, string criterio)
        {
            eArticulo = new Entidades.Articulo()
            {
                IdProveedor = IdProveedor
            };

            dg.ItemsSource = null;
            dg.ItemsSource = nArticulo.ListaArticulo(eArticulo);
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnArticulo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}