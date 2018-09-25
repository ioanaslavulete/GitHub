using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class EmptyCustomerFieldsCommand : ICommand
	{
		private BookingViewModel _bookingViewModel;

		public EmptyCustomerFieldsCommand(BookingViewModel bookingViewModel)
		{
			this._bookingViewModel = bookingViewModel;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return _bookingViewModel.Reservation.Owner.HasFieldsFilled();
		}

		public void Execute(object parameter)
		{
			_bookingViewModel.EmptyCustomerFields();
		}
	}
}
