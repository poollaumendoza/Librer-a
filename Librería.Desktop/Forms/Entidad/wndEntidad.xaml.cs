using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using Librería.Desktop.Models;

namespace Librería.Desktop.Forms.Entidad
{
    public partial class wndEntidad : MetroWindow
    {
        DbLibEntities db = new DbLibEntities();
        public int Id = 0;

        public wndEntidad(int Id = 0)
        {
            InitializeComponent();
            CargarTipoDocumento();
            CargarEstado();

            this.Id = Id;

            if(Id != 0)
            {
                var entidad = db.Entidad.Find(Id);
                cboTipoDocumento.SelectedValue = entidad.IdTipoDocumento;
                txtNroDocumento.Text = entidad.NroDocumento;
                txtRazonSocial.Text = entidad.RazonSocial;
                txtDireccion.Text = entidad.Direccion;
                txtTelefono.Text = entidad.Telefono;
                txtEmail.Text = entidad.Email;
                rbCliente.IsChecked = Convert.ToBoolean(entidad.EsCliente);
                rbProveedor.IsChecked = Convert.ToBoolean(entidad.EsProveedor);
                cboEstado.SelectedValue = entidad.IdEstado;
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
                    if (Id == 0)
                    {
                        Models.Entidad entidad = new Models.Entidad()
                        {
                            IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue),
                            NroDocumento = txtNroDocumento.Text,
                            RazonSocial = txtRazonSocial.Text,
                            Direccion = txtDireccion.Text,
                            Telefono = txtTelefono.Text,
                            Email = txtEmail.Text,
                            EsCliente = Convert.ToBoolean(rbCliente.IsChecked),
                            EsProveedor = Convert.ToBoolean(rbProveedor.IsChecked),
                            IdEstado = Convert.ToInt32(cboEstado.SelectedValue)
                        };
                        db.Entidad.Add(entidad);
                        db.SaveChanges();
                        App.Resultado = true;
                        Close();
                    }
                    else
                    {
                        var entidad = db.Entidad.Find(Id);
                        cboTipoDocumento.SelectedValue = entidad.IdTipoDocumento;
                        txtNroDocumento.Text = entidad.NroDocumento;
                        txtRazonSocial.Text = entidad.RazonSocial;
                        txtDireccion.Text = entidad.Direccion;
                        txtTelefono.Text = entidad.Telefono;
                        txtEmail.Text = entidad.Email;
                        rbCliente.IsChecked = Convert.ToBoolean(entidad.EsCliente);
                        rbProveedor.IsChecked = Convert.ToBoolean(entidad.EsProveedor);
                        cboEstado.SelectedValue = entidad.IdEstado;

                        db.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
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