using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;
using TravelAgency.Views;

namespace TravelAgency.ViewModels
{
    public class HotelDetailsViewModel
    {
        private Hotel _selectedHotel;
        private Room _selectedRoom;
        private ReservationPeriod _reservationPeriod;
        private ReserveRoomCommand _reserveRoomCommand;
        

        public HotelDetailsViewModel()
        {
           // _reserveRoomCommand = new ReserveRoomCommand(this);
            _reservationPeriod = new ReservationPeriod();
        }

        public Hotel SelectedHotel
        {
            get { return _selectedHotel; }
            set
            {
                _selectedHotel = value;
            }
        }
        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
            }
        }
        public ReservationPeriod ReservationPeriod
        {
            get { return _reservationPeriod; }
            set
            {
                _reservationPeriod = value;
            }
        }
        public ReserveRoomCommand ReserveRoomCommand
        {
            get { return _reserveRoomCommand; }
            set
            {
                _reserveRoomCommand = value;
            }
        }
        

        public void ReserveRoom()
        {
            //ReservationPeriod newReservationPeriod = new ReservationPeriod(_reservationPeriod.CheckIn, _reservationPeriod.CheckOut);
            //_selectedRoom.Add(newReservationPeriod);
            //DataManagementService.Instance.SaveData();

            
            BookingVoucherViewModel bookingVoucherViewModel = new BookingVoucherViewModel();

            BookingVoucherView bookingVoucherView = new BookingVoucherView();
            bookingVoucherView.DataContext = bookingVoucherViewModel;
            bookingVoucherView.ShowDialog();
            
        }
    }
}
