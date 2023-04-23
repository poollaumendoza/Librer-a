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

namespace Librería.Escritorio.Forms.Ventas
{
    public partial class wndVenta : MetroWindow
    {
        public static Frame StaticMainFrame;

        public wndVenta()
        {
            InitializeComponent();
            StaticMainFrame = MainFrame;
        }
    }
}
