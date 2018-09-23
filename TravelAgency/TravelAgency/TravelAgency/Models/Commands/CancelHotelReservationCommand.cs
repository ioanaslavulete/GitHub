using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class CancelHotelReservationCommand : ICommand
    {
        private ReservationsViewModel _reservationsViewModel;

        public CancelHotelReservationCommand(ReservationsViewModel reservationsViewModel)
        {
            _reservationsViewModel = reservationsViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _reservationsViewModel.CancelHotelReservation();
        }
    }
}
