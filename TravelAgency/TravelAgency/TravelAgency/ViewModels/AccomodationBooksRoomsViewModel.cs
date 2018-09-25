using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;
using TravelAgency.Models.Interfaces;

namespace TravelAgency.ViewModels
{
    public class AccomodationBooksRoomsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<IAccomodation> _accomodationList;
        private ObservableCollection<IAccomodation> _searchAccomodationList;
        private ObservableCollection<IRoom> _roomsListForSelectedAccomodation;
        private IAccomodation _accomodation;
        private string _searchedName;
        private AccomodationReservation _accomodationReservation;
        private ReservationRepository _reservationRepository;
        private IRoom _selectedRoom;

        private AccomodationBooksRoomCommand _accomodationBooksRoomCommand;
        private SearchAccomodationCommand _searchAccomodationCommand;

        public AccomodationBooksRoomsViewModel()
        {
            _accomodationList = DataManagementService.Instance.MainRepository.AccomodationRepository.AccomodationList;
            _reservationRepository = DataManagementService.Instance.MainRepository.ReservationRepository;
            _searchAccomodationList = new ObservableCollection<IAccomodation>();
            _accomodation = new Hotel();
            _searchAccomodationCommand = new SearchAccomodationCommand(this);
            _roomsListForSelectedAccomodation = new ObservableCollection<IRoom>();
            _accomodationReservation = new AccomodationReservation();
            _selectedRoom = new Room();
            _accomodationBooksRoomCommand = new AccomodationBooksRoomCommand(this);
        }


        public IAccomodation Accomodation
        {
            get { return _accomodation; }
            set
            {
                _accomodation = value;
                if (_accomodation != null)
                {
                    Accomodation.HasRoomsAvailableIn(AccomodationReservation.ReservationPeriod);
                }
                OnPropertyChanged();
            }
        }
        public ObservableCollection<IAccomodation> SearchAccomodationList
        {
            get { return _searchAccomodationList; }
            set
            {
                _searchAccomodationList = value;
            }
        }
        public SearchAccomodationCommand SearchAccomodationCommand
        {
            get { return _searchAccomodationCommand; }
            set
            {
                _searchAccomodationCommand = value;
            }
        }
        public ObservableCollection<IRoom> RoomsListForSelectedAccomodation
        {
            get { return _roomsListForSelectedAccomodation; }
            set
            {
                _roomsListForSelectedAccomodation = value;
            }
        }
        public string SearchedName
        {
            get { return _searchedName; }
            set
            {
                _searchedName = value;
                OnPropertyChanged();
            }
        }
        public AccomodationReservation AccomodationReservation
        {
            get { return _accomodationReservation; }
            set
            {
                _accomodationReservation = value;
                OnPropertyChanged();
            }
        }
        public AccomodationBooksRoomCommand AccomodationBooksRoomCommand
        {
            get { return _accomodationBooksRoomCommand; }
            set
            {
                _accomodationBooksRoomCommand = value;
            }
        }
        public IRoom SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
            }
        }

        public void SearchAccomodation()
        {
            _searchAccomodationList.Clear();

            if (SearchedName != string.Empty)
            {
                foreach (Hotel hotel in _accomodationList)
                {
                    if (hotel.Name.ToLower().Contains(SearchedName.ToLower()))
                        _searchAccomodationList.Add(hotel);
                }
            }
        }

        public void ReserveRoom()
        {
            _selectedRoom.Add(_accomodationReservation.ReservationPeriod);

            _reservationRepository.AddHotelReservation(new AccomodationReservation(Accomodation, _accomodationReservation.ReservationPeriod, _selectedRoom));
            DataManagementService.Instance.SaveData();
            MessageBox.Show("Successful");
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

