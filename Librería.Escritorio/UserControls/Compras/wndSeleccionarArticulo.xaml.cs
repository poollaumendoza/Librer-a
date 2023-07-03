using Librería.Entidades;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Librería.Escritorio.UserControls.Compras
{
    public partial class wndSeleccionarArticulo : MetroWindow
    {
        Negocios.Articulo nArticulo = new Negocios.Articulo();
        Entidades.Articulo eArticulo;
        Window oWindow;

        public wndSeleccionarArticulo(int IdEntidad = 0)
        {
            InitializeComponent();
            CargarArticulos(IdEntidad);
        }

        void CargarArticulos(int IdEntidad)
        {
            eArticulo = new Entidades.Articulo()
            {
                IdEntidad = IdEntidad
            };

            dg.ItemsSource = null;
            dg.ItemsSource = nArticulo.ListaArticulo(eArticulo);
        }

        void CargarArticulos(int IdEntidad, string criterio)
        {
            eArticulo = new Entidades.Articulo()
            {
                IdEntidad = IdEntidad
            };

            dg.ItemsSource = null;
            dg.ItemsSource = nArticulo.ListaArticulo(eArticulo);
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {

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

            var message = 
                await this.ShowInputAsync(
                "Título",
                "Ingrese cantidad de producto:",
                new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "No"
                });

            int requerido = (Convert.ToInt32(message));

            var compra = nArticulo.ListaArticulo(new Entidades.Articulo() { DescripcionArticulo = ((Entidades.Articulo)fila).DescripcionArticulo }).FirstOrDefault();
            pgCompra.listaCompraDetalle.Add(new Entidades.CompraDetalle()
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