using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Librería.Escritorio.Forms.Inventario
{
    public partial class wndMiInventario : MetroWindow
    {
        #region Variables
        Negocios.MiInventario nInventario = new Negocios.MiInventario();
        #endregion
        #region Métodos
        void CargarProductos(bool valor)
        {
            dgExistencias.ItemsSource = null;
            dgExistencias.ItemsSource = nInventario.ListaProductos(valor);
        }
        #endregion

        public wndMiInventario()
        {
            InitializeComponent();
            CargarProductos(Convert.ToBoolean(chkExistencia.IsChecked));
        }

        private void ChkExistencia_Checked(object sender, RoutedEventArgs e)
        {
            bool valor = Convert.ToBoolean(chkExistencia.IsChecked);
            CargarProductos(valor);
        }

        private void ChkExistencia_Unchecked(object sender, RoutedEventArgs e)
        {
            bool valor = Convert.ToBoolean(chkExistencia.IsChecked);
            CargarProductos(valor);
        }
    }
}