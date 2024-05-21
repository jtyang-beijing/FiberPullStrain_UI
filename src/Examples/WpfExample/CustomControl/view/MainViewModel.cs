using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace FiberPullStrain.CustomControl.view
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private protected readonly SerialCommunication _serialcommunication;
        private Dispatcher _dispatcher;
        public MainViewModel(SerialCommunication serialCommunication)
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
            _serialcommunication = serialCommunication;
            _serialcommunication.DataReceived += _serialcommunication_DataReceived;
            //_serialcommunication.SimulateDataReceived("f:0f0f");
            //_serialcommunication.SimulateDataReceived("d:0d0d");
            //_serialcommunication.SimulateDataReceived("test infor....");
        }

        private void _serialcommunication_DataReceived(object sender, string e)
        {
            string[] str = e.Split(':');
            _dispatcher.Invoke(() =>
            {
                if (str[0] == "f")
                {
                    lb_Current_Force = str[1];
                }
                else if (str[0] == "d")
                {
                    lb_Current_Distance = str[1];
                }
                else
                {
                    Bar_Infor = e;
                }
            });

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

        private string bar_infor;

        public string Bar_Infor
        {
            get { return bar_infor; }
            set
            {
                bar_infor = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        /* method to execute when setter of a control setting new value
 * 
 */
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}