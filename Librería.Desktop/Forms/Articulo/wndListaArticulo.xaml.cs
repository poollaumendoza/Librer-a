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

namespace Librería.Desktop.Forms.Articulo
{
    public partial class wndListaArticulo : MetroWindow
    {
        MetroWindow oWindow;

        public wndListaArticulo()
        {
            InitializeComponent();
        }

        void CargarArticulos()
        {
            using (DbLibEntities db = new DbLibEntities())
            {
                dg.ItemsSource = null;
                dg.ItemsSource = db.Articulo.ToList();
            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Articulo.wndArticulo();
            oWindow.Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            oWindow = new Forms.Articulo.wndArticulo(Id);
            oWindow.Show();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            using (DbLibEntities db = new DbLibEntities())
            {
                var articulo = db.Articulo.Find(Id);
                db.Articulo.Remove(articulo);
                db.SaveChanges();
            }
            CargarArticulos();
        }
    }
}