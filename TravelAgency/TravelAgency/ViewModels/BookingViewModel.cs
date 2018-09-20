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
        private Reservation _reservation;
        private Location _selectedLocation;
        private ObservableCollection<Hotel> _hotelList;
        private ObservableCollection<Location> _locationList;
        private ObservableCollection<Hotel> _availableHotels;
        private CheckAvailabilityCommand _checkAvailabilityCommand;
        private ShowBookingVoucherCommand _showBookingVoucherCommand;

        public BookingViewModel()
        {
            _hotelList = DataManagementService.Instance.MainRepository.HotelRepository.HotelList;
            _locationList = DataManagementService.Instance.MainRepository.LocationRepository.LocationList;
            _reservation = new Reservation();
            _availableHotels = new ObservableCollection<Hotel>();
            _selectedLocation = new Location();

            _checkAvailabilityCommand = new CheckAvailabilityCommand(this);
            _showBookingVoucherCommand = new ShowBookingVoucherCommand(this);
        }

        public ObservableCollection<Location> LocationList
        {
            get { return _locationList; }
            set
            {
                _locationList = value;
            }
        }
        public ObservableCollection<Hotel> HotelsList
        {
            get
            {
                return _availableHotels;
            }
            set
            {
                _availableHotels = value;
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
        public Location SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                _selectedLocation = value;
            }
        }

        public void CheckAvailability()
        {
            _availableHotels.Clear();

            foreach (Hotel hotel in _hotelList)
            {
                if (hotel.Location.Equals(_selectedLocation))
                {
                    if (hotel.HasRoomsAvailableIn(_reservation.ReservationPeriod))
                    {
                        hotel.GetBestOptionFor(_reservation);
                        if (hotel.BestOption.HasRooms())
                        {
                            hotel.BestOption.CalculateTotalPriceFor(_reservation.ReservationPeriod);
                            _availableHotels.Add(hotel);
                        }
                    }
                }
            }
        }

        public void ShowBookingVoucherView()
        {
            BookingVoucherView bookingVoucherView = new BookingVoucherView();
            BookingVoucherViewModel bookingVoucherViewModel = new BookingVoucherViewModel();
             
            bookingVoucherViewModel.Reservation = new Reservation(_reservation.Owner, _reservation.Hotel, _reservation.ReservationPeriod, _reservation.NumberOfPersons); 
            bookingVoucherView.DataContext = bookingVoucherViewModel;
            bookingVoucherView.Show();
        }
    }
}
