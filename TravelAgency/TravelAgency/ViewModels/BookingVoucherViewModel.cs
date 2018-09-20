using System;
using System.Windows;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;

namespace TravelAgency.ViewModels
{
	public class BookingVoucherViewModel
	{
		private ReserveRoomCommand _reserveRoomCommand;
		private ReservationRepository _reservationRepository;
        private Reservation _reservation;

		public BookingVoucherViewModel()
		{
			_reservationRepository = DataManagementService.Instance.MainRepository.ReservationRepository;
			_reserveRoomCommand = new ReserveRoomCommand(this);
		}

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

		public Reservation Reservation
        {
            get
            {
                return _reservation;
            }
            set
            {
                _reservation = value;
            }
        }
		public ReservationRepository ReservationRepository
		{
			get
			{
				return _reservationRepository;
			}

			set
			{
				_reservationRepository = value;
			}
		}

		public void ReserveRoom()
		{
			ReservationPeriod newReservationPeriod = new ReservationPeriod(Reservation.ReservationPeriod.CheckIn, Reservation.ReservationPeriod.CheckOut);
			foreach (Room room in Reservation.Hotel.BestOption.Rooms)
				room.Add(newReservationPeriod);

			_reservationRepository.Add(Reservation);
			DataManagementService.Instance.SaveData();
			MessageBox.Show("Successful");
		}
	}
}
