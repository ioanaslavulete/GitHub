using TravelAgency.ViewModels;

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

        public Reservation(Customer owner, Hotel hotel, ReservationPeriod reservationPeriod, string numberOfPersons, Option bestOption)
        {
            Owner = new Customer(owner.Id, owner.FirstName, owner.LastName, owner.Email, owner.PhoneNumber);
            Hotel = new Hotel(hotel.Id, hotel.Name, hotel.Location, hotel.RoomList, hotel.NumberOfStars);
            ReservationPeriod = new ReservationPeriod(reservationPeriod.CheckIn, reservationPeriod.CheckOut);
            NumberOfPersons = numberOfPersons;
			BestOption = bestOption;
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

		public Option BestOption { get; set; }
	}
}
