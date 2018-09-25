using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TravelAgency.Models.Interfaces;

namespace TravelAgency.Models
{
	[Serializable]
	public class Hotel : INotifyPropertyChanged, IAccomodation, IDataErrorInfo
    {
        private string _id;
        private string _name;
        private Location _location;
        private ObservableCollection<IRoom> _roomList;
        private ObservableCollection<IRoom> _availableRoomsList;
        private string _numberOfStars;
        string acceptsOnlyNumbers = "^[0-9]+$";
        string acceptsOnlyLettersAndSpaces = "^[A-Za-z ]+$";
        string acceptsOnlyDigitsOneToFive = "^[1-5]{1}$";

        public Hotel()
        {
            _location = new Location();
            _roomList = new ObservableCollection<IRoom>();
            _availableRoomsList = new ObservableCollection<IRoom>();
        }

        public Hotel(string id, string name, Location location, ObservableCollection<IRoom> roomList, string numberOfStars)
        {
            _id = id;
            _name = name;
            _location = new Location(location.CityName, location.CountryName);
            _roomList = roomList;
            _numberOfStars = numberOfStars;
            _availableRoomsList = new ObservableCollection<IRoom>();
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
        public ObservableCollection<IRoom> RoomList
        {
            get { return _roomList; }
            set
            {
                _roomList = value;
            }
        }
        public ObservableCollection<IRoom> AvailableRoomsList
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

        public void Add(IRoom newRoom)
        {
            _roomList.Add(newRoom);
        }

        public bool HasRoomsAvailableIn(ReservationPeriod reservationPeriod)
        {
            ComputeAvailableRoomsIn(reservationPeriod);

            if (_availableRoomsList.Count > 0)
                return true;
            else
                return false;
        }

        public ObservableCollection<IRoom> GetBestOptionFor(Reservation reservation)
        {
            ObservableCollection<IRoom> bestOptionList = new ObservableCollection<IRoom>();

            // Store rooms in a new list so they can be ordered (observable collection does not support OrderBy
            List<IRoom> newList = new List<IRoom>();
            foreach (IRoom room in _availableRoomsList)
                newList.Add(room);

            List<IRoom> descendingList = newList.OrderByDescending(o => o.NumberOfPersons).ThenBy(o => o.Price).ToList();

            int numberOfPersons = int.Parse(reservation.NumberOfPersons);

            foreach (IRoom room in descendingList)
            {
                int roomCapacity = int.Parse(room.NumberOfPersons);
                if (numberOfPersons >= roomCapacity)
                {
                    bestOptionList.Add(room);
                    numberOfPersons -= roomCapacity;
                    newList.Remove(room);
                }
            }

            if (numberOfPersons > 0)
            {
                List<IRoom> ascendingList = newList.OrderBy(o => o.NumberOfPersons).ThenBy(o => o.Price).ToList();

                foreach (IRoom room in ascendingList)
                {
                    int roomCapacity = int.Parse(room.NumberOfPersons);
                    if (numberOfPersons < roomCapacity)
                    {
                        bestOptionList.Add(room);
                        return bestOptionList;
                    }
                }
            }

            // If there are still persons left without rooms, it means that the hotel does not have enough rooms for the reservation
            if (numberOfPersons > 0)
                bestOptionList.Clear();

            return bestOptionList;
        }

        public bool HasSameLocationAs(Location selectedLocation)
        {
            return _location.Equals(selectedLocation);
        }

        private void AddToAvailableRoomList(IRoom room)
        {
            _availableRoomsList.Add(room);
        }

        private void ComputeAvailableRoomsIn(ReservationPeriod reservationPeriod)
        {
            _availableRoomsList.Clear();
            if (_roomList.Count > 0)
            {
                foreach (IRoom room in _roomList)
                {
                    if (room.IsAvailableIn(reservationPeriod))
                        AddToAvailableRoomList(room);
                }
            }
        }

        public bool IsValid()
        {
            if (((string.IsNullOrEmpty(Id)) || Regex.IsMatch(Id, acceptsOnlyNumbers) == false) || (string.IsNullOrEmpty(Name) || Regex.IsMatch(Name, acceptsOnlyLettersAndSpaces) == false)
                || (string.IsNullOrEmpty(NumberOfStars) || Regex.IsMatch(NumberOfStars, acceptsOnlyDigitsOneToFive) == false))
                return false;
            else
                return true;
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string propertyName]
        {
            
            get
            {
                string error = string.Empty;

                if (propertyName == "Id")
                {
                    if (string.IsNullOrEmpty(Id))
                        error = "";
                    else if(Regex.IsMatch(Id, acceptsOnlyNumbers) == false )
                        error = "✘";
                }

                if(propertyName == "Name")
                {
                    if (string.IsNullOrEmpty(Name))
                        error = "";
                   else if(Regex.IsMatch(Name, acceptsOnlyLettersAndSpaces) == false)
                        error = "✘";
                }

                if(propertyName == "NumberOfStars")
                {
                    if (string.IsNullOrEmpty(NumberOfStars))
                        error = "";
                   else if (Regex.IsMatch(NumberOfStars, acceptsOnlyDigitsOneToFive) == false)
                        error = "✘";
                }

                return error;
            }
        }


        [field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public bool HasId(string id)
        {
            if (_id == id)
                return true;
            else
                return false;
        }
    }
}
