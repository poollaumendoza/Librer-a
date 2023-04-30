using Librería.Escritorio.Forms.Empresa;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Librería.Escritorio.UserControls.Empresa
{
    public partial class pgListaEmpresas : Page
    {
        Negocios.Empresa nEmpresa = new Negocios.Empresa();

        public pgListaEmpresas()
        {
            InitializeComponent();
            CargarEmpresas();
        }

        void CargarEmpresas()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = nEmpresa.ListaEmpresa();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            wndEmpresa.StaticMainFrame.Content = new pgEmpresa();
        }

        private void BtnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            App.IdEmpresa = Id;
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
        }
    }
}