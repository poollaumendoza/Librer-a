using Librería.Escritorio.Forms.Compras;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Librería.Escritorio.UserControls.Compras
{
    public partial class pgListaCompra : Page
    {
        Negocios.Compra nCompra = new Negocios.Compra();

        public pgListaCompra()
        {
            InitializeComponent();
            CargarCompras();
        }

        void CargarCompras()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = nCompra.ListaCompra();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            wndCompra.StaticMainFrame.Content = new pgCompra();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            pgCompra pFormulario = new pgCompra(Id);
            wndCompra.StaticMainFrame.Content = pFormulario;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            var mensaje = MessageBox.Show("¿Desea eliminar este registro?", "Título", MessageBoxButton.YesNoCancel);

            switch (mensaje)
            {
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    return;
                case MessageBoxResult.Yes:
                    var compra = nCompra.ListaCompra(Id).FirstOrDefault();
                    nCompra.EliminarCompra(compra);

                    CargarCompras();

                    mensaje = MessageBox.Show("Registro eliminado");
                    break;
                case MessageBoxResult.No:
                    return;
                default:
                    break;
            }
        }
    }
}