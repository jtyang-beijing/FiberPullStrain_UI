using FiberPull;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FiberPullStrain.CustomControl.view
{
    public partial class ButtonControls : UserControl
    {
        public MainWindow _mainwindow { get; set; }
        PublicVars publicVars = new PublicVars();
        public ButtonControls()
        {
            InitializeComponent() ;
            // initialized max value of input box. 
            inBoxDistance.MaxValue = publicVars.MAX_VALUE_DISTANCE;
            inBoxForce.MaxValue = publicVars.MAX_VALUE_FORCE;
            //lbCurrentDistance.Content = publicVars.CURRENT_DISTANCE;
            //lbCurrentForce.Content = publicVars.CURRENT_FORCE;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if(_mainwindow.viewModel.IsRunning) {  }
            else { }
            _mainwindow.viewModel.IsRunning = !_mainwindow.viewModel.IsRunning;
            var mainWindow = Window.GetWindow(this) as MainWindow;

            // main functions ----------------------------
            Point point = new Point();
            point.X = mainWindow.Left;
            point.Y = mainWindow.Top;
            if (mainWindow != null)
            {
                //mainWindow.infobar.Text = "Adding new data point...";
                //mainWindow.AddPoint1(point);
            }
            //lbCurrentDistance.Content = point.X.ToString("F2");
            //lbCurrentForce.Content = point.Y.ToString("F2");   
            //_mainwindow.viewModel.lb_Current_Distance = point.X.ToString("F2");
            //_mainwindow.viewModel.lb_Current_Force = point.Y.ToString("F2");
            //---------------------------------------------
            string _cmd = "m" + (Decimal.Parse(inBoxDistance.inputBox.Text)* publicVars.MOTOR_SCALE).ToString();
            _mainwindow.serialCommunication.myPort.WriteLine(_cmd);
        }

        private void cbmm_Click(object sender, RoutedEventArgs e)
        {
            cbinch.IsChecked = !cbinch.IsChecked;
            bool ok = Decimal.TryParse(inBoxDistance.inputBox.Text, out Decimal ss);
            if (ok) 
            {
                if (cbmm.IsChecked == true)
                {
                    inBoxDistance.MaxValue = publicVars.MAX_VALUE_DISTANCE;
                    inBoxDistance.inputBox.Text = (ss * publicVars.DISTANCE_EXCHANGE_RATE).ToString("F2");
                }
                else
                {
                    inBoxDistance.MaxValue = (Decimal.Parse(publicVars.MAX_VALUE_DISTANCE) /
                        publicVars.DISTANCE_EXCHANGE_RATE ).ToString("F2");
                    inBoxDistance.inputBox.Text = (ss / publicVars.DISTANCE_EXCHANGE_RATE).ToString("F2");
                }
            }
        }

        private void cbinch_Click(object sender, RoutedEventArgs e)
        {
            cbmm.IsChecked = !cbmm.IsChecked;
            bool ok = Decimal.TryParse(inBoxDistance.inputBox.Text, out Decimal ss);
            if(ok)
            {
                if (cbinch.IsChecked == true)
                {
                    inBoxDistance.MaxValue = (Decimal.Parse(publicVars.MAX_VALUE_DISTANCE) /
                        publicVars.DISTANCE_EXCHANGE_RATE).ToString("F2");
                    inBoxDistance.inputBox.Text = (ss / publicVars.DISTANCE_EXCHANGE_RATE).ToString("F2");

                }
                else
                {
                    inBoxDistance.MaxValue = publicVars.MAX_VALUE_DISTANCE;
                    inBoxDistance.inputBox.Text = (ss * publicVars.DISTANCE_EXCHANGE_RATE).ToString("F2");
                }
            }

        }

        private void cbgrams_Click(object sender, RoutedEventArgs e)
        {
            cbnewton.IsChecked = ! cbnewton.IsChecked;
            bool ok = Decimal.TryParse(inBoxForce.inputBox.Text, out Decimal ss);
            if(ok)
            {
                if (cbgrams.IsChecked == true)
                {
                    inBoxForce.MaxValue = publicVars.MAX_VALUE_FORCE;
                    inBoxForce.inputBox.Text = (ss * publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
                }
                else
                {
                    inBoxForce.MaxValue = (Decimal.Parse(publicVars.MAX_VALUE_FORCE) /
                        publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
                    inBoxForce.inputBox.Text = (ss / publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
                }
            }
        }

        private void cbnewton_Click(object sender, RoutedEventArgs e)
        {
            cbgrams.IsChecked = !cbgrams.IsChecked;
            bool ok = Decimal.TryParse(inBoxForce.inputBox.Text, out Decimal ss);
            if(ok)
            {
                if (cbnewton.IsChecked == true)
                {
                    inBoxForce.MaxValue = (Decimal.Parse(publicVars.MAX_VALUE_FORCE) /
                        publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
                    inBoxForce.inputBox.Text = (ss / publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
                }
                else
                {
                    inBoxForce.MaxValue = publicVars.MAX_VALUE_FORCE;
                    inBoxForce.inputBox.Text = (ss * publicVars.FORCE_EXCHANGE_RATE).ToString("F2");
                }
            }
        }

        private void btnDistanceSetOrigin_Click(object sender, RoutedEventArgs e)
        {
            _mainwindow.viewModel.lb_Current_Distance = "0.00";
        }

        private void btnForceSetOrigin_Click(object sender, RoutedEventArgs e)
        {
            _mainwindow.viewModel.lb_Current_Force = "0.00";
        }
    }
}
