using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TravelAgency.Models
{
    public class Room : INotifyPropertyChanged
    {
        private string _price;
        private string _numberOfPersons;
        private RoomViewType _roomViewType;

        public Room()
        {
            
        }

        public Room(string price, string numberOfPersons, RoomViewType roomViewType)
        {
            _price = price;
            _numberOfPersons = numberOfPersons;
            _roomViewType = roomViewType;
        }

        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }
        public string NumberOfPersons
        {
            get { return _numberOfPersons; }
            set
            {
                _numberOfPersons = value;
                OnPropertyChanged();
            }
        }
        public RoomViewType RoomViewType
        {
            get { return _roomViewType; }
            set
            {
                _roomViewType = value;
                OnPropertyChanged();
            }
        }
      
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}