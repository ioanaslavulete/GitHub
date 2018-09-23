using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TravelAgency.Models
{
    public class HotelReservation : INotifyPropertyChanged
    {
        private Hotel _hotel;
        private Room _room;
        private ReservationPeriod _reservationPeriod;

        public HotelReservation()
        {
            _hotel = new Hotel();
            _reservationPeriod = new ReservationPeriod();
            _room = new Room();
        }

        public HotelReservation(Hotel hotel, ReservationPeriod reservationPeriod, Room room)
        {
            _hotel = hotel;
            _reservationPeriod = reservationPeriod;
            _room = room;
        }

        public Hotel Hotel
        {
            get { return _hotel; }
            set
            {
                _hotel = value;
                OnPropertyChanged();
            }
        }
        public ReservationPeriod ReservationPeriod
        {
            get { return _reservationPeriod; }
            set
            {
                _reservationPeriod = value;
                OnPropertyChanged();
            }
        }
        public Room Room
        {
            get { return _room; }
            set
            {
                _room = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
