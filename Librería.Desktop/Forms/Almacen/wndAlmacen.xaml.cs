using Librería.Desktop.Models;
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

namespace Librería.Desktop.Forms.Almacen
{
    public partial class wndAlmacen : MetroWindow
    {
        public int Id = 0;

        public wndAlmacen(int Id = 0)
        {
            InitializeComponent();
            CargarEstado();

            this.Id = Id;

            if (Id != 0)
            {
                using (DbLibEntities db = new DbLibEntities())
                {
                    var almacen = db.Almacen.Find(Id);
                    txtNombreAlmacen.Text = almacen.NombreAlmacen;
                    txtDireccion.Text = almacen.Direccion;
                    cboEstado.SelectedValue = almacen.IdEstado;
                }
            }
        }

        void CargarEstado()
        {
            using (DbLibEntities db = new DbLibEntities())
            {
                cboEstado.ItemsSource = null;
                cboEstado.ItemsSource = db.Estado.ToList();
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (Id == 0)
            {
                using (DbLibEntities db = new DbLibEntities())
                {
                    Models.Almacen almacen = new Models.Almacen()
                    {
                        NombreAlmacen = txtNombreAlmacen.Text,
                        Direccion = txtDireccion.Text,
                        IdEstado = Convert.ToInt32(cboEstado.SelectedValue)
                    };
                    db.Almacen.Add(almacen);
                    db.SaveChanges();
                }
            }
            else
            {
                using (DbLibEntities db = new DbLibEntities())
                {
                    var almacen = db.Almacen.Find(Id);
                    almacen.NombreAlmacen = txtNombreAlmacen.Text;
                    almacen.Direccion = txtDireccion.Text;
                    almacen.IdEstado = Convert.ToInt32(cboEstado.SelectedValue);
                    db.Entry(almacen).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}