﻿using MahApps.Metro.Controls;
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

namespace Librería.Escritorio.Forms.Entidad
{
    public partial class wndEntidad : MetroWindow
    {
        public static Frame StaticMainFrame;

        public wndEntidad()
        {
            InitializeComponent();
            StaticMainFrame = MainFrame;
        }
    }
}