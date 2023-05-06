using Librería.Desktop.Models;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Librería.Desktop.Forms.Compras
{
    public partial class wndCompra : MetroWindow
    {
        #region Variables
        Window oWindow;
        public int Id = 0;
        DbLibEntities db = new DbLibEntities();
        public static ObservableCollection<Models.CompraDetalle> listaCompraDetalle = new ObservableCollection<Models.CompraDetalle>();
        #endregion
        #region Métodos
        void CargarEntidad()
        {
            using (DbLibEntities db = new DbLibEntities())
            {
                cboProveedor.ItemsSource = null;
                cboProveedor.ItemsSource = db.Entidad.ToList();
            }
        }

        void CargarTipoDocumento()
        {
            using (DbLibEntities db = new DbLibEntities())
            {
                cboTipoDocumento.ItemsSource = null;
                cboTipoDocumento.ItemsSource = db.TipoDocumento.Where(x => x.IdClasificacionTipoDocumento == 2).ToList();
            }
        }

        void CargarArticuloAlaCompra()
        {
            decimal subt = Convert.ToDecimal(listaCompraDetalle.Select(x => x.Importe).Sum());
            decimal imp = subt * 0.18M;
            decimal tot = subt + imp;

            if (cboTipoDocumento.Text == "FACTURA")
            {
                txtSubTotal.Text = subt.ToString("#,###.##");
                txtImpuesto.Text = imp.ToString("#,###.##");
                txtTotal.Text = tot.ToString("#,###.##");
            }
            if (cboTipoDocumento.Text == "BOLETA")
            {
                txtSubTotal.Text = subt.ToString("#,###.##");
                txtImpuesto.Text = "0.00";
                txtTotal.Text = subt.ToString("#,###.##");
            }

            dg.ItemsSource = null;
            dg.ItemsSource = listaCompraDetalle;
        }
        void CargarCompraDetalle(int IdCompra)
        {
            var cd = db.CompraDetalle.Where(x => x.IdCompra == IdCompra).ToList();

            foreach (var item in cd)
            {
                listaCompraDetalle.Add(new Models.CompraDetalle()
                {
                    IdCompraDetalle = item.IdCompraDetalle,
                    IdCompra = item.IdCompra,
                    Cantidad = item.Cantidad,
                    Descripcion = item.Descripcion,
                    Precio = item.Precio,
                    Importe = item.Importe,
                    IdEstado = item.IdEstado
                });
            }

            dg.ItemsSource = null;
            dg.ItemsSource = listaCompraDetalle;
        }
        #endregion

        public wndCompra(int Id = 0)
        {
            InitializeComponent();

            CargarEntidad();
            CargarTipoDocumento();

            this.Id = Id;

            if (Id != 0)
            {
                App.IdCompra = Id;
                var compra = db.Compra.Find(Id);
                cboProveedor.SelectedValue = compra.IdEntidad.ToString();
                cboTipoDocumento.SelectedValue = compra.IdTipoDocumento;
                txtNroDocumento.Text = compra.NroDocumento;
                dtpFechaCompra.Text = compra.FechaCompra.ToString();
                txtSubTotal.Text = compra.SubTotal.ToString();
                txtImpuesto.Text = compra.Impuesto.ToString();
                txtTotal.Text = compra.Total.ToString();

                CargarCompraDetalle(App.IdCompra);
            }
        }

        private async void BtnCrearCompra_Click(object sender, RoutedEventArgs e)
        {
            var mensaje = await this.ShowMessageAsync(null, "¿Desea guardar este registro?", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings() { AffirmativeButtonText = "Sí", NegativeButtonText = "No" });

            switch (mensaje)
            {
                case MessageDialogResult.Canceled:
                    return;
                case MessageDialogResult.Negative:
                    Close();
                    break;
                case MessageDialogResult.Affirmative:
                    if (Id != 0)
                    {
                        var compra = db.Compra.Find(Id);
                        cboProveedor.SelectedValue = compra.IdEntidad.ToString();
                        cboTipoDocumento.SelectedValue = compra.IdTipoDocumento;
                        txtNroDocumento.Text = compra.NroDocumento;
                        dtpFechaCompra.Text = compra.FechaCompra.ToString();
                        txtSubTotal.Text = compra.SubTotal.ToString();
                        txtImpuesto.Text = compra.Impuesto.ToString();
                        txtTotal.Text = compra.Total.ToString();
                        db.Entry(compra).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        var mod = listaCompraDetalle.Where(x => x.IdCompraDetalle == 0).ToList();
                        var mov = db.Movimiento.Where(x => x.NroDocumento == db.Compra.Where(y => y.IdCompra == compra.IdCompra).Select(z => z.NroDocumento).FirstOrDefault()).FirstOrDefault();

                        foreach (var item in listaCompraDetalle)
                        {
                            Models.CompraDetalle eCompraDetalle = new Models.CompraDetalle()
                            {
                                IdCompra = App.IdCompra,
                                Cantidad = item.Cantidad,
                                Descripcion = item.Descripcion,
                                Precio = item.Precio,
                                Importe = item.Importe,
                                IdEstado = 1
                            };
                            db.CompraDetalle.Add(eCompraDetalle);
                            db.SaveChanges();

                            var articulo = db.Articulo.Where(x => x.DescripcionArticulo == eCompraDetalle.Descripcion).FirstOrDefault();

                            Models.MovimientoDetalle eMovimientoDetalle = new Models.MovimientoDetalle()
                            {
                                IdMovimiento = mov.IdMovimiento,
                                IdArticulo = articulo.IdArticulo,
                                StockInicial = articulo.Cantidad,
                                Ingreso = item.Cantidad,
                                Salida = 0,
                                IdEstado = 1
                            };
                            db.MovimientoDetalle.Add(eMovimientoDetalle);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        Models.Compra eCompra = new Models.Compra()
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
                        db.Compra.Add(eCompra);
                        db.SaveChanges();

                        Models.Movimiento eMovimiento = new Models.Movimiento()
                        {
                            IdEmpresa = App.IdEmpresa,
                            IdTipoMovimiento = 1,
                            IdUsuario = App.IdUsuario,
                            FechaMovimiento = DateTime.Now,
                            NroDocumento = eCompra.NroDocumento,
                            IdEstado = 1
                        };
                        db.Movimiento.Add(eMovimiento);
                        db.SaveChanges();

                        foreach (var item in listaCompraDetalle)
                        {
                            Models.CompraDetalle eCompraDetalle = new Models.CompraDetalle()
                            {
                                IdCompra = eCompra.IdCompra,
                                Cantidad = item.Cantidad,
                                Descripcion = item.Descripcion,
                                Precio = item.Precio,
                                Importe = item.Importe,
                                IdEstado = 1
                            };
                            db.CompraDetalle.Add(eCompraDetalle);
                            db.SaveChanges();

                            var articulo = db.Articulo.Where(x => x.DescripcionArticulo == eCompraDetalle.Descripcion).FirstOrDefault();

                            Models.MovimientoDetalle eMovimientoDetalle = new Models.MovimientoDetalle()
                            {
                                IdMovimiento = eMovimiento.IdMovimiento,
                                IdArticulo = articulo.IdArticulo,
                                StockInicial = articulo.Cantidad,
                                Ingreso = item.Cantidad,
                                Salida = 0,
                                IdEstado = 1
                            };
                            db.MovimientoDetalle.Add(eMovimientoDetalle);
                            db.SaveChanges();
                        }

                        await this.ShowMessageAsync(null, "Registro guardado correctamente", MessageDialogStyle.Affirmative);

                        listaCompraDetalle.Clear();
                        Close();
                    }
                    break;
                default:
                    break;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            listaCompraDetalle.Clear();
            Close();
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
                        var eliminar = listaCompraDetalle.Where(x => x.IdCompraDetalle == IdDetalle).FirstOrDefault();
                        db.CompraDetalle.Remove(eliminar);

                        dg.ItemsSource = null;
                        dg.ItemsSource = listaCompraDetalle;
                        break;
                    case MessageBoxResult.No:
                        listaCompraDetalle.Clear();
                        Close();
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