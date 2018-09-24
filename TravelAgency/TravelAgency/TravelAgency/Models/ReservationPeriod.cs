using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TravelAgency.Models
{
    [Serializable]
    public class ReservationPeriod : INotifyPropertyChanged
    {
        private DateTime _checkIn;
        private DateTime _checkOut;

        public ReservationPeriod(DateTime checkIn, DateTime checkOut)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public ReservationPeriod()
        {
            CheckIn = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            CheckOut = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
        }

        public DateTime CheckIn
        {
            get { return _checkIn; }
            set
            {
                _checkIn = value;
                CheckOut = new DateTime(_checkIn.Year, _checkIn.Month, _checkIn.Day + 1);
                OnPropertyChanged();
            }
        }
        public DateTime CheckOut
        {
            get { return _checkOut; }
            set
            {
                _checkOut = value;
                OnPropertyChanged();
            }
        }

        public bool IsBefore(ReservationPeriod reservedPeriod)
        {
            int result = DateTime.Compare(_checkOut, reservedPeriod._checkIn);
            if (result < 0)
                return true;
            else
                return false;
        }

        public bool IsAfter(ReservationPeriod reservedPeriod)
        {
            int result = DateTime.Compare(_checkIn, reservedPeriod._checkOut);
            if (result > 0)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                var res = obj as ReservationPeriod;

                return this.CheckIn.Equals(res.CheckIn) && this.CheckOut.Equals(res.CheckOut);
            }
            return false;
        }

        [field: NonSerialized]
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
