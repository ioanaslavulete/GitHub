using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class AddRoomCommand : ICommand
    {
        private HotelManagementViewModel _hotelViewModel;

        public AddRoomCommand(HotelManagementViewModel hotelViewModel)
        {
            _hotelViewModel = hotelViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _hotelViewModel.Room.IsValid();
        }

        public void Execute(object parameter)
        {
            _hotelViewModel.AddRoom();
        }
    }
}
