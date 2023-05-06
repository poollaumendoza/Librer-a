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
using MahApps.Metro.Controls.Dialogs;
using Librería.Desktop.Models;

namespace Librería.Desktop.Forms.Empresa
{
    public partial class wndEmpresa : MetroWindow
    {
        DbLibEntities db = new DbLibEntities();
        public int Id = 0;

        public wndEmpresa(int Id = 0)
        {
            InitializeComponent();
            CargarTipoDocumento();
            CargarEstado();

            this.Id = Id;

            if (Id != 0)
            {
                var empresa = db.Empresa.Find(Id);
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
            cboTipoDocumento.ItemsSource = null;
            cboTipoDocumento.ItemsSource = db.TipoDocumento.Where(x => x.IdClasificacionTipoDocumento == 1).ToList();
        }

        void CargarEstado()
        {
            cboEstado.ItemsSource = null;
            cboEstado.ItemsSource = db.Estado.ToList();
        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var mensaje = await this.ShowMessageAsync(null, "¿Desea guardar este registro?", MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, new MetroDialogSettings() { AffirmativeButtonText = "Sí", NegativeButtonText = "No", FirstAuxiliaryButtonText = "Cancelar" });

            switch (mensaje)
            {
                case MessageDialogResult.Canceled:
                    return;
                case MessageDialogResult.Negative:
                    Close();
                    break;
                case MessageDialogResult.Affirmative:
                    Models.Empresa eEmpresa = new Models.Empresa()
                    {
                        IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue),
                        NroDocumento = txtNroDocumento.Text,
                        RazonSocial = txtRazonSocial.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Email = txtEmail.Text,
                        IdEstado = Convert.ToInt32(cboEstado.SelectedValue)
                    };
                    db.Empresa.Add(eEmpresa);
                    db.SaveChanges();
                    mensaje = await this.ShowMessageAsync(null, "Registro guardado correctamente", MessageDialogStyle.Affirmative);
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}