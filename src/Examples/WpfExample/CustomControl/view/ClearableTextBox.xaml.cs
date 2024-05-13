using System.ComponentModel;
using System.Windows.Controls;
namespace FiberPullStrain.CustomControl.view
{
    public partial class ClearableTextBox : UserControl, INotifyPropertyChanged
    {
        public ClearableTextBox()
        {
            DataContext = this;
            InitializeComponent();
        }

        private string bountText;

        public event PropertyChangedEventHandler PropertyChanged;

        public string BoundText
        {
            get { return bountText; }
            set 
            { 
                bountText = value; 
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("BoundText"));
            }
        }


        private void btnClear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            inputBox.Clear();
            inputBox.Focus();
        }

        private void inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(inputBox.Text))
            {
                tbPlaceHolder.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                tbPlaceHolder.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
