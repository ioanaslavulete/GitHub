using System;
using System.Collections.ObjectModel;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;
using TravelAgency.Views;

namespace TravelAgency.ViewModels
{
    public class BookingViewModel
    {
        private HotelRepository _hotelRepository;
        private LocationRepository _locationRepository;
        private ObservableCollection<Location> _locationList;
        private ObservableCollection<AvailableOption> _availableOptionList;
        private Hotel _hotel;
        private AvailableOption _selectedAvailableOption;
        private ReservationPeriod _reservationPeriod;
        private Reservation _reservation;
        private Customer _customer;
        private Location _selectedLocation;

        private CheckAvailabilityCommand _checkAvailabilityCommand;
        private SeeDetailsCommand _seeDetailsCommand;

        public BookingViewModel()
        {
            _hotelRepository = DataManagementService.Instance.MainRepository.HotelRepository;
            _locationRepository = DataManagementService.Instance.MainRepository.LocationRepository;
            _locationList = _locationRepository.LocationList;
            _availableOptionList = new ObservableCollection<AvailableOption>();
            _hotel = new Hotel();
            _selectedAvailableOption = new AvailableOption();
            _reservationPeriod = new ReservationPeriod();
            _reservation = new Reservation();
            _selectedLocation = new Location();
            _customer = new Customer();

            _checkAvailabilityCommand = new CheckAvailabilityCommand(this);
            _seeDetailsCommand = new SeeDetailsCommand(this);
        }

        public ObservableCollection<Location> LocationList
        {
            get { return _locationList; }
            set
            {
                _locationList = value;
            }
        }
        public ObservableCollection<AvailableOption> AvailableOptionList
        {
            get
            {
                return _availableOptionList;
            }
            set
            {
                _availableOptionList = value;
            }
        }
        public Hotel Hotel
        {
            get
            {
                return _hotel;
            }
            set
            {
                _hotel = value;
            }
        }
        public AvailableOption SelectedAvailableOption
        {
            get
            {
                return _selectedAvailableOption;
            }
            set
            {
                _selectedAvailableOption = value;
            }
        }
        public ReservationPeriod ReservationPeriod
        {
            get { return _reservationPeriod; }
            set
            {
                _reservationPeriod = value;
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
            }
        }
        public Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
            }
        }
        public Location SelectedLocation
        {
            get
            {
                return _selectedLocation;
            }
            set
            {
                _selectedLocation = value;
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
        public SeeDetailsCommand SeeDetailsCommand
        {
            get
            {
                return _seeDetailsCommand;
            }
            set
            {
                _seeDetailsCommand = value;
            }
        }


        public void CheckAvailability()
        {
            AvailableOptionList.Clear();
            foreach (Hotel hotel in _hotelRepository.HotelList)
            {
                if (_selectedLocation.FullName == hotel.Location.FullName)
                {
                    if (hotel.HasRoomsAvailableIn(_reservationPeriod))
                    {
                        AvailableOption availableOption = new AvailableOption(hotel);
                        hotel.GetBestOptionFor(Reservation);
                        if (hotel.BestOption.Rooms.Count != 0)
                        {
                            hotel.BestOption.CalculateTotalPriceFor(ReservationPeriod);
                            _availableOptionList.Add(availableOption);
                        }

                    }
                }
               
            }
        }

        public void ShowHotelDetailsView()
        {
            HotelDetailsViewModel hotelDetailsViewModel = new HotelDetailsViewModel();
            hotelDetailsViewModel.SelectedHotel = _selectedAvailableOption.Hotel;
            hotelDetailsViewModel.ReservationPeriod = ReservationPeriod;
            hotelDetailsViewModel.SelectedHotel.AvailableRoomsList = _selectedAvailableOption.Hotel.AvailableRoomsList;

            HotelDetailsView view = new HotelDetailsView();
            view.DataContext = hotelDetailsViewModel;
            view.ShowDialog();
        }
    }
}
