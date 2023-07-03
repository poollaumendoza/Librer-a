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
        }

        void CargarEstado()
        {
            cboEstado.ItemsSource = null;
            cboEstado.ItemsSource = nEstado.Listar();
        }

        void Guardar()
        {
            if (Id == 0)
            {
                var almacen = new Entidades.Almacen()
                {
                    NombreAlmacen = txtNombreAlmacen.Text,
                    Direccion = txtDireccion.Text,
                    oEstado = new Entidades.Estado()
                    {
                        IdEstado = Convert.ToInt32(cboEstado.SelectedValue),
                        NombreEstado = cboEstado.Text
                    }
                };
                nAlmacen.AgregarAlmacen(almacen);

                wndAlmacen.StaticMainFrame.Content = new pgListaAlmacen();
            }
            else
            {
                var almacen = nAlmacen.Listar(new Entidades.Almacen() { IdAlmacen = Id }).FirstOrDefault();
                almacen.NombreAlmacen = txtNombreAlmacen.Text;
                almacen.Direccion = txtDireccion.Text;
                almacen.oEstado.IdEstado = Convert.ToInt32(cboEstado.SelectedValue);
                nAlmacen.Editar(almacen, Mensaje);

                wndAlmacen.StaticMainFrame.Content = new pgListaAlmacen();
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            wndAlmacen.StaticMainFrame.Content = new pgListaAlmacen();
        }
    }
}