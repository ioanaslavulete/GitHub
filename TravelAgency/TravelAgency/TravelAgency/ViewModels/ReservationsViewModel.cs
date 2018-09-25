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
        private CancelReservationCommand _cancelReservationCommand;
        private CancelHotelReservationCommand _cancelHotelReservationCommand;


        public ReservationsViewModel()
        {
            _reservationRepository = DataManagementService.Instance.MainRepository.ReservationRepository;
            _cancelReservationCommand = new CancelReservationCommand(this);
            _cancelHotelReservationCommand = new CancelHotelReservationCommand(this);
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
            DataManagementService.Instance.SaveData();
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
