namespace TravelAgency.Models
{
	public class Reservation
	{
		private ReservationPeriod _reservationPeriod;
		private string _numberOfPersons;
		private Customer _owner;
		private Hotel _hotel;

		public Reservation()
		{
			_owner = new Customer();
			_hotel = new Hotel();
			_reservationPeriod = new ReservationPeriod();
		}

		public Reservation(Reservation reservation)
		{
			this._owner = reservation.Owner;
			this._numberOfPersons = reservation.NumberOfPersons;
			this.Hotel = reservation.Hotel;
			this._reservationPeriod = reservation.ReservationPeriod;
		}

		public string NumberOfPersons
		{
			get { return _numberOfPersons; }
			set
			{
				_numberOfPersons = value;
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
		public Customer Owner
		{
			get { return _owner; }
			set
			{
				_owner = value;
			}
		}
		public Hotel Hotel
		{
			get { return _hotel; }
			set
			{
				_hotel = value;
			}
		}
	}
}
