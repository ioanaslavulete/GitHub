using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;
using TravelAgency.Models.Interfaces;
using System.Windows;

namespace TravelAgency.ViewModels
{
    public class AccomodationManagementViewModel : INotifyPropertyChanged
    {
        private AccomodationRepository _accomodationRepository;
        private LocationRepository _locationRepository;
        private IAccomodation _accomodation;
        private IAccomodation _selectedAccomodation;
        private IRoom _room;
        private IRoom _selectedRoom;
        private int _numberOfRooms;
        private RoomFactory _roomFactory;
        private RoomType _roomType;

        private AccomodationType _acomodationType;
        private AccomodationFactory _accomodationFactory;

        private AddAccomodationCommand _addAccomodationCommand;
        private DeleteAccomodationCommand _deleteAccomodationCommand;
        private EditAccomodationCommand _editAccomodationCommand;
        private SaveAccomodationCommand _saveAccomodationCommand;
        private AddRoomCommand _addRoomCommand;
        private EditRoomCommand _editRoomCommand;
        private SaveRoomCommand _saveRoomCommand;

        public AccomodationManagementViewModel()
        {
            _accomodationRepository = DataManagementService.Instance.MainRepository.AccomodationRepository;
            _locationRepository = DataManagementService.Instance.MainRepository.LocationRepository;

            _accomodationFactory = new AccomodationFactory();
            _accomodation = _accomodationFactory.BuildAccomodation(_acomodationType);
            _selectedAccomodation = _accomodationFactory.BuildAccomodation(_acomodationType);

            _roomFactory = new RoomFactory();
            _room = _roomFactory.BuildRoom(_roomType);
            _selectedRoom = _roomFactory.BuildRoom(_roomType);

            _addAccomodationCommand = new AddAccomodationCommand(this);
            _deleteAccomodationCommand = new DeleteAccomodationCommand(this);
            _editAccomodationCommand = new EditAccomodationCommand(this);
            _saveAccomodationCommand = new SaveAccomodationCommand(this);
            _addRoomCommand = new AddRoomCommand(this);
            _editRoomCommand = new EditRoomCommand(this);
            _saveRoomCommand = new SaveRoomCommand(this);
        }

        public AccomodationRepository AccomodationRepository
        {
            get { return _accomodationRepository; }
            set
            {
                _accomodationRepository = value;
            }
        }
        public IAccomodation Accomodation
        {
            get { return _accomodation; }
            set
            {
                _accomodation = value;
                OnPropertyChanged();
            }
        }
        public IAccomodation SelectedAccomodation
        {
            get
            {
                return _selectedAccomodation;
            }
            set
            {
                _selectedAccomodation = value;
                OnPropertyChanged();
            }
        }
        public IRoom Room
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
        public IRoom SelectedRoom
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
        public List<CurrencyType> CurrencyTypeList
        {
            get
            {
                return Enum.GetValues(typeof(CurrencyType)).Cast<CurrencyType>().ToList<CurrencyType>();
            }
        }
        public AccomodationType AcomodationType
        {
            get
            {
                return _acomodationType;
            }

            set
            {
                _acomodationType = value;
                Accomodation = _accomodationFactory.BuildAccomodation(_acomodationType);
                SelectedAccomodation = _accomodationFactory.BuildAccomodation(_acomodationType);
                OnPropertyChanged();
            }
        }

        public AddAccomodationCommand AddAccomodationCommand
        {
            get
            {
                return _addAccomodationCommand;
            }
            set
            {
                _addAccomodationCommand = value;
            }
        }
        public DeleteAccomodationCommand DeleteAccomodationCommand
        {
            get
            {
                return _deleteAccomodationCommand;
            }
            set
            {
                _deleteAccomodationCommand = value;
            }
        }
        public EditAccomodationCommand EditAccomodationCommand
        {
            get
            {
                return _editAccomodationCommand;
            }
            set
            {
                _editAccomodationCommand = value;
            }
        }
        public SaveAccomodationCommand SaveAccomodationCommand
        {
            get
            {
                return _saveAccomodationCommand;
            }
            set
            {
                _saveAccomodationCommand = value;
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

        public void AddAccomodation()
        {
            if (_accomodationRepository.HasAccomodationWithId(_accomodation.Id) == false)
            {
                _accomodationRepository.Add(_accomodation);
                _locationRepository.Add(_accomodation.Location);

                DataManagementService.Instance.SaveData();
                ClearAccomodationFields();
                ClearRoomFields();
            }
            else
                MessageBox.Show("This id already exists");

        }

        public void DeleteAccomodation()
        {
            _locationRepository.Delete(_selectedAccomodation.Location, _accomodationRepository);
            _accomodationRepository.Delete(_selectedAccomodation);
            DataManagementService.Instance.SaveData();
        }

        public void EditAccomodation()
        {
            Accomodation = SelectedAccomodation;
        }

        public void SaveAccomodation()
        {
            SelectedAccomodation = Accomodation;
            DataManagementService.Instance.SaveData();
            ClearAccomodationFields();
        }

        public void AddRoom()
        {
            for (int i = 1; i <= NumberOfRooms; i++)
            {
                Price roomPrice = new Price(_room.Price.Value, _room.Price.Currency);
                IRoom newRoom = new Room(roomPrice, _room.NumberOfPersons, _room.RoomViewType);
                _accomodation.Add(newRoom);
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

        public void ClearAccomodationFields()
        {
            Accomodation = _accomodationFactory.BuildAccomodation(_acomodationType);
        }

        public void ClearRoomFields()
        {
            Room = _roomFactory.BuildRoom(_roomType);
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
