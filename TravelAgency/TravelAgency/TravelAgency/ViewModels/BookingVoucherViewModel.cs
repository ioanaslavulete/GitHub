using System;
using System.Windows;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Models.Interfaces;
using TravelAgency.Services;

namespace TravelAgency.ViewModels
{
	public class BookingVoucherViewModel
	{
		private CustomerBooksRoomCommand _customerBooksRoomCommand;
		private ReservationRepository _reservationRepository;
        private Reservation _reservation;

		public BookingVoucherViewModel()
		{
			_reservationRepository = DataManagementService.Instance.MainRepository.ReservationRepository;
			_customerBooksRoomCommand = new CustomerBooksRoomCommand(this);
		}

		public CustomerBooksRoomCommand CustomerBooksRoomCommand
		{
			get
			{
				return _customerBooksRoomCommand;
			}

			set
			{
				_customerBooksRoomCommand = value;
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
			foreach (IRoom room in Reservation.BestOption.RoomList)
				room.Add(_reservation.ReservationPeriod);

			_reservationRepository.Add(_reservation);
			DataManagementService.Instance.SaveData();
		}
	}
}
