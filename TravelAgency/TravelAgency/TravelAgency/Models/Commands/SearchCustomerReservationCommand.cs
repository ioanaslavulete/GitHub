using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class SearchCustomerReservationCommand : ICommand
    {
        private ReservationsViewModel _reservationsViewModel;

        public SearchCustomerReservationCommand(ReservationsViewModel reservationsViewModel)
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
            return _reservationsViewModel.SearchedCustomerId != string.Empty;
        }

        public void Execute(object parameter)
        {
            _reservationsViewModel.SearchCustomerReservation();
        }
    }
}
