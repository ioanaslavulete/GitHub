using System;
using TravelAgency.Models.Commands;
using TravelAgency.Views;

namespace TravelAgency.ViewModels
{
    public class MainWindowViewModel
    {
        private OpenHotelManagementViewCommand _openHotelManagementViewCommand;
        private OpenBookingViewCommand _openBookingViewCommand;

        public MainWindowViewModel()
        {
            _openHotelManagementViewCommand = new OpenHotelManagementViewCommand(this);
            _openBookingViewCommand = new OpenBookingViewCommand(this);
        }

        public OpenHotelManagementViewCommand OpenHotelManagementViewCommand
        {
            get { return _openHotelManagementViewCommand; }
            set
            {
                _openHotelManagementViewCommand = value;
            }
        }
        public OpenBookingViewCommand OpenBookingViewCommand
        {
            get { return _openBookingViewCommand; }
            set
            {
                _openBookingViewCommand = value;
            }
        }

        public void ShowHotelManagementView()
        {
            HotelManagementView view = new HotelManagementView();
            view.ShowDialog();
        }

        public void ShowBookingView()
        {
            BookingView view = new BookingView();
            view.ShowDialog();
        }
    }
}
