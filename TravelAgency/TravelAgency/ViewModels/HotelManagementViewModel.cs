using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;

namespace TravelAgency.ViewModels
{
    public class HotelManagementViewModel : INotifyPropertyChanged
    {
        private HotelRepository _hotelRepository;
        private LocationRepository _locationRepository;
        private Hotel _hotel;
        private Hotel _selectedHotel;
        private Room _room;
        private Room _selectedRoom;
        private int _numberOfRooms;
        private AddHotelCommand _addHotelCommand;
        private DeleteHotelCommand _deleteHotelCommand;
        private EditHotelCommand _editHotelCommand;
        private SaveHotelCommand _saveHotelCommand;
        private AddRoomCommand _addRoomCommand;
        private EditRoomCommand _editRoomCommand;
        private SaveRoomCommand _saveRoomCommand;

        public HotelManagementViewModel()
        {
            _hotelRepository = DataManagementService.Instance.MainRepository.HotelRepository;
            _locationRepository = DataManagementService.Instance.MainRepository.LocationRepository;
            _hotel = new Hotel();
            _selectedHotel = new Hotel();
            _room = new Room();
            _selectedRoom = new Room();
            _addHotelCommand = new AddHotelCommand(this);
            _deleteHotelCommand = new DeleteHotelCommand(this);
            _editHotelCommand = new EditHotelCommand(this);
            _saveHotelCommand = new SaveHotelCommand(this);
            _addRoomCommand = new AddRoomCommand(this);
            _editRoomCommand = new EditRoomCommand(this);
            _saveRoomCommand = new SaveRoomCommand(this);
        }

        public HotelRepository HotelRepository
        {
            get { return _hotelRepository; }
            set
            {
                _hotelRepository = value;
            }
        }
        public Hotel Hotel
        {
            get { return _hotel; }
            set
            {
                _hotel = value;
                OnPropertyChanged();
            }
        }
        public Hotel SelectedHotel
        {
            get
            {
                return _selectedHotel;
            }
            set
            {
                _selectedHotel = value;
                OnPropertyChanged();
            }
        }
        public Room Room
        {
            get
            {
                return _room;
            }
            set
            {
                _room = value;
                OnPropertyChanged();
            }
        }
        public Room SelectedRoom
        {
            get
            {
                return _selectedRoom;
            }
            set
            {
                _selectedRoom = value;
                OnPropertyChanged();
            }
        }
        public int NumberOfRooms
        {
            get
            {
                return _numberOfRooms;
            }
            set
            {
                _numberOfRooms = value;
            }
        }
        public List<RoomViewType> RoomViewTypeList
        {
            get
            {
                return Enum.GetValues(typeof(RoomViewType)).Cast<RoomViewType>().ToList<RoomViewType>();
            }
        }
        public AddHotelCommand AddHotelCommand
        {
            get
            {
                return _addHotelCommand;
            }
            set
            {
                _addHotelCommand = value;
            }
        }
        public DeleteHotelCommand DeleteHotelCommand
        {
            get
            {
                return _deleteHotelCommand;
            }
            set
            {
                _deleteHotelCommand = value;
            }
        }
        public EditHotelCommand EditHotelCommand
        {
            get
            {
                return _editHotelCommand;
            }
            set
            {
                _editHotelCommand = value;
            }
        }
        public SaveHotelCommand SaveHotelCommand
        {
            get
            {
                return _saveHotelCommand;
            }
            set
            {
                _saveHotelCommand = value;
            }
        }
        public AddRoomCommand AddRoomCommand
        {
            get
            {
                return _addRoomCommand;
            }
            set
            {
                _addRoomCommand = value;
            }
        }
        public EditRoomCommand EditRoomCommand
        {
            get
            {
                return _editRoomCommand;
            }
            set
            {
                _editRoomCommand = value;
            }
        }
        public SaveRoomCommand SaveRoomCommand
        {
            get
            {
                return _saveRoomCommand;
            }
            set
            {
                _saveRoomCommand = value;
            }
        }

        public void AddHotel()
        {
            Hotel newHotel = new Hotel(_hotel.Id, _hotel.Name, _hotel.Location, _hotel.RoomList, _hotel.NumberOfStars);
            _hotelRepository.Add(newHotel);
            _locationRepository.Add(_hotel.Location);

            DataManagementService.Instance.SaveData();
            ClearHotelFields();
            ClearRoomFields();
        }

        public void DeleteHotel()
        {
            _locationRepository.Delete(_selectedHotel.Location, _hotelRepository);
            _hotelRepository.Delete(_selectedHotel);
            DataManagementService.Instance.SaveData();
        }

        public void EditHotel()
        {
            Hotel = SelectedHotel;
        }

        public void SaveHotel()
        {
            SelectedHotel = Hotel;
            DataManagementService.Instance.SaveData();
            ClearHotelFields();
        }

        public void AddRoom()
        {
            for (int i = 1; i <= NumberOfRooms; i++)
            {
                Room newRoom = new Room(_room.Price, _room.NumberOfPersons, _room.RoomViewType);
                _hotel.Add(newRoom);                
            }
            DataManagementService.Instance.SaveData();
            ClearRoomFields();
        }

        public void EditRoom()
        {
            Room = SelectedRoom;
        }

        public void SaveRoom()
        {
            SelectedRoom = Room;
            DataManagementService.Instance.SaveData();
            ClearRoomFields();
        }

        public void ClearHotelFields()
        {
            Hotel = new Hotel();
        }

        public void ClearRoomFields()
        {
            Room = new Room();
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
