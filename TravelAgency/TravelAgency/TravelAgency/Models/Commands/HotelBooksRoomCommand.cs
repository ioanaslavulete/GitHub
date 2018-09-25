using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class HotelBooksRoomCommand : ICommand
    {
        private HotelBooksRoomsViewModel _hotelBooksRoomsViewModel;

        public HotelBooksRoomCommand(HotelBooksRoomsViewModel hotelBooksRoomsViewModel)
        {
            _hotelBooksRoomsViewModel = hotelBooksRoomsViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public bool CanExecute(object parameter)
        {
           return _hotelBooksRoomsViewModel.SelectedRoom != null;
        }

        public void Execute(object parameter)
        {
            _hotelBooksRoomsViewModel.ReserveRoom();
        }
    }
}
