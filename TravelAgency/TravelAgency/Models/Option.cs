using System.Collections.ObjectModel;
using TravelAgency.Models;

namespace TravelAgency.Models
{
	public class Option
	{
		private Hotel _hotel;
		private ObservableCollection<Room> _roomList;

		public Option(Hotel hotel, ObservableCollection<Room> observableCollection)
		{
			this._hotel = hotel;
			this._roomList = observableCollection;
		}

		public Option()
		{
			_hotel = new Hotel();
			_roomList = new ObservableCollection<Room>();
		}

		public Hotel Hotel
		{
			get
			{
				return _hotel;
			}

			set
			{
				_hotel = value;
			}
		}

		public ObservableCollection<Room> RoomList
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
					result += string.Format(room.NumberOfPersons + " persons" + " - " + room.Price + " ron/night" + "\n");
				}
				return result;
			}
		}
	}
}