using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public event PropertyChangedEventHandler PropertyChanged;

        private string tblbountText;
        public string tblBoundText
        {
            get { return tblbountText; }
            set 
            { 
                tblbountText = value; 
                OnPropertyChanged();
            }
        }

        private string tbbountText;
        public string tbBoundText
        {
            get { return tbbountText; }
            set
            {
                tbbountText = value;
                OnPropertyChanged();
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

        private void OnPropertyChanged([CallerMemberName]  string propertyName = null) 
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
