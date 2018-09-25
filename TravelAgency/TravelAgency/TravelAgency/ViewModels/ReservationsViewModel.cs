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
        private HotelReservation _selectedHotelReservation;
        private string _searchedCustomerId;
        private string _searchedHotelName;
        private ObservableCollection<HotelReservation> _searchHotelReservationList;
        private ObservableCollection<Reservation> _searchCustomerReservationList;
        private CancelReservationCommand _cancelReservationCommand;
        private CancelHotelReservationCommand _cancelHotelReservationCommand;
        private SearchCustomerReservationCommand _searchCustomerReservationCommand;
        private SearchHotelReservationCommand _searchHotelReservationCommand;

        public ReservationsViewModel()
        {
            _reservationRepository = DataManagementService.Instance.MainRepository.ReservationRepository;
            _searchCustomerReservationList = new ObservableCollection<Reservation>();
            _searchHotelReservationList = new ObservableCollection<HotelReservation>();
            _cancelReservationCommand = new CancelReservationCommand(this);
            _cancelHotelReservationCommand = new CancelHotelReservationCommand(this);
            _searchCustomerReservationCommand = new SearchCustomerReservationCommand(this);
            _searchHotelReservationCommand = new SearchHotelReservationCommand(this);
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
        public HotelReservation SelectedHotelReservation
        {
            get { return _selectedHotelReservation; }
            set
            {
                _selectedHotelReservation = value;
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
        public CancelReservationCommand CancelReservationCommand
        {
            get { return _cancelReservationCommand; }
            set
            {
                _cancelReservationCommand = value;
            }
        }
        public CancelHotelReservationCommand CancelHotelReservationCommand
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

        public string SearchedHotelName
        {
            get { return _searchedHotelName; }
            set
            {
                _searchedHotelName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<HotelReservation> SearchHotelReservationList
        {
            get { return _searchHotelReservationList; }
            set
            {
                _searchHotelReservationList = value;
            }
        }

        public SearchHotelReservationCommand SearchHotelReservationCommand { get => _searchHotelReservationCommand; set => _searchHotelReservationCommand = value; }

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
            _selectedHotelReservation.Room.Delete(_selectedHotelReservation.ReservationPeriod);

            _reservationRepository.DeleteHotelReservation(_selectedHotelReservation);
            SearchHotelReservationList.Clear();
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
            _searchHotelReservationList.Clear();
            if(SearchedHotelName != string.Empty)
            {
                foreach(HotelReservation hotelReservation in _reservationRepository.HotelReservationList)
                {
                    if (hotelReservation.Hotel.Name.ToLower().Contains(SearchedHotelName.ToLower()))
                        _searchHotelReservationList.Add(hotelReservation);
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
