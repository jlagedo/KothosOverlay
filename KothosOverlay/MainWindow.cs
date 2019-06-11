using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Input;

namespace KothosOverlay
{
    public class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponents();
        }

        public Overlay overlay;

        public OverlayModel OverlayModel { get; set; }

        private void InitializeComponents()
        {
            Height = 332;
            Width = 500;
            AllowsTransparency = true;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.CanResizeWithGrip;
            Background = new SolidColorBrush { Opacity = 0 };

            MouseDown += MainWindow_MouseDown;

            OverlayModel = new OverlayModel();
            overlay = new Overlay();
            overlay.DataContext = OverlayModel;
            this.Content = overlay;
        }

        private void MainWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
