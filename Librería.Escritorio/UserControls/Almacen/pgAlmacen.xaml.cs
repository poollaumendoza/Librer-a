using Librería.Escritorio.Forms.Almacen;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Librería.Escritorio.UserControls.Almacen
{
    public partial class pgAlmacen : Page
    {
        Negocios.Almacen nAlmacen = new Negocios.Almacen();
        Negocios.Estado nEstado = new Negocios.Estado();
        public int Id = 0;

        public pgAlmacen(int Id = 0)
        {
            InitializeComponent();

            CargarEstado();

            this.Id = Id;

            if (Id != 0)
            {
                var almacen = nAlmacen.ListaAlmacen(Id).FirstOrDefault();
                txtNombreAlmacen.Text = almacen.NombreAlmacen;
                txtDireccion.Text = almacen.Direccion;
                cboEstado.SelectedValue = almacen.IdEstado;
            }
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
                var almacen = new Entidades.Almacen()
                {
                    NombreAlmacen = txtNombreAlmacen.Text,
                    Direccion = txtDireccion.Text,
                    IdEstado = Convert.ToInt32(cboEstado.SelectedValue)
                };
                nAlmacen.AgregarAlmacen(almacen);

                wndAlmacen.StaticMainFrame.Content = new pgListaAlmacen();
            }
            else
            {
                var almacen = nAlmacen.ListaAlmacen(Id).FirstOrDefault();
                almacen.NombreAlmacen = txtNombreAlmacen.Text;
                almacen.Direccion = txtDireccion.Text;
                almacen.IdEstado = Convert.ToInt32(cboEstado.SelectedValue);
                nAlmacen.EditarAlmacen(almacen);

                wndAlmacen.StaticMainFrame.Content = new pgListaAlmacen();
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            wndAlmacen.StaticMainFrame.Content = new pgListaAlmacen();
        }
    }
}