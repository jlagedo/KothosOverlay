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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
