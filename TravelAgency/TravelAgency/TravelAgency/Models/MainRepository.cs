namespace TravelAgency.Models
{
	public class MainRepository
	{
		private ReservationRepository _reservationRepository;
		private HotelRepository _hotelRepository;
		private LocationRepository _locationRepository;

		public MainRepository()
		{
			_hotelRepository = new HotelRepository();
			_locationRepository = new LocationRepository();
			_reservationRepository = new ReservationRepository();
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
		public ReservationRepository ReservationRepository
		{
			get
			{
				return _reservationRepository;
			}

			set
			{
				_reservationRepository = value;
			}
		}
	}
}
