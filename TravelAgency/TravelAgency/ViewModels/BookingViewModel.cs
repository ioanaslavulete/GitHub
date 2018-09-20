using System;
using System.Collections.ObjectModel;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;
using TravelAgency.Views;

namespace TravelAgency.ViewModels
{
	public class BookingViewModel
	{
		private Reservation _reservation;
		private ObservableCollection<Hotel> _hotelList;
		private ObservableCollection<Location> _locationList;
		private ObservableCollection<AvailableOption> _availableOptionList;
		private AvailableOption _selectedAvailableOption;
		private CheckAvailabilityCommand _checkAvailabilityCommand;
		private ShowBookingVoucherCommand _showBookingVoucherCommand;

		public BookingViewModel()
		{
			_hotelList = DataManagementService.Instance.MainRepository.HotelRepository.HotelList;
			_locationList = DataManagementService.Instance.MainRepository.LocationRepository.LocationList;
			_reservation = new Reservation();
			_availableOptionList = new ObservableCollection<AvailableOption>();
			_selectedAvailableOption = new AvailableOption();

			_checkAvailabilityCommand = new CheckAvailabilityCommand(this);
			_showBookingVoucherCommand = new ShowBookingVoucherCommand(this);
		}

		public ObservableCollection<Location> LocationList
		{
			get { return _locationList; }
			set
			{
				_locationList = value;
			}
		}
		public ObservableCollection<AvailableOption> AvailableOptionList
		{
			get
			{
				return _availableOptionList;
			}
			set
			{
				_availableOptionList = value;
			}
		}
		public AvailableOption SelectedAvailableOption
		{
			get
			{
				return _selectedAvailableOption;
			}
			set
			{
				_selectedAvailableOption = value;
			}
		}
		public Reservation Reservation
		{
			get
			{
				return _reservation;
			}
			set
			{
				_reservation = value;
			}
		}
		public CheckAvailabilityCommand CheckAvailabilityCommand
		{
			get
			{
				return _checkAvailabilityCommand;
			}
			set
			{
				_checkAvailabilityCommand = value;
			}
		}
		public ShowBookingVoucherCommand ShowBookingVoucherCommand
		{
			get
			{
				return _showBookingVoucherCommand;
			}
			set
			{
				_showBookingVoucherCommand = value;
			}
		}


		public void CheckAvailability()
		{
			_availableOptionList.Clear();

			foreach (Hotel hotel in _hotelList)
			{
				if (hotel.Location.Equals(_reservation.Hotel.Location))
				{
					if (hotel.HasRoomsAvailableIn(_reservation.ReservationPeriod))
					{
						AvailableOption availableOption = new AvailableOption(hotel);
						hotel.GetBestOptionFor(_reservation);
						if (hotel.BestOption.HasRooms())
						{
							hotel.BestOption.CalculateTotalPriceFor(_reservation.ReservationPeriod);
							_availableOptionList.Add(availableOption);
						}
					}
				}
			}
		}

		public void ShowBookingVoucherView()
		{
			BookingVoucherView bookingVoucherView = new BookingVoucherView();
			BookingVoucherViewModel bookingVoucherViewModel = new BookingVoucherViewModel();
			Reservation.Hotel = SelectedAvailableOption.Hotel;
			Reservation newReservation = new Reservation(Reservation);
			bookingVoucherViewModel.Reservation = newReservation;
			bookingVoucherView.DataContext = bookingVoucherViewModel;
			bookingVoucherView.Show();
		}
	}
}
