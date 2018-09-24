using System;

namespace TravelAgency.Models
{
	[Serializable]
	public class MainRepository
	{
		private ReservationRepository _reservationRepository;
		private AccomodationRepository _accomodationRepository;
		private LocationRepository _locationRepository;

		public MainRepository()
		{
			_accomodationRepository = new AccomodationRepository();
			_locationRepository = new LocationRepository();
			_reservationRepository = new ReservationRepository();
		}

		public AccomodationRepository AccomodationRepository
		{
			get { return _accomodationRepository; }
			set
			{
				_accomodationRepository = value;
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
