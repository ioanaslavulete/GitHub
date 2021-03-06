﻿using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class AddRoomCommand : ICommand
    {
        private AccomodationManagementViewModel _accomodationManagementViewModel;

        public AddRoomCommand(AccomodationManagementViewModel accomodationManagementViewModel)
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
            return _accomodationManagementViewModel.Room.IsValid();
        }

        public void Execute(object parameter)
        {
            _accomodationManagementViewModel.AddRoom();
        }
    }
}
