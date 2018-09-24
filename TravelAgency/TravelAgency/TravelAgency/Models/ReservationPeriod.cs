﻿using System;

namespace TravelAgency.Models
{
	[Serializable]
	public class ReservationPeriod
    {
        private DateTime _checkIn;
        private DateTime _checkOut;

        public ReservationPeriod(DateTime checkIn, DateTime checkOut)
        {
            _checkIn = checkIn;
            _checkOut = checkOut;
        }

        public ReservationPeriod()
        {
            _checkIn = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            _checkOut = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public DateTime CheckIn
        {
            get { return _checkIn; }
            set
            {
                _checkIn = value;
            }
        }
        public DateTime CheckOut
        {
            get { return _checkOut; }
            set
            {
                _checkOut = value;
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
    }
}
