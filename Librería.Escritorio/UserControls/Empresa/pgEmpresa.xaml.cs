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
    public partial class pgEmpresa : Page
    {
        Negocios.TipoDocumento nTipoDocumento = new Negocios.TipoDocumento();
        Negocios.Estado nEstado = new Negocios.Estado();
        Negocios.Empresa nEmpresa = new Negocios.Empresa();
        public int Id = 0;

        public pgEmpresa(int Id = 0)
        {
            InitializeComponent();
            CargarTipoDocumento();
            CargarEstado();

            this.Id = Id;

            if (Id != 0)
            {
                var empresa = nEmpresa.ListaEmpresa(new Entidades.Empresa() { IdEmpresa = Id }).FirstOrDefault();
                cboTipoDocumento.SelectedValue = empresa.IdTipoDocumento;
                txtNroDocumento.Text = empresa.NroDocumento;
                txtRazonSocial.Text = empresa.RazonSocial;
                txtDireccion.Text = empresa.Direccion;
                txtTelefono.Text = empresa.Telefono;
                txtEmail.Text = empresa.Email;
                cboEstado.SelectedValue = empresa.IdEstado;
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
            var mensaje = MessageBox.Show("Desea guardar este registro?", "Título", MessageBoxButton.YesNoCancel);

            switch (mensaje)
            {
                case MessageBoxResult.Cancel:
                    return;
                case MessageBoxResult.Yes:
                    Entidades.Empresa eEmpresa = new Entidades.Empresa()
                    {
                        IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue),
                        NroDocumento = txtNroDocumento.Text,
                        RazonSocial = txtRazonSocial.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Email = txtEmail.Text,
                        IdEstado = Convert.ToInt32(cboEstado.SelectedValue)
                    };
                    nEmpresa.AgregarEmpresa(eEmpresa);
                    mensaje = MessageBox.Show("Registro guardado");
                    wndEmpresa.StaticMainFrame.Content = new pgListaEmpresas();
                    break;
                case MessageBoxResult.No:
                    wndEmpresa.StaticMainFrame.Content = new pgListaEmpresas();
                    break;
                default:
                    break;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            wndEmpresa.StaticMainFrame.Content = new pgListaEmpresas();
        }
    }
}