﻿using System;
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

        public Hotel()
        {
            _location = new Location();
            _roomList = new ObservableCollection<Room>();
            _availableRoomsList = new ObservableCollection<Room>();
        }

        public Hotel(string id, string name, Location location, ObservableCollection<Room> roomList, string numberOfStars)
        {
            _id = id;
            _name = name;
            _location = new Location(location.CityName, location.CountryName);
            _roomList = roomList;
            _numberOfStars = numberOfStars;
            _availableRoomsList = new ObservableCollection<Room>();
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

		public ObservableCollection<Room> GetBestOptionFor(Reservation reservation)
		{
			var list = new ObservableCollection<Room>();

			List<Room> newList = new List<Room>();
			foreach (Room room in _availableRoomsList)
				newList.Add(room);

			var descendingList = newList.OrderByDescending(o => o.NumberOfPersons).ThenBy(o => o.Price).ToList();

			int numberOfPersons = int.Parse(reservation.NumberOfPersons);

			foreach (Room room in descendingList)
			{
				int roomCapacity = int.Parse(room.NumberOfPersons);
				if (numberOfPersons >= roomCapacity)
				{
					list.Add(room);
					numberOfPersons -= roomCapacity;
					newList.Remove(room);
				}
			}

			if (numberOfPersons > 0)
			{
				var ascendingList = newList.OrderBy(o => o.NumberOfPersons).ThenBy(o => o.Price).ToList();

				foreach (Room room in ascendingList)
				{
					int roomCapacity = int.Parse(room.NumberOfPersons);
					if (numberOfPersons < roomCapacity)
					{
						list.Add(room);
						return list;
					}
				}
			}

			if (numberOfPersons > 0)
				list.Clear();

			return list;
		}

		private void AddToAvailableRoomList(Room room)
        {
            _availableRoomsList.Add(room);

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
