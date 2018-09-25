using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class SearchAccomodationReservationCommand : ICommand
    {
        private ReservationsViewModel _reservationsViewModel;

        public SearchAccomodationReservationCommand(ReservationsViewModel reservationsViewModel)
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
            return _reservationsViewModel.SearchedAccomodationName != string.Empty;
        }

        public void Execute(object parameter)
        {
            _reservationsViewModel.SearchHotelReservation();
        }
    }
}
