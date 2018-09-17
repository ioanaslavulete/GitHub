namespace TravelAgency.Models
{
    public class MainRepository
    {
        private HotelRepository _hotelRepository;
        private LocationRepository _locationRepository;

        public MainRepository()
        {
            _hotelRepository = new HotelRepository();
            _locationRepository = new LocationRepository();
        }

        public HotelRepository HotelRepository
        {
            get { return _hotelRepository; }
            set
            {
                _hotelRepository = value;
            }
        }
        public LocationRepository LocationRepository
        {
            get { return _locationRepository; }
            set
            {
                _locationRepository = value;
            }
        }
    }
}
