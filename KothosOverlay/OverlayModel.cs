using System.Collections.ObjectModel;
using System.ComponentModel;

namespace KothosOverlay
{
    public class OverlayModel : INotifyPropertyChanged
    {
        private string _messageLog;

        public string MessageLog
        {
            get => _messageLog;
            set
            {
                _messageLog = value; NotifyPropertyChanged("MessageLog");
            }
        }

        public ObservableCollection<PlayerModel> Players { get; set; }

        public OverlayModel()
        {
            MessageLog = string.Empty;
            Players = new ObservableCollection<PlayerModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PlayerModel : INotifyPropertyChanged
    {
        private string _name;
        private double _dps;

        private string _dpsEnc;
        private string _criticalEnc;
        private string _directEnc;
        private string _directCritEnc;

        public string Name
        {
            get => _name;
            set
            {
                _name = value; NotifyPropertyChanged("Name");
            }
        }

        public double DPS
        {
            get => _dps;
            set
            {
                _dps = value; NotifyPropertyChanged("DPS");
            }
        }

        public string DPSEnc
        {
            get => _dpsEnc;
            set
            {
                _dpsEnc = value; NotifyPropertyChanged("DPSEnc");
            }
        }

        public string CriticalEnc
        {
            get => _criticalEnc;
            set
            {
                _criticalEnc = value; NotifyPropertyChanged("CriticalEnc");
            }
        }

        public string DirectEnc
        {
            get => _directEnc;
            set
            {
                _directEnc = value; NotifyPropertyChanged("DirectEnc");
            }
        }

        public string DirectCritEnc
        {
            get => _directCritEnc;
            set
            {
                _directCritEnc = value; NotifyPropertyChanged("DirectCritEnc");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
