using Fiber.ScatterGraph;
using FiberPull;
using OpenTK.Graphics.OpenGL;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace FiberPullStrain.CustomControl.view
{
    public partial class ButtonControls : UserControl, INotifyPropertyChanged
    {

        public ButtonControls()
        {
            DataContext = this;
            InitializeComponent();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private bool isRunning;

        public bool IsRunning
        {
            get { return isRunning; }
            set 
            { 
                isRunning = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsRunning"));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if(IsRunning) {  }
            else { }
            IsRunning = !IsRunning;
            var mainWindow = Window.GetWindow(this) as MainWindow;

            Point point = new Point();
            point.X = mainWindow.Left;
            point.Y = mainWindow.Top;
            if (mainWindow != null)
            {
                mainWindow.infobar.Text = "Adding new data point...";
                mainWindow.AddPoint1(point);
            }
        }

        private void cbmm_Click(object sender, RoutedEventArgs e)
        {
            cbinch.IsChecked = !cbinch.IsChecked;
            bool ok = Decimal.TryParse(inBoxDistance.tbBoundText, out Decimal ss);
            if (ok) 
            {
                if (cbmm.IsChecked == true)
                {
                    inBoxDistance.tbBoundText = (ss * (Decimal)2.54).ToString("F2");
                }
                else
                {
                    inBoxDistance.tbBoundText = (ss / (Decimal)2.54).ToString("F2");
                }
            }
        }

        private void cbinch_Click(object sender, RoutedEventArgs e)
        {
            cbmm.IsChecked = !cbmm.IsChecked;
            bool ok = Decimal.TryParse(inBoxDistance.tbBoundText, out Decimal ss);
            if(ok)
            {
                if (cbinch.IsChecked == true)
                {
                    inBoxDistance.tbBoundText = (ss / (Decimal)2.54).ToString("F2");
                }
                else
                {
                    inBoxDistance.tbBoundText = (ss * (Decimal)2.54).ToString("F2");
                }
            }

        }

        private void cbgrams_Click(object sender, RoutedEventArgs e)
        {
            cbnewton.IsChecked = ! cbnewton.IsChecked;
            bool ok = Decimal.TryParse(inBoxForce.tbBoundText, out Decimal ss);
            if(ok)
            {
                if (cbgrams.IsChecked == true)
                {
                    inBoxForce.tbBoundText = (ss * (Decimal)101.971621).ToString("F2");
                }
                else
                {
                    inBoxForce.tbBoundText = (ss / (Decimal)101.971621).ToString("F2");
                }
            }
        }

        private void cbnewton_Click(object sender, RoutedEventArgs e)
        {
            cbgrams.IsChecked = !cbgrams.IsChecked;
            bool ok = Decimal.TryParse(inBoxForce.tbBoundText, out Decimal ss);
            if(ok)
            {
                if (cbnewton.IsChecked == true)
                {
                    inBoxForce.tbBoundText = (ss / (Decimal)101.971621).ToString("F2");
                }
                else
                {
                    inBoxForce.tbBoundText = (ss * (Decimal)101.971621).ToString("F2");
                }
            }
        }

        private void btnDistanceSetOrigin_Click(object sender, RoutedEventArgs e)
        {
            inBoxDistance.tbBoundText = "0.00";
        }

        private void btnForceSetOrigin_Click(object sender, RoutedEventArgs e)
        {
            inBoxForce.tbBoundText = "0.00";
        }
    }
}
