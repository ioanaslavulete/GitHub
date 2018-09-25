using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class EditRoomCommand : ICommand
    {
        private HotelManagementViewModel _hotelManagementViewModel;

        public EditRoomCommand(HotelManagementViewModel hotelManagementViewModel)
        {
            _hotelManagementViewModel = hotelManagementViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_hotelManagementViewModel.SelectedRoom != null)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            _hotelManagementViewModel.EditRoom();
        }
    }
}
