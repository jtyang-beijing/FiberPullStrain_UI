using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FiberPullStrain.CustomControl.view
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MainViewModel()
        {
            
        }

        private bool isRunning;

        public bool IsRunning
        {
            get { return isRunning; }
            set
            {
                isRunning = value;
                OnPropertyChanged();
            }
        }

        private string lb_current_distance;

        public string lb_Current_Distance
        {
            get { return lb_current_distance; }
            set 
            { 
                lb_current_distance = value; 
                OnPropertyChanged();
            }
        }

        private string lb_current_force;

        public string lb_Current_Force
        {
            get { return lb_current_force; }
            set
            {
                lb_current_force = value;
                OnPropertyChanged();
            }
        }

        /* method to execute when setter of a control setting new value
 * 
 */
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
