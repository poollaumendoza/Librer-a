using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using System.Windows.Shapes;
using Librería.Desktop.Models;
using System.Collections.ObjectModel;

namespace Librería.Desktop.Forms.Ventas
{
    public partial class wndVenta : MetroWindow
    {
        MetroWindow oWindow;
        DbLibEntities db = new DbLibEntities();
        public static ObservableCollection<Models.VentaDetalle> listaVentaDetalle = new ObservableCollection<Models.VentaDetalle>();
        public int Id = 0;

        public wndVenta(int Id = 0)
        {
            InitializeComponent();

            CargarEntidad();
            CargarTipoDocumento();

            this.Id = Id;

            if (Id != 0)
            {
                var venta = db.Venta.Find(Id);
                cboCliente.SelectedValue = venta.IdEntidad.ToString();
                cboTipoDocumento.SelectedValue = venta.IdTipoDocumento;
                cboSerie.SelectedValue = venta.IdCorrelativo;
                dtpFechaVenta.Text = venta.FechaVenta.ToString();
                txtSubTotal.Text = venta.SubTotal.ToString();
                txtImpuesto.Text = venta.Impuesto.ToString();
                txtTotal.Text = venta.Total.ToString();

                CargarVentaDetalle(Id);
            }
        }

        #region Métodos
        void CargarEntidad()
        {
            cboCliente.ItemsSource = null;
            cboCliente.ItemsSource = db.Entidad.ToList();
        }

        void CargarTipoDocumento()
        {
            cboTipoDocumento.ItemsSource = null;
            cboTipoDocumento.ItemsSource = db.TipoDocumento.Where(x => x.IdClasificacionTipoDocumento == 2).ToList();
        }

        void CargarArticuloAlaVenta()
        {
            decimal subt = Convert.ToDecimal(listaVentaDetalle.Select(x => x.Importe).Sum());
            decimal imp = subt * 0.18M;
            decimal tot = subt + imp;

            if (cboTipoDocumento.Text == "FACTURA")
            {
                txtSubTotal.Text = subt.ToString("#,###.##");
                txtImpuesto.Text = imp.ToString("#,###.##");
                txtTotal.Text = tot.ToString("#,###.##");
            }

            dg.ItemsSource = null;
            dg.ItemsSource = listaVentaDetalle;
        }

        void CargarSeries(string NombreTabla, string Abreviatura)
        {
            cboSerie.ItemsSource = null;
            cboSerie.ItemsSource = db.Correlativo.Where(x => x.NombreTabla == NombreTabla).Where(y => y.Abreviatura == Abreviatura).Select(z => z.Serie).ToList();
            cboSerie.DisplayMemberPath = "Serie";
            cboSerie.SelectedValuePath = "IdCorrelativo";
        }

        void CargarVentaDetalle(int IdVenta)
        {
            var ventas = db.VentaDetalle.Where(x => x.IdVenta == IdVenta).ToList();

            foreach (var item in ventas)
            {
                listaVentaDetalle.Add(new Models.VentaDetalle()
                {
                    IdVentaDetalle = item.IdVentaDetalle,
                    IdVenta = item.IdVenta,
                    Cantidad = item.Cantidad,
                    Descripcion = item.Descripcion,
                    Precio = item.Precio,
                    Importe = item.Importe,
                    IdEstado = item.IdEstado
                });
            }

            dg.ItemsSource = null;
            dg.ItemsSource = listaVentaDetalle;
        }
        #endregion

