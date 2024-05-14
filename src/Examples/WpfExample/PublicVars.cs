using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FiberPullStrain
{
    public partial class PublicVars: INotifyPropertyChanged
    {
        public Decimal DISTANCE_EXCHANGE_RATE = (Decimal)2.54;
        public Decimal FORCE_EXCHANGE_RATE = (Decimal)101.971621;

        public PublicVars()
        {
            MAX_VALUE_DISTANCE = "50"; 
            MAX_VALUE_FORCE = "5000";
        }
        private string max_value_distance;

        public string MAX_VALUE_DISTANCE
        {
            get { return max_value_distance; }
            set 
            { 
                max_value_distance = value;
                OnPropertyChanged();
            }
        }

        private string max_value_force;

        public string MAX_VALUE_FORCE
        {
            get { return max_value_force; }
            set 
            { 
                max_value_force = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName =null) 
        { 
        
        }
    }
}
