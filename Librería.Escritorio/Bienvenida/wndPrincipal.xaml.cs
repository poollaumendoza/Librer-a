﻿//using MahApps.Metro.Controls;
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

namespace Librería.Escritorio.Bienvenida
{
    public partial class wndPrincipal : Window
    {
        Window oWindow;

        public wndPrincipal()
        {
            InitializeComponent();
        }

        private void BtnCompras_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Compras.wndCompra();
            oWindow.Show();
        }
    }
}