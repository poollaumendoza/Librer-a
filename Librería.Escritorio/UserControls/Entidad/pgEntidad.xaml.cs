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
    public partial class pgEntidad : Page
    {
        Negocios.Entidad nEntidad = new Negocios.Entidad();
        Negocios.TipoDocumento nTipoDocumento = new Negocios.TipoDocumento();
        Negocios.Estado nEstado = new Negocios.Estado();

        public int Id = 0;

        public pgEntidad(int Id = 0)
        {
            InitializeComponent();

            CargarTipoDocumento();
            CargarEstado();

            this.Id = Id;

            if(Id != 0)
            {
                var entidad = nEntidad.ListaEntidad(Id).FirstOrDefault();
                cboTipoDocumento.SelectedValue = entidad.IdTipoDocumento;
                txtNroDocumento.Text = entidad.NroDocumento;
                txtRazonSocial.Text = entidad.RazonSocial;
                txtDireccion.Text = entidad.Direccion;
                txtTelefono.Text = entidad.Telefono;
                txtEmail.Text = entidad.Email;
                rbCliente.IsChecked = entidad.EsCliente == 1 ? true : false;
                rbProveedor.IsChecked = entidad.EsProveedor == 1 ? true : false;
                cboEstado.SelectedValue = entidad.IdEstado;
            }
        }

        void CargarTipoDocumento()
        {
            var td = (from t in nTipoDocumento.ListaTipoDocumento()
                      where t.IdClasificacionTipoDocumento.Equals(1)
                      select t).ToList();

            cboTipoDocumento.ItemsSource = null;
            cboTipoDocumento.ItemsSource = td;
        }

        void CargarEstado()
        {
            cboEstado.ItemsSource = null;
            cboEstado.ItemsSource = nEstado.ListaEstado();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(Id == 0)
            {
                var entidad = new Entidades.Entidad()
                {
                    IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue),
                    NroDocumento = txtNroDocumento.Text,
                    RazonSocial = txtRazonSocial.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    EsCliente = rbCliente.IsChecked == true ? 1 : 0,
                    EsProveedor = rbProveedor.IsChecked == true ? 1 : 0,
                    IdEstado = Convert.ToInt32(cboEstado.SelectedValue)
                };
                nEntidad.AgregarEntidad(entidad);
                App.Resultado = true;
                
                wndEntidad.StaticMainFrame.Content = new pgListaEntidad();
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            wndEntidad.StaticMainFrame.Content = new pgListaEntidad();
        }
    }
}