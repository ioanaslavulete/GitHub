using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class DeleteAccomodationCommand : ICommand
    {
        private AccomodationManagementViewModel _accomodationManagementViewModel;

        public DeleteAccomodationCommand(AccomodationManagementViewModel accomodationManagementViewModel)
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
            if (_accomodationManagementViewModel.SelectedAccomodation != null)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            _accomodationManagementViewModel.DeleteAccomodation();
        }
    }
}
