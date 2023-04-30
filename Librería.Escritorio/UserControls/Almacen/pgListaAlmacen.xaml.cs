using Librería.Escritorio.Forms.Almacen;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Librería.Escritorio.UserControls.Almacen
{
    public partial class pgListaAlmacen : Page
    {
        Negocios.Almacen nAlmacen = new Negocios.Almacen();

        public pgListaAlmacen()
        {
            InitializeComponent();

            CargarAlmacenes();
        }

        void CargarAlmacenes()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = nAlmacen.ListaAlmacen();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            wndAlmacen.StaticMainFrame.Content = new pgAlmacen();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            pgAlmacen pFormulario = new pgAlmacen(Id);
            wndAlmacen.StaticMainFrame.Content = pFormulario;

            CargarAlmacenes();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            var almacen = nAlmacen.ListaAlmacen(new Entidades.Almacen() { IdAlmacen = Id }).FirstOrDefault();
            nAlmacen.EliminarAlmacen(almacen);

            CargarAlmacenes();
        }
    }
}