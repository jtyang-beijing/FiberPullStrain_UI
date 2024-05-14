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
        
        /*
         Serve for value range limitation
         */
        public string MinValue
        {
            get { return GetValue(MinValueProperty).ToString(); }
            set { SetValue(MinValueProperty, value); }
        }

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(string), 
                typeof(ClearableTextBox), new PropertyMetadata("0"));// default value set to string "0"

        public string MaxValue
        {
            get { return GetValue(MaxValueProperty).ToString(); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(string), 
                typeof(ClearableTextBox), new PropertyMetadata("100"));// default value set to string "100"

        //-------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        // bount text for text block - place holder text
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
        // bount text for text input box
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
        {   /* dealing with place holder text. show when no inputs to text box
             * hide when input detected.
            */
            if(string.IsNullOrEmpty(inputBox.Text))
            {
                tbPlaceHolder.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                tbPlaceHolder.Visibility = System.Windows.Visibility.Hidden;
                if(!float.TryParse(inputBox.Text, out float v))
                {
                    inputBox.Text="Invalid";
                }
            }
            /*
             * dealing with value range limit.
             */
            if (float.TryParse(inputBox.Text, out float value))
            {
                if (value < float.Parse(MinValue))
                {
                    inputBox.Text = MinValue;
                }
                else if (value > float.Parse(MaxValue))
                {
                    inputBox.Text = MaxValue;
                }

                inputBox.SelectionStart = inputBox.Text.Length;
            }
        }

        /* method to execute when setter of a control setting new value
         * 
         */
        private void OnPropertyChanged([CallerMemberName]  string propertyName = null) 
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
