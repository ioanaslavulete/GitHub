using System;
using System.Collections.ObjectModel;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;

namespace TravelAgency.ViewModels
{
    public class BookingViewModel
    {
        private HotelRepository _hotelRepository;
        private LocationRepository _locationRepository;
        private ObservableCollection<Location> _locationList;
        private CheckAvailabilityCommand _checkAvailabilityCommand;

        public BookingViewModel()
        {
            _locationRepository = DataManagementService.Instance.MainRepository.LocationRepository;
            _locationList = _locationRepository.LocationList;
            _checkAvailabilityCommand = new CheckAvailabilityCommand(this);
        }

        public ObservableCollection<Location> LocationList
        {
            get { return _locationList; }
            set
            {
                _locationList = value;
            }
        }

        public void CheckAvailability()
        {
            throw new NotImplementedException();
        }
    }
}
