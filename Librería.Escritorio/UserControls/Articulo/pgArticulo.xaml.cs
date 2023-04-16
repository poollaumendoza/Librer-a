using Librería.Escritorio.Forms.Articulo;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Librería.Escritorio.UserControls.Articulo
{
    public partial class pgArticulo : Page
    {
        Entidades.Articulo eArticulo;
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
                cboProveedor.SelectedValue = articulo.IdProveedor;
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
            if (Id == 0)
            {
                eArticulo = new Entidades.Articulo()
                {
                    CodigoArticulo = txtCodigo.Text,
                    DescripcionArticulo = txtDescripcion.Text,
                    IdProveedor = Convert.ToInt32(cboProveedor.SelectedValue),
                    Cantidad = Convert.ToInt32(nupCantidad.Value),
                    PrecioCompra = Convert.ToDecimal(nupPrecioCompra.Value),
                    PrecioVenta = Convert.ToDecimal(nupPrecioVenta.Value),
                    IdEstado = Convert.ToInt32(cboEstado.SelectedValue)
                };
                nArticulo.AgregarArticulo(eArticulo);
            }
            else
            {
                eArticulo.IdArticulo = Id;
                var articulo = nArticulo.ListaArticulo(eArticulo).FirstOrDefault();
                articulo.CodigoArticulo = txtCodigo.Text;
                articulo.DescripcionArticulo = txtDescripcion.Text;
                articulo.IdProveedor = Convert.ToInt32(cboProveedor.SelectedValue);
                articulo.Cantidad = Convert.ToInt32(nupCantidad.Value);
                articulo.PrecioCompra = Convert.ToDecimal(nupPrecioCompra.Value);
                articulo.PrecioVenta = Convert.ToDecimal(nupPrecioVenta.Value);
                articulo.IdEstado = Convert.ToInt32(cboEstado.SelectedValue);
                nArticulo.EditarArticulo(eArticulo);

                wndArticulo.StaticMainFrame.Content = new pgListaArticulo();
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            wndArticulo.StaticMainFrame.Content = new pgListaArticulo();
        }
    }
}