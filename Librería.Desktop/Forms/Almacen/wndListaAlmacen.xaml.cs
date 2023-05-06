using Librería.Desktop.Models;
using MahApps.Metro.Controls;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;

namespace Librería.Desktop.Forms.Almacen
{
    public partial class wndListaAlmacen : MetroWindow
    {
        MetroWindow oWindow;

        public wndListaAlmacen()
        {
            InitializeComponent();
            CargarAlmacenes();
        }

        void CargarAlmacenes()
        {
            using (DbLibEntities db = new DbLibEntities())
            {
                dg.ItemsSource = null;
                dg.ItemsSource = db.Almacen.ToList();
            }
        }

        private void BtnAgregar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            oWindow = new Forms.Almacen.wndAlmacen();
            oWindow.Show();
        }

        private void BtnEditar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int Id = (int)((System.Windows.Controls.Button)sender).CommandParameter;
            oWindow = new Forms.Almacen.wndAlmacen(Id);

            CargarAlmacenes();
        }

        private void BtnEliminar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int Id = (int)((System.Windows.Controls.Button)sender).CommandParameter;

            using (DbLibEntities db = new DbLibEntities())
            {
                var almacen = db.Almacen.Find(Id);
                db.Almacen.Remove(almacen);
                db.SaveChanges();

                CargarAlmacenes();
            }
        }
    }
}