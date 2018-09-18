﻿using System;
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

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _hotelViewModel.AddHotel();
        }
    }
}