namespace TravelAgency.Models
{
    public class Reservation
    {
        private ReservationPeriod _reservationPeriod;
        private string _numberOfPersons;
        private Customer _owner;
        private Hotel _hotel;

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
