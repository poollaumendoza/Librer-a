using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Librería.Escritorio.UserControls.Ventas
{
    public partial class pgVenta : Page
    {
        #region Variables
        MetroWindow oWindow;
        Entidades.Venta eVenta = new Entidades.Venta();
        Negocios.Venta nVenta = new Negocios.Venta();
        Negocios.VentaDetalle nVentaDetalle = new Negocios.VentaDetalle();
        Negocios.Entidad nEntidad = new Negocios.Entidad();
        Negocios.TipoDocumento nTipoDocumento = new Negocios.TipoDocumento();
        Negocios.Articulo nArticulo = new Negocios.Articulo();
        Negocios.Correlativo nCorrelativo = new Negocios.Correlativo();
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

        void CargarSeries(string NombreTabla, string Abreviatura)
        {
            cboSerie.ItemsSource = null;
            cboSerie.ItemsSource = nCorrelativo.ObtenerSerie(NombreTabla, Abreviatura);
        }



        #endregion

        public pgVenta(int Id = 0)
        {
            InitializeComponent();

            CargarEntidad();
            CargarTipoDocumento();

            //this.Id = Id;

            //if (Id != 0)
            //{
            //    var Venta = nVenta.ListaVenta(Id).FirstOrDefault();
            //    cboCliente.SelectedValue = Venta.IdCliente.ToString();
            //    cboTipoDocumento.SelectedValue = Venta.IdTipoDocumento;
            //    txtNroDocumento.Text = Venta.NroDocumento;
            //    dtpFechaVenta.Text = Venta.FechaVenta;
            //    txtSubTotal.Text = Venta.SubTotal.ToString();
            //    txtImpuesto.Text = Venta.Impuesto.ToString();
            //    txtTotal.Text = Venta.Total.ToString();

            //    dg.ItemsSource = null;
            //    dg.ItemsSource = nVentaDetalle.ListaVentaDetalle("IdVenta", Venta.IdVenta.ToString());
            //}
        }

        private void BtnCrearVenta_Click(object sender, RoutedEventArgs e)
        {
            //Entidades.Compra eCompra = new Entidades.Compra()
            //{
            //    IdEmpresa = App.IdEmpresa,
            //    IdProveedor = cboProveedor.SelectedValue.ToString(),
            //    IdTipoDocumento = cboTipoDocumento.SelectedValue.ToString(),
            //    IdUsuario = "0",
            //    NroDocumento = txtNroDocumento.Text,
            //    FechaCompra = dtpFechaCompra.Text,
            //    FechaRegistro = DateTime.Now.ToLongDateString(),
            //    SubTotal = Convert.ToDecimal(txtSubTotal.Text),
            //    Impuesto = Convert.ToDecimal(txtImpuesto.Text),
            //    Total = Convert.ToDecimal(txtTotal.Text),
            //    IdEstado = 1

            //};
            //nCompra.AgregarCompra(eCompra);

            //foreach (var item in App.oCompra)
            //{
            //    Entidades.CompraDetalle eCompraDetalle = new Entidades.CompraDetalle()
            //    {
            //        IdCompra = eCompra.IdCompra,
            //        Cantidad = item.Cantidad,
            //        Descripcion = item.Descripcion,
            //        Precio = item.Precio,
            //        Importe = item.Importe,
            //        IdEstado = 1
            //    };
            //    nCompraDetalle.AgregarCompraDetalle(eCompraDetalle);
            //}
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            //App.oCompra.Clear();
            //wndCompra.StaticMainFrame.Content = new pgListaCompra();
        }

        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {
            //oWindow = new Forms.Entidad.wndEntidad();
            //if (oWindow.ShowDialog() == false)
            //    if (App.Resultado == true)
            //        CargarEntidad();
        }

        private void BtnSeleccionarArticulo_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new wndSeleccionarArticulo();
            oWindow.ShowDialog();

            //App.IdProveedor = Convert.ToInt32(cboCliente.SelectedValue);

            //oWindow = new wndSeleccionarArticulo(App.IdProveedor);
            //if (oWindow.ShowDialog() == false)
            //    if (App.Resultado == true)
            //        CargarArticuloAlaCompra();


        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            //int Id = (int)((Button)sender).CommandParameter;

            //var compra = nCompra.ListaCompra(Id).FirstOrDefault();
            //var compradetalle = nCompraDetalle.ListaCompraDetalle("IdCompra", compra.IdCompra.ToString()).FirstOrDefault();
            //nCompraDetalle.EliminarCompraDetalle(compradetalle);

            //dg.ItemsSource = null;
            //dg.ItemsSource = nCompraDetalle.ListaCompraDetalle("IdCompra", compra.IdCompra.ToString());
        }

        private void CboTipoDocumento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string IdEmpresa = App.IdEmpresa;
            string nombreTabla = "VENTA";
            string Abreviatura = string.Empty;
            int tipodocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);

            switch (tipodocumento)
            {
                case 3:
                    Abreviatura = "FACT";
                    CargarSeries(nombreTabla, Abreviatura);
                    break;
                case 4:
                    Abreviatura = "BOL";
                    CargarSeries(nombreTabla, Abreviatura);
                    break;
                case 5:
                    Abreviatura = "GR";
                    CargarSeries(nombreTabla, Abreviatura);
                    break;
            }
        }

        private void CboSerie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtCorrelativo.Text = nCorrelativo.ConstruirCorrelativoDocumento(Convert.ToInt32(cboSerie.SelectedValue));
        }
    }
}