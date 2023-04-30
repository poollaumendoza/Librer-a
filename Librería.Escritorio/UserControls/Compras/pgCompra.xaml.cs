using Librería.Escritorio.Forms.Compras;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;

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
            if(cboTipoDocumento.Text == "BOLETA")
            {
                txtSubTotal.Text = subt.ToString("#,###.##");
                txtImpuesto.Text = "0.00";
                txtTotal.Text = subt.ToString("#,###.##");
            }

            dg.ItemsSource = null;
            dg.ItemsSource = App.oCompra;
        }

        void CargarCompraDetalle(int IdCompra)
        {
            dg.ItemsSource = null;
            dg.ItemsSource = nCompraDetalle.ListaCompraDetalle(new Entidades.CompraDetalle() { IdCompra = IdCompra });
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
                var compra = nCompra.ListaCompra(new Entidades.Compra() { IdCompra = Id }).FirstOrDefault();
                cboProveedor.SelectedValue = compra.IdEntidad.ToString();
                cboTipoDocumento.SelectedValue = compra.IdTipoDocumento;
                txtNroDocumento.Text = compra.NroDocumento;
                dtpFechaCompra.Text = compra.FechaCompra.ToShortDateString();
                txtSubTotal.Text = compra.SubTotal.ToString();
                txtImpuesto.Text = compra.Impuesto.ToString();
                txtTotal.Text = compra.Total.ToString();

                CargarCompraDetalle(Id);
            }
        }

        private void BtnCrearCompra_Click(object sender, RoutedEventArgs e)
        {
            var mensaje = MessageBox.Show("Desea guardar este registro?", "Titulo", MessageBoxButton.YesNoCancel);

            switch (mensaje)
            {
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    return;
                case MessageBoxResult.Yes:
                    Entidades.Compra eCompra = new Entidades.Compra()
                    {
                        IdEmpresa = App.IdEmpresa,
                        IdEntidad = Convert.ToInt32(cboProveedor.SelectedValue),
                        IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue),
                        IdUsuario = App.IdUsuario,
                        NroDocumento = txtNroDocumento.Text,
                        FechaCompra = Convert.ToDateTime(dtpFechaCompra.Text),
                        FechaRegistro = DateTime.Now,
                        SubTotal = Convert.ToDecimal(txtSubTotal.Text),
                        Impuesto = Convert.ToDecimal(txtImpuesto.Text),
                        Total = Convert.ToDecimal(txtTotal.Text),
                        IdEstado = 1
                    };
                    eCompra.IdCompra = nCompra.AgregarCompra(eCompra);

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

                    mensaje = MessageBox.Show("Registro guardado", "Título");

                    App.oCompra.Clear();
                    wndCompra.StaticMainFrame.Content = new pgListaCompra();
                    break;
                case MessageBoxResult.No:
                    App.oCompra.Clear();
                    wndCompra.StaticMainFrame.Content = new pgListaCompra();
                    break;
                default:
                    break;
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
            App.IdEntidad = Convert.ToInt32(cboProveedor.SelectedValue);

            oWindow = new wndSeleccionarArticulo(App.IdEntidad);
            if (oWindow.ShowDialog() == false)
                if (App.Resultado == true)
                    CargarArticuloAlaCompra();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int IdDetalle = (int)((Button)sender).CommandParameter;

                var mensaje = MessageBox.Show("¿Desea eliminar este registro?", "Título", MessageBoxButton.YesNoCancel);

                switch (mensaje)
                {
                    case MessageBoxResult.Cancel:
                        return;
                    case MessageBoxResult.Yes:
                        CargarCompraDetalle(eCompra.IdCompra);
                        var eliminar = nCompraDetalle.ListaCompraDetalle("IdCompraDetalle", IdDetalle.ToString()).FirstOrDefault();
                        nCompraDetalle.EliminarCompraDetalle(eliminar);

                        dg.ItemsSource = null;
                        dg.ItemsSource = nCompraDetalle.ListaCompraDetalle("IdCompra", Id.ToString());
                        break;
                    case MessageBoxResult.No:
                        App.oCompra.Clear();
                        wndCompra.StaticMainFrame.Content = new pgListaCompra();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}