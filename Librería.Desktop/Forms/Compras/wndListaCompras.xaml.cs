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

namespace Librería.Desktop.Forms.Compras
{
    public partial class wndListaCompras : MetroWindow
    {
        MetroWindow oWindow;
        DbLibEntities db = new DbLibEntities();

        public wndListaCompras()
        {
            InitializeComponent();
            CargarCompras();
        }

        void CargarCompras()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = db.Compra.ToList();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Compras.wndCompra();
            oWindow.Show();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            oWindow = new Forms.Compras.wndCompra(Id);
            oWindow.Show();
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            var mensaje = 
                await this.ShowMessageAsync(
                    null, 
                    "¿Desea eliminar este registro?", 
                    MessageDialogStyle.AffirmativeAndNegative, 
                    new MetroDialogSettings() {
                        AffirmativeButtonText = "Sí",
                        NegativeButtonText = "No" });

            switch (mensaje)
            {
                case MessageDialogResult.Negative:
                    return;
                case MessageDialogResult.Affirmative:
                    var compra = db.Compra.Find(Id);
                    db.Compra.Remove(compra);
                    db.SaveChanges();
                    mensaje = await this.ShowMessageAsync(null, "Registro eliminado", MessageDialogStyle.Affirmative);
                    break;
                default:
                    break;
            }
        }
    }
}