using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Lab4CS
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        Point from;
        double q = Math.PI / 4;
        double f = Math.PI / 4;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            PerspectiveCamera Camera = (PerspectiveCamera)MainForm.getGraphic().myViewport3D.Camera;
            Point till = e.GetPosition(sender as IInputElement);
            double dx = from.X - till.X;
            double dy = from.Y - till.Y;
            from = till;

            double distance = dx * dx + dy * dy;
            if (distance <= 0)
                return;

            if (e.MouseDevice.LeftButton is MouseButtonState.Pressed) {
                double r = MainForm.getGraphic().radius;
                double dq = (dy / (Math.PI * 2 * 50));
                double df = (dx / (Math.PI * 2 * 50));
                if (!((q < 0.05 && dq < 0) || (q > Math.PI - 0.05 && dq > 0))) q += dq;
                f += df;
                Camera.Position = new Point3D(r * Math.Sin(q) * Math.Cos(f), r * Math.Sin(q) * Math.Sin(f), r * Math.Cos(q));
                Camera.LookDirection = new Vector3D(-Camera.Position.X, -Camera.Position.Y, -Camera.Position.Z);

            }
        }

        private void Window_MouseDown(object sender, MouseEventArgs e) {
            MainForm.getGraphic().myViewport3D.Children.Add(MainForm.getGraphic().cube);
        }

        private void Window_MouseUp(object sender, MouseEventArgs e) {
            MainForm.getGraphic().myViewport3D.Children.Remove(MainForm.getGraphic().cube);
        }
    }
}
