using MahApps.Metro.Controls;
using Librería.Escritorio.Forms.Compras;
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

namespace Librería.Escritorio.UserControls.Compras
{
    public partial class pgCompra : Page
    {
        Window oWindow;
        Negocios.Entidad nEntidad = new Negocios.Entidad();
        Negocios.TipoDocumento nTipoDocumento = new Negocios.TipoDocumento();
        Negocios.Articulo nArticulo = new Negocios.Articulo();
        Entidades.Articulo eArticulo = new Entidades.Articulo();
        public int Id = 0;

        public pgCompra(int Id = 0)
        {
            InitializeComponent();

            CargarEntidad();
            CargarTipoDocumento();

            //this.Id = Id;

            //if(Id != 0)
            //{
            //    var compra.
            //}
        }

        void CargarEntidad()
        {
            cboProveedor.ItemsSource = null;
            cboProveedor.ItemsSource = nEntidad.ListaEntidad();
        }

        void CargarTipoDocumento()
        {
            var td = (from t in nTipoDocumento.ListaTipoDocumento()
                      where t.IdClasificacionTipoDocumento.Equals(2)
                      select t).ToList();

            cboTipoDocumento.ItemsSource = null;
            cboTipoDocumento.ItemsSource = td;
        }

        void CargarArticuloAlaCompra()
        {
            //Entidades.Articulo eArticulo = new Entidades.Articulo()
            //{
            //    IdArticulo = IdArticulo
            //};
            //var articulo = nArticulo.ListaArticulo(eArticulo).FirstOrDefault();

            //oCompra.Add(new App.CompraTemporal() { Cantidad = 1, Descripcion = articulo.DescripcionArticulo, Precio = articulo.PrecioVenta });

            dg.ItemsSource = null;
            dg.ItemsSource = App.oCompra;
        }

        private void BtnCrearCompra_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            wndCompra.StaticMainFrame.Content = new pgListaCompra();
        }

        private void BtnProveedor_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Entidad.wndEntidad();
            if (oWindow.ShowDialog() == false)
                if (App.Resultado == true)
                    CargarEntidad();
        }

        private void BtnSeleccionarArticulo_Click(object sender, RoutedEventArgs e)
        {
            App.IdProveedor = Convert.ToInt32(cboProveedor.SelectedValue);

            oWindow = new wndSeleccionarArticulo(App.IdProveedor);
            if(oWindow.ShowDialog() == false)
                if(App.Resultado == true)
                    CargarArticuloAlaCompra();
        }
    }
}