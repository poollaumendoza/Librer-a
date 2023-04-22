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
    public partial class pgVenta : Page
    {
        #region Variables
        Window oWindow;
        Entidades.Venta eVenta = new Entidades.Venta();
        Negocios.Venta nVenta = new Negocios.Venta();
        Negocios.VentaDetalle nVentaDetalle = new Negocios.VentaDetalle();
        Negocios.Entidad nEntidad = new Negocios.Entidad();
        Negocios.TipoDocumento nTipoDocumento = new Negocios.TipoDocumento();
        Negocios.Articulo nArticulo = new Negocios.Articulo();
        Entidades.Articulo eArticulo = new Entidades.Articulo();
        public int Id = 0;
        #endregion
        #region Métodos
        void CargarEntidad()
        {
            cboCliente.ItemsSource = null;
            cboCliente.ItemsSource = nEntidad.ListaEntidad();
        }

        void CargarTipoDocumento()
        {
            var td = (from t in nTipoDocumento.ListaTipoDocumento()
                      where t.IdClasificacionTipoDocumento.Equals(2)
                      select t).ToList();

            cboTipoDocumento.ItemsSource = null;
            cboTipoDocumento.ItemsSource = td;
        }

        void CargarArticuloAlaVenta()
        {
            var subt = App.oVenta.Select(x => x.Importe).Sum();
            var imp = subt * 0.18M;
            var tot = subt + imp;

            if (cboTipoDocumento.Text == "FACTURA")
            {
                txtSubTotal.Text = subt.ToString("#,###.##");
                txtImpuesto.Text = imp.ToString("#,###.##");
                txtTotal.Text = tot.ToString("#,###.##");
            }

            dg.ItemsSource = null;
            dg.ItemsSource = App.oVenta;
        }
        #endregion

        public pgVenta(int Id = 0)
        {
            InitializeComponent();

            CargarEntidad();
            CargarTipoDocumento();

            this.Id = Id;

            if (Id != 0)
            {
                var Venta = nVenta.ListaVenta(Id).FirstOrDefault();
                cboCliente.SelectedValue = Venta.IdCliente.ToString();
                cboTipoDocumento.SelectedValue = Venta.IdTipoDocumento;
                txtNroDocumento.Text = Venta.NroDocumento;
                dtpFechaVenta.Text = Venta.FechaVenta;
                txtSubTotal.Text = Venta.SubTotal.ToString();
                txtImpuesto.Text = Venta.Impuesto.ToString();
                txtTotal.Text = Venta.Total.ToString();

                dg.ItemsSource = null;
                dg.ItemsSource = nVentaDetalle.ListaVentaDetalle("IdVenta", Venta.IdVenta.ToString());
            }
        }

        private void BtnCrearVenta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSeleccionarArticulo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
