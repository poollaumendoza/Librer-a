using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Librería.Escritorio.UserControls.Compras
{
    public partial class wndSeleccionarArticulo : MetroWindow
    {
        Negocios.Articulo nArticulo = new Negocios.Articulo();
        Entidades.Articulo eArticulo;
        Window oWindow;

        public wndSeleccionarArticulo(int IdProveedor = 0)
        {
            InitializeComponent();
            CargarArticulos(IdProveedor);
        }

        void CargarArticulos(int IdProveedor)
        {
            eArticulo = new Entidades.Articulo()
            {
                IdProveedor = IdProveedor
            };

            dg.ItemsSource = null;
            dg.ItemsSource = nArticulo.ListaArticulo(eArticulo);
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
            int idproveedor = App.IdProveedor;
            string criterio = string.Empty;

            oWindow = new Forms.Articulo.wndArticulo();
            if (oWindow.ShowDialog() == false)
                if (App.Resultado == true)
                    CargarArticulos(idproveedor, criterio);
        }

        private async void Dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object fila = dg.Items.CurrentItem;

            var message = 
                await this.ShowInputAsync(
                "Título",
                "Ingrese cantidad de producto:",
                new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "No"
                });

            App.oCompra.Add(new App.CompraTemporal()
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