using Librería.Escritorio.Forms.Ventas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Librería.Escritorio.UserControls.Ventas
{
    public partial class pgListaVenta : Page
    {
        Negocios.Venta nVenta = new Negocios.Venta();

        public pgListaVenta()
        {
            InitializeComponent();
            CargarVentas();
        }

        void CargarVentas()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = nVenta.ListaVenta();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            wndVenta.StaticMainFrame.Content = new pgVenta();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            pgVenta pFormulario = new pgVenta(Id);
            wndVenta.StaticMainFrame.Content = pFormulario;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            var venta = nVenta.ListaVenta(new Entidades.Venta() { IdVenta = Id }).FirstOrDefault();
            nVenta.EliminarVenta(venta);
        }
    }
}
