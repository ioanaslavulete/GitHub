﻿using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class SaveAccomodationCommand : ICommand
    {
        private AccomodationManagementViewModel _accomodationManagementViewModel;

        public SaveAccomodationCommand(AccomodationManagementViewModel accomodationManagementViewModel)
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
            if (_accomodationManagementViewModel.SelectedAccomodation != null && _accomodationManagementViewModel.SelectedAccomodation.IsValid()) 
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            _accomodationManagementViewModel.SaveAccomodation();
        }
    }
}
