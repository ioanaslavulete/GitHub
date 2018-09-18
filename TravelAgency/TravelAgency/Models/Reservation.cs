namespace TravelAgency.Models
{
    public class Reservation
    {
        
        private ReservationPeriod _reservationPeriod;
        private string _numberOfPersons;

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
        
    }
}
