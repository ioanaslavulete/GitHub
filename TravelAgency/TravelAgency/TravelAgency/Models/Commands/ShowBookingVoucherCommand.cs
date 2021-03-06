﻿using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class ShowBookingVoucherCommand : ICommand
    {
        private BookingViewModel _bookingViewModel;

        public ShowBookingVoucherCommand(BookingViewModel bookingViewModel)
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
            if (_bookingViewModel.SelectedOption != null && _bookingViewModel.Reservation.Owner.IsValid())
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            _bookingViewModel.ShowBookingVoucherView();
        }
    }
}
