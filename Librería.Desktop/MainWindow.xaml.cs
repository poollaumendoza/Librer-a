using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Librería.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool IsMaximized = false;

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                if (IsMaximized)
                {
                    WindowState = WindowState.Normal;
                    Width = 1080;
                    Height = 720;
                    IsMaximized = false;
                }
                else
                {
                    WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
        }
    }
}
