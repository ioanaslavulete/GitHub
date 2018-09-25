using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TravelAgency.Models.Interfaces;

namespace TravelAgency.Models
{
    [Serializable]
    public class Room : INotifyPropertyChanged, IRoom, IDataErrorInfo
    {
        private Price _price;
        private string _numberOfPersons;
        private RoomViewType _roomViewType;
        private ObservableCollection<ReservationPeriod> _reservedPeriodList;
        string acceptsOnlyNumbers = "^[0-9]+$";

        public Room()
        {
            _reservedPeriodList = new ObservableCollection<ReservationPeriod>();
            _price = new Price();
        }

        public Room(Price price, string numberOfPersons, RoomViewType roomViewType)
        {
            _price = price;
            _numberOfPersons = numberOfPersons;
            _roomViewType = roomViewType;
            _reservedPeriodList = new ObservableCollection<ReservationPeriod>();
        }

        public Price Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }
        public string NumberOfPersons
        {
            get { return _numberOfPersons; }
            set
            {
                _numberOfPersons = value;
                OnPropertyChanged();
            }
        }
        public RoomViewType RoomViewType
        {
            get { return _roomViewType; }
            set
            {
                _roomViewType = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ReservationPeriod> ReservedPeriodList
        {
            get { return _reservedPeriodList; }
            set
            {
                _reservedPeriodList = value;
            }
        }

        public bool IsAvailableIn(ReservationPeriod reservationPeriod)
        {
            bool isAvailable = true;
            if (_reservedPeriodList.Count > 0)
            {
                foreach (ReservationPeriod reservedPeriod in _reservedPeriodList)
                {
                    if ((reservationPeriod.IsBefore(reservedPeriod) == false) && (reservationPeriod.IsAfter(reservedPeriod) == false))
                        isAvailable = false;
                }
            }
            return isAvailable;
        }

        public void Add(ReservationPeriod newReservationPeriod)
        {
            _reservedPeriodList.Add(newReservationPeriod);
        }

        public void Delete(ReservationPeriod reservationPeriod)
        {
            _reservedPeriodList.Remove(reservationPeriod);
        }
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                string error = string.Empty;

                if (propertyName == "Price")
                {
                    if (string.IsNullOrEmpty(Price.Value) || Regex.IsMatch(Price.Value, acceptsOnlyNumbers) == false)
                        error = "";
                }

                if (propertyName == "NumberOfPersons")
                {
                    if (string.IsNullOrEmpty(NumberOfPersons) || Regex.IsMatch(NumberOfPersons, acceptsOnlyNumbers) == false)
                        error = "";
                }

                return error;
            }
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Price.Value) || Regex.IsMatch(Price.Value, acceptsOnlyNumbers) == false || string.IsNullOrEmpty(NumberOfPersons) || Regex.IsMatch(NumberOfPersons, acceptsOnlyNumbers) == false)
                return false;
            else
                return true;
        }
    }
}