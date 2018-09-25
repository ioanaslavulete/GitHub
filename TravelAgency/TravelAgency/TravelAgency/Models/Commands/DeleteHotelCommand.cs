﻿using System;
using System.Windows.Input;
using TravelAgency.ViewModels;

namespace TravelAgency.Models.Commands
{
    public class DeleteHotelCommand : ICommand
    {
        private HotelManagementViewModel _hotelViewModel;

        public DeleteHotelCommand(HotelManagementViewModel hotelViewModel)
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
            if(_hotelViewModel.SelectedHotel != null)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            _hotelViewModel.DeleteAccomodation();
        }
    }
}
