﻿using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
	public class GetCustomerInfoCommand : ICommand
	{
		private BookingViewModel _bookingViewModel;

		public GetCustomerInfoCommand(BookingViewModel bookingViewModel)
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
			return _bookingViewModel.Reservation.Owner.Id != string.Empty;
		}

		public void Execute(object parameter)
		{
			_bookingViewModel.GetCustomerInfo();
		}
	}
}