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
        public ReservationPeriod ReservationPeriod
        {
            get { return _reservationPeriod; }
            set
            {
                _reservationPeriod = value;
            }
        }

        public void CheckAvailability()
        {
            AvailableOptionList.Clear();
            foreach (Hotel hotel in _hotelRepository.HotelList)
            {
                if (hotel.HasRoomsAvailableIn(_reservationPeriod))
                {
                    AvailableOption availableOption = new AvailableOption(hotel);
                    _availableOptionList.Add(availableOption);
                }
            }
        }

        public void ShowHotelDetailsView()
        {
            HotelDetailsViewModel hotelDetailsViewModel = new HotelDetailsViewModel();
            hotelDetailsViewModel.SelectedHotel = _selectedAvailableOption.Hotel;

            HotelDetailsView view = new HotelDetailsView();
            view.DataContext = hotelDetailsViewModel;
            view.ShowDialog();
        }
    }
}
