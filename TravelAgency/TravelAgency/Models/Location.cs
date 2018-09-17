using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TravelAgency.Models
{
    public class Location : INotifyPropertyChanged
    {
        private string _cityName;
        private string _countryName;
        private string _fullName;

        public string CityName
        {
            get { return _cityName; }
            set
            {
                _cityName = value;
                FullName = string.Format(_cityName + ", " + _countryName);
                OnPropertyChanged();
            }
        }
        public string CountryName
        {
            get { return _countryName; }
            set
            {
                _countryName = value;
                FullName = string.Format(_cityName + ", " + _countryName);
                OnPropertyChanged();
            }
        }
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return FullName;
        }       

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public override bool Equals(object obj)
        {
            var location = obj as Location;
            if (_fullName == location.FullName)
                return true;
            else
                return false;
        }
    }
}