        private async void BtnCrearVenta_Click(object sender, RoutedEventArgs e)
        {
            var mensaje = await this.ShowMessageAsync(null, "¿Desea guardar este registro?", MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, new MetroDialogSettings() { AffirmativeButtonText = "Sí", NegativeButtonText = "No", FirstAuxiliaryButtonText = "Cancelar" });

            switch (mensaje)
            {
                case MessageDialogResult.Canceled:
                    return;
                case MessageDialogResult.Negative:
                    Close();
                    break;
                case MessageDialogResult.Affirmative:
                    if(Id == 0)
                    {
                        Models.Venta eVenta = new Models.Venta()
                        {
                            IdEmpresa = App.IdEmpresa,
                            IdEntidad = Convert.ToInt32(cboCliente.SelectedValue),
                            IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue),
                            IdUsuario = App.IdUsuario,
                            IdCorrelativo = Convert.ToInt32(cboSerie.SelectedValue),
                            Correlativo = txtCorrelativo.Text,
                            FechaVenta = Convert.ToDateTime(dtpFechaVenta.Text),
                            FechaRegistro = DateTime.Now,
                            SubTotal = Convert.ToDecimal(txtSubTotal.Text),
                            Impuesto = Convert.ToDecimal(txtImpuesto.Text),
                            Total = Convert.ToDecimal(txtTotal.Text),
                            IdEstado = 1

                        };
                        db.Venta.Add(eVenta);
                        db.SaveChanges();

                        Models.Movimiento eMovimiento = new Models.Movimiento()
                        {
                            IdEmpresa = App.IdEmpresa,
                            IdTipoMovimiento = 2,
                            IdUsuario = App.IdUsuario,
                            FechaMovimiento = DateTime.Now,
                            NroDocumento = string.Format("{0}-{1}", cboSerie.Text, eVenta.Correlativo),
                            IdEstado = 1
                        };
                        db.Movimiento.Add(eMovimiento);
                        db.SaveChanges();

                        foreach (var item in listaVentaDetalle)
                        {
                            Models.VentaDetalle eVentaDetalle = new Models.VentaDetalle()
                            {
                                IdVenta = eVenta.IdVenta,
                                Cantidad = item.Cantidad,
                                Descripcion = item.Descripcion,
                                Precio = item.Precio,
                                Importe = item.Importe,
                                IdEstado = 1
                            };
                            db.VentaDetalle.Add(eVentaDetalle);
                            db.SaveChanges();

                            var articulo = db.Articulo.Where(x => x.DescripcionArticulo == item.Descripcion).FirstOrDefault();
                            Models.MovimientoDetalle eMovimientoDetalle = new MovimientoDetalle()
                            {
                                IdMovimiento = eMovimiento.IdMovimiento,
                                IdArticulo = articulo.IdArticulo,
                                StockInicial = articulo.Cantidad,
                                Ingreso = 0,
                                Salida = item.Cantidad,
                                IdEstado = 1
                            };
                            db.MovimientoDetalle.Add(eMovimientoDetalle);
                            db.SaveChanges();
                        }
                        mensaje = await this.ShowMessageAsync(null, "Registro guardado", MessageDialogStyle.Affirmative);
                    }
                    else
                    {
                        var venta = db.Venta.Find(Id);
                        cboCliente.SelectedValue = venta.IdEntidad.ToString();
                        cboTipoDocumento.SelectedValue = venta.IdTipoDocumento;
                        cboSerie.SelectedValue = venta.IdCorrelativo;
                        dtpFechaVenta.Text = venta.FechaVenta.ToString();
                        txtSubTotal.Text = venta.SubTotal.ToString();
                        txtImpuesto.Text = venta.Impuesto.ToString();
                        txtTotal.Text = venta.Total.ToString();

                        db.Entry(venta).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        var vd = listaVentaDetalle.Where(x => x.IdVentaDetalle == 0).ToList();

                        foreach (var item in vd)
                        {
                            Models.VentaDetalle eVentaDetalle = new Models.VentaDetalle()
                            {
                                IdVenta = Id,
                                Cantidad = item.Cantidad,
                                Descripcion = item.Descripcion,
                                Precio = item.Precio,
                                Importe = item.Importe,
                                IdEstado = 1
                            };
                            db.VentaDetalle.Add(eVentaDetalle);
                            db.SaveChanges();

                            var articulo = db.Articulo.Where(x => x.DescripcionArticulo == item.Descripcion).FirstOrDefault();
                            var mov = db.Movimiento.Where(x => x.NroDocumento == db.Venta.Where(y => y.IdVenta == venta.IdVenta).Select(z => z.Correlativo).FirstOrDefault()).FirstOrDefault();
                            Models.MovimientoDetalle eMovimientoDetalle = new MovimientoDetalle()
                            {
                                IdMovimiento = eMovimiento.IdMovimiento,
                                IdArticulo = articulo.IdArticulo,
                                StockInicial = articulo.Cantidad,
                                Ingreso = 0,
                                Salida = item.Cantidad,
                                IdEstado = 1
                            };
                            db.MovimientoDetalle.Add(eMovimientoDetalle);
                            db.SaveChanges();
                        }
                    }
                    break;
                case MessageDialogResult.FirstAuxiliary:
                    break;
                case MessageDialogResult.SecondAuxiliary:
                    break;
                default:
                    break;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            listaVentaDetalle.Clear();
            Close();
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
                        var eliminar = listaVentaDetalle.Where(x => x.IdVentaDetalle == IdDetalle).FirstOrDefault();
                        db.VentaDetalle.Remove(eliminar);

                        dg.ItemsSource = null;
                        dg.ItemsSource = listaVentaDetalle;
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
            //int IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
            //string Abreviatura = nCorrelativo.ObtenerAbreviatura(IdTipoDocumento, App.NombreTabla);

            //CargarSeries(App.NombreTabla, Abreviatura);
        }

        private void CboSerie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int serie = Convert.ToInt32(cboSerie.SelectedValue);
            //txtCorrelativo.Text = nCorrelativo.ConstruirCorrelativoDocumento(serie);
        }
    }
}