using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class SearchHotelCommand : ICommand
    {
        private HotelBooksRoomsViewModel _hotelBooksRoomsViewModel;

        public SearchHotelCommand(HotelBooksRoomsViewModel hotelBooksRoomsViewModel)
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
            _hotelBooksRoomsViewModel.SearchHotel();
        }
    }
}
