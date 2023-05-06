using MahApps.Metro.Controls;
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

namespace Librería.Desktop.Bienvenida
{
    public partial class wndPrincipal : MetroWindow
    {
        MetroWindow oWindow;

        public wndPrincipal()
        {
            InitializeComponent();
        }

        private void BtnCompras_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Compras.wndListaCompras();
            oWindow.Show();
        }

        private void BtnVentas_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Ventas.wndListaVentas();
            oWindow.Show();
        }

        private void MnuEmpresa_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Empresa.wndEmpresa();
            oWindow.Show();
        }

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Inventario.wndInventario();
            oWindow.Show();
        }
    }
}
