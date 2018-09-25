using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace TravelAgency.Models
{
    [Serializable]
    public class Customer : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _id;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;
        string acceptsOnlyNumbers = "^[0-9]+$";
        string acceptsOnlyLettersAndSpaces = "^[A-Za-z ]+$";

        public Customer()
        {
            _id = string.Empty;
            _firstName = string.Empty;
            _lastName = string.Empty;
            _phoneNumber = string.Empty;
            _email = string.Empty;
        }

        public Customer(string id, string firstName, string lastName, string email, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public bool HasId(string id)
        {
            if (_id.Equals(id))
                return true;
            return false;
        }

        public bool HasFieldsFilled()
        {
            return !(string.IsNullOrEmpty(_id) ||
                string.IsNullOrEmpty(_firstName) ||
                string.IsNullOrEmpty(_lastName) ||
                string.IsNullOrEmpty(_phoneNumber) ||
                string.IsNullOrEmpty(_email));
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
                if (propertyName == "Id")
                {
                    if (string.IsNullOrEmpty(Id))
                        error = "";
                    else if (Regex.IsMatch(Id, acceptsOnlyNumbers) == false)
                        error = "✘";
                }
                if (propertyName == "FirstName")
                {
                    if (string.IsNullOrEmpty(FirstName))
                        error = "";
                    else if (Regex.IsMatch(FirstName, acceptsOnlyLettersAndSpaces) == false)
                        error = "✘";
                }
                if (propertyName == "LastName")
                {
                    if (string.IsNullOrEmpty(LastName))
                        error = "";
                    else if (Regex.IsMatch(LastName, acceptsOnlyLettersAndSpaces) == false)
                        error = "✘";
                }
                if (propertyName == "PhoneNumber")
                {
                    if (string.IsNullOrEmpty(PhoneNumber))
                        error = "";
                    else if (Regex.IsMatch(PhoneNumber, acceptsOnlyNumbers) == false)
                        error = "✘";
                }
                if(propertyName == "Email")
                {
                    if (string.IsNullOrEmpty(Email))
                        error = "";
                }
                return error;
            }
        }


        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Id) || Regex.IsMatch(Id, acceptsOnlyNumbers) == false || string.IsNullOrEmpty(FirstName) || Regex.IsMatch(FirstName, acceptsOnlyLettersAndSpaces) == false
                || string.IsNullOrEmpty(LastName) || Regex.IsMatch(LastName, acceptsOnlyLettersAndSpaces) == false || string.IsNullOrEmpty(PhoneNumber) ||
                Regex.IsMatch(PhoneNumber, acceptsOnlyNumbers) == false || string.IsNullOrEmpty(Email))

                return false;
            else
                return true;
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
    }
}