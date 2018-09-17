using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TravelAgency.Models
{
    public class Hotel : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private Location _location;
        private ObservableCollection<Room> _roomList;
        private string _numberOfStars;
        

        public Hotel()
        {
            _location = new Location();
            _roomList = new ObservableCollection<Room>();
        }

        public Hotel(string id, string name, Location location, ObservableCollection<Room> roomList, string numberOfStars)
        {
            _id = id;
            _name = name;
            _location = location;
            _roomList = roomList;
            _numberOfStars = numberOfStars;
        }

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string NumberOfStars
        {
            get { return _numberOfStars; }
            set
            {
                _numberOfStars = value;
                OnPropertyChanged();
            }
        }
        public Location Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Room> RoomList
        {
            get { return _roomList; }
            set
            {
                _roomList = value;
                
            }
        }

        public void Add(Room newRoom)
        {
            _roomList.Add(newRoom);
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
