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
			foreach (Room room in Reservation.BestOption.RoomList)
				room.Add(_reservation.ReservationPeriod);

			_reservationRepository.Add(_reservation);
			DataManagementService.Instance.SaveData();
		}
	}
}
