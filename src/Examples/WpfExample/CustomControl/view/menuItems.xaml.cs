using FiberPull;
using System.Windows;
using System.Windows.Controls;

namespace FiberPullStrain.CustomControl.view
{
    public partial class menuItems : UserControl
    {
        public menuItems()
        {
            InitializeComponent();
        }

        private void mnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void mnAboutProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("In-Suit Fiber Pull Strain Test Stage" +
                "\nVersion 1.0.0", "Information",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void mnAboutSupport_Click(object sender, RoutedEventArgs e)
        {
            About about = new About
            {
                Width = 500,
                Height = 500
            };
            about.Show();
        }
    }
}
