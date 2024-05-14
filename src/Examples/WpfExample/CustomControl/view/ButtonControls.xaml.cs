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
        PublicVars publicVars = new PublicVars();
        public ButtonControls()
        {
            DataContext = this;
            InitializeComponent();
            // initialized max value of input box. 
            inBoxDistance.MaxValue = publicVars.MAX_VALUE_DISTANCE;
            inBoxForce.MaxValue = publicVars.MAX_VALUE_FORCE;
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
                    inBoxDistance.MaxValue = publicVars.MAX_VALUE_DISTANCE;
                    inBoxDistance.tbBoundText = (ss * publicVars.DISTANCE_EXCHANGE_RATE).ToString("F2");
                }
                else
                {
                    inBoxDistance.MaxValue = (Decimal.Parse(publicVars.MAX_VALUE_DISTANCE) /
                        publicVars.DISTANCE_EXCHANGE_RATE ).ToString("F2");
                    inBoxDistance.tbBoundText = (ss / publicVars.DISTANCE_EXCHANGE_RATE).ToString("F2");
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
                    inBoxDistance.MaxValue = (Decimal.Parse(publicVars.MAX_VALUE_DISTANCE) /
                        publicVars.DISTANCE_EXCHANGE_RATE).ToString("F2");
                    inBoxDistance.tbBoundText = (ss / publicVars.DISTANCE_EXCHANGE_RATE).ToString("F2");
                }
                else
                {
                    inBoxDistance.MaxValue = publicVars.MAX_VALUE_DISTANCE;
                    inBoxDistance.tbBoundText = (ss * publicVars.DISTANCE_EXCHANGE_RATE).ToString("F2");
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
                    inBoxForce.MaxValue = publicVars.MAX_VALUE_FORCE;
                    inBoxForce.tbBoundText = (ss * publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
                }
                else
                {
                    inBoxForce.MaxValue = (Decimal.Parse(publicVars.MAX_VALUE_FORCE) /
                        publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
                    inBoxForce.tbBoundText = (ss / publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
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
                    inBoxForce.MaxValue = (Decimal.Parse(publicVars.MAX_VALUE_FORCE) /
                        publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
                    inBoxForce.tbBoundText = (ss / publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
                }
                else
                {
                    inBoxForce.MaxValue = publicVars.MAX_VALUE_FORCE;
                    inBoxForce.tbBoundText = (ss * publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
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
