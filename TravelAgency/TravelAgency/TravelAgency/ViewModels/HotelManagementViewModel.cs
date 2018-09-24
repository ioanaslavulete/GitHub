using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;
using TravelAgency.Models.Interfaces;


namespace TravelAgency.ViewModels
{
	public class HotelManagementViewModel : INotifyPropertyChanged
	{
		private AccomodationRepository _hotelRepository;
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

		private AddHotelCommand _addHotelCommand;
		private DeleteHotelCommand _deleteHotelCommand;
		private EditHotelCommand _editHotelCommand;
		private SaveHotelCommand _saveHotelCommand;
		private AddRoomCommand _addRoomCommand;
		private EditRoomCommand _editRoomCommand;
		private SaveRoomCommand _saveRoomCommand;

		public HotelManagementViewModel()
		{
			_hotelRepository = DataManagementService.Instance.MainRepository.AccomodationRepository;
			_locationRepository = DataManagementService.Instance.MainRepository.LocationRepository;

			_accomodationFactory = new AccomodationFactory();
			_accomodation = _accomodationFactory.BuildAccomodation(_acomodationType);
			_selectedAccomodation = _accomodationFactory.BuildAccomodation(_acomodationType);

            _roomFactory = new RoomFactory();
            _room = _roomFactory.BuildRoom(_roomType);
			_selectedRoom = _roomFactory.BuildRoom(_roomType);

            _addHotelCommand = new AddHotelCommand(this);
			_deleteHotelCommand = new DeleteHotelCommand(this);
			_editHotelCommand = new EditHotelCommand(this);
			_saveHotelCommand = new SaveHotelCommand(this);
			_addRoomCommand = new AddRoomCommand(this);
			_editRoomCommand = new EditRoomCommand(this);
			_saveRoomCommand = new SaveRoomCommand(this);
		}

		public AccomodationRepository HotelRepository
		{
			get { return _hotelRepository; }
			set
			{
				_hotelRepository = value;
			}
		}
		public IAccomodation Hotel
		{
			get { return _accomodation; }
			set
			{
				_accomodation = value;
				OnPropertyChanged();
			}
		}
		public IAccomodation SelectedHotel
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
		public AccomodationType AcomodationType
		{
			get
			{
				return _acomodationType;
			}

			set
			{
				_acomodationType = value;
				Hotel = _accomodationFactory.BuildAccomodation(_acomodationType);
				SelectedHotel = _accomodationFactory.BuildAccomodation(_acomodationType);
				OnPropertyChanged();
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

		public void AddAccomodation()
		{
			_hotelRepository.Add(_accomodation);
			_locationRepository.Add(_accomodation.Location);

			DataManagementService.Instance.SaveData();
			ClearHotelFields();
			ClearRoomFields();
		}

		public void DeleteAccomodation()
		{
			_locationRepository.Delete(_selectedAccomodation.Location, _hotelRepository);
			_hotelRepository.Delete(_selectedAccomodation);
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
				IRoom newRoom = new Room(_room.Price, _room.NumberOfPersons, _room.RoomViewType);
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
