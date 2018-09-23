using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;

namespace TravelAgency.ViewModels
{
    public class HotelBooksRoomsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Hotel> _hotelList;
        private ObservableCollection<Hotel> _searchHotelList;
        private ObservableCollection<Room> _roomsListForSelectedHotel;
        private Hotel _hotel;
        private SearchHotelCommand _searchHotelCommand;
        private string _searchedName;
        private HotelReservation _hotelReservation;
        private ReservationRepository _reservationRepository;
        private Room _selectedRoom;

        private HotelBooksRoomCommand _hotelBooksRoomCommand;


        public HotelBooksRoomsViewModel()
        {
            _hotelList = DataManagementService.Instance.MainRepository.HotelRepository.HotelList;
            _reservationRepository = DataManagementService.Instance.MainRepository.ReservationRepository;
            _searchHotelList = new ObservableCollection<Hotel>();
            _hotel = new Hotel();
            _searchHotelCommand = new SearchHotelCommand(this);
            _roomsListForSelectedHotel = new ObservableCollection<Room>();
            _hotelReservation = new HotelReservation();
            _selectedRoom = new Room();
            _hotelBooksRoomCommand = new HotelBooksRoomCommand(this);
        }


        public Hotel Hotel
        {
            get { return _hotel; }
            set
            {
                _hotel = value;
                if (_hotel != null)
                {
                    Hotel.HasRoomsAvailableIn(HotelReservation.ReservationPeriod);
                }
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Hotel> SearchHotelList
        {
            get { return _searchHotelList; }
            set
            {
                _searchHotelList = value;
            }
        }
        public SearchHotelCommand SearchHotelCommand
        {
            get { return _searchHotelCommand; }
            set
            {
                _searchHotelCommand = value;
            }
        }
        public ObservableCollection<Room> RoomsListForSelectedHotel
        {
            get { return _roomsListForSelectedHotel; }
            set
            {
                _roomsListForSelectedHotel = value;
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
        public HotelReservation HotelReservation
        {
            get { return _hotelReservation; }
            set
            {
                _hotelReservation = value;
                OnPropertyChanged();
            }
        }
        public HotelBooksRoomCommand HotelBooksRoomCommand
        {
            get { return _hotelBooksRoomCommand; }
            set
            {
                _hotelBooksRoomCommand = value;
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

        public void SearchHotel()
        {
            _searchHotelList.Clear();

            if (SearchedName != string.Empty)
            {
                foreach (Hotel hotel in _hotelList)
                {
                    if (hotel.Name.ToLower().Contains(SearchedName.ToLower()))
                        _searchHotelList.Add(hotel);
                }
            }
        }

        public void ReserveRoom()
        {
            _selectedRoom.Add(_hotelReservation.ReservationPeriod);

            _reservationRepository.AddHotelReservation(new HotelReservation(Hotel, _hotelReservation.ReservationPeriod, _selectedRoom));
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

