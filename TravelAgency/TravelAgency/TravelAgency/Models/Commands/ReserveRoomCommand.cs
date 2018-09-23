using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
	public class ReserveRoomCommand : ICommand
	{
		private BookingVoucherViewModel _bookingVoucherViewModel;

		public ReserveRoomCommand(BookingVoucherViewModel bookingVoucherViewModel)
		{
			_bookingVoucherViewModel = bookingVoucherViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_bookingVoucherViewModel.ReserveRoom();
		}
	}
}
