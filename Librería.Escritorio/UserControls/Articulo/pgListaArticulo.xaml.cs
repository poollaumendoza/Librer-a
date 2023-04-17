using Librería.Escritorio.Forms.Articulo;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Librería.Escritorio.UserControls.Articulo
{
    public partial class pgListaArticulo : Page
    {
        Entidades.Articulo eArticulo;
        Negocios.Articulo nArticulo = new Negocios.Articulo();

        public pgListaArticulo()
        {
            InitializeComponent();

            CargarArticulos();
        }

        void CargarArticulos()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = nArticulo.ListaArticulo();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            wndArticulo.StaticMainFrame.Content = new pgArticulo();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            pgArticulo pFormulario = new pgArticulo(Id);
            wndArticulo.StaticMainFrame.Content = pFormulario;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            eArticulo = new Entidades.Articulo()
            {
                IdArticulo = Id
            };
            var articulo = nArticulo.ListaArticulo(eArticulo).FirstOrDefault();
            nArticulo.EliminarArticulo(articulo);

            CargarArticulos();
        }
    }
}