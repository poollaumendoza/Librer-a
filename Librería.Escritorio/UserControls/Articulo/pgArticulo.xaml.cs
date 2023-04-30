using Librería.Escritorio.Forms.Articulo;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Librería.Escritorio.UserControls.Articulo
{
    public partial class pgArticulo : Page
    {
        Entidades.Articulo eArticulo = new Entidades.Articulo();
        Entidades.Correlativo eCorrelativo;
        Negocios.Correlativo nCorrelativo = new Negocios.Correlativo();
        Negocios.Articulo nArticulo = new Negocios.Articulo();
        Negocios.Entidad nEntidad = new Negocios.Entidad();
        Negocios.Estado nEstado = new Negocios.Estado();
        public int Id = 0;

        public pgArticulo(int Id = 0)
        {
            InitializeComponent();

            
            CargarProveedor();
            CargarEstado();

            this.Id = Id;

            if (Id != 0)
            {
                eArticulo.IdArticulo = Id;
                var articulo = nArticulo.ListaArticulo(eArticulo).FirstOrDefault();
                txtCodigo.Text = articulo.CodigoArticulo;
                txtDescripcion.Text = articulo.DescripcionArticulo;
                cboProveedor.SelectedValue = articulo.IdEntidad;
                nupCantidad.Value = articulo.Cantidad;
                nupPrecioCompra.Value = Convert.ToDouble(articulo.PrecioCompra);
                nupPrecioVenta.Value = Convert.ToDouble(articulo.PrecioVenta);
                cboEstado.SelectedValue = articulo.IdEstado;
            }
        }

        void CargarProveedor()
        {
            cboProveedor.ItemsSource = null;
            cboProveedor.ItemsSource = nEntidad.ListaEntidad();
        }

        void CargarEstado()
        {
            cboEstado.ItemsSource = null;
            cboEstado.ItemsSource = nEstado.ListaEstado();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var mensaje = MessageBox.Show("¿Desea guardar este registro?", "Título", MessageBoxButton.YesNoCancel);

            switch (mensaje)
            {
                case MessageBoxResult.Cancel:
                    return;
                case MessageBoxResult.Yes:
                    if (Id == 0)
                    {
                        string abreviatura = txtCodigo.Text;
                        if (nCorrelativo.ListaCorrelativo(new Entidades.Correlativo() { Abreviatura = abreviatura }).ToList().Count().Equals(0))
                        {
                            eCorrelativo = new Entidades.Correlativo()
                            {
                                IdEmpresa = App.IdEmpresa,
                                NombreTabla = "ARTICULO",
                                Abreviatura = abreviatura,
                                Serie = "-",
                                NroCorrelativo = 1,
                                IdEstado = 1
                            };
                            nCorrelativo.AgregarCorrelativo(eCorrelativo);
                        }
                        else
                        {
                            var correlativo = nCorrelativo.ListaCorrelativo(new Entidades.Correlativo() { Abreviatura = abreviatura }).FirstOrDefault();
                            eCorrelativo = new Entidades.Correlativo()
                            {
                                IdEmpresa = correlativo.IdEmpresa,
                                NombreTabla = correlativo.NombreTabla,
                                Abreviatura = correlativo.Abreviatura,
                                Serie = correlativo.Serie,
                                NroCorrelativo = correlativo.NroCorrelativo + 1,
                                IdEstado = correlativo.IdEstado
                            };
                            nCorrelativo.EditarCorrelativo(eCorrelativo);
                        }

                        eArticulo = new Entidades.Articulo()
                        {
                            IdEmpresa = App.IdEmpresa,
                            CodigoArticulo = nCorrelativo.ConstruirCorrelativoArticulo(txtCodigo.Text),
                            DescripcionArticulo = txtDescripcion.Text,
                            IdEntidad = Convert.ToInt32(cboProveedor.SelectedValue),
                            Cantidad = Convert.ToInt32(nupCantidad.Value),
                            PrecioCompra = Convert.ToDecimal(nupPrecioCompra.Value),
                            PrecioVenta = Convert.ToDecimal(nupPrecioVenta.Value),
                            IdEstado = Convert.ToInt32(cboEstado.SelectedValue)
                        };
                        nArticulo.AgregarArticulo(eArticulo);
                        App.Resultado = true;
                    }
                    else
                    {
                        eArticulo.IdArticulo = Id;
                        var articulo = nArticulo.ListaArticulo(eArticulo).FirstOrDefault();
                        articulo.CodigoArticulo = txtCodigo.Text;
                        articulo.DescripcionArticulo = txtDescripcion.Text;
                        articulo.IdEntidad = Convert.ToInt32(cboProveedor.SelectedValue);
                        articulo.Cantidad = Convert.ToInt32(nupCantidad.Value);
                        articulo.PrecioCompra = Convert.ToDecimal(nupPrecioCompra.Value);
                        articulo.PrecioVenta = Convert.ToDecimal(nupPrecioVenta.Value);
                        articulo.IdEstado = Convert.ToInt32(cboEstado.SelectedValue);
                        nArticulo.EditarArticulo(eArticulo);

                        wndArticulo.StaticMainFrame.Content = new pgListaArticulo();
                    }
                    break;
                case MessageBoxResult.No:
                    wndArticulo.StaticMainFrame.Content = new pgListaArticulo();
                    break;
                default:
                    break;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            wndArticulo.StaticMainFrame.Content = new pgListaArticulo();
        }
    }
}