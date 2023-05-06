using Librería.Desktop.Models;
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

namespace Librería.Desktop.Forms.Entidad
{
    public partial class wndListaEntidades : MetroWindow
    {
        MetroWindow oWindow;
        DbLibEntities db = new DbLibEntities();

        public wndListaEntidades()
        {
            InitializeComponent();
            CargarEntidad();
        }

        void CargarEntidad()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = db.Entidad.ToList();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Entidad.wndEntidad();
            oWindow.Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            oWindow = new Forms.Entidad.wndEntidad(Id);
            oWindow.Show();

            CargarEntidad();
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            var entidad = db.Entidad.Find(Id);
            db.Entidad.Remove(entidad);
            db.SaveChanges();

            await this.ShowMessageAsync(null, "Registro eliminado", MessageDialogStyle.Affirmative);

            CargarEntidad();
        }
    }
}