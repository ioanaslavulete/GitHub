using System;
using System.Windows;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;

namespace TravelAgency.ViewModels
{
	public class BookingVoucherViewModel
	{
		private Customer _customer;
		private ReserveRoomCommand _reserveRoomCommand;
		public Customer Customer
		{
			get { return _customer; }
			set
			{
				_customer = value;
			}
		}

		public BookingVoucherViewModel()
		{
			_reserveRoomCommand = new ReserveRoomCommand(this);
		}

		public Hotel SelectedHotel { get; set; }
		public ReservationPeriod ReservationPeriod { get; set; }

		public ReserveRoomCommand ReserveRoomCommand
		{
			get
			{
				return _reserveRoomCommand;
			}

			set
			{
				_reserveRoomCommand = value;
			}
		}

		internal void ReserveRoom()
		{
			ReservationPeriod newReservationPeriod = new ReservationPeriod(ReservationPeriod.CheckIn, ReservationPeriod.CheckOut);
			foreach (Room room in SelectedHotel.BestOption.Rooms)
				room.Add(newReservationPeriod);
			DataManagementService.Instance.SaveData();
			MessageBox.Show("Successful");
		}
	}
}
