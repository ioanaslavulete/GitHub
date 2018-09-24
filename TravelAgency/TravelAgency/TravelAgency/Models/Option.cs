﻿using System;
using System.Collections.ObjectModel;
using TravelAgency.Models;

namespace TravelAgency.Models
{
	using TravelAgency.Models.Interfaces;

	[Serializable]
	public class Option
	{
		private IAccomodation _hotel;
		private ObservableCollection<IRoom> _roomList;

		public Option(IAccomodation hotel, ObservableCollection<IRoom> roomList)
		{
			this._hotel = hotel;
			this._roomList = roomList;
		}

		public Option()
		{
			_hotel = new Hotel();
			_roomList = new ObservableCollection<IRoom>();
		}

		public IAccomodation Hotel
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
					result += string.Format(room.NumberOfPersons + " persons" + " - " + room.Price + " ron/night" + "\n");
				}
				return result;
			}
		}
	}
}