﻿using System;
using System.Collections.ObjectModel;
using TravelAgency.Models;

namespace TravelAgency.Models
{
	using TravelAgency.Models.Interfaces;

	[Serializable]
	public class Option
	{
		private IAccomodation _accomodation;
		private ObservableCollection<IRoom> _roomList;
        private Price _totalPrice;

        public Option(IAccomodation accomodation, ObservableCollection<IRoom> roomList)
		{
			this._accomodation = accomodation;
			this._roomList = roomList;
            _totalPrice = new Price();
		}

		public Option()
		{
			_accomodation = new Hotel();
			_roomList = new ObservableCollection<IRoom>();
            _totalPrice = new Price();
		}

		public IAccomodation Hotel
		{
			get
			{
				return _accomodation;
			}

			set
			{
				_accomodation = value;
			}
		}
		public ObservableCollection<IRoom> RoomList
		{
			get
			{
				return _roomList;
			}

			set
			{
				_roomList = value;
			}
		}

		public string Result
		{
			get
			{
				string result = "";
				foreach (Room room in _roomList)
				{
					result += string.Format(room.NumberOfPersons + " persons" + " - " + room.Price  + "\n");
				}
				return result;
			}
		}

        public Price TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
            }
        }

        public void ComputeTotalPriceFor(ReservationPeriod reservationPeriod)
        {
            double sum = 0;
            foreach (Room room in _roomList)
            {
                double roomPrice = double.Parse(room.Price.Value);
                sum += roomPrice * (reservationPeriod.CheckOut.Day - reservationPeriod.CheckIn.Day);
                _totalPrice.Currency = room.Price.Currency;
            }
            _totalPrice.Value = "" + sum;
        }
    }
}