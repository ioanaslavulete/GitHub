﻿using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class CancelCustomerReservationCommand : ICommand
    {
        private ReservationsViewModel _reservationsViewModel;

        public CancelCustomerReservationCommand(ReservationsViewModel reservationsViewModel)
        {
            _reservationsViewModel = reservationsViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_reservationsViewModel.SelectedReservation != null)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            _reservationsViewModel.CancelReservation();
        }
    }
}
