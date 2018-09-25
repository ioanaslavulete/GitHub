using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class SearchAccomodationCommand : ICommand
    {
        private AccomodationBooksRoomsViewModel _accomodationBooksRoomViewModel;

        public SearchAccomodationCommand(AccomodationBooksRoomsViewModel accomodationBooksRoomViewModel)
        {
            _accomodationBooksRoomViewModel = accomodationBooksRoomViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public bool CanExecute(object parameter)
        {
            return _accomodationBooksRoomViewModel.SearchedName != string.Empty;
        }

        public void Execute(object parameter)
        {
            _accomodationBooksRoomViewModel.SearchAccomodation();
        }
    }
}
