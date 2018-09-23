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

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _hotelBooksRoomsViewModel.ReserveRoom();
        }
    }
}
