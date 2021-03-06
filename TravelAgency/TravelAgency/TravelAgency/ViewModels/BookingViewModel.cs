﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Models.Interfaces;
using TravelAgency.Services;
using TravelAgency.Views;

namespace TravelAgency.ViewModels
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        private Reservation _reservation;
        private ReservationRepository _reservationRepository;
        private Location _selectedLocation;
        private ObservableCollection<IAccomodation> _accomodationList;
        private ObservableCollection<IAccomodation> _availableAccomodations;
        private ObservableCollection<Location> _locationList;
        private ObservableCollection<Option> _availableOptions;
        private Option _selectedOption;
        private RoomFactory _roomFactory;
        private RoomType _roomType;
        private ObservableCollection<IRoom> _roomsToReserve;
        private IRoom _selectedRoom;

        private CheckAvailabilityCommand _checkAvailabilityCommand;
        private ShowBookingVoucherCommand _showBookingVoucherCommand;
        private GetCustomerInfoCommand _getCustomerInfoCommand;
        private EmptyCustomerFieldsCommand _newCustomerCommand;
        private AddRoomToReservationCommand _addRoomToReservationCommand;

        public BookingViewModel()
        {
            _accomodationList = DataManagementService.Instance.MainRepository.AccomodationRepository.AccomodationList;
            _locationList = DataManagementService.Instance.MainRepository.LocationRepository.LocationList;
            _reservationRepository = DataManagementService.Instance.MainRepository.ReservationRepository;

            _reservation = new Reservation();
            _selectedLocation = new Location();
            _selectedOption = new Option();
            _availableOptions = new ObservableCollection<Option>();

            _roomsToReserve = new ObservableCollection<IRoom>();
            _roomFactory = new RoomFactory();
            _selectedRoom = _roomFactory.BuildRoom(_roomType);

            _checkAvailabilityCommand = new CheckAvailabilityCommand(this);
            _showBookingVoucherCommand = new ShowBookingVoucherCommand(this);
            _getCustomerInfoCommand = new GetCustomerInfoCommand(this);
            _newCustomerCommand = new EmptyCustomerFieldsCommand(this);
            _addRoomToReservationCommand = new AddRoomToReservationCommand(this);
        }

        public ObservableCollection<Location> LocationList
        {
            get { return _locationList; }
            set
            {
                _locationList = value;
            }
        }
        public ObservableCollection<IAccomodation> AccomodationsList
        {
            get
            {
                return _availableAccomodations;
            }
            set
            {
                _availableAccomodations = value;
            }
        }
        public Reservation Reservation
        {
            get
            {
                return _reservation;
            }
            set
            {
                _reservation = value;
                OnPropertyChanged();
            }
        }
        public Location SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                _selectedLocation = value;
            }
        }
        public ObservableCollection<Option> AvailableOptions
        {
            get
            {
                return _availableOptions;
            }
            set
            {
                _availableOptions = value;
            }
        }
        public Option SelectedOption
        {
            get
            {
                return _selectedOption;
            }

            set
            {
                _selectedOption = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<IRoom> RoomsToReserve
        {
            get { return _roomsToReserve; }
            set
            {
                _roomsToReserve = value;
            }
        }
        public IRoom SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
            }
        }

        public CheckAvailabilityCommand CheckAvailabilityCommand
        {
            get
            {
                return _checkAvailabilityCommand;
            }
            set
            {
                _checkAvailabilityCommand = value;
            }
        }
        public ShowBookingVoucherCommand ShowBookingVoucherCommand
        {
            get
            {
                return _showBookingVoucherCommand;
            }
            set
            {
                _showBookingVoucherCommand = value;
            }
        }
        public GetCustomerInfoCommand GetCustomerInfoCommand
        {
            get
            {
                return _getCustomerInfoCommand;
            }
            set
            {
                _getCustomerInfoCommand = value;
            }
        }
        public EmptyCustomerFieldsCommand EmptyCustomerFieldsCommand
        {
            get
            {
                return _newCustomerCommand;
            }

            set
            {
                _newCustomerCommand = value;
            }
        }
        public AddRoomToReservationCommand AddRoomToReservationCommand
        {
            get { return _addRoomToReservationCommand; }
            set
            {
                _addRoomToReservationCommand = value;
            }
        }

        public void CheckAvailability()
        {
            AvailableOptions.Clear();

            foreach (IAccomodation accomodation in _accomodationList)
            {
                if (accomodation.HasSameLocationAs(_selectedLocation))
                {
                    if (accomodation.HasRoomsAvailableIn(_reservation.ReservationPeriod))
                    {
                        Option option = new Option(accomodation, accomodation.GetBestOptionFor(_reservation));
                        option.ComputeTotalPriceFor(_reservation.ReservationPeriod);
                        AvailableOptions.Add(option);
                    }
                }
            }
        }

        public void GetCustomerInfo()
        {
            Reservation.Owner = _reservationRepository.GetOwnerWithId(_reservation.Owner.Id);
        }

        public void EmptyCustomerFields()
        {
            Reservation = new Reservation();
        }

        public void ShowBookingVoucherView()
        {
            BookingVoucherView bookingVoucherView = new BookingVoucherView();
            BookingVoucherViewModel bookingVoucherViewModel = new BookingVoucherViewModel();

            if (_roomsToReserve.Count != 0)
            {
                ObservableCollection<IRoom> newList = new ObservableCollection<IRoom>();
                foreach (IRoom room in _roomsToReserve)
                {
                    newList.Add(room);
                }
                _selectedOption.RoomList = newList;
            }
           
            bookingVoucherViewModel.Reservation = new Reservation(_reservation.Owner, _selectedOption.Hotel, _reservation.ReservationPeriod, _reservation.NumberOfPersons, _selectedOption);
            bookingVoucherView.DataContext = bookingVoucherViewModel;
           
            bookingVoucherView.Show();
            Reservation = new Reservation();
            
            AvailableOptions.Clear();
            RoomsToReserve.Clear();
        }

        public void AddRoomToReservation()
        {
            _roomsToReserve.Add(_selectedRoom);
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
