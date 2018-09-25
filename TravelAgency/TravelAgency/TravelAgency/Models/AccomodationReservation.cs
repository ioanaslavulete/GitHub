using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TravelAgency.Models.Interfaces;

namespace TravelAgency.Models
{
	[Serializable]
	public class AccomodationReservation : INotifyPropertyChanged
    {
        private IAccomodation _accomodation;
        private IRoom _room;
        private ReservationPeriod _reservationPeriod;

        public AccomodationReservation()
        {
            
            _reservationPeriod = new ReservationPeriod();
            _room = new Room();
        }

        public AccomodationReservation(IAccomodation accomodation, ReservationPeriod reservationPeriod, IRoom room)
        {
            _accomodation = accomodation;
            _reservationPeriod = reservationPeriod;
            _room = room;
        }

        public IAccomodation Hotel
        {
            get { return _accomodation; }
            set
            {
                _accomodation = value;
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
