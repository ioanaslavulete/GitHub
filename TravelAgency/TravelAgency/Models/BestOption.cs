using System;
using System.Collections.ObjectModel;

namespace TravelAgency.Models
{
	public class BestOption
	{
		private ObservableCollection<Room> _rooms;
		private string _totalPrice;

		public BestOption()
		{
			_rooms = new ObservableCollection<Room>();
			_totalPrice = null;

		}

		public ObservableCollection<Room> Rooms
		{
			get { return _rooms; }
			set
			{
				_rooms = value;
			}
		}
		public string TotalPrice
		{
			get
			{
				return _totalPrice + " ron";
			}
		}
		public string Result
		{
			get
			{
				string result = "";
				foreach (Room room in _rooms)
				{
					result += string.Format(room.NumberOfPersons + "persons" + " - " + room.Price + "ron/night" + "\n");
				}
				return result;
			}
		}

		public void CalculateTotalPriceFor(ReservationPeriod reservationPeriod)
		{
			int _totalPrice = 0;
			foreach (Room room in _rooms)
			{
				_totalPrice += int.Parse(room.Price) * (reservationPeriod.CheckOut.Day - reservationPeriod.CheckIn.Day);
			}
			this._totalPrice = _totalPrice.ToString();
		}

		internal bool HasRooms()
		{
			return _rooms.Count != 0;
		}
	}
}
