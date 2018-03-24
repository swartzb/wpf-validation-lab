using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_validation_lab
{
    public class Model : INotifyPropertyChanged
    {
        private int _posInt1;

        public int PosInt1
        {
            get { return _posInt1; }
            set
            {
                if (value != _posInt1)
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("value must be positive");
                    }
                    _posInt1 = value;
                    NotifyPropertyChanged("PosInt1");

                }
            }
        }

        private int _posInt2;

        public int PosInt2
        {
            get { return _posInt2; }
            set
            {
                if (value != _posInt2)
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("value must be positive");
                    }
                    _posInt2 = value;
                    NotifyPropertyChanged("PosInt2");
                }
            }
        }

        private int _posInt3;

        public int PosInt3
        {
            get { return _posInt3; }
            set
            {
                if (value != _posInt3)
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("value must be positive");
                    }
                    _posInt3 = value;
                    NotifyPropertyChanged("PosInt3");
                }
            }
        }
        private int _posInt4;

        public int PosInt4
        {
            get { return _posInt4; }
            set
            {
                if (value != _posInt4)
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("value must be positive");
                    }
                    _posInt4 = value;
                    NotifyPropertyChanged("PosInt4");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
