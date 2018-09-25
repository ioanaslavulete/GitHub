using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class AddRoomToReservationCommand : ICommand
    {
        private BookingViewModel _bookingViewModel;

        public AddRoomToReservationCommand(BookingViewModel bookingViewModel)
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
            return _bookingViewModel.SelectedRoom != null;
        }

        public void Execute(object parameter)
        {
            _bookingViewModel.AddRoomToReservation();
        }
    }
}
