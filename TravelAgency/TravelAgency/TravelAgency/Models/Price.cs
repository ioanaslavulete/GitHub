using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TravelAgency.Models
{
    [Serializable]
    public class Price : INotifyPropertyChanged
    {

        private CurrencyType _currency;
        private string _value;
        private string _fullPrice;

        public Price()
        {

        }

        public Price(string value, CurrencyType currency)
        {
            _value = value;
            _currency = currency;
        }

        public CurrencyType Currency
        {
            get { return _currency; }
            set
            {
                _currency = value;
                FullPrice = string.Format(_value + " " + _currency.ToString());
                OnPropertyChanged();
            }
        }
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                FullPrice = string.Format(_value + " " + _currency.ToString());
                OnPropertyChanged();
            }
        }

        public string FullPrice
        {
            get { return _fullPrice; }
            set
            {
                _fullPrice = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return FullPrice;
        }
        [field:NonSerialized]
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
