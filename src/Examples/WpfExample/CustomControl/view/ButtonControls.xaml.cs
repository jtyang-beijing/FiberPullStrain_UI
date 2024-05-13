using Fiber.ScatterGraph;
using FiberPull;
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
        }

        private void cbinch_Click(object sender, RoutedEventArgs e)
        {
            cbmm.IsChecked = !cbmm.IsChecked;
        }

        private void cbgrams_Click(object sender, RoutedEventArgs e)
        {
            cbnewton.IsChecked = ! cbnewton.IsChecked;
        }

        private void cbnewton_Click(object sender, RoutedEventArgs e)
        {
            cbgrams.IsChecked = !cbgrams.IsChecked;
        }
    }
}
