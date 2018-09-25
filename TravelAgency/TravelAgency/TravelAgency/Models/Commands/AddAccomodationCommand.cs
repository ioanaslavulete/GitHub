using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class AddAccomodationCommand : ICommand
    {
        private AccomodationManagementViewModel _accomodationManagementViewModel;

        public AddAccomodationCommand(AccomodationManagementViewModel accomodationManagementViewModel)
        {
            _accomodationManagementViewModel = accomodationManagementViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _accomodationManagementViewModel.Accomodation.IsValid();
        }

        public void Execute(object parameter)
        {
            _accomodationManagementViewModel.AddAccomodation();
        }
    }
}
