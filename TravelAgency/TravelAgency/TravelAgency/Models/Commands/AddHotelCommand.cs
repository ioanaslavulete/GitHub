using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class AddHotelCommand : ICommand
    {
        private HotelManagementViewModel _hotelViewModel;

        public AddHotelCommand(HotelManagementViewModel hotelViewModel)
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
            
            return _hotelViewModel.Hotel.IsValid();
           
        }

        public void Execute(object parameter)
        {
            _hotelViewModel.AddAccomodation();
        }
    }
}
