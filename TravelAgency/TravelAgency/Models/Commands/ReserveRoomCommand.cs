using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class ReserveRoomCommand : ICommand
    {
        private HotelDetailsViewModel _hotelDetailsViewModel;

        public ReserveRoomCommand(HotelDetailsViewModel hotelDetailsViewModel)
        {
            _hotelDetailsViewModel = hotelDetailsViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _hotelDetailsViewModel.ReserveRoom();
        }
    }
}
