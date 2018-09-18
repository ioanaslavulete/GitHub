using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TravelAgency.Models
{
    public class Hotel : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private Location _location;
        private ObservableCollection<Room> _roomList;
        private ObservableCollection<Room> _availableRoomsList;
        private string _numberOfStars;
        private ObservableCollection<Room> _bestOption;
        private string _bestOptionTotalPrice;

        public Hotel()
        {
            _location = new Location();
            _roomList = new ObservableCollection<Room>();
            _availableRoomsList = new ObservableCollection<Room>();
            _bestOption = new ObservableCollection<Room>();
        }

        public Hotel(string id, string name, Location location, ObservableCollection<Room> roomList, string numberOfStars)
        {
            _id = id;
            _name = name;
            _location = location;
            _roomList = roomList;
            _numberOfStars = numberOfStars;
            _availableRoomsList = new ObservableCollection<Room>();
            _bestOption = new ObservableCollection<Room>();
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
        public ObservableCollection<Room> AvailableRoomsList
        {
            get
            {
                return _availableRoomsList;
            }
            set
            {
                _availableRoomsList = value;
            }
        }
        public ObservableCollection<Room> BestOption
        {
            get
            {
                return _bestOption;
            }
            set
            {
                _bestOption = value;
            }
        }
        public string BestOptionString
        {
            get
            {
                string result = "";
                foreach (Room room in _bestOption)
                {
                    result += string.Format(room.NumberOfPersons + "persons" + " - " + room.Price + "ron/night" + "\n");
                }
                return result;
            }
        }
        public string BestOptionTotalPrice
        {
            get
            {
                return _bestOptionTotalPrice + " ron";
            }
        }

        public void CalculateTotalPriceFor(ReservationPeriod reservationPeriod)
        {
            int _totalPrice = 0;
            foreach(Room room in _bestOption)
            {
                _totalPrice += int.Parse(room.Price) * (reservationPeriod.CheckOut.Day - reservationPeriod.CheckIn.Day);
            }
            _bestOptionTotalPrice = _totalPrice.ToString();
        }

        public void Add(Room newRoom)
        {
            _roomList.Add(newRoom);
        }

        public bool HasRoomsAvailableIn(ReservationPeriod reservationPeriod)
        {
            AvailableRoomsList.Clear();
            if (_roomList.Count > 0)
            {
                foreach (Room room in _roomList)
                {
                    if (room.IsAvailableIn(reservationPeriod))
                        AddToAvailableRoomList(room);
                }

                if (AvailableRoomsList.Count > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private void AddToAvailableRoomList(Room room)
        {
            _availableRoomsList.Add(room);
        }

        public void GetBestOptionFor(Reservation reservation)
        {
            _bestOption.Clear();

            List<Room> newList = new List<Room>();
            foreach (Room room in _availableRoomsList)
                newList.Add(room);

            List<Room> orderedList = newList.OrderByDescending(o => o.NumberOfPersons).ToList();

            int numberOfPersons = int.Parse(reservation.NumberOfPersons);

            foreach (Room room in orderedList)
            {
                int roomCapacity = int.Parse(room.NumberOfPersons);
                if (numberOfPersons >= roomCapacity)
                {
                    _bestOption.Add(room);
                    numberOfPersons -= roomCapacity;
                    
                }
            }

            if (numberOfPersons > 0)
            {
                List<Room> orderedListAscending = newList.OrderBy(o => o.NumberOfPersons).ToList();

                foreach (Room room in orderedListAscending)
                {
                    int roomCapacity = int.Parse(room.NumberOfPersons);
                    if (numberOfPersons < roomCapacity)
                    {
                        _bestOption.Add(room);
                        return;
                    }
                }
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
