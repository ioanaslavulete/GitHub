using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace TravelAgency.Models
{
    [Serializable]
    public class Location : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _cityName;
        private string _countryName;
        private string _fullName;


        public Location()
        {
            _cityName = string.Empty;
            _countryName = string.Empty;
        }

        public Location(string cityName, string countryName)
        {
            CityName = cityName;
            CountryName = countryName;
        }

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
                string acceptsOnlyLettersAndSpaces = "^[A-Za-z ]+$";

                if (propertyName == "CityName")
                {
                    if (string.IsNullOrEmpty(CityName))
                        error = "";

                   else if (Regex.IsMatch(CityName, acceptsOnlyLettersAndSpaces) == false)
                        error = "✘";
                }

                if (propertyName == "CountryName")
                {
                    if (string.IsNullOrEmpty(CountryName))
                        error = "";
                    else if (Regex.IsMatch(CountryName, acceptsOnlyLettersAndSpaces) == false)
                        error = "✘";
                }

                return error;

            }
        }

        public override bool Equals(object obj)
        {
            Location location = obj as Location;

            if (location == null)
                return false;

            if (_fullName == location.FullName)
                return true;
            else
                return false;
        }
    }
}