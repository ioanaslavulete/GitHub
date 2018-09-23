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

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _hotelManagementViewModel.EditRoom();
        }
    }
}
