using Librería.Escritorio.Forms.Entidad;
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

namespace Librería.Escritorio.UserControls.Entidad
{
    public partial class pgListaEntidad : Page
    {
        Negocios.Entidad nEntidad = new Negocios.Entidad();

        public pgListaEntidad()
        {
            InitializeComponent();

            CargarEntidad();
        }

        void CargarEntidad()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = nEntidad.ListaEntidad();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            wndEntidad.StaticMainFrame.Content = new pgEntidad();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            pgEntidad pFormulario = new pgEntidad(Id);
            wndEntidad.StaticMainFrame.Content = pFormulario;

            CargarEntidad();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            var entidad = nEntidad.ListaEntidad(Id).FirstOrDefault();
            nEntidad.EliminarEntidad(entidad);

            CargarEntidad();
        }
    }
}