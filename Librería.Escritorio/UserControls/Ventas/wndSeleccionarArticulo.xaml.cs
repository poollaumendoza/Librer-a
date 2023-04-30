using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
        MetroWindow oWindow;
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

        private void BtnArticulo_Click(object sender, RoutedEventArgs e)
        {
            string criterio = string.Empty;

            oWindow = new Forms.Articulo.wndArticulo();
            if (oWindow.ShowDialog() == false)
                if (App.Resultado == true)
                    CargarArticulos();
        }

        private async void Dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object fila = dg.SelectedItem;

            var message =
                await this.ShowInputAsync(
                "Título",
                "Ingrese cantidad de producto:",
                new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "No"
                });

            App.oVenta.Add(new App.VentaTemporal()
            {
                Cantidad = Convert.ToInt32(message),
                Descripcion = ((Entidades.Articulo)fila).DescripcionArticulo,
                Precio = ((Entidades.Articulo)fila).PrecioVenta,
                Importe = (Convert.ToInt32(message) * ((Entidades.Articulo)fila).PrecioVenta)
            });
            App.Resultado = true;
            this.Close();
        }
    }
}