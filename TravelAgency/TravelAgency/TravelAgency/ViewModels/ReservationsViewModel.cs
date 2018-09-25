using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;

namespace TravelAgency.ViewModels
{
    public class ReservationsViewModel : INotifyPropertyChanged
    {
        private ReservationRepository _reservationRepository;
        private Reservation _selectedReservation;
        private AccomodationReservation _selectedAccomodationReservation;
        private string _searchedCustomerId;
        private string _searchedAccomodationName;
        private ObservableCollection<AccomodationReservation> _searchAccomodationReservationList;
        private ObservableCollection<Reservation> _searchCustomerReservationList;

        private CancelCustomerReservationCommand _cancelReservationCommand;
        private CancelAccomodationReservationCommand _cancelHotelReservationCommand;
        private SearchCustomerReservationCommand _searchCustomerReservationCommand;
        private SearchAccomodationReservationCommand _searchHotelReservationCommand;

        public ReservationsViewModel()
        {
            _reservationRepository = DataManagementService.Instance.MainRepository.ReservationRepository;
            _searchCustomerReservationList = new ObservableCollection<Reservation>();
            _searchAccomodationReservationList = new ObservableCollection<AccomodationReservation>();
            _cancelReservationCommand = new CancelCustomerReservationCommand(this);
            _cancelHotelReservationCommand = new CancelAccomodationReservationCommand(this);
            _searchCustomerReservationCommand = new SearchCustomerReservationCommand(this);
            _searchHotelReservationCommand = new SearchAccomodationReservationCommand(this);
        }

        public ReservationRepository ReservationRepository
        {
            get
            {
                return _reservationRepository;
            }

            set
            {
                _reservationRepository = value;
            }
        }
        public Reservation SelectedReservation
        {
            get { return _selectedReservation; }
            set
            {
                _selectedReservation = value;
                OnPropertyChanged();
            }
        }
        public AccomodationReservation SelectedAccomodationReservation
        {
            get { return _selectedAccomodationReservation; }
            set
            {
                _selectedAccomodationReservation = value;
                OnPropertyChanged();
            }
        }
        public string SearchedCustomerId
        {
            get { return _searchedCustomerId; }
            set
            {
                _searchedCustomerId = value;
                OnPropertyChanged();
            }
        }

        public CancelCustomerReservationCommand CancelReservationCommand
        {
            get { return _cancelReservationCommand; }
            set
            {
                _cancelReservationCommand = value;
            }
        }
        public CancelAccomodationReservationCommand CancelHotelReservationCommand
        {
            get { return _cancelHotelReservationCommand; }
            set
            {
                _cancelHotelReservationCommand = value;
            }
        }
        public SearchCustomerReservationCommand SearchCustomerReservationCommand
        {
            get { return _searchCustomerReservationCommand; }
            set
            {
                _searchCustomerReservationCommand = value;
            }
        }
        public ObservableCollection<Reservation> SearchCustomerReservationList
        {
            get { return _searchCustomerReservationList; }
            set
            {
                _searchCustomerReservationList = value;
            }
        }

        public string SearchedAccomodationName
        {
            get { return _searchedAccomodationName; }
            set
            {
                _searchedAccomodationName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AccomodationReservation> SearchAccomodationReservationList
        {
            get { return _searchAccomodationReservationList; }
            set
            {
                _searchAccomodationReservationList = value;
            }
        }

        public SearchAccomodationReservationCommand SearchHotelReservationCommand { get => _searchHotelReservationCommand; set => _searchHotelReservationCommand = value; }

        public void CancelReservation()
        {
            foreach (Room room in _selectedReservation.BestOption.RoomList)
            {
                room.Delete(_selectedReservation.ReservationPeriod);
            }

            _reservationRepository.Delete(_selectedReservation);
            DataManagementService.Instance.SaveData();
        }

        public void CancelHotelReservation()
        {
            _selectedAccomodationReservation.Room.Delete(_selectedAccomodationReservation.ReservationPeriod);

            _reservationRepository.DeleteHotelReservation(_selectedAccomodationReservation);
            SearchAccomodationReservationList.Clear();
            DataManagementService.Instance.SaveData();
        }

        public void SearchCustomerReservation()
        {
            _searchCustomerReservationList.Clear();
            if(SearchedCustomerId != string.Empty)
            {
                foreach (Reservation reservation in _reservationRepository.ReservationList)
                    if (reservation.Owner.Id.Equals(SearchedCustomerId))
                        _searchCustomerReservationList.Add(reservation);
            }

        }

        public void SearchHotelReservation()
        {
            _searchAccomodationReservationList.Clear();
            if(SearchedAccomodationName != string.Empty)
            {
                foreach(AccomodationReservation hotelReservation in _reservationRepository.HotelReservationList)
                {
                    if (hotelReservation.Hotel.Name.ToLower().Contains(SearchedAccomodationName.ToLower()))
                        _searchAccomodationReservationList.Add(hotelReservation);
                }

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
