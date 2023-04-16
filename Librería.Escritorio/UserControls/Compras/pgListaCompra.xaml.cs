using Librería.Escritorio.Forms.Compras;
using System.Windows;
using System.Windows.Controls;

namespace Librería.Escritorio.UserControls.Compras
{
    public partial class pgListaCompra : Page
    {
        public pgListaCompra()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            wndCompra.StaticMainFrame.Content = new pgCompra();
        }
    }
}