using Librería.Escritorio.Forms.Compras;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Librería.Escritorio.UserControls.Compras
{
    public partial class pgCompra : Page
    {
        #region Variables
        Window oWindow;
        Entidades.Compra eCompra = new Entidades.Compra();
        Negocios.Compra nCompra = new Negocios.Compra();
        Negocios.CompraDetalle nCompraDetalle = new Negocios.CompraDetalle();
        Negocios.Entidad nEntidad = new Negocios.Entidad();
        Negocios.TipoDocumento nTipoDocumento = new Negocios.TipoDocumento();
        Negocios.Articulo nArticulo = new Negocios.Articulo();
        Entidades.Articulo eArticulo = new Entidades.Articulo();
        public int Id = 0;
        #endregion
        #region Métodos
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
            var subt = App.oCompra.Select(x => x.Importe).Sum();
            var imp = subt * 0.18M;
            var tot = subt + imp;

            if (cboTipoDocumento.Text == "FACTURA")
            {
                txtSubTotal.Text = subt.ToString("#,###.##");
                txtImpuesto.Text = imp.ToString("#,###.##");
                txtTotal.Text = tot.ToString("#,###.##");
            }

            dg.ItemsSource = null;
            dg.ItemsSource = App.oCompra;
        }
        #endregion

        public pgCompra(int Id = 0)
        {
            InitializeComponent();

            CargarEntidad();
            CargarTipoDocumento();

            this.Id = Id;

            if (Id != 0)
            {
                var compra = nCompra.ListaCompra(Id).FirstOrDefault();
                cboProveedor.SelectedValue = compra.IdProveedor.ToString();
                cboTipoDocumento.SelectedValue = compra.IdTipoDocumento;
                txtNroDocumento.Text = compra.NroDocumento;
                dtpFechaCompra.Text = compra.FechaCompra;
                txtSubTotal.Text = compra.SubTotal.ToString();
                txtImpuesto.Text = compra.Impuesto.ToString();
                txtTotal.Text = compra.Total.ToString();

                dg.ItemsSource = null;
                dg.ItemsSource = nCompraDetalle.ListaCompraDetalle("IdCompra", compra.IdCompra.ToString());
            }
        }

        private void BtnCrearCompra_Click(object sender, RoutedEventArgs e)
        {
            Entidades.Compra eCompra = new Entidades.Compra()
            {
                IdEmpresa = App.IdEmpresa,
                IdProveedor = cboProveedor.SelectedValue.ToString(),
                IdTipoDocumento = cboTipoDocumento.SelectedValue.ToString(),
                IdUsuario = "0",
                NroDocumento = txtNroDocumento.Text,
                FechaCompra = dtpFechaCompra.Text,
                FechaRegistro = DateTime.Now.ToLongDateString(),
                SubTotal = Convert.ToDecimal(txtSubTotal.Text),
                Impuesto = Convert.ToDecimal(txtImpuesto.Text),
                Total = Convert.ToDecimal(txtTotal.Text),
                IdEstado = 1

            };
            nCompra.AgregarCompra(eCompra);

            foreach (var item in App.oCompra)
            {
                Entidades.CompraDetalle eCompraDetalle = new Entidades.CompraDetalle()
                {
                    IdCompra = eCompra.IdCompra,
                    Cantidad = item.Cantidad,
                    Descripcion = item.Descripcion,
                    Precio = item.Precio,
                    Importe = item.Importe,
                    IdEstado = 1
                };
                nCompraDetalle.AgregarCompraDetalle(eCompraDetalle);
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            App.oCompra.Clear();
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
            if (oWindow.ShowDialog() == false)
                if (App.Resultado == true)
                    CargarArticuloAlaCompra();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            var compra = nCompra.ListaCompra(Id).FirstOrDefault();
            var compradetalle = nCompraDetalle.ListaCompraDetalle("IdCompra", compra.IdCompra.ToString()).FirstOrDefault();
            nCompraDetalle.EliminarCompraDetalle(compradetalle);

            dg.ItemsSource = null;
            dg.ItemsSource = nCompraDetalle.ListaCompraDetalle("IdCompra", compra.IdCompra.ToString());
        }
    }
}