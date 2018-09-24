using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Models.Interfaces;
using TravelAgency.Services;
using TravelAgency.Views;

namespace TravelAgency.ViewModels
{
	public class BookingViewModel : INotifyPropertyChanged
	{
		private Reservation _reservation;
		private Location _selectedLocation;
		private ObservableCollection<IAccomodation> _hotelList;
		private ObservableCollection<Location> _locationList;
		private ObservableCollection<IAccomodation> _availableHotels;
		private ObservableCollection<Option> _availableOptions;
		private Option _selectedOption;
		private CheckAvailabilityCommand _checkAvailabilityCommand;
		private ShowBookingVoucherCommand _showBookingVoucherCommand;
		private GetCustomerInfoCommand _getCustomerInfoCommand;

		private ObservableCollection<Reservation> _reservationList;

		public BookingViewModel()
		{
			_hotelList = DataManagementService.Instance.MainRepository.AccomodationRepository.HotelList;
			_locationList = DataManagementService.Instance.MainRepository.LocationRepository.LocationList;
			_reservationList = DataManagementService.Instance.MainRepository.ReservationRepository.ReservationList;

			_reservation = new Reservation();
			_selectedLocation = new Location();
			_selectedOption = new Option();
			_availableOptions = new ObservableCollection<Option>();

			_checkAvailabilityCommand = new CheckAvailabilityCommand(this);
			_showBookingVoucherCommand = new ShowBookingVoucherCommand(this);
			_getCustomerInfoCommand = new GetCustomerInfoCommand(this);
		}

		public ObservableCollection<Location> LocationList
		{
			get { return _locationList; }
			set
			{
				_locationList = value;
			}
		}
		public ObservableCollection<IAccomodation> HotelsList
		{
			get
			{
				return _availableHotels;
			}
			set
			{
				_availableHotels = value;
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
				OnPropertyChanged();
			}
		}
		public Location SelectedLocation
		{
			get { return _selectedLocation; }
			set
			{
				_selectedLocation = value;
			}
		}
		public ObservableCollection<Option> AvailableOptions
		{
			get
			{
				return _availableOptions;
			}
			set
			{
				_availableOptions = value;
			}
		}
		public Option SelectedOption
		{
			get
			{
				return _selectedOption;
			}

			set
			{
				_selectedOption = value;
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
		public GetCustomerInfoCommand GetCustomerInfoCommand
		{
			get
			{
				return _getCustomerInfoCommand;
			}
			set
			{
				_getCustomerInfoCommand = value;
			}
		}

		public void CheckAvailability()
		{
			AvailableOptions.Clear();

			foreach (Hotel hotel in _hotelList)
			{
				if (hotel.HasSameLocationAs(_selectedLocation))
				{
					if (hotel.HasRoomsAvailableIn(_reservation.ReservationPeriod))
					{
						Option option = new Option(hotel, hotel.GetBestOptionFor(_reservation));
						AvailableOptions.Add(option);
					}
				}
			}
		}

		public void ShowBookingVoucherView()
		{
			BookingVoucherView bookingVoucherView = new BookingVoucherView();
			BookingVoucherViewModel bookingVoucherViewModel = new BookingVoucherViewModel();

			bookingVoucherViewModel.Reservation = new Reservation(_reservation.Owner, _selectedOption.Hotel, _reservation.ReservationPeriod, _reservation.NumberOfPersons, _selectedOption);
			bookingVoucherView.DataContext = bookingVoucherViewModel;

			bookingVoucherView.Show();
		}

		public void GetCustomerInfo()
		{
			bool found = false;
			if (_reservation.Owner.Id != string.Empty)
			{
				foreach (Reservation reservation in _reservationList)
				{
					if (reservation.Owner.Id == _reservation.Owner.Id)
					{
						found = true;
						Reservation.Owner = new Customer(reservation.Owner.Id, reservation.Owner.FirstName, reservation.Owner.LastName, reservation.Owner.Email, reservation.Owner.PhoneNumber);
					}
				}
				if (found == false)
					Reservation.Owner = new Customer();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string caller = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(caller));
			}
		}
	}
}
