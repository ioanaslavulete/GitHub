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

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _hotelManagementViewModel.SaveRoom();
        }
    }
}
