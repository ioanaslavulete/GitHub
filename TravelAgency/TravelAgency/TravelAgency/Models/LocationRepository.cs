using System;
using System.Collections.ObjectModel;

namespace TravelAgency.Models
{
	[Serializable]
	public class LocationRepository
    {
        private ObservableCollection<Location> _locationList;

        public LocationRepository()
        {
            _locationList = new ObservableCollection<Location>();
        }

        public ObservableCollection<Location> LocationList
        {
            get { return _locationList; }
            set
            {
                _locationList = value;
            }
        }

        public void Add(Location newLocation)
        {
            foreach(Location location in _locationList)
            {
                if (_locationList.Contains(newLocation))
                    return;
            }
            _locationList.Add(newLocation);
        }

        public void Delete(Location location, AccomodationRepository hotelRepository)
        {
           int locationCount = 0;
           foreach(Hotel hotel in hotelRepository.HotelList)
            {
                if (hotel.Location.FullName == location.FullName)
                    locationCount++;
            }

            if (locationCount == 1)
                _locationList.Remove(location);
        }
    }
}
