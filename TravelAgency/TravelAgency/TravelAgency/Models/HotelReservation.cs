using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TravelAgency.Models.Interfaces;

namespace TravelAgency.Models
{
	[Serializable]
	public class HotelReservation : INotifyPropertyChanged
    {
        private IAccomodation _hotel;
        private IRoom _room;
        private ReservationPeriod _reservationPeriod;

        public HotelReservation()
        {
            _hotel = new Hotel();
            _reservationPeriod = new ReservationPeriod();
            _room = new Room();
        }

        public HotelReservation(IAccomodation hotel, ReservationPeriod reservationPeriod, IRoom room)
        {
            _hotel = hotel;
            _reservationPeriod = reservationPeriod;
            _room = room;
        }

        public IAccomodation Hotel
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
        public IRoom Room
        {
            get { return _room; }
            set
            {
                _room = value;
                OnPropertyChanged();
            }
        }
		[field:NonSerialized]
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
