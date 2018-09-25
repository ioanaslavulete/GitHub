using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
	public class CheckAvailabilityCommand : ICommand
	{
		private BookingViewModel _bookingViewModel;

		public CheckAvailabilityCommand(BookingViewModel bookingViewModel)
		{
			_bookingViewModel = bookingViewModel;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
            string acceptsOnlyNumbers = "^[0-9]+$";
            if (Regex.IsMatch(_bookingViewModel.Reservation.NumberOfPersons, acceptsOnlyNumbers) == false || _bookingViewModel.SelectedLocation == null)
                return false;
            else
                return true;
        }

		public void Execute(object parameter)
		{
			_bookingViewModel.CheckAvailability();
		}
	}
}
