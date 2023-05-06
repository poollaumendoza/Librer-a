using Librería.Desktop.Models;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Librería.Desktop.Forms.Compras
{
    public partial class wndSeleccionarArticulo : MetroWindow
    {
        MetroWindow oWindow;
        DbLibEntities db = new DbLibEntities();

        public wndSeleccionarArticulo(int IdEntidad = 0)
        {
            InitializeComponent();
            CargarArticulos(IdEntidad);
        }

        void CargarArticulos(int IdEntidad)
        {
            dg.ItemsSource = null;
            dg.ItemsSource = db.Articulo.Where(x => x.IdEntidad == IdEntidad).ToList();
        }

        void CargarArticulos(int IdEntidad, string criterio)
        {
            dg.ItemsSource = null;
            dg.ItemsSource = db.Articulo.Where(x => x.IdEntidad == IdEntidad).Where(y => y.DescripcionArticulo == criterio).ToList();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string criterio = txtBuscar.Text;
            CargarArticulos(App.IdEntidad, criterio);
        }

        private void BtnArticulo_Click(object sender, RoutedEventArgs e)
        {
            int IdEntidad = App.IdEntidad;
            string criterio = string.Empty;

            oWindow = new Forms.Articulo.wndArticulo();
            if (oWindow.ShowDialog() == false)
                if (App.Resultado == true)
                    CargarArticulos(IdEntidad, criterio);
        }

        private async void Dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object fila = dg.SelectedItem;
            var message = await this.ShowInputAsync("Título", "Ingrese cantidad de producto:", new MetroDialogSettings() { AffirmativeButtonText = "Sí", NegativeButtonText = "No" });

            int requerido = (Convert.ToInt32(message));
            var compra = db.Articulo.Where(x => x.DescripcionArticulo == ((Models.Articulo)fila).DescripcionArticulo).FirstOrDefault();

            wndCompra.listaCompraDetalle.Add(new Models.CompraDetalle()
            {
                IdCompra = App.IdCompra,
                Cantidad = requerido,
                Descripcion = compra.DescripcionArticulo,
                Precio = compra.PrecioCompra,
                Importe = requerido * compra.PrecioCompra
            });
            App.Resultado = true;
            this.Close();
        }
    }
}