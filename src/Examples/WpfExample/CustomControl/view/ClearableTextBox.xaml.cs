using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        private void inputBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private void inputBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Allow the Delete key
            if (e.Key == Key.Delete) return;

            // Disallow spaces and other invalid keys
            if (e.Key == Key.Space || (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9))
            {
                e.Handled = true;
            }
        }
        private void inputBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+"); // Disallow non-numeric characters
            return !regex.IsMatch(text);
        }
    }
}
