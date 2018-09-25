using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class SaveRoomCommand : ICommand
    {
        private HotelManagementViewModel _hotelManagementViewModel;

        public SaveRoomCommand(HotelManagementViewModel hotelManagementViewModel)
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
            _hotelManagementViewModel.SaveRoom();
        }
    }
}
