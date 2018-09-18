﻿using System;
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

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _bookingViewModel.CheckAvailability();
        }
    }
}