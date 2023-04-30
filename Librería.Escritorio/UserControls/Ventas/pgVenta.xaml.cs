using Librería.Escritorio.Forms.Ventas;
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
            cboSerie.ItemsSource = nCorrelativo.ListaSerie(NombreTabla, Abreviatura);
            cboSerie.DisplayMemberPath = "Serie";
            cboSerie.SelectedValuePath = "IdCorrelativo";
        }

        void CargarVentaDetalle(int IdVenta)
        {
            dg.ItemsSource = null;
            dg.ItemsSource = nVentaDetalle.ListaVentaDetalle(new Entidades.VentaDetalle() { IdVenta = IdVenta });
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
                var Venta = nVenta.ListaVenta(new Entidades.Venta() { IdVenta = Id }).FirstOrDefault();
                cboCliente.SelectedValue = Venta.IdEntidad.ToString();
                cboTipoDocumento.SelectedValue = Venta.IdTipoDocumento;
                cboSerie.SelectedValue = Venta.IdCorrelativo;
                dtpFechaVenta.Text = Venta.FechaVenta.ToShortDateString();
                txtSubTotal.Text = Venta.SubTotal.ToString();
                txtImpuesto.Text = Venta.Impuesto.ToString();
                txtTotal.Text = Venta.Total.ToString();

                CargarVentaDetalle(Id);
            }
        }

        private void BtnCrearVenta_Click(object sender, RoutedEventArgs e)
        {
            var mensaje = MessageBox.Show("Desea guardar este registro?", "Título", MessageBoxButton.YesNoCancel);

            switch (mensaje)
            {
                case MessageBoxResult.Cancel:
                    return;
                case MessageBoxResult.Yes:
                    Entidades.Venta eVenta = new Entidades.Venta()
                    {
                        IdEmpresa = App.IdEmpresa,
                        IdEntidad = Convert.ToInt32(cboCliente.SelectedValue),
                        IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue),
                        IdUsuario = App.IdUsuario,
                        IdCorrelativo = Convert.ToInt32(cboSerie.SelectedValue),
                        Correlativo = txtCorrelativo.Text,
                        NroDocumento = string.Format("{0}-{1}", cboSerie.Text, txtCorrelativo.Text),
                        FechaVenta = Convert.ToDateTime(dtpFechaVenta.Text),
                        FechaRegistro = DateTime.Now,
                        SubTotal = Convert.ToDecimal(txtSubTotal.Text),
                        Impuesto = Convert.ToDecimal(txtImpuesto.Text),
                        Total = Convert.ToDecimal(txtTotal.Text),
                        IdEstado = 1

                    };
                    eVenta.IdVenta = nVenta.AgregarVenta(eVenta);

                    foreach (var item in App.oVenta)
                    {
                        Entidades.VentaDetalle eVentaDetalle = new Entidades.VentaDetalle()
                        {
                            IdVenta = eVenta.IdVenta,
                            Cantidad = item.Cantidad,
                            Descripcion = item.Descripcion,
                            Precio = item.Precio,
                            Importe = item.Importe,
                            IdEstado = 1
                        };
                        nVentaDetalle.AgregarVentaDetalle(eVentaDetalle);
                    }
                    break;
                case MessageBoxResult.No:
                    App.oCompra.Clear();
                    wndVenta.StaticMainFrame.Content = new pgListaVenta();
                    break;
                default:
                    break;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            App.oCompra.Clear();
            wndVenta.StaticMainFrame.Content = new pgListaVenta();
        }

        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Entidad.wndEntidad();
            if (oWindow.ShowDialog() == false)
                if (App.Resultado == true)
                    CargarEntidad();
        }

        private void BtnSeleccionarArticulo_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new wndSeleccionarArticulo();
            if (oWindow.ShowDialog() == false)
                if (App.Resultado == true)
                    CargarArticuloAlaVenta();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int IdDetalle = Convert.ToInt32(((Button)sender).CommandParameter);

                var mensaje = MessageBox.Show("Desea eliminar este registro?", "Título", MessageBoxButton.YesNoCancel);

                switch (mensaje)
                {
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.Yes:
                        CargarVentaDetalle(eVenta.IdVenta);
                        var eliminar = nVentaDetalle.ListaVentaDetalle(new Entidades.VentaDetalle() { IdVentaDetalle = IdDetalle }).FirstOrDefault();
                        nVentaDetalle.EliminarVentaDetalle(eliminar);

                        dg.ItemsSource = null;
                        dg.ItemsSource = nVentaDetalle.ListaVentaDetalle(new Entidades.VentaDetalle() { IdVenta = Id });
                        break;
                    case MessageBoxResult.No:
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

        private void CboTipoDocumento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
            string Abreviatura = nCorrelativo.ObtenerAbreviatura(IdTipoDocumento, App.NombreTabla);

            CargarSeries(App.NombreTabla, Abreviatura);
        }

        private void CboSerie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int serie = Convert.ToInt32(cboSerie.SelectedValue);
            txtCorrelativo.Text = nCorrelativo.ConstruirCorrelativoDocumento(serie);
        }
    }
}